using GMap.NET.MapProviders;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
using FBGroundControl.GPI;



namespace FBGroundControl
{

    public partial class UAVMainForm : MetroForm
    {
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置

        Thread thisthread;

        public Hashtable adsbPlanes = new Hashtable();
        //MainForm 复制开始
        int tickStart;

        public static GMapOverlay kmlpolygons;
        internal static GMapOverlay rallypointoverlay;
        internal static GMapOverlay poioverlay = new GMapOverlay("POI"); // poi layer

        Thread serialreaderthread;
        public static bool threadrun;

        private static readonly log4net.ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DateTime connecttime = DateTime.Now;
        MAVLinkInterface _comPort = new MAVLinkInterface();
        

        GMapOverlay polygons;
        GMapOverlay routes;
        GMapRoute route;
        List<PointLatLng> trackPoints = new List<PointLatLng>();
        private bool CameraOverlap;

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

        bool serialThread = false;
        public static bool speechEnable = false;



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


        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);
        public static Speech speechEngine = null;
        DateTime nodatawarning = DateTime.Now;
        private DateTime heatbeatSend = DateTime.Now;

        public bool quickadd;

        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>();
      
        MissionPlanner.Controls.MainSwitcher MyView;

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
        //copy end

        public UAVMainForm()
        {
            InitializeComponent();
            initWidget();
            initMap();
            InitData();
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


        }

        private void InitData()
        {
             
            COMInterface.comPort.MavChanged -= comPort_MavChanged;
            COMInterface.comPort.MavChanged += comPort_MavChanged;

            if (!Settings.Instance.ContainsKey("copter_guid"))
            {
                Settings.Instance["copter_guid"] = Guid.NewGuid().ToString();
            }
                
            LoadConfig();
             
        }
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
                if (COMInterface.comPort.giveComport)
                {
                    Thread.Sleep(50);
                    updateBindingSource();
                    continue;
                }

                if (!COMInterface.comPort.logreadmode)
                    Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

                /*
                try
                {
                    if (aviwriter != null && vidrec.AddMilliseconds(100) <= DateTime.Now)
                    {
                        vidrec = DateTime.Now;

                        //hud1.streamjpgenable = true;

                        //aviwriter.avi_start("test.avi");
                        // add a frame
                        aviwriter.avi_add(//hud1.streamjpg.ToArray(), (uint)//hud1.streamjpg.Length);
                        // write header - so even partial files will play
                        aviwriter.avi_end(//hud1.Width, //hud1.Height, 10);
                    }
                }
                catch
                {
                    log.Error("Failed to write avi");
                }
                 * */

