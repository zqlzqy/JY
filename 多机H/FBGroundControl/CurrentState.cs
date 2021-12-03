using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.ComponentModel;
using MissionPlanner.Utilities;
using log4net;
using MissionPlanner.Attributes;
using MissionPlanner;
using System.Collections;
using DirectShowLib;
using FBGroundControl;
using FBGroundControl.Forms.utils;
using FBGroundControl.Forms;

namespace MissionPlanner
{
    public class CurrentState : ICloneable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler csCallBack;

        internal JYState parent;

        internal int lastautowp = -1;

        // multipliers
        public static float multiplierdist = 1;
        public static string DistanceUnit = "";
        public static float multiplierspeed = 1;
        public static string SpeedUnit = "";
        bool se_run = false;
        UInt32 run_begin;//开始计算航时时刻
        public static double toDistDisplayUnit(double input)
        {
            return input * multiplierdist;
        }

        public static double toSpeedDisplayUnit(double input)
        {
            return input * multiplierspeed;
        }
        public static string distance_str
        {
            get;
            set;
        }
        public static double fromDistDisplayUnit(double input)
        {
            return input / multiplierdist;
        }

        public static double fromSpeedDisplayUnit(double input)
        {
            return input / multiplierspeed;
        }

        // orientation - rads
        [DisplayText("Roll (deg)")]
        public float roll { get; set; }

        [DisplayText("Pitch (deg)")]
        public float pitch { get; set; }
        public float yaw_h { get; set; }

        [DisplayText("Yaw (deg)")]

        public float yaw
        {
            get { return _yaw; }
            set
            {
                if (value < 0)
                {
                    _yaw = value + 360;
                }
                else
                {
                    _yaw = value;
                }
            }
        }

        private float _yaw = 0;

        [DisplayText("GroundCourse (deg)")]
        public float groundcourse
        {
            get { return _groundcourse; }
            set
            {
                if (value < 0)
                {
                    _groundcourse = value + 360;
                }
                else
                {
                    _groundcourse = value;
                }
            }
        }

        private float _groundcourse = 0;
        public double zuhe_altitude { get; set; }
        public double air_altitude { get; set; }
        public double set1 { get; set; }
        public double set2 { get; set; }
        public double set3 { get; set; }
        public double set4 { get; set; }
        public double get1 { get; set; }
        public double get2 { get; set; }
        public double get3 { get; set; }
        public double get4 { get; set; }
        public Int16 cepian { get; set; }
        public double roll_set { get; set; }
        public double pitch_set { get; set; }
        public double hight_set { get; set; }

        // position
        [DisplayText("Latitude (dd)")]
        public double lat { get; set; }

        [DisplayText("Longitude (dd)")]
        public double lng { get; set; }

        [DisplayText("Altitude (dist)")]
        public float alt
        {
            get { return (_alt - altoffsethome) * multiplierdist; }
            set
            {
                // check update rate, and ensure time hasnt gone backwards                
                _alt = value;

                if ((datetime - lastalt).TotalSeconds >= 0.2 && oldalt != alt || lastalt > datetime)
                {
                    climbrate = (alt - oldalt) / (float)(datetime - lastalt).TotalSeconds;
                    verticalspeed = (alt - oldalt) / (float)(datetime - lastalt).TotalSeconds;
                    if (float.IsInfinity(_verticalspeed))
                        _verticalspeed = 0;
                    lastalt = datetime;
                    oldalt = alt;
                }
            }
        }

        DateTime lastalt = DateTime.MinValue;

        [DisplayText("Altitude (dist)")]
        public float altasl
        {
            get { return _altasl * multiplierdist; }
            set { _altasl = value; }
        }

        float _altasl = 0;
        float oldalt = 0;

        [DisplayText("Alt Home Offset (dist)")]
        public float altoffsethome { get; set; }

        private float _alt = 0;

        [DisplayText("Gps Status")]
        public float gpsstatus { get; set; }

        [DisplayText("Gps HDOP")]
        public float gpshdop { get; set; }

        [DisplayText("TakeOff CMD")]
        public string takeoffcmd { get; set; }

        public static UInt32 mainCtrlcmd { get; set; }
        public string mainCtrlCmdStr { get; set; }
        public string solidData { get; set; }

        public string systemTimeGet { get; set; }

        [DisplayText("Left_Condition")]
        public string leftcondition { get; set; }

        [DisplayText("Right_Condition")]
        public string rightcondition { get; set; }

        [DisplayText("Sat Count")]
        public float satcount { get; set; }
        public byte gpsFixStatus { get; set; }

        [DisplayText("Latitude2 (dd)")]
        public double lat2 { get; set; }

        [DisplayText("Longitude2 (dd)")]
        public double lng2 { get; set; }

        [DisplayText("Altitude2 (dist)")]
        public float altasl2 { get; set; }

        public float gpsstatus2 { get; set; }

        public float gpshdop2 { get; set; }

        public float satcount2 { get; set; }

        public float groundspeed2 { get; set; }

        [DisplayText("GroundCourse2 (deg)")]
        public float groundcourse2 { get; set; }

        public float altd1000
        {
            get { return (alt / 1000) % 10; }
        }

        public float altd100
        {
            get { return (alt / 100) % 10; }
        }

        // speeds
        [DisplayText("AirSpeed (speed)")]
        public float airspeed
        {
            get { return _airspeed * multiplierspeed; }
            set { _airspeed = value; }
        }

        [DisplayText("Airspeed Target (speed)")]
        public float targetairspeed
        {
            get { return _targetairspeed; }
        }

        public bool lowairspeed { get; set; }

        [DisplayText("Airspeed Ratio")]
        public float asratio { get; set; }

        [DisplayText("GroundSpeed (speed)")]
        public float groundspeed
        {
            get { return _groundspeed * multiplierspeed; }
            set { _groundspeed = value; }
        }

        // accel
        [DisplayText("Accel X")]
        public float ax { get; set; }

        [DisplayText("Accel Y")]
        public float ay { get; set; }

        [DisplayText("Accel Z")]
        public float az { get; set; }
        public float Accx { get; set; }
        public float Accy { get; set; }
        public double Accz { get; set; }
        // gyro
        [DisplayText("Gyro X")]
        public float gx { get; set; }

        [DisplayText("Gyro Y")]
        public float gy { get; set; }

        [DisplayText("Gyro Z")]
        public float gz { get; set; }

        // mag
        [DisplayText("Mag X")]
        public float mx { get; set; }

        [DisplayText("Mag Y")]
        public float
            my { get; set; }

        [DisplayText("Mag Z")]
        public float mz { get; set; }

        [DisplayText("Mag Field")]
        public float magfield
        {
            get { return (float)Math.Sqrt(Math.Pow(mx, 2) + Math.Pow(my, 2) + Math.Pow(mz, 2)); }
        }

        [DisplayText("Accel Strength")]
        public float accelsq
        {
            get { return (float)Math.Sqrt(Math.Pow(ax, 2) + Math.Pow(ay, 2) + Math.Pow(az, 2)) / 1000.0f /*980.665f*/; }
        }

        [DisplayText("Gyro Strength")]
        public float gyrosq
        {
            get { return (float)Math.Sqrt(Math.Pow(gx, 2) + Math.Pow(gy, 2) + Math.Pow(gz, 2)); }
        }
        public string groundspeed_str { get; set; }
        // accel2
        [DisplayText("Accel2 X")]
        public float ax2 { get; set; }

        [DisplayText("Accel2 Y")]
        public float ay2 { get; set; }

        [DisplayText("Accel2 Z")]
        public float az2 { get; set; }

        // gyro2
        [DisplayText("Gyro2 X")]
        public float gx2 { get; set; }

        [DisplayText("Gyro2 Y")]
        public float gy2 { get; set; }

        [DisplayText("Gyro2 Z")]
        public float gz2 { get; set; }

        // mag2
        [DisplayText("Mag2 X")]
        public float mx2 { get; set; }

        [DisplayText("Mag2 Y")]
        public float my2 { get; set; }

        [DisplayText("Mag2 Z")]
        public float mz2 { get; set; }

        // accel3
        [DisplayText("Accel3 X")]
        public float ax3 { get; set; }

        [DisplayText("Accel3 Y")]
        public float ay3 { get; set; }

        [DisplayText("Accel3 Z")]
        public float az3 { get; set; }

        // gyro3
        [DisplayText("Gyro3 X")]
        public float gx3 { get; set; }

        [DisplayText("Gyro3 Y")]
        public float gy3 { get; set; }

        [DisplayText("Gyro3 Z")]
        public float gz3 { get; set; }

        // mag3
        [DisplayText("Mag3 X")]
        public float mx3 { get; set; }

        [DisplayText("Mag3 Y")]
        public float my3 { get; set; }

        [DisplayText("Mag3 Z")]
        public float mz3 { get; set; }

        [DisplayText("Failsafe")]
        public bool failsafe { get; set; }

        [DisplayText("RX Rssi")]
        public int rxrssi { get; set; }

        //radio
        public float ch1in { get; set; }
        public float ch2in { get; set; }
        public float ch3in { get; set; }
        public float ch4in { get; set; }
        public float ch5in { get; set; }
        public float ch6in { get; set; }
        public float ch7in { get; set; }
        public float ch8in { get; set; }

