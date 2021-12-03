using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGaugeApp;
using System.IO.Ports;
using System.Threading;
using MissionPlanner.Attributes;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Sockets;
using System.Xml; // config file
using System.Runtime.InteropServices; // dll imports
using log4net;
using ZedGraph; // Graphs
using MissionPlanner;
using System.Reflection;
using MissionPlanner.Utilities;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using FBGroundControl;
using FBGroundControl.chao.models;

namespace MissionPlanner
{


    public class Common
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public enum distances
        {
            Meters,
            Feet
        }

        public enum speeds
        {
            meters_per_second,
            fps,
            kph,
            mph,
            knots
        }


        /// <summary>
        /// from libraries\AP_Math\rotations.h
        /// </summary>
        public enum Rotation
        {
            ROTATION_NONE = 0,
            ROTATION_YAW_45,
            ROTATION_YAW_90,
            ROTATION_YAW_135,
            ROTATION_YAW_180,
            ROTATION_YAW_225,
            ROTATION_YAW_270,
            ROTATION_YAW_315,
            ROTATION_ROLL_180,
            ROTATION_ROLL_180_YAW_45,
            ROTATION_ROLL_180_YAW_90,
            ROTATION_ROLL_180_YAW_135,
            ROTATION_PITCH_180,
            ROTATION_ROLL_180_YAW_225,
            ROTATION_ROLL_180_YAW_270,
            ROTATION_ROLL_180_YAW_315,
            ROTATION_ROLL_90,
            ROTATION_ROLL_90_YAW_45,
            ROTATION_ROLL_90_YAW_90,
            ROTATION_ROLL_90_YAW_135,
            ROTATION_ROLL_270,
            ROTATION_ROLL_270_YAW_45,
            ROTATION_ROLL_270_YAW_90,
            ROTATION_ROLL_270_YAW_135,
            ROTATION_PITCH_90,
            ROTATION_PITCH_270,
            ROTATION_MAX
        }


        public enum ap_product
        {
            [DisplayText("HIL")]
            AP_PRODUCT_ID_NONE = 0x00, // Hardware in the loop
            [DisplayText("APM1 1280")]
            AP_PRODUCT_ID_APM1_1280 = 0x01, // APM1 with 1280 CPUs
            [DisplayText("APM1 2560")]
            AP_PRODUCT_ID_APM1_2560 = 0x02, // APM1 with 2560 CPUs
            [DisplayText("SITL")]
            AP_PRODUCT_ID_SITL = 0x03, // Software in the loop
            [DisplayText("PX4")]
            AP_PRODUCT_ID_PX4 = 0x04, // PX4 on NuttX
            [DisplayText("PX4 FMU 2")]
            AP_PRODUCT_ID_PX4_V2 = 0x05, // PX4 FMU2 on NuttX
            [DisplayText("APM2 ES C4")]
            AP_PRODUCT_ID_APM2ES_REV_C4 = 0x14, // APM2 with MPU6000ES_REV_C4
            [DisplayText("APM2 ES C5")]
            AP_PRODUCT_ID_APM2ES_REV_C5 = 0x15, // APM2 with MPU6000ES_REV_C5
            [DisplayText("APM2 ES D6")]
            AP_PRODUCT_ID_APM2ES_REV_D6 = 0x16, // APM2 with MPU6000ES_REV_D6
            [DisplayText("APM2 ES D7")]
            AP_PRODUCT_ID_APM2ES_REV_D7 = 0x17, // APM2 with MPU6000ES_REV_D7
            [DisplayText("APM2 ES D8")]
            AP_PRODUCT_ID_APM2ES_REV_D8 = 0x18, // APM2 with MPU6000ES_REV_D8	
            [DisplayText("APM2 C4")]
            AP_PRODUCT_ID_APM2_REV_C4 = 0x54, // APM2 with MPU6000_REV_C4 	
            [DisplayText("APM2 C5")]
            AP_PRODUCT_ID_APM2_REV_C5 = 0x55, // APM2 with MPU6000_REV_C5 	
            [DisplayText("APM2 D6")]
            AP_PRODUCT_ID_APM2_REV_D6 = 0x56, // APM2 with MPU6000_REV_D6 		
            [DisplayText("APM2 D7")]
            AP_PRODUCT_ID_APM2_REV_D7 = 0x57, // APM2 with MPU6000_REV_D7 	
            [DisplayText("APM2 D8")]
            AP_PRODUCT_ID_APM2_REV_D8 = 0x58, // APM2 with MPU6000_REV_D8 	
            [DisplayText("APM2 D9")]
            AP_PRODUCT_ID_APM2_REV_D9 = 0x59, // APM2 with MPU6000_REV_D9 
            [DisplayText("FlyMaple")]
            AP_PRODUCT_ID_FLYMAPLE = 0x100, // Flymaple with ITG3205, ADXL345, HMC5883, BMP085
            [DisplayText("Linux")]
            AP_PRODUCT_ID_L3G4200D = 0x101, // Linux with L3G4200D and ADXL345
        }

