using FBGroundControl;
using log4net;
using MissionPlanner.Comms;
using MissionPlanner.Controls;
using MissionPlanner.HIL;
using MissionPlanner.Mavlink;
using MissionPlanner.Utilities;
using System;
using System.Collections; // hashs
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;

// stopwatch
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using FBGroundControl.Forms;

namespace MissionPlanner
{
    public class JYLinkMainCtrl : JYLink, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ICommsSerial _baseStream;
        private bool pauseStreams;

        public static UInt32 mainCtrlCmd { get; set; }
        public static byte Bajiid { get; set; }

        public byte id = 0;

        public ICommsSerial BaseStream
        {
            get { return _baseStream; }
            set
            {
                // This is called every time user changes the port selection, so we need to make sure we cleanup
                // any previous objects so we don't leave the cleanup of system resources to the garbage collector.
                if (_baseStream != null)
                {
                    try
                    {
                        if (_baseStream.IsOpen)
                        {
                            _baseStream.Close();
                        }
                    }
                    catch { }
                    IDisposable dsp = _baseStream as IDisposable;
                    if (dsp != null)
                    {
                        try
                        {
                            dsp.Dispose();
                        }
                        catch { }
                    }
                }
                _baseStream = value;
            }
        }

        public ICommsSerial MirrorStream { get; set; }
        public bool MirrorStreamWrite { get; set; }

        public event EventHandler ParamListChanged;

        public event EventHandler MavChanged;

        public event EventHandler CommsClose;

        private const int gcssysid = 255;

        /// <summary>
        /// used to prevent comport access for exclusive use
        /// </summary>



        private DateTime lastparamset = DateTime.MinValue;

        internal string plaintxtline = "";
        private string buildplaintxtline = "";

        public bool ReadOnly = false;
        public bool LinkState = false;

        public TerrainFollow Terrain;

        public event ProgressEventHandler Progress;

        private int _sysidcurrent = 0;

        public int sysidcurrent
        {
            get { return _sysidcurrent; }
            set
            {
                if (_sysidcurrent == value)
                    return;
                _sysidcurrent = value;
                if (MavChanged != null) MavChanged(this, null);
            }
        }

        private int _compidcurrent = 0;

        public int compidcurrent
        {
            get { return _compidcurrent; }
            set
            {
                if (_compidcurrent == value)
                    return;
                _compidcurrent = value;
                if (MavChanged != null) MavChanged(this, null);
            }
        }

        public JYList JYlist = new JYList();

        public JYState JY
        {
            get { return JYlist[sysidcurrent, compidcurrent]; }
            set { JYlist[sysidcurrent, compidcurrent] = value; }
        }

        public double CONNECT_TIMEOUT_SECONDS = 30;

        /// <summary>
        /// progress form to handle connect and param requests
        /// </summary>
        private ProgressReporterDialogue frmProgressReporter;

        /// <summary>
        /// used for outbound packet sending
        /// </summary>
        internal int packetcount = 0;

        private readonly Subject<int> _bytesReceivedSubj = new Subject<int>();
        private readonly Subject<int> _bytesSentSubj = new Subject<int>();

        /// <summary>
        /// Observable of the count of bytes received, notified when the bytes themselves are received
        /// </summary>
        public IObservable<int> BytesReceived
        {
            get { return _bytesReceivedSubj; }
        }

        /// <summary>
        /// Observable of the count of bytes sent, notified when the bytes themselves are received
        /// </summary>
        public IObservable<int> BytesSent
        {
            get { return _bytesSentSubj; }
        }

        /// <summary>
        /// Observable of the count of packets skipped (on reception),
        /// calculated from periods where received packet sequence is not
        /// contiguous
        /// </summary>
        public Subject<int> WhenPacketLost { get; set; }

        public Subject<int> WhenPacketReceived { get; set; }

        /// <summary>
        /// used as a serial port write lock
        /// </summary>
        private volatile object objlock = new object();

        /// <summary>
        /// used for a readlock on readpacket
        /// </summary>
        private volatile object readlock = new object();