        public float ch9in { get; set; }
        public float ch10in { get; set; }
        public float ch11in { get; set; }
        public float ch12in { get; set; }
        public float ch13in { get; set; }
        public float ch14in { get; set; }
        public float ch15in { get; set; }
        public float ch16in { get; set; }

        // motors
        public float ch1out { get; set; }
        public float ch2out { get; set; }
        public float ch3out { get; set; }
        public float ch4out { get; set; }
        public float ch5out { get; set; }
        public float ch6out { get; set; }
        public float ch7out { get; set; }
        public float ch8out { get; set; }

        public float ch9out { get; set; }
        public float ch10out { get; set; }
        public float ch11out { get; set; }
        public float ch12out { get; set; }
        public float ch13out { get; set; }
        public float ch14out { get; set; }
        public float ch15out { get; set; }
        public float ch16out { get; set; }



        public bool lowgroundspeed { get; set; }
        float _airspeed;
        float _groundspeed;
        float _verticalspeed;

        [DisplayText("Vertical Speed (speed)")]
        public float verticalspeed
        {
            get
            {
                if (float.IsNaN(_verticalspeed)) _verticalspeed = 0;
                return _verticalspeed * multiplierspeed;
            }
            set { _verticalspeed = _verticalspeed * 0.4f + value * 0.6f; }
        }

        [DisplayText("Wind Direction (Deg)")]
        public float wind_dir { get; set; }

        [DisplayText("Wind Velocity (speed)")]
        public float wind_vel { get; set; }

        /// <summary>
        /// used in wind calc
        /// </summary>
        double Wn_fgo;

        /// <summary>
        /// used for wind calc
        /// </summary>
        double We_fgo;

        //nav state
        [DisplayText("Roll Target (deg)")]
        public float nav_roll { get; set; }

        [DisplayText("Pitch Target (deg)")]
        public float nav_pitch { get; set; }

        [DisplayText("Bearing Target (deg)")]
        public float nav_bearing { get; set; }

        [DisplayText("Bearing Target (deg)")]
        public float target_bearing { get; set; }

        [DisplayText("Dist to WP (dist)")]
        public float wp_dist
        {
            get { return (_wpdist * multiplierdist); }
            set { _wpdist = value; }
        }

        [DisplayText("Altitude Error (dist)")]
        public float alt_error
        {
            get { return _alt_error * multiplierdist; }
            set
            {
                if (_alt_error == value) return;
                _alt_error = value;
                _targetalt = _targetalt * 0.5f + (float)Math.Round(alt + alt_error, 0) * 0.5f;
            }
        }

        [DisplayText("Bearing Error (deg)")]
        public float ber_error
        {
            get { return (target_bearing - yaw); }
            set { }
        }

        [DisplayText("Airspeed Error (speed)")]
        public float aspd_error
        {
            get { return _aspd_error * multiplierspeed; }
            set
            {
                if (_aspd_error == value) return;
                _aspd_error = value;
                _targetairspeed = _targetairspeed * 0.5f + (float)Math.Round(airspeed + aspd_error, 0) * 0.5f;
            }
        }

        [DisplayText("Xtrack Error (m)")]
        public float xtrack_error { get; set; }

        [DisplayText("WP No")]
        public float wpno { get; set; }

        [DisplayText("Run_Mode")]
        public string runmode { get; set; }

        [DisplayText("Change_Mode")]
        public string change_mode { get; set; }

        [DisplayText("Mode")]
        public string mode { get; set; }

        uint _mode = 99999;

        [DisplayText("ClimbRate (speed)")]
        public float climbrate
        {
            get { return _climbrate * multiplierspeed; }
            set { _climbrate = value; }
        }


        /// <summary>
        /// time over target in seconds
        /// </summary>
        [DisplayText("Time over Target (sec)")]
        public int tot
        {
            get
            {
                if (groundspeed <= 0) return 0;
                return (int)(wp_dist / groundspeed);
            }
        }

        [DisplayText("Time over Home (sec)")]
        public int toh
        {
            get
            {
                if (groundspeed <= 0) return 0;
                return (int)(DistToHome / groundspeed);
            }
        }

        [DisplayText("Dist Traveled (dist)")]
        public float distTraveled { get; set; }

        [DisplayText("Time in Air (sec)")]
        public float timeInAir { get; set; }

        // calced turn rate
        [DisplayText("Turn Rate (speed)")]
        public float turnrate
        {
            get
            {
                if (groundspeed <= 1) return 0;
                return (roll * 9.8f) / groundspeed;
            }
        }

        // turn radius
        [DisplayText("Turn Radius (dist)")]
        public float radius
        {
            get
            {
                if (groundspeed <= 1) return 0;
                return ((groundspeed * groundspeed) / (float)(9.8f * Math.Tan(roll * deg2rad)));
            }
        }

        float _wpdist;
        float _aspd_error;
        float _alt_error;
        float _targetalt;
        float _targetairspeed;
        float _climbrate;

        public float targetaltd100
        {
            get { return (_targetalt / 100) % 10; }
        }

        public float targetalt
        {
            get { return _targetalt; }
        }

        //airspeed_error = (airspeed_error - airspeed);

        //message
        public List<string> messages { get; set; }

        internal string message
        {
            get
            {
                if (messages.Count == 0) return "";
                return messages[messages.Count - 1];
            }
        }

        public string messageHigh
        {
            get { return _messagehigh; }
            set { _messagehigh = value; }
        }

        private string _messagehigh;
        public DateTime messageHighTime { get; set; }

        //battery
        [DisplayText("Bat Voltage (V)")]
        public float battery_voltage
        {
            get { return _battery_voltage; }
            set
            {
                if (_battery_voltage == 0) _battery_voltage = value;
                _battery_voltage = value * 0.2f + _battery_voltage * 0.8f;
            }
        }

        public static string battery_voltage_str
        {
            get;
            set;
        }
        public static int battery_voltage_int
        {
            get;
            set;
        }
        internal float _battery_voltage;

        [DisplayText("Bat Remaining (%)")]
        public int battery_remaining
        {
            get { return _battery_remaining; }
            set
            {
                _battery_remaining = value;
                if (_battery_remaining < 0 || _battery_remaining > 100) _battery_remaining = 0;
            }
        }

        private int _battery_remaining;

        [DisplayText("Bat Current (Amps)")]
        public float current
        {
            get { return _current; }
            set
            {
                if (_lastcurrent == DateTime.MinValue) _lastcurrent = datetime;
                // case for no sensor
                if (value == -0.01f)
                {
                    _current = 0;
                    return;
                }
                battery_usedmah += (float)((value * 1000.0) * (datetime - _lastcurrent).TotalHours);
                _current = value;
                _lastcurrent = datetime;
            }
        } //current may to be below zero - recuperation in arduplane
        private float _current;

        [DisplayText("Bat Watts")]
        public float watts
        {
            get { return battery_voltage * current; }
        }

        private DateTime _lastcurrent = DateTime.MinValue;

        [DisplayText("Bat efficiency (mah/km)")]
        public float battery_mahperkm { get { return battery_usedmah / (distTraveled / 1000.0f); } }

        [DisplayText("Bat km left EST (km)")]
        public float battery_kmleft { get { return (((100.0f / (100.0f - battery_remaining)) * battery_usedmah) - battery_usedmah) / battery_mahperkm; } }

        [DisplayText("Bat used EST (mah)")]
        public float battery_usedmah { get; set; }

        [DisplayText("Bat2 Voltage (V)")]
        public float battery_voltage2
        {
            get { return _battery_voltage2; }
            set
            {
                if (_battery_voltage2 == 0) _battery_voltage2 = value;
                _battery_voltage2 = value * 0.2f + _battery_voltage2 * 0.8f;
            }
        }

        internal float _battery_voltage2;

        [DisplayText("Bat2 Current (Amps)")]
        public float current2
        {
            get { return _current2; }
            set
            {
                if (value < 0) return;
                _current2 = value;
            }
        }

        private float _current2;

        public float HomeAlt
        {
            get { return (float)HomeLocation.Alt; }
            set { }
        }

        static PointLatLngAlt _homelocation = new PointLatLngAlt();

        public PointLatLngAlt HomeLocation
        {
            get { return _homelocation; }
            set { _homelocation = value; }
        }

        public PointLatLngAlt MovingBase = null;

        static PointLatLngAlt _trackerloc = new PointLatLngAlt();

        public PointLatLngAlt TrackerLocation
        {
            get
            {
                if (_trackerloc.Lng != 0) return _trackerloc;
                return HomeLocation;
            }
            set { _trackerloc = value; }
        }

        public PointLatLngAlt Location
        {
            get { return new PointLatLngAlt(lat, lng, altasl); }
        }

        [DisplayText("Distance to Home (dist)")]
        public float DistToHome
        {
            get
            {
                if (lat == 0 && lng == 0 || TrackerLocation.Lat == 0)
                    return 0;

                // shrinking factor for longitude going to poles direction
                double rads = Math.Abs(TrackerLocation.Lat) * 0.0174532925;
                double scaleLongDown = Math.Cos(rads);
                double scaleLongUp = 1.0f / Math.Cos(rads);

                //DST to Home
                double dstlat = Math.Abs(TrackerLocation.Lat - lat) * 111319.5;
                double dstlon = Math.Abs(TrackerLocation.Lng - lng) * 111319.5 * scaleLongDown;
                return (float)Math.Sqrt((dstlat * dstlat) + (dstlon * dstlon)) * multiplierdist;
            }
        }