        public static bool getFilefromNet(string url, string saveto)
        {
            try
            {
                // this is for mono to a ssl server
                //ServicePointManager.CertificatePolicy = new NoCheckCertificatePolicy(); 

                ServicePointManager.ServerCertificateValidationCallback =
                    new System.Net.Security.RemoteCertificateValidationCallback(
                        (sender, certificate, chain, policyErrors) => { return true; });

                log.Info(url);
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 10000;
                // Set the Method property of the request to POST.
                request.Method = "GET";
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                log.Info(((HttpWebResponse)response).StatusDescription);
                if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    return false;

                if (File.Exists(saveto))
                {
                    DateTime lastfilewrite = new FileInfo(saveto).LastWriteTime;
                    DateTime lasthttpmod = ((HttpWebResponse)response).LastModified;

                    if (lasthttpmod < lastfilewrite)
                    {
                        if (((HttpWebResponse)response).ContentLength == new FileInfo(saveto).Length)
                        {
                            log.Info("got LastModified " + saveto + " " + ((HttpWebResponse)response).LastModified +
                                     " vs " + new FileInfo(saveto).LastWriteTime);
                            response.Close();
                            return true;
                        }
                    }
                }

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                long bytes = response.ContentLength;
                long contlen = bytes;

                byte[] buf1 = new byte[1024];

                if (!Directory.Exists(Path.GetDirectoryName(saveto)))
                    Directory.CreateDirectory(Path.GetDirectoryName(saveto));

                FileStream fs = new FileStream(saveto + ".new", FileMode.Create);

                DateTime dt = DateTime.Now;

                while (dataStream.CanRead && bytes > 0)
                {
                    Application.DoEvents();
                    log.Debug(saveto + " " + bytes);
                    int len = dataStream.Read(buf1, 0, buf1.Length);
                    bytes -= len;
                    fs.Write(buf1, 0, len);
                }

                fs.Close();
                dataStream.Close();
                response.Close();

                File.Delete(saveto);
                File.Move(saveto + ".new", saveto);

                return true;
            }
            catch (Exception ex)
            {
                log.Info("getFilefromNet(): " + ex.ToString());
                return false;
            }
        }

        //from px4firmwareplugin.cc
        enum PX4_CUSTOM_MAIN_MODE
        {
            PX4_CUSTOM_MAIN_MODE_MANUAL = 1,
            PX4_CUSTOM_MAIN_MODE_ALTCTL,
            PX4_CUSTOM_MAIN_MODE_POSCTL,
            PX4_CUSTOM_MAIN_MODE_AUTO,
            PX4_CUSTOM_MAIN_MODE_ACRO,
            PX4_CUSTOM_MAIN_MODE_OFFBOARD,
            PX4_CUSTOM_MAIN_MODE_STABILIZED,
            PX4_CUSTOM_MAIN_MODE_RATTITUDE
        }

        enum PX4_CUSTOM_SUB_MODE_AUTO
        {
            PX4_CUSTOM_SUB_MODE_AUTO_READY = 1,
            PX4_CUSTOM_SUB_MODE_AUTO_TAKEOFF,
            PX4_CUSTOM_SUB_MODE_AUTO_LOITER,
            PX4_CUSTOM_SUB_MODE_AUTO_MISSION,
            PX4_CUSTOM_SUB_MODE_AUTO_RTL,
            PX4_CUSTOM_SUB_MODE_AUTO_LAND,
            PX4_CUSTOM_SUB_MODE_AUTO_RTGS
        }

        public static List<KeyValuePair<int, string>> getLoiterDirList(CurrentState cs)
        {
            var temp = new List<KeyValuePair<int, string>>()
               {
                   new KeyValuePair<int, string>((int) JYLink.JY_LOITERDIR_ID.Clockwise, "顺时针"),
                   new KeyValuePair<int, string>((int) JYLink.JY_LOITERDIR_ID.AntiClockwise, "逆时针"),
                  
               };
            return temp;
        }
        public static List<KeyValuePair<int, string>> getEcuDirList(CurrentState cs)
        {
            var temp = new List<KeyValuePair<int, string>>()
               {

                    //泵 (01H)
                    //点火 (02H)
                    //吸油CHOKE (03H)
                    //转速 (04H)
                    //熄火 (05H)

                   new KeyValuePair<int, string>((int) JYLink.JY_EcuDir_ID.Pump, "泵"),
                   new KeyValuePair<int, string>((int) JYLink.JY_EcuDir_ID.Ignition, "点火"),
                   new KeyValuePair<int, string>((int) JYLink.JY_EcuDir_ID.OilAbsorption, "吸油CHOKE"),
                   new KeyValuePair<int, string>((int) JYLink.JY_EcuDir_ID.Speed, "转速"),
                   new KeyValuePair<int, string>((int) JYLink.JY_EcuDir_ID.Flameout, "熄火")
                  
               };
            return temp;
        }

