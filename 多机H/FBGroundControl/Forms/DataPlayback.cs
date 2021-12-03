using GMap.NET.WindowsForms;
using log4net;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace FBGroundControl.Forms
{
    public partial class DataPlayback : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Thread thisthread;
        //是否播放
        public bool playingLog;
        public double LogPlayBackSpeed = 1.0;
        public static bool threadrun;
        public int tickStart;


        RollingPointPairList list1 = new RollingPointPairList(1200);
        RollingPointPairList list2 = new RollingPointPairList(1200);
        RollingPointPairList list3 = new RollingPointPairList(1200);
        RollingPointPairList list4 = new RollingPointPairList(1200);
        RollingPointPairList list5 = new RollingPointPairList(1200);
        RollingPointPairList list6 = new RollingPointPairList(1200);
        RollingPointPairList list7 = new RollingPointPairList(1200);
        RollingPointPairList list8 = new RollingPointPairList(1200);
        RollingPointPairList list9 = new RollingPointPairList(1200);
        RollingPointPairList list10 = new RollingPointPairList(1200);

        public DataPlayback()
        {
            InitializeComponent();
        }
        GMapOverlay polygons;
        GMapOverlay routes;
        GMapRoute route;
        GMapMarker marker;
        AviWriter aviwriter;

        protected override void Dispose(bool disposing)
        {


            base.Dispose(disposing);

            MainForm.comPort.logreadmode = false;
            try
            {
                if (MainForm.instance.hudFrm.hud1 != null)
                    Settings.Instance["FlightSplitter"] = MainForm.instance.hudFrm.hud1.Width.ToString();
            }
            catch
            {
            }

            if (polygons != null)
                polygons.Dispose();
            if (routes != null)
                routes.Dispose();
            if (route != null)
                route.Dispose();
            if (marker != null)
                marker.Dispose();
            if (aviwriter != null)
                aviwriter.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
        }
        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUT_loadtelem_Click(object sender, EventArgs e)
        {
            //if (thisthread.IsAlive)
            //{
            //    Application.DoEvents();
            //}


            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.AddExtension = true;
                fd.Filter = "Telemetry log (*.tlog)|*.tlog;*.tlog.*|Mavlink Log (*.mavlog)|*.mavlog";
                fd.InitialDirectory = Settings.Instance.LogDir;
                fd.DefaultExt = ".tlog";
                DialogResult result = fd.ShowDialog();
                if (result==DialogResult.OK)
                {
                    LBL_logfn.Text = "";
                    thisthread.Abort();
                    if (MainForm.comPort.logplaybackfile != null)
                    {
                        try
                        {
                            MainForm.comPort.logplaybackfile.Close();
                            MainForm.comPort.logplaybackfile = null;

                        }
                        catch
                        {
                        }
                    }
                    string file = fd.FileName;
                    LoadLogFile(file);
                }

            }
        }

        public void LoadLogFile(string file)
        {
            if (file != "")
            {
                try
                {
                    BUT_clear_track_Click(null, null);
                    MainForm.comPort.logreadmode = true;
                    MainForm.comPort.logplaybackfile = new BinaryReader(File.OpenRead(file));
                    MainForm.comPort.lastlogread = DateTime.MinValue;
                    MainForm.instance.updateBindingSourcecount = 0;
                    LBL_logfn.Text = Path.GetFileName(file);

                    log.Info("Open logfile " + file);
                   // MainForm.comPort.JYlist.Clear();
                    MainForm.comPort.getHeartBeat();

                    tracklog.Value = 0;
                    tracklog.Minimum = 0;
                    tracklog.Maximum = 100;
                }
                catch
                {
                    CustomMessageBox.Show(Strings.PleaseLoadValidFile, Strings.ERROR);
                }
            }
        }
        private void BUT_clear_track_Click(object sender, EventArgs e)
        {
            if (MainForm.instance.route != null)
                MainForm.instance.route.Points.Clear();
        }
        /// <summary>
        /// 播放、暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUT_playlog_Click(object sender, EventArgs e)
        {
            if (MainForm.comPort.logreadmode)
            {
                MainForm.comPort.logreadmode = false;
                ZedGraphTimer.Stop();
                playingLog = false;
            }
            else
            {
                // BUT_clear_track_Click(sender, e);
                MainForm.comPort.logreadmode = true;
                list1.Clear();
                list2.Clear();
                list3.Clear();
                list4.Clear();
                list5.Clear();
                list6.Clear();
                list7.Clear();
                list8.Clear();
                list9.Clear();
                list10.Clear();
                tickStart = Environment.TickCount;

                zg1.GraphPane.XAxis.Scale.Min = 0;
                zg1.GraphPane.XAxis.Scale.Max = 1;
                ZedGraphTimer.Start();
                playingLog = true;
            }
            updatePlayPauseButton(playingLog);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Make sure that the curvelist has at least one curve
                if (zg1.GraphPane.CurveList.Count <= 0)
                    return;

                // Get the first CurveItem in the graph
                LineItem curve = zg1.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    return;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    return;

                // Time is measured in seconds
                double time = (Environment.TickCount - tickStart) / 1000.0;

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale xScale = zg1.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 10.0;
                }

                // Make sure the Y axis is rescaled to accommodate actual data
                zg1.AxisChange();

                // Force a redraw

                zg1.Invalidate();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 进度条：数据播放进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tracklog_Scroll(object sender, EventArgs e)
        {
            try
            {
                BUT_clear_track_Click(sender, e);

                MainForm.comPort.lastlogread = DateTime.MinValue;
                MainForm.comPort.JY.cs.ResetInternals();

                if (MainForm.comPort.logplaybackfile != null)
                    MainForm.comPort.logplaybackfile.BaseStream.Position =
                        (long)(MainForm.comPort.logplaybackfile.BaseStream.Length * (tracklog.Value / 100.0));

                updateLogPlayPosition();
            }
            catch
            {
            } // ignore any invalid 
        }

        public void updateLogPlayPosition()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (tracklog.Visible)
                        tracklog.Value =
                            (int)
                                (MainForm.comPort.logplaybackfile.BaseStream.Position /
                                 (double)MainForm.comPort.logplaybackfile.BaseStream.Length * 100);
                    if (lbl_logpercent.Visible)
                        lbl_logpercent.Text =
                            (MainForm.comPort.logplaybackfile.BaseStream.Position /
                             (double)MainForm.comPort.logplaybackfile.BaseStream.Length).ToString("0.00%");

                    if (lbl_playbackspeed.Visible)
                        lbl_playbackspeed.Text = "x " + LogPlayBackSpeed;
                }
                catch
                {
                }
            });
        }
        /// <summary>
        /// 加速倍数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUT_speed1_Click(object sender, EventArgs e)
        {
            LogPlayBackSpeed = double.Parse(((MyButton)sender).Tag.ToString(), CultureInfo.InvariantCulture);
            lbl_playbackspeed.Text = "x " + LogPlayBackSpeed;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D1))
            {
                tabControlactions.SelectedIndex = 0;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                tabControlactions.SelectedIndex = 1;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                tabControlactions.SelectedIndex = 2;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                tabControlactions.SelectedIndex = 3;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D5))
            {
                tabControlactions.SelectedIndex = 4;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D6))
            {
                tabControlactions.SelectedIndex = 5;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D7))
            {
                tabControlactions.SelectedIndex = 6;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D8))
            {
                tabControlactions.SelectedIndex = 7;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D9))
            {
                tabControlactions.SelectedIndex = 8;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D0))
            {
                tabControlactions.SelectedIndex = 9;
                return true;
            }

            if (keyData == (Keys.Space))
            {
                if (MainForm.comPort.logplaybackfile != null)
                {
                    BUT_playlog_Click(null, null);
                    return true;
                }
            }
            else if (keyData == (Keys.Subtract))
            {
                if (LogPlayBackSpeed > 1)
                    LogPlayBackSpeed--;
                else
                    LogPlayBackSpeed /= 2;

                updateLogPlayPosition();
            }
            else if (keyData == (Keys.Add))
            {
                if (LogPlayBackSpeed > 1)
                    LogPlayBackSpeed++;
                else
                    LogPlayBackSpeed *= 2;

                updateLogPlayPosition();
            }

            return false;
        }
        DateTime lastscreenupdate = DateTime.Now;
        object updateBindingSourcelock = new object();
        volatile int updateBindingSourcecount;
        string updateBindingSourceThreadName = "";



        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataPlayback_Load(object sender, EventArgs e)
        {
            thisthread = new Thread(MainForm.instance.mainloop);
            thisthread.Name = "FD Mainloop";
            thisthread.IsBackground = true;
            thisthread.Start();
        }

        /// <summary>
        /// 播放/停播
        /// </summary>
        /// <param name="playing"></param>
        public void updatePlayPauseButton(bool playing)
        {
            if (playing)
            {
                if (BUT_playlog.Text == "Pause")
                    return;

                BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        BUT_playlog.Text = "Pause";
                    }
                    catch
                    {
                    }
                });
            }
            else
            {
                if (BUT_playlog.Text == "Play")
                    return;

                BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        BUT_playlog.Text = "Play";
                    }
                    catch
                    {
                    }
                });
            }
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataPlayback_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadrun = false;
            this.Dispose();
            while (thisthread.IsAlive)
            {
                Application.DoEvents();
            }
        }
    }
}