        [DisplayText("Distance From Moving Base (dist)")]
        public float DistFromMovingBase
        {
            get
            {
                if (lat == 0 && lng == 0 || MovingBase == null)
                    return 0;

                // shrinking factor for longitude going to poles direction
                double rads = Math.Abs(MovingBase.Lat) * 0.0174532925;
                double scaleLongDown = Math.Cos(rads);
                double scaleLongUp = 1.0f / Math.Cos(rads);

                //DST to Home
                double dstlat = Math.Abs(MovingBase.Lat - lat) * 111319.5;
                double dstlon = Math.Abs(MovingBase.Lng - lng) * 111319.5 * scaleLongDown;
                return (float)Math.Sqrt((dstlat * dstlat) + (dstlon * dstlon)) * multiplierdist;
            }
        }

        [DisplayText("Elevation to Mav (deg)")]
        public float ELToMAV
        {
            get
            {
                float dist = DistToHome / multiplierdist;

                if (dist < 5)
                    return 0;

                float altdiff = (float)(_altasl - TrackerLocation.Alt);

                float angle = (float)Math.Atan(altdiff / dist) * rad2deg;

                return angle;
            }
        }

        [DisplayText("Bearing to Mav (deg)")]
        public float AZToMAV
        {
            get
            {
                // shrinking factor for longitude going to poles direction
                double rads = Math.Abs(TrackerLocation.Lat) * 0.0174532925;
                double scaleLongDown = Math.Cos(rads);
                double scaleLongUp = 1.0f / Math.Cos(rads);

                //DIR to Home
                double dstlon = (TrackerLocation.Lng - lng); //OffSet_X
                double dstlat = (TrackerLocation.Lat - lat) * scaleLongUp; //OffSet Y
                double bearing = 90 + (Math.Atan2(dstlat, -dstlon) * 57.295775); //absolut home direction
                if (bearing < 0) bearing += 360; //normalization
                //bearing = bearing - 180;//absolut return direction
                //if (bearing < 0) bearing += 360;//normalization

                float dist = DistToHome / multiplierdist;

                if (dist < 5)
                    return 0;

                return (float)bearing;
            }
        }


        // pressure
        public float press_abs { get; set; }
        public int press_temp { get; set; }

        // sensor offsets
        public int mag_ofs_x { get; set; }
        public int mag_ofs_y { get; set; }
        public int mag_ofs_z { get; set; }
        public float mag_declination { get; set; }
        public int raw_press { get; set; }
        public int raw_temp { get; set; }
        public float gyro_cal_x { get; set; }
        public float gyro_cal_y { get; set; }
        public float gyro_cal_z { get; set; }
        public float accel_cal_x { get; set; }
        public float accel_cal_y { get; set; }
        public float accel_cal_z { get; set; }

        [DisplayText("Sonar Range (meters)")]
        public float sonarrange
        {
            get { return (float)toDistDisplayUnit(_sonarrange); }
            set { _sonarrange = value; }
        }

        float _sonarrange = 0;

        [DisplayText("Sonar Voltage (Volt)")]
        public float sonarvoltage { get; set; }

        // current firmware
        //public MainForm.Firmwares firmware = MainForm.Firmwares.ArduCopter2;
        public MainForm.Firmwares firmware = MainForm.Firmwares.JYPlane;

        public float freemem { get; set; }
        public float load { get; set; }
        public float brklevel { get; set; }
        public bool armed { get; set; }

        // Sik radio
        [DisplayText("Sik Radio rssi")]
        public float rssi { get; set; }

        [DisplayText("Sik Radio remote rssi")]
        public float remrssi { get; set; }

        public byte txbuffer { get; set; }

        [DisplayText("Sik Radio noise")]
        public float noise { get; set; }

        [DisplayText("Sik Radio remote noise")]
        public float remnoise { get; set; }
        public string lat_dfm { get; set; }
        public string lng_dfm { get; set; }
        public ushort rxerrors { get; set; }
        public ushort fixedp { get; set; }
        private float _localsnrdb = 0;
        private float _remotesnrdb = 0;
        private DateTime lastrssi = DateTime.Now;
        private DateTime lastremrssi = DateTime.Now;

        [DisplayText("Sik Radio snr")]
        public float localsnrdb
        {
            get
            {
                if (lastrssi.AddSeconds(1) > DateTime.Now)
                {
                    return _localsnrdb;
                }
                lastrssi = DateTime.Now;
                _localsnrdb = ((rssi - noise) / 1.9f) * 0.5f + _localsnrdb * 0.5f;
                return _localsnrdb;
            }
        }

        [DisplayText("Sik Radio remote snr")]
        public float remotesnrdb
        {
            get
            {
                if (lastremrssi.AddSeconds(1) > DateTime.Now)
                {
                    return _remotesnrdb;
                }
                lastremrssi = DateTime.Now;
                _remotesnrdb = ((remrssi - remnoise) / 1.9f) * 0.5f + _remotesnrdb * 0.5f;
                return _remotesnrdb;
            }
        }

        [DisplayText("Sik Radio est dist (m)")]
        public float DistRSSIRemain
        {
            get
            {
                float work = 0;
                if (localsnrdb == 0)
                {
                    return 0;
                }
                if (localsnrdb > remotesnrdb)
                {
                    // remote
                    // minus fade margin
                    work = remotesnrdb - 5;
                }
                else
                {
                    // local
                    // minus fade margin
                    work = localsnrdb - 5;
                }

                {
                    float dist = DistToHome / multiplierdist;

                    work = dist * (float)Math.Pow(2.0, work / 6.0);
                }

                return work;
            }
        }

        // stats
        public ushort packetdropremote { get; set; }
        public ushort linkqualitygcs { get; set; }

        [DisplayText("HW Voltage")]
        public float hwvoltage { get; set; }

        [DisplayText("Board Voltage")]
        public float boardvoltage { get; set; }

        [DisplayText("Servo Rail Voltage")]
        public float servovoltage { get; set; }

        [DisplayText("Voltage Flags")]
        public JYLink.JY_POWER_STATUS voltageflag { get; set; }

        public ushort i2cerrors { get; set; }

        public double timesincelastshot { get; set; }

        // requested stream rates
        public byte rateattitude { get; set; }
        public byte rateposition { get; set; }
        public byte ratestatus { get; set; }
        public byte ratesensors { get; set; }
        public byte raterc { get; set; }

        internal static byte rateattitudebackup { get; set; }
        internal static byte ratepositionbackup { get; set; }
        internal static byte ratestatusbackup { get; set; }
        internal static byte ratesensorsbackup { get; set; }
        internal static byte ratercbackup { get; set; }

        // reference
        public DateTime datetime { get; set; }
        public DateTime gpstime { get; set; }

        // HIL
        public int hilch1 { get; set; }
        public int hilch2 { get; set; }
        public int hilch3 { get; set; }
        public int hilch4 { get; set; }
        public int hilch5;
        public int hilch6;
        public int hilch7;
        public int hilch8;

        // rc override
        public ushort rcoverridech1 { get; set; }
        public ushort rcoverridech2 { get; set; }
        public ushort rcoverridech3 { get; set; }
        public ushort rcoverridech4 { get; set; }
        public ushort rcoverridech5 { get; set; }
        public ushort rcoverridech6 { get; set; }
        public ushort rcoverridech7 { get; set; }
        public ushort rcoverridech8 { get; set; }

        public bool connected
        {
            get { return (MainForm.comPort.BaseStream.IsOpen || MainForm.comPort.logreadmode); }
        }

        bool useLocation = false;
        bool gotwind = false;
        internal bool batterymonitoring = false;

        // for calc of sitl speedup
        internal DateTime lastimutime = DateTime.MinValue;
        internal double imutime = 0;

        public float speedup { get; set; }

        internal Mavlink_Sensors sensors_enabled = new Mavlink_Sensors();
        internal Mavlink_Sensors sensors_health = new Mavlink_Sensors();
        internal Mavlink_Sensors sensors_present = new Mavlink_Sensors();

        internal bool MONO = false;
        public delegate void PlanFlyTime(string planflyTime);//状态栏：飞机飞行时间委托类型声明
        public static event PlanFlyTime PlanFlyTimeHandler;//状态栏：飞机飞行时间基于委托的事件对象

        public delegate void PlanFlyGPSTime(float gpshdop, float satcount);//状态栏：GPS委托类型声明
        public static event PlanFlyGPSTime PlanFlyGPSTimeHandler;//状态栏：GPS基于委托的事件对象

        public delegate void PlanFlyRemoteControl(float ch3in);//状态栏：遥控器委托类型声明
        public static event PlanFlyRemoteControl PlanFlyRemoteControlHandler;//状态栏：遥控器基于委托的事件对象

        static CurrentState()
        {
            // set default telemrates
            rateattitudebackup = 4;
            ratepositionbackup = 2;
            ratestatusbackup = 2;
            ratesensorsbackup = 2;
            ratercbackup = 2;


        }

        public CurrentState()
        {
            ResetInternals();

            var t = Type.GetType("Mono.Runtime");
            MONO = (t != null);
        }