        public static List<KeyValuePair<int, string>> getTakeOffDirList(CurrentState cs)
        {
            var temp = new List<KeyValuePair<int, string>>()
               {
                   new KeyValuePair<int, string>((int) JYLink.JY_TakeOffDIR_ID.PlanningRun, "滑跑起飞"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TakeOffDIR_ID.Ejection, "弹射起飞"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TakeOffDIR_ID.RocketAssisted, "火箭助推")
                  
               };
            return temp;
        }
        public static List<KeyValuePair<int, string>> SteerActionDirList(CurrentState cs)
        {
            var temp = new List<KeyValuePair<int, string>>()
               {
                   new KeyValuePair<int, string>((int) JYLink.JY_SteerAction_ID.Rise, "飞机抬头"),
                   new KeyValuePair<int, string>((int) JYLink.JY_SteerAction_ID.Bow, "飞机低头"),
                   new KeyValuePair<int, string>((int) JYLink.JY_SteerAction_ID.LeftRoll, "飞机左横滚"),
                   new KeyValuePair<int, string>((int) JYLink.JY_SteerAction_ID.RightRoll, "飞机右横滚")
                  
               };
            return temp;
        }
        public static List<KeyValuePair<int, string>> getModesList(CurrentState cs)
        {
            log.Info("getModesList Called");
            if (cs.firmware == MainForm.Firmwares.JYPlane)
            {
                var temp = new List<KeyValuePair<int, string>>()
               {
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Manual, "Manual"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Stabilize, "Stabilize"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Alt_Hold, "Alt_Hold"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Loiter, "Loiter"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Longitudinal, "Longitudinal"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Guided, "Guided"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.RTL, "RTL"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Mot_ContinueRoll, "Mot_ContinueRoll"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Mot_AnglePitch, "Mot_AnglePitch"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Mot_LevelTurn, "Mot_LevelTurn"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Mot_YMM_Motorized, "Mot_YMM_Motorized"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Mot_Loop, "Mot_Loop"),
                   new KeyValuePair<int, string>((int) JYLink.JY_FLIGHTMODE_ID.Auto, "Auto"),
               };
                return temp;
            }
            if (cs.firmware == MainForm.Firmwares.PX4)
            {
                /*
union px4_custom_mode {
    struct {
        uint16_t reserved;
        uint8_t main_mode;
        uint8_t sub_mode;
    };
    uint32_t data;
    float data_float;
};
                 */


                var temp = new List<KeyValuePair<int, string>>()
                {
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_MANUAL << 16, "Manual"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_ACRO << 16, "Acro"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_STABILIZED << 16,
                        "Stabalized"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_RATTITUDE << 16,
                        "Rattitude"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_ALTCTL << 16,
                        "Altitude Control"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_POSCTL << 16,
                        "Position Control"),
                    new KeyValuePair<int, string>((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_OFFBOARD << 16,
                        "Offboard Control"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_READY << 24, "Auto: Ready"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_TAKEOFF << 24, "Auto: Takeoff"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_LOITER << 24, "Loiter"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_MISSION << 24, "Auto"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_RTL << 24, "RTL"),
                    new KeyValuePair<int, string>(
                        ((int) PX4_CUSTOM_MAIN_MODE.PX4_CUSTOM_MAIN_MODE_AUTO << 16) +
                        (int) PX4_CUSTOM_SUB_MODE_AUTO.PX4_CUSTOM_SUB_MODE_AUTO_LAND << 24, "Auto: Landing")
                };

                return temp;
            }
            else if (cs.firmware == MainForm.Firmwares.ArduPlane)
            {
                var flightModes = Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("FLTMODE1",
                    cs.firmware.ToString());
                flightModes.Add(new KeyValuePair<int, string>(16, "INITIALISING"));

                flightModes.Add(new KeyValuePair<int, string>(17, "QStabilize"));
                flightModes.Add(new KeyValuePair<int, string>(18, "QHover"));
                flightModes.Add(new KeyValuePair<int, string>(19, "QLoiter"));
                flightModes.Add(new KeyValuePair<int, string>(20, "QLand"));
                flightModes.Add(new KeyValuePair<int, string>(21, "QRTL"));

                return flightModes;
            }
            else if (cs.firmware == MainForm.Firmwares.Ateryx)
            {
                var flightModes = Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("FLTMODE1",
                    cs.firmware.ToString()); //same as apm
                return flightModes;
            }
            else if (cs.firmware == MainForm.Firmwares.ArduCopter2)
            {
                var flightModes = Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("FLTMODE1",
                    cs.firmware.ToString());
                return flightModes;
            }
            else if (cs.firmware == MainForm.Firmwares.ArduRover)
            {
                var flightModes = Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("MODE1",
                    cs.firmware.ToString());
                return flightModes;
            }
            else if (cs.firmware == MainForm.Firmwares.ArduTracker)
            {
                var temp = new List<KeyValuePair<int, string>>();
                temp.Add(new KeyValuePair<int, string>(0, "MANUAL"));
                temp.Add(new KeyValuePair<int, string>(1, "STOP"));
                temp.Add(new KeyValuePair<int, string>(2, "SCAN"));
                temp.Add(new KeyValuePair<int, string>(3, "SERVO_TEST"));
                temp.Add(new KeyValuePair<int, string>(10, "AUTO"));
                temp.Add(new KeyValuePair<int, string>(16, "INITIALISING"));

                return temp;
            }