                // log playback
                if (COMInterface.comPort.logreadmode && COMInterface.comPort.logplaybackfile != null)
                {
                    if (COMInterface.comPort.BaseStream.IsOpen)
                    {
                        COMInterface.comPort.logreadmode = false;
                        try
                        {
                            COMInterface.comPort.logplaybackfile.Close();
                        }
                        catch
                        {
                            log.Error("Failed to close logfile");
                        }
                        COMInterface.comPort.logplaybackfile = null;
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

                    DateTime logplayback = COMInterface.comPort.lastlogread;
                    try
                    {
                        if (!COMInterface.comPort.giveComport)
                            COMInterface.comPort.readPacket();

                        // update currentstate of sysids on the port
                        foreach (var MAV in COMInterface.comPort.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, COMInterface.comPort, MAV);
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

                    double act = (COMInterface.comPort.lastlogread - logplayback).TotalMilliseconds;

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
                        //Console.WriteLine(COMInterface.comPort.lastlogread.Second + " " + DateTime.Now.Second + " " + (COMInterface.comPort.lastlogread.Second - DateTime.Now.Second));
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
                        if (COMInterface.comPort.logplaybackfile != null &&
                            COMInterface.comPort.logplaybackfile.BaseStream.Position ==
                            COMInterface.comPort.logplaybackfile.BaseStream.Length)
                        {
                            COMInterface.comPort.logreadmode = false;
                        }
                    }
                    catch
                    {
                        COMInterface.comPort.logreadmode = false;
                    }*/
                }
                else
                {
                    // ensure we know to stop
                    /*
                    if (COMInterface.comPort.logreadmode)
                        COMInterface.comPort.logreadmode = false;
                    updatePlayPauseButton(false);

                    if (!playingLog && COMInterface.comPort.logplaybackfile != null)
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

                    if (COMInterface.comPort.MAV.cs.battery_voltage <= warnvolt)
                    {
                        //////hud1.lowvoltagealert = true;
                    }
                    else if ((COMInterface.comPort.MAV.cs.battery_remaining) < warnpercent)
                    {
                        //////hud1.lowvoltagealert = true;
                    }
                    else
                    {
                        //////hud1.lowvoltagealert = false;
                    }

                    /*
                    // update opengltest
                    if (OpenGLtest.instance != null)
                    {
                        OpenGLtest.instance.rpy = new Vector3(COMInterface.comPort.MAV.cs.roll, COMInterface.comPort.MAV.cs.pitch,
                            COMInterface.comPort.MAV.cs.yaw);
                        OpenGLtest.instance.LocationCenter = new PointLatLngAlt(COMInterface.comPort.MAV.cs.lat,
                            COMInterface.comPort.MAV.cs.lng, COMInterface.comPort.MAV.cs.alt, "here");
                    }

                    // update opengltest2
                    if (OpenGLtest2.instance != null)
                    {
                        OpenGLtest2.instance.rpy = new Vector3(COMInterface.comPort.MAV.cs.roll, COMInterface.comPort.MAV.cs.pitch,
                            COMInterface.comPort.MAV.cs.yaw);
                        OpenGLtest2.instance.LocationCenter = new PointLatLngAlt(COMInterface.comPort.MAV.cs.lat,
                            COMInterface.comPort.MAV.cs.lng, COMInterface.comPort.MAV.cs.alt, "here");
                    }*/

                    // update vario info
                    Vario.SetValue(COMInterface.comPort.MAV.cs.climbrate);

                    // udpate tunning tab
                    if (tunning.AddMilliseconds(50) < DateTime.Now && false)
                    {
                        double time = (Environment.TickCount - tickStart) / 1000.0;
                        if (list1item != null)
                            list1.Add(time, ConvertToDouble(list1item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list2item != null)
                            list2.Add(time, ConvertToDouble(list2item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list3item != null)
                            list3.Add(time, ConvertToDouble(list3item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list4item != null)
                            list4.Add(time, ConvertToDouble(list4item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list5item != null)
                            list5.Add(time, ConvertToDouble(list5item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list6item != null)
                            list6.Add(time, ConvertToDouble(list6item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list7item != null)
                            list7.Add(time, ConvertToDouble(list7item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list8item != null)
                            list8.Add(time, ConvertToDouble(list8item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list9item != null)
                            list9.Add(time, ConvertToDouble(list9item.GetValue(COMInterface.comPort.MAV.cs, null)));
                        if (list10item != null)
                            list10.Add(time, ConvertToDouble(list10item.GetValue(COMInterface.comPort.MAV.cs, null)));
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

                        PointLatLng currentloc = new PointLatLng(COMInterface.comPort.MAV.cs.lat, COMInterface.comPort.MAV.cs.lng);

                        myGMAP1.HoldInvalidation = true;

                        int numTrackLength = Settings.Instance.GetInt32("NUM_tracklength");
                        // maintain route history length
                        if (route.Points.Count > numTrackLength)
                        {
                            route.Points.RemoveRange(0,
                                route.Points.Count - numTrackLength);
                        }
                        // add new route point
                        if (COMInterface.comPort.MAV.cs.lat != 0 && COMInterface.comPort.MAV.cs.lng != 0)
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

                            foreach (MAVLink.mavlink_mission_item_t plla in COMInterface.comPort.MAV.wps.Values)
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

                                    if (plla.seq <= COMInterface.comPort.MAV.cs.wpno)
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

                            travdist -= COMInterface.comPort.MAV.cs.wp_dist;

                            // if (COMInterface.comPort.MAV.cs.mode.ToUpper() == "AUTO")
                            // distanceBar1.traveleddist = travdist;

                            //RegeneratePolygon();

                            // update rally points

                            //rallypointoverlay.Markers.Clear();

                            //foreach (var mark in COMInterface.comPort.MAV.rallypoints.Values)
                            //{
                            //    rallypointoverlay.Markers.Add(new GMapMarkerRallyPt(mark));
                            //} 坑5

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
                        if (COMInterface.comPort.MAV.cs.MovingBase != null)
                        {
                            addMissionRouteMarker(new GMarkerGoogle(currentloc, GMarkerGoogleType.blue_dot)
                            {
                                Position = COMInterface.comPort.MAV.cs.MovingBase,
                                ToolTipText = "Moving Base",
                                ToolTipMode = MarkerTooltipMode.OnMouseOver
                            });
                        }

                        // add gimbal point center
                        try
                        {
                            if (COMInterface.comPort.MAV.param.ContainsKey("MNT_STAB_TILT"))
                            {
                                float temp1 = (float)COMInterface.comPort.MAV.param["MNT_STAB_TILT"];
                                float temp2 = (float)COMInterface.comPort.MAV.param["MNT_STAB_ROLL"];

                                float temp3 = (float)COMInterface.comPort.MAV.param["MNT_TYPE"];

                                if (COMInterface.comPort.MAV.param.ContainsKey("MNT_STAB_PAN") &&
                                    // (float)COMInterface.comPort.MAV.param["MNT_STAB_PAN"] == 1 &&
                                    ((float)COMInterface.comPort.MAV.param["MNT_STAB_TILT"] == 1 &&
                                      (float)COMInterface.comPort.MAV.param["MNT_STAB_ROLL"] == 0) ||
                                     (float)COMInterface.comPort.MAV.param["MNT_TYPE"] == 4) // storm driver
                                {
                                    var marker = GimbalPoint.ProjectPoint();

                                    if (marker != PointLatLngAlt.Zero)
                                    {
                                        COMInterface.comPort.MAV.cs.GimbalPoint = marker;

                                        addMissionRouteMarker(new GMarkerGoogle(marker, GMarkerGoogleType.blue_dot)
                                        {
                                            ToolTipText = "Camera Target\n" + marker,
                                            ToolTipMode = MarkerTooltipMode.OnMouseOver
                                        });
                                    }
                                }
                            }


                            // cleanup old - no markers where added, so remove all old 
                            //if (COMInterface.comPort.MAV.camerapoints.Count == 0)
                            //    photosoverlay.Markers.Clear();

                            var min_interval = 0.0;
                            if (COMInterface.comPort.MAV.param.ContainsKey("CAM_MIN_INTERVAL"))
                                min_interval = COMInterface.comPort.MAV.param["CAM_MIN_INTERVAL"].Value / 1000.0;

                            // set fov's based on last grid calc
                            if (Settings.Instance["camera_fovh"] != null)
                            {
                                GMapMarkerPhoto.hfov = Settings.Instance.GetDouble("camera_fovh");
                                GMapMarkerPhoto.vfov = Settings.Instance.GetDouble("camera_fovv");
                            }

                            // add new - populate camera_feedback to map
                            /*
                           double oldtime = double.MinValue;

                           
                           foreach (var mark in COMInterface.comPort.MAV.camerapoints.ToArray())
                           {
                               var timesincelastshot = (mark.time_usec / 1000.0) / 1000.0 - oldtime;
                               COMInterface.comPort.MAV.cs.timesincelastshot = timesincelastshot;
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
                           int camcount = COMInterface.comPort.MAV.camerapoints.Count;
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
                                           COMInterface.comPort.MAV.GMapMarkerOverlapCount.Add(
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
                               if (!kmlpolygons.Markers.Contains(COMInterface.comPort.MAV.GMapMarkerOverlapCount) &&
                                   camcount > 0)
                               {
                                   kmlpolygons.Markers.Clear();
                                   kmlpolygons.Markers.Add(COMInterface.comPort.MAV.GMapMarkerOverlapCount);
                               }
                           }
                           else if (kmlpolygons.Markers.Contains(COMInterface.comPort.MAV.GMapMarkerOverlapCount))
                           {
                               kmlpolygons.Markers.Clear();
                           }
                          */
                        }
                        catch
                        {
                        }


                       
                        lock (this.adsblock)
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

                            foreach (adsb.PointLatLngAltHdg plla in this.adsbPlanes.Values)
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
                            if (COMInterface.comPort.MAV.cs.mode.ToLower() == "guided" && COMInterface.comPort.MAV.GuidedMode.x != 0)
                            {
                                addpolygonmarker("Guided Mode", COMInterface.comPort.MAV.GuidedMode.y,
                                    COMInterface.comPort.MAV.GuidedMode.x, (int)COMInterface.comPort.MAV.GuidedMode.z, Color.Blue,
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

        void comPort_MavChanged(object sender, EventArgs e)
        {
             
              

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

        private void initMap()
        {
            SetMenuBtnColor("btnFlighData");
            this.myGMAP1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }


        private void SetMenuBtnColor(string selectBtnName)
        {

            this.btnFlighData.BackColor = getButtonDefualtColor();
            this.btnPlanningCourse.BackColor = getButtonDefualtColor();
            this.btnParameterSetting.BackColor = getButtonDefualtColor();

            this.btnFlighData.ForeColor = getTitleDefualtColor();
            this.btnPlanningCourse.ForeColor = getTitleDefualtColor();
            this.btnParameterSetting.ForeColor = getTitleDefualtColor();

            switch (selectBtnName)
            {
                case "btnFlighData":
                    this.btnFlighData.BackColor = getButtonSelectColor();
                    this.btnFlighData.ForeColor = getTitleSelectColor();
                    break;
                case "btnPlanningCourse":
                    this.btnPlanningCourse.BackColor = getButtonSelectColor();
                    this.btnPlanningCourse.ForeColor = getTitleSelectColor();
                    break;
                case "btnParameterSetting":
                    this.btnParameterSetting.BackColor = getButtonSelectColor();
                    this.btnParameterSetting.ForeColor = getTitleSelectColor();
                    break;

            }
        }

        private Color getTitleDefualtColor()
        {
            return Color.FromArgb(255, 255, 255);
        }

        private Color getTitleSelectColor()
        {
            return Color.FromArgb(47, 113, 180);
        }

        private Color getButtonDefualtColor()
        {
            return Color.FromArgb(43, 51, 60);
        }

        private Color getButtonSelectColor()
        {
            return Color.FromArgb(255, 255, 255);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void initWidget()
        {
            this.cboProtocolType.SelectedIndex = 0;
            this.cboPort.SelectedIndex = 0;
        }


        private void btnFlighData_MouseEnter(object sender, EventArgs e)
        {
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            int index = 0;
            switch (name)
            {
                case "btnFlighData":
                    index = 0;
                    break;
                case "btnPlanningCourse":
                    index = 1;
                    break;
                case "btnParameterSetting":
                    index = 2;
                    break;

            }
            SetMenuBtnColor(name);

            this.TabContent.SelectedIndex = index;
        }

        private void btnParameterSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnFlighData_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            doConnect(COMInterface.comPort,this.cboProtocolType.Text,this.cboPort.Text);


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

                //CheckBatteryShow();   TODO 

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
                if (COMInterface.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(COMInterface.comPort.MAV.param["RALLY_TOTAL"].ToString()) > 0)
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
        private void labYaw_Click(object sender, EventArgs e)
        {

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


                object updateBindingSourcelock = new object();
        volatile int updateBindingSourcecount;
        string updateBindingSourceThreadName = "";

        internal object adsblock = new object();
        private void addMissionRouteMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Add(marker);
            });
        }
        DateTime lastscreenupdate = DateTime.Now;
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
                    //COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSource1);
                    //Console.Write("bindingSourceHud ");
                    COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                    //Console.WriteLine("DONE ");

                    /*
                    if (tabControlactions.SelectedTab == tabStatus)
                    {
                        COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceStatusTab);
                    }
                    else if (tabControlactions.SelectedTab == tabQuick)
                    {
                        COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceQuickTab);
                    }
                    else if (tabControlactions.SelectedTab == tabGauges)
                    {
                        COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }
                    else if (tabControlactions.SelectedTab == tabPagePreFlight)
                    {
                        COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    }*/
                }
                else
                {
                    //Console.WriteLine("Null Binding");
                    COMInterface.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceHud);
                }
                lastscreenupdate = DateTime.Now;
            }
            catch
            {
            }
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
                        //mBorders.wprad =
                        //    (int)(float.Parse(TXT_WPRad.EditValue.ToString()) / CurrentState.multiplierdist); //TODO
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

        private void updateClearMissionRouteMarkers()
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                //polygons.Routes.Clear(); 坑2
                //polygons.Markers.Clear(); 坑3
                // routes.Markers.Clear();坑4
            });
        }
        private void updateClearRoutesMarkers()
        {
            Invoke((MethodInvoker)delegate
            {
                //routes.Markers.Clear(); 坑1
            });
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
                        (COMInterface.comPort.logreadmode || COMInterface.comPort.BaseStream.IsOpen))
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
                            COMInterface.comPort.MAV.cs.battery_voltage <= warnvolt &&
                            COMInterface.comPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (COMInterface.comPort.MAV.cs.battery_remaining) < warnpercent &&
                                 COMInterface.comPort.MAV.cs.battery_voltage >= 5.0 &&
                                 COMInterface.comPort.MAV.cs.battery_remaining != 0.0)
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
                        (COMInterface.comPort.logreadmode || COMInterface.comPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && COMInterface.comPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (COMInterface.comPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainForm.speechEngine.IsReady)
                                {
                                    MainForm.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (COMInterface.comPort.MAV.cs.groundspeed < warngroundspeed)
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
                        (COMInterface.comPort.logreadmode || COMInterface.comPort.BaseStream.IsOpen))
                    {
                        float warnalt = float.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }
                        try
                        {
                            int todo; // need a reset method
                            altwarningmax = (int)Math.Max(COMInterface.comPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && COMInterface.comPort.MAV.cs.alt != 0.00 &&
                                (COMInterface.comPort.MAV.cs.alt <= warnalt) && COMInterface.comPort.MAV.cs.armed)
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
                                lastmessagehigh != COMInterface.comPort.MAV.cs.messageHigh && COMInterface.comPort.MAV.cs.messageHigh != null)
                            {
                                if (!COMInterface.comPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainForm.speechEngine.SpeakAsync(COMInterface.comPort.MAV.cs.messageHigh);
                                    lastmessagehigh = COMInterface.comPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - COMInterface.comPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            COMInterface.comPort.MAV.cs.linkqualitygcs = (ushort)(COMInterface.comPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw is no other packets are being read
                            //hud1.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - COMInterface.comPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (COMInterface.comPort.logreadmode || COMInterface.comPort.BaseStream.IsOpen)
                        && COMInterface.comPort.MAV.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - COMInterface.comPort.MAV.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != COMInterface.comPort.MAV.cs.armed && COMInterface.comPort.BaseStream.IsOpen)
                    {
                        armedstatus = COMInterface.comPort.MAV.cs.armed;
                        // status just changed to armed
                        if (COMInterface.comPort.MAV.cs.armed == true && COMInterface.comPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            try
                            {
                                COMInterface.comPort.MAV.cs.HomeLocation = new PointLatLngAlt(COMInterface.comPort.getWP(0));
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
                                                                  COMInterface.comPort.MAV.sysid + ")");
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
                                    if (port == COMInterface.comPort)
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
                    if (!COMInterface.comPort.BaseStream.IsOpen || COMInterface.comPort.giveComport == true)
                    {
                        if (!COMInterface.comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    COMInterface.comPort = port;
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
                            if (port == COMInterface.comPort)
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
                        COMInterface.comPort.Close();
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


        private void updateHomeText()
        {
            // set home location
            if (MainForm.comPort.MAV.cs.HomeLocation.Lat != 0 && MainForm.comPort.MAV.cs.HomeLocation.Lng != 0)
            {
                //TXT_homelat.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Lat.ToString();

                //TXT_homelng.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Lng.ToString();

                //TXT_homealt.EditValue = MainForm.comPort.MAV.cs.HomeLocation.Alt.ToString();

                //writeKML();
            }
        }
   

    }

}