        public void ResetInternals()
        {
            lock (this)
            {

                _mode = 99999;
                messages = new List<string>();
                useLocation = false;
                rateattitude = rateattitudebackup;
                rateposition = ratepositionbackup;
                ratestatus = ratestatusbackup;
                ratesensors = ratesensorsbackup;
                raterc = ratercbackup;
                datetime = DateTime.MinValue;
                battery_usedmah = 0;
                _lastcurrent = DateTime.MinValue;
                distTraveled = 0;
                timeInAir = 0;
                version = new Version();
                voltageflag = JYLink.JY_POWER_STATUS.USB_CONNECTED;
            }
        }

        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        private DateTime lastupdate = DateTime.Now;

        private DateTime lastsecondcounter = DateTime.Now;
        private PointLatLngAlt lastpos = new PointLatLngAlt();

        DateTime lastdata = DateTime.MinValue;

        public string GetNameandUnit(string name)
        {
            string desc = name;
            try
            {
                var typeofthing = typeof(CurrentState).GetProperty(name);
                if (typeofthing != null)
                {
                    var attrib = typeofthing.GetCustomAttributes(false);
                    if (attrib.Length > 0)
                        desc = ((Attributes.DisplayTextAttribute)attrib[0]).Text;
                }
            }
            catch
            {
            }

            if (desc.Contains("(dist)"))
            {
                desc = desc.Replace("(dist)", "(" + CurrentState.DistanceUnit + ")");
            }
            else if (desc.Contains("(speed)"))
            {
                desc = desc.Replace("(speed)", "(" + CurrentState.SpeedUnit + ")");
            }

            return desc;
        }


        /// <summary>
        /// use for main serial port only
        /// </summary>
        /// <param name="bs"></param>
        public void UpdateCurrentSettings(System.Windows.Forms.BindingSource bs)
        {
            UpdateCurrentSettings(bs, false, MainForm.comPort, MainForm.comPort.JY);
        }

        /// <summary>
        /// Use the default sysid
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="updatenow"></param>
        /// <param name="mavinterface"></param>
        public void UpdateCurrentSettings(System.Windows.Forms.BindingSource bs, bool updatenow,
            JYLinkInterface mavinterface)
        {
            UpdateCurrentSettings(bs, updatenow, mavinterface, mavinterface.JY);
        }

