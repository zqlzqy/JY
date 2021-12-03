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

namespace MissionPlanner
{
    public class JYLinkInterface : JYLink, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ICommsSerial _baseStream;
        private bool pauseStreams;


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
        public bool giveComport
        {
            get { return _giveComport; }
            set { _giveComport = value; }
        }
        public byte targetid
        {
            get;
            set;
        }
        public byte Zhan_id
        {
            get;
            set;
        }
        private volatile bool _giveComport = false;

        private DateTime lastparamset = DateTime.MinValue;

        internal string plaintxtline = "";
        private string buildplaintxtline = "";

        public bool ReadOnly = false;

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

        public JYLinkInterface()
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

        public JYLinkInterface(Stream logfileStream)
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
                Text = "测控电台连接"
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
            OpenBg(sender, true, e);
        }

        private void FrmProgressReporterDoWorkNOParams(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            OpenBg(sender, true, e);
        }

        private void OpenBg(object PRsender, bool getparams, ProgressWorkerEventArgs progressWorkerEventArgs)
        {
            //BaseStream.Open();
            frmProgressReporter.UpdateProgressAndStatus(-1, "正在连接...");

            giveComport = true;

            if (BaseStream is SerialPort)
            {
                // allow settings to settle - previous dtr
                System.Threading.Thread.Sleep(1000);
            }

            Terrain = new TerrainFollow(this);

            bool hbseen = false;

            try
            {
                BaseStream.ReadBufferSize = 16 * 1024;

                lock (objlock) // so we dont have random traffic
                {
                    log.Info("Open port with " + BaseStream.PortName + " " + BaseStream.BaudRate);
                    BaseStream.RtsEnable = true;
                    BaseStream.Open();

                    BaseStream.DiscardInBuffer();

                    // other boards seem to have issues if there is no delay? posible bootloader timeout issue
                    Thread.Sleep(1000);
                }

                JYLinkMessage buffer = new JYLinkMessage();
                JYLinkMessage buffer1 = new JYLinkMessage();

                DateTime start = DateTime.Now;
                DateTime deadline = start.AddSeconds(CONNECT_TIMEOUT_SECONDS);

                var countDown = new System.Timers.Timer { Interval = 1000, AutoReset = false };
                countDown.Elapsed += (sender, e) =>
                {
                    int secondsRemaining = (deadline - e.SignalTime).Seconds;
                    frmProgressReporter.UpdateProgressAndStatus(-1, string.Format("尝试连接。在{0}秒后超时", secondsRemaining));
                    if (secondsRemaining > 0) countDown.Start();
                };
                countDown.Start();

                // px4 native
                //BaseStream.WriteLine("sh /etc/init.d/rc.usb");

                int count = 0;

                while (true)
                {
                    if (progressWorkerEventArgs.CancelRequested)
                    {
                        progressWorkerEventArgs.CancelAcknowledged = true;
                        countDown.Stop();
                        if (BaseStream.IsOpen)
                            BaseStream.Close();
                        giveComport = false;
                        return;
                    }

                    log.Info(DateTime.Now.Millisecond + " Start connect loop ");

                    if (DateTime.Now > deadline)
                    {
                        //if (Progress != null)
                        //    Progress(-1, "No Heartbeat Packets");
                        countDown.Stop();
                        this.Close();

                        if (hbseen)
                        {
                            progressWorkerEventArgs.ErrorMessage = Strings.Only1Hb;
                            throw new Exception(Strings.Only1HbD);
                        }
                        else
                        {
                            progressWorkerEventArgs.ErrorMessage = "No Heartbeat Packets Received";
                            throw new Exception("Can not establish a connection");
                        }
                    }

                    System.Threading.Thread.Sleep(1);

                    // can see 2 heartbeat packets at any time, and will connect - was one after the other

                    if (buffer.Length == 0)
                        buffer = getHeartBeat();

                    System.Threading.Thread.Sleep(1);

                    if (buffer1.Length == 0)
                        buffer1 = getHeartBeat();

                    if (buffer.Length > 0 || buffer1.Length > 0)
                        hbseen = false;

                    count++;

                    // 2 hbs that match
                    if (buffer != null && buffer.Length > 5 && buffer1.Length > 5)//&& buffer.sysid == buffer1.sysid && buffer.targetid == buffer1.targetid)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.STATUS_PARAM_DOWN)
                        {
                            jylink_status_param_down hb = buffer.ToStructure<jylink_status_param_down>();
                            SetupMavConnect(buffer, hb);
                        }
                        else
                        {
                            jylink_status_down hbb = buffer.ToStructure<jylink_status_down>();
                            SetupMavConnect(buffer, hbb);
                        }
                        break;
                        //}
                    }

                    // 2 hb's that dont match. more than one sysid here
                    if (buffer != null && buffer.Length > 5 && buffer1.Length > 5)// && (buffer.sysid == buffer1.sysid || buffer.targetid == buffer1.targetid))
                    {
                     
                        //if (hb.type != (byte)MAVLink.MAV_TYPE.ANTENNA_TRACKER && hb.type != (byte)MAVLink.MAV_TYPE.GCS)
                        //{
                        //    SetupMavConnect(buffer, hb);
                        //    break;
                        //}

                        //hb = buffer1.ToStructure<mavlink_heartbeat_t>();

                        //if (hb.type != (byte)MAVLink.MAV_TYPE.ANTENNA_TRACKER && hb.type != (byte)MAVLink.MAV_TYPE.GCS)
                        //{
                        //    SetupMavConnect(buffer1, hb);
                        //    break;
                        //}
                    }
                }

                countDown.Stop();

                //getVersion();

                frmProgressReporter.UpdateProgressAndStatus(0,
                    "Getting Params.. (sysid " + JY.sysid + " compid " + JY.targetid + ") ");

                //byte[] temp = ASCIIEncoding.ASCII.GetBytes("Mission Planner " + Application.ProductVersion + "\0");
                //Array.Resize(ref temp, 50);

                //generatePacket((byte)MAVLINK_MSG_ID.STATUSTEXT,
                //    new mavlink_statustext_t() { severity = (byte)MAV_SEVERITY.INFO, text = temp });
                // mavlink2
                //generatePacket((byte)MAVLINK_MSG_ID.STATUSTEXT,
                //    new mavlink_statustext_t() { severity = (byte)MAV_SEVERITY.INFO, text = temp }, sysidcurrent,
                //    compidcurrent, true, true);

                //if (getparams)
                //{
                //    getParamListBG();
                //}

                if (frmProgressReporter.doWorkArgs.CancelAcknowledged == true)
                {
                    giveComport = false;
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
                giveComport = false;
                if (string.IsNullOrEmpty(progressWorkerEventArgs.ErrorMessage))
                    progressWorkerEventArgs.ErrorMessage = "连接失败！";
                log.Error(e);
                throw;
            }
            //frmProgressReporter.Close();
            giveComport = false;
            frmProgressReporter.UpdateProgressAndStatus(100, "连接成功！");
            //log.Info("Done open " + MAV.sysid + " " + MAV.compid);
            JY.packetslost = 0;
            JY.synclost = 0;
        }
        private void SetupMavConnect(JYLinkMessage message, jylink_status_down hb)
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
        private void SetupMavConnect(JYLinkMessage message, jylink_status_param_down hb)
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

        public JYLinkMessage getHeartBeat()
        {
            giveComport = true;
            DateTime start = DateTime.Now;
            int readcount = 0;
            while (true)
            {
                JYLinkMessage buffer = readPacket();
                readcount++;
                if (buffer != null && buffer.Length > 5)
                {
                    //log.Info("getHB packet received: " + buffer.Length + " btr " + BaseStream.BytesToRead + " type " + buffer.msgid );
                    if (buffer.msgid == (byte)JYLINK_MSG_ID.STATUS_PARAM_DOWN)
                    {
                        jylink_status_param_down hb = buffer.ToStructure<jylink_status_param_down>();

                        JY.sysid = buffer.targetid;
                        JY.targetid = buffer.sysid;
                        return buffer;
                    }
                    if (buffer.msgid == (byte)JYLINK_MSG_ID.STATUS_DOWN)
                    {
                        jylink_status_down hb = buffer.ToStructure<jylink_status_down>();

                        JY.sysid = buffer.targetid;
                        JY.targetid = buffer.sysid;
                        return buffer;
                    }
                }
                if (DateTime.Now > start.AddMilliseconds(2200) || readcount > 200) // was 1200 , now 2.2 sec
                {
                    giveComport = false;
                    return new JYLinkMessage();
                }
            }
        }

        public void sendPacket(object indata, int sysid, int compid)
        {
            //bool validPacket = false;
            //foreach (var ty in jy_message_info)
            //{
            //    if (ty.Value == indata.GetType())
            //    {
            //        validPacket = true;
            //        generatePacket((int)ty.Key, indata, sysid, compid);
            //        return;
            //    }
            //}
            //if (!validPacket)
            //{
            //    log.Info("Mavlink : NOT VALID PACKET sendPacket() " + indata.GetType().ToString());
            //}
        }

        private void generatePacket(int messageType, object indata)
        {
            //uses currently targeted mavs sysid and compid
            generatePacket(messageType, indata, Zhan_id, targetid);
        }
        private void generatePacket_ship(int messageType, object indata)
        {
            //uses currently targeted mavs sysid and compid
            generatePacket(messageType, indata, Zhan_id, 255);
        }
        /// <summary>
        /// Generate a Mavlink Packet and write to serial
        /// </summary>
        /// <param name="messageType">type number = MAVLINK_MSG_ID</param>
        /// <param name="indata">struct of data</param>
        private void generatePacket(int messageType, object indata, int sysid, int targetid)
        {
            if (!BaseStream.IsOpen)
            {
                return;
            }


            byte[] data = JylinkUtil.StructureToByteArray(messageType, indata);
            //byte[] data = new byte[0];
            byte[] packet = new byte[0];
            int i = 0;

            // are we mavlink2 enabled for this sysid/compid
            if (messageType < 256)
            {
                //var info = JYLINK_MESSAGE_INFOS.SingleOrDefault(p => p.msgid == messageType);
                //if (data.Length + 8 != info.minlength)
                //{
                //    Array.Resize(ref data, (int)info.minlength);
                //}

                packet = new byte[data.Length + 8];

                packet[0] = JYLINK_STX_1;
                packet[1] = JYLINK_STX_2;
                packet[2] = (byte)messageType;
                packet[3] = (byte)sysid;
                packet[4] = (byte)targetid;

                packet[5] = (byte)packetcount;
                packet[6] = (byte)data.Length;

                packetcount++;


                i = 7;
                foreach (byte b in data)
                {
                    packet[i] = b;
                    i++;
                }
                byte crc = JylinkCRC.crc_calculate(packet, packet.Length - 1);
                packet[packet.Length - 1] = crc;
            }

            if (BaseStream.IsOpen)
            {
                lock (objlock)
                {
                    BaseStream.Write(packet, 0, packet.Length);

                }
                //_bytesSentSubj.OnNext(i);
            }

            try   
            {
                //MessageBox.Show(logfile.ToString());
                if (logfile != null && logfile.CanWrite)
                {
                    lock (logfile)
                    {
                        if (packet[2]!=0x22)
                        {
                            logfile.Write(packet, 0, packet.Length);  
                        }                        
                    }
                }
            }
            catch
            {
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

        public bool setupSigning(string userseed, byte[] key = null)
        {
            //    byte[] shauser;
            //    bool clearkey = false;

            //    if (key == null)
            //    {
            //        clearkey = String.IsNullOrEmpty(userseed);

            //        // sha the user input string
            //        SHA256Managed signit = new SHA256Managed();
            //        shauser = signit.ComputeHash(Encoding.UTF8.GetBytes(userseed));
            //        Array.Resize(ref shauser, 32);
            //    }
            //    else
            //    {
            //        shauser = key;
            //        Array.Resize(ref shauser, 32);
            //    }

            //    mavlink_setup_signing_t sign = new mavlink_setup_signing_t();
            //    if (!clearkey)
            //    {
            //        MAV.signingKey = shauser;
            //        sign.initial_timestamp = (UInt64)((DateTime.UtcNow - new DateTime(2015, 1, 1)).TotalMilliseconds * 100);
            //        sign.secret_key = shauser;
            //    }
            //    else
            //    {
            //        MAV.signingKey = new byte[32];
            //        sign.initial_timestamp = 0;
            //        sign.secret_key = new byte[32];
            //    }
            //    sign.target_component = (byte)compidcurrent;
            //    sign.target_system = (byte)sysidcurrent;

            //    generatePacket((int)MAVLINK_MSG_ID.SETUP_SIGNING, sign, MAV.sysid, MAV.compid);

            //    generatePacket((int)MAVLINK_MSG_ID.SETUP_SIGNING, sign, MAV.sysid, MAV.compid);

            //    if (clearkey)
            //    {
            //        return disableSigning(sysidcurrent, compidcurrent);
            //    }

            //    return enableSigning(sysidcurrent, compidcurrent);
            return true;
        }

        public bool enableSigning(int sysid, int compid)
        {
            JYlist[sysid, compid].signing = true;
            JYlist[sysid, compid].mavlinkv2 = true;

            return JYlist[sysid, compid].signing;
        }

        public bool disableSigning(int sysid, int compid)
        {
            JYlist[sysid, compid].signing = false;
            JYlist[sysid, compid].mavlinkv2 = false;

            return JYlist[sysid, compid].signing;
        }

        /// <summary>
        /// set param on apm, used for param rename
        /// </summary>
        /// <param name="paramname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool setParam(string[] paramnames, double value)
        {
            foreach (string paramname in paramnames)
            {
                if (setParam(paramname, value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set parameter on apm
        /// </summary>
        /// <param name="paramname">name as a string</param>
        /// <param name="value"></param>
        public bool setParam(string paramname, double value, bool force = false)
        {
            //if (!MAV.param.ContainsKey(paramname))
            //{
            //    log.Warn("Trying to set Param that doesnt exist " + paramname + "=" + value);
            //    return false;
            //}

            //if (MAV.param[paramname].Value == value && !force)
            //{
            //    log.Warn("setParam " + paramname + " not modified as same");
            //    return true;
            //}

            //giveComport = true;

            //// param type is set here, however it is always sent over the air as a float 100int = 100f.
            //var req = new mavlink_param_set_t
            //{
            //    target_system = MAV.sysid,
            //    target_component = MAV.compid,
            //    param_type = (byte)MAV.param_types[paramname]
            //};

            //byte[] temp = Encoding.ASCII.GetBytes(paramname);

            //Array.Resize(ref temp, 16);
            //req.param_id = temp;
            //if (MAV.apname == MAV_AUTOPILOT.ARDUPILOTMEGA)
            //{
            //    req.param_value = new MAVLinkParam(paramname, value, (MAV_PARAM_TYPE.REAL32)).float_value;
            //}
            //else
            //{
            //    req.param_value =
            //        new MAVLinkParam(paramname, value, (MAV_PARAM_TYPE)MAV.param_types[paramname]).float_value;
            //}

            //generatePacket((byte)MAVLINK_MSG_ID.PARAM_SET, req);

            //log.InfoFormat("setParam '{0}' = '{1}' sysid {2} compid {3}", paramname, req.param_value, MAV.sysid,
            //    MAV.compid);

            //DateTime start = DateTime.Now;
            //int retrys = 3;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(700) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("setParam Retry " + retrys);
            //            generatePacket((byte)MAVLINK_MSG_ID.PARAM_SET, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - setParam " + paramname);
            //    }

            //    MAVLinkMessage buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.PARAM_VALUE)
            //        {
            //            mavlink_param_value_t par = buffer.ToStructure<mavlink_param_value_t>();

            //            string st = System.Text.ASCIIEncoding.ASCII.GetString(par.param_id);

            //            int pos = st.IndexOf('\0');

            //            if (pos != -1)
            //            {
            //                st = st.Substring(0, pos);
            //            }

            //            if (st != paramname)
            //            {
            //                log.InfoFormat("MAVLINK bad param response - {0} vs {1}", paramname, st);
            //                continue;
            //            }

            //            log.Info("setParam gotback " + st + " : " + par.param_value);

            //            if (MAV.apname == MAV_AUTOPILOT.ARDUPILOTMEGA)
            //            {
            //                MAV.param[st] = new MAVLinkParam(st, par.param_value, MAV_PARAM_TYPE.REAL32, (MAV_PARAM_TYPE)par.param_type);
            //            }
            //            else
            //            {
            //                MAV.param[st] = new MAVLinkParam(st, par.param_value, (MAV_PARAM_TYPE)par.param_type);
            //            }

            //            lastparamset = DateTime.Now;

            //            giveComport = false;
            //            //System.Threading.Thread.Sleep(100);//(int)(8.5 * 5)); // 8.5ms per byte
            //            return true;
            //        }
            //    }
            //}
            return true;
        }

        /*
        public Bitmap getImage()
        {
            MemoryStream ms = new MemoryStream();
        }
        */

        public void getParamList()
        {
            frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                Text = Strings.GettingParams + " " + sysidcurrent
            };

            frmProgressReporter.DoWork += FrmProgressReporterGetParams;
            frmProgressReporter.UpdateProgressAndStatus(-1, Strings.GettingParamsD);

            frmProgressReporter.RunBackgroundOperationAsync();

            frmProgressReporter.Dispose();

            if (ParamListChanged != null)
            {
                ParamListChanged(this, null);
            }
        }

        private void FrmProgressReporterGetParams(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            getParamListBG();
        }

        public static bool MONO = false;

        /// <summary>
        /// Get param list from apm
        /// </summary>
        /// <returns></returns>
        private Hashtable getParamListBG()
        {
            return null;
            //giveComport = true;
            //List<int> indexsreceived = new List<int>();

            //// create new list so if canceled we use the old list
            //MAVLinkParamList newparamlist = new MAVLinkParamList();

            //int param_total = 1;

            //mavlink_param_request_list_t req = new mavlink_param_request_list_t();
            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;

            //generatePacket((byte)MAVLINK_MSG_ID.PARAM_REQUEST_LIST, req);

            //DateTime start = DateTime.Now;
            //DateTime restart = DateTime.Now;

            //DateTime lastmessage = DateTime.MinValue;

            ////hires.Stopwatch stopwatch = new hires.Stopwatch();
            //int packets = 0;
            //bool onebyone = false;
            //DateTime lastonebyone = DateTime.MinValue;

            //do
            //{
            //    if (frmProgressReporter.doWorkArgs.CancelRequested)
            //    {
            //        frmProgressReporter.doWorkArgs.CancelAcknowledged = true;
            //        giveComport = false;
            //        frmProgressReporter.doWorkArgs.ErrorMessage = "User Canceled";
            //        return MAV.param;
            //    }

            //    // 4 seconds between valid packets
            //    if (!(start.AddMilliseconds(4000) > DateTime.Now) && !logreadmode)
            //    {
            //        onebyone = true;

            //        if (lastonebyone.AddMilliseconds(600) < DateTime.Now)
            //        {
            //            log.Info("Get param 1 by 1 - got " + indexsreceived.Count + " of " + param_total);

            //            int queued = 0;
            //            // try getting individual params
            //            for (short i = 0; i <= (param_total - 1); i++)
            //            {
            //                if (!indexsreceived.Contains(i))
            //                {
            //                    if (frmProgressReporter.doWorkArgs.CancelRequested)
            //                    {
            //                        frmProgressReporter.doWorkArgs.CancelAcknowledged = true;
            //                        giveComport = false;
            //                        frmProgressReporter.doWorkArgs.ErrorMessage = "User Canceled";
            //                        return MAV.param;
            //                    }

            //                    // prevent dropping out of this get params loop
            //                    try
            //                    {
            //                        queued++;

            //                        mavlink_param_request_read_t req2 = new mavlink_param_request_read_t();
            //                        req2.target_system = MAV.sysid;
            //                        req2.target_component = MAV.compid;
            //                        req2.param_index = i;
            //                        req2.param_id = new byte[] { 0x0 };

            //                        Array.Resize(ref req2.param_id, 16);

            //                        generatePacket((byte)MAVLINK_MSG_ID.PARAM_REQUEST_READ, req2);

            //                        if (queued >= 10)
            //                        {
            //                            lastonebyone = DateTime.Now;
            //                            break;
            //                        }
            //                    }
            //                    catch (Exception excp)
            //                    {
            //                        log.Info("GetParam Failed index: " + i + " " + excp);
            //                        throw excp;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    //Console.WriteLine(DateTime.Now.Millisecond + " gp0 ");

            //    MAVLinkMessage buffer = readPacket();
            //    //Console.WriteLine(DateTime.Now.Millisecond + " gp1 ");
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        packets++;
            //        // stopwatch.Start();
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.PARAM_VALUE && buffer.sysid == req.target_system && buffer.compid == req.target_component)
            //        {
            //            restart = DateTime.Now;
            //            // if we are doing one by one dont update start time
            //            if (!onebyone)
            //                start = DateTime.Now;

            //            mavlink_param_value_t par = buffer.ToStructure<mavlink_param_value_t>();

            //            // set new target
            //            param_total = (par.param_count);

            //            string paramID = System.Text.ASCIIEncoding.ASCII.GetString(par.param_id);

            //            int pos = paramID.IndexOf('\0');
            //            if (pos != -1)
            //            {
            //                paramID = paramID.Substring(0, pos);
            //            }

            //            // check if we already have it
            //            if (indexsreceived.Contains(par.param_index))
            //            {
            //                log.Info("Already got " + (par.param_index) + " '" + paramID + "'");
            //                this.frmProgressReporter.UpdateProgressAndStatus((indexsreceived.Count * 100) / param_total,
            //                    "Already Got param " + paramID);
            //                continue;
            //            }

            //            //Console.WriteLine(DateTime.Now.Millisecond + " gp2 ");

            //            if (!MainForm.MONO)
            //                log.Info(DateTime.Now.Millisecond + " got param " + (par.param_index) + " of " +
            //                         (par.param_count) + " name: " + paramID);

            //            //Console.WriteLine(DateTime.Now.Millisecond + " gp2a ");

            //            if (MAV.apname == MAV_AUTOPILOT.ARDUPILOTMEGA)
            //            {
            //                newparamlist[paramID] = new MAVLinkParam(paramID, par.param_value, MAV_PARAM_TYPE.REAL32, (MAV_PARAM_TYPE)par.param_type);
            //            }
            //            else
            //            {
            //                newparamlist[paramID] = new MAVLinkParam(paramID, par.param_value,
            //                    (MAV_PARAM_TYPE)par.param_type);
            //            }

            //            //Console.WriteLine(DateTime.Now.Millisecond + " gp2b ");

            //            // exclude index of 65535
            //            if (par.param_index != 65535)
            //                indexsreceived.Add(par.param_index);

            //            MAV.param_types[paramID] = (MAV_PARAM_TYPE)par.param_type;

            //            //Console.WriteLine(DateTime.Now.Millisecond + " gp3 ");

            //            this.frmProgressReporter.UpdateProgressAndStatus((indexsreceived.Count * 100) / param_total,
            //                Strings.Gotparam + paramID);

            //            // we hit the last param - lets escape eq total = 176 index = 0-175
            //            if (par.param_index == (param_total - 1))
            //                start = DateTime.MinValue;
            //        }
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.STATUSTEXT)
            //        {
            //            var msg = buffer.ToStructure<MAVLink.mavlink_statustext_t>();

            //            string logdata = Encoding.ASCII.GetString(msg.text);

            //            int ind = logdata.IndexOf('\0');
            //            if (ind != -1)
            //                logdata = logdata.Substring(0, ind);

            //            if (logdata.ToLower().Contains("copter") || logdata.ToLower().Contains("rover") ||
            //                logdata.ToLower().Contains("plane"))
            //            {
            //                MAV.VersionString = logdata;
            //            }
            //            else if (logdata.ToLower().Contains("nuttx"))
            //            {
            //                MAV.SoftwareVersions = logdata;
            //            }
            //            else if (logdata.ToLower().Contains("px4v2"))
            //            {
            //                MAV.SerialString = logdata;
            //            }
            //            else if (logdata.ToLower().Contains("frame"))
            //            {
            //                MAV.FrameString = logdata;
            //            }
            //        }
            //        //stopwatch.Stop();
            //        // Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //        // Console.WriteLine(DateTime.Now.Millisecond + " gp4 " + BaseStream.BytesToRead);
            //    }
            //    if (logreadmode && logplaybackfile.BaseStream.Position >= logplaybackfile.BaseStream.Length)
            //    {
            //        break;
            //    }
            //    if (!logreadmode && !BaseStream.IsOpen)
            //    {
            //        var exp = new Exception("Not Connected");
            //        frmProgressReporter.doWorkArgs.ErrorMessage = exp.Message;
            //        throw exp;
            //    }
            //} while (indexsreceived.Count < param_total);

            //if (indexsreceived.Count != param_total)
            //{
            //    var exp = new Exception("Missing Params " + indexsreceived.Count + " vs " + param_total);
            //    frmProgressReporter.doWorkArgs.ErrorMessage = exp.Message;
            //    throw exp;
            //}
            //giveComport = false;

            //MAV.param.Clear();
            //MAV.param.AddRange(newparamlist);
            //return MAV.param;
        }

        public float GetParam(string name)
        {
            return GetParam(name, -1);
        }

        public float GetParam(short index)
        {
            return GetParam("", index);
        }

        /// <summary>
        /// Get param by either index or name
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal float GetParam(string name = "", short index = -1)
        {
            //if (name == "" && index == -1)
            //    return 0;

            //log.Info("GetParam name: '" + name + "' or index: " + index);

            //giveComport = true;
            //MAVLinkMessage buffer;

            //mavlink_param_request_read_t req = new mavlink_param_request_read_t();
            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            //req.param_index = index;
            //req.param_id = new byte[] { 0x0 };
            //if (index == -1)
            //{
            //    req.param_id = System.Text.ASCIIEncoding.ASCII.GetBytes(name);
            //}

            //Array.Resize(ref req.param_id, 16);

            //generatePacket((byte)MAVLINK_MSG_ID.PARAM_REQUEST_READ, req);

            //DateTime start = DateTime.Now;
            //int retrys = 3;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(700) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("GetParam Retry " + retrys);
            //            generatePacket((byte)MAVLINK_MSG_ID.PARAM_REQUEST_READ, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - GetParam");
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.PARAM_VALUE && buffer.sysid == req.target_system && buffer.compid == req.target_component)
            //        {
            //            giveComport = false;

            //            mavlink_param_value_t par = buffer.ToStructure<mavlink_param_value_t>();

            //            string st = System.Text.ASCIIEncoding.ASCII.GetString(par.param_id);

            //            int pos = st.IndexOf('\0');

            //            if (pos != -1)
            //            {
            //                st = st.Substring(0, pos);
            //            }

            //            // not the correct id
            //            if (!(par.param_index == index || st == name))
            //            {
            //                log.ErrorFormat("Wrong Answer {0} - {1} - {2}    --- '{3}' vs '{4}'", par.param_index,
            //                    ASCIIEncoding.ASCII.GetString(par.param_id), par.param_value,
            //                    ASCIIEncoding.ASCII.GetString(req.param_id).TrimEnd(), st);
            //                continue;
            //            }

            //            // update table
            //            if (MAV.apname == MAV_AUTOPILOT.ARDUPILOTMEGA)
            //            {
            //                MAV.param[st] = new MAVLinkParam(st, par.param_value, MAV_PARAM_TYPE.REAL32, (MAV_PARAM_TYPE)par.param_type);
            //            }
            //            else
            //            {
            //                MAV.param[st] = new MAVLinkParam(st, par.param_value, (MAV_PARAM_TYPE)par.param_type);
            //            }

            //            MAV.param_types[st] = (MAV_PARAM_TYPE)par.param_type;

            //            log.Info(DateTime.Now.Millisecond + " got param " + (par.param_index) + " of " +
            //                     (par.param_count) + " name: " + st);

            //            return par.param_value;
            //        }
            //    }
            //}
            return 0;
        }

        public static void modifyParamForDisplay(bool fromapm, string paramname, ref float value)
        {
            int planforremoval;

            if (paramname.ToUpper().EndsWith("_IMAX") || paramname.ToUpper().EndsWith("ALT_HOLD_RTL") ||
                paramname.ToUpper().EndsWith("APPROACH_ALT") || paramname.ToUpper().EndsWith("TRIM_ARSPD_CM") ||
                paramname.ToUpper().EndsWith("MIN_GNDSPD_CM")
                || paramname.ToUpper().EndsWith("XTRK_ANGLE_CD") || paramname.ToUpper().EndsWith("LIM_PITCH_MAX") ||
                paramname.ToUpper().EndsWith("LIM_PITCH_MIN")
                || paramname.ToUpper().EndsWith("LIM_ROLL_CD") || paramname.ToUpper().EndsWith("PITCH_MAX") ||
                paramname.ToUpper().EndsWith("WP_SPEED_MAX"))
            {
                if (paramname.ToUpper().EndsWith("THR_RATE_IMAX") || paramname.ToUpper().EndsWith("THR_HOLD_IMAX")
                    || paramname.ToUpper().EndsWith("RATE_RLL_IMAX") || paramname.ToUpper().EndsWith("RATE_PIT_IMAX"))
                    return;

                if (fromapm)
                {
                    value /= 100.0f;
                }
                else
                {
                    value *= 100.0f;
                }
            }
            else if (paramname.ToUpper().StartsWith("TUNE_"))
            {
                if (fromapm)
                {
                    value /= 1000.0f;
                }
                else
                {
                    value *= 1000.0f;
                }
            }
        }

        /// <summary>
        /// Stops all requested data packets.
        /// </summary>
        public void stopall(bool forget)
        {
            //mavlink_request_data_stream_t req = new mavlink_request_data_stream_t();
            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;

            //req.req_message_rate = 10;
            //req.start_stop = 0; // stop
            //req.req_stream_id = 0; // all

            //// no error on bad
            //try
            //{
            //    generatePacket((byte)MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
            //    System.Threading.Thread.Sleep(20);
            //    generatePacket((byte)MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
            //    System.Threading.Thread.Sleep(20);
            //    generatePacket((byte)MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
            //    log.Info("Stopall Done");
            //}
            //catch
            //{
            //}
        }

        public void setWPACK()
        {
            //MAVLink.mavlink_mission_ack_t req = new MAVLink.mavlink_mission_ack_t();
            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            //req.type = 0;

            //generatePacket((byte)MAVLINK_MSG_ID.MISSION_ACK, req);
        }

        public bool setWPCurrent(ushort index)
        {
            return true;
            //giveComport = true;
            //MAVLinkMessage buffer;

            //mavlink_mission_set_current_t req = new mavlink_mission_set_current_t();

            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            //req.seq = index;

            //generatePacket((byte)MAVLINK_MSG_ID.MISSION_SET_CURRENT, req);

            //DateTime start = DateTime.Now;
            //int retrys = 5;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(2000) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("setWPCurrent Retry " + retrys);
            //            generatePacket((byte)MAVLINK_MSG_ID.MISSION_SET_CURRENT, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - setWPCurrent");
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.MISSION_CURRENT)
            //        {
            //            giveComport = false;
            //            return true;
            //        }
            //    }
            //}
        }

        [Obsolete("Mavlink 09 - use doCommand", true)]
        public bool doAction(object actionid)
        {
            // mavlink 09
            throw new NotImplementedException();
        }

        /// <summary>
        /// reboot the vehicle
        /// </summary>
        /// <param name="bootloadermode">reboot into bootloader mode?</param>
        /// <param name="currentvehicle">use current sysid/compid or scan for it</param>
        /// <returns></returns>
        public bool doReboot(bool bootloadermode = false, bool currentvehicle = true)
        {
            return true;
            //int param1 = 1;
            //if (bootloadermode)
            //{
            //    param1 = 3;
            //}

            //// reboot the current selected mav
            //if (currentvehicle)
            //{
            //    doCommand(MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN, param1, 0, 0, 0, 0, 0, 0);
            //    doCommand(MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN, 1, 0, 0, 0, 0, 0, 0);
            //}
            //else
            //{
            //    // scan for hb on unknown mav
            //    MAVLinkMessage buffer = getHeartBeat();

            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        mavlink_heartbeat_t hb = buffer.ToStructure<mavlink_heartbeat_t>();

            //        mavlinkversion = hb.mavlink_version;
            //        MAV.aptype = (MAV_TYPE)hb.type;
            //        MAV.apname = (MAV_AUTOPILOT)hb.autopilot;
            //        MAV.sysid = buffer.sysid;
            //        MAV.compid = buffer.compid;
            //    }

            //    // reboot if we have seen hb
            //    if (MAV.sysid != 0 && MAV.compid != 0)
            //    {
            //        doCommand(MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN, param1, 0, 0, 0, 0, 0, 0);
            //        doCommand(MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN, 1, 0, 0, 0, 0, 0, 0);
            //    }
            //}
            //giveComport = false;
            //return true;
        }

        public bool doARM(bool armit)
        {
            return true;
            //return doCommand(MAV_CMD.COMPONENT_ARM_DISARM, armit ? 1 : 0, 21196, 0, 0, 0, 0, 0);
        }

        //public bool setThrottleUp(PWM pwm)
        //{
        //    return true;
        //    //if (BaseStream.IsOpen)
        //    //{
        //    //    mavlink_rc_channels_override_t msg_rc_channels_override = new mavlink_rc_channels_override_t();
        //    //    msg_rc_channels_override.target_component = MAV.compid;
        //    //    msg_rc_channels_override.target_system = MAV.sysid;
        //    //    msg_rc_channels_override.chan1_raw = (UInt16)pwm.Chan1;
        //    //    msg_rc_channels_override.chan2_raw = (UInt16)pwm.Chan2;
        //    //    msg_rc_channels_override.chan3_raw = (UInt16)pwm.Chan3;
        //    //    msg_rc_channels_override.chan4_raw = (UInt16)pwm.Chan4;
        //    //    generatePacket(70, msg_rc_channels_override);
        //    //    /*
        //    //    msg_rc_channels_override.sysId = MainForm.comPort.sysidcurrent ;
        //    //    msg_rc_channels_override.componentId = MainForm.comPort.compidcurrent;
        //    //    msg_rc_channels_override.target_system = MAV.sysid;
        //    //    msg_rc_channels_override.target_component = MAV.compid;
        //    //    msg_rc_channels_override.chan1_raw = pwm.Chan1;
        //    //    msg_rc_channels_override.chan2_raw = pwm.Chan2;
        //    //    msg_rc_channels_override.chan3_raw = pwm.Chan3;
        //    //    msg_rc_channels_override.chan4_raw = pwm.Chan4;
        //    //    byte[] packes = msg_rc_channels_override.encode();
        //    //     */
        //    //    //BaseStream.Write(packes, 0, packes.Length);
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
        //}

        public bool doAbortLand()
        {
            return true;
            //return doCommand(MAV_CMD.DO_GO_AROUND, 0, 0, 0, 0, 0, 0, 0);
        }

        //public bool doMotorTest(int motor, MAVLink.MOTOR_TEST_THROTTLE_TYPE thr_type, int throttle, int timeout, int motorcount = 0)
        //{
        //    //return MainForm.comPort.doCommand(JYLink.JY_CMD.DO_MOTOR_TEST, (float)motor, (float)(byte)thr_type,
        //    //    (float)throttle, (float)timeout, (float)motorcount, 0, 0);
        //    return true;
        //}

        public bool doCommand(JY_CMD actionid, float p1, float p2, float p3, float p4, float p5, float p6, float p7, bool requireack = true)
        {
            return true;
            //giveComport = true;
            //MAVLinkMessage buffer;

            //mavlink_command_long_t req = new mavlink_command_long_t();

            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;

            //req.command = (ushort)actionid;

            //req.param1 = p1;
            //req.param2 = p2;
            //req.param3 = p3;
            //req.param4 = p4;
            //req.param5 = p5;
            //req.param6 = p6;
            //req.param7 = p7;

            //log.InfoFormat("doCommand cmd {0} {1} {2} {3} {4} {5} {6} {7}", actionid.ToString(), p1, p2, p3, p4, p5, p6,
            //    p7);

            //generatePacket((byte)MAVLINK_MSG_ID.COMMAND_LONG, req);

            //if (!requireack)
            //{
            //    giveComport = false;
            //    return true;
            //}

            //DateTime GUI = DateTime.Now;

            //DateTime start = DateTime.Now;
            //int retrys = 3;

            //int timeout = 2000;

            //// imu calib take a little while
            //if (actionid == MAV_CMD.PREFLIGHT_CALIBRATION && p5 == 1)
            //{
            //    // this is for advanced accel offsets, and blocks execution
            //    giveComport = false;
            //    return true;
            //}
            //else if (actionid == MAV_CMD.PREFLIGHT_CALIBRATION)
            //{
            //    retrys = 1;
            //    timeout = 25000;
            //}
            //else if (actionid == MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN)
            //{
            //    generatePacket((byte)MAVLINK_MSG_ID.COMMAND_LONG, req);
            //    giveComport = false;
            //    return true;
            //}
            //else if (actionid == MAV_CMD.COMPONENT_ARM_DISARM)
            //{
            //    // 10 seconds as may need an imu calib
            //    timeout = 10000;
            //}
            //else if (actionid == MAV_CMD.PREFLIGHT_CALIBRATION && p6 == 1)
            //{
            //    // compassmot
            //    // send again just incase
            //    generatePacket((byte)MAVLINK_MSG_ID.COMMAND_LONG, req);
            //    giveComport = false;
            //    return true;
            //}
            //else if (actionid == MAV_CMD.GET_HOME_POSITION)
            //{
            //    giveComport = false;
            //    return true;
            //}

            //while (true)
            //{
            //    if (DateTime.Now > GUI.AddMilliseconds(100))
            //    {
            //        GUI = DateTime.Now;

            //        MainForm.instance.Invalidate();

            //        MainForm.instance.Update();
            //    }

            //    if (!(start.AddMilliseconds(timeout) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("doCommand Retry " + retrys);
            //            generatePacket((byte)MAVLINK_MSG_ID.COMMAND_LONG, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - doCommand");
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.COMMAND_ACK)
            //        {
            //            var ack = buffer.ToStructure<mavlink_command_ack_t>();

            //            log.InfoFormat("doCommand cmd resp {0} - {1}", (MAV_CMD)ack.command, ack.result);

            //            if (ack.result == (byte)MAV_RESULT.ACCEPTED)
            //            {
            //                giveComport = false;
            //                return true;
            //            }
            //            else
            //            {
            //                giveComport = false;
            //                return false;
            //            }
            //        }
            //    }
            //}
        }

        public void SendAck()
        {
            //mavlink_command_ack_t ack = new mavlink_command_ack_t();
            //ack.command = (byte)MAV_CMD.PREFLIGHT_CALIBRATION;
            //ack.result = 0;

            //// send twice
            //generatePacket((byte)MAVLINK_MSG_ID.COMMAND_ACK, ack);
            //System.Threading.Thread.Sleep(20);
            //generatePacket((byte)MAVLINK_MSG_ID.COMMAND_ACK, ack);
        }

        public void SendSerialControl(SERIAL_CONTROL_DEV port, ushort timeoutms, byte[] data, uint baudrate = 0,
            bool close = false)
        {
            jylink_serial_control_t ctl = new jylink_serial_control_t();

            ctl.baudrate = baudrate; // no change
            ctl.device = (byte)port;
            ctl.timeout = timeoutms;
            ctl.data = new byte[70];
            ctl.count = 0;
            if (close)
            {
                ctl.flags = 0;
            }
            else
            {
                //ctl.flags = (byte)SERIAL_CONTROL_FLAG.EXCLUSIVE; // | SERIAL_CONTROL_FLAG.MULTI);
            }

            if (data != null && data.Length != 0)
            {
                int packets = (data.Length / 70) + 1;
                int len = data.Length;
                while (len > 0)
                {
                    //if (packets == 1)
                    //    ctl.flags |= (byte)SERIAL_CONTROL_FLAG.RESPOND;

                    byte n = (byte)Math.Min(70, len);

                    ctl.count = n;
                    Array.Copy(data, data.Length - len, ctl.data, 0, n);

                    // dont flood the port
                    System.Threading.Thread.Sleep(10);

                    //generatePacket((byte)JYLINK_MSG_ID.SERIAL_CONTROL, ctl);

                    len -= n;
                    packets--;
                }
            }
            else
            {
                //if (!close)
                //    ctl.flags |= (byte)SERIAL_CONTROL_FLAG.RESPOND | (byte)SERIAL_CONTROL_FLAG.MULTI;

                //generatePacket((byte)MAVLINK_MSG_ID.SERIAL_CONTROL, ctl);
            }
        }

        //public void requestDatastream(JYLink.MAV_DATA_STREAM id, byte hzrate, int sysid = -1, int compid = -1)
        //{
        //    if (sysid == -1)
        //        sysid = sysidcurrent;

        //    if (compid == -1)
        //        compid = compidcurrent;

        //    double pps = 0;

        //    switch (id)
        //    {
        //        case MAVLink.MAV_DATA_STREAM.ALL:

        //            break;

        //        case MAVLink.MAV_DATA_STREAM.EXTENDED_STATUS:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.SYS_STATUS] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.SYS_STATUS];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.EXTRA1:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.ATTITUDE] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.ATTITUDE];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.EXTRA2:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.VFR_HUD] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.VFR_HUD];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.EXTRA3:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.AHRS] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.AHRS];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.POSITION:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.GLOBAL_POSITION_INT] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.GLOBAL_POSITION_INT];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.RAW_CONTROLLER:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.RC_CHANNELS_SCALED] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.RC_CHANNELS_SCALED];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.RAW_SENSORS:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.RAW_IMU] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.RAW_IMU];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;

        //        case MAVLink.MAV_DATA_STREAM.RC_CHANNELS:
        //            if (MAVlist[sysid, compid].packetspersecondbuild[(byte)MAVLINK_MSG_ID.RC_CHANNELS_RAW] <
        //                DateTime.Now.AddSeconds(-2))
        //                break;
        //            pps = MAVlist[sysid, compid].packetspersecond[(byte)MAVLINK_MSG_ID.RC_CHANNELS_RAW];
        //            if (hzratecheck(pps, hzrate))
        //            {
        //                return;
        //            }
        //            break;
        //    }

        //    //packetspersecond[temp[5]];

        //    if (pps == 0 && hzrate == 0)
        //    {
        //        return;
        //    }

        //    log.InfoFormat("Request stream {0} at {1} hz for {2}:{3}",
        //        Enum.Parse(typeof(MAV_DATA_STREAM), id.ToString()), hzrate, sysid, compid);
        //    getDatastream(id, hzrate);
        //}

        // returns true for ok
        private bool hzratecheck(double pps, int hzrate)
        {
            if (double.IsInfinity(pps))
            {
                return false;
            }
            else if (hzrate == 0 && pps == 0)
            {
                return true;
            }
            else if (hzrate == 1 && pps >= 0.5 && pps <= 2)
            {
                return true;
            }
            else if (hzrate == 3 && pps >= 2 && hzrate < 5)
            {
                return true;
            }
            else if (hzrate == 10 && pps > 5 && hzrate < 15)
            {
                return true;
            }
            else if (hzrate > 15 && pps > 15)
            {
                return true;
            }

            return false;
        }

        //private void getDatastream(MAVLink.MAV_DATA_STREAM id, byte hzrate)
        //{
        //    mavlink_request_data_stream_t req = new mavlink_request_data_stream_t();
        //    req.target_system = MAV.sysid;
        //    req.target_component = MAV.compid;

        //    req.req_message_rate = hzrate;
        //    req.start_stop = 1; // start
        //    req.req_stream_id = (byte)id; // id

        //    // send each one twice.
        //    generatePacket((byte)MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
        //    generatePacket((byte)MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
        //}

        /// <summary>
        /// Returns WP count
        /// </summary>
        /// <returns></returns>
        public int getWPCount(List<Locationwp> cmds)
        {
            giveComport = true;
            JYLinkMessage buffer;
            jylink_mission_search req = new jylink_mission_search();
            req.seq = 0;

            //req. = MAV.sysid;
            //req.target_component = MAV.compid;

            // request list
            //9.26 5:35
            generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);

            DateTime start = DateTime.Now;
            int retrys = 3;

            while (true)
            {
                if (!(start.AddMilliseconds(500) > DateTime.Now))
                {
                    if (retrys > 0)
                    {
                        log.Info("getWPCount Retry " + retrys + " - giv com " + giveComport);
                        generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);
                        start = DateTime.Now;
                        retrys--;
                        continue;
                    }
                    giveComport = false;
                    return -1;

                }
                //while (true)
                //{
                buffer = readPacket();
                if (buffer != null)
                {
                    if (buffer != null && buffer.Length > 5)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.MISSION_ITEM_DOWN)
                        {
                            var count = buffer.ToStructure<jylink_mission_item>();
                            //var wp = buffer.ToStructure<jylink_mission_item>();

                            // received a packet, but not what we requested
                            Locationwp loc = new Locationwp();
                            loc.p1 = (count.param1);
                            loc.p2 = (count.param2);
                            loc.p3 = (count.param3);
                            loc.p4 = (count.param4);
                            loc.id = (count.cmd);

                            loc.alt = ((count.altitude));
                            loc.lat = ((count.latitude));
                            loc.lng = ((count.longitude));
                            //cmds.Add(loc);
                            //log.Info("wpcount: " + count.count);
                            giveComport = false;
                            //return count.count; // should be ushort, but apm has limited wp count < byte
                            return count.count;
                        }
                    }

                }

                // }
            }
        }

        public jylink_home_location_down getHomePosition()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_home_location_down_search homePoint = new JYLink.jylink_home_location_down_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.HOME_LOCATION_SEARCH, homePoint);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.HOME_LOCATION_SEARCH, homePoint);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.HOME_LOCATION_DOWN)
                            {
                                var homeLocationDown = buffer.ToStructure<jylink_home_location_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return homeLocationDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("HOME点查询失败。");
                }
            }
            giveComport = false;
            jylink_home_location_down guidectrlnull = new jylink_home_location_down();
            return guidectrlnull;
        }

        /// <summary>
        /// Gets specfied WP
        /// </summary>
        /// <param name="index"></param>
        /// <returns>WP</returns>

        public Locationwp getWP(byte num, byte index)
        {

            //while (giveComport)
            //    System.Threading.Thread.Sleep(100);

            //bool use_int = (JY.cs.capabilities & JY_PROTOCOL_CAPABILITY.MISSION_INT) > 0;
            bool use_int = true;
            object req = null;
            giveComport = true;
            if (use_int)
            {
                jylink_mission_search reqi = new jylink_mission_search();

                //reqi.target_system = JY.sysid;
                //reqi.target_component = JY.targetid;

                reqi.num = num;
                reqi.seq = index;

                // request
                generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, reqi);

                req = reqi;
            }


            Locationwp loc = new Locationwp();

            DateTime start = DateTime.Now;
            int retrys = 1;

            while (true)
            {
                if (!(start.AddMilliseconds(1500) > DateTime.Now)) // apm times out after 5000ms
                {
                    if (retrys > 0 && req != null)
                    {
                        log.Info("getWP Retry " + retrys);
                        if (use_int)
                            generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);

                        start = DateTime.Now;
                        retrys--;
                        continue;
                    }
                    giveComport = false;
                    loc.Tag = "error";
                    return loc;
                    //throw new TimeoutException("Timeout on read - getWP");
                }
                JYLinkMessage buffer = readPacket();
                if (buffer != null)
                {
                    if (buffer.Length > 5)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.MISSION_ITEM_DOWN)
                        {

                            var wp = buffer.ToStructure<jylink_mission_item>();

                            if (index != wp.seq)
                            {
                                generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);
                                continue;
                            }

                            loc.Tag = "normal";
                            loc.p1 = (wp.param1);
                            loc.p2 = (wp.param2);
                            loc.p3 = (wp.param3);
                            loc.p4 = (wp.param4);
                            loc.id = (wp.cmd);
                            loc.num = (wp.num);
                            loc.alt = ((wp.altitude));
                            loc.lat = ((wp.latitude));
                            loc.lng = ((wp.longitude));

                            log.InfoFormat("getWP {0} {1} {2} {3} {4} opt {5}", loc.id, loc.p1, loc.alt, loc.lat, loc.lng,
                                loc.options);
                            giveComport = false;
                            return loc;
                        }
                    }
                }


            }



            return loc;
            //return null;
        }
    
        public void setHomePosition(JYLink.Warship_home_location_up home)
        {
            generatePacket_ship((byte)JYLink.JYLINK_MSG_ID.Warship_Home_Up, home);
        }
        public bool upHomeShipChange(Warship_change change)
        {
            JYLinkMessage buffer;
            giveComport = true;
            try
            {
                generatePacket_ship((byte)(byte)JYLink.JYLINK_MSG_ID.Warship_Change, change);
                DateTime start = DateTime.Now;
                int retrys = 3;

                while (true)
                {
                    if (!(start.AddMilliseconds(500) > DateTime.Now))
                    {
                        if (retrys > 0)
                        {
                            generatePacket_ship((byte)(byte)JYLink.JYLINK_MSG_ID.Warship_Change, change);
                            start = DateTime.Now;
                            retrys--;
                            continue;
                        }
                        giveComport = false;
                        return false;
                    }

                    buffer = readPacket();
                    if (buffer != null)
                    {
                        if (buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.Warship_Change)
                            {
                                var varchange = buffer.ToStructure<Warship_change>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }



                }

            }
            catch
            {
                giveComport = false;
                MainForm.instance.isSendSuccess = false;
                //System.Windows.Forms.MessageBox.Show("改变航向上传失败。");
                return false;
            }

        }
        //public object DebugPacket(MAVLinkMessage datin)
        //{
        //    string text = "";
        //    return DebugPacket(datin, ref text, true);
        //}

        //public object DebugPacket(MAVLinkMessage datin, bool PrintToConsole)
        //{
        //    string text = "";
        //    return DebugPacket(datin, ref text, PrintToConsole);
        //}

        //public object DebugPacket(MAVLinkMessage datin, ref string text)
        //{
        //    return DebugPacket(datin, ref text, true);
        //}

        ///// <summary>
        ///// Print entire decoded packet to console
        ///// </summary>
        ///// <param name="datin">packet byte array</param>
        ///// <returns>struct of data</returns>
        //public object DebugPacket(MAVLinkMessage datin, ref string text, bool PrintToConsole, string delimeter = " ")
        //{
        //    string textoutput = "";
        //    try
        //    {
        //        if (datin.Length > 5)
        //        {
        //            textoutput =
        //                string.Format(
        //                    "{0,2:X}{8}{1,2:X}{8}{2,2:X}{8}{3,2:X}{8}{4,2:X}{8}{5,2:X}{8}{6,2:X}{8}{7,6:X}{8}",
        //                    datin.header,
        //                    datin.payloadlength, datin.incompat_flags, datin.compat_flags, datin.seq, datin.sysid,
        //                    datin.compid, datin.msgid, delimeter);

        //            object data = datin.data;

        //            Type test = data.GetType();

        //            if (PrintToConsole)
        //            {
        //                textoutput = textoutput + test.Name + delimeter;

        //                foreach (var field in test.GetFields())
        //                {
        //                    // field.Name has the field's name.

        //                    object fieldValue = field.GetValue(data); // Get value

        //                    if (field.FieldType.IsArray)
        //                    {
        //                        textoutput = textoutput + field.Name + delimeter;
        //                        if (fieldValue.GetType() == typeof(byte[]))
        //                        {
        //                            try
        //                            {
        //                                byte[] crap = (byte[])fieldValue;

        //                                foreach (byte fiel in crap)
        //                                {
        //                                    if (fiel == 0)
        //                                    {
        //                                        break;
        //                                    }
        //                                    else
        //                                    {
        //                                        textoutput = textoutput + (char)fiel;
        //                                    }
        //                                }
        //                            }
        //                            catch
        //                            {
        //                            }
        //                        }
        //                        if (fieldValue.GetType() == typeof(short[]))
        //                        {
        //                            try
        //                            {
        //                                short[] crap = (short[])fieldValue;

        //                                foreach (short fiel in crap)
        //                                {
        //                                    if (fiel == 0)
        //                                    {
        //                                        break;
        //                                    }
        //                                    else
        //                                    {
        //                                        textoutput = textoutput + Convert.ToString(fiel, 16) + "|";
        //                                    }
        //                                }
        //                            }
        //                            catch
        //                            {
        //                            }
        //                        }
        //                        textoutput = textoutput + delimeter;
        //                    }
        //                    else
        //                    {
        //                        textoutput = textoutput + field.Name + delimeter + fieldValue.ToString() + delimeter;
        //                    }
        //                }
        //                var sig = "";
        //                if (datin.sig != null)
        //                    sig = Convert.ToBase64String(datin.sig);

        //                textoutput = textoutput + delimeter + "sig " + sig + delimeter + "Len" + delimeter + datin.Length + "\r\n";
        //                if (PrintToConsole)
        //                    Console.Write(textoutput);

        //                if (text != null)
        //                    text = textoutput;
        //            }

        //            return data;
        //        }
        //    }
        //    catch
        //    {
        //        textoutput = textoutput + "\r\n";
        //    }

        //    return null;
        //}

        /// <summary>
        /// Set start and finish for partial wp upload.
        /// </summary>
        /// <param name="startwp"></param>
        /// <param name="endwp"></param>
        //public void setWPPartialUpdate(ushort startwp, ushort endwp)
        //{
        //    mavlink_mission_write_partial_list_t req = new mavlink_mission_write_partial_list_t();

        //    req.target_system = MAV.sysid;
        //    req.target_component = MAV.compid;

        //    req.start_index = (short)startwp;
        //    req.end_index = (short)endwp;

        //    generatePacket((byte)MAVLINK_MSG_ID.MISSION_WRITE_PARTIAL_LIST, req);
        //}

        ///// <summary>
        ///// Sets wp total count
        ///// </summary>
        ///// <param name="wp_total"></param>
        //public void setWPTotal(ushort wp_total)
        //{
        //    giveComport = true;
        //    mavlink_mission_count_t req = new mavlink_mission_count_t();

        //    req.target_system = MAV.sysid;
        //    req.target_component = MAV.compid; // MSG_NAMES.MISSION_COUNT

        //    req.count = wp_total;

        //    generatePacket((byte)MAVLINK_MSG_ID.MISSION_COUNT, req);

        //    DateTime start = DateTime.Now;
        //    int retrys = 3;

        //    while (true)
        //    {
        //        if (!(start.AddMilliseconds(700) > DateTime.Now))
        //        {
        //            if (retrys > 0)
        //            {
        //                log.Info("setWPTotal Retry " + retrys);
        //                generatePacket((byte)MAVLINK_MSG_ID.MISSION_COUNT, req);
        //                start = DateTime.Now;
        //                retrys--;
        //                continue;
        //            }
        //            giveComport = false;
        //            throw new Exception("Timeout on read - setWPTotal");
        //        }
        //        MAVLinkMessage buffer = readPacket();
        //        if (buffer.Length > 9)
        //        {
        //            if (buffer.msgid == (byte)MAVLINK_MSG_ID.MISSION_REQUEST)
        //            {
        //                var request = buffer.ToStructure<mavlink_mission_request_t>();

        //                if (request.seq == 0)
        //                {
        //                    if (MAV.param["WP_TOTAL"] != null)
        //                        MAV.param["WP_TOTAL"].Value = wp_total - 1;
        //                    if (MAV.param["CMD_TOTAL"] != null)
        //                        MAV.param["CMD_TOTAL"].Value = wp_total - 1;
        //                    if (MAV.param["MIS_TOTAL"] != null)
        //                        MAV.param["MIS_TOTAL"].Value = wp_total - 1;

        //                    MAV.wps.Clear();

        //                    giveComport = false;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                //Console.WriteLine(DateTime.Now + " PC getwp " + buffer.msgid);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// used to injecy data into the gps ie rtcm/sbp/ubx
        ///// </summary>
        ///// <param name="data"></param>
        //public void InjectGpsData(byte[] data, byte length)
        //{
        //    mavlink_gps_inject_data_t gps = new mavlink_gps_inject_data_t();

        //    var len = (length % 128) == 0 ? length / 128 : (length / 128) + 1;

        //    for (int a = 0; a < len; a++)
        //    {
        //        gps.data = new byte[110];

        //        int copy = Math.Min(length - a * 110, 110);

        //        Array.Copy(data, a * 110, gps.data, 0, copy);
        //        gps.len = (byte)copy;
        //        gps.target_component = MAV.compid;
        //        gps.target_system = MAV.sysid;

        //        generatePacket((byte)MAVLINK_MSG_ID.GPS_INJECT_DATA, gps);
        //    }
        //}

        /// <summary>
        /// Save wp to eeprom
        /// </summary>
        /// <param name="loc">location struct</param>
        /// <param name="index">wp no</param>
        /// <param name="frame">global or relative</param>
        /// <param name="current">0 = no , 2 = guided mode</param>
        public JY_MISSION_RESULT setWP(int count, Locationwp loc, int index,
              byte autocontinue = 1, bool use_int = false)
        {
            //if (use_int)
            //{
            jylink_mission_item req = new jylink_mission_item();

            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            req.count = (byte)count;
            req.cmd = loc.id;
            req.num = loc.num;
            //req.current = current;
            //req.autocontinue = autocontinue;

            //req.frame = (byte)frame;
            req.latitude = (int)(loc.lng);
            req.longitude = (int)(loc.lat);
            req.altitude = (float)(loc.alt);

            if (loc.p1 < 85)
            {
                req.param1 = 85;
            }
            else if (loc.p1 > 300)
            {
                req.param1 = 300;
            }
            else
            {
                req.param1 = loc.p1;
            }
            req.param2 = loc.p2;
            req.param3 = loc.p3;
            req.param4 = loc.p4;

            req.seq = (byte)(index - 1);

            return setWP(req);
            //}
            //else
            //{
            //    jylink_mission_item req = new jylink_mission_item();

            //    //req.target_system = MAV.sysid;
            //    //req.target_component = MAV.compid;

            //    req.cmd = loc.id;

            //    req.current = current;
            //    req.autocontinue = autocontinue;

            //    req.frame = (byte)frame;
            //    req.y = (float)(loc.lng);
            //    req.x = (float)(loc.lat);
            //    req.z = (float)(loc.alt);

            //    req.param1 = loc.p1;
            //    req.param2 = loc.p2;
            //    req.param3 = loc.p3;
            //    req.param4 = loc.p4;

            //    req.seq = index;

            //    return setWP(req);
            //}
        }

        public JY_MISSION_RESULT setWP(jylink_mission_item req)
        {
            giveComport = true;

            ushort index = req.seq;

            //log.InfoFormat("setWP {6} frame {0} cmd {1} p1 {2} x {3} y {4} z {5}", req.frame, req.command, req.param1,
            //    req.x, req.y, req.z, index);

            // request
            generatePacket((byte)JYLINK_MSG_ID.MISSION_ITEM_UP, req);

            DateTime start = DateTime.Now;
            int retrys = 4;

            while (true)
            {
                if (!(start.AddMilliseconds(800) > DateTime.Now))
                {
                    if (retrys > 0)
                    {
                        log.Info("setWP Retry " + retrys);
                        generatePacket((byte)JYLINK_MSG_ID.MISSION_ITEM_UP, req);

                        start = DateTime.Now;
                        retrys--;
                        continue;
                    }
                    giveComport = false;
                    throw new TimeoutException("Timeout on read - setWP");
                }
                JYLinkMessage buffer = readPacket();
                if (buffer != null)
                {
                    if (buffer.Length > 5)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.MISSION_ITEM_UP)
                        {
                            var ans = buffer.ToStructure<jylink_mission_item>();
                            //log.Info("set wp " + index + " ACK 47 : " + buffer.msgid + " ans " +
                            //         Enum.Parse(typeof(MAV_MISSION_RESULT), ans.type.ToString()));
                            //if (ans.seq == index)
                            //{
                            giveComport = false;
                            return JY_MISSION_RESULT.JY_MISSION_ACCEPTED;
                            //}
                            //else
                            //{
                            //    JY.wps[req.seq] = req;
                            //}

                        }

                    }
                }

            }

            return JY_MISSION_RESULT.JY_MISSION_INVALID;
        }

        //public MAV_MISSION_RESULT setWP(mavlink_mission_item_int_t req)
        //{
        //    giveComport = true;

        //    ushort index = req.seq;

        //    log.InfoFormat("setWPint {6} frame {0} cmd {1} p1 {2} x {3} y {4} z {5}", req.frame, req.command, req.param1,
        //        req.x / 1.0e7, req.y / 1.0e7, req.z, index);

        //    // request
        //    generatePacket((byte)MAVLINK_MSG_ID.MISSION_ITEM_INT, req);

        //    DateTime start = DateTime.Now;
        //    int retrys = 10;

        //    while (true)
        //    {
        //        if (!(start.AddMilliseconds(400) > DateTime.Now))
        //        {
        //            if (retrys > 0)
        //            {
        //                log.Info("setWP Retry " + retrys);
        //                generatePacket((byte)MAVLINK_MSG_ID.MISSION_ITEM_INT, req);

        //                start = DateTime.Now;
        //                retrys--;
        //                continue;
        //            }
        //            giveComport = false;
        //            throw new TimeoutException("Timeout on read - setWP");
        //        }
        //        MAVLinkMessage buffer = readPacket();
        //        if ( buffer!=null&&buffer.Length > 5)
        //        {
        //            if (buffer.msgid == (byte)MAVLINK_MSG_ID.MISSION_ACK)
        //            {
        //                var ans = buffer.ToStructure<mavlink_mission_ack_t>();
        //                log.Info("set wp " + index + " ACK 47 : " + buffer.msgid + " ans " +
        //                         Enum.Parse(typeof(MAV_MISSION_RESULT), ans.type.ToString()));
        //                giveComport = false;

        //                if (req.current == 2)
        //                {
        //                    MAV.GuidedMode = (Locationwp)req;
        //                }
        //                else if (req.current == 3)
        //                {
        //                }
        //                else
        //                {
        //                    MAV.wps[req.seq] = (Locationwp)req;
        //                }

        //                return (MAV_MISSION_RESULT)ans.type;
        //            }
        //            else if (buffer.msgid == (byte)MAVLINK_MSG_ID.MISSION_REQUEST)
        //            {
        //                var ans = buffer.ToStructure<mavlink_mission_request_t>();
        //                if (ans.seq == (index + 1))
        //                {
        //                    log.Info("set wp doing " + index + " req " + ans.seq + " REQ 40 : " + buffer.msgid);
        //                    giveComport = false;

        //                    if (req.current == 2)
        //                    {
        //                        MAV.GuidedMode = (Locationwp)req;
        //                    }
        //                    else if (req.current == 3)
        //                    {
        //                    }
        //                    else
        //                    {
        //                        MAV.wps[req.seq] = (Locationwp)req;
        //                    }

        //                    return MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED;
        //                }
        //                else
        //                {
        //                    log.InfoFormat(
        //                        "set wp fail doing " + index + " req " + ans.seq + " ACK 47 or REQ 40 : " + buffer.msgid +
        //                        " seq {0} ts {1} tc {2}", req.seq, req.target_system, req.target_component);
        //                    // resend point now
        //                    start = DateTime.MinValue;
        //                }
        //            }
        //            else
        //            {
        //                //Console.WriteLine(DateTime.Now + " PC setwp " + buffer.msgid);
        //            }
        //        }
        //    }

        //    // return MAV_MISSION_RESULT.MAV_MISSION_INVALID;
        //}

        public int getRequestedWPNo()
        {
            //giveComport = true;
            //DateTime start = DateTime.Now;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(1500) > DateTime.Now))
            //    {
            //        giveComport = false;
            //        throw new TimeoutException("Timeout on read - getRequestedWPNo");
            //    }
            //    MAVLinkMessage buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.MISSION_REQUEST)
            //        {
            //            var ans = buffer.ToStructure<mavlink_mission_request_t>();

            //            log.InfoFormat("getRequestedWPNo seq {0} ts {1} tc {2}", ans.seq, ans.target_system, ans.target_component);

            //            giveComport = false;

            //            return ans.seq;
            //        }
            //    }
            //}
            return 0;
        }

        public void setNextWPTargetAlt(ushort wpno, float alt)
        {
            // get the existing wp
            //Locationwp current = getWP(wpno);

            //mavlink_mission_write_partial_list_t req = new mavlink_mission_write_partial_list_t();
            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;

            //req.start_index = (short)wpno;
            //req.end_index = (short)wpno;

            //// change the alt
            //current.alt = alt;

            //// send a request to update single point
            //generatePacket((byte)MAVLINK_MSG_ID.MISSION_WRITE_PARTIAL_LIST, req);
            //Thread.Sleep(10);
            //generatePacket((byte)MAVLINK_MSG_ID.MISSION_WRITE_PARTIAL_LIST, req);

            //MAV_FRAME frame = (current.options & 0x1) == 0 ? MAV_FRAME.GLOBAL : MAV_FRAME.GLOBAL_RELATIVE_ALT;

            ////send the point with new alt
            //setWP(current, wpno, MAV_FRAME.GLOBAL_RELATIVE_ALT, 0);

            //// set the point as current to reload the modified command
            //setWPCurrent(wpno);
        }

        public void setGuidedModeWP(Locationwp gotohere, bool setguidedmode = true)
        {
            //if (gotohere.alt == 0 || gotohere.lat == 0 || gotohere.lng == 0)
            //    return;

            //giveComport = true;

            //try
            //{
            //    gotohere.id = (ushort)MAV_CMD.WAYPOINT;

            //    if (setguidedmode)
            //    {
            //        // fix for followme change
            //        if (MAV.cs.mode.ToUpper() != "GUIDED")
            //            setMode("GUIDED");
            //    }

            //    MAV_MISSION_RESULT ans = setWP(gotohere, 0, MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT, (byte)2);

            //    if (ans != MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
            //        throw new Exception("Guided Mode Failed");
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex);
            //}

            //giveComport = false;
        }

        public void setNewWPAlt(Locationwp gotohere)
        {
            //giveComport = true;

            //try
            //{
            //    gotohere.id = (ushort)MAV_CMD.WAYPOINT;

            //    MAV_MISSION_RESULT ans = setWP(gotohere, 0, MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT, (byte)3);

            //    if (ans != MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
            //        throw new Exception("Alt Change Failed");
            //}
            //catch (Exception ex)
            //{
            //    giveComport = false;
            //    log.Error(ex);
            //    throw;
            //}

            //giveComport = false;
        }

        public void setDigicamConfigure()
        {
            // not implmented
        }

        public void setDigicamControl(bool shot)
        {
            //mavlink_digicam_control_t req = new mavlink_digicam_control_t();

            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            //req.shot = (shot == true) ? (byte)1 : (byte)0;

            //generatePacket((byte)MAVLINK_MSG_ID.DIGICAM_CONTROL, req);

            //MainForm.comPort.doCommand(MAV_CMD.DO_DIGICAM_CONTROL, 0, 0, 0, 0, 1, 0, 0);

            //MAVLINK_MSG_ID.CAMERA_FEEDBACK;

            //mavlink_camera_feedback_t
        }

        //public void setMountConfigure(MAV_MOUNT_MODE mountmode, bool stabroll, bool stabpitch, bool stabyaw)
        //{
        //    mavlink_mount_configure_t req = new mavlink_mount_configure_t();

        //    req.target_system = MAV.sysid;
        //    req.target_component = MAV.compid;
        //    req.mount_mode = (byte)mountmode;
        //    req.stab_pitch = (stabpitch == true) ? (byte)1 : (byte)0;
        //    req.stab_roll = (stabroll == true) ? (byte)1 : (byte)0;
        //    req.stab_yaw = (stabyaw == true) ? (byte)1 : (byte)0;

        //    generatePacket((byte)MAVLINK_MSG_ID.MOUNT_CONFIGURE, req);
        //    System.Threading.Thread.Sleep(20);
        //    generatePacket((byte)MAVLINK_MSG_ID.MOUNT_CONFIGURE, req);
        //}

        public void setMountControl(double pa, double pb, double pc, bool islatlng)
        {
            //mavlink_mount_control_t req = new mavlink_mount_control_t();

            //req.target_system = MAV.sysid;
            //req.target_component = MAV.compid;
            //if (!islatlng)
            //{
            //    req.input_a = (int)pa;
            //    req.input_b = (int)pb;
            //    req.input_c = (int)pc;
            //}
            //else
            //{
            //    req.input_a = (int)(pa * 10000000.0);
            //    req.input_b = (int)(pb * 10000000.0);
            //    req.input_c = (int)(pc * 100.0);
            //}

            //generatePacket((byte)MAVLINK_MSG_ID.MOUNT_CONTROL, req);
            //System.Threading.Thread.Sleep(20);
            //generatePacket((byte)MAVLINK_MSG_ID.MOUNT_CONTROL, req);
        }
        //卫星星况查询
        public jylink_satlate_status searchSatStatus(string value)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_satellite_search satstatus = new JYLink.jylink_satellite_search();
                    int ssysid = JY.sysid;
                    int stargetid = JY.targetid;
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.SATELLITE_STATUS, satstatus);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.SATELLITE_STATUS, satstatus);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return null;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.SATLATE_STATUS)
                            {
                                var satlate = buffer.ToStructure<jylink_satlate_status>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return satlate;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("未接收到星况信息。");
                }
            }
            giveComport = false;
            return null;
        }
        //姿态环参数查询
        public jylink_attitudeloop_param_down searchAttitudeLoop()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_attitudeloop_param_search attitudeloop = new JYLink.jylink_attitudeloop_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ATTITUDELOOP_PARAM_SEARCH, attitudeloop);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ATTITUDELOOP_PARAM_SEARCH, attitudeloop);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ATTITUDELOOP_PARAM_DOWN)
                            {
                                var attitudeParamDown = buffer.ToStructure<jylink_attitudeloop_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return attitudeParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("姿态环参数查询失败。");
                }
            }
            giveComport = false;
            jylink_attitudeloop_param_down att = new jylink_attitudeloop_param_down();
            return att;
        }
        //姿态环参数设置
        public bool setupAttitudeLoop(jylink_attitudeloop_param_setup attitudeParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ATTITUDELOOP_PARAM_SETUP, attitudeParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ATTITUDELOOP_PARAM_SETUP, attitudeParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();

                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ATTITUDELOOP_PARAM_SETUP)
                            {
                                var attitudeParamDown = buffer.ToStructure<jylink_attitudeloop_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }

                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("姿态环参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //过载环参数查询
        public jylink_overloadloop_param_down searchOverLoadLoop()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_overloadloop_param_search overloadloop = new JYLink.jylink_overloadloop_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.OVERLOADLOOP_PARAM_SEARCH, overloadloop);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.OVERLOADLOOP_PARAM_SEARCH, overloadloop);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.OVERLOADLOOP_PARAM_DOWN)
                            {
                                var overloadParamDown = buffer.ToStructure<jylink_overloadloop_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return overloadParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("过载环参数查询失败。");
                }
            }
            giveComport = false;
            jylink_overloadloop_param_down overload = new jylink_overloadloop_param_down();
            return overload;
        }
        //过载环参数设置
        public bool setupOverLoadLoop(jylink_overloadloop_param_setup overloadParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.OVERLOADLOOP_PARAM_SETUP, overloadParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.OVERLOADLOOP_PARAM_SETUP, overloadParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.OVERLOADLOOP_PARAM_SETUP)
                            {
                                var attitudeParamDown = buffer.ToStructure<jylink_overloadloop_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("过载环参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //制导参数查询
        public jylink_guidectrl_param_down searchGuideCtrl()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_guidectrl_param_search guidectrl = new JYLink.jylink_guidectrl_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDECTRL_PARAM_SEARCH, guidectrl);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDECTRL_PARAM_SEARCH, guidectrl);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GUIDECTRL_PARAM_DOWN)
                            {
                                var guidectrlParamDown = buffer.ToStructure<jylink_guidectrl_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return guidectrlParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("制导参数查询失败。");
                }
            }
            giveComport = false;
            jylink_guidectrl_param_down guidectrlnull = new jylink_guidectrl_param_down();
            return guidectrlnull;
        }
        //制导参数设置
        public bool setupGuideCtrl(jylink_guidectrl_param_setup guidectrlParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDECTRL_PARAM_SETUP, guidectrlParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDECTRL_PARAM_SETUP, guidectrlParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GUIDECTRL_PARAM_SETUP)
                            {
                                var guidectrlDown = buffer.ToStructure<jylink_guidectrl_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("制导参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //起飞参数查询
        public jylink_takeoff_param_down searchTakeOff()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_takeoff_param_search takeoff = new JYLink.jylink_takeoff_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TAKEOFF_PARAM_SEARCH, takeoff);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TAKEOFF_PARAM_SEARCH, takeoff);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.TAKEOFF_PARAM_DOWN)
                            {
                                var takeoffParamDown = buffer.ToStructure<jylink_takeoff_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return takeoffParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("起飞参数查询失败。");
                }
            }
            giveComport = false;
            jylink_takeoff_param_down takeoffnull = new jylink_takeoff_param_down();
            return takeoffnull;
        }
        //起飞参数设置
        public bool setupTakeOff(jylink_takeoff_param_setup takeoffParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TAKEOFF_PARAM_SETUP, takeoffParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TAKEOFF_PARAM_SETUP, takeoffParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.TAKEOFF_PARAM_SETUP)
                            {
                                var takeoffParamDown = buffer.ToStructure<jylink_takeoff_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("起飞参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //引导参数查询
        public jylink_guide_param_down searchGuide()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_guide_param_search guide = new JYLink.jylink_guide_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDE_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDE_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GUIDE_PARAM_DOWN)
                            {
                                var guideParamDown = buffer.ToStructure<jylink_guide_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return guideParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("引导参数查询失败。");
                }
            }
            giveComport = false;
            jylink_guide_param_down guidenull = new jylink_guide_param_down();
            return guidenull;
        }
        //引导参数设置
        public bool setupGuide(jylink_guide_param_setup guideParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDE_PARAM_SETUP, guideParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GUIDE_PARAM_SETUP, guideParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GUIDE_PARAM_SETUP)
                            {
                                var guideParamDown = buffer.ToStructure<jylink_guide_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("引导参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //盘旋参数查询
        public jylink_loiter_param_down searchLoiter()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_loiter_param_search loiter = new JYLink.jylink_loiter_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LOITER_PARAM_SEARCH, loiter);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LOITER_PARAM_SEARCH, loiter);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.LOITER_PARAM_DOWN)
                            {
                                var loiterParamDown = buffer.ToStructure<jylink_loiter_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return loiterParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("盘旋参数查询失败。");
                }
            }
            giveComport = false;
            jylink_loiter_param_down loiternull = new jylink_loiter_param_down();
            return loiternull;
        }
        //盘旋参数设置
        public bool setupLoiter(jylink_loiter_param_setup loiterParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LOITER_PARAM_SETUP, loiterParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LOITER_PARAM_SETUP, loiterParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.LOITER_PARAM_SETUP)
                            {
                                var loiterParamDown = buffer.ToStructure<jylink_loiter_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("盘旋参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //极限参数查询
        public jylink_limit_param_down searchLimit()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_limit_param_search limit = new JYLink.jylink_limit_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LIMIT_PARAM_SEARCH, limit);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LIMIT_PARAM_SEARCH, limit);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.LIMIT_PARAM_DOWN)
                            {
                                var limitParamDown = buffer.ToStructure<jylink_limit_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return limitParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("极限参数查询失败。");
                }
            }
            giveComport = false;
            jylink_limit_param_down limitnull = new jylink_limit_param_down();
            return limitnull;
        }
        //极限参数设置
        public bool setupLimit(jylink_limit_param_setup limitParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LIMIT_PARAM_SETUP, limitParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LIMIT_PARAM_SETUP, limitParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.LIMIT_PARAM_SETUP)
                            {
                                var limitParamDown = buffer.ToStructure<jylink_limit_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("极限参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        //舵机配平参数查询
        public jylink_steertrim_param_down searchSteerTrim()
        {
            int inum = 0;
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_steertrim_param_search steertrim = new JYLink.jylink_steertrim_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEERTRIM_PARAM_SEARCH, steertrim);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(2000) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEERTRIM_PARAM_SEARCH, steertrim);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            inum++;
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.STEERTRIM_PARAM_DOWN)
                            {
                                var steertrimParamDown = buffer.ToStructure<jylink_steertrim_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return steertrimParamDown;
                            }
                        }
                    }
                }
                catch
                {

                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("舵面配平参数查询失败。");
                }
            }
            giveComport = false;
            jylink_steertrim_param_down steertrimnull = new jylink_steertrim_param_down();
            return steertrimnull;
        }
        //舵面配平参数设置
        public bool setupSteerTrim(jylink_steertrim_param_setup steertrimParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;

            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEERTRIM_PARAM_SETUP, steertrimParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEERTRIM_PARAM_SETUP, steertrimParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.STEERTRIM_PARAM_SETUP)
                            {
                                var steertrimParamDown = buffer.ToStructure<jylink_steertrim_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("舵面配平参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_steer_cac_param_down searchSteerCac()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_steer_cac_param_search steer = new JYLink.jylink_steer_cac_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_SET_SEARCH, steer);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_SET_SEARCH, steer);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.STEER_SET_DOWN)
                            {
                                var steerParamDown = buffer.ToStructure<jylink_steer_cac_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return steerParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("盘旋参数查询失败。");
                }
            }
            giveComport = false;
            jylink_steer_cac_param_down steernull = new jylink_steer_cac_param_down();
            return steernull;
        }

        public bool setupSteerCac(jylink_steer_cac_setup steerCac)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_SET_DOWN, steerCac);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_SET_DOWN, steerCac);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.STEER_SET_DOWN)
                            {
                                var loiterParamDown = buffer.ToStructure<jylink_loiter_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("舵机设置失败。");
                }
            }
            giveComport = false;
            return false;
        }


        //空速和气压传感器校准
        public bool calASBA()
        {
            giveComport = true;
            JYLinkMessage buffer;
            //if (MainForm.instance._linkqualitygcs <= 0)
            //{
            //    MainForm.instance.isSendSuccess = false;
            //}
            //else 
            //if (MissionPlanner.CurrentState.position_state.Equals(0))
            //{
            //    MessageBox.Show("未定位，校准发送失败");
            //    MainForm.instance.isSendSuccess = false;
            //}
            //else
            //{
            try
            {
                JYLink.jylink_airspeed_balt_cal asba = new JYLink.jylink_airspeed_balt_cal();

                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.AIRSPEED_BALT_CAL, asba);
                DateTime start = DateTime.Now;
                int retrys = 3;

                while (true)
                {
                    if (!(start.AddMilliseconds(500) > DateTime.Now))
                    {
                        if (retrys > 0)
                        {
                            log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                            generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.AIRSPEED_BALT_CAL, asba);
                            start = DateTime.Now;
                            retrys--;
                            continue;
                        }
                        giveComport = false;
                        return false;
                    }
                    buffer = readPacket();
                    if (buffer != null && buffer.Length > 5)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.AIRSPEED_BALT_CAL)
                        {
                            var asbaDown = buffer.ToStructure<jylink_airspeed_balt_cal>();
                            MainForm.instance.isSendSuccess = true;
                            giveComport = false;
                            return true;
                        }
                    }
                }
            }
            catch
            {
                MainForm.instance.isSendSuccess = false;
                System.Windows.Forms.MessageBox.Show("空速和气压高度校准失败。");
            }
            //}
            giveComport = false;
            return false;
        }
        //系统自检
        public bool systemSelfCheck()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_system_self_check systemCheck = new JYLink.jylink_system_self_check();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.SYSTEM_SELF_CHECK, systemCheck);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.SYSTEM_SELF_CHECK, systemCheck);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.SYSTEM_SELF_CHECK)
                            {
                                var asbaDown = buffer.ToStructure<jylink_system_self_check>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("系统自检失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //舵机测试
        public bool steerTest()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_steer_test steerTest = new JYLink.jylink_steer_test();
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_TEST, steerTest);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.STEER_TEST, steerTest);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.STEER_TEST)
                            {
                                var asbaDown = buffer.ToStructure<jylink_steer_test>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("舵机测试失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //ECU
        public bool setupECU(jylink_ecu_setup ecuParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ECU_SETUP, ecuParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ECU_SETUP, ecuParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ECU_SETUP)
                            {
                                var ecuParamDown = buffer.ToStructure<jylink_ecu_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("ECU参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        //控制极性
        public bool setupCtrlPolarity(jylink_ctrlpolarity_test cpParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.CTRLPOLARITY_TEST, cpParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.CTRLPOLARITY_TEST, cpParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.CTRLPOLARITY_TEST)
                            {
                                var ecuParamDown = buffer.ToStructure<jylink_ctrlpolarity_test>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("控制极性参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        public void setMode(string modein)
        {
            giveComport = true;
            JYLinkMessage buffer;

            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_flightmode_setup jymode = new JYLink.jylink_flightmode_setup();
                    int ssysid = JY.sysid;
                    int stargetid = JY.targetid;
                    if (translateMode(modein, ref jymode))
                    {

                        setMode(jymode);

                        MainForm.instance.isSendSuccess = true;
                        giveComport = false;
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("Failed to change Modes");
                }
            }
        }
        //指令上传
        public void missionUpLoad(string cmdName)
        {
            giveComport = true;
            JYLinkMessage buffer;

            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    if (cmdName.Equals("Mode") || cmdName.Equals("Target") || cmdName.Equals("Umbrella") || cmdName.Equals("TakeOff") || cmdName.Equals("Return_To_Launch") || cmdName.Equals("Land"))
                    {
                        JYLink.jylink_mission_upload jytask = new JYLink.jylink_mission_upload();

                        if (translateTask(cmdName, ref jytask))
                        {
                            setTask(jytask);
                            MainForm.instance.isSendSuccess = true;
                            giveComport = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("指令上传失败");
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("Failed to upload mission");
                }
            }
        }
        //数传链路测试
        public bool linkTest()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_link_test linkTest = new JYLink.jylink_link_test();
                    linkTest.data1 = 0x01;
                    linkTest.data2 = 0x02;
                    linkTest.data3 = 0x03;
                    linkTest.data4 = 0x04;
                    linkTest.data5 = 0x05;
                    linkTest.data6 = 0x06;
                    linkTest.data7 = 0x07;
                    linkTest.data8 = 0x08;
                    linkTest.data9 = 0x09;
                    linkTest.data10 = 0x10;

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LINK_TEST, linkTest);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.LINK_TEST, linkTest);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.LINK_TEST)
                            {
                                var asbaDown = buffer.ToStructure<jylink_link_test>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("数传链路测试失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public void setMode(JYLink.jylink_flightmode_setup mode)
        {
            //mode.base_mode |= (byte)base_mode;

            generatePacket((byte)JYLink.JYLINK_MSG_ID.FLIGHT_MODE_SETUP, mode);
            //System.Threading.Thread.Sleep(10);
            //generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FLIGHT_MODE_SETUP, mode);
        }

        public void setTask(JYLink.jylink_mission_upload task)
        {
            generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.MISSION_UPLOAD, task);
        }

        /// <summary>
        /// used for last bad serial characters
        /// </summary>
        private byte[] lastbad = new byte[2];

        private double t7 = 1.0e7;
        public string activeDir=null;
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
        public static void ReadWithTimeout(Stream BaseStream, byte[] buffer, int offset, int count)
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

        private static void AddText(BufferedStream bs, string value)
        {
            byte[] info = new UTF8Encoding().GetBytes(value);
            bs.Write(info, 0, info.Length);
        }
        /// <summary>
        /// Serial Reader to read mavlink packets. POLL method
        /// </summary>
        /// <returns></returns>


        public JYLinkMessage readPacket()
        {
            byte[] buffer = new byte[270];

            int readcount = 0;
            BaseStream.ReadTimeout = 1200;
            lock (readlock)
            {
                if (logreadmode)
                {
                    giveComport = false;
                    int lengthData = readlogPacketMavlink(buffer);


                    if (lengthData != 0)
                    {
                        Array.Resize<byte>(ref buffer, lengthData);
                    }

                }
                else
                {
                    while (readcount < 200 || logreadmode)
                    {
                        // read STX1 byte


                        ReadWithTimeout(BaseStream, buffer, 0, 1);

                        if (buffer[0] == JYLink.JYLINK_STX_1)
                            break;

                        readcount += 1;
                    }

                    var headerlength = 0;
                    if (buffer[0] == JYLINK_STX_1)
                        headerlength = JYLINK_HEADER_LEN;

                    var headerlengthstx = headerlength + 2;

                    // read header
                    ReadWithTimeout(BaseStream, buffer, 1, headerlength + 1);

                    // packet length
                    int lengthtoread = 0;
                    if (buffer[0] == JYLINK_STX_1)
                    {
                        lengthtoread = buffer[6] + headerlengthstx + 1; // data + header + checksum - magic - length

                    }
                    //read rest of packet
                    ReadWithTimeout(BaseStream, buffer, 7, lengthtoread - (headerlengthstx));

                    // resize the packet to the correct length
                    Array.Resize<byte>(ref buffer, lengthtoread);
                }

            }
            JYLinkMessage message = new JYLinkMessage(buffer);
            uint msgid = message.msgid;
            if (buffer[2] == 0x25 &&buffer[4] == 0xFF)//获取船位置信息
            {                    
                    CurrentState.xn_lng = BitConverter.ToDouble(buffer,7);
                    CurrentState.xn_lat = BitConverter.ToDouble(buffer, 15);
                    CurrentState.xn_head = BitConverter.ToInt16(buffer, 23);
                    CurrentState.xn_speed = BitConverter.ToInt16(buffer, 25);
                    return null;
            }
            if (Zhan_id != 0xD0 && !logreadmode)
            {
                if (Zhan_id != message.sysid || !MainForm.instance.Table_id.Contains(message.targetid))
                {
                    return null;
                }
            }


            byte crc = JylinkCRC.crc_calculate(buffer, buffer.Length - 1);

            if (crc != buffer[buffer.Length - 1] || buffer[1] != 0x90 || buffer[2] == 0x22)
            {
                return null;
            } 
            else
            {
                //校验通过后再更新数据
                JYlist[message.sysid, message.targetid].packets[msgid] = message;
                if (JYlist[message.sysid, message.targetid].packets.ContainsKey(0xB7) && JYlist[message.sysid, message.targetid].packets.ContainsKey(0xA0))
                {
                    if (msgid == 0xB7)
                    {
                        JYlist[message.sysid, message.targetid].packets.Remove(0xA0);
                        JYlist[message.sysid, message.targetid].packets.Remove(0xB6);
                    }
                    else if (msgid == 0xB6)
                    {
                        JYlist[message.sysid, message.targetid].packets.Remove(0xB7);
                    }
                }
                // create a state for any sysid/compid includes gcs on log playback
                if (!JYlist.Contains(message.sysid, message.targetid) && message.targetid != 0xFF && message.targetid != 0)
                {
                    // create an item - hidden
                    JYlist.AddHiddenList(message.sysid, message.targetid);
                    Thread.Sleep(100);
                }
                if (!JYlist.Contains(message.sysid, message.targetid, false) && message.targetid != 0xFF && message.targetid != 0)
                {
                    // ensure its set from connect or log playback
                    JYlist.Create(message.sysid, message.targetid);
                    Thread.Sleep(100);
                }
                //写入tlog日志记录
                // getWPsfromstream(ref message, sysid, compid);
                try
                {
                    if (logfile == null && !logreadmode && MainForm.comPort.logplaybackfile == null)
                    {
                        activeDir = "D:\\飞行数据" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                        System.IO.Directory.CreateDirectory(activeDir);
                        string filepath = activeDir + "\\原始数据.tlog";
                        MainForm.comPort.logfile =
                         new BufferedStream(
                           File.Open(
                            filepath, FileMode.CreateNew,
                             FileAccess.ReadWrite, FileShare.None));
                    }
                    if (logfile != null && logfile.CanWrite && !logreadmode)
                    {
                        lock (logfile)
                        {
                            logfile.Write(buffer, 0, buffer.Length);                      
                            if (msgid == 0)
                            {
                                // flush on heartbeat - 1 seconds
                                logfile.Flush();
                                rawlogfile.Flush();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }


                return message;
            }

                
           
     

            //// update last valid packet receive time
            //MAVlist[sysid, compid].lastvalidpacket = DateTime.Now;

            //return message;

        }

        public PointLatLngAlt getFencePoint(int no, ref int total)
        {
            //JYLinkMessage buffer;

            // giveComport = true;

            // PointLatLngAlt plla = new PointLatLngAlt();
            // mavlink_fence_fetch_point_t req = new mavlink_fence_fetch_point_t();

            // req.idx = (byte)no;
            // req.target_component = MAV.compid;
            // req.target_system = MAV.sysid;

            // // request point
            // generatePacket((byte)MAVLINK_MSG_ID.FENCE_FETCH_POINT, req);

            // DateTime start = DateTime.Now;
            // int retrys = 3;

            // while (true)
            // {
            //     if (!(start.AddMilliseconds(700) > DateTime.Now))
            //     {
            //         if (retrys > 0)
            //         {
            //             log.Info("getFencePoint Retry " + retrys + " - giv com " + giveComport);
            //             generatePacket((byte)MAVLINK_MSG_ID.FENCE_FETCH_POINT, req);
            //             start = DateTime.Now;
            //             retrys--;
            //             continue;
            //         }
            //         giveComport = false;
            //         throw new Exception("Timeout on read - getFencePoint");
            //     }

            //     buffer = readPacket();
            //     if ( buffer!=null&&buffer.Length > 5)
            //     {
            //         if (buffer.msgid == (byte)MAVLINK_MSG_ID.FENCE_POINT)
            //         {
            //             giveComport = false;

            //             mavlink_fence_point_t fp = buffer.ToStructure<mavlink_fence_point_t>();

            //             plla.Lat = fp.lat;
            //             plla.Lng = fp.lng;
            //             plla.Tag = fp.idx.ToString();

            //             total = fp.count;

            //             return plla;
            //         }
            //     }
            // }
            return null;
        }

        public FileStream GetLog(ushort no)
        {
            return null;
            //FileStream ms = new FileStream(Path.GetTempFileName(), FileMode.Create, FileAccess.ReadWrite);
            //Hashtable set = new Hashtable();

            //giveComport = true;
            //JYLinkMessage buffer;

            //if (Progress != null)
            //{
            //    Progress((int)0, "");
            //}

            //uint totallength = 0;
            //uint ofs = 0;
            //uint bps = 0;
            //DateTime bpstimer = DateTime.Now;

            //mavlink_log_request_data_t req = new mavlink_log_request_data_t();

            //req.target_component = MAV.compid;
            //req.target_system = MAV.sysid;
            //req.id = no;
            //req.ofs = ofs;
            //// entire log
            //req.count = 0xFFFFFFFF;

            //// request point
            //generatePacket((byte)MAVLINK_MSG_ID.LOG_REQUEST_DATA, req);

            //DateTime start = DateTime.Now;
            //int retrys = 3;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(3000) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("GetLog Retry " + retrys + " - giv com " + giveComport);
            //            generatePacket((byte)MAVLINK_MSG_ID.LOG_REQUEST_DATA, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - GetLog");
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.LOG_DATA)
            //        {
            //            var data = buffer.ToStructure<mavlink_log_data_t>();

            //            if (data.id != no)
            //                continue;

            //            // reset retrys
            //            retrys = 3;
            //            start = DateTime.Now;

            //            bps += data.count;

            //            // record what we have received
            //            set[(data.ofs / 90).ToString()] = 1;

            //            ms.Seek((long)data.ofs, SeekOrigin.Begin);
            //            ms.Write(data.data, 0, data.count);

            //            // update new start point
            //            req.ofs = data.ofs + data.count;

            //            if (bpstimer.Second != DateTime.Now.Second)
            //            {
            //                if (Progress != null)
            //                {
            //                    Progress((int)req.ofs, "");
            //                }

            //                //Console.WriteLine("log dl bps: " + bps.ToString());
            //                bpstimer = DateTime.Now;
            //                bps = 0;
            //            }

            //            // if data is less than max packet size or 0 > exit
            //            if (data.count < 90 || data.count == 0)
            //            {
            //                totallength = data.ofs + data.count;
            //                log.Info("start fillin len " + totallength + " count " + set.Count + " datalen " +
            //                         data.count);
            //                break;
            //            }
            //        }
            //    }
            //}

            //log.Info("set count " + set.Count);
            //log.Info("count total " + ((totallength) / 90 + 1));
            //log.Info("totallength " + totallength);
            //log.Info("current length " + ms.Length);

            //while (true)
            //{
            //    if (totallength == ms.Length && set.Count >= ((totallength) / 90 + 1))
            //    {
            //        giveComport = false;
            //        return ms;
            //    }

            //    if (!(start.AddMilliseconds(500) > DateTime.Now))
            //    {
            //        for (int a = 0; a < ((totallength) / 90 + 1); a++)
            //        {
            //            if (!set.ContainsKey(a.ToString()))
            //            {
            //                // request large chunk if they are back to back
            //                uint bytereq = 90;
            //                int b = a + 1;
            //                while (!set.ContainsKey(b.ToString()))
            //                {
            //                    bytereq += 90;
            //                    b++;
            //                }

            //                req.ofs = (uint)(a * 90);
            //                req.count = bytereq;
            //                log.Info("req missing " + req.ofs + " " + req.count);
            //                generatePacket((byte)MAVLINK_MSG_ID.LOG_REQUEST_DATA, req);
            //                start = DateTime.Now;
            //                break;
            //            }
            //        }
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.LOG_DATA)
            //        {
            //            var data = buffer.ToStructure<mavlink_log_data_t>();

            //            if (data.id != no)
            //                continue;

            //            // reset retrys
            //            retrys = 3;
            //            start = DateTime.Now;

            //            bps += data.count;

            //            // record what we have received
            //            set[(data.ofs / 90).ToString()] = 1;

            //            ms.Seek((long)data.ofs, SeekOrigin.Begin);
            //            ms.Write(data.data, 0, data.count);

            //            // update new start point
            //            req.ofs = data.ofs + data.count;

            //            if (bpstimer.Second != DateTime.Now.Second)
            //            {
            //                if (Progress != null)
            //                {
            //                    Progress((int)req.ofs, "");
            //                }

            //                //Console.WriteLine("log dl bps: " + bps.ToString());
            //                bpstimer = DateTime.Now;
            //                bps = 0;
            //            }

            //            // check if we have next set and invalidate to request next packets
            //            if (set.ContainsKey(((data.ofs / 90) + 1).ToString()))
            //            {
            //                start = DateTime.MinValue;
            //            }

            //            // if data is less than max packet size or 0 > exit
            //            if (data.count < 90 || data.count == 0)
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //}
        }

        //public List<mavlink_log_entry_t> GetLogList()
        //{
        //    List<mavlink_log_entry_t> ans = new List<mavlink_log_entry_t>();

        //    mavlink_log_entry_t entry1 = GetLogEntry(0, ushort.MaxValue);

        //    log.Info("id " + entry1.id + " lastllogno " + entry1.last_log_num + " #logs " + entry1.num_logs + " size " +
        //             entry1.size);
        //    //ans.Add(entry1);

        //    for (ushort a = (ushort)(entry1.last_log_num - entry1.num_logs + 1); a <= entry1.last_log_num; a++)
        //    {
        //        mavlink_log_entry_t entry = GetLogEntry(a, a);
        //        ans.Add(entry);
        //    }

        //    return ans;
        //}

        public void GetMountStatus()
        {
            //mavlink_mount_status_t req = new MAVLink.mavlink_mount_status_t();
            //req.target_component = MAV.compid;
            //req.target_system = MAV.sysid;

            //generatePacket((byte)MAVLINK_MSG_ID.MOUNT_STATUS, req);
        }

        //public mavlink_log_entry_t GetLogEntry(ushort startno = 0, ushort endno = ushort.MaxValue)
        //{
        //    giveComport = true;
        //    MAVLinkMessage buffer;

        //    mavlink_log_request_list_t req = new mavlink_log_request_list_t();

        //    req.target_component = MAV.compid;
        //    req.target_system = MAV.sysid;
        //    req.start = startno;
        //    req.end = endno;

        //    log.Info("GetLogEntry " + startno + "-" + endno);

        //    // request point
        //    generatePacket((byte)MAVLINK_MSG_ID.LOG_REQUEST_LIST, req);

        //    DateTime start = DateTime.Now;
        //    int retrys = 5;

        //    while (true)
        //    {
        //        if (!(start.AddMilliseconds(2000) > DateTime.Now))
        //        {
        //            if (retrys > 0)
        //            {
        //                log.Info("GetLogEntry Retry " + retrys + " - giv com " + giveComport);
        //                generatePacket((byte)MAVLINK_MSG_ID.LOG_REQUEST_LIST, req);
        //                start = DateTime.Now;
        //                retrys--;
        //                continue;
        //            }
        //            giveComport = false;
        //            throw new Exception("Timeout on read - GetLogEntry");
        //        }

        //        buffer = readPacket();
        //        if ( buffer!=null&&buffer.Length > 5)
        //        {
        //            if (buffer.msgid == (byte)MAVLINK_MSG_ID.LOG_ENTRY)
        //            {
        //                var ans = buffer.ToStructure<mavlink_log_entry_t>();

        //                if (ans.id >= startno && ans.id <= endno)
        //                {
        //                    giveComport = false;
        //                    return ans;
        //                }
        //            }
        //        }
        //    }
        //}

        public void EraseLog()
        {
            //mavlink_log_erase_t req = new mavlink_log_erase_t();

            //req.target_component = MAV.compid;
            //req.target_system = MAV.sysid;

            //// send twice - we have no feedback on this
            //generatePacket((byte)MAVLINK_MSG_ID.LOG_ERASE, req);
            //generatePacket((byte)MAVLINK_MSG_ID.LOG_ERASE, req);
        }

        public List<PointLatLngAlt> getRallyPoints()
        {
            //List<PointLatLngAlt> points = new List<PointLatLngAlt>();

            //if (!MAV.param.ContainsKey("RALLY_TOTAL"))
            //    return points;

            //int count = int.Parse(MAV.param["RALLY_TOTAL"].ToString());

            //for (int a = 0; a < (count - 1); a++)
            //{
            //    try
            //    {
            //        PointLatLngAlt plla = getRallyPoint(a, ref count);
            //        points.Add(plla);
            //    }
            //    catch
            //    {
            //        return points;
            //    }
            //}

            //return points;
            return null;
        }

        public PointLatLngAlt getRallyPoint(int no, ref int total)
        {
            return null;
            //MAVLinkMessage buffer;

            //giveComport = true;

            //PointLatLngAlt plla = new PointLatLngAlt();
            //mavlink_rally_fetch_point_t req = new mavlink_rally_fetch_point_t();

            //req.idx = (byte)no;
            //req.target_component = MAV.compid;
            //req.target_system = MAV.sysid;

            //// request point
            //generatePacket((byte)MAVLINK_MSG_ID.RALLY_FETCH_POINT, req);

            //DateTime start = DateTime.Now;
            //int retrys = 3;

            //while (true)
            //{
            //    if (!(start.AddMilliseconds(700) > DateTime.Now))
            //    {
            //        if (retrys > 0)
            //        {
            //            log.Info("getRallyPoint Retry " + retrys + " - giv com " + giveComport);
            //            generatePacket((byte)MAVLINK_MSG_ID.FENCE_FETCH_POINT, req);
            //            start = DateTime.Now;
            //            retrys--;
            //            continue;
            //        }
            //        giveComport = false;
            //        throw new Exception("Timeout on read - getRallyPoint");
            //    }

            //    buffer = readPacket();
            //    if ( buffer!=null&&buffer.Length > 5)
            //    {
            //        if (buffer.msgid == (byte)MAVLINK_MSG_ID.RALLY_POINT)
            //        {
            //            mavlink_rally_point_t fp = buffer.ToStructure<mavlink_rally_point_t>();

            //            if (req.idx != fp.idx)
            //            {
            //                generatePacket((byte)MAVLINK_MSG_ID.FENCE_FETCH_POINT, req);
            //                continue;
            //            }

            //            plla.Lat = fp.lat / t7;
            //            plla.Lng = fp.lng / t7;
            //            plla.Tag = fp.idx.ToString();
            //            plla.Alt = fp.alt;

            //            total = fp.count;

            //            giveComport = false;

            //            return plla;
            //        }
            //    }
            //}
        }

        public bool setFencePoint(byte index, PointLatLngAlt plla, byte fencepointcount)
        {
            //mavlink_fence_point_t fp = new mavlink_fence_point_t();

            //fp.idx = index;
            //fp.count = fencepointcount;
            //fp.lat = (float)plla.Lat;
            //fp.lng = (float)plla.Lng;
            //fp.target_component = MAV.compid;
            //fp.target_system = MAV.sysid;

            //int retry = 3;

            //PointLatLngAlt newfp;

            //while (retry > 0)
            //{
            //    generatePacket((byte)MAVLINK_MSG_ID.FENCE_POINT, fp);
            //    int counttemp = 0;
            //    newfp = getFencePoint(fp.idx, ref counttemp);

            //    if (newfp.GetDistance(plla) < 5)
            //        return true;
            //    retry--;
            //}

            //throw new Exception("Could not verify GeoFence Point");
            return true;
        }

        public bool setRallyPoint(byte index, PointLatLngAlt plla, short break_alt, UInt16 land_dir_cd, byte flags,
            byte rallypointcount)
        {
            //mavlink_rally_point_t rp = new mavlink_rally_point_t();

            //rp.idx = index;
            //rp.count = rallypointcount;
            //rp.lat = (int)(plla.Lat * t7);
            //rp.lng = (int)(plla.Lng * t7);
            //rp.alt = (short)plla.Alt;
            //rp.break_alt = break_alt;
            //rp.land_dir = land_dir_cd;
            //rp.flags = (byte)flags;
            //rp.target_component = MAV.compid;
            //rp.target_system = MAV.sysid;

            //int retry = 3;

            //while (retry > 0)
            //{
            //    generatePacket((byte)MAVLINK_MSG_ID.RALLY_POINT, rp);
            //    int counttemp = 0;
            //    PointLatLngAlt newfp = getRallyPoint(rp.idx, ref counttemp);

            //    if (newfp.Lat == plla.Lat && newfp.Lng == rp.lng)
            //    {
            //        Console.WriteLine("Rally Set");
            //        return true;
            //    }
            //    retry--;
            //}

            return false;
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
            // byte[] temp = new byte[300];

            //  public DataPlayback dataPlayback = new DataPlayback();

            byte[] datearray = new byte[8];

            //      MainForm.Comports
            int length = 7;
            int a = 0;
            while (a < length)
            {
                if (logplaybackfile.BaseStream.Position == logplaybackfile.BaseStream.Length)
                    break;
                temp[a] = (byte)logplaybackfile.ReadByte();

                if (temp[0] != 235)
                {
                    log.InfoFormat("logread - lost sync byte {0} pos {1}", temp[0], logplaybackfile.BaseStream.Position);
                    a = 0;
                    continue;
                }
                if (a == 1)
                {
                    int headerlength = temp[0] == JYLINK_STX_1 ? 7 : 5;
                    int headerlengthstx = JYLINK_HEADER_LEN;

                    // header + 2 checksum
                }
                if (a == 6)
                {
                    length = temp[6] + JYLINK_HEADER_LEN + 3;
                    if (!(temp[2] == 0xA0 || temp[2] == 0xB6 || temp[2] == 0xB7 || temp[2] == 0x25 || temp[2] == 0x24))
                    {
                        logplaybackfile.ReadBytes(temp[6]+1);
                        a = 0;
                        continue;
                    }
                }

                a++;
            }

            return length;

        }

        public bool translateMode(string modein, ref JYLink.jylink_flightmode_setup mode)
        {
            //mode = JY.sysid;

            if (modein == null || modein == "")
                return false;

            try
            {
                List<KeyValuePair<int, string>> modelist = Common.getModesList(JY.cs);

                foreach (KeyValuePair<int, string> pair in modelist)
                {
                    if (pair.Value.ToLower() == modein.ToLower())
                    {
                        //mode.base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED;
                        mode.flight_mode = (byte)pair.Key;
                    }
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Failed to find Mode");
                return false;
            }

            return true;
        }

        public bool translateTask(string taskin, ref JYLink.jylink_mission_upload task)
        {
            //mode = JY.sysid;

            if (taskin == null || taskin == "")
                return false;

            try
            {
                if (taskin.Equals("Mode"))
                {
                    task.mission_id = 0x01;
                }
                else if (taskin.Equals("Target"))
                {
                    task.mission_id = 0x02;
                }
                else if (taskin.Equals("Umbrella"))
                {
                    task.mission_id = 0x03;
                }
                else if (taskin.Equals("TakeOff"))
                {
                    task.mission_id = 0x04;
                }
                else if (taskin.Equals("Return_To_Launch"))
                {
                    task.mission_id = 0x05;
                }
                else if (taskin.Equals("Land"))
                {
                    task.mission_id = 0x06;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Failed to find Task");
                return false;
            }

            return true;
        }

        //public void setAPType(byte sysid, byte compid)
        //{
        //    MAVlist[sysid, compid].sysid = sysid;
        //    MAVlist[sysid, compid].compid = compid;

        //    switch (MAVlist[sysid, compid].apname)
        //    {
        //        case MAV_AUTOPILOT.ARDUPILOTMEGA:
        //            switch (MAVlist[sysid, compid].aptype)
        //            {
        //                case MAVLink.MAV_TYPE.FIXED_WING:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduPlane;
        //                    break;

        //                case MAVLink.MAV_TYPE.QUADROTOR:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduCopter2;
        //                    break;

        //                case MAVLink.MAV_TYPE.TRICOPTER:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduCopter2;
        //                    break;

        //                case MAVLink.MAV_TYPE.HEXAROTOR:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduCopter2;
        //                    break;

        //                case MAVLink.MAV_TYPE.OCTOROTOR:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduCopter2;
        //                    break;

        //                case MAVLink.MAV_TYPE.HELICOPTER:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduCopter2;
        //                    break;

        //                case MAVLink.MAV_TYPE.GROUND_ROVER:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduRover;
        //                    break;

        //                case MAV_TYPE.ANTENNA_TRACKER:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduTracker;
        //                    break;

        //                default:
        //                    break;
        //            }
        //            break;

        //        case MAV_AUTOPILOT.UDB:
        //            switch (MAVlist[sysid, compid].aptype)
        //            {
        //                case MAVLink.MAV_TYPE.FIXED_WING:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.ArduPlane;
        //                    break;
        //            }
        //            break;

        //        case MAV_AUTOPILOT.GENERIC:
        //            switch (MAVlist[sysid, compid].aptype)
        //            {
        //                case MAVLink.MAV_TYPE.FIXED_WING:
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.Ateryx;
        //                    break;
        //            }
        //            break;

        //        case MAV_AUTOPILOT.PX4:
        //            MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.PX4;
        //            break;

        //        default:
        //            switch (MAVlist[sysid, compid].aptype)
        //            {
        //                case MAV_TYPE.GIMBAL: // storm32 - name 83
        //                    MAVlist[sysid, compid].cs.firmware = MainForm.Firmwares.Gymbal;
        //                    break;
        //            }
        //            break;
        //    }

        //    switch (MAVlist[sysid, compid].cs.firmware)
        //    {
        //        case MainForm.Firmwares.ArduCopter2:
        //            MAVlist[sysid, compid].Guid = Settings.Instance["copter_guid"].ToString();
        //            break;

        //        case MainForm.Firmwares.ArduPlane:
        //            MAVlist[sysid, compid].Guid = Settings.Instance["plane_guid"].ToString();
        //            break;

        //        case MainForm.Firmwares.ArduRover:
        //            MAVlist[sysid, compid].Guid = Settings.Instance["rover_guid"].ToString();
        //            break;
        //    }
        //}

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
        //IMU参数查询
        public jylink_imu_param_down searchImu()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_imu_param_search imu = new JYLink.jylink_imu_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.IMU_PARAM_SEARCH, imu);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.IMU_PARAM_SEARCH, imu);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.IMU_PARAM_DOWN)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_imu_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return imuParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("IMU参数查询失败。");
                }
            }
            giveComport = false;
            jylink_imu_param_down imunull = new jylink_imu_param_down();
            return imunull;
        }
        //imu参数设置
        public bool setupImu(jylink_imu_param_setup imuParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.IMU_PARAM_SETUP, imuParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.IMU_PARAM_SETUP, imuParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.IMU_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_imu_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("IMU参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        public void mainCtrlCmdSetup(jylink_mainctrl_command_setup mainctrlCmd)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.MAINCTRL_CMD_SETUP, mainctrlCmd);
                    //DateTime start = DateTime.Now;
                    //int retrys = 3;

                    //while (true)
                    //{

                    //    if (!(start.AddMilliseconds(1000) > DateTime.Now))
                    //    {
                    //        if (retrys > 0)
                    //        {
                    //          generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.MAINCTRL_CMD_SETUP, mainctrlCmd);
                    //            start = DateTime.Now;
                    //            retrys--;
                    //            continue;
                    //        }
                    //        return;
                    //    }
                    //buffer = readPacket();
                    //if ( buffer!=null&&buffer.Length > 5)
                    //{
                    //    if (buffer.msgid == (byte)JYLINK_MSG_ID.MAINCTRL_CMD_SETUP)
                    //    {
                    //        MainForm.instance.isSendSuccess = true;
                    //        return;
                    //    }
                    //}
                    // }

                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("主控板命令上传失败。");
                }
            }
            giveComport = false;
            return;
        }

        public bool setupKongyu(jylink_kongyu_param microparam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.KONGYU_PARAM_SETUP, microparam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.KONGYU_PARAM_SETUP, microparam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.KONGYU_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_kongyu_param>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("归航模式设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_kongyu_param searchKongyu()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_kongyu_param_search guide = new JYLink.jylink_kongyu_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.KONGYU_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.KONGYU_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.KONGYU_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_kongyu_param>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_kongyu_param navnull = new jylink_kongyu_param();
            return navnull;
        }
        //nav参数设置Kgsx
        //public bool setupNavKgsx(jylink_nav_Kgsx_param_setup navParam)
        //{
        //    giveComport = true;
        //    JYLinkMessage buffer;
        //    if (MainForm.instance._linkqualitygcs <= 0)
        //    {
        //        MainForm.instance.isSendSuccess = false;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.NAV_Kgsx_PARAM_SETUP, navParam);
        //            DateTime start = DateTime.Now;
        //            int retrys = 3;

        //            while (true)
        //            {
        //                if (!(start.AddMilliseconds(500) > DateTime.Now))
        //                {
        //                    if (retrys > 0)
        //                    {
        //                        generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.NAV_Kgsx_PARAM_SETUP, navParam);
        //                        start = DateTime.Now;
        //                        retrys--;
        //                        continue;
        //                    }
        //                    giveComport = false;
        //                    return false;
        //                }
        //                buffer = readPacket();
        //                if (buffer != null && buffer.Length > 5)
        //                {
        //                    if (buffer.msgid == (byte)JYLINK_MSG_ID.NAV_Kgsx_PARAM_SETUP)
        //                    {
        //                        var imuParamDown = buffer.ToStructure<jylink_nav_Kgsx_param_setup>();
        //                        MainForm.instance.isSendSuccess = true;
        //                        giveComport = false;
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            MainForm.instance.isSendSuccess = false;
        //            System.Windows.Forms.MessageBox.Show("Kgsx参数设置失败。");
        //        }
        //    }
        public bool setupZh(jylink_zhenghe_param microparam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ZHENGHE_PARAM_SETUP, microparam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ZHENGHE_PARAM_SETUP, microparam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ZHENGHE_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_zhenghe_param>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("归航模式设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_zhenghe_param searchZh()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_zhenghe_param_search guide = new JYLink.jylink_zhenghe_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ZHENGHE_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ZHENGHE_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ZHENGHE_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_zhenghe_param>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_zhenghe_param navnull = new jylink_zhenghe_param();
            return navnull;
        }
        public bool setupDuoji(jylink_duoji_param_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Duoji_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Duoji_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.Duoji_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_duoji_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("舵机中位状态参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_planeID_param_down searchPlaneId()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_planeID_param_search guide = new JYLink.jylink_planeID_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.PLANEID_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_planeID_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("ID参数查询失败。");
                }
            }
            giveComport = false;
            jylink_planeID_param_down navnull = new jylink_planeID_param_down();
            return navnull;
        }

        public jylink_bd_planeID_param_down searchBDPlaneId()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bd_planeID_param_search guide = new JYLink.jylink_bd_planeID_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(1000) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_PLANEID_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_bd_planeID_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("编队ID参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bd_planeID_param_down navnull = new jylink_bd_planeID_param_down();
            return navnull;
        }

        public bool setupPlaneId(jylink_planeID_param_set navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.PLANEID_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_planeID_param_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("ID参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupBDPlaneId(jylink_bd_planeID_param_set navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_PLANEID_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_bd_planeID_param_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("编队ID参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupBDControl(jylink_bd_control_param_set navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_bd_control_param_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("编队控制参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_bd_control_param_down searchBDControl()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bd_control_param_search guide = new JYLink.jylink_bd_control_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_CONTROL_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_bd_control_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("编队控制参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bd_control_param_down navnull = new jylink_bd_control_param_down();
            return navnull;
        }

        public bool setupMode(jylink_fangzhe_set navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FANGZHEN_SET, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FANGZHEN_SET, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.FANGZHEN_SET)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_fangzhe_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("编队控制参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupToNextPoint(jylink_to_nextpoint_set navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FLYTONEXTPOINT_SET, navParam);
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("仿真设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_engine_param_down searchEngine()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_engine_param_search guide = new JYLink.jylink_engine_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ENGINE_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ENGINE_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ENGINE_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_engine_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_engine_param_down navnull = new jylink_engine_param_down();
            return navnull;
        }

        public bool setupEngine(jylink_engine_param_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ENGINE_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.ENGINE_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.ENGINE_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_engine_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show(" 类型设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public jylink_bandwidth_param_down searchBandWidth()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bandwidth_param_search guide = new JYLink.jylink_bandwidth_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BANDWIDTH_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BANDWIDTH_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BANDWIDTH_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_bandwidth_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bandwidth_param_down navnull = new jylink_bandwidth_param_down();
            return navnull;
        }

        public bool setupBandWidth(jylink_bandwidth_param_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BANDWIDTH_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BANDWIDTH_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BANDWIDTH_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_bandwidth_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("遥测带宽设置失败。");
                }
            }
            giveComport = false;
            return false;
        }


        public jylink_gmode_param_down searchGmode()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_gmode_param_search guide = new JYLink.jylink_gmode_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GMODE_PARAM_SEARCH, guide);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GMODE_PARAM_SEARCH, guide);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GMODE_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_gmode_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_gmode_param_down navnull = new jylink_gmode_param_down();
            return navnull;
        }

        public bool setupGmode(jylink_gmode_param_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GMODE_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.GMODE_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.GMODE_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_gmode_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("归航模式设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        public bool setupPlaneId(jylink_planeID_param_set navParam, byte targid)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SETUP, navParam, Zhan_id, targid);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SETUP, navParam, Zhan_id, targid);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.PLANEID_PARAM_SETUP)
                            {

                                var imuParamDown = buffer.ToStructure<jylink_planeID_param_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("ID参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }
        public jylink_planeID_param_down searchPlaneId(byte id)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_planeID_param_search guide = new JYLink.jylink_planeID_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SEARCH, guide, Zhan_id, id);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.PLANEID_PARAM_SEARCH, guide, Zhan_id, id);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.PLANEID_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_planeID_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("ID参数查询失败。");
                }
            }
            giveComport = false;
            jylink_planeID_param_down navnull = new jylink_planeID_param_down();
            return navnull;
        }

        public bool setupTuoluo(jylink_tuoluo_param_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TUOLUO_PARAM_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.TUOLUO_PARAM_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.TUOLUO_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_tuoluo_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupJiDongMode(jylink_flightmode_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FLIGHT_MODE_SETUP, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.FLIGHT_MODE_SETUP, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.FLIGHT_MODE_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_flightmode_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;

                }
            }
            giveComport = false;
            return false;
        }
        public void setKdjPosition(JYLink.jylink_Micro_position_setup home)
        {
            generatePacket(0x35, home, Zhan_id, 255);
        }
        //micro参数设置
        public bool setupMicro(JYLink.jylink_Micro_param_setup microParam, int targetid)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_PARAM_SETUP, microParam, Zhan_id, targetid);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_PARAM_SETUP, microParam, Zhan_id, targetid);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.Micro_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_Micro_param_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("微波源参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        //micro参数查询
        public jylink_Micro_param_down searchMicro(int targetid)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_Micro_param_search guide = new JYLink.jylink_Micro_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_PARAM_SEARCH, guide, Zhan_id, targetid);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_PARAM_SEARCH, guide, Zhan_id, targetid);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null)
                        {
                            if (buffer.Length > 5)
                            {
                                if (buffer.msgid == (byte)JYLINK_MSG_ID.Micro_PARAM_DOWN)
                                {
                                    var navParamDown = buffer.ToStructure<jylink_Micro_param_down>();
                                    MainForm.instance.isSendSuccess = true;
                                    giveComport = false;
                                    return navParamDown;
                                }
                            }
                        }

                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("微波源参数查询失败。");
                }
            }
            giveComport = false;
            // System.Windows.Forms.MessageBox.Show("微波源参数查询失败。");
            jylink_Micro_param_down navnull = new jylink_Micro_param_down();
            return navnull;
        }

        //micro参数查询
        public jylink_Micro_status_down searchMicrostatus(int targetid)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_status_Micro_param_search guide = new JYLink.jylink_status_Micro_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_STATUS_PARAM_SEARCH, guide, Zhan_id, targetid);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Micro_STATUS_PARAM_SEARCH, guide, Zhan_id, targetid);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.Micro_STATUS_PARAM_DOWN)
                            {
                                var navParamDown = buffer.ToStructure<jylink_Micro_status_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return navParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("微波源状态参数查询失败。");
                }
            }
            giveComport = false;
            jylink_Micro_status_down navnull = new jylink_Micro_status_down();
            return navnull;
        }

        public bool setupGrj(JYLink.jylink_Grj_setup grjParam) 
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Grj_PARAM_SETUP, grjParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.Grj_PARAM_SETUP, grjParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.Grj_PARAM_SETUP)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_Grj_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("干扰机指令上传失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupBiandui(jylink_biandui_mode_setup navParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANDUI_MODE_SET, navParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANDUI_MODE_SET, navParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BIANDUI_MODE_SET)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_biandui_mode_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        //制导参数查询
        public jylink_bd_control_param_down searchBianduiCtrl()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bd_control_param_search guidectrl = new JYLink.jylink_bd_control_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SEARCH, guidectrl);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SEARCH, guidectrl);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_CONTROL_PARAM_DOWN)
                            {
                                var guidectrlParamDown = buffer.ToStructure<jylink_bd_control_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return guidectrlParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bd_control_param_down guidectrlnull = new jylink_bd_control_param_down();
            return guidectrlnull;
        }
        //制导参数设置
        public bool setupBianduiCtrl(jylink_bd_control_param_set guidectrlParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP, guidectrlParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP, guidectrlParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_CONTROL_PARAM_SETUP)
                            {
                                var guidectrlDown = buffer.ToStructure<jylink_bd_control_param_set>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("参数设置失败。");
                }
            }
            giveComport = false;
            return false;
        }

        //制导参数查询
        public jylink_bd_planeID_param_down searchBianduiStart()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bd_control_param_search guidectrl = new JYLink.jylink_bd_control_param_search();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SEARCH, guidectrl);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SEARCH, guidectrl);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BD_PLANEID_PARAM_DOWN)
                            {
                                var guidectrlParamDown = buffer.ToStructure<jylink_bd_planeID_param_down>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return guidectrlParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bd_planeID_param_down guidectrlnull = new jylink_bd_planeID_param_down();
            return guidectrlnull;
        }
        //制导参数设置
        public bool setupBianduiStart(jylink_bd_planeID_param_set guidectrlParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SETUP, guidectrlParam);
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BD_PLANEID_PARAM_SETUP, guidectrlParam);
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                }
            }
            giveComport = false;
            return false;
        }

        public bool setupYoumenMode(JYLink.jylink_youmen_mode_setup grjParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.YOUMEN_MODE_SET, grjParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.YOUMEN_MODE_SET, grjParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.YOUMEN_MODE_SET)
                            {
                                var imuParamDown = buffer.ToStructure<jylink_youmen_mode_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("干扰机指令上传失败。");
                }
            }
            giveComport = false;
            return false;
        }

        public int getWPCount(byte num)
        {
            giveComport = true;
            JYLinkMessage buffer;
            jylink_mission_search req = new jylink_mission_search();
            req.num = num;
            req.seq = 0;

            //req. = MAV.sysid;
            //req.target_component = MAV.compid;

            // request list
            //9.26 5:35
            generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);

            DateTime start = DateTime.Now;
            int retrys = 3;

            while (true)
            {
                if (!(start.AddMilliseconds(500) > DateTime.Now))
                {
                    if (retrys > 0)
                    {
                        log.Info("getWPCount Retry " + retrys + " - giv com " + giveComport);
                        generatePacket((byte)JYLINK_MSG_ID.MISSION_SEARCH, req);
                        start = DateTime.Now;
                        retrys--;
                        continue;
                    }
                    giveComport = false;
                    return -1;

                }
                //while (true)
                //{
                buffer = readPacket();
                if (buffer != null)
                {
                    if (buffer != null && buffer.Length > 5)
                    {
                        if (buffer.msgid == (byte)JYLINK_MSG_ID.MISSION_ITEM_DOWN)
                        {
                            var count = buffer.ToStructure<jylink_mission_item>();
                            //var wp = buffer.ToStructure<jylink_mission_item>();

                            // received a packet, but not what we requested
                            Locationwp loc = new Locationwp();
                            loc.p1 = (count.param1);
                            loc.p2 = (count.param2);
                            loc.p3 = (count.param3);
                            loc.p4 = (count.param4);
                            loc.id = (count.cmd);

                            loc.alt = ((count.altitude));
                            loc.lat = ((count.latitude));
                            loc.lng = ((count.longitude));
                            //cmds.Add(loc);
                            //log.Info("wpcount: " + count.count);
                            giveComport = false;
                            //return count.count; // should be ushort, but apm has limited wp count < byte
                            return count.count;
                        }
                    }

                }

                // }
            }
        }

        public jylink_bianhao_setup searchBianHao()
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    JYLink.jylink_bianhao_ser guidectrl = new JYLink.jylink_bianhao_ser();

                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANHAO_Ser, guidectrl);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                log.Info("getVersion Retry " + retrys + " - giv com " + giveComport);
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANHAO_Ser, guidectrl);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            break;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BIANHAO_Down)
                            {
                                var guidectrlParamDown = buffer.ToStructure<jylink_bianhao_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return guidectrlParamDown;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    System.Windows.Forms.MessageBox.Show("参数查询失败。");
                }
            }
            giveComport = false;
            jylink_bianhao_setup guidectrlnull = new jylink_bianhao_setup();
            return guidectrlnull;
        }

        public bool setupBianhao(JYLink.jylink_bianhao_setup grjParam)
        {
            giveComport = true;
            JYLinkMessage buffer;
            if (MainForm.instance._linkqualitygcs <= 0)
            {
                MainForm.instance.isSendSuccess = false;
            }
            else
            {
                try
                {
                    generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANHAO_SET, grjParam);
                    DateTime start = DateTime.Now;
                    int retrys = 3;

                    while (true)
                    {
                        if (!(start.AddMilliseconds(500) > DateTime.Now))
                        {
                            if (retrys > 0)
                            {
                                generatePacket((byte)(byte)JYLink.JYLINK_MSG_ID.BIANHAO_SET, grjParam);
                                start = DateTime.Now;
                                retrys--;
                                continue;
                            }
                            giveComport = false;
                            return false;
                        }
                        buffer = readPacket();
                        if (buffer != null && buffer.Length > 5)
                        {
                            if (buffer.msgid == (byte)JYLINK_MSG_ID.BIANHAO_SET)
                            {
                                //var imuParamDown = buffer.ToStructure<jylink_youmen_mode_setup>();
                                MainForm.instance.isSendSuccess = true;
                                giveComport = false;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    MainForm.instance.isSendSuccess = false;
                    //System.Windows.Forms.MessageBox.Show("干扰机指令上传失败。");
                }
            }
            giveComport = false;
            return false;
        }


      
    }
}