        /// <summary>
        /// mavlink version
        /// </summary>
        private byte mavlinkversion = 0;

        /// <summary>
        /// turns on console packet display
        /// </summary>
        public bool debugmavlink { get; set; }

        /// <summary>
        /// enabled read from file mode
        /// </summary>
        public bool logreadmode
        {
            get { return _logreadmode; }
            set { _logreadmode = value; }
        }

        private bool _logreadmode = false;

        private BinaryReader _logplaybackfile;

        public DateTime lastlogread { get; set; }

        public BinaryReader logplaybackfile
        {
            get { return _logplaybackfile; }
            //set { _logplaybackfile = value; JYlist.Clear(); }
            set
            {
                _logplaybackfile = value;
                if (_logplaybackfile != null && _logplaybackfile.BaseStream is FileStream)
                    log.Info("Logplaybackfile set " + ((FileStream)_logplaybackfile.BaseStream).Name);
                JYlist.Clear();
            }
        }

        public BufferedStream logfile { get; set; }
        public BufferedStream rawlogfile { get; set; }

        private int _jylinkcount = 0;
        private int _mavlink2count = 0;
        private int _mavlink2signed = 0;
        private int _bps1 = 0;
        private int _bps2 = 0;
        private DateTime _bpstime { get; set; }

        public JYLinkMainCtrl()
        {
            // init fields
            this.BaseStream = new SerialPort();
            this.packetcount = 0;
            this._bytesReceivedSubj = new Subject<int>();
            this._bytesSentSubj = new Subject<int>();
            this.WhenPacketLost = new Subject<int>();
            this.WhenPacketReceived = new Subject<int>();
            this.readlock = new object();

            this.mavlinkversion = 0;

            this.debugmavlink = false;
            this.logreadmode = false;
            this.lastlogread = DateTime.MinValue;
            this.logplaybackfile = null;
            this.logfile = null;
            this.rawlogfile = null;
            this._bps1 = 0;
            this._bps2 = 0;
            this._bpstime = DateTime.MinValue;
            _jylinkcount = 0;
            _mavlink2count = 0;
            _mavlink2signed = 0;

            //this.lastbad = new byte[2];
        }

        public JYLinkMainCtrl(Stream logfileStream)
            : this()
        {
            logplaybackfile = new BinaryReader(logfileStream);
            logreadmode = true;
        }

        public void Close()
        {
            try
            {
                if (logfile != null)
                    logfile.Close();
            }
            catch
            {
            }
            try
            {
                if (rawlogfile != null)
                    rawlogfile.Close();
            }
            catch
            {
            }
            try
            {
                if (logplaybackfile != null)
                    logplaybackfile.Close();
            }
            catch
            {
            }

            try
            {
                if (BaseStream.IsOpen)
                    BaseStream.Close();
            }
            catch
            {
            }

            try
            {
                if (CommsClose != null)
                    CommsClose(this, null);
            }
            catch
            {
            }
        }

        public void Open()
        {
            Open(false);
        }

        public void Open(bool getparams, bool skipconnectedcheck = false)
        {
            if (BaseStream.IsOpen && !skipconnectedcheck)
                return;

            JYlist.Clear();

            frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                Text = "主控板连接"
            };

            if (getparams)
            {
                frmProgressReporter.DoWork += FrmProgressReporterDoWorkAndParams;
            }
            else
            {
                frmProgressReporter.DoWork += FrmProgressReporterDoWorkNOParams;
            }

            frmProgressReporter.UpdateProgressAndStatus(-1, "正在连接...");

            frmProgressReporter.RunBackgroundOperationAsync();

            frmProgressReporter.Dispose();