            return null;
        }

        public static Form LoadingBox(string title, string promptText)
        {
            Form form = new Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            form.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            form.Text = title;
            label.Text = promptText;

            label.SetBounds(9, 50, 372, 13);

            label.AutoSize = true;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;



            form.Show();
            form.Refresh();
            label.Refresh();
            Application.DoEvents();
            return form;
        }

        public static DialogResult MessageShowAgain(string title, string promptText)
        {
            Form form = new Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            CheckBox chk = new CheckBox();
            Controls.MyButton buttonOk = new Controls.MyButton();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            form.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            form.Text = title;
            label.Text = promptText;

            chk.Tag = ("SHOWAGAIN_" + title.Replace(" ", "_").Replace('+', '_'));
            chk.AutoSize = true;
            chk.Text = Strings.ShowMeAgain;
            chk.Checked = true;
            chk.Location = new Point(9, 80);

            if (Settings.Instance.GetBoolean((string)chk.Tag) == false)
            // skip it
            {
                form.Dispose();
                chk.Dispose();
                buttonOk.Dispose();
                label.Dispose();
                return DialogResult.OK;
            }

            chk.CheckStateChanged += new EventHandler(chk_CheckStateChanged);

            buttonOk.Text = Strings.OK;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(form.Right - 100, 80);

            label.SetBounds(9, 40, 372, 13);

            label.AutoSize = true;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, chk, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;



            DialogResult dialogResult = form.ShowDialog();

            form.Dispose();

            form = null;

            return dialogResult;
        }

        static void chk_CheckStateChanged(object sender, EventArgs e)
        {
            Settings.Instance[(string)((CheckBox)(sender)).Tag] = ((CheckBox)(sender)).Checked.ToString();
        }

        public static string speechConversion(string input)
        {
            if (MainForm.comPort.JY.cs.wpno == 0)
            {
                input = input.Replace("{wpn}", "Home");
            }
            else
            {
                input = input.Replace("{wpn}", MainForm.comPort.JY.cs.wpno.ToString());
            }

            input = input.Replace("{asp}", MainForm.comPort.JY.cs.airspeed.ToString("0"));

            input = input.Replace("{alt}", MainForm.comPort.JY.cs.alt.ToString("0"));

            input = input.Replace("{wpa}", MainForm.comPort.JY.cs.targetalt.ToString("0"));

            input = input.Replace("{gsp}", MainForm.comPort.JY.cs.groundspeed.ToString("0"));

            input = input.Replace("{mode}", MainForm.comPort.JY.cs.mode.ToString());

            input = input.Replace("{runmode}", MainForm.comPort.JY.cs.runmode.ToString());

            input = input.Replace("{change_mode}", MainForm.comPort.JY.cs.change_mode.ToString());

            input = input.Replace("{batv}", MainForm.comPort.JY.cs.battery_voltage.ToString("0.00"));

            input = input.Replace("{batp}", (MainForm.comPort.JY.cs.battery_remaining).ToString("0"));

            input = input.Replace("{vsp}", (MainForm.comPort.JY.cs.verticalspeed).ToString("0.0"));

            input = input.Replace("{curr}", (MainForm.comPort.JY.cs.current).ToString("0.0"));

            input = input.Replace("{hdop}", (MainForm.comPort.JY.cs.gpshdop).ToString("0.00"));

            input = input.Replace("{satcount}", (MainForm.comPort.JY.cs.satcount).ToString("0"));

            input = input.Replace("{rssi}", (MainForm.comPort.JY.cs.rssi).ToString("0"));

            input = input.Replace("{disthome}", (MainForm.comPort.JY.cs.DistToHome).ToString("0"));

            input = input.Replace("{timeinair}",(new TimeSpan(0, 0, 0, (int)MainForm.comPort.JY.cs.timeInAir)).ToString());

            try
            {
                object thisBoxed = MainForm.comPort.JY.cs;
                Type test = thisBoxed.GetType();

                PropertyInfo[] props = test.GetProperties();

                //props
                foreach (var field in props)
                {
                    // field.Name has the field's name.
                    object fieldValue;
                    TypeCode typeCode;
                    try
                    {
                        fieldValue = field.GetValue(thisBoxed, null); // Get value

                        if (fieldValue == null)
                            continue;
                        // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                        typeCode = Type.GetTypeCode(fieldValue.GetType());
                    }
                    catch
                    {
                        continue;
                    }

                    var fname = String.Format("{{{0}}}", field.Name);
                    input = input.Replace(fname, fieldValue.ToString());
                }
            }
            catch
            {

            }

            return input;
        }
        /// <summary>
        /// 创建自定义飞机模型
        /// </summary>
        /// <param name="MAV"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static GMapMarker addNewPlane(JYState MAV, AircraftModel planeModel)
        {

            Bitmap plane;
            if (planeModel.colorID == 1)
            {
                plane = global::FBGroundControl.Properties.Resources.planeicon;
            }
            else if (planeModel.colorID == 2)
            {
                plane = global::FBGroundControl.Properties.Resources.quadicon2;
            }
            else if (planeModel.colorID == 3)
            {
                plane = global::FBGroundControl.Properties.Resources.quadicon3;
            }
            else if (planeModel.colorID == 4)
            {
                plane = global::FBGroundControl.Properties.Resources.quadicon4;
            }
            else if (planeModel.colorID == 5)
            {
                plane = global::FBGroundControl.Properties.Resources.quadicon5;
            }
            else
            {
                plane = global::FBGroundControl.Properties.Resources.planeicon;
            }

            PointLatLng portlocation = new PointLatLng(MAV.cs.lat, MAV.cs.lng);
            return (new GMapMarkerQuad(portlocation, MAV.cs.yaw,
                    MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid, plane, planeModel));
        }
        //点击图片时更换飞机 目前是测试代码 by lichao
        public static GMapMarker getMyPlane(JYState JY)
        {
            PointLatLng portlocation = new PointLatLng(JY.cs.lat, JY.cs.lng);
            return (new GMapMarkerQuad(portlocation, JY.cs.yaw,
                    JY.cs.groundcourse, JY.cs.nav_bearing, JY.sysid));
            //if (MAV.cs.firmware == MainForm.Firmwares.ArduCopter2 || MAV.aptype == MAVLink.MAV_TYPE.QUADROTOR)
            //{
            //    if (MAV.param.ContainsKey("AVD_W_DIST_XY") && MAV.param.ContainsKey("AVD_F_DIST_XY"))
            //    {
            //        var w = MAV.param["AVD_W_DIST_XY"].Value;
            //        var f = MAV.param["AVD_F_DIST_XY"].Value;
            //        return (new GMapMarkerQuad(portlocation, MAV.cs.yaw,
            //            MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid)
            //        {
            //            danger = (int)f,
            //            warn = (int)w
            //        });
            //    }

            //    return (new GMapMarkerQuad(portlocation, MAV.cs.yaw,
            //        MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid));
            //}
            //else {
            //    return null;
            //}
        }
        public static GMapMarker getMAVMarker(JYState MAV)
        {
            PointLatLng portlocation = new PointLatLng(MAV.cs.lat, MAV.cs.lng);
            return null;
        }

        //    if (JY.aptype == JYLink.JY_TYPE.FIXED_WING)
        //    {
        //        return (new GMapMarkerPlane(portlocation, MAV.cs.yaw,
        //            MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.cs.target_bearing, MAV.cs.radius)
        //        {
        //            ToolTipText = MAV.cs.alt.ToString("0"),
        //            ToolTipMode = MarkerTooltipMode.Always
        //        });
        //    }
        //    //else if (MAV.aptype == MAVLink.MAV_TYPE.GROUND_ROVER)
        //    //{
        //    //    return  (new GMapMarkerRover(portlocation, MAV.cs.yaw,
        //    //        MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.cs.target_bearing));
        //    //}
        //    //else if (MAV.aptype == MAVLink.MAV_TYPE.HELICOPTER)
        //    //{
        //    //    return (new GMapMarkerHeli(portlocation, MAV.cs.yaw,
        //    //        MAV.cs.groundcourse, MAV.cs.nav_bearing));
        //    //}
        //    else if (MAV.cs.firmware == MainForm.Firmwares.ArduTracker)
        //    {
        //        return (new GMapMarkerAntennaTracker(portlocation, MAV.cs.yaw,
        //            MAV.cs.target_bearing));
        //    }
        //    //else if (MAV.cs.firmware == MainForm.Firmwares.ArduCopter2 || MAV.aptype == MAVLink.MAV_TYPE.QUADROTOR)
        //    //{
        //    //    if (MAV.param.ContainsKey("AVD_W_DIST_XY") && MAV.param.ContainsKey("AVD_F_DIST_XY"))
        //    //    {
        //    //        var w = MAV.param["AVD_W_DIST_XY"].Value;
        //    //        var f = MAV.param["AVD_F_DIST_XY"].Value;
        //    //        return (new GMapMarkerQuad(portlocation, MAV.cs.yaw,
        //    //            MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid)
        //    //        {
        //    //            danger = (int)f,
        //    //            warn = (int)w
        //    //        });
        //    //    }

        //    //    return (new GMapMarkerQuad(portlocation, MAV.cs.yaw,
        //    //        MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid));
        //    //}
        //    //else if (MAV.aptype == MAVLink.MAV_TYPE.COAXIAL)
        //    //{
        //    //    return (new GMapMarkerSingle(portlocation, MAV.cs.yaw,
        //    //       MAV.cs.groundcourse, MAV.cs.nav_bearing, MAV.sysid));
        //    //}
        //    else
        //    {
        //        // unknown type
        //        return (new GMarkerGoogle(portlocation, GMarkerGoogleType.green_dot));
        //    }
        //}
        //}

        /// <summary>
        /// used to override the drawing of the waypoint box bounding
        /// </summary>
        [Serializable]
        public class GMapMarkerRect : GMapMarker
        {
            public Pen Pen = new Pen(Brushes.White, 2);

            public Color Color
            {
                get { return Pen.Color; }
                set
                {
                    if (!initcolor.HasValue) initcolor = value;
                    Pen.Color = value;
                }
            }

            Color? initcolor = null;

            public GMapMarker InnerMarker;

            public int wprad = 0;

            public void ResetColor()
            {
                if (initcolor.HasValue)
                    Color = initcolor.Value;
                else
                    Color = Color.White;
            }

            public GMapMarkerRect(PointLatLng p)
                : base(p)
            {
                Pen.DashStyle = DashStyle.Dash;

                // do not forget set Size of the marker
                // if so, you shall have no event on it ;}
                Size = new System.Drawing.Size(50, 50);
                Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2 - 20);
            }

            public override void OnRender(Graphics g)
            {
                base.OnRender(g);

                if (wprad == 0 || Overlay.Control == null)
                    return;

                // if we have drawn it, then keep that color
                if (!initcolor.HasValue)
                    Color = Color.White;

                // undo autochange in mouse over
                //if (Pen.Color == Color.Blue)
                //  Pen.Color = Color.White;

                double width =
                    (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                        Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0)) * 1000.0);
                double height =
                    (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                        Overlay.Control.FromLocalToLatLng(Overlay.Control.Height, 0)) * 1000.0);
                double m2pixelwidth = Overlay.Control.Width / width;
                double m2pixelheight = Overlay.Control.Height / height;

                GPoint loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * wprad * 2)), LocalPosition.Y);
                // MainMap.FromLatLngToLocal(wpradposition);

                if (m2pixelheight > 0.5)
                    g.DrawArc(Pen,
                        new System.Drawing.Rectangle(
                            LocalPosition.X - Offset.X - (int)(Math.Abs(loc.X - LocalPosition.X) / 2),
                            LocalPosition.Y - Offset.Y - (int)Math.Abs(loc.X - LocalPosition.X) / 2,
                            (int)Math.Abs(loc.X - LocalPosition.X), (int)Math.Abs(loc.X - LocalPosition.X)), 0, 360);
            }
        }

        [Serializable]
        public class GMapMarkerADSBPlane : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private static readonly Bitmap icong = new Bitmap(global::FBGroundControl.Properties.Resources.FW_icons_2013_logos_01, new Size(40, 40));
            private static readonly Bitmap iconr = new Bitmap(global::FBGroundControl.Properties.Resources.FW_icons_2013_logos_011, new Size(40, 40));
            private static readonly Bitmap icono = new Bitmap(global::FBGroundControl.Properties.Resources.FW_icons_2013_logos_012, new Size(40, 40));

            public float heading = 0;
            public AlertLevelOptions AlertLevel = AlertLevelOptions.Green;

            public enum AlertLevelOptions
            {
                Green,
                Orange,
                Red
            }

            public GMapMarkerADSBPlane(PointLatLng p, float heading, AlertLevelOptions alert = AlertLevelOptions.Green)
                : base(p)
            {
                this.AlertLevel = alert;
                this.heading = heading;
                Size = icong.Size;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                g.RotateTransform(-Overlay.Control.Bearing);

                try
                {
                    g.RotateTransform(heading);
                }
                catch
                {
                }

                switch (AlertLevel)
                {
                    case AlertLevelOptions.Green:
                        g.DrawImageUnscaled(icong, icong.Width / -2, icong.Height / -2);
                        break;
                    case AlertLevelOptions.Orange:
                        g.DrawImageUnscaled(icono, icono.Width / -2, icono.Height / -2);
                        break;
                    case AlertLevelOptions.Red:
                        g.DrawImageUnscaled(iconr, iconr.Width / -2, iconr.Height / -2);
                        break;
                }

                g.Transform = temp;
            }
        }

        [Serializable]
        public class GMapMarkerWP : GMarkerGoogle
        {
            string wpno = "";
            public bool selected = false;
            SizeF txtsize = SizeF.Empty;
            static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
            static Font font;

            public GMapMarkerWP(PointLatLng p, string wpno)
                : base(p, GMarkerGoogleType.orange)
            {
                this.wpno = wpno;
                if (font == null)
                    font = SystemFonts.DefaultFont;
                Bitmap temp1 = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
              
                if (!fontBitmaps.ContainsKey(wpno))
                {
                    Bitmap temp = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
                    using (Graphics g = Graphics.FromImage(temp))
                    {
                        //txtsize = g.MeasureString(wpno, font);

                        g.DrawString(wpno, font, Brushes.Black, new PointF(0, 0));
                    }
                    fontBitmaps[wpno] = temp;
                }
            }

            public override void OnRender(Graphics g)
            {
                base.OnRender(g);
                if (selected)
                {
                    g.FillEllipse(Brushes.Red, new Rectangle(this.LocalPosition, this.Size));
                    g.DrawArc(Pens.Red, new Rectangle(this.LocalPosition, this.Size), 0, 360);
                }


                var midw = LocalPosition.X + 10;
                var midh = LocalPosition.Y + 3;

                if (txtsize.Width > 15)
                    midw -= 4;

                if (Overlay.Control.Zoom >= 0 || IsMouseOver)
                {

                    g.DrawImageUnscaled(fontBitmaps[wpno], midw, midh);
                }



            }
        }

        [Serializable]
        public class GMapMarkerRover : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            static readonly System.Drawing.Size SizeSt =
                new System.Drawing.Size(global::FBGroundControl.Properties.Resources.rover.Width,
                    global::FBGroundControl.Properties.Resources.rover.Height);

            float heading = 0;
            float cog = -1;
            float target = -1;
            float nav_bearing = -1;

            public GMapMarkerRover(PointLatLng p, float heading, float cog, float nav_bearing, float target)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.nav_bearing = nav_bearing;
                Size = SizeSt;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                g.RotateTransform(-Overlay.Control.Bearing);

                int length = 500;
                // anti NaN
                try
                {
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                        (float)Math.Sin((heading - 90) * deg2rad) * length);
                }
                catch
                {
                }
                g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length,
                    (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                    (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                    (float)Math.Sin((target - 90) * deg2rad) * length);
                // anti NaN

                try
                {
                    g.RotateTransform(heading);
                }
                catch
                {
                }
                g.DrawImageUnscaled(global::FBGroundControl.Properties.Resources.rover,
                    global::FBGroundControl.Properties.Resources.rover.Width / -2,
                    global::FBGroundControl.Properties.Resources.rover.Height / -2);

                g.Transform = temp;
            }
        }

        [Serializable]
        public class GMapMarkerPlane : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private readonly Bitmap icon = global::FBGroundControl.Properties.Resources.planeicon;

            float heading = 0;
            float cog = -1;
            float target = -1;
            float nav_bearing = -1;
            float radius = -1;

            public GMapMarkerPlane(PointLatLng p, float heading, float cog, float nav_bearing, float target, float radius)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.nav_bearing = nav_bearing;
                this.radius = radius;
                Size = icon.Size;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                g.RotateTransform(-Overlay.Control.Bearing);

                int length = 500;
                // anti NaN
                try
                {
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                        (float)Math.Sin((heading - 90) * deg2rad) * length);
                }
                catch
                {
                }
                g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length,
                    (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                    (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                    (float)Math.Sin((target - 90) * deg2rad) * length);
                // anti NaN
                try
                {
                    float desired_lead_dist = 100;

                    double width =
                        (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                            Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0)) * 1000.0);
                    double m2pixelwidth = Overlay.Control.Width / width;

                    float alpha = ((desired_lead_dist * (float)m2pixelwidth) / radius) * rad2deg;

                    if (radius < -1)
                    {
                        // fixme 

                        float p1 = (float)Math.Cos((cog) * deg2rad) * radius + radius;

                        float p2 = (float)Math.Sin((cog) * deg2rad) * radius + radius;

                        g.DrawArc(new Pen(Color.HotPink, 2), p1, p2, Math.Abs(radius) * 2, Math.Abs(radius) * 2, cog, alpha);
                    }

                    else if (radius > 1)
                    {
                        // correct

                        float p1 = (float)Math.Cos((cog - 180) * deg2rad) * radius + radius;

                        float p2 = (float)Math.Sin((cog - 180) * deg2rad) * radius + radius;

                        g.DrawArc(new Pen(Color.HotPink, 2), -p1, -p2, radius * 2, radius * 2, cog - 180, alpha);
                    }
                }
                catch
                {
                }

                try
                {
                    g.RotateTransform(heading);
                }
                catch
                {
                }
                g.DrawImageUnscaled(icon, icon.Width / -2, icon.Height / -2);

                g.Transform = temp;
            }
        }

        [Serializable]
        public class GMapMarkerQuad : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private Bitmap icon = global::FBGroundControl.Properties.Resources.quadicon;

            float heading = 0;
            float cog = -1;
            float target = -1;
            private int sysid = -1;

            public float warn = -1;
            public float danger = -1;
            private AircraftModel planeModel;

            public GMapMarkerQuad(PointLatLng p, float heading, float cog, float target, int sysid)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.sysid = sysid;
                Size = icon.Size;
            }
            //自定义初始化飞机的构造函数 by lichao
            public GMapMarkerQuad(PointLatLng p, float heading, float cog, float target, int sysid, Bitmap icon, AircraftModel planeModel)
                : base(p)
            {
                this.icon = icon;
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.sysid = sysid;
                Size = this.icon.Size;
                this.planeModel = planeModel;
            }
            public GMapMarkerQuad(PointLatLng p, float heading, float cog, float target, int sysid, Bitmap icon)
                : base(p)
            {
                this.icon = icon;
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.sysid = sysid;
                Size = this.icon.Size;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                int length = 500;
                // anti NaN
                //绘制 当前航向、直达当前航点、gps追踪线。
                if (planeModel.isShowHeading)
                {
                    //当前航向
                    try
                    {
                        g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                            (float)Math.Sin((heading - 90) * deg2rad) * length);
                    }
                    catch
                    {
                    }

                    //直达当前航点
                    //g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                    g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                        (float)Math.Sin((cog - 90) * deg2rad) * length);
                    g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                        (float)Math.Sin((target - 90) * deg2rad) * length);
                    // anti NaN
                    try
                    {
                        g.RotateTransform(heading);
                    }
                    catch
                    {
                    }
                }
                //绘制飞机
                g.DrawImageUnscaled(icon, icon.Width / -2 + 2, icon.Height / -2);
                //绘制飞机编号
                if (planeModel.isShowPlaneID)
                {
                    //源代码注释
                    //g.DrawString(sysid.ToString(), new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, -8,
                    //-8);
                    g.DrawString(planeModel.current_id.ToString(), new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, -8,
                    -8);
                }
                g.Transform = temp;

                {
                    double width =
           (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
               Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0)) * 1000.0);
                    double m2pixelwidth = Overlay.Control.Width / width;

                    GPoint loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * warn * 2)), LocalPosition.Y);

                    if (m2pixelwidth > 0.001 && warn > 0)
                        g.DrawArc(Pens.Orange,
                            new System.Drawing.Rectangle(
                                LocalPosition.X - Offset.X - (int)(Math.Abs(loc.X - LocalPosition.X) / 2),
                                LocalPosition.Y - Offset.Y - (int)Math.Abs(loc.X - LocalPosition.X) / 2,
                                (int)Math.Abs(loc.X - LocalPosition.X), (int)Math.Abs(loc.X - LocalPosition.X)), 0, 360);

                    loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * danger * 2)), LocalPosition.Y);

                    if (m2pixelwidth > 0.001 && danger > 0)
                        g.DrawArc(Pens.Red,
                            new System.Drawing.Rectangle(
                                LocalPosition.X - Offset.X - (int)(Math.Abs(loc.X - LocalPosition.X) / 2),
                                LocalPosition.Y - Offset.Y - (int)Math.Abs(loc.X - LocalPosition.X) / 2,
                                (int)Math.Abs(loc.X - LocalPosition.X), (int)Math.Abs(loc.X - LocalPosition.X)), 0, 360);

                }
            }
        }

        [Serializable]
        public class GMapMarkerSingle : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private readonly Bitmap icon = global::FBGroundControl.Properties.Resources.redsinglecopter2;

            float heading = 0;
            float cog = -1;
            float target = -1;
            private int sysid = -1;

            public GMapMarkerSingle(PointLatLng p, float heading, float cog, float target, int sysid)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                this.sysid = sysid;
                Size = icon.Size;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                int length = 500;
                // anti NaN
                try
                {
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                        (float)Math.Sin((heading - 90) * deg2rad) * length);
                }
                catch
                {
                }
                //g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                    (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                    (float)Math.Sin((target - 90) * deg2rad) * length);
                // anti NaN
                try
                {
                    g.RotateTransform(heading);
                }
                catch
                {
                }

                g.DrawImageUnscaled(icon, icon.Width / -2 + 2, icon.Height / -2);

                g.DrawString(sysid.ToString(), new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, -8,
                    -8);

                g.Transform = temp;
            }
        }


        [Serializable]
        public class GMapMarkerHeli : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private readonly Bitmap icon = global::FBGroundControl.Properties.Resources.heli;

            float heading = 0;
            float cog = -1;
            float target = -1;

            public GMapMarkerHeli(PointLatLng p, float heading, float cog, float target)
                : base(p)
            {
                this.heading = heading;
                this.cog = cog;
                this.target = target;
                Size = icon.Size;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                int length = 500;
                // anti NaN
                try
                {
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                        (float)Math.Sin((heading - 90) * deg2rad) * length);
                }
                catch
                {
                }
                //g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                    (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                    (float)Math.Sin((target - 90) * deg2rad) * length);
                // anti NaN
                try
                {
                    g.RotateTransform(heading);
                }
                catch
                {
                }
                g.DrawImageUnscaled(icon, icon.Width / -2 + 2, icon.Height / -2);

                g.Transform = temp;
            }
        }

        [Serializable]
        public class GMapMarkerAntennaTracker : GMapMarker
        {
            const float rad2deg = (float)(180 / Math.PI);
            const float deg2rad = (float)(1.0 / rad2deg);

            private readonly Bitmap icon = global::FBGroundControl.Properties.Resources.Antenna_Tracker_01;

            float heading = 0;
            private float target = 0;

            public GMapMarkerAntennaTracker(PointLatLng p, float heading, float target)
                : base(p)
            {
                Size = icon.Size;
                this.heading = heading;
                this.target = target;
            }

            public override void OnRender(Graphics g)
            {
                Matrix temp = g.Transform;
                g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

                int length = 500;

                try
                {
                    // heading
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length,
                        (float)Math.Sin((heading - 90) * deg2rad) * length);

                    // target
                    g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                        (float)Math.Sin((target - 90) * deg2rad) * length);
                }
                catch
                {
                }

                g.DrawImage(icon, -20, -20, 40, 40);

                g.Transform = temp;
            }
        }


        class NoCheckCertificatePolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request,
                int certificateProblem)
            {
                return true;
            }
        }
    }
}