        public void UpdateCurrentSettings(System.Windows.Forms.BindingSource bs, bool updatenow,
            JYLinkInterface mavinterface, JYState JY)
        {
            lock (this)
            {
                if (DateTime.Now > lastupdate.AddMilliseconds(50) || updatenow) // 20 hz
                {

                    lastupdate = DateTime.Now;

                    systemTimeGet = DateTime.Now.ToString("hh:mm:ss");

                    mainCtrlcmd = JYLinkMainCtrl.mainCtrlCmd;
                    mainCtrlCmdStr = JYLinkMainCtrl.mainCtrlCmd.ToString("X");
                    BajiId = JYLinkMainCtrl.Bajiid;

                    //check if valid mavinterface
                    if (parent != null && parent.packetsnotlost != 0)
                    {
                        if ((DateTime.Now - JY.lastvalidpacket).TotalSeconds > 10)
                        {
                            linkqualitygcs = 0;
                        }
                        else
                        {
                            linkqualitygcs = (ushort)((parent.packetsnotlost / (parent.packetsnotlost + parent.packetslost)) * 100.0);
                        }

                        if (linkqualitygcs > 100)
                            linkqualitygcs = 100;
                    }

                    if (datetime.Second != lastsecondcounter.Second)
                    {
                        lastsecondcounter = datetime;

                        if (lastpos.Lat != 0 && lastpos.Lng != 0 && armed)
                        {
                            if (!mavinterface.BaseStream.IsOpen && !mavinterface.logreadmode)
                                distTraveled = 0;

                            distTraveled += (float)lastpos.GetDistance(new PointLatLngAlt(lat, lng, 0, "")) * multiplierdist;
                            lastpos = new PointLatLngAlt(lat, lng, 0, "");
                        }
                        else
                        {
                            lastpos = new PointLatLngAlt(lat, lng, 0, "");
                        }

                        // throttle is up, or groundspeed is > 3 m/s
                        if ((barome_altitude > 5) && (groundspeed > 3.0))
                            timeInAir++;

                        if (!gotwind)
                            dowindcalc();
                    }

                    Dictionary<byte, string> coutrolModeDic = DictionaryTools.getControlMode();
                    Dictionary<byte, string> modeDic = DictionaryTools.getFlightMode();
                    Dictionary<byte, string> offCondition = DictionaryTools.getOffCondition();
                    JYLink.JYLinkMessage tuoluo = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.TUOLUO_PARAM_DOWN);
                    if ((tuoluo != null))
                    {
                        var tstatus = tuoluo.ToStructure<JYLink.jylink_tuoluo_param_down>();
                        status = tstatus.status;
                        Tuo_x = tstatus.Tuo_x;
                        Tuo_y = tstatus.Tuo_y;
                        Tuo_z = tstatus.Tuo_z;
                        acc_status = tstatus.acc_status;
                        acc_value = tstatus.acc_value;
                    }
                    JYLink.JYLinkMessage microMessage = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.Micro_STATUS_PARAM_DOWN);
                    if ((microMessage != null))
                    {

                        Micro = microMessage.ToStructure<JYLink.jylink_Micro_status_down>();
                        kj_time = Micro.kj_time;
                        wby_status1 = Micro.wby_status1;
                        wby_id = Micro.wby_id;
                        kdj_id = Micro.kdj_id;
                        bj_kdj_l = Micro.bj_kdj_l;
                        bj_zxj = Micro.bj_zxj;
                        bjsf_fkj = Micro.bjsf_fkj;
                        v_60 = Micro.v_60;
                        v1_28 = Micro.v1_28;
                        v2_28 = Micro.v2_28;
                        v_12 = Micro.v_12;
                        pz_cyz = Micro.pz_cyz;
                        beiyong = Micro.beiyong;
                        wby_status2 = Micro.wby_status2;
                    }
                    JYLink.JYLinkMessage grj = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.Grj_PARAM_DOWN);
                    if ((grj != null))
                    {
                        var grj_status = grj.ToStructure<JYLink.jylink_Grj_down>();
                        grj_second = grj_status.second;

                        grj_temp = grj_status.temp;
                        grj_command = Enum.GetName(typeof(grjcommand), grj_status.command);

                        if ((grj_status.status & 1) == 1)
                        {
                            grj_lmd = "低";
                        }
                        else
                        {
                            grj_lmd = "高";
                        }

                        if ((grj_status.status & 4) == 4)
                        {
                            grj_qptd = "开启";
                        }
                        else
                        {
                            grj_qptd = "关闭";
                        }
                        if ((grj_status.status & 8) == 8)
                        {
                            grj_yztd = "开启";
                        }
                        else
                        {
                            grj_yztd = "关闭";
                        }

                        if (grj_status.leibie == 0x11)
                        {
                            leibie = "干扰设备";
                        }
                        else
                        {
                            leibie = "待定";
                        }
                        grj_secCount = grj_status.secCount;
                        grj_id = grj_status.grjid;
                        task_id = grj_status.taskid;
                        task_b = grj_status.taskb;
                        grj_zsldpl = grj_status.zsldpl;
                        grj_cfzq = grj_status.cfzq * 0.5;//us
                        grj_mk = grj_status.mk * 0.05;//ns
                        grj_yzzsdk = grj_status.yzzsdk * 0.02;
                        //grj_xczsdk = grj_status.xczsdk * 0.02;
                        grj_count = grj_status.count;
                        //grj_ld2pl = grj_status.ld2pl;
                        grj_ld3pl = grj_status.ld3pl;
                        grj_ld4pl = grj_status.ld4pl;
                    }
                    //JYLink.JYLinkMessage SHIPMessage = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.Warship_Home_Up);
                    //if (SHIPMessage != null)
                    //{
                    //    var ShipParam = SHIPMessage.ToStructure<JYLink.Warship_home_location_up>();
                    //    xn_lng = ShipParam.h_lon;
                    //    xn_lat = ShipParam.h_lat;
                    //    xn_head = ShipParam.h_head;
                    //    xn_speed = ShipParam.h_speed;
                    //}
                    JYLink.JYLinkMessage ShipChange = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.Warship_Change);
                    if (ShipChange != null)
                    {
                        var ship = ShipChange.ToStructure<JYLink.Warship_change>();
                        head_change = ship.Heading;
                    }
                    //JYLink.JYLinkMessage YoumenMessage = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.YOUMEN_MODE_SET);
                    //if ((YoumenMessage != null))
                    //{

                    //    var YoumenParam = YoumenMessage.ToStructure<JYLink.jylink_youmen_mode_setup>();
                    //    if (YoumenParam.status==0)
                    //    {
                    //        YoumenMode = "手动"; 
                    //    }
                    //    else if (YoumenParam.status==1)
                    //    {
                    //        YoumenMode = "定速"; 
                    //    }
                    //    else if (YoumenParam.status == 2)
                    //    {
                    //        YoumenMode = "编队";
                    //    }
                    //    else
                    //    {
                    //        YoumenMode = "未知";
                    //    }

                    //}
                    //else
                    //{
                    //    YoumenMode = "手动";
                    //}
                    JYLink.JYLinkMessage mavLinkMessage = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.STATUS_PARAM_DOWN);
                    if ((mavLinkMessage != null))
                    {

                        var statusParam = mavLinkMessage.ToStructure<JYLink.jylink_status_param_down>();
                        //satcount = statusParam.satellites_count;//卫星数


                        if (double.IsNaN(statusParam.zuhe_altitude) || double.IsInfinity(statusParam.zuhe_altitude))
                        {
                            zuhe_altitude = 0;
                        }
                        else
                        {
                            if (statusParam.zuhe_altitude > 100000 || statusParam.zuhe_altitude < -1000)
                            {
                                zuhe_altitude = 9999;
                            }
                            else
                            {
                                zuhe_altitude = statusParam.zuhe_altitude;//   组合高度       
                            }
                        }
                        if (double.IsNaN(statusParam.air_altitude) || double.IsInfinity(statusParam.air_altitude))
                        {
                            air_altitude = 0;
                        }
                        else
                        {
                            air_altitude = statusParam.air_altitude;//  气压高度 
                        }
                        if (double.IsNaN(statusParam.altitude) || double.IsInfinity(statusParam.altitude))
                        {
                            alt = 0;
                        }
                        else
                        {
                            alt = statusParam.altitude;//无线电高度表高度   
                        }
                        solidData = "yaw:" + yaw.ToString() + "  " + "roll:" + roll.ToString() + "  " + "pitch:" + pitch.ToString();
                        haiba_altitude = statusParam.gnss_alt;
                        yaw_state = (float)((yaw) * 3.1415926) / 180;
                        pitch_state = (float)(-pitch * 3.1415926) / 180;
                        roll_state = (float)(-roll * 3.1415926) / 180;
                        hight_set = statusParam.hight_set;
                        linkqualitygcs = 100;
                        if (statusParam.youmen_mode == 0)
                        {
                            YoumenMode = "遥调";
                        }
                        else if (statusParam.youmen_mode == 1)
                        {
                            YoumenMode = "定速";
                        }
                        else if (statusParam.youmen_mode == 2)
                        {
                            YoumenMode = "编队";
                        }
                        else
                        {
                            YoumenMode = "未知";
                        }
                        //airspeed = statusParam.airspeed;//空速
                        battery_voltage = statusParam.flightcontrol_voltage / 10f;//飞控电压*10
                        wpno = statusParam.waypoint_id;//航点序号
                        wp_dist = (float)(statusParam.distance_to_nextwaypoint / 100.0);//距下一航点距离km
                        second_count = statusParam.second_count / 100;//秒计数
                        /*用于刷新立体图形*/
                        //                       secondCount = statusParam.second_count.ToString();

                        rpm = statusParam.rpm / 100f;//RPM
                        // rpm1 = statusParam.rpm1 / 100f;//RPM1
                        // waypoint_cmd = statusParam.waypoint_cmd;//航点指令
                        //  next_waypoint_cmd = statusParam.next_waypoint_cmd;//下一航点指令
                        distance_to_home = (uint)statusParam.distance_to_home / 100.0;//距家距离km
                        utc_hour = statusParam.time_h;//UTC 时
                        utc_minute = statusParam.time_m;//UTC 
                        utc_second = statusParam.time_s;//UTC 
                        sateliter = statusParam.sateliter;
                        distance_str = distance_to_home.ToString("0.00 km");
                        position_state = statusParam.position_state;//用于校准的判断-定位状态
                        gpsFixStatus = statusParam.position_state;
                        battery_voltage_str = string.Format("{0:N2}", battery_voltage);
                        battery_voltage_int = Convert.ToInt32(battery_voltage);

                        if (statusParam.flightcontrol_mode == 85)
                        {
                            flightcontrol_mode = "程控";
                            flightprogrom = Enum.GetName(typeof(program), statusParam.flightcontrol_progrom);
                            mode = flightcontrol_mode + " " + flightprogrom;

                        }
                        else if (statusParam.flightcontrol_mode == 170)
                        {
                            flightcontrol_mode = "自驾";
                            flightprogrom = Enum.GetName(typeof(command), statusParam.flightcontrol_progrom);
                            mode = flightcontrol_mode + " " + flightprogrom;
                        }
                        else if (statusParam.flightcontrol_mode == 90)
                        {
                            flightcontrol_mode = "机动";
                            flightprogrom = Enum.GetName(typeof(jidong), statusParam.flightcontrol_progrom);
                            mode = flightcontrol_mode + " " + flightprogrom;
                        }
                        else
                        {
                            flightcontrol_mode = "无";
                            mode = "无";
                        }

                        //flightcommand = Enum.GetName(typeof(command), statusParam.flightcontrol_command);
                        if (statusParam.loss_connect > 8)
                        {
                            losscontrol_mode = Enum.GetName(typeof(loss), 0);
                        }
                        else
                        {
                            losscontrol_mode = Enum.GetName(typeof(loss), statusParam.loss_connect);
                        }
                        //flightcontrol_mode = statusParam.flightcontrol_mode;//飞控模式
                        if (statusParam.tele_command > 42)
                        {
                            telecommand = Enum.GetName(typeof(tele), 0);
                        }
                        else
                        {
                            telecommand = Enum.GetName(typeof(tele), statusParam.tele_command);
                        }
                        //airspeed = statusParam.airspeed;

                        if (statusParam.flightcontrol_progrom == 6 && se_run == true)
                        {
                            se_run = false;
                        }
                        if (se_run)
                        {
                            second_run = (int)(second_count - run_begin);
                        }
                        if (flightcontrol_mode == "程控" && flightprogrom == "在架")
                        {
                            second_run = 0;
                            run_begin = second_count;
                        }
                        else if (flightcontrol_mode == "程控" && flightprogrom == "爬升")
                        {
                            se_run = true;
                        }



                        if (modeDic.ContainsKey(statusParam.flightcontrol_mode))
                        {
                            runmode = modeDic[statusParam.flightcontrol_mode];

                        }

                        control_youmen = statusParam.control_youmen.ToString() + "%";
                        ecu_voltage1 = statusParam.ecu_voltage1 / 10f;//ECU动力电压
                        ecu_throttle = statusParam.ecu_throttle * 0.01;
                        if (statusParam.ecu_errorno == 255)
                        {
                            ecu_errorno = "与飞控中断";

                        }
                        else if (statusParam.ecu_errorno > 37)
                        {
                            ecu_errorno = "未知错误！";
                        }
                        else
                        {
                            ecu_errorno = offCondition[statusParam.ecu_errorno];
                        }
                        ecu_pw = statusParam.ecu_pw;

                    }

                    JYLink.JYLinkMessage mavMessage2 = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.SATLATE_STATUS);
                    if ((mavMessage2 != null))
                    {

                        var statusParam2 = mavMessage2.ToStructure<JYLink.Satlate_status>();
                        set1 = (statusParam2.duo1_set / 100.0);
                        set2 = (statusParam2.duo2_set / 100.0);
                        set3 = (statusParam2.duo3_set / 100.0);
                        set4 = (statusParam2.duo4_set / 100.0);
                        get1 = (statusParam2.duo1_get / 100.0);
                        get2 = (statusParam2.duo2_get / 100.0);
                        get3 = (statusParam2.duo3_get / 100.0);
                        get4 = (statusParam2.duo4_get / 100.0);
                        roll_set = statusParam2.roll_set / 182.0;
                        pitch_set = statusParam2.pitch_set / 182.0;
                        if (double.IsNaN(statusParam2.lat) || double.IsInfinity(statusParam2.lat))
                        {
                            lat = 0;
                        }
                        else
                        {
                            lat = statusParam2.lat;//纬度   
                        }
                        if (double.IsNaN(statusParam2.lng) || double.IsInfinity(statusParam2.lng))
                        {
                            lng = 0;
                        }
                        else
                        {
                            lng = statusParam2.lng;//纬度   
                        }
                        if (double.IsNaN(statusParam2.roll) || double.IsInfinity(statusParam2.roll))
                        {
                            roll = 0;
                        }
                        else
                        {
                            roll = (float)(statusParam2.roll / 182.0);
                        }
                        if (double.IsNaN(statusParam2.pitch) || double.IsInfinity(statusParam2.pitch))
                        {
                            pitch = 0;
                        }
                        else
                        {
                            pitch = (float)(statusParam2.pitch / 182.0);
                        }
                        if (double.IsNaN(statusParam2.yaw) || double.IsInfinity(statusParam2.yaw))
                        {
                            yaw_h = 0;
                        }
                        else
                        {
                            yaw_h = (float)(statusParam2.yaw / 182.0);
                        }
                        angle_x = statusParam2.angelspeed_x * 57.3;
                        angle_y = statusParam2.angelspeed_y * 57.3;
                        angle_z = statusParam2.angelspeed_z * 57.3;
                        Accx = statusParam2.accspeed_x;
                        Accy = statusParam2.accspeed_y;
                        Accz = (float)(statusParam2.accspeed_z / (-9.8));
                        east_speed = (float)(statusParam2.east_speed / 100.0);
                        north_speed = (float)(statusParam2.north_speed / 100.0);
                        air_speed = (float)(statusParam2.sky_speed / 100.0);
                        groundspeed = (float)(Math.Sqrt(Math.Pow(statusParam2.east_speed, 2.0) + Math.Pow(statusParam2.north_speed, 2.0) + Math.Pow(statusParam2.sky_speed, 2.0)) / 100.0);
                        yaw = (float)(Math.Atan2(statusParam2.east_speed, statusParam2.north_speed) * 180 / 3.14);
                        if (yaw < 0)
                        {
                            yaw = yaw + 360;
                        }

                    }
                    JYLink.JYLinkMessage mavMessage = JY.getPacket((uint)JYLink.JYLINK_MSG_ID.STATUS_DOWN);
                    if ((mavMessage != null))
                    {

                        var statusParam = mavMessage.ToStructure<JYLink.jylink_status_down>();
                        //satcount = statusParam.satellites_count;//卫星数
                        cepian = statusParam.cepian;
                        set1 = statusParam.s1 * 0.25f;
                        set2 = statusParam.s2 * 0.25f;
                        set3 = statusParam.s3 * 0.25f;
                        set4 = statusParam.s4 * 0.25f;
                        get1 = statusParam.f1 * 0.25f;
                        get2 = statusParam.f2 * 0.25f;
                        get3 = statusParam.f3 * 0.25f;
                        get4 = statusParam.f4 * 0.25f;
                        if (double.IsNaN(statusParam.lat) || double.IsInfinity(statusParam.lat))
                        {
                            lat = 0;
                        }
                        else
                        {
                            lat = statusParam.lat;//纬度   
                        }
                        if (double.IsNaN(statusParam.lng) || double.IsInfinity(statusParam.lng))
                        {
                            lng = 0;
                        }
                        else
                        {
                            lng = statusParam.lng;//纬度   
                        }
                        if (double.IsNaN(statusParam.roll) || double.IsInfinity(statusParam.roll))
                        {
                            roll = 0;
                        }
                        else
                        {
                            roll = (float)(statusParam.roll / 182.0);
                        }
                        if (double.IsNaN(statusParam.pitch) || double.IsInfinity(statusParam.pitch))
                        {
                            pitch = 0;
                        }
                        else
                        {
                            pitch = (float)(statusParam.pitch / 182.0);
                        }
                        if (double.IsNaN(statusParam.yaw) || double.IsInfinity(statusParam.yaw))
                        {
                            yaw = 0;
                        }
                        else
                        {
                            yaw = (float)(Math.Atan2(statusParam.east_speed, statusParam.north_speed) * 180 / 3.14);
                            if (yaw < 0)
                            {
                                yaw = yaw + 360;
                            }
                        }

                        if (statusParam.youmen_mode == 0)
                        {
                            YoumenMode = "遥调";
                        }
                        else if (statusParam.youmen_mode == 1)
                        {
                            YoumenMode = "定速";
                        }
                        else if (statusParam.youmen_mode == 2)
                        {
                            YoumenMode = "编队";
                        }
                        else
                        {
                            YoumenMode = "未知";
                        }

                        utc_hour = statusParam.time_h;//UTC 时
                        utc_minute = statusParam.time_m;//UTC 
                        utc_second = (byte)(statusParam.time_s * 0.25);//UTC 
                        sateliter = statusParam.sateliter;
                        east_speed = (float)(statusParam.east_speed / 100.0);
                        north_speed = (float)(statusParam.north_speed / 100.0);
                        air_speed = (float)(statusParam.sky_speed / 100.0);//垂速
                        groundspeed = (float)(Math.Sqrt(Math.Pow(statusParam.east_speed, 2.0) + Math.Pow(statusParam.north_speed, 2.0) + Math.Pow(statusParam.sky_speed, 2.0)) / 100.0);
                        if (double.IsNaN(statusParam.zuhe_altitude) || double.IsInfinity(statusParam.zuhe_altitude))
                        {
                            zuhe_altitude = 0;
                        }
                        else
                        {
                            if (statusParam.zuhe_altitude > 10000 || statusParam.zuhe_altitude < -1000)
                            {
                                zuhe_altitude = 9999;
                            }
                            else
                            {
                                zuhe_altitude = statusParam.zuhe_altitude;//   组合高度       
                            }
                        }
                        if (double.IsNaN(statusParam.air_altitude) || double.IsInfinity(statusParam.air_altitude))
                        {
                            air_altitude = 0;
                        }
                        else
                        {
                            air_altitude = statusParam.air_altitude;//  气压高度 
                        }
                        if (double.IsNaN(statusParam.altitude) || double.IsInfinity(statusParam.altitude))
                        {
                            alt = 0;
                        }
                        else
                        {
                            alt = statusParam.altitude * 0.1f;//无线电高度表高度   
                        }
                        solidData = "yaw:" + yaw.ToString() + "  " + "roll:" + roll.ToString() + "  " + "pitch:" + pitch.ToString();
                        linkqualitygcs = 100;
                        airspeed = 0;//空速
                        battery_voltage = statusParam.flightcontrol_voltage / 5.0f;//飞控电压*10

                        wpno = statusParam.waypoint_id;//航点序号
                        wp_dist = (float)(statusParam.distance_to_nextwaypoint / 100.0);//距下一航点距离km
                        second_count = statusParam.second_count / 100;//秒计数
                        ecu_voltage1 = statusParam.ecu_voltage1 / 5.0f;//ECU动力电压
                        ecu_throttle = statusParam.ecu_throttle * 0.01;
                        ecub_v = statusParam.ecub_v * 0.1f;
                        if (statusParam.ecu_errorno == 255)
                        {
                            ecu_errorno = "与飞控中断";

                        }
                        else if (statusParam.ecu_errorno > 37)
                        {
                            ecu_errorno = "未知错误！";
                        }
                        else
                        {
                            ecu_errorno = offCondition[statusParam.ecu_errorno];
                        }
                        zj_speed = statusParam.zj_speed;
                        ecu_pw = statusParam.ecu_pw;
                        rpm = statusParam.rpm / 100.0f;//RPM
                        distance_to_home = statusParam.distance_to_home / 100.0;//距家距离km
                        distance_to_zj = statusParam.distance_to_zj;//m
                        distance_str = distance_to_home.ToString("N2");
                        control_youmen = statusParam.youmen.ToString() + " %";
                        position_state = statusParam.position_state;//用于校准的判断-定位状态
                        gpsFixStatus = statusParam.position_state;
                        if ((statusParam.flightcontrol_mode & 224) == 32)
                        {
                            flightcontrol_mode = "程控";
                            flightprogrom = Enum.GetName(typeof(program), statusParam.flightcontrol_mode & 31);
                            mode = flightcontrol_mode + " " + flightprogrom;

                        }
                        else if ((statusParam.flightcontrol_mode & 224) == 64)
                        {
                            flightcontrol_mode = "自驾";
                            flightprogrom = Enum.GetName(typeof(command), statusParam.flightcontrol_mode & 31);
                            mode = flightcontrol_mode + " " + flightprogrom;
                        }
                        else if ((statusParam.flightcontrol_mode & 224) == 96)
                        {
                            flightcontrol_mode = "机动";
                            flightprogrom = Enum.GetName(typeof(jidong), statusParam.flightcontrol_mode & 31);
                            mode = flightcontrol_mode + " " + flightprogrom;
                        }
                        else
                        {
                            flightcontrol_mode = "无";
                            mode = "无";
                        }
                        Accz = statusParam.accz / 300.0 / (-9.8);

                        //flightcontrol_mode = statusParam.flightcontrol_mode;//飞控模式
                        if (statusParam.loss_connect > 8)
                        {
                            losscontrol_mode = Enum.GetName(typeof(loss), 0);
                        }
                        else
                        {
                            losscontrol_mode = Enum.GetName(typeof(loss), statusParam.loss_connect);
                        }
                        if (statusParam.tele_command > 42)
                        {
                            telecommand = Enum.GetName(typeof(tele), 0);
                        }
                        else
                        {
                            telecommand = Enum.GetName(typeof(tele), statusParam.tele_command);
                        }


                        if (flightcontrol_mode == "自驾" && flightprogrom == "降落" && se_run == true)
                        {
                            se_run = false;
                        }
                        if (se_run)
                        {
                            second_run = (int)(second_count - run_begin);
                        }
                        if (flightcontrol_mode == "程控" && flightprogrom == "在架")
                        {
                            second_run = 0;
                            run_begin = second_count;
                        }
                        else if (flightcontrol_mode == "程控" && flightprogrom == "爬升")
                        {
                            se_run = true;
                        }
                        duoji_v = statusParam.duoji_v / 100.0f;

                        if (modeDic.ContainsKey(statusParam.flightcontrol_mode))
                        {
                            runmode = modeDic[statusParam.flightcontrol_mode];

                        }
                    }
                    if ((roll >= -180) && (roll <= 180))
                    {
                        roll = roll;//Roll
                    }
                    else if (roll < -180)
                    {
                        roll = -180;
                    }
                    else if (roll > 180)
                    {
                        roll = 180;
                    }

                    if ((pitch >= -90) && (pitch <= 90))
                    {
                        pitch = pitch;//Roll
                    }
                    else if (pitch < -90)
                    {
                        pitch = -90;
                    }
                    else if (pitch > 90)
                    {
                        pitch = 90;
                    }

                    if ((yaw >= 0) && (yaw <= 360))
                    {
                        yaw = yaw;//Roll
                    }
                    else if (yaw < 0)
                    {
                        yaw = 0;
                    }
                    else if (yaw > 360)
                    {
                        yaw = 360;
                    }
                    if ((yaw_h >= 0) && (yaw_h <= 360))
                    {
                        yaw_h = yaw_h;//Roll
                    }
                    else if (yaw_h < 0)
                    {
                        yaw_h = yaw_h + 360;
                    }
                    else if (yaw_h > 360)
                    {
                        yaw_h = 360;
                    }

                    if (lng != 0)
                    {
                        lng_double = lng;
                    }
                    if (lat != 0)
                    {
                        lat_double = lat;
                    }
                    utc_time = utc_hour;
                    alt_double = (ushort)zuhe_altitude;
                    baji_heading = yaw;
                    if (yaw != 0)
                    {
                        plane_heading = yaw;
                    }
                    double temp1, temp2;
                    if (lat >= 0)
                    {
                        temp1 = (lat - Math.Truncate(lat)) * 60;
                        temp2 = (temp1 - Math.Truncate(temp1)) * 60;
                        lat_dfm = Math.Truncate(lat).ToString() + "°" + Math.Truncate(temp1).ToString() + "'" + temp2.ToString("0.00") + "''";
                    }
                    else
                    {
                        lat = Math.Abs(lat);
                        temp1 = (lat - Math.Truncate(lat)) * 60;
                        temp2 = (temp1 - Math.Truncate(temp1)) * 60;
                        lat_dfm = "-" + Math.Truncate(lat).ToString() + "°" + Math.Truncate(temp1).ToString() + "'" + temp2.ToString("0.00") + "''";
                        lat = -lat;
                    }
                    if (lng >= 0)
                    {
                        temp1 = (lng - Math.Truncate(lng)) * 60;
                        temp2 = (temp1 - Math.Truncate(temp1)) * 60;
                        lng_dfm = Math.Truncate(lng).ToString() + "°" + Math.Truncate(temp1).ToString() + "'" + temp2.ToString("0.00") + "''";
                    }
                    else
                    {
                        lng = Math.Abs(lng);
                        temp1 = (lng - Math.Truncate(lng)) * 60;
                        temp2 = (temp1 - Math.Truncate(temp1)) * 60;
                        lng_dfm = "-" + Math.Truncate(lng).ToString() + "°" + Math.Truncate(temp1).ToString() + "'" + temp2.ToString("0.00") + "''";
                        lng = -lng;
                    }
                    //////////////////////
                }

                try
                {
                    if (csCallBack != null)
                        csCallBack(this, null);
                }
                catch
                {
                }

                //Console.Write(DateTime.Now.Millisecond + " start ");
                // update form
                try
                {
                    if (bs != null)
                    {
                        bs.DataSource = this;
                        bs.ResetBindings(false);

                        return;

                    }
                }
                catch
                {
                    log.InfoFormat("CurrentState Binding error");
                }
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void dowindcalc()
        {
            //Wind Fixed gain Observer
            //Ryan Beall 
            //8FEB10

            double Kw = 0.010; // 0.01 // 0.10

            if (airspeed < 1 || groundspeed < 1)
                return;

            double Wn_error = airspeed * Math.Cos((yaw) * deg2rad) * Math.Cos(pitch * deg2rad) -
                              groundspeed * Math.Cos((groundcourse) * deg2rad) - Wn_fgo;
            double We_error = airspeed * Math.Sin((yaw) * deg2rad) * Math.Cos(pitch * deg2rad) -
                              groundspeed * Math.Sin((groundcourse) * deg2rad) - We_fgo;

            Wn_fgo = Wn_fgo + Kw * Wn_error;
            We_fgo = We_fgo + Kw * We_error;

            double wind_dir = (Math.Atan2(We_fgo, Wn_fgo) * (180 / Math.PI));
            double wind_vel = (Math.Sqrt(Math.Pow(We_fgo, 2) + Math.Pow(Wn_fgo, 2)));

            wind_dir = (wind_dir + 360) % 360;

            this.wind_dir = (float)wind_dir; // (float)(wind_dir * 0.5 + this.wind_dir * 0.5);
            this.wind_vel = (float)wind_vel; // (float)(wind_vel * 0.5 + this.wind_vel * 0.5);

            //Console.WriteLine("Wn_error = {0}\nWe_error = {1}\nWn_fgo =    {2}\nWe_fgo =  {3}\nWind_dir =    {4}\nWind_vel =    {5}\n",Wn_error,We_error,Wn_fgo,We_fgo,wind_dir,wind_vel);

            //Console.WriteLine("wind_dir: {0} wind_vel: {1}    as {4} yaw {5} pitch {6} gs {7} cog {8}", wind_dir, wind_vel, Wn_fgo, We_fgo , airspeed,yaw,pitch,groundspeed,groundcourse);

            //low pass the outputs for better results!
        }

        /// <summary>
        /// derived from MAV_SYS_STATUS_SENSOR
        /// </summary>
        public class Mavlink_Sensors
        {
            BitArray bitArray = new BitArray(32);

            public bool seen = false;

            public Mavlink_Sensors()
            {
                //var item = MAVLink.MAV_SYS_STATUS_SENSOR._3D_ACCEL;
            }

            public Mavlink_Sensors(uint p)
            {
                seen = true;
                bitArray = new BitArray(new int[] { (int)p });
            }


            int ConvertValuetoBitmaskOffset(int input)
            {
                int offset = 0;
                for (int a = 0; a < sizeof(int) * 8; a++)
                {
                    offset = 1 << a;
                    if (input == offset)
                        return a;
                }
                return 0;
            }

            public uint Value
            {
                get
                {
                    int[] array = new int[1];
                    bitArray.CopyTo(array, 0);
                    return (uint)array[0];
                }
                set
                {
                    seen = true;
                    bitArray = new BitArray(new int[] { (int)value });
                }
            }

            public override string ToString()
            {
                return Convert.ToString(Value, 2);
            }
        }

        public float campointa { get; set; }

        public float campointb { get; set; }

        public float campointc { get; set; }

        public PointLatLngAlt GimbalPoint { get; set; }

        public float gimballat
        {
            get
            {
                if (GimbalPoint == null) return 0;
                return (float)GimbalPoint.Lat;
            }
        }

        public float gimballng
        {
            get
            {
                if (GimbalPoint == null) return 0;
                return (float)GimbalPoint.Lng;
            }
        }


        public bool landed { get; set; }

        public bool terrainactive { get; set; }

        float _ter_curalt;

        [DisplayText("Terrain AGL")]
        public float ter_curalt
        {
            get { return _ter_curalt * multiplierdist; }
            set { _ter_curalt = value; }
        }

        float _ter_alt;

        [DisplayText("Terrain GL")]
        public float ter_alt
        {
            get { return _ter_alt * multiplierdist; }
            set { _ter_alt = value; }
        }

        public float ter_load { get; set; }

        public float ter_pend { get; set; }

        public float ter_space { get; set; }

        public static int KIndexstatic = -1;

        public int KIndex
        {
            get { return (int)CurrentState.KIndexstatic; }
        }

        [DisplayText("flow_comp_m_x")]
        public float opt_m_x { get; set; }

        [DisplayText("flow_comp_m_y")]
        public float opt_m_y { get; set; }

        [DisplayText("flow_x")]
        public short opt_x { get; set; }

        [DisplayText("flow_y")]
        public short opt_y { get; set; }

        [DisplayText("flow quality")]
        public byte opt_qua { get; set; }

        public float ekfstatus { get; set; }

        public int ekfflags { get; set; }

        public float ekfvelv { get; set; }

        public float ekfcompv { get; set; }

        public float ekfposhor { get; set; }

        public float ekfposvert { get; set; }

        public float ekfteralt { get; set; }

        public float pidff { get; set; }

        public float pidP { get; set; }

        public float pidI { get; set; }

        public float pidD { get; set; }

        public byte pidaxis { get; set; }

        public float piddesired { get; set; }

        public float pidachieved { get; set; }

        public uint vibeclip0 { get; set; }

        public uint vibeclip1 { get; set; }

        public uint vibeclip2 { get; set; }

        public float vibex { get; set; }

        public float vibey { get; set; }

        public float vibez { get; set; }

        public Version version { get; set; }

        // public float rpm1 { get; set; }

        public float rpm2 { get; set; }


        public int Roll { get; set; }

        public int Pitch { get; set; }

        public int Throttle { get; set; }

        public int Rudder { get; set; }


        /// <summary> 秒计数</summary>
        public UInt32 second_count { get; set; }
        /// <summary> 气压高度</summary>
        public Single barome_altitude { get; set; }
        /// <summary> RPM </summary>
        public float rpm { get; set; }
        /// <summary> RPM1 </summary>
        public float rpm1 { get; set; }
        /// <summary> 东速</summary>
        public Single east_speed { get; set; }
        /// <summary> 北速</summary>
        public Single north_speed { get; set; }
        /// <summary> 天速</summary>
        public Single air_speed { get; set; }

        public UInt16 waypoint_id { get; set; }

        /// <summary> 航点指令</summary>
        public UInt16 waypoint_cmd { get; set; }
        /// <summary> 下一航点指令</summary>
        public UInt16 next_waypoint_cmd { get; set; }

        /// <summary> 距家距离</summary>
        public double distance_to_home { get; set; }
        /// <summary> UTC时</summary>
        public byte utc_hour { get; set; }
        /// <summary> UTC分</summary>
        public byte utc_minute { get; set; }
        /// <summary> UTC秒</summary>
        public byte utc_second { get; set; }
        /// <summary> UTC秒</summary>
        public float sateliter { get; set; }
        /// <summary> 切换标志</summary>
        public byte change_flag { get; set; }
        /// <summary> 定位状态</summary>
        public byte position_state { get; set; }

        public static float yaw_state { get; set; }

        public static float roll_state { get; set; }

        public static float pitch_state { get; set; }

        /// <summary> 距主机距离</summary>
        public double distance_to_zj { get; set; }
        /// <summary> 预设飞控模式</summary>
        public byte setcontrol_mode { get; set; }
        /// <summary> 飞控模式</summary>


        /// <summary> 舵机电压*10</summary>
        public float servo_voltage { get; set; }
        /// <summary> 舵机电流*10</summary>
        public float servo_current { get; set; }
        ///// <summary> 负载1电压*10</summary>
        //public float load1_voltage { get; set; }
        ///// <summary> 负载1电流*10</summary>
        //public float load1_current { get; set; }
        /// <summary> 负载2电压*10</summary>
        public byte land_stage { get; set; }
        /// <summary> 负载2电流*10</summary>
        public float load2_current { get; set; }
        /// <summary> 负载3电压*10</summary>
        public float load3_voltage { get; set; }
        /// <summary> 负载3电流*10</summary>
        public float load3_current { get; set; }
        /// <summary> 负载4电压*10</summary>
        public float load4_voltage { get; set; }
        /// <summary> 负载4电流*10</summary>
        public float load4_current { get; set; }
        /// <summary> 负载5电压*10</summary>
        public float load5_voltage { get; set; }
        /// <summary> 负载5电流*10</summary>
        public float load5_current { get; set; }
        /// <summary> ECU钢头温度</summary>
        public UInt16 ecu_head_tempreture { get; set; }
        /// <summary> ECU电压</summary>
        public float ecu_voltage1 { get; set; }
        /// <summary>油门</summary>
        public double ecu_throttle { get; set; }
        /// <summary> 泵电压</summary>
        public float ecub_v { get; set; }
        /// <summary>温度</summary>
        public Int32 ecu_pw { get; set; }
        /// <summary>错误码</summary>
        public string ecu_errorno { get; set; }
        /// <summary> ECU电压</summary>
        public float ecu_voltage2 { get; set; }
        /// <summary> ECU电流</summary>
        public float ecu_voltage { get; set; }
        /// <summary> Ignition Pump Choke</summary>
        public UInt16 ignition_pump_choke { get; set; }
        /// <summary> ECU Duty_cycle</summary>
        public UInt16 ecu_duty_cycle { get; set; }
        /// <summary> 发电机状态</summary>
        public byte auto_step { get; set; }

        /// <summary> 角速度X</summary>
        public double angle_x { get; set; }
        /// <summary> 角速度Y</summary>
        public double angle_y { get; set; }

        /// <summary> 角速度Z</summary>
        public double angle_z { get; set; }
        /// <summary> 海拔高度</summary>
        public Single haiba_altitude { get; set; }
        /// <summary> 飞控模式</summary>
        public string flightcontrol_mode { get; set; }   //修改
        public string flightprogrom { get; set; }   //修改 
        public string flightcommand { get; set; }   //修改 

        public string telecommand { get; set; }   //修改 
        /// <summary> 失控模式</summary>
        public string losscontrol_mode { get; set; }   //修改 
        //public MAVLink.MAV_PROTOCOL_CAPABILITY capabilities { get; set; }
        /// <summary> 航时</summary>
        public Int32 second_run { get; set; }

        public double zj_speed { get; set; }
        //机动飞行阶段
        public enum jidong
        {
            航向机动 = 0,
            蛇形机动 = 1,
            半滚倒转 = 2,
            桶滚 = 3,
            俯冲拉起 = 4,
        };
        //程控模式飞行阶段
        public enum program
        {
            在架 = 0,
            爬升 = 1,
            导引 = 2,

        };
        // 自驾模式飞行阶段
        public enum command
        {
            平飞 = 0,
            定点盘旋 = 1,
            远航 = 2,
            返航 = 3,
            俯冲 = 4,
            爬升 = 5,
            降落 = 6,
            去自主 = 7,
            左盘旋 = 8,
            右盘旋 = 9,
            失控保护 = 10,
            归航 = 11,
            归航降高 = 12,
            归_航 = 13,
        };
        // 失控飞行阶段
        public enum loss
        {
            正常飞行 = 0,
            高度保护 = 1,
            姿态保护 = 2,
            遥控异常 = 3,
            GPS丢失 = 4,
            爬升掉高 = 5,
            空域预警 = 6,
            空域超限归航 = 7,
            空域超限开伞 = 8,
        };
        public enum tele
        {
            无指令 = 0,
            下纠 = 1,
            上纠 = 2,
            下舵 = 3,
            上舵 = 4,
            俯冲 = 5,
            爬升 = 6,
            火工1 = 7,
            开伞 = 8,
            气囊 = 9,
            抛伞 = 10,
            归航 = 11,
            程控 = 12,
            大车 = 13,
            升高 = 14,
            满车 = 15,
            巡航 = 16,
            小车 = 17,
            火工2 = 18,
            通电 = 19,
            降高1 = 20,
            降高2 = 21,
            怠速 = 22,
            启动 = 23,
            停车 = 24,
            平飞 = 25,
            急停 = 26,
            左纠 = 27,
            右纠 = 28,
            左舵 = 29,
            右舵 = 30,
            左盘 = 31,
            右盘 = 32,
            左盘机动 = 33,
            左航向90 = 34,
            左航向180 = 35,
            半滚倒转 = 36,
            S机动 = 37,
            俯冲拉起 = 38,
            桶滚 = 39,
            右盘机动 = 40,
            右航向90 = 41,
            右航向180 = 42,
        };
        public enum grjcommand
        {
            开干扰 = 0x33,
            关干扰 = 0x35,
            任务1 = 0x41,
            任务2 = 0x43,
            任务3 = 0x45,
            任务4 = 0x47,
            任务5 = 0x49,
            任务6 = 0x4B,
            任务7 = 0x4D,
            任务8 = 0x4F,
            自检 = 0x53,
            待机 = 0x55,
            卸载数据 = 0x57,
            擦除完成 = 0x58,
            擦除失败 = 0x59,
            备份1 = 0x61,
            备份2 = 0x63,
        };
        public static double xn_lng { get; set; }

        public static double xn_lat { get; set; }

        public static short xn_head { get; set; }

        public static short xn_speed { get; set; }

        public static UInt32 utc_time { get; set; }
        public static UInt16 kj_time { get; set; }
        public static byte wby_status1 { get; set; }
        public byte wby_id { get; set; }
        public static byte kdj_id { get; set; }
        public static UInt16 bj_kdj_l { get; set; }
        public static Int16 bj_zxj { get; set; }
        public static Int16 bjsf_fkj { get; set; }
        public static UInt16 v_60 { get; set; }
        public static UInt16 v1_28 { get; set; }
        public static UInt16 v2_28 { get; set; }
        public static UInt16 v_12 { get; set; }
        public static UInt16 pz_cyz { get; set; }
        public static Int16 beiyong { get; set; }
        public static byte wby_status2 { get; set; }

        public JYLink.jylink_Micro_status_down Micro
        {
            get;
            set;
        }
        public string rpm_str { get; set; }
        public UInt16 grj_second { get; set; }
        public string grj_zj_status { get; set; }
        public sbyte grj_temp { get; set; }
        public string grj_command { get; set; }
        public double duoji_v { get; set; }
        public string grj_lmd { get; set; }
        public string grj_sffs { get; set; }
        public string grj_qptd { get; set; }
        public string grj_yztd { get; set; }
        public string grj_fsj { get; set; }
        public UInt16 grj_zsldpl { get; set; }
        public double grj_cfzq { get; set; }
        public double grj_mk { get; set; }
        public sbyte grj_fd { get; set; }
        public UInt16 grj_grpl { get; set; }
        public sbyte grj_grxhfd { get; set; }
        public double grj_yzzsdk { get; set; }
        public double grj_xczsdk { get; set; }
        public Int16 grj_count { get; set; }
        public UInt16 grj_ld2pl { get; set; }
        public UInt16 grj_ld3pl { get; set; }
        public UInt16 grj_ld4pl { get; set; }
        public Int16 grj_id { get; set; }
        public Int16 task_id { get; set; }
        public UInt16 task_b { get; set; }
        public string leibie { get; set; }
        public static double lat_double { get; set; }
        public static float baji_heading { get; set; }
        public static float plane_heading { get; set; }
        public static ushort alt_double { get; set; }
        public static double lng_double { get; set; }

        public static byte status { get; set; }
        public static byte BajiId { get; set; }
        public static float Tuo_x { get; set; }

        public static float Tuo_y { get; set; }

        public static float Tuo_z { get; set; }

        public static byte acc_status { get; set; }

        public static float acc_value { get; set; }

        public string control_youmen { get; set; }
        public static bool g_speed { get; set; }

        public ushort grj_secCount { get; set; }

        public static float head_change { get; set; }

        public string YoumenMode { get; set; }
    }
}