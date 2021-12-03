using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using GMap.NET.MapProviders;
using MissionPlanner;
using System.IO;
using log4net;
using MissionPlanner.Utilities;
using Strings = FBGroundControl.Strings;
using MissionPlanner.Controls;
using Settings = MissionPlanner.Utilities.Settings;
using MissionPlanner.Comms;
using System.Collections;
using GMap.NET.WindowsForms;
using System.Threading;
using System.Globalization;
using System.Net;
using GMap.NET;
using System.Reflection;
using ZedGraph;
using GMap.NET.WindowsForms.Markers;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Xml;
using MissionPlanner.Controls.Waypoints;
using FBGroundControl.Properties;
using DotSpatial.Projections;
using DotSpatial.Data;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using FBGroundControl.Mavlink;


namespace FBGroundControl
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {



        public static GMapOverlay kmlpolygons;
        internal static GMapOverlay rallypointoverlay;
        internal static GMapOverlay poioverlay = new GMapOverlay("POI"); // poi layer

        Thread serialreaderthread;


        private static readonly log4net.ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MainForm()
        {
            InitializeComponent();

            //repositoryItemComboBox3.Items = ;

            //repositoryItemComboBox3.
            //EnumTranslator.EnumToList<altmode>().ForEach(x => repositoryItemComboBox3.Items.Add(x));


            CMB_altmode.EditValue = altmode.Relative;
            //set default
            //CMB_altmode.EditValue = altmode.Relative;

            /*
            this.repositoryItemLookUpEdit2.DisplayMember = "Value";
            this.repositoryItemLookUpEdit2.ValueMember = "Key";
 
            this.repositoryItemLookUpEdit2.DataSource =  Common.getModesList(MainForm.comPort.MAV.cs);
            */
            repositoryItemComboBox1.Items.AddRange(SerialPort.GetPortNames());
            this.repositoryItemComboBox6.Items.Add("Relative");
            this.repositoryItemComboBox6.Items.Add("Absolute");
            this.repositoryItemComboBox6.Items.Add("Terrain");

            List<KeyValuePair<int, string>> modeList = Common.getModesList(MainForm.comPort.MAV.cs);
            foreach (KeyValuePair<int, string> pair in modeList)
            {
                this.repositoryItemComboBox5.Items.Add(pair.Value);
            }

            this.cboFlightModel.EditValue = "Auto";

            instance = this;


            Settings.Instance["NUM_tracklength"] = "200";

            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();
            config(false);

            this.hud1.opengl = false;

            this.myGMAP1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
            //this.myGMAP1.DragButton = MouseButtons.Left;

            // draw this layer first

            myGMAP1.RoutesEnabled = true;




            //top = new GMapOverlay("top");
            //MainMap.Overlays.Add(top);

            // set current marker
            currentMarker = new GMarkerGoogle(myGMAP1.Position, GMarkerGoogleType.red);
            //top.Markers.Add(currentMarker);

            // map center


            polygonsoverlay = new GMapOverlay("polygons");
            myGMAP1.Overlays.Add(polygonsoverlay);

            routes = new GMapOverlay("routes");
            myGMAP1.Overlays.Add(routes);

            objectsoverlay = new GMapOverlay("objects");
            myGMAP1.Overlays.Add(objectsoverlay);
            objectsoverlay.Markers.Clear();

            kmlpolygons = new GMapOverlay("kmlpolygons");
            myGMAP1.Overlays.Add(kmlpolygons);

            polygons = new GMapOverlay("polygons");
            myGMAP1.Overlays.Add(polygons);

            rallypointoverlay = new GMapOverlay("rally points");
            myGMAP1.Overlays.Add(rallypointoverlay);

            drawnpolygonsoverlay = new GMapOverlay("drawnpolygons");
            myGMAP1.Overlays.Add(drawnpolygonsoverlay);


            List<PointLatLng> polygonPoints2 = new List<PointLatLng>();
            drawnpolygon = new GMapPolygon(polygonPoints2, "drawnpoly");
            drawnpolygon.Stroke = new Pen(Color.Red, 2);
            drawnpolygon.Fill = Brushes.Transparent;


            Comports.Add(comPort);


            if (!Settings.Instance.ContainsKey("copter_guid"))
                Settings.Instance["copter_guid"] = Guid.NewGuid().ToString();


            if (Settings.Instance.ContainsKey("language") && !string.IsNullOrEmpty(Settings.Instance["language"]))
            {
                changelanguage(CultureInfoEx.GetCultureInfo(Settings.Instance["language"]));
            }

            hud1.doResize();

            serialreaderthread = new Thread(SerialReader)
            {
                IsBackground = true,
                Name = "Main Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            serialreaderthread.Start();

            thisthread = new Thread(mainloop);
            thisthread.Name = "FD Mainloop";
            thisthread.IsBackground = true;
            thisthread.Start();

            updateHome();

            setWPParams();

            updateCMDParams();

            this.myGMAP1.OnPositionChanged += MainMap_OnCurrentPositionChanged;
            this.myGMAP1.OnTileLoadStart += MainMap_OnTileLoadStart;
            this.myGMAP1.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            this.myGMAP1.OnMarkerClick += MainMap_OnMarkerClick;
            this.myGMAP1.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            this.myGMAP1.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            this.myGMAP1.MouseUp += MainMap_MouseUp;
            this.myGMAP1.OnMarkerEnter += MainMap_OnMarkerEnter;
            this.myGMAP1.OnMarkerLeave += MainMap_OnMarkerLeave;
            this.myGMAP1.MapScaleInfoEnabled = false;
            this.myGMAP1.ScalePen = new Pen(Color.Red);
            this.myGMAP1.DisableFocusOnMouseEnter = true;
            this.myGMAP1.ForceDoubleBuffer = false;

        }

        private void LoadConfig()
        {
            try
            {
                log.Info("Loading config");

                Settings.Instance.Load();

                //comPortName = Settings.Instance.ComPort;
            }
            catch (Exception ex)
            {
                log.Error("Bad Config File", ex);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            config(true);
            SaveConfig();

        }

        private void config(bool write)
        {
            if (write)
            {

                //Settings.Instance["TXT_homelat"] = TXT_homelat.EditValue ==null ? "": TXT_homelat.EditValue.ToString();
                //Settings.Instance["TXT_homelng"] = TXT_homelng.EditValue ==null ? "": TXT_homelng.EditValue.ToString();
                //Settings.Instance["TXT_homealt"] = TXT_homealt.EditValue ==null ? "":  TXT_homealt.EditValue.ToString();
                //Settings.Instance["TXT_WPRad"] = TXT_WPRad.EditValue ==null ? "": TXT_WPRad.EditValue.ToString();
                //Settings.Instance["TXT_loiterrad"] =TXT_loiterrad.EditValue ==null ? "":  TXT_loiterrad.EditValue.ToString();
                //Settings.Instance["TXT_DefaultAlt"] = TXT_DefaultAlt.EditValue  ==null ? "": TXT_DefaultAlt.EditValue.ToString();
                //Settings.Instance["CMB_altmode"] = CMB_altmode.EditValue == null ? "" : CMB_altmode.EditValue.ToString();

                Settings.Instance["TXT_homelat"] = TXT_homelat.EditValue.ToString();
                Settings.Instance["TXT_homelng"] = TXT_homelng.EditValue.ToString();
                Settings.Instance["TXT_homealt"] = TXT_homealt.EditValue.ToString();
                Settings.Instance["TXT_WPRad"] = TXT_WPRad.EditValue.ToString();
                Settings.Instance["TXT_loiterrad"] = TXT_loiterrad.EditValue.ToString();
                Settings.Instance["TXT_DefaultAlt"] = TXT_DefaultAlt.EditValue.ToString();
                Settings.Instance["CMB_altmode"] = CMB_altmode.EditValue.ToString();


            }
            else
            {
                if (Settings.Instance["TXT_homelat"] != null)
                    MainForm.comPort.MAV.cs.HomeLocation.Lat = Settings.Instance.GetDouble("TXT_homelat");

                if (Settings.Instance["TXT_homelng"] != null)
                    MainForm.comPort.MAV.cs.HomeLocation.Lng = Settings.Instance.GetDouble("TXT_homelng");

                if (Settings.Instance["TXT_homealt"] != null)
                    MainForm.comPort.MAV.cs.HomeLocation.Alt = Settings.Instance.GetDouble("TXT_homealt");

                foreach (string key in Settings.Instance.Keys)
                {
                    switch (key)
                    {
                        case "TXT_WPRad":
                            TXT_WPRad.EditValue = "" + Settings.Instance[key];
                            break;
                        case "TXT_loiterrad":
                            TXT_loiterrad.EditValue = "" + Settings.Instance[key];
                            break;
                        case "TXT_DefaultAlt":
                            TXT_DefaultAlt.EditValue = "" + Settings.Instance[key];
                            break;
                        case "CMB_altmode":
                            //CMB_altmode.EditValue = "" + Settings.Instance[key];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");

                Settings.Instance.APMFirmware = MainForm.comPort.MAV.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }


        void updateCMDParams()
        {
            cmdParamNames = readCMDXML();

            List<string> cmds = new List<string>();

            foreach (string item in cmdParamNames.Keys)
            {

                cmds.Add(item);
            }

            cmds.Add("UNKNOWN");

            Command.DataSource = cmds;
        }

        Dictionary<string, string[]> readCMDXML()
        {
            Dictionary<string, string[]> cmd = new Dictionary<string, string[]>();

            // do lang stuff here

            string file = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "mavcmd.xml";

            if (!File.Exists(file))
            {
                CustomMessageBox.Show("Missing mavcmd.xml file");
                return cmd;
            }

            using (XmlReader reader = XmlReader.Create(file))
            {
                reader.Read();
                reader.ReadStartElement("CMD");
                if (MainForm.comPort.MAV.cs.firmware == MainForm.Firmwares.ArduPlane ||
                    MainForm.comPort.MAV.cs.firmware == MainForm.Firmwares.Ateryx)
                {
                    reader.ReadToFollowing("APM");
                }
                else if (MainForm.comPort.MAV.cs.firmware == MainForm.Firmwares.ArduRover)
                {
                    reader.ReadToFollowing("APRover");
                }
                else
                {
                    reader.ReadToFollowing("AC2");
                }

                XmlReader inner = reader.ReadSubtree();

                inner.Read();

                inner.MoveToElement();

                inner.Read();

                while (inner.Read())
                {
                    inner.MoveToElement();
                    if (inner.IsStartElement())
                    {
                        string cmdname = inner.Name;
                        string[] cmdarray = new string[7];
                        int b = 0;

                        XmlReader inner2 = inner.ReadSubtree();

                        inner2.Read();

                        while (inner2.Read())
                        {
                            inner2.MoveToElement();
                            if (inner2.IsStartElement())
                            {
                                cmdarray[b] = inner2.ReadString();
                                b++;
                            }
                        }

                        cmd[cmdname] = cmdarray;
                    }
                }
            }

            return cmd;
        }

        void setWPParams()
        {
            try
            {
                log.Info("Loading wp params");

                Hashtable param = new Hashtable((Hashtable)MainForm.comPort.MAV.param);

                if (param["WP_RADIUS"] != null)
                {
                    TXT_WPRad.EditValue = (((double)param["WP_RADIUS"] * CurrentState.multiplierdist)).ToString();
                }
                if (param["WPNAV_RADIUS"] != null)
                {
                    TXT_WPRad.EditValue = (((double)param["WPNAV_RADIUS"] * CurrentState.multiplierdist / 100.0)).ToString();
                }

                log.Info("param WP_RADIUS " + TXT_WPRad.EditValue);

                try
                {
                    TXT_loiterrad.Enabled = false;
                    if (param["LOITER_RADIUS"] != null)
                    {
                        TXT_loiterrad.EditValue = (((double)param["LOITER_RADIUS"] * CurrentState.multiplierdist)).ToString();
                        TXT_loiterrad.Enabled = true;
                    }
                    else if (param["WP_LOITER_RAD"] != null)
                    {
                        TXT_loiterrad.EditValue = (((double)param["WP_LOITER_RAD"] * CurrentState.multiplierdist)).ToString();
                        TXT_loiterrad.Enabled = true;
                    }

                    log.Info("param LOITER_RADIUS " + TXT_loiterrad.EditValue);
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void updateHome()
        {
            quickadd = true;
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { updateHomeText(); });
            }
            else
            {
                updateHomeText();
            }
            quickadd = false;
        }


        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);
        bool serialThread = false;
        DateTime nodatawarning = DateTime.Now;
        private DateTime heatbeatSend = DateTime.Now;
        private void SerialReader()
        {
            if (serialThread == true)
                return;
            serialThread = true;

            SerialThreadrunner.Reset();

            int minbytes = 0;

            int altwarningmax = 0;

            bool armedstatus = false;

            string lastmessagehigh = "";

            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5

                    try
                    {
                        /*
                        if (GCSViews.Terminal.comPort is MAVLinkSerialPort)
                        {
                        }
                        else
                        {
                            if (GCSViews.Terminal.comPort != null && GCSViews.Terminal.comPort.IsOpen)
                                continue;
                        }*/
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // update connect/disconnect button and info stats
                    try
                    {
                        //UpdateConnectIcon();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // 30 seconds interval speech options
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechcustomtime).TotalSeconds > 30 &&
                        (MainForm.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (MainForm.speechEngine.IsReady)
                        {
                            if (Settings.Instance.GetBoolean("speechcustomenabled"))
                            {
                                MainForm.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechcustom"]));
                            }

                            speechcustomtime = DateTime.Now;
                        }

                        // speech for battery alerts
                        //speechbatteryvolt
                        float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                        float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                        if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                            MainForm.comPort.MAV.cs.battery_voltage <= warnvolt &&
                            MainForm.comPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainForm.comPort.MAV.cs.battery_remaining) < warnpercent &&
                                 MainForm.comPort.MAV.cs.battery_voltage >= 5.0 &&
                                 MainForm.comPort.MAV.cs.battery_remaining != 0.0)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync(
                                    Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                    }

                    // speech for airspeed alerts
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechlowspeedtime).TotalSeconds > 10 &&
                        (MainForm.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && MainForm.comPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainForm.comPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainForm.speechEngine.IsReady)
                                {
                                    MainForm.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainForm.comPort.MAV.cs.groundspeed < warngroundspeed)
                            {
                                if (MainForm.speechEngine.IsReady)
                                {
                                    MainForm.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowgroundspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else
                            {
                                speechlowspeedtime = DateTime.Now;
                            }
                        }
                    }

                    // speech altitude warning - message high warning
                    if (speechEnable && speechEngine != null &&
                        (MainForm.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        float warnalt = float.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }
                        try
                        {
                            int todo; // need a reset method
                            altwarningmax = (int)Math.Max(MainForm.comPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && MainForm.comPort.MAV.cs.alt != 0.00 &&
                                (MainForm.comPort.MAV.cs.alt <= warnalt) && MainForm.comPort.MAV.cs.armed)
                            {
                                if (altwarningmax > warnalt)
                                {
                                    if (MainForm.speechEngine.IsReady)
                                        MainForm.speechEngine.SpeakAsync(
                                            Common.speechConversion("" + Settings.Instance["speechalt"]));
                                }
                            }
                        }
                        catch
                        {
                        } // silent fail


                        try
                        {
                            // say the latest high priority message
                            if (MainForm.speechEngine.IsReady &&
                                lastmessagehigh != MainForm.comPort.MAV.cs.messageHigh && MainForm.comPort.MAV.cs.messageHigh != null)
                            {
                                if (!MainForm.comPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainForm.speechEngine.SpeakAsync(MainForm.comPort.MAV.cs.messageHigh);
                                    lastmessagehigh = MainForm.comPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainForm.comPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainForm.comPort.MAV.cs.linkqualitygcs = (ushort)(MainForm.comPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw is no other packets are being read
                            hud1.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainForm.comPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainForm.comPort.logreadmode || comPort.BaseStream.IsOpen)
                        && MainForm.comPort.MAV.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - MainForm.comPort.MAV.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainForm.comPort.MAV.cs.armed && comPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainForm.comPort.MAV.cs.armed;
                        // status just changed to armed
                        if (MainForm.comPort.MAV.cs.armed == true && MainForm.comPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            try
                            {
                                MainForm.comPort.MAV.cs.HomeLocation = new PointLatLngAlt(MainForm.comPort.getWP(0));
                                updateHome();
                                /*
                                if (MyView.current != null && MyView.current.Name == "FlightPlanner")
                                {
                                    // update home if we are on flight data tab
                                    //FlightPlanner.updateHome();
                                }*/
                            }
                            catch
                            {
                                // dont hang this loop
                                this.BeginInvoke(
                                    (MethodInvoker)
                                        delegate
                                        {
                                            CustomMessageBox.Show("Failed to update home location (" +
                                                                  MainForm.comPort.MAV.sysid + ")");
                                        });
                            }
                        }

                        if (speechEnable && speechEngine != null)
                        {
                            if (Settings.Instance.GetBoolean("speecharmenabled"))
                            {
                                string speech = armedstatus ? Settings.Instance["speecharm"] : Settings.Instance["speechdisarm"];
                                if (!string.IsNullOrEmpty(speech))
                                {
                                    MainForm.speechEngine.SpeakAsync(Common.speechConversion(speech));
                                }
                            }
                        }
                    }

                    // send a hb every seconds from gcs to ap
                    if (heatbeatSend.Second != DateTime.Now.Second)
                    {
                        MAVLink.mavlink_heartbeat_t htb = new MAVLink.mavlink_heartbeat_t()
                        {
                            type = (byte)MAVLink.MAV_TYPE.GCS,
                            autopilot = (byte)MAVLink.MAV_AUTOPILOT.INVALID,
                            mavlink_version = 3 // MAVLink.MAVLINK_VERSION
                        };

                        // enumerate each link
                        foreach (var port in Comports)
                        {
                            // there are 3 hb types we can send, mavlink1, mavlink2 signed and unsigned
                            bool sentsigned = false;
                            bool sentmavlink1 = false;
                            bool sentmavlink2 = false;

                            // enumerate each mav
                            foreach (var MAV in port.MAVlist)
                            {
                                try
                                {
                                    // are we talking to a mavlink2 device
                                    if (MAV.mavlinkv2)
                                    {
                                        // is signing enabled
                                        if (MAV.signing)
                                        {
                                            // check if we have already sent
                                            if (sentsigned)
                                                continue;
                                            sentsigned = true;
                                        }
                                        else
                                        {
                                            // check if we have already sent
                                            if (sentmavlink2)
                                                continue;
                                            sentmavlink2 = true;
                                        }
                                    }
                                    else
                                    {
                                        // check if we have already sent
                                        if (sentmavlink1)
                                            continue;
                                        sentmavlink1 = true;
                                    }

                                    port.sendPacket(htb, MAV.sysid, MAV.compid);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    // close the bad port
                                    try
                                    {
                                        port.Close();
                                    }
                                    catch
                                    {
                                    }
                                    // refresh the screen if needed
                                    if (port == MainForm.comPort)
                                    {
                                        // refresh config window if needed
                                        if (MyView.current != null)
                                        {
                                            this.Invoke((MethodInvoker)delegate()
                                            {
                                                if (MyView.current.Name == "HWConfig")
                                                    MyView.ShowScreen("HWConfig");
                                                if (MyView.current.Name == "SWConfig")
                                                    MyView.ShowScreen("SWConfig");
                                            });
                                        }
                                    }
                                }
                            }
                        }

                        heatbeatSend = DateTime.Now;
                    }

                    // if not connected or busy, sleep and loop
                    if (!comPort.BaseStream.IsOpen || comPort.giveComport == true)
                    {
                        if (!comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    comPort = port;
                                    break;
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in Comports.ToArray())
                    {
                        if (!port.BaseStream.IsOpen)
                        {
                            // skip primary interface
                            if (port == comPort)
                                continue;

                            // modify array and drop out
                            Comports.Remove(port);
                            break;
                        }

                        while (port.BaseStream.IsOpen && port.BaseStream.BytesToRead > minbytes &&
                               port.giveComport == false && serialThread)
                        {
                            try
                            {
                                port.readPacket();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                        // update currentstate of sysids on the port
                        foreach (var MAV in port.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, port, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                    try
                    {
                        comPort.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }

            Console.WriteLine("SerialReader Done");
            SerialThreadrunner.Set();
        }

        Thread thisthread;
        public static bool speechEnable = false;
        MissionPlanner.Controls.MainSwitcher MyView;
        public static MainForm instance = null;
        static MAVLinkInterface _comPort = new MAVLinkInterface();
        public void changelanguage(CultureInfo ci)
        {
            log.Info("change lang to " + ci.ToString() + " current " + Thread.CurrentThread.CurrentUICulture.ToString());

            if (ci != null && !Thread.CurrentThread.CurrentUICulture.Equals(ci))
            {
                Thread.CurrentThread.CurrentUICulture = ci;
                Settings.Instance["language"] = ci.Name;
                //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                HashSet<Control> views = new HashSet<Control> { this };

                foreach (Control view in MyView.Controls)
                    views.Add(view);

                foreach (Control view in views)
                {
                    if (view != null)
                    {
                        ComponentResourceManager rm = new ComponentResourceManager(view.GetType());
                        foreach (Control ctrl in view.Controls)
                        {
                            rm.ApplyResource(ctrl);
                        }
                        rm.ApplyResources(view, "$this");
                    }
                }
            }
        }

        public static bool threadrun;
        DateTime lastscreenupdate = DateTime.Now;
        object updateBindingSourcelock = new object();
        volatile int updateBindingSourcecount;
        string updateBindingSourceThreadName = "";
        private void updateBindingSource()
        {
            //  run at 25 hz.
            if (lastscreenupdate.AddMilliseconds(40) < DateTime.Now)
            {
                // this is an attempt to prevent an invoke queue on the binding update on slow machines
                if (updateBindingSourcecount > 0)
                    return;

                lock (updateBindingSourcelock)
                {
                    updateBindingSourcecount++;
                    updateBindingSourceThreadName = Thread.CurrentThread.Name;
                }

                this.BeginInvokeIfRequired((MethodInvoker)delegate
                {
                    updateBindingSourceWork();

                    lock (updateBindingSourcelock)
                    {
                        updateBindingSourcecount--;
                    }
                });
            }
        }
        private void updateBindingSourceWork()
        {
            try
            {
                if (this.Visible)
                {
                    //Console.Write("bindingSource1 ");
                    //MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSource1);
                    //Console.Write("bindingSourceHud ");
                    MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                    //Console.WriteLine("DONE ");

                    /*
                    if (tabControlactions.SelectedTab == tabStatus)
                    {
                        MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceStatusTab);
                    }
                    else if (tabControlactions.SelectedTab == tabQuick)
                    {
                        MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceQuickTab);
                    }
                    else if (tabControlactions.SelectedTab == tabGauges)
                    {
                        MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }
                    else if (tabControlactions.SelectedTab == tabPagePreFlight)
                    {
                        MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }*/
                }
                else
                {
                    //Console.WriteLine("Null Binding");
                    MainForm.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                }
                lastscreenupdate = DateTime.Now;
            }
            catch
            {
            }
        }
        PropertyInfo list1item;
        PropertyInfo list2item;
        PropertyInfo list3item;
        PropertyInfo list4item;
        PropertyInfo list5item;
        PropertyInfo list6item;
        PropertyInfo list7item;
        PropertyInfo list8item;
        PropertyInfo list9item;
        PropertyInfo list10item;

        int tickStart;
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

        GMapOverlay polygons;
        GMapOverlay routes;
        GMapRoute route;
        List<PointLatLng> trackPoints = new List<PointLatLng>();
        private bool CameraOverlap;
        private void mainloop()
        {
            threadrun = true;
            EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);

            DateTime tracklast = DateTime.Now.AddSeconds(0);

            DateTime tunning = DateTime.Now.AddSeconds(0);

            DateTime mapupdate = DateTime.Now.AddSeconds(0);

            DateTime vidrec = DateTime.Now.AddSeconds(0);

            DateTime waypoints = DateTime.Now.AddSeconds(0);

            DateTime updatescreen = DateTime.Now;

            DateTime tsreal = DateTime.Now;

            while (!IsHandleCreated)
                Thread.Sleep(100);

            while (threadrun)
            {
                if (MainForm.comPort.giveComport)
                {
                    Thread.Sleep(50);
                    updateBindingSource();
                    continue;
                }

                if (!MainForm.comPort.logreadmode)
                    Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

                /*
                try
                {
                    if (aviwriter != null && vidrec.AddMilliseconds(100) <= DateTime.Now)
                    {
                        vidrec = DateTime.Now;

                        hud1.streamjpgenable = true;

                        //aviwriter.avi_start("test.avi");
                        // add a frame
                        aviwriter.avi_add(hud1.streamjpg.ToArray(), (uint)hud1.streamjpg.Length);
                        // write header - so even partial files will play
                        aviwriter.avi_end(hud1.Width, hud1.Height, 10);
                    }
                }
                catch
                {
                    log.Error("Failed to write avi");
                }
                 * */

                // log playback
                if (MainForm.comPort.logreadmode && MainForm.comPort.logplaybackfile != null)
                {
                    if (MainForm.comPort.BaseStream.IsOpen)
                    {
                        MainForm.comPort.logreadmode = false;
                        try
                        {
                            MainForm.comPort.logplaybackfile.Close();
                        }
                        catch
                        {
                            log.Error("Failed to close logfile");
                        }
                        MainForm.comPort.logplaybackfile = null;
                    }


                    //Console.WriteLine(DateTime.Now.Millisecond);

                    if (updatescreen.AddMilliseconds(300) < DateTime.Now)
                    {
                        try
                        {
                            //updatePlayPauseButton(true);
                            //updateLogPlayPosition();
                        }
                        catch
                        {
                            log.Error("Failed to update log playback pos");
                        }
                        updatescreen = DateTime.Now;
                    }

                    //Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    DateTime logplayback = MainForm.comPort.lastlogread;
                    try
                    {
                        if (!MainForm.comPort.giveComport)
                            MainForm.comPort.readPacket();

                        // update currentstate of sysids on the port
                        foreach (var MAV in MainForm.comPort.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, MainForm.comPort, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                    catch
                    {
                        log.Error("Failed to read log packet");
                    }

                    double act = (MainForm.comPort.lastlogread - logplayback).TotalMilliseconds;

                    if (act > 9999 || act < 0)
                        act = 0;
                    /*
                    double ts = 0;
                    if (LogPlayBackSpeed == 0)
                        LogPlayBackSpeed = 0.01;
                    try
                    {
                        ts = Math.Min((act / LogPlayBackSpeed), 1000);
                    }
                    catch
                    {
                    }

                    if (LogPlayBackSpeed >= 4 && MainForm.speechEnable)
                        MainForm.speechEngine.SpeakAsyncCancelAll();
                    

                    double timetook = (DateTime.Now - tsreal).TotalMilliseconds;
                    if (timetook != 0)
                    {
                        //Console.WriteLine("took: " + timetook + "=" + taketime + " " + (taketime - timetook) + " " + ts);
                        //Console.WriteLine(MainForm.comPort.lastlogread.Second + " " + DateTime.Now.Second + " " + (MainForm.comPort.lastlogread.Second - DateTime.Now.Second));
                        //if ((taketime - timetook) < 0)
                        {
                            timeerror += (taketime - timetook);
                            if (ts != 0)
                            {
                                ts += timeerror;
                                timeerror = 0;
                            }
                        }
                        if (Math.Abs(ts) > 1000)
                            ts = 1000;
                    }

                    taketime = ts;
                    tsreal = DateTime.Now;

                    if (ts > 0 && ts < 1000)
                        Thread.Sleep((int)ts);

                    tracklast = tracklast.AddMilliseconds(ts - act);
                    tunning = tunning.AddMilliseconds(ts - act);

                    if (tracklast.Month != DateTime.Now.Month)
                    {
                        tracklast = DateTime.Now;
                        tunning = DateTime.Now;
                    }

                    try
                    {
                        if (MainForm.comPort.logplaybackfile != null &&
                            MainForm.comPort.logplaybackfile.BaseStream.Position ==
                            MainForm.comPort.logplaybackfile.BaseStream.Length)
                        {
                            MainForm.comPort.logreadmode = false;
                        }
                    }
                    catch
                    {
                        MainForm.comPort.logreadmode = false;
                    }*/
                }
                else
                {
                    // ensure we know to stop
                    /*
                    if (MainForm.comPort.logreadmode)
                        MainForm.comPort.logreadmode = false;
                    updatePlayPauseButton(false);

                    if (!playingLog && MainForm.comPort.logplaybackfile != null)
                    {
                        continue;
                    }*/
                }

                try
                {
                    //CheckAndBindPreFlightData();
                    //Console.WriteLine(DateTime.Now.Millisecond);
                    //int fixme;
                    updateBindingSource();
                    // Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    // battery warning.
                    float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                    float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                    if (MainForm.comPort.MAV.cs.battery_voltage <= warnvolt)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else if ((MainForm.comPort.MAV.cs.battery_remaining) < warnpercent)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else
                    {
                        hud1.lowvoltagealert = false;
                    }

                    /*
                    // update opengltest
                    if (OpenGLtest.instance != null)
                    {
                        OpenGLtest.instance.rpy = new Vector3(MainForm.comPort.MAV.cs.roll, MainForm.comPort.MAV.cs.pitch,
                            MainForm.comPort.MAV.cs.yaw);
                        OpenGLtest.instance.LocationCenter = new PointLatLngAlt(MainForm.comPort.MAV.cs.lat,
                            MainForm.comPort.MAV.cs.lng, MainForm.comPort.MAV.cs.alt, "here");
                    }

                    // update opengltest2
                    if (OpenGLtest2.instance != null)
                    {
                        OpenGLtest2.instance.rpy = new Vector3(MainForm.comPort.MAV.cs.roll, MainForm.comPort.MAV.cs.pitch,
                            MainForm.comPort.MAV.cs.yaw);
                        OpenGLtest2.instance.LocationCenter = new PointLatLngAlt(MainForm.comPort.MAV.cs.lat,
                            MainForm.comPort.MAV.cs.lng, MainForm.comPort.MAV.cs.alt, "here");
                    }*/

                    // update vario info
                    Vario.SetValue(MainForm.comPort.MAV.cs.climbrate);

                    // udpate tunning tab
                    if (tunning.AddMilliseconds(50) < DateTime.Now && false)
                    {
                        double time = (Environment.TickCount - tickStart) / 1000.0;
                        if (list1item != null)
                            list1.Add(time, ConvertToDouble(list1item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list2item != null)
                            list2.Add(time, ConvertToDouble(list2item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list3item != null)
                            list3.Add(time, ConvertToDouble(list3item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list4item != null)
                            list4.Add(time, ConvertToDouble(list4item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list5item != null)
                            list5.Add(time, ConvertToDouble(list5item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list6item != null)
                            list6.Add(time, ConvertToDouble(list6item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list7item != null)
                            list7.Add(time, ConvertToDouble(list7item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list8item != null)
                            list8.Add(time, ConvertToDouble(list8item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list9item != null)
                            list9.Add(time, ConvertToDouble(list9item.GetValue(MainForm.comPort.MAV.cs, null)));
                        if (list10item != null)
                            list10.Add(time, ConvertToDouble(list10item.GetValue(MainForm.comPort.MAV.cs, null)));
                    }

                    // update map

                    if (tracklast.AddSeconds(1.2) < DateTime.Now)
                    {
                        /*
                        // show disable joystick button
                        if (MainForm.joystick != null && MainForm.joystick.enabled)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                but_disablejoystick.Visible = true;
                            });
                        }*/

                        if (Settings.Instance.GetBoolean("CHK_maprotation"))
                        {
                            // dont holdinvalidation here
                            //setMapBearing();
                        }

                        if (route == null)
                        {
                            route = new GMapRoute(trackPoints, "track");
                            routes.Routes.Add(route);
                        }

                        PointLatLng currentloc = new PointLatLng(MainForm.comPort.MAV.cs.lat, MainForm.comPort.MAV.cs.lng);

                        myGMAP1.HoldInvalidation = true;

                        int numTrackLength = Settings.Instance.GetInt32("NUM_tracklength");
                        // maintain route history length
                        if (route.Points.Count > numTrackLength)
                        {
                            route.Points.RemoveRange(0,
                                route.Points.Count - numTrackLength);
                        }
                        // add new route point
                        if (MainForm.comPort.MAV.cs.lat != 0 && MainForm.comPort.MAV.cs.lng != 0)
                        {
                            route.Points.Add(currentloc);
                        }

                        myGMAP1.UpdateRouteLocalPosition(route);

                        // update programed wp course
                        if (waypoints.AddSeconds(5) < DateTime.Now)
                        {
                            //Console.WriteLine("Doing FD WP's");
                            updateClearMissionRouteMarkers();

                            float dist = 0;
                            float travdist = 0;
                            // distanceBar1.ClearWPDist();
                            MAVLink.mavlink_mission_item_t lastplla = new MAVLink.mavlink_mission_item_t();
                            MAVLink.mavlink_mission_item_t home = new MAVLink.mavlink_mission_item_t();

                            foreach (MAVLink.mavlink_mission_item_t plla in MainForm.comPort.MAV.wps.Values)
                            {
                                if (plla.x == 0 || plla.y == 0)
                                    continue;

                                if (plla.command == (ushort)MAVLink.MAV_CMD.DO_SET_ROI)
                                {
                                    addpolygonmarkerred(plla.seq.ToString(), plla.y, plla.x, (int)plla.z, Color.Red,
                                        routes);
                                    continue;
                                }

                                string tag = plla.seq.ToString();
                                if (plla.seq == 0 && plla.current != 2)
                                {
                                    tag = "Home";
                                    home = plla;
                                }
                                if (plla.current == 2)
                                {
                                    continue;
                                }

                                if (lastplla.command == 0)
                                    lastplla = plla;

                                try
                                {
                                    dist =
                                        (float)
                                            new PointLatLngAlt(plla.x, plla.y).GetDistance(new PointLatLngAlt(
                                                lastplla.x, lastplla.y));

                                    //distanceBar1.AddWPDist(dist);

                                    if (plla.seq <= MainForm.comPort.MAV.cs.wpno)
                                    {
                                        travdist += dist;
                                    }

                                    lastplla = plla;
                                }
                                catch
                                {
                                }

                                //addpolygonmarker(tag, plla.y, plla.x, (int)plla.z, Color.White, polygons);
                            }

                            try
                            {
                                //dist = (float)new PointLatLngAlt(home.x, home.y).GetDistance(new PointLatLngAlt(lastplla.x, lastplla.y));
                                // distanceBar1.AddWPDist(dist);
                            }
                            catch
                            {
                            }

                            travdist -= MainForm.comPort.MAV.cs.wp_dist;

                            // if (MainForm.comPort.MAV.cs.mode.ToUpper() == "AUTO")
                            // distanceBar1.traveleddist = travdist;

                            //RegeneratePolygon();

                            // update rally points

                            rallypointoverlay.Markers.Clear();

                            foreach (var mark in MainForm.comPort.MAV.rallypoints.Values)
                            {
                                rallypointoverlay.Markers.Add(new GMapMarkerRallyPt(mark));
                            }

                            // optional on Flight data
                            /*
                            if (MainForm.ShowAirports)
                            {
                                // airports
                                foreach (var item in Airports.getAirports(gMapControl1.Position))
                                {
                                    rallypointoverlay.Markers.Add(new GMapMarkerAirport(item)
                                    {
                                        ToolTipText = item.Tag,
                                        ToolTipMode = MarkerTooltipMode.OnMouseOver
                                    });
                                }
                            }*/
                            waypoints = DateTime.Now;
                        }

                        updateClearRoutesMarkers();

                        // add this after the mav icons are drawn
                        if (MainForm.comPort.MAV.cs.MovingBase != null)
                        {
                            addMissionRouteMarker(new GMarkerGoogle(currentloc, GMarkerGoogleType.blue_dot)
                            {
                                Position = MainForm.comPort.MAV.cs.MovingBase,
                                ToolTipText = "Moving Base",
                                ToolTipMode = MarkerTooltipMode.OnMouseOver
                            });
                        }

                        // add gimbal point center
                        try
                        {
                            if (MainForm.comPort.MAV.param.ContainsKey("MNT_STAB_TILT"))
                            {
                                float temp1 = (float)MainForm.comPort.MAV.param["MNT_STAB_TILT"];
                                float temp2 = (float)MainForm.comPort.MAV.param["MNT_STAB_ROLL"];

                                float temp3 = (float)MainForm.comPort.MAV.param["MNT_TYPE"];

                                if (MainForm.comPort.MAV.param.ContainsKey("MNT_STAB_PAN") &&
                                    // (float)MainForm.comPort.MAV.param["MNT_STAB_PAN"] == 1 &&
                                    ((float)MainForm.comPort.MAV.param["MNT_STAB_TILT"] == 1 &&
                                      (float)MainForm.comPort.MAV.param["MNT_STAB_ROLL"] == 0) ||
                                     (float)MainForm.comPort.MAV.param["MNT_TYPE"] == 4) // storm driver
                                {
                                    var marker = GimbalPoint.ProjectPoint();

                                    if (marker != PointLatLngAlt.Zero)
                                    {
                                        MainForm.comPort.MAV.cs.GimbalPoint = marker;

                                        addMissionRouteMarker(new GMarkerGoogle(marker, GMarkerGoogleType.blue_dot)
                                        {
                                            ToolTipText = "Camera Target\n" + marker,
                                            ToolTipMode = MarkerTooltipMode.OnMouseOver
                                        });
                                    }
                                }
                            }


                            // cleanup old - no markers where added, so remove all old 
                            //if (MainForm.comPort.MAV.camerapoints.Count == 0)
                            //    photosoverlay.Markers.Clear();

                            var min_interval = 0.0;
                            if (MainForm.comPort.MAV.param.ContainsKey("CAM_MIN_INTERVAL"))
                                min_interval = MainForm.comPort.MAV.param["CAM_MIN_INTERVAL"].Value / 1000.0;

                            // set fov's based on last grid calc
                            if (Settings.Instance["camera_fovh"] != null)
                            {
                                GMapMarkerPhoto.hfov = Settings.Instance.GetDouble("camera_fovh");
                                GMapMarkerPhoto.vfov = Settings.Instance.GetDouble("camera_fovv");
                            }

                            // add new - populate camera_feedback to map
                            /*
                           double oldtime = double.MinValue;

                           
                           foreach (var mark in MainForm.comPort.MAV.camerapoints.ToArray())
                           {
                               var timesincelastshot = (mark.time_usec / 1000.0) / 1000.0 - oldtime;
                               MainForm.comPort.MAV.cs.timesincelastshot = timesincelastshot;
                               bool contains = photosoverlay.Markers.Any(p => p.Tag.Equals(mark.time_usec));
                               if (!contains)
                               {
                                   if (timesincelastshot < min_interval)
                                       addMissionPhotoMarker(new GMapMarkerPhoto(mark, true));
                                   else
                                       addMissionPhotoMarker(new GMapMarkerPhoto(mark, false));
                               }
                               oldtime = (mark.time_usec / 1000.0) / 1000.0;
                           }

                           // age current
                           int camcount = MainForm.comPort.MAV.camerapoints.Count;
                           int a = 0;
                           foreach (var mark in photosoverlay.Markers)
                           {
                               if (mark is GMapMarkerPhoto)
                               {
                                   if (CameraOverlap)
                                   {
                                       var marker = ((GMapMarkerPhoto)mark);
                                       // abandon roll higher than 25 degrees
                                       if (Math.Abs(marker.Roll) < 25)
                                       {
                                           MainForm.comPort.MAV.GMapMarkerOverlapCount.Add(
                                               ((GMapMarkerPhoto)mark).footprintpoly);
                                       }
                                   }
                                   if (a < (camcount - 4))
                                       ((GMapMarkerPhoto)mark).drawfootprint = false;
                               }
                               a++;
                           }

                           if (CameraOverlap)
                           {
                               if (!kmlpolygons.Markers.Contains(MainForm.comPort.MAV.GMapMarkerOverlapCount) &&
                                   camcount > 0)
                               {
                                   kmlpolygons.Markers.Clear();
                                   kmlpolygons.Markers.Add(MainForm.comPort.MAV.GMapMarkerOverlapCount);
                               }
                           }
                           else if (kmlpolygons.Markers.Contains(MainForm.comPort.MAV.GMapMarkerOverlapCount))
                           {
                               kmlpolygons.Markers.Clear();
                           }
                          */
                        }
                        catch
                        {
                        }

                        lock (MainForm.instance.adsblock)
                        {
                            // cleanup old
                            for (int a = (routes.Markers.Count - 1); a >= 0; a--)
                            {
                                if (routes.Markers[a].ToolTipText != null &&
                                    routes.Markers[a].ToolTipText.Contains("ICAO"))
                                {
                                    routes.Markers.RemoveAt(a);
                                }
                            }

                            foreach (adsb.PointLatLngAltHdg plla in MainForm.instance.adsbPlanes.Values)
                            {
                                // 30 seconds history
                                if (((DateTime)plla.Time) > DateTime.Now.AddSeconds(-30))
                                {
                                    var adsbplane = new GMapMarkerADSBPlane(plla, plla.Heading)
                                    {
                                        ToolTipText = "ICAO: " + plla.Tag + " " + plla.Alt.ToString("0"),
                                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                                    };

                                    switch (plla.ThreatLevel)
                                    {
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.NONE:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Green;
                                            break;
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.LOW:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Orange;
                                            break;
                                        case MAVLink.MAV_COLLISION_THREAT_LEVEL.HIGH:
                                            adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Red;
                                            break;
                                    }

                                    addMissionRouteMarker(adsbplane);
                                }
                            }
                        }


                        if (route.Points.Count > 0)
                        {
                            // add primary route icon

                            // draw guide mode point for only main mav
                            if (MainForm.comPort.MAV.cs.mode.ToLower() == "guided" && MainForm.comPort.MAV.GuidedMode.x != 0)
                            {
                                addpolygonmarker("Guided Mode", MainForm.comPort.MAV.GuidedMode.y,
                                    MainForm.comPort.MAV.GuidedMode.x, (int)MainForm.comPort.MAV.GuidedMode.z, Color.Blue,
                                    routes);
                            }

                            // draw all icons for all connected mavs
                            foreach (var port in MainForm.Comports)
                            {
                                // draw the mavs seen on this port
                                foreach (var MAV in port.MAVlist)
                                {
                                    var marker = Common.getMAVMarker(MAV);

                                    addMissionRouteMarker(marker);
                                }
                            }

                            if (route.Points[route.Points.Count - 1].Lat != 0 &&
                                (mapupdate.AddSeconds(3) < DateTime.Now) && false)
                            {
                                updateMapPosition(currentloc);
                                mapupdate = DateTime.Now;
                            }

                            if (route.Points.Count == 1 && myGMAP1.Zoom == 3) // 3 is the default load zoom
                            {
                                updateMapPosition(currentloc);
                                updateMapZoom(17);
                            }
                        }

                        myGMAP1.HoldInvalidation = false;

                        if (myGMAP1.Visible)
                        {
                            myGMAP1.Invalidate();
                        }

                        tracklast = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Tracking.AddException(ex);
                    Console.WriteLine("FD Main loop exception " + ex);
                }
            }
            Console.WriteLine("FD Main loop exit");
        }
        private void updateClearRoutesMarkers()
        {
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Clear();
            });
        }
        void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            if (routes == null)
                return;

            foreach (GMapMarker m in polygons.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = polygonPoints.Count;
                    polygonPoints.Add(m.Position);
                }
            }

            if (polygonPoints.Count < 2)
                return;

            GMapRoute homeroute = new GMapRoute("homepath");
            homeroute.Stroke = new Pen(Color.Yellow, 2);
            homeroute.Stroke.DashStyle = DashStyle.Dash;
            // add first point past home
            homeroute.Points.Add(polygonPoints[1]);
            // add home location
            homeroute.Points.Add(polygonPoints[0]);
            // add last point
            homeroute.Points.Add(polygonPoints[polygonPoints.Count - 1]);

            GMapRoute wppath = new GMapRoute("wp path");
            wppath.Stroke = new Pen(Color.Yellow, 4);
            wppath.Stroke.DashStyle = DashStyle.Custom;

            for (int a = 1; a < polygonPoints.Count; a++)
            {
                wppath.Points.Add(polygonPoints[a]);
            }

            Invoke((MethodInvoker)delegate
            {
                polygons.Routes.Add(homeroute);
                polygons.Routes.Add(wppath);
            });
        }
        /*
        private void addMissionPhotoMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                photosoverlay.Markers.Add(marker);
            });
        }
        */
        internal object adsblock = new object();
        private void addMissionRouteMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Add(marker);
            });
        }
        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>();
        private void updateMapZoom(int zoom)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    myGMAP1.Zoom = zoom;
                }
                catch
                {
                }
            });
        }
        private void updateClearMissionRouteMarkers()
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                polygons.Routes.Clear();
                polygons.Markers.Clear();
                routes.Markers.Clear();
            });
        }
        DateTime lastmapposchange = DateTime.MinValue;
        private void updateMapPosition(PointLatLng currentloc)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (lastmapposchange.Second != DateTime.Now.Second)
                    {
                        this.myGMAP1.Position = currentloc;
                        lastmapposchange = DateTime.Now;
                    }
                    //hud1.Refresh();
                }
                catch
                {
                }
            });
        }
        private void addpolygonmarker(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.green);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    try
                    {
                        mBorders.wprad =
                            (int)(float.Parse(TXT_WPRad.EditValue.ToString()) / CurrentState.multiplierdist);
                    }
                    catch
                    {
                    }
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                Invoke((MethodInvoker)delegate
                {
                    overlay.Markers.Add(m);
                    overlay.Markers.Add(mBorders);
                });
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
            }
        }
        private void addpolygonmarkerred(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                Invoke((MethodInvoker)delegate
                {
                    overlay.Markers.Add(m);
                    overlay.Markers.Add(mBorders);
                });
            }
            catch (Exception)
            {
            }
        }

        private double ConvertToDouble(object input)
        {
            if (input.GetType() == typeof(float))
            {
                return (float)input;
            }
            if (input.GetType() == typeof(double))
            {
                return (double)input;
            }
            if (input.GetType() == typeof(ulong))
            {
                return (ulong)input;
            }
            if (input.GetType() == typeof(long))
            {
                return (long)input;
            }
            if (input.GetType() == typeof(int))
            {
                return (int)input;
            }
            if (input.GetType() == typeof(uint))
            {
                return (uint)input;
            }
            if (input.GetType() == typeof(short))
            {
                return (short)input;
            }
            if (input.GetType() == typeof(ushort))
            {
                return (ushort)input;
            }
            if (input.GetType() == typeof(bool))
            {
                return (bool)input ? 1 : 0;
            }
            if (input.GetType() == typeof(string))
            {
                double ans = 0;
                if (double.TryParse((string)input, out ans))
                {
                    return ans;
                }
            }

            if (input == null)
                throw new Exception("Bad Type Null");
            else
                throw new Exception("Bad Type " + input.GetType().ToString());
        }
        void comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainForm.comPort.MAV.sysid);

            HUD.Custom.src = MainForm.comPort.MAV.cs;



            // when uploading a firmware we dont want to reload this screen.


            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    instance.MyView.Reload();
                });
            }
            else
            {
                instance.MyView.Reload();
            }
        }
        public static MAVLinkInterface comPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if (_comPort == value)
                    return;
                _comPort = value;
                _comPort.MavChanged -= instance.comPort_MavChanged;
                _comPort.MavChanged += instance.comPort_MavChanged;
                instance.comPort_MavChanged(null, null);
            }
        }


        DateTime connecttime = DateTime.Now;
        public void CheckBatteryShow()
        {
            // ensure battery display is on - also set in hud if current is updated
            if (MainForm.comPort.MAV.param.ContainsKey("BATT_MONITOR") &&
                (float)MainForm.comPort.MAV.param["BATT_MONITOR"] != 0)
            {
                hud1.batteryon = true;
            }
            else
            {
                hud1.batteryon = false;
            }
        }
        public static bool MONO = false;
        public static Speech speechEngine = null;
        public Hashtable adsbPlanes = new Hashtable();
        public enum Firmwares
        {
            ArduPlane,
            ArduCopter2,
            ArduRover,
            Ateryx,
            ArduTracker,
            Gymbal,
            PX4
        }

        public void doConnect(MAVLinkInterface comPort, string portname, string baud)
        {

            bool skipconnectcheck = false;

            comPort.MAV.cs.ResetInternals();

            //cleanup any log being played
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {

                if (portname.Equals("TCP"))
                {


                    // do autoscan
                    comPort.BaseStream = new TcpSerial();
                    // set port, then options
                    comPort.BaseStream.PortName = portname;
                }
                else
                {
                    comPort.BaseStream = new SerialPort();
                    comPort.BaseStream.PortName = portname;
                }



                try
                {
                    comPort.BaseStream.BaudRate = int.Parse(baud);
                }
                catch (Exception exp)
                {
                    log.Error(exp);
                }

                // prevent serialreader from doing anything
                comPort.giveComport = true;

                log.Info("About to do dtr if needed");
                // reset on connect logic.
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }

                comPort.giveComport = false;

                // setup to record new logs
                try
                {
                    Directory.CreateDirectory(Settings.Instance.LogDir);
                    comPort.logfile =
                        new BufferedStream(
                            File.Open(
                                Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".tlog", FileMode.CreateNew,
                                FileAccess.ReadWrite, FileShare.None));

                    comPort.rawlogfile =
                        new BufferedStream(
                            File.Open(
                                Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".rlog", FileMode.CreateNew,
                                FileAccess.ReadWrite, FileShare.None));

                    log.Info("creating logfile " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".tlog");
                }
                catch (Exception exp2)
                {
                    log.Error(exp2);
                    CustomMessageBox.Show(Strings.Failclog);
                } // soft fail

                // reset connect time - for timeout functions
                connecttime = DateTime.Now;

                // do the connect
                comPort.Open(false, skipconnectcheck);

                if (!comPort.BaseStream.IsOpen)
                {
                    log.Info("comport is closed. existing connect");
                    try
                    {
                        comPort.Close();
                    }
                    catch
                    {
                    }
                    return;
                }

                // get all the params
                foreach (var mavstate in comPort.MAVlist)
                {
                    comPort.sysidcurrent = mavstate.sysid;
                    comPort.compidcurrent = mavstate.compid;
                    comPort.getParamList();
                }

                // set to first seen
                comPort.sysidcurrent = comPort.MAVlist.First().sysid;
                comPort.compidcurrent = comPort.MAVlist.First().compid;


                // check for newer firmware
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.MAV.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.MAV.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                        Strings.NewFirmwareA + item.name + Strings.Pleaseup);
                                    break;
                                }

                                // check the first hit only
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                CheckBatteryShow();

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Connect", comPort.MAV.cs.firmware.ToString(),
                    comPort.MAV.param.Count.ToString());
                MissionPlanner.Utilities.Tracking.AddTiming("Connect", "Connect Time",
                    (DateTime.Now - connecttime).TotalMilliseconds, "");

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Baud", comPort.BaseStream.BaudRate.ToString(), "");

                // save the baudrate for this port
                //Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] = _connectionControl.CMB_baudrate.Text;

                //this.Text = titlebar + " " + comPort.MAV.VersionString;

                // refresh config window if needed

                // load wps on connect option.
                if (Settings.Instance.GetBoolean("loadwpsonconnect") == true)
                {
                    // only do it if we are connected.
                    if (comPort.BaseStream.IsOpen)
                    {
                        //MenuFlightPlanner_Click(null, null);
                        //FlightPlanner.BUT_read_Click(null, null);
                    }
                }

                // get any rallypoints
                if (MainForm.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(MainForm.comPort.MAV.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    //FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                    double maxdist = 0;

                    foreach (var rally in comPort.MAV.rallypoints)
                    {
                        foreach (var rally1 in comPort.MAV.rallypoints)
                        {
                            var pnt1 = new PointLatLngAlt(rally.Value.lat / 10000000.0f, rally.Value.lng / 10000000.0f);
                            var pnt2 = new PointLatLngAlt(rally1.Value.lat / 10000000.0f, rally1.Value.lng / 10000000.0f);

                            var dist = pnt1.GetDistance(pnt2);

                            maxdist = Math.Max(maxdist, dist);
                        }
                    }

                    if (comPort.MAV.param.ContainsKey("RALLY_LIMIT_KM") &&
                        (maxdist / 1000.0) > (float)comPort.MAV.param["RALLY_LIMIT_KM"])
                    {
                        CustomMessageBox.Show(Strings.Warningrallypointdistance + " " +
                                              (maxdist / 1000.0).ToString("0.00") + " > " +
                                              (float)comPort.MAV.param["RALLY_LIMIT_KM"]);
                    }
                }

                // set connected icon
                //this.MenuConnect.Image = displayicons.disconnect;
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {
                    //_connectionControl.IsConnected(false);
                    //UpdateConnectIcon();
                    comPort.Close();
                }
                catch (Exception ex2)
                {
                    log.Warn(ex2);
                }
                CustomMessageBox.Show("Can not establish a connection\n\n" + ex.Message);
                return;
            }
        }

        private void btnConnect_ItemClick(object sender, ItemClickEventArgs e)
        {



            doConnect(comPort, this.cboProtocolType.EditValue.ToString(), this.cboPort.EditValue.ToString());



        }



        private void btnArm_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!MainForm.comPort.BaseStream.IsOpen)
                return;

            // arm the MAV
            try
            {
                if (MainForm.comPort.MAV.cs.armed)
                    if (CustomMessageBox.Show("Are you sure you want to Disarm?", "Disarm?", MessageBoxButtons.YesNo) !=
                        DialogResult.Yes)
                        return;

                bool ans = MainForm.comPort.doARM(!MainForm.comPort.MAV.cs.armed);
                if (ans == false)
                    CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        internal PointLatLng MouseDownStart;

        private void goHereToolStripMenuItem_Click(object sender, EventArgs e)
        {



            if (!MainForm.comPort.BaseStream.IsOpen)
            {
                CustomMessageBox.Show(Strings.PleaseConnect, Strings.ERROR);
                return;
            }

            if (MainForm.comPort.MAV.GuidedMode.z == 0)
            {
                flyToHereAltToolStripMenuItem_Click(null, null);

                if (MainForm.comPort.MAV.GuidedMode.z == 0)
                    return;
            }

            if (MouseDownStart.Lat == 0 || MouseDownStart.Lng == 0)
            {
                CustomMessageBox.Show(Strings.BadCoords, Strings.ERROR);
                return;
            }

            Locationwp gotohere = new Locationwp();

            gotohere.id = (ushort)MAVLink.MAV_CMD.WAYPOINT;
            gotohere.alt = MainForm.comPort.MAV.GuidedMode.z; // back to m
            gotohere.lat = (MouseDownStart.Lat);
            gotohere.lng = (MouseDownStart.Lng);

            try
            {
                MainForm.comPort.setGuidedModeWP(gotohere);
            }
            catch (Exception ex)
            {
                MainForm.comPort.giveComport = false;
                CustomMessageBox.Show(Strings.CommandFailed + ex.Message, Strings.ERROR);
            }



        }

        private void flyToHereAltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string alt = "100";

            if (MainForm.comPort.MAV.cs.firmware == MainForm.Firmwares.ArduCopter2)
            {
                alt = (10 * CurrentState.multiplierdist).ToString("0");
            }
            else
            {
                alt = (100 * CurrentState.multiplierdist).ToString("0");
            }

            if (Settings.Instance.ContainsKey("guided_alt"))
                alt = Settings.Instance["guided_alt"];

            if (DialogResult.Cancel == InputBox.Show("Enter Alt", "Enter Guided Mode Alt", ref alt))
                return;

            Settings.Instance["guided_alt"] = alt;

            int intalt = (int)(100 * CurrentState.multiplierdist);
            if (!int.TryParse(alt, out intalt))
            {
                CustomMessageBox.Show("Bad Alt");
                return;
            }

            MainForm.comPort.MAV.GuidedMode.z = intalt / CurrentState.multiplierdist;

            if (MainForm.comPort.MAV.cs.mode == "Guided")
            {
                MainForm.comPort.setGuidedModeWP(new Locationwp
                {
                    alt = MainForm.comPort.MAV.GuidedMode.z,
                    lat = MainForm.comPort.MAV.GuidedMode.x,
                    lng = MainForm.comPort.MAV.GuidedMode.y
                });
            }
        }

        private void myGMAP1_Click(object sender, EventArgs e)
        {

        }

        GMapMarkerRallyPt CurrentRallyPt;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (CurentRectMarker == null && CurrentRallyPt == null && groupmarkers.Count == 0)
            {
                toolStripMenuItem1.Enabled = false;
            }
            else
            {
                toolStripMenuItem1.Enabled = true;
            }

            isMouseClickOffMenu = false; // Just incase
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (e.CloseReason.ToString() == "AppClicked")
                isMouseClickOffMenu = true;
        }
        private void myGMAP1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownStart = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

            if (ModifierKeys == Keys.Control)
            {
                goHereToolStripMenuItem_Click(null, null);
            }

            if (isMouseClickOffMenu)
                return;



            //   Console.WriteLine("MainMap MD");

            if (e.Button == MouseButtons.Left && (groupmarkers.Count > 0 || ModifierKeys == Keys.Control))
            {
                // group move
                isMouseDown = true;
                isMouseDraging = false;

                return;
            }

            if (e.Button == MouseButtons.Left && ModifierKeys != Keys.Alt && ModifierKeys != Keys.Control)
            {
                isMouseDown = true;
                isMouseDraging = false;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = myGMAP1.FromLocalToLatLng(e.X, e.Y);
                }
            }


        }

        static public Object thisLock = new Object();
        GMapMarker CurrentGMapMarker;
        GMapMarker center = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.none);
        private void myGMAP1_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

            if (MouseDownStart == point)
                return;

            //  Console.WriteLine("MainMap MM " + point);

            currentMarker.Position = point;

            if (!isMouseDown)
            {
                // update mouse pos display
                //SetMouseDisplay(point.Lat, point.Lng, 0);
            }



            //draging
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                isMouseDraging = true;
                if (CurrentRallyPt != null)
                {
                    PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

                    CurrentRallyPt.Position = pnew;
                }
                else if (groupmarkers.Count > 0)
                {
                    // group drag

                    double latdif = MouseDownStart.Lat - point.Lat;
                    double lngdif = MouseDownStart.Lng - point.Lng;

                    MouseDownStart = point;

                    Hashtable seen = new Hashtable();

                    foreach (var markerid in groupmarkers)
                    {
                        if (seen.ContainsKey(markerid))
                            continue;

                        seen[markerid] = 1;
                        for (int a = 0; a < objectsoverlay.Markers.Count; a++)
                        {
                            var marker = objectsoverlay.Markers[a];

                            if (marker.Tag != null && marker.Tag.ToString() == markerid.ToString())
                            {
                                var temp = new PointLatLng(marker.Position.Lat, marker.Position.Lng);
                                temp.Offset(latdif, -lngdif);
                                marker.Position = temp;
                            }
                        }
                    }
                }
                else if (CurentRectMarker != null) // left click pan
                {
                    try
                    {
                        // check if this is a grid point
                        if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                        {
                            drawnpolygon.Points[
                                int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] =
                                new PointLatLng(point.Lat, point.Lng);
                            this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);
                            this.myGMAP1.Invalidate();
                        }
                    }
                    catch
                    {
                    }

                    PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

                    // adjust polyline point while we drag
                    try
                    {
                        /*
                        if (CurrentGMapMarker != null && CurrentGMapMarker.Tag is int)
                        {
                            int? pIndex = (int?)CurentRectMarker.Tag;
                            if (pIndex.HasValue)
                            {
                                if (pIndex < wppolygon.Points.Count)
                                {
                                    wppolygon.Points[pIndex.Value] = pnew;
                                    lock (thisLock) 
                                    {
                                        this.myGMAP1.UpdatePolygonLocalPosition(wppolygon);
                                    }
                                }
                            }
                        }*/
                    }
                    catch
                    {
                    }

                    // update rect and marker pos.
                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = pnew;
                    }
                    CurentRectMarker.Position = pnew;

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        CurentRectMarker.InnerMarker.Position = pnew;
                    }
                }
                else if (CurrentPOIMarker != null)
                {
                    PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

                    CurrentPOIMarker.Position = pnew;
                }
                else if (CurrentGMapMarker != null)
                {
                    PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

                    CurrentGMapMarker.Position = pnew;
                }
                else if (ModifierKeys == Keys.Control)
                {
                    // draw selection box
                    double latdif = MouseDownStart.Lat - point.Lat;
                    double lngdif = MouseDownStart.Lng - point.Lng;

                    this.myGMAP1.SelectedArea = new RectLatLng(Math.Max(MouseDownStart.Lat, point.Lat),
                        Math.Min(MouseDownStart.Lng, point.Lng), Math.Abs(lngdif), Math.Abs(latdif));
                }
                else // left click pan
                {
                    double latdif = MouseDownStart.Lat - point.Lat;
                    double lngdif = MouseDownStart.Lng - point.Lng;

                    try
                    {
                        lock (thisLock)
                        {
                            this.myGMAP1.Position = new PointLatLng(center.Position.Lat + latdif,
                                center.Position.Lng + lngdif);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            /*
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng point = myGMAP1.FromLocalToLatLng(e.X, e.Y);

                double latdif = MouseDownStart.Lat - point.Lat;
                double lngdif = MouseDownStart.Lng - point.Lng;

                try
                {
                    myGMAP1.Position = new PointLatLng(myGMAP1.Position.Lat + latdif,
                        myGMAP1.Position.Lng + lngdif);
                }
                catch
                {
                }
            }
            else
            {
                // setup a ballon with home distance
                if (marker != null)
                {
                    if (routes.Markers.Contains(marker))
                        routes.Markers.Remove(marker);
                }

                if (Settings.Instance.GetBoolean("CHK_disttohomeflightdata") != false)
                {
                    PointLatLng point = myGMAP1.FromLocalToLatLng(e.X, e.Y);

                    marker = new GMapMarkerRect(point);
                    marker.ToolTip = new GMapToolTip(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = "Dist to Home: " +
                                         ((myGMAP1.MapProvider.Projection.GetDistance(point,
                                             MainForm.comPort.MAV.cs.HomeLocation.Point()) * 1000) *
                                          CurrentState.multiplierdist).ToString("0");

                    routes.Markers.Add(marker);
                }
            }*/
        }
        bool polygongridmode;
        GMapOverlay drawnpolygonsoverlay;
        internal GMapPolygon drawnpolygon;
        float routetotal = 0;
        private void addPolygonPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (polygongridmode == false)
            {
                CustomMessageBox.Show(
                    "You will remain in polygon mode until you clear the polygon or create a grid/upload a fence");
            }

            polygongridmode = true;

            List<PointLatLng> polygonPoints = new List<PointLatLng>();
            if (drawnpolygonsoverlay.Polygons.Count == 0)
            {
                drawnpolygon.Points.Clear();
                drawnpolygonsoverlay.Polygons.Add(drawnpolygon);
            }

            drawnpolygon.Fill = Brushes.Transparent;

            // remove full loop is exists
            if (drawnpolygon.Points.Count > 1 &&
                drawnpolygon.Points[0] == drawnpolygon.Points[drawnpolygon.Points.Count - 1])
                drawnpolygon.Points.RemoveAt(drawnpolygon.Points.Count - 1); // unmake a full loop

            drawnpolygon.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownStart.Lng));

            addpolygonmarkergrid(drawnpolygon.Points.Count.ToString(), MouseDownStart.Lng, MouseDownStart.Lat, 0);

            myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);

            myGMAP1.Invalidate();

            this.lblDistance.Text = drawnpolygon.Distance.ToString("0.##") + "千米";

            if (drawnpolygon.Points.Count > 2)
            {
                this.lblArea.Text = calcpolygonarea(drawnpolygon.Points).ToString("#") + "平方米";
            }

        }

        double calcpolygonarea(List<PointLatLng> polygon)
        {
            // should be a closed polygon
            // coords are in lat long
            // need utm to calc area

            if (polygon.Count == 0)
            {
                CustomMessageBox.Show("Please define a polygon!");
                return 0;
            }

            // close the polygon
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

            GeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;

            int utmzone = (int)((polygon[0].Lng - -186.0) / 6.0);

            IProjectedCoordinateSystem utm = ProjectedCoordinateSystem.WGS84_UTM(utmzone, polygon[0].Lat < 0 ? false : true);

            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++)
            {
                double[] pll1 = { polygon[a].Lng, polygon[a].Lat };
                double[] pll2 = { polygon[a + 1].Lng, polygon[a + 1].Lat };

                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);

                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;

            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop

            return Math.Abs(answer);
        }


        private void addpolygonmarkergrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Never;
                m.ToolTipText = "grid" + tag;
                m.Tag = "grid" + tag;

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                drawnpolygonsoverlay.Markers.Add(m);
                drawnpolygonsoverlay.Markers.Add(mBorders);
            }
            catch (Exception ex)
            {
                log.Info(ex.ToString());
            }
        }

        GMapMarker marker;
        private void myGMAP1_MouseLeave(object sender, EventArgs e)
        {
            if (marker != null)
            {
                try
                {
                    if (routes.Markers.Contains(marker))
                        routes.Markers.Remove(marker);
                }
                catch
                {
                }
            }
        }

        private void MainMap_OnMapTypeChanged(GMap.NET.MapProviders.GMapProvider type)
        {

        }

        private void MainMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, System.Windows.Forms.MouseEventArgs e)
        {
            int answer;
            try // when dragging item can sometimes be null
            {
                if (item.Tag == null)
                {
                    // home.. etc
                    return;
                }

                if (ModifierKeys == Keys.Control)
                {
                    try
                    {
                        groupmarkeradd(item);

                        log.Info("add marker to group");
                    }
                    catch
                    {
                    }
                }

            }
            catch
            {
            }
        }

        void groupmarkeradd(GMapMarker marker)
        {
            System.Diagnostics.Debug.WriteLine("add marker " + marker.Tag.ToString());
            groupmarkers.Add(int.Parse(marker.Tag.ToString()));
            if (marker is GMapMarkerWP)
            {
                ((GMapMarkerWP)marker).selected = true;
            }
            if (marker is GMapMarkerRect)
            {
                ((GMapMarkerWP)((GMapMarkerRect)marker).InnerMarker).selected = true;
            }
        }

        private void MainMap_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    CurentRectMarker = null;
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.ResetColor();
                    this.myGMAP1.Invalidate(false);
                }
                if (item is GMapMarkerRallyPt)
                {
                    CurrentRallyPt = null;
                }
                if (item is GMapMarkerPOI)
                {
                    CurrentPOIMarker = null;
                }
                if (item is GMapMarker)
                {
                    // when you click the context menu this triggers and causes problems
                    CurrentGMapMarker = null;
                }
            }
        }

        private void MainMap_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                    this.myGMAP1.Invalidate(false);

                    int answer;
                    if (item.Tag != null && rc.InnerMarker != null &&
                        int.TryParse(rc.InnerMarker.Tag.ToString(), out answer))
                    {
                        try
                        {
                            Commands.CurrentCell = Commands[0, answer - 1];
                            item.ToolTipText = "Alt: " + Commands[Alt.Index, answer - 1].Value;
                            item.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }
                        catch
                        {
                        }
                    }

                    CurentRectMarker = rc;
                }
                if (item is GMapMarkerRallyPt)
                {
                    CurrentRallyPt = item as GMapMarkerRallyPt;
                }
                if (item is GMapMarkerAirport)
                {
                    // do nothing - readonly
                    return;
                }
                if (item is GMapMarkerPOI)
                {
                    CurrentPOIMarker = item as GMapMarkerPOI;
                }
                if (item is GMapMarkerWP)
                {
                    //CurrentGMapMarker = item;
                }
                if (item is GMapMarker)
                {
                    //CurrentGMapMarker = item;
                }
            }
        }
        bool isMouseDown;
        bool isMouseDraging;
        bool isMouseClickOffMenu;

        private void clearPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygongridmode = false;
            if (drawnpolygon == null)
                return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Markers.Clear();
            this.myGMAP1.Invalidate();

            writeKML();
        }

        private void updateHomeText()
        {
            // set home location
            if (MainForm.comPort.MAV.cs.HomeLocation.Lat != 0 && MainForm.comPort.MAV.cs.HomeLocation.Lng != 0)
            {
                TXT_homelat.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Lat.ToString();

                TXT_homelng.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Lng.ToString();

                TXT_homealt.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Alt.ToString();

                writeKML();
            }
        }

        public bool quickadd;
        public List<PointLatLngAlt> pointlist = new List<PointLatLngAlt>();
        public List<PointLatLngAlt> fullpointlist = new List<PointLatLngAlt>();
        public static GMapOverlay objectsoverlay;
        public void writeKML()
        {

            // quickadd is for when loading wps from eeprom or file, to prevent slow, loading times
            if (quickadd)
                return;

            // this is to share the current mission with the data tab
            pointlist = new List<PointLatLngAlt>();

            fullpointlist.Clear();

            Debug.WriteLine(DateTime.Now);
            try
            {
                if (objectsoverlay != null) // hasnt been created yet
                {
                    objectsoverlay.Markers.Clear();
                    objectsoverlay.Routes.Clear();
                }


                // process and add home to the list
                string home;
                if (TXT_homealt.EditValue.ToString() != "" && TXT_homelat.EditValue.ToString() != "" && TXT_homelng.EditValue.ToString() != "")
                {
                    home = string.Format("{0},{1},{2}\r\n", TXT_homelng.EditValue, TXT_homelat.EditValue, TXT_DefaultAlt.EditValue);
                    if (objectsoverlay != null) // during startup
                    {
                        pointlist.Add(new PointLatLngAlt(double.Parse(TXT_homelat.EditValue.ToString()), double.Parse(TXT_homelng.EditValue.ToString()),
                            double.Parse(TXT_homealt.EditValue.ToString()), "H"));
                        fullpointlist.Add(pointlist[pointlist.Count - 1]);
                        addpolygonmarker("H", double.Parse(TXT_homelng.EditValue.ToString()), double.Parse(TXT_homelat.EditValue.ToString()), 0, null);
                    }
                }
                else
                {
                    home = "";
                    pointlist.Add(null);
                    fullpointlist.Add(pointlist[pointlist.Count - 1]);
                }

                // setup for centerpoint calc etc.
                double avglat = 0;
                double avglong = 0;
                double maxlat = -180;
                double maxlong = -180;
                double minlat = 180;
                double minlong = 180;
                double homealt = 0;
                try
                {
                    if (!String.IsNullOrEmpty(TXT_homealt.EditValue.ToString()))
                        homealt = (int)double.Parse(TXT_homealt.EditValue.ToString());
                }
                catch
                {
                }


                if (CMB_altmode.EditValue.ToString() == altmode.Absolute.ToString())
                {
                    homealt = 0; // for absolute we dont need to add homealt
                }

                int usable = 0;

                updateRowNumbers();

                long temp = Stopwatch.GetTimestamp();

                string lookat = "";
                for (int a = 0; a < Commands.Rows.Count - 0; a++)
                {

                    try
                    {
                        if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
                            continue;

                        int command =
                            (byte)
                                (int)
                                    Enum.Parse(typeof(MAVLink.MAV_CMD),
                                        Commands.Rows[a].Cells[Command.Index].Value.ToString(), false);
                        if (command < (byte)MAVLink.MAV_CMD.LAST &&
                            command != (byte)MAVLink.MAV_CMD.TAKEOFF &&
                            command != (byte)MAVLink.MAV_CMD.RETURN_TO_LAUNCH &&
                            command != (byte)MAVLink.MAV_CMD.CONTINUE_AND_CHANGE_ALT &&
                            command != (byte)MAVLink.MAV_CMD.GUIDED_ENABLE
                            || command == (byte)MAVLink.MAV_CMD.DO_SET_ROI)
                        {
                            string cell2 = Commands.Rows[a].Cells[Alt.Index].Value.ToString(); // alt
                            string cell3 = Commands.Rows[a].Cells[Lat.Index].Value.ToString(); // lat
                            string cell4 = Commands.Rows[a].Cells[Lon.Index].Value.ToString(); // lng

                            // land can be 0,0 or a lat,lng
                            if (command == (byte)MAVLink.MAV_CMD.LAND && cell3 == "0" && cell4 == "0")
                                continue;

                            if (cell4 == "?" || cell3 == "?")
                                continue;

                            if (command == (byte)MAVLink.MAV_CMD.DO_SET_ROI)
                            {
                                pointlist.Add(new PointLatLngAlt(double.Parse(cell3), double.Parse(cell4),
                                    double.Parse(cell2) + homealt, "ROI" + (a + 1)) { color = Color.Red });
                                // do set roi is not a nav command. so we dont route through it
                                //fullpointlist.Add(pointlist[pointlist.Count - 1]);
                                GMarkerGoogle m =
                                    new GMarkerGoogle(new PointLatLng(double.Parse(cell3), double.Parse(cell4)),
                                        GMarkerGoogleType.red);
                                m.ToolTipMode = MarkerTooltipMode.Always;
                                m.ToolTipText = (a + 1).ToString();
                                m.Tag = (a + 1).ToString();

                                GMapMarkerRect mBorders = new GMapMarkerRect(m.Position);
                                {
                                    mBorders.InnerMarker = m;
                                    mBorders.Tag = "Dont draw line";
                                }

                                // check for clear roi, and hide it
                                if (m.Position.Lat != 0 && m.Position.Lng != 0)
                                {
                                    // order matters
                                    objectsoverlay.Markers.Add(m);
                                    objectsoverlay.Markers.Add(mBorders);
                                }
                            }
                            else if (command == (byte)MAVLink.MAV_CMD.LOITER_TIME ||
                                     command == (byte)MAVLink.MAV_CMD.LOITER_TURNS ||
                                     command == (byte)MAVLink.MAV_CMD.LOITER_UNLIM)
                            {
                                pointlist.Add(new PointLatLngAlt(double.Parse(cell3), double.Parse(cell4),
                                    double.Parse(cell2) + homealt, (a + 1).ToString())
                                {
                                    color = Color.LightBlue
                                });
                                fullpointlist.Add(pointlist[pointlist.Count - 1]);
                                addpolygonmarker((a + 1).ToString(), double.Parse(cell4), double.Parse(cell3),
                                    double.Parse(cell2), Color.LightBlue);
                            }
                            else if (command == (byte)MAVLink.MAV_CMD.SPLINE_WAYPOINT)
                            {
                                pointlist.Add(new PointLatLngAlt(double.Parse(cell3), double.Parse(cell4),
                                    double.Parse(cell2) + homealt, (a + 1).ToString()) { Tag2 = "spline" });
                                fullpointlist.Add(pointlist[pointlist.Count - 1]);
                                addpolygonmarker((a + 1).ToString(), double.Parse(cell4), double.Parse(cell3),
                                    double.Parse(cell2), Color.Green);
                            }
                            else
                            {
                                pointlist.Add(new PointLatLngAlt(double.Parse(cell3), double.Parse(cell4),
                                    double.Parse(cell2) + homealt, (a + 1).ToString()));
                                fullpointlist.Add(pointlist[pointlist.Count - 1]);
                                addpolygonmarker((a + 1).ToString(), double.Parse(cell4), double.Parse(cell3),
                                     double.Parse(cell2), null);
                            }

                            avglong += double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString());
                            avglat += double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString());
                            usable++;

                            maxlong = Math.Max(double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString()), maxlong);
                            maxlat = Math.Max(double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString()), maxlat);
                            minlong = Math.Min(double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString()), minlong);
                            minlat = Math.Min(double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString()), minlat);

                            Debug.WriteLine(temp - Stopwatch.GetTimestamp());
                        }
                        else if (command == (byte)MAVLink.MAV_CMD.DO_JUMP) // fix do jumps into the future
                        {
                            pointlist.Add(null);

                            int wpno = int.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString());
                            int repeat = int.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString());

                            List<PointLatLngAlt> list = new List<PointLatLngAlt>();

                            // cycle through reps
                            for (int repno = repeat; repno > 0; repno--)
                            {
                                // cycle through wps
                                for (int no = wpno; no <= a; no++)
                                {
                                    if (pointlist[no] != null)
                                        list.Add(pointlist[no]);
                                }
                            }

                            fullpointlist.AddRange(list);
                        }
                        else
                        {
                            pointlist.Add(null);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Info("writekml - bad wp data " + e);
                    }
                }

                if (usable > 0)
                {
                    avglat = avglat / usable;
                    avglong = avglong / usable;
                    double latdiff = maxlat - minlat;
                    double longdiff = maxlong - minlong;
                    float range = 4000;

                    Locationwp loc1 = new Locationwp();
                    loc1.lat = (minlat);
                    loc1.lng = (minlong);
                    Locationwp loc2 = new Locationwp();
                    loc2.lat = (maxlat);
                    loc2.lng = (maxlong);

                    //double distance = getDistance(loc1, loc2);  // same code as ardupilot
                    double distance = 2000;

                    if (usable > 1)
                    {
                        range = (float)(distance * 2);
                    }
                    else
                    {
                        range = 4000;
                    }

                    if (avglong != 0 && usable < 3)
                    {
                        // no autozoom
                        lookat = "<LookAt>     <longitude>" + (minlong + longdiff / 2).ToString(new CultureInfo("en-US")) +
                                 "</longitude>     <latitude>" + (minlat + latdiff / 2).ToString(new CultureInfo("en-US")) +
                                 "</latitude> <range>" + range + "</range> </LookAt>";
                        //MainMap.ZoomAndCenterMarkers("objects");
                        //MainMap.Zoom -= 1;
                        //MainMap_OnMapZoomChanged();
                    }
                }
                else if (home.Length > 5 && usable == 0)
                {
                    lookat = "<LookAt>     <longitude>" + TXT_homelng.EditValue.ToString().ToString(new CultureInfo("en-US")) +
                             "</longitude>     <latitude>" + TXT_homelat.EditValue.ToString().ToString(new CultureInfo("en-US")) +
                             "</latitude> <range>4000</range> </LookAt>";

                    RectLatLng? rect = myGMAP1.GetRectOfAllMarkers("objects");
                    if (rect.HasValue)
                    {
                        myGMAP1.Position = rect.Value.LocationMiddle;
                    }

                    //MainMap.Zoom = 17;

                    MainMap_OnMapZoomChanged();
                }



                //RegeneratePolygon();


                RegenerateWPRoute(fullpointlist);

                if (fullpointlist.Count > 0)
                {
                    double homedist = 0;

                    if (home.Length > 5)
                    {
                        homedist = this.myGMAP1.MapProvider.Projection.GetDistance(fullpointlist[fullpointlist.Count - 1],
                            fullpointlist[0]);
                    }

                    double dist = 0;

                    for (int a = 1; a < fullpointlist.Count; a++)
                    {
                        if (fullpointlist[a - 1] == null)
                            continue;

                        if (fullpointlist[a] == null)
                            continue;

                        dist += this.myGMAP1.MapProvider.Projection.GetDistance(fullpointlist[a - 1], fullpointlist[a]);
                    }

                    //lbl_distance.Text = rm.GetString("lbl_distance.Text") + ": " +
                    //                   FormatDistance(dist + homedist, false);
                }

                setgradanddistandaz();
            }
            catch (Exception ex)
            {
                log.Info(ex.ToString());
            }

            Debug.WriteLine(DateTime.Now);
        }

        private void addpolygonmarker(string tag, double lng, double lat, double alt, Color? color)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMapMarkerWP m = new GMapMarkerWP(point, tag);
                m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                m.ToolTipText = "Alt: " + alt.ToString("0");
                m.Tag = tag;

                int wpno = -1;
                if (int.TryParse(tag, out wpno))
                {
                    // preselect groupmarker
                    if (groupmarkers.Contains(wpno))
                        m.selected = true;
                }

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    mBorders.Tag = tag;
                    mBorders.wprad = (int)(float.Parse(TXT_WPRad.EditValue.ToString()) / CurrentState.multiplierdist);
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                objectsoverlay.Markers.Add(m);
                objectsoverlay.Markers.Add(mBorders);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
            }
        }



        private string FormatDistance(double distInKM, bool toMeterOrFeet)
        {
            string sunits = Settings.Instance["distunits"];
            Common.distances units = Common.distances.Meters;

            if (sunits != null)
                try
                {
                    units = (Common.distances)Enum.Parse(typeof(Common.distances), sunits);
                }
                catch (Exception)
                {
                }

            switch (units)
            {
                case Common.distances.Feet:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 3280.8399).ToString("0.00 ft"))
                        : string.Format((distInKM * 0.621371).ToString("0.0000 miles"));
                case Common.distances.Meters:
                default:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 1000).ToString("0.00 m"))
                        : string.Format(distInKM.ToString("0.0000 km"));
            }
        }
        public GMapRoute wpRoute = new GMapRoute("wp route");
        public GMapRoute homeroute = new GMapRoute("home route");
        public static GMapOverlay polygonsoverlay;


        private void RegenerateWPRoute(List<PointLatLngAlt> fullpointlist)
        {

            wpRoute.Clear();
            homeroute.Clear();

            polygonsoverlay.Routes.Clear();

            PointLatLngAlt lastpnt = fullpointlist[0];
            PointLatLngAlt lastpnt2 = fullpointlist[0];
            PointLatLngAlt lastnonspline = fullpointlist[0];
            List<PointLatLngAlt> splinepnts = new List<PointLatLngAlt>();
            List<PointLatLngAlt> wproute = new List<PointLatLngAlt>();

            // add home - this causeszx the spline to always have a straight finish
            fullpointlist.Add(fullpointlist[0]);

            for (int a = 0; a < fullpointlist.Count; a++)
            {
                if (fullpointlist[a] == null)
                    continue;

                if (fullpointlist[a].Tag2 == "spline")
                {
                    if (splinepnts.Count == 0)
                        splinepnts.Add(lastpnt);

                    splinepnts.Add(fullpointlist[a]);
                }
                else
                {
                    if (splinepnts.Count > 0)
                    {
                        List<PointLatLng> list = new List<PointLatLng>();

                        splinepnts.Add(fullpointlist[a]);

                        Spline2 sp = new Spline2();

                        //sp._flags.segment_type = MissionPlanner.Controls.Waypoints.Spline2.SegmentType.SEGMENT_STRAIGHT;
                        //sp._flags.reached_destination = true;
                        //sp._origin = sp.pv_location_to_vector(lastpnt);
                        //sp._destination = sp.pv_location_to_vector(fullpointlist[0]);

                        // sp._spline_origin_vel = sp.pv_location_to_vector(lastpnt) - sp.pv_location_to_vector(lastnonspline);

                        sp.set_wp_origin_and_destination(sp.pv_location_to_vector(lastpnt2),
                            sp.pv_location_to_vector(lastpnt));

                        sp._flags.reached_destination = true;

                        for (int no = 1; no < (splinepnts.Count - 1); no++)
                        {
                            Spline2.spline_segment_end_type segtype =
                                Spline2.spline_segment_end_type.SEGMENT_END_STRAIGHT;

                            if (no < (splinepnts.Count - 2))
                            {
                                segtype = Spline2.spline_segment_end_type.SEGMENT_END_SPLINE;
                            }

                            sp.set_spline_destination(sp.pv_location_to_vector(splinepnts[no]), false, segtype,
                                sp.pv_location_to_vector(splinepnts[no + 1]));

                            //sp.update_spline();

                            while (sp._flags.reached_destination == false)
                            {
                                float t = 1f;
                                //sp.update_spline();
                                sp.advance_spline_target_along_track(t);
                                // Console.WriteLine(sp.pv_vector_to_location(sp.target_pos).ToString());
                                list.Add(sp.pv_vector_to_location(sp.target_pos));
                            }

                            list.Add(splinepnts[no]);
                        }

                        list.ForEach(x => { wproute.Add(x); });


                        splinepnts.Clear();

                        /*
                        MissionPlanner.Controls.Waypoints.Spline sp = new Controls.Waypoints.Spline();
                        
                        var spline = sp.doit(splinepnts, 20, lastlastpnt.GetBearing(splinepnts[0]),false);

                  
                         */

                        lastnonspline = fullpointlist[a];
                    }

                    wproute.Add(fullpointlist[a]);

                    lastpnt2 = lastpnt;
                    lastpnt = fullpointlist[a];
                }
            }
            /*

           List<PointLatLng> list = new List<PointLatLng>();
           fullpointlist.ForEach(x => { list.Add(x); });
           route.Points.AddRange(list);
           */
            // route is full need to get 1, 2 and last point as "HOME" route

            int count = wproute.Count;
            int counter = 0;
            PointLatLngAlt homepoint = new PointLatLngAlt();
            PointLatLngAlt firstpoint = new PointLatLngAlt();
            PointLatLngAlt lastpoint = new PointLatLngAlt();

            if (count > 2)
            {
                // homeroute = last, home, first
                wproute.ForEach(x =>
                {
                    counter++;
                    if (counter == 1)
                    {
                        homepoint = x;
                        return;
                    }
                    if (counter == 2)
                    {
                        firstpoint = x;
                    }
                    if (counter == count - 1)
                    {
                        lastpoint = x;
                    }
                    if (counter == count)
                    {
                        homeroute.Points.Add(lastpoint);
                        homeroute.Points.Add(homepoint);
                        homeroute.Points.Add(firstpoint);
                        return;
                    }
                    wpRoute.Points.Add(x);
                });

                homeroute.Stroke = new Pen(Color.Yellow, 2);
                // if we have a large distance between home and the first/last point, it hangs on the draw of a the dashed line.
                if (homepoint.GetDistance(lastpoint) < 5000 && homepoint.GetDistance(firstpoint) < 5000)
                    homeroute.Stroke.DashStyle = DashStyle.Dash;

                polygonsoverlay.Routes.Add(homeroute);

                wpRoute.Stroke = new Pen(Color.Yellow, 4);
                wpRoute.Stroke.DashStyle = DashStyle.Custom;
                polygonsoverlay.Routes.Add(wpRoute);
            }
        }


        void setgradanddistandaz()
        {
            int a = 0;
            PointLatLngAlt last = MainForm.comPort.MAV.cs.HomeLocation;
            foreach (var lla in pointlist)
            {
                if (lla == null)
                    continue;
                try
                {
                    if (lla.Tag != null && lla.Tag != "H" && !lla.Tag.Contains("ROI"))
                    {
                        double height = lla.Alt - last.Alt;
                        double distance = lla.GetDistance(last) * CurrentState.multiplierdist;
                        double grad = height / distance;

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Grad.Index].Value =
                            (grad * 100).ToString("0.0");

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Angle.Index].Value =
                            ((180.0 / Math.PI) * Math.Atan(grad)).ToString("0.0");

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value =
                            (lla.GetDistance(last) * CurrentState.multiplierdist).ToString("0.0");

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[AZ.Index].Value =
                            ((lla.GetBearing(last) + 180) % 360).ToString("0");
                    }
                }
                catch
                {
                }
                a++;
                last = lla;
            }
        }

        void updateRowNumbers()
        {
            // number rows 
            this.BeginInvoke((MethodInvoker)delegate
            {
                // thread for updateing row numbers
                for (int a = 0; a < Commands.Rows.Count - 0; a++)
                {
                    try
                    {
                        if (Commands.Rows[a].HeaderCell.Value == null)
                        {
                            //Commands.Rows[a].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            Commands.Rows[a].HeaderCell.Value = (a + 1).ToString();
                        }
                        // skip rows with the correct number
                        string rowno = Commands.Rows[a].HeaderCell.Value.ToString();
                        if (!rowno.Equals((a + 1).ToString()))
                        {
                            // this code is where the delay is when deleting.
                            Commands.Rows[a].HeaderCell.Value = (a + 1).ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        private void MainMap_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isMouseClickOffMenu)
            {
                isMouseClickOffMenu = false;
                return;
            }

            // check if the mouse up happend over our button
            if (polyicon.Rectangle.Contains(e.Location))
            {
                polyicon.IsSelected = !polyicon.IsSelected;

                if (e.Button == MouseButtons.Right)
                {
                    polyicon.IsSelected = false;
                    clearPolygonToolStripMenuItem_Click(this, null);

                    contextMenuStrip1.Visible = false;

                    return;
                }

                if (polyicon.IsSelected)
                {
                    polygongridmode = true;
                }
                else
                {
                    polygongridmode = false;
                }

                return;
            }

            MouseDownEnd = myGMAP1.FromLocalToLatLng(e.X, e.Y);

            // Console.WriteLine("MainMap MU");

            if (e.Button == MouseButtons.Right) // ignore right clicks
            {
                return;
            }

            if (isMouseDown) // mouse down on some other object and dragged to here.
            {
                // drag finished, update poi db
                if (CurrentPOIMarker != null)
                {
                    POI.POIMove(CurrentPOIMarker);
                    CurrentPOIMarker = null;
                }

                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }
                if (ModifierKeys == Keys.Control)
                {
                    // group select wps
                    GMapPolygon poly = new GMapPolygon(new List<PointLatLng>(), "temp");

                    poly.Points.Add(MouseDownStart);
                    poly.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownEnd.Lng));
                    poly.Points.Add(MouseDownEnd);
                    poly.Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownStart.Lng));

                    foreach (var marker in objectsoverlay.Markers)
                    {
                        if (poly.IsInside(marker.Position))
                        {
                            try
                            {
                                if (marker.Tag != null)
                                {
                                    groupmarkeradd(marker);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }

                    isMouseDraging = false;
                    return;
                }
                if (!isMouseDraging)
                {
                    if (CurentRectMarker != null)
                    {
                        // cant add WP in existing rect
                    }
                    else
                    {
                        if (TXT_DefaultAlt.EditValue == null || TXT_DefaultAlt.EditValue.ToString().Trim().Length == 0)
                        {
                            CustomMessageBox.Show("请设置默认高度");
                            return;
                        }
                        if (TXT_WPRad.EditValue == null || TXT_WPRad.EditValue.ToString().Trim().Length == 0)
                        {
                            CustomMessageBox.Show("请设置航点半径");
                            return;
                        }

                        AddWPToMap(currentMarker.Position.Lat, currentMarker.Position.Lng, 0);
                    }
                }
                else
                {
                    if (groupmarkers.Count > 0)
                    {
                        Dictionary<string, PointLatLng> dest = new Dictionary<string, PointLatLng>();

                        foreach (var markerid in groupmarkers)
                        {
                            for (int a = 0; a < objectsoverlay.Markers.Count; a++)
                            {
                                var marker = objectsoverlay.Markers[a];

                                if (marker.Tag != null && marker.Tag.ToString() == markerid.ToString())
                                {
                                    dest[marker.Tag.ToString()] = marker.Position;
                                    break;
                                }
                            }
                        }

                        foreach (KeyValuePair<string, PointLatLng> item in dest)
                        {
                            var value = item.Value;
                            quickadd = true;
                            callMeDrag(item.Key, value.Lat, value.Lng, -1);
                            quickadd = false;
                        }

                        this.myGMAP1.SelectedArea = RectLatLng.Empty;
                        groupmarkers.Clear();
                        // redraw to remove selection
                        writeKML();

                        CurentRectMarker = null;
                    }

                    if (CurentRectMarker != null)
                    {
                        if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                        {
                            try
                            {
                                drawnpolygon.Points[
                                    int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] =
                                    new PointLatLng(MouseDownEnd.Lat, MouseDownEnd.Lng);
                                this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);
                                this.myGMAP1.Invalidate();
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            callMeDrag(CurentRectMarker.InnerMarker.Tag.ToString(), currentMarker.Position.Lat,
                                currentMarker.Position.Lng, -2);
                        }
                        CurentRectMarker = null;
                    }
                }
            }

            isMouseDraging = false;
        }
        List<int> groupmarkers = new List<int>();
        internal PointLatLng MouseDownEnd;
        GMapMarker currentMarker;
        GMapMarkerRect CurentRectMarker;
        GMapMarkerPOI CurrentPOIMarker;
        public void callMeDrag(string pointno, double lat, double lng, int alt)
        {
            if (pointno == "")
            {
                return;
            }

            // dragging a WP
            if (pointno == "H")
            {
                if (isonline && CHK_verifyheight.Checked)
                {
                    TXT_homealt.EditValue = getGEAlt(lat, lng).ToString();
                }
                TXT_homelat.EditValue = lat.ToString();
                TXT_homelng.EditValue = lng.ToString();
                return;
            }

            if (pointno == "Tracker Home")
            {
                MainForm.comPort.MAV.cs.TrackerLocation = new PointLatLngAlt(lat, lng, alt, "");
                return;
            }

            try
            {
                selectedrow = int.Parse(pointno) - 1;
                Commands.CurrentCell = Commands[1, selectedrow];
                // depending on the dragged item, selectedrow can be reset 
                selectedrow = int.Parse(pointno) - 1;
            }
            catch
            {
                return;
            }

            setfromMap(lat, lng, alt);
        }

        double getGEAlt(double lat, double lng)
        {
            double alt = 0;
            //http://maps.google.com/maps/api/elevation/xml

            try
            {
                using (
                    XmlTextReader xmlreader =
                        new XmlTextReader("http://maps.google.com/maps/api/elevation/xml?locations=" +
                                          lat.ToString(new CultureInfo("en-US")) + "," +
                                          lng.ToString(new CultureInfo("en-US")) + "&sensor=true"))
                {
                    while (xmlreader.Read())
                    {
                        xmlreader.MoveToElement();
                        switch (xmlreader.Name)
                        {
                            case "elevation":
                                alt = double.Parse(xmlreader.ReadString(), new CultureInfo("en-US"));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch
            {
            }

            return alt * CurrentState.multiplierdist;
        }


        int selectedrow;
        List<Locationwp> GetCommandList()
        {
            List<Locationwp> commands = new List<Locationwp>();

            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                var temp = DataViewtoLocationwp(a);

                commands.Add(temp);
            }

            return commands;
        }
        Locationwp DataViewtoLocationwp(int a)
        {
            try
            {
                Locationwp temp = new Locationwp();
                if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
                {
                    temp.id = (ushort)Commands.Rows[a].Cells[Command.Index].Tag;
                }
                else
                {
                    temp.id =
                        (ushort)
                            (int)
                                Enum.Parse(typeof(MAVLink.MAV_CMD),
                                    Commands.Rows[a].Cells[Command.Index].Value.ToString(),
                                    false);
                }
                temp.p1 = float.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString());

                temp.alt =
                    (float)
                        (double.Parse(Commands.Rows[a].Cells[Alt.Index].Value.ToString()) / CurrentState.multiplierdist);
                temp.lat = (double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString()));
                temp.lng = (double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString()));

                temp.p2 = (float)(double.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString()));
                temp.p3 = (float)(double.Parse(Commands.Rows[a].Cells[Param3.Index].Value.ToString()));
                temp.p4 = (float)(double.Parse(Commands.Rows[a].Cells[Param4.Index].Value.ToString()));

                temp.Tag = Commands.Rows[a].Cells[Tag.Index].Value;

                return temp;
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid number on row " + (a + 1).ToString(), ex);
            }
        }
        List<List<Locationwp>> history = new List<List<Locationwp>>();
        private Dictionary<string, string[]> cmdParamNames = new Dictionary<string, string[]>();
        public enum altmode
        {
            Relative = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT,
            Absolute = MAVLink.MAV_FRAME.GLOBAL,
            Terrain = MAVLink.MAV_FRAME.GLOBAL_TERRAIN_ALT
        }
        public void setfromMap(double lat, double lng, int alt, double p1 = 0)
        {
            if (selectedrow > Commands.RowCount)
            {
                CustomMessageBox.Show("Invalid coord, How did you do this?");
                return;
            }

            // add history
            history.Add(GetCommandList());

            // remove more than 20 revisions
            if (history.Count > 20)
            {
                history.RemoveRange(0, history.Count - 20);
            }

            DataGridViewTextBoxCell cell;
            if (alt == -2 && Commands.Columns[Alt.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][6] /*"Alt"*/))
            {
                if (CHK_verifyheight.Checked && CMB_altmode1.EditValue != altmode.Terrain.ToString()) //Drag with verifyheight // use srtm data
                {
                    cell = Commands.Rows[selectedrow].Cells[Alt.Index] as DataGridViewTextBoxCell;
                    float ans;
                    if (float.TryParse(cell.Value.ToString(), out ans))
                    {
                        ans = (int)ans;

                        DataGridViewTextBoxCell celllat =
                            Commands.Rows[selectedrow].Cells[Lat.Index] as DataGridViewTextBoxCell;
                        DataGridViewTextBoxCell celllon =
                            Commands.Rows[selectedrow].Cells[Lon.Index] as DataGridViewTextBoxCell;
                        int oldsrtm =
                            (int)
                                ((srtm.getAltitude(double.Parse(celllat.Value.ToString()),
                                    double.Parse(celllon.Value.ToString())).alt) * CurrentState.multiplierdist);
                        int newsrtm = (int)((srtm.getAltitude(lat, lng).alt) * CurrentState.multiplierdist);
                        int newh = (int)(ans + newsrtm - oldsrtm);

                        cell.Value = newh;

                        cell.DataGridView.EndEdit();
                    }
                }
            }
            if (Commands.Columns[Lat.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][4] /*"Lat"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Lat.Index] as DataGridViewTextBoxCell;
                cell.Value = lat.ToString("0.0000000");
                cell.DataGridView.EndEdit();
            }
            if (Commands.Columns[Lon.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][5] /*"Long"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Lon.Index] as DataGridViewTextBoxCell;
                cell.Value = lng.ToString("0.0000000");
                cell.DataGridView.EndEdit();
            }
            if (alt != -1 && alt != -2 &&
                Commands.Columns[Alt.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][6] /*"Alt"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Alt.Index] as DataGridViewTextBoxCell;

                {
                    double result;
                    bool pass = double.TryParse(TXT_homealt.EditValue.ToString(), out result);

                    if (pass == false)
                    {
                        CustomMessageBox.Show("You must have a home altitude");
                        string homealt = "100";
                        if (DialogResult.Cancel == InputBox.Show("Home Alt", "Home Altitude", ref homealt))
                            return;
                        TXT_homealt.EditValue = homealt;
                    }
                    int results1;
                    if (!int.TryParse(TXT_DefaultAlt.EditValue.ToString(), out results1))
                    {
                        CustomMessageBox.Show("Your default alt is not valid");
                        return;
                    }

                    if (results1 == 0)
                    {
                        string defalt = "100";
                        if (DialogResult.Cancel == InputBox.Show("Default Alt", "Default Altitude", ref defalt))
                            return;
                        TXT_DefaultAlt.EditValue = defalt;
                    }
                }

                cell.Value = TXT_DefaultAlt.EditValue;

                float ans;
                if (float.TryParse(cell.Value.ToString(), out ans))
                {
                    ans = (int)ans;
                    if (alt != 0) // use passed in value;
                        cell.Value = alt.ToString();
                    if (ans == 0) // default
                        cell.Value = 50;
                    if (ans == 0 && (MainForm.comPort.MAV.cs.firmware == MainForm.Firmwares.ArduCopter2))
                        cell.Value = 15;

                    // not online and verify alt via srtm
                    if (CHK_verifyheight.Checked) // use srtm data
                    {
                        // is absolute but no verify
                        if (CMB_altmode1.EditValue == altmode.Absolute.ToString())
                        {
                            //abs
                            cell.Value =
                                ((srtm.getAltitude(lat, lng).alt) * CurrentState.multiplierdist +
                                 int.Parse(TXT_DefaultAlt.EditValue.ToString())).ToString();
                        }
                        else if (CMB_altmode1.EditValue == altmode.Terrain.ToString())
                        {
                            cell.Value = int.Parse(TXT_DefaultAlt.EditValue.ToString());
                        }
                        else
                        {
                            //relative and verify
                            cell.Value =
                                ((int)(srtm.getAltitude(lat, lng).alt) * CurrentState.multiplierdist +
                                 int.Parse(TXT_DefaultAlt.EditValue.ToString()) -
                                 (int)
                                     srtm.getAltitude(MainForm.comPort.MAV.cs.HomeLocation.Lat,
                                         MainForm.comPort.MAV.cs.HomeLocation.Lng).alt * CurrentState.multiplierdist)
                                    .ToString();
                        }
                    }

                    cell.DataGridView.EndEdit();
                }
                else
                {
                    CustomMessageBox.Show("Invalid Home or wp Alt");
                    cell.Style.BackColor = Color.Red;
                }
            }

            // Add more for other params
            if (Commands.Columns[Param1.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][1] /*"Delay"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Param1.Index] as DataGridViewTextBoxCell;
                cell.Value = p1;
                cell.DataGridView.EndEdit();
            }

            writeKML();
            Commands.EndEdit();
        }
        private void ChangeColumnHeader(string command)
        {
            try
            {
                if (cmdParamNames.ContainsKey(command))
                    for (int i = 1; i <= 7; i++)
                        Commands.Columns[i].HeaderText = cmdParamNames[command][i - 1];
                else
                    for (int i = 1; i <= 7; i++)
                        Commands.Columns[i].HeaderText = "setme";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }
        bool isonline = true;
        bool sethome;

        bool splinemode;
        public void AddWPToMap(double lat, double lng, int alt)
        {
            if (polygongridmode)
            {

                addPolygonPointToolStripMenuItem_Click(null, null);
                return;
            }

            if (sethome)
            {
                sethome = false;
                callMeDrag("H", lat, lng, alt);
                return;
            }
            // creating a WP

            selectedrow = Commands.Rows.Add();

            if (splinemode)
            {
                Commands.Rows[selectedrow].Cells[Command.Index].Value = MAVLink.MAV_CMD.SPLINE_WAYPOINT.ToString();
                ChangeColumnHeader(MAVLink.MAV_CMD.SPLINE_WAYPOINT.ToString());
            }
            else
            {
                Commands.Rows[selectedrow].Cells[Command.Index].Value = MAVLink.MAV_CMD.WAYPOINT.ToString();
                ChangeColumnHeader(MAVLink.MAV_CMD.WAYPOINT.ToString());
            }

            setfromMap(lat, lng, alt);
        }

        private void Commands_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedrow = e.RowIndex;
            Commands_RowEnter(sender, new DataGridViewCellEventArgs(0, e.RowIndex - 0));
            // do header labels - encure we dont 0 out valid colums
            int cols = Commands.Columns.Count;
            for (int a = 1; a < cols; a++)
            {
                DataGridViewTextBoxCell cell;
                cell = Commands.Rows[selectedrow].Cells[a] as DataGridViewTextBoxCell;

                if (Commands.Columns[a].HeaderText.Equals("") && cell != null && cell.Value == null)
                {
                    cell.Value = "0";
                }
                else
                {
                    if (cell != null && (cell.Value == null || cell.Value.ToString() == ""))
                    {
                        cell.Value = "?";
                    }
                }
            }
        }

        private void Commands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (e.ColumnIndex == Delete.Index && (e.RowIndex + 0) < Commands.RowCount) // delete
                {
                    quickadd = true;
                    // mono fix
                    Commands.CurrentCell = null;
                    Commands.Rows.RemoveAt(e.RowIndex);
                    quickadd = false;
                    writeKML();
                }
                if (e.ColumnIndex == Up.Index && e.RowIndex != 0) // up
                {
                    DataGridViewRow myrow = Commands.CurrentRow;
                    Commands.Rows.Remove(myrow);
                    Commands.Rows.Insert(e.RowIndex - 1, myrow);
                    writeKML();
                }
                if (e.ColumnIndex == Down.Index && e.RowIndex < Commands.RowCount - 1) // down
                {
                    DataGridViewRow myrow = Commands.CurrentRow;
                    Commands.Rows.Remove(myrow);
                    Commands.Rows.Insert(e.RowIndex + 1, myrow);
                    writeKML();
                }
                setgradanddistandaz();
            }
            catch (Exception)
            {
                CustomMessageBox.Show("Row error");
            }
        }

        private void Commands_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Commands_RowEnter(null,
                new DataGridViewCellEventArgs(Commands.CurrentCell.ColumnIndex, Commands.CurrentCell.RowIndex));

            writeKML();
        }

        private void Commands_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (quickadd)
                return;
            try
            {
                selectedrow = e.RowIndex;
                string option = Commands[Command.Index, selectedrow].EditedFormattedValue.ToString();
                string cmd;
                try
                {
                    cmd = Commands[Command.Index, selectedrow].Value.ToString();
                }
                catch
                {
                    cmd = option;
                }
                //Console.WriteLine("editformat " + option + " value " + cmd);
                ChangeColumnHeader(cmd);

                if (cmd == "WAYPOINT")
                {
                }

                //  writeKML();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }


        private void Commands_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                var temp = ((ComboBox)e.Control);
                ((ComboBox)e.Control).SelectionChangeCommitted -= Commands_SelectionChangeCommitted;
                ((ComboBox)e.Control).SelectionChangeCommitted += Commands_SelectionChangeCommitted;
                ((ComboBox)e.Control).ForeColor = Color.White;
                ((ComboBox)e.Control).BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                Debug.WriteLine("Setting event handle");
            }
        }

        void Commands_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // update row headers
            ((ComboBox)sender).ForeColor = Color.White;
            ChangeColumnHeader(((ComboBox)sender).Text);
            try
            {
                // default takeoff to non 0 alt
                if (((ComboBox)sender).Text == "TAKEOFF")
                {
                    if (Commands.Rows[selectedrow].Cells[Alt.Index].Value != null &&
                        Commands.Rows[selectedrow].Cells[Alt.Index].Value.ToString() == "0")
                        Commands.Rows[selectedrow].Cells[Alt.Index].Value = TXT_DefaultAlt.EditValue;
                }

                // default to take shot
                if (((ComboBox)sender).Text == "DO_DIGICAM_CONTROL")
                {
                    if (Commands.Rows[selectedrow].Cells[Lat.Index].Value != null &&
                        Commands.Rows[selectedrow].Cells[Lat.Index].Value.ToString() == "0")
                        Commands.Rows[selectedrow].Cells[Lat.Index].Value = (1).ToString();
                }

                for (int i = 0; i < Commands.ColumnCount; i++)
                {
                    DataGridViewCell tcell = Commands.Rows[selectedrow].Cells[i];
                    if (tcell.GetType() == typeof(DataGridViewTextBoxCell))
                    {
                        if (tcell.Value.ToString() == "?")
                            tcell.Value = "0";
                    }
                }
            }
            catch
            {
            }
        }

        void AddDrawPolygon()
        {
            List<PointLatLng> list2 = new List<PointLatLng>();

            list.ForEach(x => { list2.Add(x); });

            //var poly = new GMapPolygon(list2, "poly");
            //poly.Stroke = new Pen(Color.Red, 2);
            //poly.Fill = Brushes.Transparent;

            //objectsoverlay.Polygons.Add(poly);

            foreach (var item in list)
            {
                objectsoverlay.Markers.Add(new GMarkerGoogle(item, GMarkerGoogleType.red));
            }
        }

        private void Commands_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < Commands.ColumnCount; i++)
            {
                DataGridViewCell tcell = Commands.Rows[e.RowIndex].Cells[i];
                if (tcell.GetType() == typeof(DataGridViewTextBoxCell))
                {
                    if (tcell.Value == null)
                        tcell.Value = "0";
                }
            }

            DataGridViewComboBoxCell cell = Commands.Rows[e.RowIndex].Cells[Command.Index] as DataGridViewComboBoxCell;
            if (cell.Value == null)
            {
                cell.Value = "WAYPOINT";
                cell.DropDownWidth = 200;
                Commands.Rows[e.RowIndex].Cells[Delete.Index].Value = "X";
                if (!quickadd)
                {
                    Commands_RowEnter(sender, new DataGridViewCellEventArgs(0, e.RowIndex - 0)); // do header labels
                    Commands_RowValidating(sender, new DataGridViewCellCancelEventArgs(0, e.RowIndex));
                    // do default values
                }
            }

            if (quickadd)
                return;

            try
            {
                Commands.CurrentCell = Commands.Rows[e.RowIndex].Cells[0];

                if (Commands.Rows.Count > 1)
                {
                    if (Commands.Rows[e.RowIndex - 1].Cells[Command.Index].Value.ToString() == "WAYPOINT")
                    {
                        Commands.Rows[e.RowIndex].Selected = true; // highlight row
                    }
                    else
                    {
                        Commands.CurrentCell = Commands[1, e.RowIndex - 1];
                        //Commands_RowEnter(sender, new DataGridViewCellEventArgs(0, e.RowIndex-1));
                    }
                }
            }
            catch (Exception)
            {
            }
            // Commands.EndEdit();
        }

        void Commands_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log.Info(e.Exception + " " + e.Context + " col " + e.ColumnIndex);
            e.Cancel = false;
            e.ThrowException = false;
            //throw new NotImplementedException();
        }

        private void Commands_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[Delete.Index].Value = "X";
            e.Row.Cells[Up.Index].Value = Resources.up;
            e.Row.Cells[Down.Index].Value = Resources.down;
        }

        private void MainMap_OnMapZoomChanged()
        {

        }



        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {

        }

        private void MainMap_OnTileLoadStart()
        {

        }

        private void MainMap_OnCurrentPositionChanged(GMap.NET.PointLatLng point)
        {
            if (point.Lat > 90)
            {
                point.Lat = 90;
            }
            if (point.Lat < -90)
            {
                point.Lat = -90;
            }
            if (point.Lng > 180)
            {
                point.Lng = 180;
            }
            if (point.Lng < -180)
            {
                point.Lng = -180;
            }
            center.Position = point;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int no = 0;
            if (CurentRectMarker != null)
            {
                if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString(), out no))
                {
                    try
                    {
                        Commands.Rows.RemoveAt(no - 1); // home is 0
                    }
                    catch
                    {
                        CustomMessageBox.Show("error selecting wp, please try again.");
                    }
                }
                else if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", ""), out no))
                {
                    try
                    {
                        drawnpolygon.Points.RemoveAt(no - 1);
                        drawnpolygonsoverlay.Markers.Clear();

                        int a = 1;
                        foreach (PointLatLng pnt in drawnpolygon.Points)
                        {
                            addpolygonmarkergrid(a.ToString(), pnt.Lng, pnt.Lat, 0);
                            a++;
                        }

                        this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);

                        this.myGMAP1.Invalidate();
                    }
                    catch
                    {
                        CustomMessageBox.Show("Remove point Failed. Please try again.");
                    }
                }
            }
            else if (CurrentRallyPt != null)
            {
                rallypointoverlay.Markers.Remove(CurrentRallyPt);
                this.myGMAP1.Invalidate(true);

                CurrentRallyPt = null;
            }
            else if (groupmarkers.Count > 0)
            {
                for (int a = Commands.Rows.Count; a > 0; a--)
                {
                    try
                    {
                        if (groupmarkers.Contains(a))
                            Commands.Rows.RemoveAt(a - 1); // home is 0
                    }
                    catch
                    {
                        CustomMessageBox.Show("error selecting wp, please try again.");
                    }
                }

                groupmarkers.Clear();
            }


            if (currentMarker != null)
                CurentRectMarker = null;

            writeKML();
        }


        List<PointLatLngAlt> list = new List<PointLatLngAlt>();
        private void btnSplice_ItemClick(object sender, ItemClickEventArgs e)
        {

            cleanMission();


            polygongridmode = false;

            list.Clear();

            objectsoverlay.Markers.Clear();
            objectsoverlay.Routes.Clear();

            if (this.txtSpace.EditValue == null)
            {

                CustomMessageBox.Show("请输入间距");
                return;

            }


            double distance = 0.0D;

            bool canParse = double.TryParse(this.txtSpace.EditValue.ToString(), out distance);

            if (!canParse)
            {
                CustomMessageBox.Show("请输入正确的数值");
                return;
            }


            GMapPolygon gMapPolygon = new GMapPolygon(new List<PointLatLng>(this.drawnpolygon.Points),
                    "Poly Copy") { Stroke = this.drawnpolygon.Stroke };
            gMapPolygon.Points.ForEach(x => { list.Add(x); });
            double angle = (double)((getAngleOfLongestSide(list) + 360) % 360);
            //List<PointLatLngAlt> polygon, double altitude, double distance, double spacing, double angle, double overshoot1,double overshoot2, StartPosition startpos, bool shutter, float minLaneSeparation, float leadin = 0
            List<PointLatLngAlt> grid = Grid.CreateGrid(list, 10, distance, 0, angle, 0, 0, Grid.StartPosition.Home, false, 0, 0);

            if (grid.Count == 0)
            {
                CustomMessageBox.Show("无法切片");
                return;
            }


            //AddDrawPolygon();
            int strips = 0;
            int images = 0;
            int a = 1;
            PointLatLngAlt prevpoint = grid[0];
            float routetotal = 0;
            List<PointLatLng> segment = new List<PointLatLng>();
            double maxgroundelevation = double.MinValue;
            double mingroundelevation = double.MaxValue;
            double startalt = 10;

            foreach (var item in grid)
            {
                double currentalt = srtm.getAltitude(item.Lat, item.Lng).alt;
                mingroundelevation = Math.Min(mingroundelevation, currentalt);
                maxgroundelevation = Math.Max(maxgroundelevation, currentalt);

                if (item.Tag == "M")
                {
                    images++;

                }
                else
                {
                    if (item.Tag != "SM" && item.Tag != "ME")
                        strips++;

                    if (true)
                    {
                        var marker = new GMapMarkerWP(item, a.ToString()) { ToolTipText = a.ToString(), ToolTipMode = MarkerTooltipMode.OnMouseOver };
                        objectsoverlay.Markers.Add(marker);
                    }

                    segment.Add(prevpoint);
                    segment.Add(item);
                    prevpoint = item;
                    a++;
                }
                GMapRoute seg = new GMapRoute(segment, "segment" + a.ToString());
                seg.Stroke = new Pen(Color.Yellow, 4);
                seg.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                seg.IsHitTestVisible = true;
                routetotal = routetotal + (float)seg.Distance;

                objectsoverlay.Routes.Add(seg);

                segment.Clear();
            }

            quickadd = true;
            foreach (GMapMarker marker in objectsoverlay.Markers)
            {
                AddCommand(MAVLink.MAV_CMD.WAYPOINT, 0, 0, 0, 0, marker.Position.Lng, marker.Position.Lat, 0);
            }
            updateRowNumbers();
            quickadd = false;


        }



        double getAngleOfLongestSide(List<PointLatLngAlt> list)
        {
            if (list.Count == 0)
                return 0;
            double angle = 0;
            double maxdist = 0;
            PointLatLngAlt last = list[list.Count - 1];
            foreach (var item in list)
            {
                if (item.GetDistance(last) > maxdist)
                {
                    angle = item.GetBearing(last);
                    maxdist = item.GetDistance(last);
                }
                last = item;
            }

            return (angle + 360) % 360;
        }

        private void 清楚多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygongridmode = false;
            if (drawnpolygon == null)
                return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Markers.Clear();
            this.myGMAP1.Invalidate();

            writeKML();
        }

        private void btnReadWaypoints_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Commands.Rows.Count > 0)
            {

                if (
                    CustomMessageBox.Show("This will clear your existing planned mission, Continue?", "Confirm",
                        MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }

            }

            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Receiving WP's"
            };

            frmProgressReporter.DoWork += getWPs;
            frmProgressReporter.UpdateProgressAndStatus(-1, "Receiving WP's");



            frmProgressReporter.RunBackgroundOperationAsync();

            frmProgressReporter.Dispose();
        }
        Hashtable param = new Hashtable();
        void getWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                MAVLinkInterface port = MainForm.comPort;

                if (!port.BaseStream.IsOpen)
                {
                    throw new Exception("Please Connect First!");
                }

                MainForm.comPort.giveComport = true;

                param = port.MAV.param;

                log.Info("Getting Home");

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Getting WP count");

                if (port.MAV.apname == MAVLink.MAV_AUTOPILOT.PX4)
                {
                    try
                    {
                        cmds.Add(port.getHomePosition());
                    }
                    catch (TimeoutException ex)
                    {
                        // blank home
                        cmds.Add(new Locationwp() { id = (ushort)MAVLink.MAV_CMD.WAYPOINT });
                    }
                }

                log.Info("Getting WP #");

                int cmdcount = port.getWPCount();

                for (ushort a = 0; a < cmdcount; a++)
                {
                    if (((ProgressReporterDialogue)sender).doWorkArgs.CancelRequested)
                    {
                        ((ProgressReporterDialogue)sender).doWorkArgs.CancelAcknowledged = true;
                        throw new Exception("Cancel Requested");
                    }

                    log.Info("Getting WP" + a);
                    ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / cmdcount, "Getting WP " + a);
                    cmds.Add(port.getWP(a));
                }

                port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done");

                log.Info("Done");
            }
            catch
            {
                throw;
            }

            WPtoScreen(cmds);
        }

        public void WPtoScreen(List<Locationwp> cmds, bool withrally = true)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        log.Info("Process " + cmds.Count);
                        processToScreen(cmds);
                    }
                    catch (Exception exx)
                    {
                        log.Info(exx.ToString());
                    }

                    /*
                    try
                    {
                        if (withrally && MainForm.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                            int.Parse(MainForm.comPort.MAV.param["RALLY_TOTAL"].ToString()) >= 1)
                            getRallyPointsToolStripMenuItem_Click(null, null);
                    }
                    catch
                    {
                    }*/

                    MainForm.comPort.giveComport = false;



                    writeKML();
                });
            }
            catch (Exception exx)
            {
                log.Info(exx.ToString());
            }
        }

        void processToScreen(List<Locationwp> cmds, bool append = false)
        {
            quickadd = true;


            // mono fix
            Commands.CurrentCell = null;

            while (Commands.Rows.Count > 0 && !append)
                Commands.Rows.Clear();

            if (cmds.Count == 0)
            {
                quickadd = false;
                return;
            }

            Commands.SuspendLayout();
            Commands.Enabled = false;

            int i = Commands.Rows.Count - 1;
            foreach (Locationwp temp in cmds)
            {
                i++;
                //Console.WriteLine("FP processToScreen " + i);
                if (temp.id == 0 && i != 0) // 0 and not home
                    break;
                if (temp.id == 255 && i != 0) // bad record - never loaded any WP's - but have started the board up.
                    break;
                if (i + 1 >= Commands.Rows.Count)
                {
                    selectedrow = Commands.Rows.Add();
                }
                //if (i == 0 && temp.alt == 0) // skip 0 home
                //  continue;
                DataGridViewTextBoxCell cell;
                DataGridViewComboBoxCell cellcmd;
                cellcmd = Commands.Rows[i].Cells[Command.Index] as DataGridViewComboBoxCell;
                cellcmd.Value = "UNKNOWN";
                cellcmd.Tag = temp.id;

                foreach (object value in Enum.GetValues(typeof(MAVLink.MAV_CMD)))
                {
                    if ((int)value == temp.id)
                    {
                        cellcmd.Value = value.ToString();
                        break;
                    }
                }

                // from ap_common.h
                if (temp.id < (ushort)MAVLink.MAV_CMD.LAST || temp.id == (ushort)MAVLink.MAV_CMD.DO_SET_HOME)
                {
                    // check ralatice and terrain flags
                    if ((temp.options & 0x9) == 0 && i != 0)
                    {
                        CMB_altmode.EditValue = altmode.Absolute;
                    } // check terrain flag
                    else if ((temp.options & 0x8) != 0 && i != 0)
                    {
                        CMB_altmode.EditValue = altmode.Terrain;
                    } // check relative flag
                    else if ((temp.options & 0x1) != 0 && i != 0)
                    {
                        CMB_altmode.EditValue = altmode.Relative;
                    }
                }

                cell = Commands.Rows[i].Cells[Alt.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.alt * CurrentState.multiplierdist;
                cell = Commands.Rows[i].Cells[Lat.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.lat;
                cell = Commands.Rows[i].Cells[Lon.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.lng;

                cell = Commands.Rows[i].Cells[Param1.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p1;
                cell = Commands.Rows[i].Cells[Param2.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p2;
                cell = Commands.Rows[i].Cells[Param3.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p3;
                cell = Commands.Rows[i].Cells[Param4.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p4;
            }

            Commands.Enabled = true;
            Commands.ResumeLayout();

            setWPParams();

            try
            {
                DataGridViewTextBoxCell cellhome;
                cellhome = Commands.Rows[0].Cells[Lat.Index] as DataGridViewTextBoxCell;
                if (cellhome.Value != null)
                {
                    if (cellhome.Value.ToString() != TXT_homelat.EditValue.ToString() && cellhome.Value.ToString() != "0")
                    {
                        DialogResult dr = CustomMessageBox.Show("Reset Home to loaded coords", "Reset Home Coords",
                            MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            TXT_homelat.EditValue = (double.Parse(cellhome.Value.ToString())).ToString();
                            cellhome = Commands.Rows[0].Cells[Lon.Index] as DataGridViewTextBoxCell;
                            TXT_homelng.EditValue = (double.Parse(cellhome.Value.ToString())).ToString();
                            cellhome = Commands.Rows[0].Cells[Alt.Index] as DataGridViewTextBoxCell;
                            TXT_homealt.EditValue =
                                (double.Parse(cellhome.Value.ToString()) * CurrentState.multiplierdist).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            } // if there is no valid home

            if (Commands.RowCount > 0)
            {
                log.Info("remove home from list");
                Commands.Rows.Remove(Commands.Rows[0]); // remove home row
            }

            quickadd = false;

            writeKML();

            this.myGMAP1.ZoomAndCenterMarkers("objects");

            MainMap_OnMapZoomChanged();
        }

        private void btnWriteWaypoints_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CMB_altmode.EditValue == altmode.Absolute.ToString())
            {
                if (DialogResult.No ==
                    CustomMessageBox.Show("Absolute Alt is selected are you sure?", "Alt Mode", MessageBoxButtons.YesNo))
                {
                    CMB_altmode.EditValue = altmode.Relative;
                }
            }

            // check for invalid grid data
            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                for (int b = 0; b < Commands.ColumnCount - 0; b++)
                {
                    double answer;
                    if (b >= 1 && b <= 7)
                    {
                        if (!double.TryParse(Commands[b, a].Value.ToString(), out answer))
                        {
                            CustomMessageBox.Show("There are errors in your mission");
                            return;
                        }
                    }



                    if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
                        continue;

                    byte cmd =
                        (byte)
                            (int)
                                Enum.Parse(typeof(MAVLink.MAV_CMD),
                                    Commands.Rows[a].Cells[Command.Index].Value.ToString(), false);
                    /*
                    if (cmd < (byte)MAVLink.MAV_CMD.LAST &&
                        double.Parse(Commands[Alt.Index, a].Value.ToString()) < double.Parse(TXT_altwarn.Text))
                    {
                        if (cmd != (byte)MAVLink.MAV_CMD.TAKEOFF &&
                            cmd != (byte)MAVLink.MAV_CMD.LAND &&
                            cmd != (byte)MAVLink.MAV_CMD.RETURN_TO_LAUNCH)
                        {
                            CustomMessageBox.Show("Low alt on WP#" + (a + 1) +
                                                  "\nPlease reduce the alt warning, or increase the altitude");
                            return;
                        }
                    }*/
                }
            }

            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Sending WP's"
            };

            frmProgressReporter.DoWork += saveWPs;
            frmProgressReporter.UpdateProgressAndStatus(-1, "Sending WP's");

            frmProgressReporter.RunBackgroundOperationAsync();

            frmProgressReporter.Dispose();

            this.myGMAP1.Focus();
        }
        altmode currentaltmode = altmode.Relative;
        void saveWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            try
            {
                MAVLinkInterface port = MainForm.comPort;

                if (!port.BaseStream.IsOpen)
                {
                    throw new Exception("Please connect first!");
                }

                MainForm.comPort.giveComport = true;
                int a = 0;

                // define the home point
                Locationwp home = new Locationwp();
                try
                {
                    home.id = (ushort)MAVLink.MAV_CMD.WAYPOINT;
                    home.lat = (double.Parse(TXT_homelat.EditValue.ToString()));
                    home.lng = (double.Parse(TXT_homelng.EditValue.ToString()));
                    home.alt = (float.Parse(TXT_homealt.EditValue.ToString()) / CurrentState.multiplierdist); // use saved home
                }
                catch
                {
                    throw new Exception("Your home location is invalid");
                }

                // log
                log.Info("wps values " + MainForm.comPort.MAV.wps.Values.Count);
                log.Info("cmd rows " + (Commands.Rows.Count + 1)); // + home

                // check for changes / future mod to send just changed wp's
                if (MainForm.comPort.MAV.wps.Values.Count == (Commands.Rows.Count + 1))
                {
                    Hashtable wpstoupload = new Hashtable();

                    a = -1;
                    foreach (var item in MainForm.comPort.MAV.wps.Values)
                    {
                        // skip home
                        if (a == -1)
                        {
                            a++;
                            continue;
                        }

                        MAVLink.mavlink_mission_item_t temp = DataViewtoLocationwp(a);

                        if (temp.command == item.command &&
                            temp.x == item.x &&
                            temp.y == item.y &&
                            temp.z == item.z &&
                            temp.param1 == item.param1 &&
                            temp.param2 == item.param2 &&
                            temp.param3 == item.param3 &&
                            temp.param4 == item.param4
                            )
                        {
                            log.Info("wp match " + (a + 1));
                        }
                        else
                        {
                            log.Info("wp no match" + (a + 1));
                            wpstoupload[a] = "";
                        }

                        a++;
                    }
                }

                bool use_int = (port.MAV.cs.capabilities & MAVLink.MAV_PROTOCOL_CAPABILITY.MISSION_INT) > 0;

                // set wp total
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set total wps ");

                ushort totalwpcountforupload = (ushort)(Commands.Rows.Count + 1);

                if (port.MAV.apname == MAVLink.MAV_AUTOPILOT.PX4)
                {
                    totalwpcountforupload--;
                }

                port.setWPTotal(totalwpcountforupload); // + home

                // set home location - overwritten/ignored depending on firmware.
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set home");

                // upload from wp0
                a = 0;

                if (port.MAV.apname != MAVLink.MAV_AUTOPILOT.PX4)
                {
                    try
                    {
                        var homeans = port.setWP(home, (ushort)a, MAVLink.MAV_FRAME.GLOBAL, 0, 1, use_int);
                        if (homeans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                        {
                            CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                            return;
                        }
                        a++;
                    }
                    catch (TimeoutException ex)
                    {
                        use_int = false;
                        // added here to prevent timeout errors
                        port.setWPTotal(totalwpcountforupload);
                        var homeans = port.setWP(home, (ushort)a, MAVLink.MAV_FRAME.GLOBAL, 0, 1, use_int);
                        if (homeans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                        {
                            CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                            return;
                        }
                        a++;
                    }
                }
                else
                {
                    use_int = false;
                }

                // define the default frame.
                MAVLink.MAV_FRAME frame = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT;

                // get the command list from the datagrid
                var commandlist = GetCommandList();

                // process commandlist to the mav
                for (a = 1; a <= commandlist.Count; a++)
                {
                    var temp = commandlist[a - 1];

                    ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / Commands.Rows.Count,
                        "Setting WP " + a);

                    // make sure we are using the correct frame for these commands
                    if (temp.id < (ushort)MAVLink.MAV_CMD.LAST || temp.id == (ushort)MAVLink.MAV_CMD.DO_SET_HOME)
                    {
                        var mode = currentaltmode;

                        if (mode == altmode.Terrain)
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL_TERRAIN_ALT;
                        }
                        else if (mode == altmode.Absolute)
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL;
                        }
                        else
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT;
                        }
                    }

                    // try send the wp
                    MAVLink.MAV_MISSION_RESULT ans = port.setWP(temp, (ushort)(a), frame, 0, 1, use_int);

                    // we timed out while uploading wps/ command wasnt replaced/ command wasnt added
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ERROR)
                    {
                        // resend for partial upload
                        port.setWPPartialUpdate((ushort)(a), totalwpcountforupload);
                        // reupload this point.
                        ans = port.setWP(temp, (ushort)(a), frame, 0, 1, use_int);
                    }

                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_NO_SPACE)
                    {
                        e.ErrorMessage = "Upload failed, please reduce the number of wp's";
                        return;
                    }
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_INVALID)
                    {
                        e.ErrorMessage =
                            "Upload failed, mission was rejected byt the Mav,\n item had a bad option wp# " + a + " " +
                            ans;
                        return;
                    }
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_INVALID_SEQUENCE)
                    {
                        // invalid sequence can only occur if we failed to see a response from the apm when we sent the request.
                        // or there is io lag and we send 2 mission_items and get 2 responces, one valid, one a ack of the second send

                        // the ans is received via mission_ack, so we dont know for certain what our current request is for. as we may have lost the mission_request

                        // get requested wp no - 1;
                        a = port.getRequestedWPNo() - 1;

                        continue;
                    }
                    if (ans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                    {
                        e.ErrorMessage = "Upload wps failed " + Enum.Parse(typeof(MAVLink.MAV_CMD), temp.id.ToString()) +
                                         " " + Enum.Parse(typeof(MAVLink.MAV_MISSION_RESULT), ans.ToString());
                        return;
                    }
                }

                port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(95, "Setting params");

                // m
                port.setParam("WP_RADIUS", float.Parse(TXT_WPRad.EditValue.ToString()) / CurrentState.multiplierdist);

                // cm's
                port.setParam("WPNAV_RADIUS", float.Parse(TXT_WPRad.EditValue.ToString()) / CurrentState.multiplierdist * 100.0);

                try
                {
                    port.setParam(new[] { "LOITER_RAD", "WP_LOITER_RAD" },
                        float.Parse(TXT_loiterrad.EditValue.ToString()) / CurrentState.multiplierdist);
                }
                catch
                {
                }

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MainForm.comPort.giveComport = false;
                throw;
            }

            MainForm.comPort.giveComport = false;
        }

        private void CMB_altmode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CMB_altmode.EditValue == null)
            {
                CMB_altmode.EditValue = 0;
            }
            else
            {
                currentaltmode = (altmode)CMB_altmode.EditValue;
            }

        }

        private void LoadSHPFile(string file)
        {
            ProjectionInfo pStart = new ProjectionInfo();
            ProjectionInfo pESRIEnd = KnownCoordinateSystems.Geographic.World.WGS1984;
            bool reproject = false;

            if (File.Exists(file))
            {
                string prjfile = Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                 Path.GetFileNameWithoutExtension(file) + ".prj";
                if (File.Exists(prjfile))
                {
                    using (
                        StreamReader re =
                            File.OpenText(Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                          Path.GetFileNameWithoutExtension(file) + ".prj"))
                    {
                        pStart.ParseEsriString(re.ReadLine());

                        reproject = true;
                    }
                }

                IFeatureSet fs = FeatureSet.Open(file);

                fs.FillAttributes();

                int rows = fs.NumRows();

                DataTable dtOriginal = fs.DataTable;
                for (int row = 0; row < dtOriginal.Rows.Count; row++)
                {
                    object[] original = dtOriginal.Rows[row].ItemArray;
                }

                foreach (DataColumn col in dtOriginal.Columns)
                {
                    Console.WriteLine(col.ColumnName + " " + col.DataType);
                }

                quickadd = true;

                bool dosort = false;

                List<PointLatLngAlt> wplist = new List<PointLatLngAlt>();

                for (int row = 0; row < dtOriginal.Rows.Count; row++)
                {
                    double x = fs.Vertex[row * 2];
                    double y = fs.Vertex[row * 2 + 1];

                    double z = -1;
                    float wp = 0;

                    try
                    {
                        if (dtOriginal.Columns.Contains("ELEVATION"))
                            z = (float)Convert.ChangeType(dtOriginal.Rows[row]["ELEVATION"], TypeCode.Single);
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (z == -1 && dtOriginal.Columns.Contains("alt"))
                            z = (float)Convert.ChangeType(dtOriginal.Rows[row]["alt"], TypeCode.Single);
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (z == -1)
                            z = fs.Z[row];
                    }
                    catch
                    {
                    }


                    try
                    {
                        if (dtOriginal.Columns.Contains("wp"))
                        {
                            wp = (float)Convert.ChangeType(dtOriginal.Rows[row]["wp"], TypeCode.Single);
                            dosort = true;
                        }
                    }
                    catch
                    {
                    }

                    if (reproject)
                    {
                        double[] xyarray = { x, y };
                        double[] zarray = { z };

                        Reproject.ReprojectPoints(xyarray, zarray, pStart, pESRIEnd, 0, 1);


                        x = xyarray[0];
                        y = xyarray[1];
                        z = zarray[0];
                    }

                    PointLatLngAlt pnt = new PointLatLngAlt(x, y, z, wp.ToString());

                    wplist.Add(pnt);
                }

                if (dosort)
                    wplist.Sort();

                foreach (var item in wplist)
                {
                    AddCommand(MAVLink.MAV_CMD.WAYPOINT, 0, 0, 0, 0, item.Lng, item.Lat, item.Alt);
                }

                quickadd = false;

                writeKML();

                this.myGMAP1.ZoomAndCenterMarkers("objects");
            }
        }

        public int AddCommand(MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x, double y,
           double z, object tag = null)
        {
            selectedrow = Commands.Rows.Add();

            FillCommand(this.selectedrow, cmd, p1, p2, p3, p4, x, y, z, tag);

            writeKML();

            return selectedrow;
        }

        private void FillCommand(int rowIndex, MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x,
            double y, double z, object tag = null)
        {
            Commands.Rows[rowIndex].Cells[Command.Index].Value = cmd.ToString();
            Commands.Rows[rowIndex].Cells[Tag.Index].Tag = tag;
            Commands.Rows[rowIndex].Cells[Tag.Index].Value = tag;

            ChangeColumnHeader(cmd.ToString());

            // switch wp to spline if spline checked
            if (splinemode && cmd == MAVLink.MAV_CMD.WAYPOINT)
            {
                Commands.Rows[rowIndex].Cells[Command.Index].Value = MAVLink.MAV_CMD.SPLINE_WAYPOINT.ToString();
                ChangeColumnHeader(MAVLink.MAV_CMD.SPLINE_WAYPOINT.ToString());
            }

            if (cmd == MAVLink.MAV_CMD.WAYPOINT)
            {
                // add delay if supplied
                Commands.Rows[rowIndex].Cells[Param1.Index].Value = p1;

                setfromMap(y, x, (int)z, Math.Round(p1, 1));
            }
            else if (cmd == MAVLink.MAV_CMD.LOITER_UNLIM)
            {
                setfromMap(y, x, (int)z);
            }
            else
            {
                Commands.Rows[rowIndex].Cells[Param1.Index].Value = p1;
                Commands.Rows[rowIndex].Cells[Param2.Index].Value = p2;
                Commands.Rows[rowIndex].Cells[Param3.Index].Value = p3;
                Commands.Rows[rowIndex].Cells[Param4.Index].Value = p4;
                Commands.Rows[rowIndex].Cells[Lat.Index].Value = y;
                Commands.Rows[rowIndex].Cells[Lon.Index].Value = x;
                Commands.Rows[rowIndex].Cells[Alt.Index].Value = z;
            }
        }


        internal string wpfilename;

        private void btnReadWpsFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "All Supported Types|*.txt;*.waypoints;*.shp;*.mission";
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;

                if (File.Exists(file))
                {
                    if (file.ToLower().EndsWith(".shp"))
                    {
                        LoadSHPFile(file);
                    }
                    else
                    {
                        string line = "";
                        using (var fs = File.OpenText(file))
                        {
                            line = fs.ReadLine();
                        }

                        if (line.StartsWith("{"))
                        {
                            var format = MissionFile.ReadFile(file);

                            var cmds = MissionFile.ConvertToLocationwps(format);

                            processToScreen(cmds);

                            writeKML();

                            this.myGMAP1.ZoomAndCenterMarkers("objects");
                        }
                        else
                        {
                            wpfilename = file;
                            readQGC110wpfile(file);
                        }
                    }

                    //lbl_wpfile.Text = "Loaded " + Path.GetFileName(file);
                }
            }
        }

        public void readQGC110wpfile(string file, bool append = false)
        {
            int wp_count = 0;
            bool error = false;
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                StreamReader sr = new StreamReader(file); //"defines.h"
                string header = sr.ReadLine();
                if (header == null || !header.Contains("QGC WPL"))
                {
                    CustomMessageBox.Show("Invalid Waypoint file");
                    return;
                }

                while (!error && !sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // waypoints

                    if (line.StartsWith("#"))
                        continue;

                    string[] items = line.Split(new[] { '\t', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (items.Length <= 9)
                        continue;

                    try
                    {
                        Locationwp temp = new Locationwp();
                        if (items[2] == "3")
                        {
                            // abs MAV_FRAME_GLOBAL_RELATIVE_ALT=3
                            temp.options = 1;
                        }
                        else
                        {
                            temp.options = 0;
                        }
                        temp.id = (ushort)(int)Enum.Parse(typeof(MAVLink.MAV_CMD), items[3], false);
                        temp.p1 = float.Parse(items[4], new CultureInfo("en-US"));

                        if (temp.id == 99)
                            temp.id = 0;

                        temp.alt = (float)(double.Parse(items[10], new CultureInfo("en-US")));
                        temp.lat = (double.Parse(items[8], new CultureInfo("en-US")));
                        temp.lng = (double.Parse(items[9], new CultureInfo("en-US")));

                        temp.p2 = (float)(double.Parse(items[5], new CultureInfo("en-US")));
                        temp.p3 = (float)(double.Parse(items[6], new CultureInfo("en-US")));
                        temp.p4 = (float)(double.Parse(items[7], new CultureInfo("en-US")));

                        cmds.Add(temp);

                        wp_count++;
                    }
                    catch
                    {
                        CustomMessageBox.Show("Line invalid\n" + line);
                    }
                }

                sr.Close();

                processToScreen(cmds, append);

                writeKML();

                this.myGMAP1.ZoomAndCenterMarkers("objects");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Can't open file! " + ex);
            }
        }

        private void btnSaveWpsFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFile_Click(null, null);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            savewaypoints();
            writeKML();
        }

        private void savewaypoints()
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Filter = "Mission|*.waypoints;*.txt|Mission JSON|*.mission";
                fd.DefaultExt = ".waypoints";
                fd.FileName = wpfilename;
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;
                if (file != "")
                {
                    try
                    {
                        if (file.EndsWith(".mission"))
                        {
                            var list = GetCommandList();
                            Locationwp home = new Locationwp();
                            try
                            {
                                home.id = (ushort)MAVLink.MAV_CMD.WAYPOINT;
                                home.lat = (double.Parse(TXT_homelat.EditValue.ToString()));
                                home.lng = (double.Parse(TXT_homelng.EditValue.ToString()));
                                home.alt = (float.Parse(TXT_homealt.EditValue.ToString()) / CurrentState.multiplierdist); // use saved home
                            }
                            catch { }

                            list.Insert(0, home);

                            var format = MissionFile.ConvertFromLocationwps(list, (byte)(altmode)CMB_altmode.EditValue);

                            MissionFile.WriteFile(file, format);
                            return;
                        }

                        StreamWriter sw = new StreamWriter(file);
                        sw.WriteLine("QGC WPL 110");
                        try
                        {
                            sw.WriteLine("0\t1\t0\t16\t0\t0\t0\t0\t" +
                                         double.Parse(TXT_homelat.EditValue.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                                         "\t" +
                                         double.Parse(TXT_homelng.EditValue.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                                         "\t" +
                                         double.Parse(TXT_homealt.EditValue.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                                         "\t1");
                        }
                        catch
                        {
                            sw.WriteLine("0\t1\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1");
                        }
                        for (int a = 0; a < Commands.Rows.Count - 0; a++)
                        {
                            byte mode =
                                (byte)
                                    (MAVLink.MAV_CMD)
                                        Enum.Parse(typeof(MAVLink.MAV_CMD), Commands.Rows[a].Cells[0].Value.ToString());

                            sw.Write((a + 1)); // seq
                            sw.Write("\t" + 0); // current
                            //sw.Write("\t" + CMB_altmode.EditValue.ToString()); //frame 
                            sw.Write("\t" + (int)(altmode)Enum.Parse(typeof(altmode), CMB_altmode.EditValue.ToString()));
                            sw.Write("\t" + mode);
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Param3.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Param4.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     (double.Parse(Commands.Rows[a].Cells[Alt.Index].Value.ToString()) /
                                      CurrentState.multiplierdist).ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" + 1);
                            sw.WriteLine("");
                        }
                        sw.Close();

                        //lbl_wpfile.Text = "Saved " + Path.GetFileName(file);
                    }
                    catch (Exception)
                    {
                        CustomMessageBox.Show(Strings.ERROR);
                    }
                }
            }
        }

        private void splitContainerControl1_Panel1_Resize(object sender, EventArgs e)
        {

            this.hud1.doResize();

        }

        private void cboFlightModel_EditValueChanged(object sender, EventArgs e)
        {
            if (MainForm.comPort.BaseStream.IsOpen)
            {
                MainForm.comPort.setMode(this.cboFlightModel.EditValue.ToString());
            }
        }

        private void cboFlightModel_EditValueChanged_1(object sender, EventArgs e)
        {
            if (MainForm.comPort.BaseStream.IsOpen)
            {
                MainForm.comPort.setMode(this.cboFlightModel.EditValue.ToString());
            }
        }

        MissionPlanner.Controls.Icon.Polygon polyicon = new MissionPlanner.Controls.Icon.Polygon();
        private void myGMAP1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ResetTransform();

            polyicon.Location = new Point(10, 100);
            polyicon.Paint(e.Graphics);
        }

        private void 清除任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMission();
        }

        private void cleanMission()
        {
            quickadd = true;

            // mono fix
            Commands.CurrentCell = null;

            Commands.Rows.Clear();

            selectedrow = 0;
            quickadd = false;

            writeKML();
        }

        private void 设置家在这ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXT_homealt.EditValue = srtm.getAltitude(MouseDownStart.Lat, MouseDownStart.Lng).alt.ToString("0");
            TXT_homelat.EditValue = MouseDownStart.Lat.ToString();
            TXT_homelng.EditValue = MouseDownStart.Lng.ToString();
        }

        private void TXT_homelat_TextChanged(object sender, EventArgs e)
        {
            sethome = false;
            try
            {
                MainForm.comPort.MAV.cs.HomeLocation.Lat = double.Parse(TXT_homelat.EditValue.ToString());
            }
            catch
            {
            }
            writeKML();
        }

        private void TXT_homelng_TextChanged(object sender, EventArgs e)
        {
            sethome = false;
            try
            {
                MainForm.comPort.MAV.cs.HomeLocation.Lng = double.Parse(TXT_homelng.EditValue.ToString());
            }
            catch
            {
            }
            writeKML();
        }

        private void TXT_homealt_TextChanged(object sender, EventArgs e)
        {
            sethome = false;
            try
            {
                MainForm.comPort.MAV.cs.HomeLocation.Alt = double.Parse(TXT_homealt.EditValue.ToString());
            }
            catch
            {
            }
            writeKML();
        }

        private void btnAutoFlight_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (MainForm.comPort.MAV.cs.connected)
            {


                MainForm.comPort.setMode("Stabilize");

                PWM pwm = new PWM();

                if (!MainForm.comPort.MAV.cs.armed)
                {

                    pwm.Chan1 = MainForm.comPort.MAV.cs.Roll;
                    pwm.Chan2 = MainForm.comPort.MAV.cs.Pitch;
                    pwm.Chan3 = 1000;
                    pwm.Chan4 = MainForm.comPort.MAV.cs.Rudder;
                    MainForm.comPort.setThrottleUp(pwm);
                    /*
                    while(true)
                    {
                        MainForm.comPort.setThrottleUp(pwm);  

                        if(MainForm.comPort.MAV.cs.Throttle==1000)
                        {
                            break;
                        }

                    }*/


                    bool ans = MainForm.comPort.doARM(true);

                }

                MainForm.comPort.setMode("Auto");

                pwm.Chan1 = MainForm.comPort.MAV.cs.Roll;
                pwm.Chan2 = MainForm.comPort.MAV.cs.Pitch;
                pwm.Chan3 = 1500;
                pwm.Chan4 = MainForm.comPort.MAV.cs.Rudder;
                MainForm.comPort.setThrottleUp(pwm);



            }
            else
            {

            }


        }



    }
}