            if (ParamListChanged != null)
            {
                ParamListChanged(this, null);
            }
        }

        private void FrmProgressReporterDoWorkAndParams(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            // OpenBg(sender, true, e);
            OpenMC(sender, true, e);
        }

        private void FrmProgressReporterDoWorkNOParams(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            OpenMC(sender, true, e);
        }




        private void OpenMC(object PRsender, bool getparams, ProgressWorkerEventArgs progressWorkerEventArgs)
        {
            frmProgressReporter.UpdateProgressAndStatus(-1, "正在连接...");



            if (BaseStream is SerialPort)
            {
                System.Threading.Thread.Sleep(1000);
            }



            try
            {
                BaseStream.ReadBufferSize = 16 * 1024;

                lock (objlock)
                {
                    log.Info("Open port with " + BaseStream.PortName + " " + BaseStream.BaudRate);

                    BaseStream.Open();

                    BaseStream.DiscardInBuffer();

                    Thread.Sleep(1000);
                }

                JYLinkMCMessage buffer = new JYLinkMCMessage();

                DateTime start = DateTime.Now;
                DateTime deadline = start.AddSeconds(CONNECT_TIMEOUT_SECONDS);

                var countDown = new System.Timers.Timer { Interval = 1000, AutoReset = false };
                countDown.Elapsed += (sender, e) =>
                {
                    int secondsRemaining = (deadline - e.SignalTime).Seconds;
                    frmProgressReporter.UpdateProgressAndStatus(-1, string.Format("尝试连接。在{0}秒后超时", secondsRemaining));
                    if (secondsRemaining > 0) countDown.Start();
                    if (progressWorkerEventArgs.CancelRequested)
                    {
                        progressWorkerEventArgs.CancelAcknowledged = true;
                        countDown.Stop();
                        if (BaseStream.IsOpen)
                            BaseStream.Close();
                        return;
                    }
                };
                countDown.Start();


                while (true)
                {
                    if (progressWorkerEventArgs.CancelRequested)
                    {
                        progressWorkerEventArgs.CancelAcknowledged = true;
                        countDown.Stop();
                        if (BaseStream.IsOpen)
                            BaseStream.Close();
                        return;
                    }

                    log.Info(DateTime.Now.Millisecond + " Start connect loop ");

                    if (DateTime.Now > deadline)
                    {

                        countDown.Stop();
                        this.Close();
                    }

                    System.Threading.Thread.Sleep(1);


                    if (buffer.Length == 0)
                        buffer = getHeartBeat();

                    if (buffer.Length > 5 && buffer.msgid == 0x55)
                    {
                        LinkState = true;

                        break;
                    }
                }

                countDown.Stop();


                frmProgressReporter.UpdateProgressAndStatus(0, "Getting Params.. (sysid " + JY.sysid + " compid " + JY.targetid + ") ");


                if (frmProgressReporter.doWorkArgs.CancelAcknowledged == true)
                {
                    if (BaseStream.IsOpen)
                        BaseStream.Close();
                    return;
                }
            }
            catch (Exception e)
            {
                try
                {
                    BaseStream.Close();
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(progressWorkerEventArgs.ErrorMessage))
                    progressWorkerEventArgs.ErrorMessage = "连接失败！";
                log.Error(e);
                throw;
            }

            frmProgressReporter.UpdateProgressAndStatus(100, "连接成功！");
        }

        private void SetupMavConnect(JYLinkMCMessage message, jylink_status_param_down hb)
        {
            sysidcurrent = message.sysid;
            compidcurrent = message.targetid;

            //mavlinkversion = hb.mavlink_version;
            ////MAV.aptype = (JY_TYPE)hb.type;
            //MAV.apname = (MAV_AUTOPILOT)hb.autopilot;

            //setAPType(message.sysid, message.compid);

            JY.sysid = message.targetid;
            JY.targetid = message.sysid;
            JY.recvpacketcount = message.seq;
            //log.InfoFormat("ID sys {0} comp {1} ver{2} type {3} name {4}", JY.sysid, JY.compid, mavlinkversion,
            //    JY.aptype.ToString(), JY.apname.ToString());
        }

        public JYLinkMCMessage getHeartBeat()
        {

            JYLinkMCMessage buffer;

            //Bajiid = 0;
            generatePacket();


            DateTime start = DateTime.Now;
            int retrys = 3;

            while (true)
            {
                if (!(start.AddMilliseconds(200) > DateTime.Now))
                {
                    if (retrys > 0)
                    {
                        generatePacket();
                        start = DateTime.Now;
                        retrys--;
                        continue;
                    }
                    return new JYLinkMCMessage();
                }
                buffer = readPacket();
                if (buffer != null && buffer.Length > 5)
                {
                    if (buffer.msgid == 0x55)
                    {
                        return buffer;
                    }
                }
            }

            return new JYLinkMCMessage();
        }

        public JYLinkMCMessage getMCData()
        {
            DateTime start = DateTime.Now;
            int readcount = 0;
            while (true)
            {
                JYLinkMCMessage buffer = readPacket();
                readcount++;
                if (buffer.Length > 5)
                {
                    if (buffer.msgid == (byte)JYLINK_MSG_ID.STATUS_PARAM_DOWN)
                    {
                        jylink_status_param_down hb = buffer.ToStructure<jylink_status_param_down>();

                        JY.sysid = buffer.targetid;
                        JY.targetid = buffer.sysid;
                        return buffer;
                    }
                }
                if (DateTime.Now > start.AddMilliseconds(2200) || readcount > 200) // was 1200 , now 2.2 sec
                {
                    return new JYLinkMCMessage();
                }
            }
        }



        private void generatePacket()
        {
            //uses currently targeted mavs sysid and compid
            generatePacket(0, id);

        }

        /// <summary>
        /// Generate a Mavlink Packet and write to serial
        /// </summary>
        /// <param name="messageType">type number = MAVLINK_MSG_ID</param>
        /// <param name="indata">struct of data</param>
        private void generatePacket(int sysid, byte targetid)
        {
            if (!BaseStream.IsOpen)
            {
                return;
            }

            lock (objlock)
            {
                byte[] packet = new byte[6];//2020
                int i = 0;

                packet[0] = 0xEB;
                packet[1] = 0x90;
                packet[2] = 0x01;
                packet[3] = 1;
                packet[4] = targetid;
                byte crc = JylinkCRC.crc_calculate2(packet);
                packet[5] = crc;
                if (BaseStream.IsOpen)
                {
                    BaseStream.Write(packet, 0, packet.Length);
                }

            }
        }

        public bool Write(string line)
        {
            lock (objlock)
            {
                BaseStream.Write(line);
            }
            _bytesSentSubj.OnNext(line.Length);
            return true;
        }









        /// <summary>
        /// used for last bad serial characters
        /// </summary>
        private byte[] lastbad = new byte[2];

        private double t7 = 1.0e7;
        private void ReadWithTimeout(ICommsSerial BaseStream, byte[] buffer, int offset, int count)
        {

            int timeout = BaseStream.ReadTimeout;

            if (timeout == -1)
                timeout = 60000;

            DateTime to = DateTime.Now.AddMilliseconds(timeout);

            int toread = count;
            int pos = offset;

            while (true)
            {
                // read from stream
                int read = BaseStream.Read(buffer, pos, toread);

                // update counter
                toread -= read;
                pos += read;

                // reset timeout if we get data
                if (read > 0)
                    to = DateTime.Now.AddMilliseconds(timeout);

                if (toread == 0)
                    break;

                if (DateTime.Now > to)
                {
                    throw new TimeoutException("Timeout waiting for data");
                }
                System.Threading.Thread.Sleep(1);
            }

        }


        /// <summary>
        /// Serial Reader to read mavlink packets. POLL method
        /// </summary>
        /// <returns></returns>
        public JYLinkMCMessage readPacket()
        {
            byte[] buffer = new byte[270];

            int readcount = 0;
            BaseStream.ReadTimeout = 1200;
            if (logreadmode)
            {
                int lengthData = readlogPacketMavlink(buffer);
                Array.Resize<byte>(ref buffer, lengthData);

            }
            else
            {
                while (readcount < 200 || logreadmode)
                {
                    ReadWithTimeout(BaseStream, buffer, 0, 1);

                    if (buffer[0] == 0xEB)
                        break;

                    readcount += 1;
                }

                // read header
                ReadWithTimeout(BaseStream, buffer, 1, 1);

                // packet length
                int lengthtoread = 0;
                if ((buffer[0] == 0xEB) && (buffer[1] == 0x90))
                {
                    lengthtoread = 14; // data + header + checksum - magic - length
                    for (int i = 0; i < 12; i++)
                    {
                        ReadWithTimeout(BaseStream, buffer, 2 + i, 1);
                    }
                    Array.Resize<byte>(ref buffer, lengthtoread);
                }
                //read rest of packet




            }


            JYLinkMCMessage message = new JYLinkMCMessage(buffer);
            uint msgid = message.msgid;

            byte crc = 0;

            for (int i = 0; i < message.Length - 1; i++)
            {
                crc ^= buffer[i];
            }


            if (crc != buffer[buffer.Length - 1])
            {
                return null;
            }
            else
            {
                //写入tlog日志记录
                try
                {
                    JYLink.jylink_mainctrl_command_setup mainctrlCmd = new JYLink.jylink_mainctrl_command_setup();
                    if (buffer[4] == 255)
                    {
                        if (MainForm.instance.Zhan_id == 0)
                        {
                            Bajiid = 0xFF;
                        }
                        else
                        {
                            Bajiid = (byte)(0xF0 + MainForm.instance.Zhan_id);
                        }

                    }
                    else
                    {
                        Bajiid = MainForm.instance.Table_id[buffer[4] - 1];
                    }
                    id = buffer[4];
                    mainctrlCmd.command1 = buffer[5];
                    mainctrlCmd.command2 = buffer[6];
                    mainctrlCmd.command3 = buffer[7];
                    mainctrlCmd.command4 = buffer[8];
                    mainctrlCmd.command5 = buffer[9];
                    mainctrlCmd.command6 = buffer[10];
                    mainctrlCmd.command7 = buffer[11];
                    mainctrlCmd.command8 = buffer[12];

                    JYLinkInterface port = MainForm.comPort;
                    if (port.BaseStream.IsOpen)
                    {
                        port.mainCtrlCmdSetup(mainctrlCmd);
                    }


                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                return message;
            }
        }


        public enum sensoroffsetsenum
        {
            gyro = 0,
            accelerometer = 1,
            magnetometer = 2,
            barometer = 3,
            optical_flow = 4,
            second_magnetometer = 5
        }

        public bool SetSensorOffsets(sensoroffsetsenum sensor, float x, float y, float z)
        {
            //return doCommand(MAV_CMD.PREFLIGHT_SET_SENSOR_OFFSETS, (int)sensor, x, y, z, 0, 0, 0);
            return true;
        }

        private int readlogPacketMavlink(byte[] temp)
        {

            //  public DataPlayback dataPlayback = new DataPlayback();

            byte[] datearray = new byte[8];


            int a = 0;
            while (a < 24)
            {
                if (logplaybackfile.BaseStream.Position == logplaybackfile.BaseStream.Length)
                    break;
                temp[a] = (byte)logplaybackfile.ReadByte();

                if (temp[0] != 0xCC)
                {
                    a = 0;
                    continue;
                }
                if (a == 1)
                {
                    if (temp[0] != 0xDD)
                    {
                        a = 0;
                        continue;
                    }

                }

                a++;
            }

            //           Array.Resize<byte>(ref temp, length);
            JYLinkMessage tmp = new JYLinkMessage(temp);

            if (tmp.msgid.Equals(0x4D))
            {
                // System.Threading.Thread.Sleep((int)(1000 / MainForm.dataPlayback.LogPlayBackSpeed));
            }

            return a;

        }





        public override string ToString()
        {
            if (BaseStream.IsOpen)
                return "MAV " + JY.sysid + " on " + BaseStream.PortName;

            if (logreadmode)
                return "MAV " + JY.sysid + " on LogFile";

            return "MAV " + JY.sysid + " on Ice";
        }

        public void Dispose()
        {
            if (_bytesReceivedSubj != null)
                _bytesReceivedSubj.Dispose();
            if (_bytesSentSubj != null)
                _bytesSentSubj.Dispose();
            this.Close();

            Terrain = null;

            MirrorStream = null;

            logreadmode = false;
            logplaybackfile = null;
        }
    }
}