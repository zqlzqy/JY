using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO.Ports;
using System.Text;

namespace FBGroundControl
{
//    using JYLink;
    using DevExpress.XtraBars;
    using DotSpatial.Data;
    using DotSpatial.Projections;
    using FBGroundControl.chao.models;
    using FBGroundControl.chao.views;
    using FBGroundControl.Forms;
    using FBGroundControl.Properties;
    using FBGroundControl.view;
    using GMap.NET;
    using GMap.NET.MapProviders;
    using GMap.NET.WindowsForms;
    using GMap.NET.WindowsForms.Markers;
    using log4net;
    using MissionPlanner;
    using MissionPlanner.Comms;
    using MissionPlanner.Controls;
    using MissionPlanner.Controls.Waypoints;
    using MissionPlanner.Utilities;
    using ProjNet.CoordinateSystems;
    using ProjNet.CoordinateSystems.Transformations;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using WeifenLuo.WinFormsUI.Docking;
    using ZedGraph;
    using Settings = MissionPlanner.Utilities.Settings;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public partial class MainForm : Form
    {
        //飞控是否连接
        public bool isConnect = false;
        public List<byte> Table_id = new List<byte>();
        public byte Zhan_id = 0;
        public static List<JYLinkInterface> Comports = new List<JYLinkInterface>();
        public static List<JYLinkMainCtrl> MainCtrlComports = new List<JYLinkMainCtrl>();
        public static MainForm instance = null;
        public static GMapOverlay kmlpolygons;
        public static bool MONO = false;
        public static GMapOverlay objectsoverlay;
        public static GMapOverlay polygonsoverlay;
        public static GMapOverlay flyToPointLay;
        public static bool speechEnable = false;
        public static Speech speechEngine = null;
        public static Object thisLock = new Object();
        public static bool threadrun;
        public Hashtable adsbPlanes = new Hashtable();
        public List<PointLatLngAlt> fullpointlist = new List<PointLatLngAlt>();
        public GMapRoute homeroute = new GMapRoute("home route");
        public List<PointLatLngAlt> pointlist = new List<PointLatLngAlt>();
        public bool quickadd;
        public GMapRoute wpRoute = new GMapRoute("wp route");
        private Microwave microwave;
        private Ganraoji ganraoji; 
        internal static GMapOverlay poioverlay = new GMapOverlay("POI");
        internal static GMapOverlay rallypointoverlay;
        double angel_c = 0;
        // poi layer
        internal object adsblock = new object();

        internal GMapPolygon drawnpolygon;
        internal PointLatLng MouseDownEnd;
        internal PointLatLng MouseDownStart;
        internal string wpfilename;

        private static readonly log4net.ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static JYLinkInterface _comPort = new JYLinkInterface();
        //private static JYLinkTeleCtrl _telecontrol_comPort = new JYLinkTeleCtrl();
        private static JYLinkMainCtrl _mainCtrl_comPort = new JYLinkMainCtrl();
        public static Dictionary<byte, byte[]> Listbuff = new Dictionary<byte, byte[]>();//信标数据
        public static Dictionary<byte, JYLink.jylink_xb_status_down> xbsum = new Dictionary<byte, JYLink.jylink_xb_status_down>();//信标数据
        public static byte xinbiao_id = 0;
        public LatLngToDfm latTodfm = null;
        private bool CameraOverlap;
        private GMapMarker center = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.none);
        private Dictionary<string, string[]> cmdParamNames = new Dictionary<string, string[]>();
        private DateTime connecttime = DateTime.Now;
        private MissionPlanner.Common.GMapMarkerRect CurentRectMarker;
        private altmode currentaltmode = altmode.Relative;
        private GMapMarker CurrentGMapMarker;
        private GMapMarker currentMarker;
        private GMapMarkerPOI CurrentPOIMarker;
        private GMapMarkerRallyPt CurrentRallyPt;
        private GMapOverlay drawnpolygonsoverlay;
        private List<int> groupmarkers = new List<int>();
        private DateTime heatbeatSend = DateTime.Now;
        private List<List<Locationwp>> history = new List<List<Locationwp>>();
        private bool isMouseClickOffMenu;
        private bool isMouseDown;
        private bool isMouseDraging;
        private Boolean isRange = false;
        private bool isFlyToPoint = false;
        private bool isPlan = false;
        private bool isonline = true;
        private DateTime lastmapposchange = DateTime.MinValue;
        private DateTime lastscreenupdate = DateTime.Now;
        private List<PointLatLngAlt> list = new List<PointLatLngAlt>();
        private RollingPointPairList list1 = new RollingPointPairList(1200);
        private RollingPointPairList list10 = new RollingPointPairList(1200);
        private PropertyInfo list10item;
        private PropertyInfo list1item;
        private RollingPointPairList list2 = new RollingPointPairList(1200);
        private PropertyInfo list2item;
        private RollingPointPairList list3 = new RollingPointPairList(1200);
        private PropertyInfo list3item;
        private RollingPointPairList list4 = new RollingPointPairList(1200);
        private PropertyInfo list4item;
        private RollingPointPairList list5 = new RollingPointPairList(1200);
        private PropertyInfo list5item;
        private RollingPointPairList list6 = new RollingPointPairList(1200);
        private PropertyInfo list6item;
        private RollingPointPairList list7 = new RollingPointPairList(1200);
        private PropertyInfo list7item;
        private RollingPointPairList list8 = new RollingPointPairList(1200);
        private PropertyInfo list8item;
        private RollingPointPairList list9 = new RollingPointPairList(1200);
        private PropertyInfo list9item;
        private GMapMarker marker;
        public MissionPlanner.Controls.MainSwitcher MyView;
        private DateTime nodatawarning = DateTime.Now;
        private Hashtable param = new Hashtable();
        private bool polygongridmode;
        private GMapOverlay polygons;
        private MissionPlanner.Controls.Icon.Polygon polyicon = new MissionPlanner.Controls.Icon.Polygon();
        public GMapRoute route;
        private GMapOverlay routes;
        private float routetotal = 0;
        private int selectedrow;
        private Thread serialreaderthread;
        private bool serialThread = false;
        private ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);
        private ManualResetEvent mainCtrlThreadrunner = new ManualResetEvent(false);
        private ManualResetEvent shipCtrlThreadrunner = new ManualResetEvent(false);
        private Thread mainctrlreaderthread;
        private Thread xbctrlreaderthread;
        private bool mainCtrlThread = false;
        private Thread shipctrlreaderthread;//1225
        private bool shipCtrlThread = false; 
        private bool sethome;
        private bool splinemode;
        private Thread thisthread;
        private int tickStart;
        private List<PointLatLng> trackPoints = new List<PointLatLng>();
        public volatile int updateBindingSourcecount;
        private object updateBindingSourcelock = new object();
        private string updateBindingSourceThreadName = "";
        public Telemetry2 telemetryFrm2;
        public HudFrm hudFrm;
        public CommandHistoryFrm commandHirtoryFrm=new CommandHistoryFrm();
        private CommandsFrm commandsFrm;
        private MapFrm mapFrm;
        FlightMode flight = new FlightMode();
        public TelemetryFrm telemetryFrm;
        private WpsFrm wpsFrm;
        private ComboBox CMB_altmode;
        private ComboBox CMB_modes;
        private ComboBox cboFlightModel;
        public myGMAP myGMAP1;
        public HUD hud1;
        private TextBox TXT_homealt;
        private TextBox TXT_homelng;
        private TextBox TXT_homelat;
        private TextBox TXT_homeheading;
        private TextBox TXT_homesecond;
        public TextBox lng_xn;
        public TextBox lat_xn;
        public TextBox head_xn;
        public TextBox speed_xn;
        public XuNi xuniFrm;
        private bool Home_Flag;
        private TextBox TXT_WPRad;
        private TextBox TXT_loiterrad;
        private TextBox TXT_DefaultAlt;
        private CheckBox CHK_verifyheight;
        private DataGridView Commands;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewComboBoxColumn Command;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alt;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Up;
        private System.Windows.Forms.DataGridViewImageColumn Down;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dist;
        private System.Windows.Forms.DataGridViewTextBoxColumn AZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private BindingSource bindingSourceHud;
        private ContextMenuStrip contextMenuStrip1;
        private LinkLabel label4;
        public Panel tabStatus;
        private System.Windows.Forms.BindingSource bindingSourceStatusTab;

        //初始化通讯设置(串口/TCP)
        internal CommunicationSetFrm _communicationSetFrm;
        internal NewSerialPorts _newserialPorts;
        public HudView hudview; 
        public DuojiView duojiFrm;
        //视图设置
        internal ViewSetFrm _viewSetFrm = new ViewSetFrm();

        //TCP设置：IP
        public string Host;

        //TCP设置：端口号
        public string Port;

        //串口设置：串口
        public string serialValue;

        public string telecontrol_serialValue;

        public string mainCtrl_serialValue;

        //新增串口
//        public string NserialValue;

        //新增串口波特率
 //       public string NbaudRateValue;
        public Point[] p_goujing = new Point[2];

        //串口设置：波特率
        public string baudRateValue;

        public string telecontrol_baudRateValue;

        public string mainCtrl_baudRateValue;

        public string XBCtrl_baudRateValue;
        public string XBCtrl_serialValue;
        public string Headtext = string.Format("{0,-2}", "时") + string.Format("{0,-2}", "分") + string.Format("{0,-2}", "秒") + string.Format("{0,-3}", "星数")
                               + string.Format("{0,-10}", "经度") + string.Format("{0,-10}", "纬度") + string.Format("{0,-4}", "高度") + string.Format("{0,-5}", "滚转") + string.Format("{0,-5}", "俯仰")
                               + string.Format("{0,-5}", "偏航") + string.Format("{0,-6}", "东速") + string.Format("{0,-6}", "北速") + string.Format("{0,-6}", "天速")
                               + string.Format("{0,-7}", "ECU电压") + string.Format("{0,-7}", "ECU转速") + string.Format("{0,-7}", "ECU温度") + string.Format("{0,-14}", "ECU状态") + string.Format("{0,-10}", "操作指令")
                          + string.Format("{0,-10}", "船经度") + string.Format("{0,-10}", "船纬度") + string.Format("{0,-8}", "船航向") + string.Format("{0,-4}", "船速（节）");

        
        public ViewSet _viewSet = new ViewSet();

        //地图设置
        public MapSourceSet mapSourceSet;

        //下载地图保存路径
        public string mapSourceLoaction = "";

        //设置主飞机
        private GMapMarker mainPlane;

        //指令是否发送成功
        public bool isSendSuccess = false;

        //手机连接信号
        public float _linkqualitygcs=100;

        //GPS定位状态
        public float _positionState;

        //实时数据：数据监测
        public TelemetryMgrFrm _telemetryMgrFrm = null;

        //实时数据：数据列表
        public TelemetryListFrm _telemetryListFrm = null;

        private AircraftModel mainPlaneModel;//靶机模型

        private ComponentResourceManager rm = new ComponentResourceManager(typeof(MapFrm));
       
        

        /// <summary>
        /// joystick static class操纵杆的静态类
        /// </summary>
        //public static Joystick.Joystick joystick = null;
        private void InitControls()
        {
            //myGMAP1 = mapFrm.myGMAP1;
            hud1 = hudFrm.hud1;
            Num = wpsFrm.Hxnum;
            label4 = wpsFrm.label4;
            Commands = wpsFrm.Commands;
            Command = wpsFrm.Command;
            Param1 = wpsFrm.Param1;
            Param2 = wpsFrm.Param2;
            Param3 = wpsFrm.Param3;
            Param4 = wpsFrm.Param4;
            Lat = wpsFrm.Lat;
            Lon = wpsFrm.Lon;
            Alt = wpsFrm.Alt;
            Delete = wpsFrm.Delete;
            Up = wpsFrm.Up;
            Down = wpsFrm.Down;
            Grad = wpsFrm.Grad;
            Angle = wpsFrm.Angle;
            Dist = wpsFrm.Dist;
            AZ = wpsFrm.AZ;
            Tag = wpsFrm.Tag;
            //TXT_homealt = wpsFrm.TXT_homealt;
            TXT_homelng = wpsFrm.TXT_homelng;
            TXT_homelat = wpsFrm.TXT_homelat;
            TXT_homeheading = wpsFrm.cheading;
            TXT_homesecond = wpsFrm.SECOND;
            TXT_WPRad = wpsFrm.TXT_WPRad;
            TXT_loiterrad = wpsFrm.TXT_loiterrad;
            TXT_DefaultAlt = wpsFrm.TXT_DefaultAlt;
            CHK_verifyheight = wpsFrm.CHK_verifyheight;
            CMB_altmode = wpsFrm.CMB_altmode;
            CMB_altmode = wpsFrm.CMB_altmode;
            bindingSourceHud = hudFrm.bindingSourceHud;
            //lng_xn = xuniFrm.lng_xn;
            //lat_xn = xuniFrm.lat_xn;
            //head_xn = xuniFrm.heading_xn;
            //speed_xn = xuniFrm.speed_xn;
            tabStatus = telemetryFrm.tabStatus;
            bindingSourceStatusTab = telemetryFrm.bindingSourceStatusTab;
        }
        Screen[] screens = Screen.AllScreens;
        Point mp = Control.MousePosition;
        public MainForm()
        {



            InitializeComponent();
            

            //******************初始化视图设置：判断各模块是否显示******************************************
            //_viewSetFrm = new ViewSetFrm();
            //_viewSet = new ViewSet();
            // MessageBox.Show(Application.StartupPath);

            PopulateViewSetFrmList();

            ViewSetFrm.SaveViewSetHandler += ViewSetFrm_SaveViewSetHandler;

            InitDockPanels();
            //******************航线规划显示隐藏******************************************************
            WpsFrm.IsShowWpsFrmHandler += WpsFrm_IsShowWpsFrmHandler;

            InitControls();
            //初始化地图鼠标右键事件集 by lichao
            registMapRightClickEvent();
            //repositoryItemComboBox3.Items = ;
            //初始化飞机模型
            mainPlaneModel = new AircraftModel("0", "0");
            //repositoryItemComboBox3.
            //EnumTranslator.EnumToList<altmode>().ForEach(x => repositoryItemComboBox3.Items.Add(x));
            CMB_altmode.DisplayMember = "Value";
            CMB_altmode.ValueMember = "Key";
            CMB_altmode.DataSource = EnumTranslator.EnumToList<altmode>();
            CMB_altmode.SelectedItem = altmode.Relative;

            //set default
            //CMB_altmode.Text = altmode.Relative;

            /*
            this.repositoryItemLookUpEdit2.DisplayMember = "Value";
            this.repositoryItemLookUpEdit2.ValueMember = "Key";

            this.repositoryItemLookUpEdit2.DataSource =  Common.getModesList(MainForm.comPort.MAV.cs);
            */
            //repositoryItemComboBox1.Items.AddRange(SerialPort.GetPortNames()); 111
            //this.repositoryItemComboBox6.Items.Add("Relative");
            //this.repositoryItemComboBox6.Items.Add("Absolute");
            //this.repositoryItemComboBox6.Items.Add("Terrain");

            //List<KeyValuePair<int, string>> modeList = Common.getModesList(MainForm.comPort.MAV.cs);
            //foreach (KeyValuePair<int, string> pair in modeList)
            //{
            //    this.repositoryItemComboBox5.Items.Add(pair.Value);
            //}

            //this.cboFlightModel.Text = "Auto"; 111

            instance = this;
            Settings.Instance["NUM_tracklength"] = "200";

            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();
            config(false);
            //初始化地图
            // config map             
           // this.myGMAP1.CacheLocation = Settings.GetDataDirectory() +
                                    //"gmapcache" + Path.DirectorySeparatorChar;

            //this.myGMAP1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
            //*****************初始化地图设置************************************************************************************
            mapSourceSet = new MapSourceSet();
            PopulateMapSourceSet();
            //this.myGMAP1.DragButton = MouseButtons.Left;

            // draw this layer first

            //myGMAP1.RoutesEnabled = true;

            //top = new GMapOverlay("top");
            //MainMap.Overlays.Add(top);

            // set current marker
            //currentMarker = new GMarkerGoogle(myGMAP1.Position, GMarkerGoogleType.red);
            //top.Markers.Add(currentMarker);

            // map center

            polygonsoverlay = new GMapOverlay("polygons");
            //myGMAP1.Overlays.Add(polygonsoverlay);

            flyToPointLay = new GMapOverlay("flyToPointLay");
            //myGMAP1.Overlays.Add(flyToPointLay);

            routes = new GMapOverlay("routes");
           // myGMAP1.Overlays.Add(routes);


            List<PointLatLng> polygonPoints2 = new List<PointLatLng>();
            drawnpolygon = new GMapPolygon(polygonPoints2, "drawnpoly");
            drawnpolygon.Stroke = new Pen(Color.Red, 2);
            drawnpolygon.Fill = Brushes.Transparent;

            Comports.Add(comPort);
            MainCtrlComports.Add(mainCtrl_comPort);

            if (!Settings.Instance.ContainsKey("copter_guid"))
                Settings.Instance["copter_guid"] = Guid.NewGuid().ToString();
            if (!Settings.Instance.ContainsKey("plane_guid"))
                Settings.Instance["plane_guid"] = Guid.NewGuid().ToString();

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

            mainctrlreaderthread = new Thread(mainCtrlReader)
            {
                IsBackground = true,
                Name = "MainCtrl Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            mainctrlreaderthread.Start();

            shipctrlreaderthread = new Thread(shipCtrlReader)
            {
                IsBackground = true,
                Name = "shipCtrl Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            //shipctrlreaderthread.Start();
            thisthread = new Thread(mainloop);
            thisthread.Name = "FD Mainloop";
            thisthread.IsBackground = true;
            thisthread.Start();
           
            xbctrlreaderthread = new Thread(xbCtrlReader)
            {
                IsBackground = true,
                Name = "xbCtrl Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            xbctrlreaderthread.Start();
            updateHome();

            setWPParams();

            updateCMDParams();

            //this.PlanTime_label.Text = MAVLink.time_boot_ms;

            //******************初始化 通讯设置******************************************************
            _communicationSetFrm = new CommunicationSetFrm();
            _communicationSetFrm.serial_comboBoxShow.SelectedIndexChanged += this.serial_comboBoxShow_SelectedIndexChanged;
            _communicationSetFrm.serial_comboBoxShow.Click += this.serial_comboBoxShow_Click;
            PopulateCommunicationSetFrmList();

            _newserialPorts = new NewSerialPorts(this);
            mapFrm.MouseClick += new MouseEventHandler(mapFrm_MouseClick); //鼠标单击事件
            mapFrm.MouseMove += new MouseEventHandler(mapFrm_MouseMove); //鼠标单击事件
            mapFrm.MouseDown += new MouseEventHandler(mapFrm_MouseDown); //鼠标单击事件
            mapFrm.MouseUp += new MouseEventHandler(mapFrm_MouseUp); //鼠标单击事件


            this.Commands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellContentClick);
            this.Commands.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellEndEdit);
            this.Commands.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Commands_DataError);
            this.Commands.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Commands_DefaultValuesNeeded);
            this.Commands.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Commands_EditingControlShowing);
            this.Commands.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_RowEnter);
            this.Commands.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Commands_RowsAdded);
            this.Commands.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Commands_RowValidating);
            this.Commands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Commands.CellMouseDoubleClick += Commands_CellMouseDoubleClick;
            this.TXT_homelng.TextChanged += new System.EventHandler(this.TXT_homelng_TextChanged);
            this.TXT_homelat.TextChanged += new System.EventHandler(this.TXT_homelng_TextChanged);
           // this.TXT_homealt.TextChanged += new System.EventHandler(this.TXT_homelng_TextChanged);
            //this.TXT_homealt.TextChanged += new System.EventHandler(this.TXT_homelng_TextChanged);

            //label4.LinkClicked += label4_LinkClicked;

            ////发送命令日志*********************************************************
            //writelog();
            CreateXmlSendCommondLog();
            //******************菜单栏命令发送日志记录******************************************************
            CommondOfSet.SendCommondLogBackHandler += SendCommondLogBackHandler;
            CommandsFrm.SendCommondLogBackHandler += SendCommondLogBackHandler;
            //实施数据：数据监测曲线图
            // MyView = new MainSwitcher(this);
            _telemetryMgrFrm = new TelemetryMgrFrm();
            //s实时数据：数据列表
            _telemetryListFrm = new TelemetryListFrm();
            latTodfm = new LatLngToDfm();
            //绑定时间函数，把右上角系统时间绑定显示
            //this.PlanTime_label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceHud, "systemTimeGet", true));          
        }

        private void Commands_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex == Command.Index || e.ColumnIndex == Delete.Index)
            {
                return;
            }
            UInt16 parm2 = Convert.ToUInt16(Commands.Rows[e.RowIndex].Cells[Param2.Index].Value);
            latTodfm.checkBox1.Checked = (parm2 & (0x1 << 0)) >> 0 == 1 ? true : false;
            latTodfm.checkBox2.Checked = (parm2 & (0x1 << 1)) >> 1 == 1 ? true : false;
            latTodfm.checkBox3.Checked = (parm2 & (0x1 << 2)) >> 2 == 1 ? true : false;
            latTodfm.checkBox4.Checked = (parm2 & (0x1 << 3)) >> 3 == 1 ? true : false;
            latTodfm.checkBox5.Checked = (parm2 & (0x1 << 4)) >> 4 == 1 ? true : false;
            latTodfm.biandui.Checked = (parm2 & (0x1 << 9)) >> 9 == 1 ? true : false;
            latTodfm.dingsu.Checked = (parm2 & (0x1 << 8)) >> 8 == 1 ? true : false;
            latTodfm.shoudong1.Checked = (parm2 & (0x1 << 10)) >> 10 == 1 ? true : false;
            latTodfm.ShowDialog();
            parm2 = (UInt16)((latTodfm.checkBox1.Checked == true ? 1 : 0) * 1 + (latTodfm.checkBox2.Checked == true ? 1 : 0) * 2 + (latTodfm.checkBox3.Checked == true ? 1 : 0) * 4
                    + (latTodfm.checkBox4.Checked == true ? 1 : 0) * 8 + (latTodfm.checkBox5.Checked == true ? 1 : 0) * 16 + (latTodfm.biandui.Checked == true ? 1 : 0) * 512
                    + (latTodfm.dingsu.Checked == true ? 1 : 0) * 256 + (latTodfm.shoudong1.Checked == true ? 1 : 0) * 1024);

            Commands.Rows[e.RowIndex].Cells[Param2.Index].Value = parm2.ToString();
            Commands_CellEndEdit(sender, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));

        }
      
        /// <summary>
        /// 注册地图鼠标右键事件集 by lichao
        /// </summary>
        private void registMapRightClickEvent()
        {
            //mapFrm.startRangeToolStripMenuItemShow.Click += startRangeToolStripMenuItem;
            //mapFrm.stopRangeToolStripMenuItemShow.Click += stopRangeToolStripMenuItem;
            
            goujing.set_goujing.Click += set_goujingMenuItem;
            //mapFrm.pickPoint_ToolStripMenuItemReview.Click += pickPointToolStripMenuItem;
            mapFrm.goujing_ToolStripMenuItemReview.Click += GoujingToolStripMenuItem;
            //wpsFrm.gb_heading.TextChanged += gb_heading_TextChanged;
            //mapFrm.Changeroute_ToolStripMenuItemReview.Click += ChangerouteToolStripMenuItem;
            wpsFrm.ChangeHeading_ItemReview.Click += ChangeHeadingMenuItem;
            mapFrm.flyToPoint_ToolStripMenuItemReview.Click += flyToPointToolStripMenuItem;
           // mapFrm.selectPlane_ToolStripMenuItemReview.Click += selectPlane_ToolStripMenuItem;
           // mapFrm.planeCenter_ToolStripMenuItemReview.Click += planeCenter_ToolStripMenuItem;
           // mapFrm.lineCenter_ToolStripMenuItemReview.Click += lineCenter_ToolStripMenuItem;
           // mapFrm.showHeading_ToolStripMenuItemReview.Click += showHeading_ToolStripMenuItemReview_Click;
           // mapFrm.showTrack_ToolStripMenuItemReview.Click += ShowTrack_ToolStripMenuItemReview_Click;
            //mapFrm.showWayPointLine_ToolStripMenuItemReview.Click += showWayPointLine_ToolStripMenuItemReview_Click;
           // mapFrm.showPlaneID_ToolStripMenuItemReview.Click += showPlaneID_ToolStripMenuItemReview_Click;
            mapFrm.clearTracks_ToolStripMenuItemReview.Click += clearTracks_ToolStripMenuItemReview_Click;
            mapFrm.datamode_ToolStripMenuItemReview.Click += datamode_ToolStripMenuItemReview_Click;//数据模式事件
            mapFrm.planmode_ToolStripMenuItemReview.Click += planmode_ToolStripMenuItemReview_Click;//规划模式事件
           // mapFrm.prefetchToolStripMenuItemReview.Click += prefetchToolStripMenuItem_Click;
           mapFrm.planmode_ToolStripMenuItemReview.CheckStateChanged+=planmode_ToolStripMenuItemReview_CheckStateChanged;
            mapFrm.rang_ToolStripMenuItemReview.Click += rang_ToolStripMenuItemReview_Click;
            mapFrm.datamode_ToolStripMenuItemReview.CheckStateChanged+=datamode_ToolStripMenuItemReview_CheckStateChanged;
        }

        private void datamode_ToolStripMenuItemReview_CheckStateChanged(object sender, EventArgs e)
        {
            if (mapFrm.datamode_ToolStripMenuItemReview.Checked)
            {
                mapFrm.planmode_ToolStripMenuItemReview.Checked = false;
                isPlan = false;

            }
            else
            {
                mapFrm.planmode_ToolStripMenuItemReview.Checked = true;
                isPlan = true;
            }
        }

        private void planmode_ToolStripMenuItemReview_CheckStateChanged(object sender, EventArgs e)
        {
            if (mapFrm.planmode_ToolStripMenuItemReview.Checked)
            {
                mapFrm.datamode_ToolStripMenuItemReview.Checked = false;
                isPlan = true;
                if (mapFrm.rang_ToolStripMenuItemReview.Checked)
                {
                    isRange = true;
                }
                else
                {
                    isRange = false;
                }
            }
            else
            {
                mapFrm.datamode_ToolStripMenuItemReview.Checked = true;
                isPlan = false;
                //isRange = false;
            }
        }
        //测距 功能的更改：测距只测量两点距离
        private void rang_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            isRange = true;
            //if (isPlan&&mapFrm.rang_ToolStripMenuItemReview.Checked)
            //{
            //    isRange = true;
            //}
            //else {

            //    MessageBox.Show("请先切换到规划模式");
            //}

        }


        private void prefetchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RectLatLng area = myGMAP1.SelectedArea;
            //if (area.IsEmpty)
            //{
            //    DialogResult res = CustomMessageBox.Show("No ripp area defined, ripp displayed on screen?", "Rip",
            //        MessageBoxButtons.YesNo);
            //    if (res == DialogResult.Yes)
            //    {
            //        area = myGMAP1.ViewArea;
            //    }
            //}

            //if (!area.IsEmpty)
            //{
            //    string maxzoomstring = "20";
            //    if (InputBox.Show("max zoom", "Enter the max zoom to prefetch to.", ref maxzoomstring) != DialogResult.OK)
            //        return;

            //    int maxzoom = 20;
            //    if (!int.TryParse(maxzoomstring, out maxzoom))
            //    {
            //        CustomMessageBox.Show(Strings.InvalidNumberEntered, Strings.ERROR);
            //        return;
            //    }

            //    maxzoom = Math.Min(maxzoom, myGMAP1.MaxZoom);

            //    for (int i = 1; i <= maxzoom; i++)
            //    {
            //        TilePrefetcher obj = new TilePrefetcher();
            //        ThemeManager.ApplyThemeTo(obj);
            //        obj.ShowCompleteMessage = false;
            //        obj.Start(area, i, myGMAP1.MapProvider, 0, 0);

            //        if (obj.UserAborted)
            //            break;
            //    }
            //}
            //else
            //{
            //    CustomMessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //}
        }

        void datamode_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            //isPlan = false;
        }
        void planmode_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            //isPlan = true;
        }

        /// <summary>
        /// 地图右键--测距--开始测距 插入航点用于测距 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //private void startRangeToolStripMenuItem(object sender, EventArgs e)
        //{
        //    isRange = true;
        //}

        ///// <summary>
        ///// 地图右键--测距--结束测距 清除插入的航点信息 by lichao
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void stopRangeToolStripMenuItem(object sender, EventArgs e)
        //{
        //    isRange = false;
        //    polygonsoverlay.Polygons.Clear();
        //    polygonsoverlay.Markers.Clear();
        //    polygonPoints.Clear();
        //    rangeList = 0;
        //    this.mapFrm.lbl_distanceShow.Text = "总长度" + ": ";
        //    this.mapFrm.lbl_prevdistShow.Text = "最后两点长度" + ": ";
        //}

        private bool isPickMousePoint;

        /// <summary>
        /// 地图右键--拾取坐标点 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickPointToolStripMenuItem(object sender, EventArgs e)
        {
            if (isPickMousePoint == true)
            {
                isPickMousePoint = false;
                //this.mapFrm.lbl_pickMousePointReview.Visible = false;
            }
            else
            {
                isPickMousePoint = true;
                //this.mapFrm.lbl_pickMousePointReview.Visible = true;
            }
        }

        /// <summary>
        /// 地图右键--拾取坐标点 执行具体动作 by lichao
        /// </summary>
        private string pickpointvalue;

        private panel_PickPoint pickPointPanel;

        private void doPickMousePoint(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pickPointPanel = new panel_PickPoint();
            pickPointPanel.Location = new Point(300, 300);
           // pickpointvalue = mapFrm.lbl_pickMousePointReview.Text;

            string result = pickpointvalue.Split('：')[1];
            pickPointPanel.tb_latlng.Text = result;
            //pickPointPanel.btn_copyReview.Click += pickPointPanel_btn_copy_Click;
            //pickPointPanel.btn_cancelReview.Click += pickPointPanel_btn_cancel_Click;
            pickPointPanel.ShowDialog();
            isPickMousePoint = false;
            //this.mapFrm.lbl_pickMousePointReview.Visible = false;
        }

        /// <summary>
        /// 地图右键--飞行至此点事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flyToPointToolStripMenuItem(object sender, EventArgs e)//跳过当前航点
        {
            NextPoint nn = new NextPoint();
           
            nn.Show();
            ////isFlyToPoint = true;
            //if (!MainForm.comPort.BaseStream.IsOpen)
            //{
            //    MessageBox.Show("Please Connect First!");
            //    return;
            //}
            //JYLink.jylink_to_nextpoint_set mode = new JYLink.jylink_to_nextpoint_set();
            //mode.mode = 0x5A;
            //MainForm.comPort.setupToNextPoint(mode);
        }

        /// <summary>
        /// 处理飞行至此点具体事件
        /// </summary>
        private FlyToPointForm flyToPointFrm;

        private void doFlyToPoint(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PointLatLng targetPoint = MouseDownStart;
            flyToPointLay.Markers.Add(new GMarkerGoogle(MouseDownStart, GMarkerGoogleType.blue));
            //myGMAP1.Invalidate();
            flyToPointFrm = new FlyToPointForm();
            flyToPointFrm.flyToPointFrm_lbl_commandpoint.Text = "Lat:" + targetPoint.Lat + "\nLng:" + targetPoint.Lng;
            flyToPointFrm.flyToPointFrm_btn_ok.Click += flyToPointFrm_btn_ok_Click;
            flyToPointFrm.flyToPointFrm_btn_cancel.Click += flyToPointFrm_btn_cancel_Click;
            flyToPointFrm.Show();
            isFlyToPoint = false;
        }

        /// <summary>
        /// 处理飞行至此点子页面点击 确认 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flyToPointFrm_btn_ok_Click(object sender, EventArgs e)
        {
            //TOOD 发送指令到飞控，立即执行飞行至此点任务 by lichao
            isFlyToPoint = false;
        }

        /// <summary>
        /// 处理飞行至此点子页面点击 取消 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flyToPointFrm_btn_cancel_Click(object sender, EventArgs e)
        {
            flyToPointLay.Clear();
            flyToPointFrm.Close();
            isFlyToPoint = false;
        }

        /// <summary>
        /// 计算插入的测距点
        /// </summary>
        private PointLatLng startmeasure;

        private List<PointLatLng> polygonPoints = new List<PointLatLng>();
        private double rangeList;
        private double last2pointrange;

        private void countRange()
        {
            polygonsoverlay.Polygons.Clear();

            //if (isRange)
            //{
                
            //    startmeasure = MouseDownStart;
            //    polygonsoverlay.Markers.Add(new GMarkerGoogle(MouseDownStart, GMarkerGoogleType.red));
            //    //myGMAP1.Invalidate();
            //    polygonPoints.Add(startmeasure);
            //    if (polygonPoints.Count > 1)
            //    {
                  
            //            GMapPolygon line = new GMapPolygon(polygonPoints, "measure dist");
            //            line.Stroke.Color = Color.Green;
            //            polygonsoverlay.Polygons.Add(line);
            //           // rangeList = this.myGMAP1.MapProvider.Projection.GetDistance(polygonPoints[0], polygonPoints[1]);
            //           // MessageBox.Show("测距结果：" + rangeList);
            //           // this.mapFrm.lbl_pickMousePointReview.Visible = false;
            //            isRange = false;
            //            polygonsoverlay.Polygons.Clear();
            //            polygonsoverlay.Markers.Clear();
            //            polygonPoints.Clear();
            //            rangeList = 0;

                    
            //    }
            //}
            //else
            //{
            //    return;
            //}
        }

        /// <summary>
        /// 地图右键--选择飞机事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private bool isSelectPlane = true;

        private void selectPlane_ToolStripMenuItem(object sender, EventArgs e)
        {
            //MessageBox.Show("请选择飞机");

            //if (isSelectPlane == true)
            //{
            //    isSelectPlane = false;
            //}
            //else
            //{
            //    isSelectPlane = true;
            //}
        }

        /// <summary>
        /// 地图右键--居中--飞机居中 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void planeCenter_ToolStripMenuItem(object sender, EventArgs e)
        {
            //if (mainPlane != null)
            //{
            //   // this.myGMAP1.Position = mainPlane.Position;
            //}
        }

        /// <summary>
        /// 地图右键--居中--航线居中 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void lineCenter_ToolStripMenuItem(object sender, EventArgs e)
        {
            //if (polygonsoverlay.Routes.Count > 1)
            //{
            //    //double zoom = myGMAP1.Zoom;
            //    //myGMAP1.ZoomAndCenterRoute(polygonsoverlay.Routes[1]);
            //    //myGMAP1.Zoom = zoom;
            //    //myGMAP1.Invalidate();
            //}
        }

        /// <summary>
        /// 地图右键--显示--航向 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showHeading_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            //if (mainPlaneModel != null)
            //{
            //    if (mapFrm.showHeading_ToolStripMenuItemReview.CheckState == CheckState.Checked)
            //    {
            //        mainPlaneModel.isShowHeading = true;
            //    }
            //    if (mapFrm.showHeading_ToolStripMenuItemReview.CheckState == CheckState.Unchecked || mapFrm.showHeading_ToolStripMenuItemReview.CheckState == CheckState.Indeterminate)
            //    {
            //        mainPlaneModel.isShowHeading = false;
            //    }
            //}
        }

        /// <summary>
        /// 地图右键--显示--轨迹 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTrack_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            //if (mainPlaneModel != null)
            //{
            //    if (mapFrm.showTrack_ToolStripMenuItemReview.CheckState == CheckState.Checked)
            //    {
            //        mainPlaneModel.isShowTrack = true;
            //    }
            //    if (mapFrm.showTrack_ToolStripMenuItemReview.CheckState == CheckState.Unchecked || mapFrm.showTrack_ToolStripMenuItemReview.CheckState == CheckState.Indeterminate)
            //    {
            //        route.Points.Clear();
            //        mainPlaneModel.isShowTrack = false;
            //    }
            //}
        }

        /// <summary>
        /// 地图右键--显示--航线 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showWayPointLine_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
           // route.Points.Clear();
        }

        /// <summary>
        /// 地图右键--显示--飞机编号 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPlaneID_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            //if (mainPlaneModel != null)
            //{
            //    if (mapFrm.showPlaneID_ToolStripMenuItemReview.CheckState == CheckState.Checked)
            //    {
            //        mainPlaneModel.isShowPlaneID = true;
            //    }
            //    if (mapFrm.showPlaneID_ToolStripMenuItemReview.CheckState == CheckState.Unchecked || mapFrm.showPlaneID_ToolStripMenuItemReview.CheckState == CheckState.Indeterminate)
            //    {
            //        mainPlaneModel.isShowPlaneID = false;
            //    }
            //}
        }

        /// <summary>
        /// 地图右键--清除轨迹 事件处理 by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void clearTracks_ToolStripMenuItemReview_Click(object sender, EventArgs e)
        {
            foreach (var item in mapFrm.routelist)
            {
                if (item.Value.Count>1)
                {
                    item.Value.RemoveRange(0, item.Value.Count - 2);  
                }
                
            } 
        }

        private XmlDocument xmlDoc = new XmlDocument();
        private XmlNode node = null;
        private XmlNode root = null;

        public void CreateXmlSendCommondLog()
        {
            //创建类型声明节点
            node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点
            root = xmlDoc.CreateElement("Log");
            xmlDoc.AppendChild(root);
            try
            {
                xmlDoc.Save(Application.StartupPath + "\\log.xml");
            }
            catch (Exception e)
            {
                //显示错误信息
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="xmldoc"></param>  xml文档
        /// <param name="parentnode"></param>父节点
        /// <param name="name"></param>  节点名
        /// <param name="value"></param>  节点值
        ///
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

        /// <summary>
        /// 菜单栏：发送命令日志记录
        /// </summary>
        /// <param name="sendCommondContext"></param>
        private void SendCommondLogBackHandler(string sendCommondContext)
        {
            xmlDoc.Load(Application.StartupPath + "\\log.xml"); //加载xml文件
            //获取当前log.xml节点索引
            XmlNode xn = xmlDoc.SelectSingleNode("Log");
            XmlNodeList xnl = xn.ChildNodes;
            int index = xnl.Count;

            XmlElement xesub1 = xmlDoc.CreateElement("index");
            if (isSendSuccess)
            {
                xesub1.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   ---   " + sendCommondContext + "   ---   发送成功";//设置节点的文本值
            }
            else
            {
                xesub1.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   ---   " + sendCommondContext + "   ---   发送失败";//设置节点的文本值
            }
            xn.AppendChild(xesub1);//添加到﹤Log﹥节点中
            xmlDoc.Save(Application.StartupPath + "\\log.xml"); //保存其更改
        }

        /// <summary>
        /// 串口设置：串口点击事件************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_comboBoxShow_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 串口设置：串口ComboBox点击下拉框事件************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_comboBoxShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm.comPort.BaseStream = new SerialPort();
            try
            {
                if (!String.IsNullOrEmpty(_communicationSetFrm.serial_comboBoxShow.Text))
                    comPort.BaseStream.PortName = _communicationSetFrm.serial_comboBoxShow.Text;

              //  MainForm.comPort.BaseStream.BaudRate = int.Parse(_communicationSetFrm.baudRate_comboBoxShow.Text);

                // check for saved baud rate and restore
                if (Settings.Instance[_communicationSetFrm.serial_comboBoxShow.Text + "_BAUD"] != null)
                {
                    _communicationSetFrm.baudRate_comboBoxShow.Text =
                        Settings.Instance[_communicationSetFrm.serial_comboBoxShow.Text + "_BAUD"];
                }
            }
            catch
            { }
        }
     
        /// <summary>
        /// 初始化  通讯设置************************************
        /// </summary>
        private void PopulateCommunicationSetFrmList()
        {
            //初始化串口
            _communicationSetFrm.serial_comboBoxShow.Items.Clear();
            _communicationSetFrm.serial_comboBoxShow.Items.AddRange(SerialPort.GetPortNames());
            System.Data.DataSet ds = new System.Data.DataSet();
            if (!File.Exists(Application.StartupPath + "\\serial.xml"))
            //若文件夹不存在则新建文件
            {
                ds.WriteXml(Application.StartupPath + "\\serial.xml");
            }
            else
            {
                ds.ReadXml(Application.StartupPath + "\\serial.xml");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        serialValue = ds.Tables[0].Rows[i][0].ToString();
                        baudRateValue = ds.Tables[0].Rows[i][1].ToString();

                        _communicationSetFrm.serial_comboBoxShow.Text = ds.Tables[0].Rows[i][0].ToString();
                        _communicationSetFrm.baudRate_comboBoxShow.Text = ds.Tables[0].Rows[i][1].ToString();
                        break;
                    }
                }
            }



            _communicationSetFrm.serialMC_comboBoxShow.Items.Clear();
            _communicationSetFrm.serialMC_comboBoxShow.Items.AddRange(SerialPort.GetPortNames());
            System.Data.DataSet dsMC = new System.Data.DataSet();
            if (!File.Exists(Application.StartupPath + "\\mainCtrl_serial.xml"))
            //若文件夹不存在则新建文件
            {
                dsMC.WriteXml(Application.StartupPath + "\\mainCtrl_serial.xml");
            }
            else
            {
                dsMC.ReadXml(Application.StartupPath + "\\mainCtrl_serial.xml");
                if (dsMC.Tables.Count > 0)
                {
                    for (int i = 0; i < dsMC.Tables[0].Rows.Count; i++)
                    {
                        mainCtrl_serialValue = dsMC.Tables[0].Rows[i][0].ToString();
                        mainCtrl_baudRateValue = dsMC.Tables[0].Rows[i][1].ToString();

                        _communicationSetFrm.serialMC_comboBoxShow.Text = dsMC.Tables[0].Rows[i][0].ToString();
                        _communicationSetFrm.baudRateMC_comboBoxShow.Text = dsMC.Tables[0].Rows[i][1].ToString();
                        break;
                    }
                }
            }

            //初始化TCP


            //初始化连接类别
            System.Data.DataSet connectdst = new System.Data.DataSet();
            if (!File.Exists(Application.StartupPath + "\\ConnectType.xml"))
            //若文件夹不存在则新建文件
            {
                connectdst.WriteXml(Application.StartupPath + "\\ConnectType.xml");
            }
            else
            {
                connectdst.ReadXml(Application.StartupPath + "\\ConnectType.xml");
                if (connectdst.Tables.Count > 0)
                {
                    for (int i = 0; i < connectdst.Tables[0].Rows.Count; i++)
                    {
                        if (connectdst.Tables[0].Rows[i][0].ToString().Equals("serial"))
                        {
                            _communicationSetFrm.serial_radioButtonShow.Checked = true;
                        }
                        else if (connectdst.Tables[0].Rows[i][0].ToString().Equals("tcp"))
                        {
                            _communicationSetFrm.TCP_radioButtonShow.Checked = true;
                        }
                        break;
                    }
                }
            }
        }


        private void label4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MainForm.comPort.JY.cs.lat != 0)
            {
                //TXT_homealt.Text = (MainForm.comPort.JY.cs.altasl).ToString("0");
                TXT_homelat.Text = MainForm.comPort.JY.cs.lat.ToString();
                TXT_homelng.Text = MainForm.comPort.JY.cs.lng.ToString();
            }
            else
            {
                CustomMessageBox.Show(
                    "If you're at the field, connect to your APM and wait for GPS lock. Then click 'Home Location' link to set home to your location");
            }
        }

        private void InitDockPanels()
        {
            mapFrm = new MapFrm();
            wpsFrm = new WpsFrm();
            hudFrm = new HudFrm();
            hudview = new HudView();
            duojiFrm = new DuojiView();
            telemetryFrm = new TelemetryFrm();
            commandsFrm = new CommandsFrm();
            telemetryFrm2 = new Telemetry2();
            ganraoji = new Ganraoji();
            microwave = new Microwave();
            xuniFrm = new XuNi();
  
            this.dockMainPanel.Theme = this.vS2005Theme1;
            this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2005, vS2005Theme1);
            IsHiddenView();
        }

        /// <summary>
        /// 是否隐藏视图******************************************************
        /// </summary>
        private void IsHiddenView()
        {
            if (_viewSet != null)
            {
                if (!_viewSet.mapCheckbox)
                {
                    mapFrm.IsHidden = true;
                    wpsFrm.Show(this.dockMainPanel);
                    wpsFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                }
                else
                {
                    mapFrm.Show(this.dockMainPanel);
                    mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                    wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.4);

                }



                if (!_viewSet.headCheckbox)
                {
                    hudFrm.IsHidden = true;
                }
                else
                {
                    hudFrm.Show(this.dockMainPanel, DockState.DockRight);
                }

                if (!_viewSet.mainStatusCheckbox)
                {
                    telemetryFrm.IsHidden = true;
                }
                else
                {
                    if (hudFrm.IsHidden)
                    {
                        telemetryFrm.Show(this.dockMainPanel, DockState.DockRight);
                    }
                    else
                    {
                        telemetryFrm.Show(hudFrm.Pane, DockAlignment.Bottom, 0.5);
                    }
                }
                //telemetryFrm2.Show(this.dockMainPanel, DockState.DockLeftAutoHide);

            }
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
        }

        public enum altmode
        {
            Relative = JYLink.JY_FRAME.GLOBAL_RELATIVE_ALT,
            Absolute = JYLink.JY_FRAME.GLOBAL,
            Terrain = JYLink.JY_FRAME.GLOBAL_TERRAIN_ALT
        }

        public enum Firmwares
        {
            JYPlane,
            ArduPlane,
            ArduCopter2,
            ArduRover,
            Ateryx,
            ArduTracker,
            Gymbal,
            PX4
        }

        public static JYLinkInterface comPort
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
      

        public static JYLinkMainCtrl mainCtrl_comPort
        {
            get
            {
                return _mainCtrl_comPort;
            }
            set
            {
                if (_mainCtrl_comPort == value)
                    return;
                _mainCtrl_comPort = value;
                _mainCtrl_comPort.MavChanged -= instance.mainCtrl_comPort_MavChanged;
                _mainCtrl_comPort.MavChanged += instance.mainCtrl_comPort_MavChanged;
                instance.mainCtrl_comPort_MavChanged(null, null);
            }
        }

        public int AddCommand(JYLink.JY_CMD cmd, double p1, double p2, double p3, double p4, double x, double y,
            double z, object tag = null)
        {
            selectedrow = Commands.Rows.Add();

            FillCommand(this.selectedrow, cmd, p1, p2, p3, p4, x, y, z, tag);

            writeKML();

            return selectedrow;
        }

        public void AddWPToMap(double lat, double lng, int alt)
        {
            if (polygongridmode)
            {
                addPolygonPointToolStripMenuItem_Click(null, null);
                return;
            }

            //if (sethome)
            //{
            //    sethome = false;
            //    callMeDrag("H", lat, lng, alt);
            //    return;
            //}
            // creating a WP

            selectedrow = Commands.Rows.Add();

            if (splinemode)
            {
                //Commands.Rows[selectedrow].Cells[Command.Index].Value = JYLink.JY_CMD.SPLINE_WAYPOINT.ToString();
                //ChangeColumnHeader(JYLink.JY_CMD.SPLINE_WAYPOINT.ToString());
            }
            else
            {
                Commands.Rows[selectedrow].Cells[Command.Index].Value = JYLink.JY_CMD.WAYPOINT.ToString();
                ChangeColumnHeader(JYLink.JY_CMD.WAYPOINT.ToString());
            }

            setfromMap(lat, lng, alt);
        }

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
                    //TXT_homealt.Text = getGEAlt(lat, lng).ToString();
                }
                TXT_homelat.Text = lat.ToString();
                TXT_homelng.Text = lng.ToString();
                return;
            }

            if (pointno == "Tracker Home")
            {
                MainForm.comPort.JY.cs.TrackerLocation = new PointLatLngAlt(lat, lng, alt, "");
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

        public void CheckBatteryShow()
        {
            // ensure battery display is on - also set in hud if current is updated确保电池显示在-也设置在HUD如果电流更新
            if (MainForm.comPort.JY.param.ContainsKey("BATT_MONITOR") &&
                (float)MainForm.comPort.JY.param["BATT_MONITOR"] != 0)
            {
                hud1.batteryon = true;
            }
            else
            {
                hud1.batteryon = false;
            }
        }

        public void doConnect(JYLinkInterface comPort, string portname, string baud)
        {
            bool skipconnectcheck = false;

            comPort.JY.cs.ResetInternals();

            //cleanup any log being played清理正在播放的任何日志
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {
                if (portname.Equals("TCP"))
                {
                    // do autoscan做自动扫描
                    comPort.BaseStream = new TcpSerial(Host, Port, true);
                    // set port, then options设置端口，然后选择
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

                // prevent serialreader from doing anything 防止serialreader做任何事情
                comPort.giveComport = true;

                log.Info("About to do dtr if needed");
                // reset on connect logic.重置连接逻辑
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }

                comPort.giveComport = false;

                // setup to record new logs设置记录新日志

                // reset connect time - for timeout functions重置连接时间-超时功能
                connecttime = DateTime.Now;

                // do the connect做连接

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


                // check for newer firmware检查新固件
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.JY.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter检查固件的原生型。IE arudplane，arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.JY.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                        Strings.NewFirmwareA + item.name + Strings.Pleaseup);
                                    break;
                                }

                                // check the first hit only只检查第一次命中
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

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Connect", comPort.JY.cs.firmware.ToString(),
                    comPort.JY.param.Count.ToString());
                MissionPlanner.Utilities.Tracking.AddTiming("Connect", "Connect Time",
                    (DateTime.Now - connecttime).TotalMilliseconds, "");

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Baud", comPort.BaseStream.BaudRate.ToString(), "");



                // get any rallypoints有rallypoints
                if (MainForm.comPort.JY.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(MainForm.comPort.JY.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    //FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                    double maxdist = 0;


                    if (comPort.JY.param.ContainsKey("RALLY_LIMIT_KM") &&
                        (maxdist / 1000.0) > (float)comPort.JY.param["RALLY_LIMIT_KM"])
                    {
                        CustomMessageBox.Show(Strings.Warningrallypointdistance + " " +
                                              (maxdist / 1000.0).ToString("0.00") + " > " +
                                              (float)comPort.JY.param["RALLY_LIMIT_KM"]);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {

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

      

        public void doConnectMC(JYLinkMainCtrl comPort, string portname, string baud)
        {
            bool skipconnectcheck = false;

            comPort.JY.cs.ResetInternals();

            //cleanup any log being played清理正在播放的任何日志
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {

                comPort.BaseStream = new SerialPort();
                comPort.BaseStream.PortName = portname;
       

                try
                {
                    comPort.BaseStream.BaudRate = int.Parse(baud);
                }
                catch (Exception exp)
                {
                    log.Error(exp);
                }

                // prevent serialreader from doing anything 防止serialreader做任何事情

                log.Info("About to do dtr if needed");
                // reset on connect logic.重置连接逻辑
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }


                // setup to record new logs设置记录新日志

                // reset connect time - for timeout functions重置连接时间-超时功能
                connecttime = DateTime.Now;

                // do the connect做连接

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


                // check for newer firmware检查新固件
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.JY.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter检查固件的原生型。IE arudplane，arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.JY.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                        Strings.NewFirmwareA + item.name + Strings.Pleaseup);
                                    break;
                                }

                                // check the first hit only只检查第一次命中
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

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Connect", comPort.JY.cs.firmware.ToString(),
                    comPort.JY.param.Count.ToString());
                MissionPlanner.Utilities.Tracking.AddTiming("Connect", "Connect Time",
                    (DateTime.Now - connecttime).TotalMilliseconds, "");

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Baud", comPort.BaseStream.BaudRate.ToString(), "");



                // get any rallypoints有rallypoints
                if (MainForm.comPort.JY.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(MainForm.comPort.JY.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    //FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                    double maxdist = 0;


                    if (comPort.JY.param.ContainsKey("RALLY_LIMIT_KM") &&
                        (maxdist / 1000.0) > (float)comPort.JY.param["RALLY_LIMIT_KM"])
                    {
                        CustomMessageBox.Show(Strings.Warningrallypointdistance + " " +
                                              (maxdist / 1000.0).ToString("0.00") + " > " +
                                              (float)comPort.JY.param["RALLY_LIMIT_KM"]);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {

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
                        temp.num = (byte.Parse(items[1], new CultureInfo("en-US")));
                        temp.id = (byte)(int)Enum.Parse(typeof(JYLink.JY_CMD), items[3], false);
                        temp.p1 = ushort.Parse(items[4], new CultureInfo("en-US"));

                        if (temp.id == 99)
                            temp.id = 0;

                        temp.alt = (float)(double.Parse(items[10], new CultureInfo("en-US")));
                        temp.lat = (double.Parse(items[8], new CultureInfo("en-US")));
                        temp.lng = (double.Parse(items[9], new CultureInfo("en-US")));

                        temp.p2 = (ushort)(double.Parse(items[5], new CultureInfo("en-US")));
                        temp.p3 = (ushort)(double.Parse(items[6], new CultureInfo("en-US")));
                        temp.p4 = (ushort)(double.Parse(items[7], new CultureInfo("en-US")));

                        cmds.Add(temp);

                        wp_count++;

                    }
                    catch
                    {
                        CustomMessageBox.Show("Line invalid\n" + line);
                    }
                }
                if (cmds.Count > 0)
                {
                    M_hangdian.Clear();
                    M_hangdian_up.Clear();
                    for (int i = 0; i < cmds.Count; i++)
                    {
                        M_hangdian.Add(ChangeHangdian(cmds[i])); //1224
                        M_hangdian_up.Add(ChangeHangdian(cmds[i])); //1224
                    }
                    mapFrm.TRefresh(M_hangdian);
                }
                sr.Close();

                processToScreen(cmds, append);
                //M_hangdian_up = M_hangdian;
                writeKML();
               
                // this.myGMAP1.ZoomAndCenterMarkers("objects");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Can't open file! " + ex);
            }
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
                if (CHK_verifyheight.Checked && CMB_altmode.Text != altmode.Terrain.ToString()) //Drag with verifyheight // use srtm data
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
                cell.Value = lat.ToString();//1226
                cell.DataGridView.EndEdit();
            }
            if (Commands.Columns[Lon.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][5] /*"Long"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Lon.Index] as DataGridViewTextBoxCell;
                cell.Value = lng.ToString();//1226
                cell.DataGridView.EndEdit();
            }
            if (alt != -1 && alt != -2 &&
                Commands.Columns[Alt.Index].HeaderText.Equals(cmdParamNames["WAYPOINT"][6] /*"Alt"*/))
            {
                cell = Commands.Rows[selectedrow].Cells[Alt.Index] as DataGridViewTextBoxCell;

                {
                    double result;

                }

                cell.Value = TXT_DefaultAlt.Text;

                float ans;
                if (float.TryParse(cell.Value.ToString(), out ans))
                {
                    ans = (int)ans;
                    if (alt != 0) // use passed in value;
                        cell.Value = alt.ToString();
                    if (ans == 0) // default
                        cell.Value = 50;
                    if (ans == 0 && (MainForm.comPort.JY.cs.firmware == MainForm.Firmwares.ArduCopter2))
                        cell.Value = 15;

                    // not online and verify alt via srtm
                    if (CHK_verifyheight.Checked) // use srtm data
                    {
                        // is absolute but no verify
                        if (CMB_altmode.Text == altmode.Absolute.ToString())
                        {
                            //abs
                            cell.Value =
                                ((srtm.getAltitude(lat, lng).alt) * CurrentState.multiplierdist +
                                 int.Parse(TXT_DefaultAlt.Text.ToString())).ToString();
                        }
                        else if (CMB_altmode.Text == altmode.Terrain.ToString())
                        {
                            cell.Value = int.Parse(TXT_DefaultAlt.Text.ToString());
                        }
                        else
                        {
                            //relative and verify
                            cell.Value =
                                ((int)(srtm.getAltitude(lat, lng).alt) * CurrentState.multiplierdist +
                                 int.Parse(TXT_DefaultAlt.Text.ToString()) -
                                 (int)
                                     srtm.getAltitude(MainForm.comPort.JY.cs.HomeLocation.Lat,
                                         MainForm.comPort.JY.cs.HomeLocation.Lng).alt * CurrentState.multiplierdist)
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
            cell = Commands.Rows[selectedrow].Cells[Num.Index] as DataGridViewTextBoxCell;
            if (cell.Value.ToString().Trim()=="0")
            {
                cell.Value = 1;
            }
            cell.DataGridView.EndEdit();
            writeKML();
            Commands.EndEdit();
        }
        PointLatLngAlt mouseposdisplay = new PointLatLngAlt(0, 0);

        /// <summary>
        /// Used for current mouse position
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="alt"></param>
        public void SetMouseDisplay(double lat, double lng, int alt)
        {
            mouseposdisplay.Lat = lat;
            mouseposdisplay.Lng = lng;
            mouseposdisplay.Alt = alt;

            this.coords1.Lat = mouseposdisplay.Lat;
            coords1.Lng = mouseposdisplay.Lng;
           // coords1.Alt = srtm.getAltitude(mouseposdisplay.Lat, mouseposdisplay.Lng, this.myGMAP1.Zoom).alt;

            try
            {
                PointLatLng last;

                if (pointlist.Count == 0 || pointlist[pointlist.Count - 1] == null)
                    return;

                last = pointlist[pointlist.Count - 1];

                //double lastdist = this.myGMAP1.MapProvider.Projection.GetDistance(last, currentMarker.Position);
              //  double lastdist = this.myGMAP1.MapProvider.Projection.GetDistance(last, pointlist[pointlist.Count-2]);

                double lastbearing = 0;

                if (pointlist.Count > 0)
                {
                    //lastbearing = this.myGMAP1.MapProvider.Projection.GetBearing(last, currentMarker.Position);
                }
                //rm.GetString("lbl_prevdist.Text")
               // this.mapFrm.lbl_prevdistShow.Text = "最后两点距离: " + FormatDistance(lastdist, true) + " AZ: " +
                                  //  lastbearing.ToString("0");

                // 0 is home
                if (pointlist[0] != null)
                {
                    //double homedist = this.myGMAP1.MapProvider.Projection.GetDistance(currentMarker.Position, pointlist[0]);
                    //rm.GetString("lbl_homedist.Text")
                    //this.mapFrm.lbl_homedistShow.Text =  "家距离: " + FormatDistance(homedist, true);
                }
            }
            catch
            {
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



                    MainForm.comPort.giveComport = false;

                    writeKML();
                });
            }
            catch (Exception exx)
            {
                log.Info(exx.ToString());
            }
        }

        public void writeKML()
        {
            // quickadd is for when loading wps from eeprom or file, to prevent slow, loading times
            if (quickadd)
                return;

            // this is to share the current mission with the data tab
            pointlist = new List<PointLatLngAlt>();

            fullpointlist.Clear();

            ///Debug.WriteLine(DateTime.Now);
            try
            {
                if (objectsoverlay != null) // hasnt been created yet
                {
                    objectsoverlay.Markers.Clear();
                    objectsoverlay.Routes.Clear();
                }

                // process and add home to the list
                string home;



                //if (TXT_homealt.Text.ToString() != "" && TXT_homelat.Text.ToString() != "" && TXT_homelng.Text.ToString() != "")
                //{
                home = string.Format("{0},{1},{2}\r\n", TXT_homelng.Text, TXT_homelat.Text, "0");

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
                    //if (!String.IsNullOrEmpty(TXT_homealt.Text.ToString()))
                    //    homealt = (int)double.Parse(TXT_homealt.Text.ToString());
                }
                catch
                {
                }

                if (CMB_altmode.Text.ToString() == altmode.Absolute.ToString())
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
                                    Enum.Parse(typeof(JYLink.JY_CMD),
                                        Commands.Rows[a].Cells[Command.Index].Value.ToString(), false);
                        if (command == (byte)JYLink.JY_CMD.WAYPOINT || command == (byte)JYLink.JY_CMD.TAKEOFF
                            || command == (byte)JYLink.JY_CMD.JUMP || command == (byte)JYLink.JY_CMD.LAND)
                        {
                            string cell2 = Commands.Rows[a].Cells[Alt.Index].Value.ToString(); // alt
                            string cell3 = Commands.Rows[a].Cells[Lat.Index].Value.ToString(); // lat
                            string cell4 = Commands.Rows[a].Cells[Lon.Index].Value.ToString(); // lng
                            pointlist.Add(new PointLatLngAlt(double.Parse(cell3), double.Parse(cell4),
                            double.Parse(cell2) + homealt, (a + 1).ToString()));
                            fullpointlist.Add(pointlist[pointlist.Count - 1]);
                            //addpolygonmarker((a + 1).ToString(), double.Parse(cell4), double.Parse(cell3),
                            //double.Parse(cell2), null);
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
                    lookat = "<LookAt>     <longitude>" + TXT_homelng.Text.ToString().ToString(new CultureInfo("en-US")) +
                             "</longitude>     <latitude>" + TXT_homelat.Text.ToString().ToString(new CultureInfo("en-US")) +
                             "</latitude> <range>4000</range> </LookAt>";

                   // RectLatLng? rect = myGMAP1.GetRectOfAllMarkers("objects");
                    //if (rect.HasValue)
                    //{
                    //  //  myGMAP1.Position = rect.Value.LocationMiddle;
                    //}

                    //MainMap.Zoom = 17;

                    //MainMap_OnMapZoomChanged();
                }

                //RegeneratePolygon();

               // RegenerateWPRoute(fullpointlist);

                if (fullpointlist.Count > 0)
                {
                    double homedist = 0;

                    if (home.Length > 5)
                    {
                       // homedist = this.myGMAP1.MapProvider.Projection.GetDistance(fullpointlist[fullpointlist.Count - 1],
                          //  fullpointlist[0]);
                    }

                    double dist = 0;

                    for (int a = 1; a < fullpointlist.Count; a++)
                    {
                        if (fullpointlist[a - 1] == null)
                            continue;

                        if (fullpointlist[a] == null)
                            continue;

                        //dist += this.myGMAP1.MapProvider.Projection.GetDistance(fullpointlist[a - 1], fullpointlist[a]);
                    }
                    //左上角显示两点距离 by lichao
                  //  this.mapFrm.lbl_distanceShow.Text = "总距离" + ": " +
                                     // FormatDistance(dist + homedist, false);
                }

                setgradanddistandaz();
            } 
            catch (Exception ex)
            {
                log.Info(ex.ToString());
            }

            ///Debug.WriteLine(DateTime.Now);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            config(true);
            //SaveConfig();
        }

        private void AddDrawPolygon()
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

        private void addMissionRouteMarker(GMapMarker marker)
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Add(marker);
            });
        }

        private void addpolygonmarker(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.blue);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                MissionPlanner.Common.GMapMarkerRect mBorders = new MissionPlanner.Common.GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    try
                    {
                        mBorders.wprad =
                            (int)(float.Parse(TXT_WPRad.Text.ToString()) / CurrentState.multiplierdist);
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

        private void addpolygonmarker(string tag, double lng, double lat, double alt, Color? color)
        {
            try
            {
                //PointLatLng point = new PointLatLng(lat, lng);
                //MissionPlanner.Common.GMapMarkerWP m = new MissionPlanner.Common.GMapMarkerWP(point, tag);
                ////m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                ////m.ToolTipText = "Alt: " + alt.ToString("0");
                //m.Tag = tag;
                

                //int wpno = -1;
                //if (int.TryParse(tag, out wpno))
                //{
                //    // preselect groupmarker
                //    if (groupmarkers.Contains(wpno))
                //        m.selected = true;
                //}

                ////MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                //MissionPlanner.Common.GMapMarkerRect mBorders = new MissionPlanner.Common.GMapMarkerRect(point);
                //{
                //    mBorders.InnerMarker = m;
                //    mBorders.Tag = tag;
                //    mBorders.wprad = (int)(float.Parse(TXT_WPRad.Text.ToString()) / CurrentState.multiplierdist);
                //    if (color.HasValue)
                //    {
                //        mBorders.Color = color.Value;
                //    }
                //}

                //objectsoverlay.Markers.Add(m);
                //objectsoverlay.Markers.Add(mBorders);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
            }
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
                MissionPlanner.Common.GMapMarkerRect mBorders = new MissionPlanner.Common.GMapMarkerRect(point);
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

        private void addpolygonmarkerred(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                MissionPlanner.Common.GMapMarkerRect mBorders = new MissionPlanner.Common.GMapMarkerRect(point);
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

           // myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);

           // myGMAP1.Invalidate();

            //this.lblDistance.Text = drawnpolygon.Distance.ToString("0.##") + "千米";

            //if (drawnpolygon.Points.Count > 2)
            //{
            //    this.lblArea.Text = calcpolygonarea(drawnpolygon.Points).ToString("#") + "平方米";
            //}
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnArm_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!MainForm.comPort.BaseStream.IsOpen)
                return;

            // arm the MAV
            try
            {
                if (MainForm.comPort.JY.cs.armed)
                    if (CustomMessageBox.Show("Are you sure you want to Disarm?", "Disarm?", MessageBoxButtons.YesNo) !=
                        DialogResult.Yes)
                        return;

                bool ans = MainForm.comPort.doARM(!MainForm.comPort.JY.cs.armed);
                if (ans == false)
                    CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        private void btnAutoFlight_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (MainForm.comPort.JY.cs.connected)
            //{
            //    MainForm.comPort.setMode("Stabilize");

            //    PWM pwm = new PWM();

            //    if (!MainForm.comPort.JY.cs.armed)
            //    {
            //        pwm.Chan1 = MainForm.comPort.JY.cs.Roll;
            //        pwm.Chan2 = MainForm.comPort.JY.cs.Pitch;
            //        pwm.Chan3 = 1000;
            //        pwm.Chan4 = MainForm.comPort.JY.cs.Rudder;
            //        MainForm.comPort.setThrottleUp(pwm);
            //        /*
            //        while(true)
            //        {
            //            MainForm.comPort.setThrottleUp(pwm);

            //            if(MainForm.comPort.MAV.cs.Throttle==1000)
            //            {
            //                break;
            //            }
            //        }*/

            //        bool ans = MainForm.comPort.doARM(true);
            //    }

            //    MainForm.comPort.setMode("Auto");

            //    pwm.Chan1 = MainForm.comPort.JY.cs.Roll;
            //    pwm.Chan2 = MainForm.comPort.JY.cs.Pitch;
            //    pwm.Chan3 = 1500;
            //    pwm.Chan4 = MainForm.comPort.JY.cs.Rudder;
            //    MainForm.comPort.setThrottleUp(pwm);
            //}
            //else
            //{
            //}
        }

        private void btnConnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            //doConnect(comPort, this.cboProtocolType.Text.ToString(), this.cboPort.Text.ToString());
        }

        /// <summary>
        /// 航线查询：读取航点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnReadWaypoints_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Commands.Rows.Count > 0)
            {
                if (
                    //CustomMessageBox.Show("This will clear your existing planned mission, Continue?", "Confirm",
                    //    MessageBoxButtons.OKCancel) != DialogResult.OK
                    CustomMessageBox.Show("查询操作将清除现有航线, 是否继续?", "Confirm",
                        MessageBoxButtons.OKCancel) != DialogResult.OK
                    )
                {
                    return;
                }
            }

            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Receiving WP's"
            };
            angel_init = 0;
            frmProgressReporter.DoWork += getWPs;
            mapFrm.hangdian_cmd.Clear();
           // M_hangdian.Clear();
            frmProgressReporter.UpdateProgressAndStatus(-1, "Receiving WP's");

            frmProgressReporter.RunBackgroundOperationAsync();
            Point p = new Point();
            //frmProgressReporter.Dispose();
            frmProgressReporter.Close();
            for (int i = 0; i < Commands.Rows.Count; i++)
            {
                p.X =Convert.ToInt32( Commands.Rows[i].Cells[Lon.Index].Value);
                p.Y = Convert.ToInt32(Commands.Rows[i].Cells[Lat.Index].Value);
               // M_hangdian.Add(p); //1224
                mapFrm.hangdian_cmd.Add(Commands.Rows[i].Cells[0].Value.ToString());
            }
           // M_hangdian_up = M_hangdian;
        }

        /// <summary>
        /// HOME查询：读取home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnReadHome_ItemClick(object sender, ItemClickEventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            JYLink.jylink_biandui_mode_setup param = new JYLink.jylink_biandui_mode_setup();
            param.status = 1;
            //将制导参数内容发送到飞控
            bool result = port.setupBiandui(param);
        }
        public void btnReadHome_ItemClick2(object sender, ItemClickEventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            JYLink.jylink_biandui_mode_setup param = new JYLink.jylink_biandui_mode_setup();
            param.status = 0;
            //将制导参数内容发送到飞控
            bool result = port.setupBiandui(param);


        }
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

                           // this.myGMAP1.ZoomAndCenterMarkers("objects");
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

        /*
        private void btnSaveWpsFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFile_Click(null, null);
        }

        private void btnSplice_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanMission();

            polygongridmode = false;

            list.Clear();

            objectsoverlay.Markers.Clear();
            objectsoverlay.Routes.Clear();

            if (this.txtSpace.Text == null)
            {
                CustomMessageBox.Show("请输入间距");
                return;
            }

            double distance = 0.0D;

            bool canParse = double.TryParse(this.txtSpace.Text.ToString(), out distance);

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
                AddCommand(JYLink.JY_CMD.WAYPOINT, 0, 0, 0, 0, marker.Position.Lng, marker.Position.Lat, 0);
            }
            updateRowNumbers();
            quickadd = false;
        }*/

        private void btnThrottleDown_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (MainForm.comPort.JY.cs.connected)
            //{
            //    PWM pwm = new PWM();
            //    pwm.Chan1 = MainForm.comPort.JY.cs.Roll;
            //    pwm.Chan2 = MainForm.comPort.JY.cs.Pitch;
            //    pwm.Chan3 = MainForm.comPort.JY.cs.Throttle - 50;
            //    pwm.Chan4 = MainForm.comPort.JY.cs.Rudder;
            //    MainForm.comPort.setThrottleUp(pwm);
            //}
        }

        private void btnThrottleUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (MainForm.comPort.JY.cs.connected)
            //{
            //    PWM pwm = new PWM();
            //    pwm.Chan1 = MainForm.comPort.JY.cs.Roll;
            //    pwm.Chan2 = MainForm.comPort.JY.cs.Pitch;
            //    pwm.Chan3 = MainForm.comPort.JY.cs.Throttle + 50;
            //    pwm.Chan4 = MainForm.comPort.JY.cs.Rudder;
            //    MainForm.comPort.setThrottleUp(pwm);
            //}
        }

        /// <summary>
        ///航线上传：写入航点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnWriteWaypoints_ItemClick(object sender, ItemClickEventArgs e)//1227
        {
            if (Commands.Rows.Count == 0)
            {
                MessageBox.Show("航点不能为空！");
                return;
            }
            //if (TXT_homelng.Text==""||TXT_homelat.Text=="")
            //{
            //    MessageBox.Show("请确认舰位置信息！");
            //    return;
            //}
            // check for invalid grid data
            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                for (int b = 0; b < Commands.ColumnCount - 0; b++)
                {
                    double answer;
                    if (b >1 && b <= 7)
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
                                Enum.Parse(typeof(JYLink.JY_CMD),
                                    Commands.Rows[a].Cells[Command.Index].Value.ToString(), false);
                    /*
                    if (cmd < (byte)JYLink.JY_CMD.LAST &&
                        double.Parse(Commands[Alt.Index, a].Value.ToString()) < double.Parse(TXT_altwarn.Text))
                    {
                        if (cmd != (byte)JYLink.JY_CMD.TAKEOFF &&
                            cmd != (byte)JYLink.JY_CMD.LAND &&
                            cmd != (byte)JYLink.JY_CMD.RETURN_TO_LAUNCH)
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
            ////hangxiangoujng////////

            frmProgressReporter.DoWork += saveWPs;
            frmProgressReporter.UpdateProgressAndStatus(-1, "Sending WP's");

            frmProgressReporter.RunBackgroundOperationAsync();

            frmProgressReporter.Dispose();

          //  this.myGMAP1.Focus();
        }

        private double calcpolygonarea(List<PointLatLng> polygon)
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

        private void cboFlightModel_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void cboFlightModel_EditValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void ChangeColumnHeader(string command)
        {
            try
            {
                if (cmdParamNames.ContainsKey(command))
                    for (int i = 2; i <= 7; i++)
                        Commands.Columns[i].HeaderText = cmdParamNames[command][i - 2];
                else
                    for (int i = 2; i <= 7; i++)
                        Commands.Columns[i].HeaderText = "setme";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }

        private void cleanMission()
        {
            quickadd = true;

            // mono fix
            Commands.CurrentCell = null;

            Commands.Rows.Clear();
            M_hangdian.Clear();
            M_hangdian_up.Clear();
            mapFrm.hangdian_cmd.Clear();
            mapFrm.TRefresh(M_hangdian_up);
            selectedrow = 0;
            quickadd = false;

            writeKML();
        }

        private void clearPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygongridmode = false;
            if (drawnpolygon == null)
                return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Markers.Clear();
           // this.myGMAP1.Invalidate();

            writeKML();
        }

        private void CMB_altmode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CMB_altmode.Text == null)
            {
                CMB_altmode.SelectedValue = 0;
            }
            else
            {
                currentaltmode = (altmode)CMB_altmode.SelectedValue;
            }
        }
        private void Commands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Point p = new Point();
                if (e.RowIndex < 0)
                    return;
                if (e.ColumnIndex == Delete.Index && (e.RowIndex + 0) < Commands.RowCount) // delete
                {
                    quickadd = true;
                    // mono fix
                    Commands.CurrentCell = null;
                    Commands.Rows.RemoveAt(e.RowIndex);
                    //M_hangdian_up.RemoveAt(e.RowIndex);
                   // mapFrm.hangdian_cmd.RemoveAt(e.RowIndex);
                    //mapFrm.TRefresh(M_hangdian);
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
                M_hangdian.Clear();
                M_hangdian_up.Clear();
                mapFrm.hangdian_cmd.Clear();//1944
                for (int i = 0; i < Commands.RowCount; i++)
                {
                    p.X =Convert.ToInt32(Commands.Rows[i].Cells[Lat.Index].Value)/100;
                    p.Y = Convert.ToInt32(Commands.Rows[i].Cells[Lon.Index].Value)/100;
                    M_hangdian.Add(p);
                    M_hangdian_up.Add(p);;//1945
                    mapFrm.hangdian_cmd.Add(Commands.Rows[i].Cells[Command.Index].Value.ToString());
                }
                
                mapFrm.TRefresh(M_hangdian_up);
            }
            catch (Exception)
            {
                CustomMessageBox.Show("Row error");
            }
        }

        private void Commands_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double result;
            if (!double.TryParse(Commands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out result) && e.ColumnIndex != 1 && e.ColumnIndex != 9)
            {
                MessageBox.Show("输入字符不合法！");
                return;
            }
            Point p = new Point();
            Commands_RowEnter(null,
                new DataGridViewCellEventArgs(Commands.CurrentCell.ColumnIndex, Commands.CurrentCell.RowIndex));
            p.X = Convert.ToInt32(Commands.Rows[e.RowIndex].Cells[Lat.Index].Value) / 100;
            p.Y = Convert.ToInt32(Commands.Rows[e.RowIndex].Cells[Lon.Index].Value) / 100;
            mapFrm.hangdian_cmd[e.RowIndex] = Commands.Rows[e.RowIndex].Cells[Command.Index].Value.ToString();
            M_hangdian[e.RowIndex] = p;
            M_hangdian_up[e.RowIndex] = p;
            if (e.ColumnIndex > 1 && e.ColumnIndex < 6)
            {
                double temp = Convert.ToDouble(Commands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (temp < 0)
                { Commands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0"; }
                else if (temp > 65535)
                {
                    Commands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "65535";
                }

            }
            // M_hangdian_up[e.RowIndex] = Changeroute(M_hangdian[e.RowIndex], 0);
            //mapFrm.TRefresh(M_hangdian);
            writeKML();
        }

        private void Commands_DataError(object sender, DataGridViewDataErrorEventArgs e)  
        {
            log.Info(e.Exception + " " + e.Context + " col " + e.ColumnIndex);
            e.Cancel = false;
            e.ThrowException = false;
            //throw new NotImplementedException();
        }

        private void Commands_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[Delete.Index].Value = "X";
//            e.Row.Cells[Up.Index].Value = Resources.up;
 //           e.Row.Cells[Down.Index].Value = Resources.down;
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
                ///Debug.WriteLine("Setting event handle");
            }
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

        private void Commands_SelectionChangeCommitted(object sender, EventArgs e)
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
                        Commands.Rows[selectedrow].Cells[Alt.Index].Value = TXT_DefaultAlt.Text;
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

        private void comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainForm.comPort.JY.sysid);

            HUD.Custom.src = MainForm.comPort.JY.cs;

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
       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       //新改
        private void telecontrol_comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainForm.comPort.JY.sysid);

            HUD.Custom.src = MainForm.comPort.JY.cs;

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

        private void mainCtrl_comPort_MavChanged(object sender, EventArgs e)
        {
       //     log.Info("Mav Changed " + MainForm.mainCtrl_comPort.JY.sysid);

        //    HUD.Custom.src = MainForm.mainCtrl_comPort.JY.cs;

            // when uploading a firmware we dont want to reload this screen.

            //if (this.InvokeRequired)
            //{
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        instance.MyView.Reload();
            //    });
            //}
            //else
            //{
            //    instance.MyView.Reload();
            //}
        }

        private void config(bool write)
        {
            if (write)
            {
                //Settings.Instance["TXT_homelat"] = TXT_homelat.Text ==null ? "": TXT_homelat.Text.ToString();
                //Settings.Instance["TXT_homelng"] = TXT_homelng.Text ==null ? "": TXT_homelng.Text.ToString();
                //Settings.Instance["TXT_homealt"] = TXT_homealt.Text ==null ? "":  TXT_homealt.Text.ToString();
                //Settings.Instance["TXT_WPRad"] = TXT_WPRad.Text ==null ? "": TXT_WPRad.Text.ToString();
                //Settings.Instance["TXT_loiterrad"] =TXT_loiterrad.Text ==null ? "":  TXT_loiterrad.Text.ToString();
                //Settings.Instance["TXT_DefaultAlt"] = TXT_DefaultAlt.Text  ==null ? "": TXT_DefaultAlt.Text.ToString();
                //Settings.Instance["CMB_altmode"] = CMB_altmode.Text == null ? "" : CMB_altmode.Text.ToString();

                Settings.Instance["TXT_homelat"] = TXT_homelat.Text.ToString();
                Settings.Instance["TXT_homelng"] = TXT_homelng.Text.ToString();
                //Settings.Instance["TXT_homealt"] = TXT_homealt.Text.ToString();
                Settings.Instance["TXT_WPRad"] = TXT_WPRad.Text.ToString();
                Settings.Instance["TXT_loiterrad"] = TXT_loiterrad.Text.ToString();
                Settings.Instance["TXT_DefaultAlt"] = TXT_DefaultAlt.Text.ToString();
                Settings.Instance["CMB_altmode"] = CMB_altmode.Text.ToString();
                Settings.Instance["fpcoordmouse"] = coords1.System;
            }
            else
            {
                if (Settings.Instance["TXT_homelat"] != null)
                    MainForm.comPort.JY.cs.HomeLocation.Lat = Settings.Instance.GetDouble("TXT_homelat");

                if (Settings.Instance["TXT_homelng"] != null)
                    MainForm.comPort.JY.cs.HomeLocation.Lng = Settings.Instance.GetDouble("TXT_homelng");

                if (Settings.Instance["TXT_homealt"] != null)
                    MainForm.comPort.JY.cs.HomeLocation.Alt = Settings.Instance.GetDouble("TXT_homealt");

                foreach (string key in Settings.Instance.Keys)
                {
                    switch (key)
                    {
                        case "TXT_WPRad":
                            TXT_WPRad.Text = "" + Settings.Instance[key];
                            break;

                        case "TXT_loiterrad":
                            TXT_loiterrad.Text = "" + Settings.Instance[key];
                            break;

                        case "TXT_DefaultAlt":
                            TXT_DefaultAlt.Text = "" + Settings.Instance[key];
                            break;

                        case "CMB_altmode":
                            //CMB_altmode.Text = "" + Settings.Instance[key];
                            break;
                        case "fpcoordmouse":
                            coords1.System = "" + Settings.Instance[key];
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (e.CloseReason.ToString() == "AppClicked")
                isMouseClickOffMenu = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (CurentRectMarker == null && CurrentRallyPt == null && groupmarkers.Count == 0)
            {
                //toolStripMenuItem1.Enabled = false;
            }
            else
            {
                //toolStripMenuItem1.Enabled = true;
            }

            isMouseClickOffMenu = false; // Just incase
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

        private Locationwp DataViewtoLocationwp(int a)
        {
            try
            {
                Locationwp temp = new Locationwp();
                if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
                {
                    temp.id = (byte)Commands.Rows[a].Cells[Command.Index].Tag;
                }
                else
                {
                    temp.id =
                        (byte)
                            (int)
                                Enum.Parse(typeof(JYLink.JY_CMD),
                                    Commands.Rows[a].Cells[Command.Index].Value.ToString(),
                                    false);
                }
                temp.num = byte.Parse(Commands.Rows[a].Cells[Num.Index].Value.ToString());

                temp.p1 = ushort.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString());

                temp.alt =
                    (float)
                        (double.Parse(Commands.Rows[a].Cells[Alt.Index].Value.ToString()) / CurrentState.multiplierdist);
                temp.lat = (double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString()));
                temp.lng = (double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString()));

                temp.p2 = (ushort)(double.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString()));
                temp.p3 = (ushort)(double.Parse(Commands.Rows[a].Cells[Param3.Index].Value.ToString()));
                temp.p4 = (ushort)(double.Parse(Commands.Rows[a].Cells[Param4.Index].Value.ToString()));

                temp.Tag = Commands.Rows[a].Cells[Tag.Index].Value;

                return temp;
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid number on row " + (a + 1).ToString(), ex);
            }
        }

        private void FillCommand(int rowIndex, JYLink.JY_CMD cmd, double p1, double p2, double p3, double p4, double x,
            double y, double z, object tag = null)
        {
            Commands.Rows[rowIndex].Cells[Command.Index].Value = cmd.ToString();
            Commands.Rows[rowIndex].Cells[Tag.Index].Tag = tag;
            Commands.Rows[rowIndex].Cells[Tag.Index].Value = tag;

            ChangeColumnHeader(cmd.ToString());

            // switch wp to spline if spline checked
            if (splinemode && cmd == JYLink.JY_CMD.WAYPOINT)
            {
                //Commands.Rows[rowIndex].Cells[Command.Index].Value = JYLink.JY_CMD.SPLINE_WAYPOINT.ToString();
                //ChangeColumnHeader(JYLink.JY_CMD.SPLINE_WAYPOINT.ToString());
            }

            if (cmd == JYLink.JY_CMD.WAYPOINT)
            {
                // add delay if supplied
                Commands.Rows[rowIndex].Cells[Param1.Index].Value = p1;

                setfromMap(y, x, (int)z, Math.Round(p1, 1));
            }
            //else if (cmd == JYLink.JY_CMD.LOITER_UNLIM)
            //{
            //    setfromMap(y, x, (int)z);
            //}
            else
            {
                Commands.Rows[rowIndex].Cells[Param1.Index].Value = p1;
                Commands.Rows[rowIndex].Cells[Param2.Index].Value = p2;
                Commands.Rows[rowIndex].Cells[Param3.Index].Value = p3;
                Commands.Rows[rowIndex].Cells[Param4.Index].Value = p4;
                Commands.Rows[rowIndex].Cells[Lat.Index].Value = x;
                Commands.Rows[rowIndex].Cells[Lon.Index].Value = y;
                Commands.Rows[rowIndex].Cells[Alt.Index].Value = z;
            }
        }

        private void flyToHereAltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string alt = "100";

            if (MainForm.comPort.JY.cs.firmware == MainForm.Firmwares.ArduCopter2)
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

            //MainForm.comPort.JY.GuidedMode.z = intalt / CurrentState.multiplierdist;

            //if (MainForm.comPort.JY.cs.mode == "Guided")
            //{
            //    MainForm.comPort.setGuidedModeWP(new Locationwp
            //    {
            //        alt = MainForm.comPort.JY.GuidedMode.z,
            //        lat = MainForm.comPort.JY.GuidedMode.x,
            //        lng = MainForm.comPort.JY.GuidedMode.y
            //    });
            //}
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

        private double getAngleOfLongestSide(List<PointLatLngAlt> list)
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

        private List<Locationwp> GetCommandList()
        {
            List<Locationwp> commands = new List<Locationwp>();

            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                var temp = DataViewtoLocationwp(a);

                commands.Add(temp);
            }

            return commands;
        }

        private double getGEAlt(double lat, double lng)
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

        private void getWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                JYLinkInterface port = MainForm.comPort;

                if (!port.BaseStream.IsOpen)
                {
                    throw new Exception("Please Connect First!");
                }

                MainForm.comPort.giveComport = true;

                param = port.JY.param;

                log.Info("Getting Home");

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Getting WP count");

                log.Info("Getting WP #");
                for (byte i = 1; i < 7; i++)
                {

                    int cmdcount = port.getWPCount(i);
                    //int cmdcount = -1;
                    if (cmdcount == -1)
                    {
                        MessageBox.Show("获取航点信息错误！");
                        log.Info("wp count = -1");
                        MainForm.comPort.giveComport = false;
                        return;
                    }
                    if (cmdcount > 100)
                    {
                        continue;
                    }
                    for (byte a = 0; a < cmdcount; a++)
                    {
                        if (((ProgressReporterDialogue)sender).doWorkArgs.CancelRequested)
                        {
                            ((ProgressReporterDialogue)sender).doWorkArgs.CancelAcknowledged = true;
                            throw new Exception("Cancel Requested");
                        }

                        log.Info("Getting WP" + a);
                        ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / cmdcount, "Getting WP " + a);
                        Thread.Sleep(5);//查询延时

                        Locationwp wp = port.getWP(i, a);

                        if (!wp.Tag.Equals("error"))
                        {
                            cmds.Add(wp);
                        }
                        else
                        {
                            MessageBox.Show("获取航点错误!");
                            break;
                        }
                    }
                }
                //port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done");

                log.Info("Done");
            }
            catch
            {
                MainForm.comPort.giveComport = false;
                throw;
            }
            if (cmds.Count > 0)
            {
                M_hangdian.Clear();
                M_hangdian_up.Clear();
                for (int i = 0; i < cmds.Count; i++)
                {
                    M_hangdian.Add(ChangeHangdian(cmds[i])); //1224
                    M_hangdian_up.Add(ChangeHangdian(cmds[i])); //1224
                }
                // mapFrm.TRefresh(M_hangdian);
            }
            WPtoScreen(cmds);
            MainForm.comPort.giveComport = false;
        }

        private void goHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainForm.comPort.BaseStream.IsOpen)
            {
                CustomMessageBox.Show(Strings.PleaseConnect, Strings.ERROR);
                return;
            }

            //if (MainForm.comPort.JY.GuidedMode.z == 0)
            //{
            //    flyToHereAltToolStripMenuItem_Click(null, null);

            //    if (MainForm.comPort.JY.GuidedMode.z == 0)
            //        return;
            //}

            if (MouseDownStart.Lat == 0 || MouseDownStart.Lng == 0)
            {
                CustomMessageBox.Show(Strings.BadCoords, Strings.ERROR);
                return;
            }

            //Locationwp gotohere = new Locationwp();

            //gotohere.id = (ushort)JYLink.JY_CMD.WAYPOINT;
            //gotohere.alt = MainForm.comPort.JY.GuidedMode.z; // back to m
            //gotohere.lat = (MouseDownStart.Lat);
            //gotohere.lng = (MouseDownStart.Lng);

            //try
            //{
            //    MainForm.comPort.setGuidedModeWP(gotohere);
            //}
            //catch (Exception ex)
            //{
            //    MainForm.comPort.giveComport = false;
            //    CustomMessageBox.Show(Strings.CommandFailed + ex.Message, Strings.ERROR);
            //}
        }

        private void groupmarkeradd(GMapMarker marker)
        {
            ///Debug.WriteLine("add marker " + marker.Tag.ToString());
            groupmarkers.Add(int.Parse(marker.Tag.ToString()));
            if (marker is MissionPlanner.Common.GMapMarkerWP)
            {
                ((MissionPlanner.Common.GMapMarkerWP)marker).selected = true;
            }
            if (marker is MissionPlanner.Common.GMapMarkerRect)
            {
                ((MissionPlanner.Common.GMapMarkerWP)((MissionPlanner.Common.GMapMarkerRect)marker).InnerMarker).selected = true;
            }
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
                    AddCommand(JYLink.JY_CMD.WAYPOINT, 0, 0, 0, 0, item.Lng, item.Lat, item.Alt);
                }

                quickadd = false;

                writeKML();

                //this.myGMAP1.ZoomAndCenterMarkers("objects");
            }
        }

        public void mainloop()
        {
            threadrun = true;
            float head = 0;
            EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);

            DateTime tracklast = DateTime.Now.AddSeconds(0);

            DateTime tunning = DateTime.Now.AddSeconds(0);

            DateTime mapupdate = DateTime.Now.AddSeconds(0);

            DateTime vidrec = DateTime.Now.AddSeconds(0);

            DateTime waypoints = DateTime.Now.AddSeconds(0);

            DateTime updatescreen = DateTime.Now;

            DateTime tsreal = DateTime.Now;
            double taketime = 0;
            double timeerror = 0;
            while (!IsHandleCreated)
                Thread.Sleep(100);

            while (threadrun)
            {
                //if (MainForm.comPort.giveComport)
                //{
                //    Thread.Sleep(50);
                //    updateBindingSource();
                //    continue;
                //}
                if (!MainForm.comPort.logreadmode)
                    Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

                updateBindingSource();
         
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


                    if (updatescreen.AddMilliseconds(300) < DateTime.Now)
                    {
                        try
                        {
                            dataPlayback.updatePlayPauseButton(true);
                            dataPlayback.updateLogPlayPosition();
                        }
                        catch
                        {
                            log.Error("Failed to update log playback pos");
                        }
                        updatescreen = DateTime.Now;
                    }


                    DateTime logplayback = MainForm.comPort.lastlogread;
                    try
                    {
                       if (!MainForm.comPort.giveComport)
                       {
                           MainForm.comPort.readPacket();
                           System.Threading.Thread.Sleep((int)(100 / dataPlayback.LogPlayBackSpeed));
                       }
                      // update currentstate of sysids on the port
                        //foreach (var MAV in MainForm.comPort.JYlist)
                        //{
                        //    try
                        //    {
                        //        MAV.cs.UpdateCurrentSettings(null, false, MainForm.comPort, MAV);
                        //        //MainForm.comPort.JY = MAV;
                                
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        log.Error(ex);
                        //    }
                        //}
                    }
                    catch
                    {
                        log.Error("Failed to read log packet");
                    }

                    double act = (MainForm.comPort.lastlogread - logplayback).TotalMilliseconds;
                    if (act > 9999 || act < 0)
                        act = 0;

                    double ts = 0;
                    if (dataPlayback.LogPlayBackSpeed == 0)
                        dataPlayback.LogPlayBackSpeed = 0.01;
                    try
                    {
                        ts = Math.Min((act / dataPlayback.LogPlayBackSpeed), 1000);
                    }
                    catch
                    {
                    }

                    if (dataPlayback.LogPlayBackSpeed >= 4 && MainForm.speechEnable)
                        MainForm.speechEngine.SpeakAsyncCancelAll();

                    double timetook = (DateTime.Now - tsreal).TotalMilliseconds;
  

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
                    }
                }
                else
                {

                }

                try
                {
                    byte xid = 0x53, xset = 1, xser = 0x51, xjc = 0x52;
                    bool result = false;
                    if (xinbiao.IsOpen)
                    {
                        if (Listbuff.Keys.Contains(xid))
                        {
                            xinbiao_id = Listbuff[0x53][4];
                        }
                        if (xinbiao_id == 0)
                        {
                            xinbiao_id = 255;
                        }

                        if (Listbuff.Keys.Contains(xset) && comPort.BaseStream.IsOpen)
                        {
                            result = MainForm.comPort.setupMicro(GetParm(Listbuff[0x01]), xinbiao_id);
                            Listbuff.Remove(xset);
                        }
                        if (Listbuff.Keys.Contains(xser) && comPort.BaseStream.IsOpen)
                        {
                            MainForm.comPort.searchMicro(xinbiao_id);
                            Listbuff.Remove(xser);
                        }
                        if (Listbuff.Keys.Contains(xjc) && comPort.BaseStream.IsOpen)
                        {
                            MainForm.comPort.searchMicrostatus(xinbiao_id);
                            Listbuff.Remove(xjc);
                        }
                        if (tunning.AddSeconds(10) < DateTime.Now)
                        {
                            foreach (var item in xbsum)
                            {
                                position.id = item.Value.id;
                                position.lat = (float)item.Value.lat;
                                position.lng = (float)item.Value.lng;
                                comPort.setKdjPosition(position);
                                Thread.Sleep(100);
                            }
                            tunning = DateTime.Now;
                        }
                    }
                    
                    
         

                        p2.Clear();
                        try
                        {
                            if (MainForm.comPort.logreadmode)
                            {
                                wpsFrm.gb_heading.Text = CurrentState.head_change.ToString();
                                if (head != CurrentState.head_change)
                                {
                                    for (int i = 0; i < M_hangdian.Count; i++)
                                    {
                                        M_hangdian_up[i] = Changeroute(M_hangdian[i], (CurrentState.head_change * Math.PI / 180));
                                    }
                                }
                                head = CurrentState.head_change;
                            }
                            foreach (var item in mapFrm.routelist)
                            {
                                if (item.Value != null)
                                {
                                    if (item.Value.Count > 0)
                                    {
                                        sum_l = 0;
                                        for (int i = 0; i < item.Value.Count - 1; i++)
                                        {
                                            sum_l += Math.Sqrt(Math.Pow(item.Value[i].X - item.Value[i + 1].X, 2) + Math.Pow(item.Value[i].Y - item.Value[i + 1].Y, 2));
                                        }
                                        if (sum_l > 3000)
                                        {
                                            item.Value.RemoveRange(0, item.Value.Count / 10);
                                        }

                                    }
                                }

                            }
                        }
                        catch (Exception data)
                        {
                            log.Error(data);
                            Tracking.AddException(data);                     
                        }
      
    
                        Point p = new Point();
                        double temp, temp2;
                        mapFrm.TRefresh(M_hangdian_up);//1944
                        if (mainCtrl_comPort.BaseStream.IsOpen)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                targetlabel.Text = CurrentState.BajiId.ToString();
                            });
                        }
                       
                        if (tracklast.AddSeconds(0.8) < DateTime.Now)//change1224
                        {
                            foreach (var port in MainForm.Comports)//2020
                            {
                                foreach (var JY in port.JYlist)
                                {
                                    if (JY.targetid != 0 && JY.targetid != 255)
                                    {
                                        JY.cs.UpdateCurrentSettings(null, false, MainForm.comPort, JY);
                                        if (xinbiao.IsOpen == true)
                                        {
                                            Micro(JY);
                                        }
                                        if (!mapFrm.routelist.ContainsKey(JY.targetid))
                                        {
                                            mapFrm.routelist.Add(JY.targetid, new List<Point>());
                                            //mapFrm.routelist[JY.targetid] = new List<Point>();
                                            mapFrm.plane_angel[JY.targetid] = new float();
                                        }
                                        else
                                        {
                                            if (double.TryParse(this.TXT_homelat.Text, out temp2) && double.TryParse(this.TXT_homelng.Text, out temp2))//1226
                                            {
                                                p1.Lat = Convert.ToDouble(this.TXT_homelat.Text);
                                                p1.Lng = Convert.ToDouble(this.TXT_homelng.Text);
                                                p = LatLng_to_xy(p1, new PointLatLng(JY.cs.lat, JY.cs.lng));
                                                mapFrm.routelist[JY.targetid].Add(p);
                                                mapFrm.plane_angel[JY.targetid] = 360 - JY.cs.yaw;
                                                mapFrm.TRefresh();
                                            }
                                        }
                                        if ((JY.targetid.ToString() == targetlabel.Text) || port.JYlist.Count == 1)
                                        {
                                            youmenmode.Text = JY.cs.YoumenMode;
                                            utctime.Text = JY.cs.utc_hour.ToString("D2") + ":" + JY.cs.utc_minute.ToString("D2") + ":" + JY.cs.utc_second.ToString("D2");
                                            satelite.Text = JY.cs.sateliter.ToString();

                                        }
                                    }
                                }
                            }
                            if (double.TryParse(this.TXT_homeheading.Text, out temp2))
                            {
                                mapFrm.ship_angel = (360 - Convert.ToSingle(this.TXT_homeheading.Text));
                            }
                            tracklast = DateTime.Now;
                        }
                        double tt = 0;
                        if (vidrec.AddSeconds(2.0) < DateTime.Now && comPort.BaseStream.IsOpen && double.TryParse(this.TXT_homelat.Text, out tt) && double.TryParse(this.TXT_homelng.Text, out tt))//1224
                        {
                            JYLink.Warship_home_location_up home = new JYLink.Warship_home_location_up();
                            home.h_lat = Double.Parse(this.TXT_homelat.Text);
                            home.h_lon = Double.Parse(this.TXT_homelng.Text);
                            home.h_head = Convert.ToInt16(Convert.ToDouble(this.TXT_homeheading.Text));
                            home.h_speed = Convert.ToInt16(Convert.ToDouble(this.TXT_homesecond.Text));
                            if (home.h_lat != 0 && home.h_lon != 0)
                            {
                                comPort.setHomePosition(home);

                            }
                            vidrec = DateTime.Now;
                        }                     
                    }
                       
               // }
                catch (Exception ex)
                {
                    log.Error(ex);
                   // Tracking.AddException(ex);
                   // Console.WriteLine("FD Main loop exception " + ex);
                }
            }
           // Console.WriteLine("FD Main loop exit");
        }
        uint[] time_hangshi = new uint[6];
        bool[] time_run = new bool[6];
       
        public Color getColor(int num)
        {
            switch (num)
            {
                case 1: return Color.Red;
                case 2: return Color.Black;
                case 3: return Color.YellowGreen;
                case 4: return Color.Blue;
                case 5: return Color.Orange;
                case 6: return Color.SeaGreen;
                case 7: return Color.PaleGreen;
                case 8: return Color.LightGray;
                case 9: return Color.LightPink;
                case 10: return Color.Aqua;
                case 11: return Color.CadetBlue;
                case 12: return Color.DarkOrange;
                case 13: return Color.DeepPink;
                case 14: return Color.Khaki;
                case 15: return Color.SpringGreen;
                default: return Color.Yellow;

            }
        }
        //更新飞行数据
        private void updateFlightData()
        {
            CheckForIllegalCrossThreadCalls = false;
            // update gps count by lichao
            //GPSProportion_label.Text = (MainForm._comPort.JY.cs.gpsFixStatus&0x04).Equals(4).ToString();
               
            CheckForIllegalCrossThreadCalls = true;
        }
        public void MainMap_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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

           // MouseDownEnd = myGMAP1.FromLocalToLatLng(e.X, e.Y);

            // Console.WriteLine("MainMap MU");

            if (e.Button == MouseButtons.Right) // ignore right clicks
            {
                return;
            }
            if (isPickMousePoint && !isMouseDraging)
            {
                doPickMousePoint(sender, e);
                return;
            }
            if (!isPlan)
            {
                return;
            }
            //如果是测距，则在这里进行处理 by lichao
            if (isRange && !isMouseDraging)
            {
                countRange();

                //isMouseDown = false;
                //AddWPToMap(currentMarker.Position.Lat, currentMarker.Position.Lng, 99);
                return;
            }
            //如果是飞行至此点，则在这里进行处理 by lichao
            if (isFlyToPoint)
            {
                doFlyToPoint(sender, e);
                return;
            }
            if (isMouseDown) // mouse down on some other object and dragged to here.
            {
                // drag finished, update poi db
                //if (CurrentPOIMarker != null)
                //{
                //    POI.POIMove(CurrentPOIMarker);
                //    CurrentPOIMarker = null;
                //}

                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }
                //if (ModifierKeys == Keys.Control)
                //{
                //    // group select wps
                //    GMapPolygon poly = new GMapPolygon(new List<PointLatLng>(), "temp");

                //    poly.Points.Add(MouseDownStart);
                //    poly.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownEnd.Lng));
                //    poly.Points.Add(MouseDownEnd);
                //    poly.Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownStart.Lng));

                //    foreach (var marker in objectsoverlay.Markers)
                //    {
                //        if (poly.IsInside(marker.Position))
                //        {
                //            try
                //            {
                //                if (marker.Tag != null)
                //                {
                //                    groupmarkeradd(marker);
                //                }
                //            }
                //            catch
                //            {
                //            }
                //        }
                //    }

                //    isMouseDraging = false;
                //    return;
                //}
                //if (!isMouseDraging)
                //{
                //    if (CurentRectMarker != null)
                //    {
                //        // cant add WP in existing rect
                //    }
                //    else
                //    {
                //        if (TXT_DefaultAlt.Text == null || TXT_DefaultAlt.Text.ToString().Trim().Length == 0)
                //        {
                //            CustomMessageBox.Show("请设置默认高度");
                //            return;
                //        }
                //        if (TXT_WPRad.Text == null || TXT_WPRad.Text.ToString().Trim().Length == 0)
                //        {
                //            CustomMessageBox.Show("请设置航点半径");
                //            return;
                //        }

                //        AddWPToMap(currentMarker.Position.Lat, currentMarker.Position.Lng, 0);
                //    }
                //}
                //else
                //{
                //    if (groupmarkers.Count > 0)
                //    {
                //        Dictionary<string, PointLatLng> dest = new Dictionary<string, PointLatLng>();

                //        foreach (var markerid in groupmarkers)
                //        {
                //            for (int a = 0; a < objectsoverlay.Markers.Count; a++)
                //            {
                //                var marker = objectsoverlay.Markers[a];

                //                if (marker.Tag != null && marker.Tag.ToString() == markerid.ToString())
                //                {
                //                    dest[marker.Tag.ToString()] = marker.Position;
                //                    break;
                //                }
                //            }
                //        }

                //        foreach (KeyValuePair<string, PointLatLng> item in dest)
                //        {
                //            var value = item.Value;
                //            quickadd = true;
                //            callMeDrag(item.Key, value.Lat, value.Lng, -1);
                //            quickadd = false;
                //        }

                //       // this.myGMAP1.SelectedArea = RectLatLng.Empty;
                //        groupmarkers.Clear();
                //        // redraw to remove selection
                //        writeKML();

                //        CurentRectMarker = null;
                //    }

                    //if (CurentRectMarker != null)
                    //{
                    //    if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                    //    {
                    //        try
                    //        {
                    //            drawnpolygon.Points[
                    //                int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] =
                    //                new PointLatLng(MouseDownEnd.Lat, MouseDownEnd.Lng);
                    //            //this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);
                    //           // this.myGMAP1.Invalidate();
                    //        }
                    //        catch
                    //        {
                    //        }
                    //    }
                    //    else
                    //    {
                    //        callMeDrag(CurentRectMarker.InnerMarker.Tag.ToString(), currentMarker.Position.Lat,
                    //          currentMarker.Position.Lng, -2);
                    //    }
                    //    CurentRectMarker = null;
                    //}
                //}
            }

            isMouseDraging = false;
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

        private void MainMap_OnMapTypeChanged(GMap.NET.MapProviders.GMapProvider type)
        {
        }

        private void MainMap_OnMapZoomChanged()
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

                //按下F5键点击飞机时，更换颜色 by lichao
                if (ModifierKeys == Keys.F5)
                {
                    routes.Markers.Clear();

                    int id;
                    do
                    {
                        Random rd = new Random();
                        id = rd.Next(1, 8);
                    } while (id == mainPlaneModel.colorID);
                    mainPlaneModel.colorID = id;
                }
            }
            catch
            {
            }
        }

        private void MainMap_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is MissionPlanner.Common.GMapMarkerRect)
                {
                    MissionPlanner.Common.GMapMarkerRect rc = item as MissionPlanner.Common.GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                   // this.myGMAP1.Invalidate(false);

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
                if (item is MissionPlanner.Common.GMapMarkerWP)
                {
                    //CurrentGMapMarker = item;
                }
                if (item is GMapMarker)
                {
                    //CurrentGMapMarker = item;
                }
            }
        }

        private void MainMap_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is MissionPlanner.Common.GMapMarkerRect)
                {
                    CurentRectMarker = null;
                    MissionPlanner.Common.GMapMarkerRect rc = item as MissionPlanner.Common.GMapMarkerRect;
                    rc.ResetColor();
                    //this.myGMAP1.Invalidate(false);
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

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
        }

        private void MainMap_OnTileLoadStart()
        {
        }

        private void myGMAP1_Click(object sender, EventArgs e)
        {
        }

        //private void myGMAP1_MouseLeave(object sender, EventArgs e)
        //{
        //    if (marker != null)
        //    {
        //        try
        //        {
        //            if (routes.Markers.Contains(marker))
        //                routes.Markers.Remove(marker);
        //        }
        //        catch
        //        {
        //        }
        //    }
        private void myGMAP1_MouseDown(object sender, MouseEventArgs e)
        {
           // MouseDownStart = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

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
                   // currentMarker.Position = myGMAP1.FromLocalToLatLng(e.X, e.Y);
                }
            }
        }

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

        private void myGMAP1_MouseMove(object sender, MouseEventArgs e)
        {
           //// PointLatLng point = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

           // //if (MouseDownStart == point)
           // //    return;
           // //执行右键--拾取坐标点功能 by lichao
           // if (isPickMousePoint == true)
           // {
           //     //鼠标跟随注释，跟随时会造成界面卡顿 by lichao
           //     //mapFrm.lbl_pickMousePointReview.Location = new Point(e.X, e.Y);

           //     //PointLatLng mouseLatLng = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);
           //     //mapFrm.lbl_pickMousePointReview.Text = "当前坐标：" + mouseLatLng.Lat + "," + mouseLatLng.Lng;
           // }
           // //执行右键--测距 by lichao
           // if (isRange == true)
           // {
           //     //PointLatLng mouseLatLng = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);
           //     //mapFrm.lbl_pickMousePointReview.Text = "当前坐标：" + mouseLatLng.Lat + "," + mouseLatLng.Lng;
           // }

           // //  Console.WriteLine("MainMap MM " + point);

           // //currentMarker.Position = point;

           // if (!isMouseDown)
           // {
           //     // update mouse pos display
           //     SetMouseDisplay(point.Lat, point.Lng, 0);
           // }

           // //draging
           // if (e.Button == MouseButtons.Left && isMouseDown)
           // {
           //     isMouseDraging = true;
           //     if (CurrentRallyPt != null)
           //     {
           //         PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

           //         CurrentRallyPt.Position = pnew;
           //     }
           //     else if (groupmarkers.Count > 0)
           //     {
           //         // group drag

           //         double latdif = MouseDownStart.Lat - point.Lat;
           //         double lngdif = MouseDownStart.Lng - point.Lng;

           //         MouseDownStart = point;

           //         Hashtable seen = new Hashtable();

           //         foreach (var markerid in groupmarkers)
           //         {
           //             if (seen.ContainsKey(markerid))
           //                 continue;

           //             seen[markerid] = 1;
           //             for (int a = 0; a < objectsoverlay.Markers.Count; a++)
           //             {
           //                 var marker = objectsoverlay.Markers[a];

           //                 if (marker.Tag != null && marker.Tag.ToString() == markerid.ToString())
           //                 {
           //                     var temp = new PointLatLng(marker.Position.Lat, marker.Position.Lng);
           //                     temp.Offset(latdif, -lngdif);
           //                     marker.Position = temp;
           //                 }
           //             }
           //         }
           //     }
           //     else if (CurentRectMarker != null) // left click pan
           //     {
           //         try
           //         {
           //             // check if this is a grid point
           //             if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
           //             {
           //                 drawnpolygon.Points[
           //                     int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] =
           //                     new PointLatLng(point.Lat, point.Lng);
           //                 this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);
           //                 this.myGMAP1.Invalidate();
           //             }
           //         }
           //         catch
           //         {
           //         }

           //         PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

           //         // adjust polyline point while we drag
           //         try
           //         {
           //             /*
           //             if (CurrentGMapMarker != null && CurrentGMapMarker.Tag is int)
           //             {
           //                 int? pIndex = (int?)CurentRectMarker.Tag;
           //                 if (pIndex.HasValue)
           //                 {
           //                     if (pIndex < wppolygon.Points.Count)
           //                     {
           //                         wppolygon.Points[pIndex.Value] = pnew;
           //                         lock (thisLock)
           //                         {
           //                             this.myGMAP1.UpdatePolygonLocalPosition(wppolygon);
           //                         }
           //                     }
           //                 }
           //             }*/
           //         }
           //         catch
           //         {
           //         }

           //         // update rect and marker pos.
           //         if (currentMarker.IsVisible)
           //         {
           //             currentMarker.Position = pnew;
           //         }
           //         CurentRectMarker.Position = pnew;

           //         if (CurentRectMarker.InnerMarker != null)
           //         {
           //             CurentRectMarker.InnerMarker.Position = pnew;
           //         }
           //     }
           //     else if (CurrentPOIMarker != null)
           //     {
           //         PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

           //         CurrentPOIMarker.Position = pnew;
           //     }
           //     else if (CurrentGMapMarker != null)
           //     {
           //         PointLatLng pnew = this.myGMAP1.FromLocalToLatLng(e.X, e.Y);

           //         CurrentGMapMarker.Position = pnew;
           //     }
           //     else if (ModifierKeys == Keys.Control)
           //     {
           //         // draw selection box
           //         double latdif = MouseDownStart.Lat - point.Lat;
           //         double lngdif = MouseDownStart.Lng - point.Lng;

           //         this.myGMAP1.SelectedArea = new RectLatLng(Math.Max(MouseDownStart.Lat, point.Lat),
           //             Math.Min(MouseDownStart.Lng, point.Lng), Math.Abs(lngdif), Math.Abs(latdif));
           //     }
           //     else // left click pan
           //     {
           //         double latdif = MouseDownStart.Lat - point.Lat;
           //         double lngdif = MouseDownStart.Lng - point.Lng;

           //         try
           //         {
           //             lock (thisLock)
           //             {
           //                 this.myGMAP1.Position = new PointLatLng(center.Position.Lat + latdif,
           //                     center.Position.Lng + lngdif);
           //             }
           //         }
           //         catch
           //         {
           //         }
           //     }
           // }
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
        //}

        private void myGMAP1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ResetTransform();

            polyicon.Location = new Point(10, 100);
            polyicon.Paint(e.Graphics);
        }

        private void processToScreen(List<Locationwp> cmds, bool append = false)
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
            mapFrm.hangdian_cmd.Clear();
            int i = Commands.Rows.Count - 1;
            foreach (Locationwp temp in cmds)
            {

                i++;
       
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

                foreach (object value in Enum.GetValues(typeof(JYLink.JY_CMD)))
                {
                    if ((int)value == temp.id)
                    {
                        cellcmd.Value = value.ToString();
                        mapFrm.hangdian_cmd.Add(value.ToString());
                        break;
                    }
                }
                Commands.Rows[i].HeaderCell.Value = (1+i).ToString();
                cell = Commands.Rows[i].Cells[Num.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.num;
                cell = Commands.Rows[i].Cells[Alt.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.alt * CurrentState.multiplierdist;
                cell = Commands.Rows[i].Cells[Lat.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.lng;
                cell = Commands.Rows[i].Cells[Lon.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.lat;

                cell = Commands.Rows[i].Cells[Param1.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p1;
                cell = Commands.Rows[i].Cells[Param2.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p2;
                cell = Commands.Rows[i].Cells[Param3.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p3;
                cell = Commands.Rows[i].Cells[Param4.Index] as DataGridViewTextBoxCell;
                cell.Value = temp.p4;
                // convert to utm
                //convertFromGeographic(temp.lat, temp.lng);
            }

            Commands.Enabled = true;
            Commands.ResumeLayout();

            setWPParams();
            quickadd = false;

            writeKML();

            //this.myGMAP1.ZoomAndCenterMarkers("objects");

            // MainMap_OnMapZoomChanged();
        }

        private Dictionary<string, string[]> readCMDXML()
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
                if (MainForm.comPort.JY.cs.firmware == MainForm.Firmwares.ArduPlane ||
                    MainForm.comPort.JY.cs.firmware == MainForm.Firmwares.Ateryx)
                {
                    reader.ReadToFollowing("APM");
                }
                else if (MainForm.comPort.JY.cs.firmware == MainForm.Firmwares.ArduRover)
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

        private void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            if (routes == null)
                return;

            foreach (GMapMarker m in polygons.Markers)
            {
                if (m is MissionPlanner.Common.GMapMarkerRect)
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

                homeroute.Stroke = new Pen(Color.GreenYellow, 2);
                // if we have a large distance between home and the first/last point, it hangs on the draw of a the dashed line.
                if (homepoint.GetDistance(lastpoint) < 5000 && homepoint.GetDistance(firstpoint) < 5000)
                    homeroute.Stroke.DashStyle = DashStyle.Dash;
                //home点和普通航点之间取消虚线
                //polygonsoverlay.Routes.Add(homeroute); //222

                wpRoute.Stroke = new Pen(Color.GreenYellow, 4);
                wpRoute.Stroke.DashStyle = DashStyle.Custom;
                //polygonsoverlay.Routes.Add(wpRoute); //222
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");

                Settings.Instance.APMFirmware = MainForm.comPort.JY.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 加载航线规划
        /// </summary>
        public void LoadFile_Click()
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

                           // this.myGMAP1.ZoomAndCenterMarkers("objects");
                        }
                        else
                        {
                            wpfilename = file;
                            readQGC110wpfile(file);
                        }
                    }

                    // lbl_wpfile.Text = "Loaded " + Path.GetFileName(file);
                }
            }
        }

        /// <summary>
        /// 保存航线规划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveFile_Click(object sender, EventArgs e)
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
                                home.id = (byte)JYLink.JY_CMD.WAYPOINT;
                                home.lat = (double.Parse(TXT_homelat.Text.ToString()));
                                home.lng = (double.Parse(TXT_homelng.Text.ToString()));
                                home.alt = (float.Parse(TXT_homealt.Text.ToString()) / CurrentState.multiplierdist); // use saved home
                            }
                            catch { }

                            //list.Insert(0, home);

                            //var format = MissionFile.ConvertFromLocationwps(list, (byte)(altmode)CMB_altmode.SelectedValue);

                            //MissionFile.WriteFile(file, format);
                            return;
                        }

                        StreamWriter sw = new StreamWriter(file);
                        sw.WriteLine("QGC WPL 110");
                        //try
                        //{
                        //    sw.WriteLine("0\t1\t0\t1\t0\t0\t0\t0\t" +
                        //                 double.Parse(TXT_homelat.Text.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                        //                 "\t" +
                        //                 double.Parse(TXT_homelng.Text.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                        //                 "\t" +
                        //                 double.Parse(TXT_homealt.Text.ToString()).ToString("0.000000", new CultureInfo("en-US")) +
                        //                 "\t1");
                        //}
                        //catch
                        //{
                        //    sw.WriteLine("0\t1\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1");
                        //}
                        for (int a = 0; a < Commands.Rows.Count - 0; a++)
                        {
                            byte mode =
                                (byte)
                                    (JYLink.JY_CMD)
                                        Enum.Parse(typeof(JYLink.JY_CMD), Commands.Rows[a].Cells[Command.Index].Value.ToString());

                            sw.Write((a + 1)); // seq
                            sw.Write("\t" + byte.Parse(Commands.Rows[a].Cells[Num.Index].Value.ToString()));// current

                            //sw.Write("\t" + CMB_altmode.Text.ToString()); //frame
                            sw.Write("\t" + (int)(altmode)Enum.Parse(typeof(altmode), CMB_altmode.Text.ToString()));
                            sw.Write("\t" + mode);
                            sw.Write("\t" +
                                     ulong.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString()));
                            sw.Write("\t" +
                                     ulong.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString()));
                            sw.Write("\t" +
                                     ulong.Parse(Commands.Rows[a].Cells[Param3.Index].Value.ToString()));
                            sw.Write("\t" +
                                     ulong.Parse(Commands.Rows[a].Cells[Param4.Index].Value.ToString()));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString())
                                         .ToString("0.000000", new CultureInfo("en-US")));
                            sw.Write("\t" +
                                     double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString())
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
        public Dictionary<int, FileStream> flielist = new Dictionary<int, FileStream>();
        public Dictionary<int, StreamWriter> stwlist = new Dictionary<int, StreamWriter>();
        private void saveWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            try
            {
                JYLinkInterface port = MainForm.comPort;

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
                    //home.id = (ushort)JYLink.JY_CMD.WAYPOINT;
                    //home.lat = (double.Parse(TXT_homelat.Text.ToString()));
                    //home.lng = (double.Parse(TXT_homelng.Text.ToString()));
                    //home.alt = 0; // use saved home
                }
                catch
                {
                    throw new Exception("Your home location is invalid");
                }

                // log
                log.Info("wps values " + MainForm.comPort.JY.wps.Values.Count);
                log.Info("cmd rows " + (Commands.Rows.Count + 1)); // + home

                // check for changes / future mod to send just changed wp's
                if (MainForm.comPort.JY.wps.Values.Count == (Commands.Rows.Count + 1))
                {
                    Hashtable wpstoupload = new Hashtable();

                    a = -1;
                    foreach (var item in MainForm.comPort.JY.wps.Values)
                    {
                        // skip home
                        if (a == -1)
                        {
                            a++;
                            continue;
                        }

                        JYLink.jylink_mission_item temp = DataViewtoLocationwp(a);

                        if (temp.cmd == item.cmd &&
                            temp.latitude == item.latitude &&
                            temp.longitude == item.longitude &&
                            temp.altitude == item.altitude &&
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

                bool use_int = true;

                // set wp total
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set total wps ");

                ushort totalwpcountforupload = (ushort)(Commands.Rows.Count + 1);

                //if (port.JY.apname == MAVLink.MAV_AUTOPILOT.PX4)
                //{
                //    totalwpcountforupload--;
                //}

                //port.setWPTotal(totalwpcountforupload); // + home

                // set home location - overwritten/ignored depending on firmware.
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set home");

                // upload from wp0
                a = 0;
                // get the command list from the datagrid
                var commandlist = GetCommandList();
                string ss = "";
                for (int i = 0; i < commandlist.Count; i++)
                {
                    ss += commandlist[i].id.ToString();
                }
                string n = Commands.Rows[Commands.Rows.Count - 1].HeaderCell.ToString();
                string[] test = Regex.Split(ss, "33", RegexOptions.IgnoreCase);
                // process commandlist to the mav
                int k = 1;
                for (int i = 0; i < test.Length - 1; i++)
                {

                    for (a = 1; a < test[i].Length + 3; a++)
                    {
                        var temp = commandlist[k - 1];
                        k++;
                        ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(k * 100 / Commands.Rows.Count,
                            "Setting WP " + a);
                        JYLink.JY_MISSION_RESULT ans = port.setWP(test[i].Length + 2, temp, (ushort)(a), 1, use_int);


                        if (ans != JYLink.JY_MISSION_RESULT.JY_MISSION_ACCEPTED)
                        {
                            e.ErrorMessage = "Upload wps failed " + Enum.Parse(typeof(JYLink.JY_CMD), temp.id.ToString()) +
                                             " " + Enum.Parse(typeof(MAVLink.MAV_MISSION_RESULT), ans.ToString());
                            return;
                        }
                    }
                }
                port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(95, "Setting params");

                // m
                port.setParam("WP_RADIUS", float.Parse(TXT_WPRad.Text.ToString()) / CurrentState.multiplierdist);

                // cm's
                port.setParam("WPNAV_RADIUS", float.Parse(TXT_WPRad.Text.ToString()) / CurrentState.multiplierdist * 100.0);

                try
                {
                    port.setParam(new[] { "LOITER_RAD", "WP_LOITER_RAD" },
                        float.Parse(TXT_loiterrad.Text.ToString()) / CurrentState.multiplierdist);
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
            DateTime mapupdate = DateTime.Now;
            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5


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
                            MainForm.comPort.JY.cs.battery_voltage <= warnvolt &&
                            MainForm.comPort.JY.cs.battery_voltage >= 5.0)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainForm.comPort.JY.cs.battery_remaining) < warnpercent &&
                                 MainForm.comPort.JY.cs.battery_voltage >= 5.0 &&
                                 MainForm.comPort.JY.cs.battery_remaining != 0.0)
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
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && MainForm.comPort.JY.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainForm.comPort.JY.cs.airspeed < warnairspeed)
                            {
                                if (MainForm.speechEngine.IsReady)
                                {
                                    MainForm.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainForm.comPort.JY.cs.groundspeed < warngroundspeed)
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
                            altwarningmax = (int)Math.Max(MainForm.comPort.JY.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && MainForm.comPort.JY.cs.alt != 0.00 &&
                                (MainForm.comPort.JY.cs.alt <= warnalt) && MainForm.comPort.JY.cs.armed)
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
                                lastmessagehigh != MainForm.comPort.JY.cs.messageHigh && MainForm.comPort.JY.cs.messageHigh != null)
                            {
                                if (!MainForm.comPort.JY.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainForm.speechEngine.SpeakAsync(MainForm.comPort.JY.cs.messageHigh);
                                    lastmessagehigh = MainForm.comPort.JY.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainForm.comPort.JY.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainForm.comPort.JY.cs.linkqualitygcs = (ushort)(MainForm.comPort.JY.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw is no other packets are being read
                            hud1.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainForm.comPort.JY.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainForm.comPort.logreadmode || comPort.BaseStream.IsOpen)
                        && MainForm.comPort.JY.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainForm.speechEngine.IsReady)
                            {
                                MainForm.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - MainForm.comPort.JY.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainForm.comPort.JY.cs.armed && comPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainForm.comPort.JY.cs.armed;
                        // status just changed to armed
                        if (MainForm.comPort.JY.cs.armed == true)
                        {
                            try
                            {
                             //   MainForm.comPort.JY.cs.HomeLocation = new PointLatLngAlt(MainForm.telecontrol_comPort.getWP(0));
                                updateHome();
 
                            }
                            catch
                            {
                                // dont hang this loop
                                this.BeginInvoke(
                                    (MethodInvoker)
                                        delegate
                                        {
                                            CustomMessageBox.Show("Failed to update home location (" +
                                                                  MainForm.comPort.JY.sysid + ")");
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
                                if (!MainForm.comPort.logreadmode)
                                {
                                    if (mapupdate.AddSeconds(0.4) < DateTime.Now)// && comPort.BaseStream.BytesToRead>0)
                                    {

                                        foreach (var JY in port.JYlist)
                                        {
                                            JY.cs.UpdateCurrentSettings(null, false, MainForm.comPort, JY);
                                            if (port.activeDir != null&&JY.targetid!=0)
                                            {
                                                if (!flielist.ContainsKey(JY.targetid))
                                                {
                                                    flielist[JY.targetid] = new FileStream(port.activeDir + "\\靶机编号：" + JY.targetid.ToString() + ".txt", FileMode.Create, FileAccess.Write);
                                                    stwlist[JY.targetid] = new StreamWriter(flielist[JY.targetid], System.Text.Encoding.GetEncoding("GB2312"));
                                                    stwlist[JY.targetid].WriteLine(Headtext);
                                                }
                                                else
                                                {
                                                    if (JY.cs.telecommand!=null)
                                                    {
                                                        stwlist[JY.targetid].WriteLine(Getdata(JY));
                                                        stwlist[JY.targetid].Flush();
                                                        flielist[JY.targetid].Flush(); 
                                                    }
                                                    
                                                }
                                            }
                                        }

                                        mapupdate = DateTime.Now;
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                        // update currentstate of sysids on the port
                        foreach (var JY in port.JYlist)
                        {
                            try
                            {
                                JY.cs.UpdateCurrentSettings(null, false, port, JY);
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
                       // comPort.Close();
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
        private string Getdata(JYState JY)
        {
            string s, lng = "", lat = "", heading = "", speed = "";
            if (TXT_homelng!=null)
            {
                lng = TXT_homelng.Text; 
            }
            if (TXT_homelat != null)
            {
                lat = TXT_homelat.Text;
            }
            if (TXT_homeheading != null)
            {
                heading = TXT_homeheading.Text;
            }
            if (TXT_homesecond != null)
            {
                speed = TXT_homesecond.Text;
            }
            s = string.Format("{0,-3}", JY.cs.utc_hour.ToString("D2")) + string.Format("{0,-3}", JY.cs.utc_minute.ToString("D2")) + string.Format("{0,-3}", JY.cs.utc_second.ToString("D2")) + string.Format("{0,-5}", JY.cs.sateliter.ToString())
                               + string.Format("{0,-12}", JY.cs.lng.ToString("0.000000")) + string.Format("{0,-12}", JY.cs.lat.ToString("0.000000")) + string.Format("{0,-6}", ((UInt32)JY.cs.zuhe_altitude).ToString()) + string.Format("{0,-7}", JY.cs.roll.ToString("0.0")) + string.Format("{0,-7}", JY.cs.pitch.ToString("0.0"))
                               + string.Format("{0,-7}", JY.cs.yaw.ToString("0.0")) + string.Format("{0,-8}", JY.cs.east_speed.ToString("0.0")) + string.Format("{0,-8}", JY.cs.north_speed.ToString("0.0")) + string.Format("{0,-8}", JY.cs.air_speed.ToString("0.0"))
                               + string.Format("{0,-9}", JY.cs.ecu_voltage1.ToString("0.0")) + string.Format("{0,-9}", JY.cs.rpm.ToString("0.0")) + string.Format("{0,-9}", JY.cs.ecu_pw.ToString("N0")) + alignmentStrFunc(JY.cs.ecu_errorno,16) +alignmentStrFunc(JY.cs.telecommand,14)
                               + string.Format("{0,-13}", lng) + string.Format("{0,-13}", lat) + string.Format("{0,-11}", heading) + string.Format("{0,-6}", speed);

            return s;
        }
        private string alignmentStrFunc(string strTemp, int length)
        {
            byte[] byteStr = System.Text.Encoding.Default.GetBytes(strTemp.Trim());

            int iLength = byteStr.Length;

            int iNeed = length - iLength;



            byte[] spaceLen = Encoding.Default.GetBytes(" "); //一个空格的长度

            iNeed = iNeed / spaceLen.Length;



            string spaceString = SpaceStrFunc(iNeed);

            return strTemp + spaceString;



        }
        private string SpaceStrFunc(int length)
        {
            string strReturn = string.Empty;

            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    strReturn += " ";

                }

            }

            return strReturn;

        }
        private void mainCtrlReader()
        {
            if (mainCtrlThread == true)
                return;
            mainCtrlThread = true;

            mainCtrlThreadrunner.Reset();

            int minbytes = 0;


            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;


            while (mainCtrlThread)
            {
                try
                {
                    Thread.Sleep(200); // was 5

                    // if not connected or busy, sleep and loop
                    if (!mainCtrl_comPort.BaseStream.IsOpen )
                    {
                        if (!mainCtrl_comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in MainCtrlComports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("MainCtrl comport shut, swapping to other mav");
                                    mainCtrl_comPort = port;
                                    break;
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in MainCtrlComports.ToArray())
                    {
                        if ((!port.BaseStream.IsOpen)||( mainCtrl_comPort.LinkState == false ))
                        {
                            // skip primary interface
                            if (port == mainCtrl_comPort)
                                continue;

                            // modify array and drop out
                            MainCtrlComports.Remove(port);
                            break;
                        }
                        else
                        {
                            if (!MainForm.comPort.giveComport)
                            {
                                mainCtrl_comPort.getHeartBeat();
                            }
                        }



                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                //    try
                //    {
                //        mainCtrl_comPort.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        log.Error(ex);
                //    }
                }
            }

            Console.WriteLine("SerialReader Done");
            mainCtrlThreadrunner.Set();
        }

        private void setgradanddistandaz()
        {
            int a = 0;
            PointLatLngAlt last = MainForm.comPort.JY.cs.HomeLocation;
            List<double> dis = new List<double>();
            double  hulength, speed;
            dis.Add(0);
            foreach (var lla in pointlist)
            {
                if (lla == null)
                    continue;
                try
                {
                    hulength = 0;
                    if (lla.Tag != null && lla.Tag != "H" && int.Parse(lla.Tag) > 1)
                    {
                        if (Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Command.Index].Value.ToString() == "WAYPOINT" && Commands.Rows[int.Parse(lla.Tag) - 2].Cells[Command.Index].Value.ToString() == "LAND")
                        {
                            last = MainForm.comPort.JY.cs.HomeLocation;
                            dis.Add(0);
                        }
                    }
                    if (lla.Tag != null && lla.Tag != "H" && !lla.Tag.Contains("ROI"))
                    {
                        double height = lla.Alt - last.Alt;
                        double distance = lla.GetDistance(last) * CurrentState.multiplierdist;
                        double grad = height / distance;

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Grad.Index].Value =
                            (grad * 100).ToString("0.0");

                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Angle.Index].Value =
                            ((180.0 / Math.PI) * Math.Atan(grad)).ToString("0.0");

                        if (int.Parse(lla.Tag) > 1)
                        {
                            if (Commands.Rows[int.Parse(lla.Tag) - 1].HeaderCell.Value==null)
                            {
                                Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value =
                               (Math.Sqrt(Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lat - pointlist[int.Parse(lla.Tag) - 2].Lat, 2) + Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lng - pointlist[int.Parse(lla.Tag) - 2].Lng, 2))).ToString("0");                 
                            }
                            else if (!Commands.Rows[int.Parse(lla.Tag) - 1].HeaderCell.Value.ToString().Contains("-1"))
                            {
                                Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value =
                               (Math.Sqrt(Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lat - pointlist[int.Parse(lla.Tag) - 2].Lat, 2) + Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lng - pointlist[int.Parse(lla.Tag) - 2].Lng, 2))).ToString("0");                 
                        
                            }
                            else
                            {
                                Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value = Math.Sqrt(Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lat, 2) + Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lng, 2)).ToString("0");
                            }
                        }
                        else
                        {

                            Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value = Math.Sqrt(Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lat, 2) + Math.Pow(pointlist[int.Parse(lla.Tag) - 1].Lng, 2)).ToString("0");
                        }
                        Commands.Rows[int.Parse(lla.Tag) - 1].Cells[AZ.Index].Value =
                            ((lla.GetBearing(last) + 180) % 360).ToString("0");
                        dis[dis.Count - 1] += Convert.ToDouble( Commands.Rows[int.Parse(lla.Tag) - 1].Cells[Dist.Index].Value)/1000.0; 
                    }
                }
                catch
                {
                }
                a++;
                last = lla;
            }
            double length=0;
            label6.Text = "总距离:";
            for (int i = 0; i < dis.Count; i++)
            {
                label6.Text += (i + 1).ToString() + "号航线" + dis[i].ToString("0.00") + " Km" + "  ";
            }
            //label6.Text = "总距离:" + length.ToString("0.0 Km");
        }

        private void setWPParams()
        {
            try
            {
                log.Info("Loading wp params");

                Hashtable param = new Hashtable((Hashtable)MainForm.comPort.JY.param);

                if (param["WP_RADIUS"] != null)
                {
                    TXT_WPRad.Text = (((double)param["WP_RADIUS"] * CurrentState.multiplierdist)).ToString();
                }
                if (param["WPNAV_RADIUS"] != null)
                {
                    TXT_WPRad.Text = (((double)param["WPNAV_RADIUS"] * CurrentState.multiplierdist / 100.0)).ToString();
                }

                log.Info("param WP_RADIUS " + TXT_WPRad.Text);

                try
                {
                    TXT_loiterrad.Enabled = false;
                    if (param["LOITER_RADIUS"] != null)
                    {
                        TXT_loiterrad.Text = (((double)param["LOITER_RADIUS"] * CurrentState.multiplierdist)).ToString();
                        TXT_loiterrad.Enabled = true;
                    }
                    else if (param["WP_LOITER_RAD"] != null)
                    {
                        TXT_loiterrad.Text = (((double)param["WP_LOITER_RAD"] * CurrentState.multiplierdist)).ToString();
                        TXT_loiterrad.Enabled = true;
                    }

                    log.Info("param LOITER_RADIUS " + TXT_loiterrad.Text);
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

        private void splitContainerControl1_Panel1_Resize(object sender, EventArgs e)
        {
            this.hud1.doResize();
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

                      //  this.myGMAP1.UpdatePolygonLocalPosition(drawnpolygon);

                      //  this.myGMAP1.Invalidate();
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
              //  this.myGMAP1.Invalidate(true);

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

        private void TXT_homealt_TextChanged(object sender, EventArgs e)
        {
            sethome = false;
            try
            {
                MainForm.comPort.JY.cs.HomeLocation.Alt = double.Parse(TXT_homealt.Text.ToString());
            }
            catch
            {
            }
            writeKML();
        }

        private void TXT_homelat_TextChanged(object sender, EventArgs e)
        {
            sethome = false;
            try
            {
                MainForm.comPort.JY.cs.HomeLocation.Lat = double.Parse(TXT_homelat.Text.ToString());
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
                MainForm.comPort.JY.cs.HomeLocation.Lng = double.Parse(TXT_homelng.Text.ToString());
                if (KongYu_init[0].Lat != 0 && KongYu_init[0].Lng != 0)
                {
                    setKongyu_ItemClick(KongYu_init);
                    mapFrm.Refresh();
                }
            }
            catch
            {
            }
            writeKML();
        }

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
                    updateBindingSourceWork();//2020

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
                Invoke((MethodInvoker)delegate
                {
                    foreach (var port in MainForm.Comports)
                    {
                        // draw the mavs seen on this port
                        foreach (var JY in port.JYlist)
                        {

                            JY.cs.UpdateCurrentSettings(null, false, MainForm.comPort, JY);
                            if (targetlabel.Text == JY.targetid.ToString() && JY.cs.second_count != 0)
                            {
                                utctime.Text = JY.cs.utc_hour.ToString("D2") + ":" + JY.cs.utc_minute.ToString("D2") + ":" + JY.cs.utc_second.ToString("D2");
                                JY.cs.UpdateCurrentSettings(telemetryFrm2.bindingSource1);
                                JY.cs.UpdateCurrentSettings(ganraoji.bindingSourceGanraoji, false, MainForm.comPort, JY);
                                JY.cs.UpdateCurrentSettings(hudFrm.bindingSourceHud, false, MainForm.comPort, JY);
                                JY.cs.UpdateCurrentSettings(telemetryFrm.bindingSourceQuickTab, false, MainForm.comPort, JY);
                            }
                            if (Table_id.Count > 0)
                            {
                                if (JY.targetid == Table_id[0] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource1, false, MainForm.comPort, JY);
                                    hudview.gps11.BackColor = hudview.gps1.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav11.BackColor = hudview.nav1.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ1.BackColor = hudview.ZJ11.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD1.BackColor = hudview.BD11.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu1.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu1.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu1.BackColor = Color.Green;
                                    }
                                    //hudview.dh1.BackColor = hudview.dh11.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                    //hudview.qd1.BackColor = hudview.qd11.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                    //hudview.qs1.BackColor = hudview.qs11.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                    //hudview.cw1.BackColor = hudview.cw11.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                    //hudview.cz1.BackColor = hudview.cz11.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;

                                }
                                if (JY.targetid == Table_id[1] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource2, false, MainForm.comPort, JY);
                                    hudview.gps22.BackColor = hudview.gps2.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav22.BackColor = hudview.nav2.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ2.BackColor = hudview.ZJ22.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD2.BackColor = hudview.BD22.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu2.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu2.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu2.BackColor = Color.Green;
                                    }
                                //    hudview.dh2.BackColor = hudview.dh22.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                //    hudview.qd2.BackColor = hudview.qd22.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                //    hudview.qs2.BackColor = hudview.qs22.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                //    hudview.cw2.BackColor = hudview.cw22.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                //    hudview.cz2.BackColor = hudview.cz22.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;
                                }
                                if (JY.targetid == Table_id[2] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource3, false, MainForm.comPort, JY);
                                    hudview.gps33.BackColor = hudview.gps3.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav33.BackColor = hudview.nav3.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ3.BackColor = hudview.ZJ33.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD3.BackColor = hudview.BD33.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu3.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu3.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu3.BackColor = Color.Green;
                                    }
                                //    hudview.dh3.BackColor = hudview.dh33.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                //    hudview.qd3.BackColor = hudview.qd33.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                //    hudview.qs3.BackColor = hudview.qs33.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                //    hudview.cw3.BackColor = hudview.cw33.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                //    hudview.cz3.BackColor = hudview.cz33.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;
                                }
                                if (JY.targetid == Table_id[3] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource4, false, MainForm.comPort, JY);
                                    hudview.gps44.BackColor = hudview.gps4.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav44.BackColor = hudview.nav4.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ4.BackColor = hudview.ZJ44.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD4.BackColor = hudview.BD44.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu4.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu4.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu4.BackColor = Color.Green;
                                    }
                                //    hudview.dh4.BackColor = hudview.dh44.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                //    hudview.qd4.BackColor = hudview.qd44.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                //    hudview.qs4.BackColor = hudview.qs44.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                //    hudview.cw4.BackColor = hudview.cw44.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                //    hudview.cz4.BackColor = hudview.cz44.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;
                                }
                                if (JY.targetid == Table_id[4] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource5, false, MainForm.comPort, JY);
                                    hudview.gps55.BackColor = hudview.gps5.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav55.BackColor = hudview.nav5.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ5.BackColor = hudview.ZJ55.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD5.BackColor = hudview.BD55.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu5.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu5.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu5.BackColor = Color.Green;
                                    }
                                    //hudview.dh5.BackColor = hudview.dh55.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                    //hudview.qd5.BackColor = hudview.qd55.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                    //hudview.qs5.BackColor = hudview.qs55.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                    //hudview.cw5.BackColor = hudview.cw55.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                    //hudview.cz5.BackColor = hudview.cz55.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;
                                }
                                if (JY.targetid == Table_id[5] && JY.cs.second_count != 0)
                                {

                                    JY.cs.UpdateCurrentSettings(hudview.bindingSource6, false, MainForm.comPort, JY);
                                    hudview.gps66.BackColor = hudview.gps6.BackColor = ((JY.cs.position_state & 1) == 1) ? Color.Green : Color.Red;
                                    hudview.nav66.BackColor = hudview.nav6.BackColor = ((JY.cs.position_state & 2) == 2) ? Color.Green : Color.Red;
                                    hudview.ZJ6.BackColor = hudview.ZJ66.BackColor = ((JY.cs.position_state & 64) == 64) ? Color.Green : Color.Red;
                                    hudview.BD6.BackColor = hudview.BD66.BackColor = ((JY.cs.position_state & 128) == 128) ? Color.Green : Color.Red;
                                    if (JY.cs.sateliter < 7)
                                    {
                                        hudview.xingshu6.BackColor = Color.Red;
                                    }
                                    else if (JY.cs.sateliter < 10)
                                    {
                                        hudview.xingshu6.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        hudview.xingshu6.BackColor = Color.Green;
                                    }
                                    //hudview.dh6.BackColor = hudview.dh66.BackColor = (byte.Parse(JY.cs.ecu_byte) & 8) == 8 ? Color.Red : Color.Lime;
                                    //hudview.qd6.BackColor = hudview.qd66.BackColor = (byte.Parse(JY.cs.ecu_byte) & 16) == 16 ? Color.Red : Color.Lime;
                                    //hudview.qs6.BackColor = hudview.qs66.BackColor = (byte.Parse(JY.cs.ecu_byte) & 32) == 32 ? Color.Red : Color.Lime;
                                    //hudview.cw6.BackColor = hudview.cw66.BackColor = (byte.Parse(JY.cs.ecu_byte) & 64) == 64 ? Color.Red : Color.Lime;
                                    //hudview.cz6.BackColor = hudview.cz66.BackColor = (byte.Parse(JY.cs.ecu_byte) & 128) == 128 ? Color.Red : Color.Lime;
                                }
                            }

                            Thread.Sleep(5);
                            Application.DoEvents();
                        }
                    }
                    lastscreenupdate = DateTime.Now;
                });
                //Console.Write("bindingSource1 ");
                //MainForm.comPort.JY.cs.UpdateCurrentSettings(bindingSource1);
                //Console.Write("bindingSourceHud ");

            }
            catch
            {
            }
        }

        private void updateClearMissionRouteMarkers()
        {
            // not async
            Invoke((MethodInvoker)delegate
            {
                polygons.Routes.Clear();
                polygons.Markers.Clear();
                routes.Markers.Clear();//111
            });
        }

        private void updateClearRoutesMarkers()
        {
            Invoke((MethodInvoker)delegate
            {
                routes.Markers.Clear();//111
            });
        }

        private void updateCMDParams()
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

        private void updateHomeText()
        {
            // set home location
            if (MainForm.comPort.JY.cs.HomeLocation.Lat != 0 && MainForm.comPort.JY.cs.HomeLocation.Lng != 0)
            {
                TXT_homelat.Text = MainForm.comPort.JY.cs.HomeLocation.Lat.ToString();

                TXT_homelng.Text = MainForm.comPort.JY.cs.HomeLocation.Lng.ToString();

                //TXT_homealt.Text = MainForm.comPort.JY.cs.HomeLocation.Alt.ToString();

                writeKML();
            }
        }

        private void updateMapPosition(PointLatLng currentloc)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    if (lastmapposchange.Second != DateTime.Now.Second)
                    {
                       // this.myGMAP1.Position = currentloc;
                        lastmapposchange = DateTime.Now;
                    }
                    //hud1.Refresh();
                }
                catch
                {
                }
            });
        }

        private void updateMapZoom(int zoom)
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                   // myGMAP1.Zoom = zoom;
                }
                catch
                {
                }
            });
        }

        private void updateRowNumbers()
        {
            // number rows
            this.BeginInvoke((MethodInvoker)delegate
            {
                int k = 1, n = 1, count = 1;
                for (int i = 0; i < Commands.Rows.Count; i++)
                {
                    if (Commands.Rows.Count > 1 && i > 0)
                    {
                        if ((Commands.Rows[i - 1].Cells[1].Value.ToString() == "LAND" && Commands.Rows[i].Cells[1].Value.ToString() == "WAYPOINT"))
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
                if (count > 1)
                {
                    Commands.RowHeadersWidth = 70;
                }
                else
                {
                    Commands.RowHeadersWidth = 50;
                }
                // thread for updateing row numbers
                for (int a = 0; a < Commands.Rows.Count; a++)
                {
                    try
                    {
                        //if (Commands.Rows[a].HeaderCell.Value == null)
                        //{
                        //    //Commands.Rows[a].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        //    Commands.Rows[a].HeaderCell.Value = (a + 1).ToString();
                        //}
                        //// skip rows with the correct number
                        //string rowno = Commands.Rows[a].HeaderCell.Value.ToString();
                        //if (!rowno.Equals((a + 1).ToString()))
                        //{
                        //    // this code is where the delay is when deleting.
                        //    Commands.Rows[a].HeaderCell.Value = (a + 1).ToString();
                        //}
                        if (a > 0 && Commands.Rows.Count > 1)
                        {
     
                            if (!(Commands.Rows[a - 1].Cells[1].Value.ToString() == "LAND" && Commands.Rows[a].Cells[1].Value.ToString() == "WAYPOINT"))
                            {
                                if (count == 1)
                                {
                                    Commands.Rows[a].HeaderCell.Value = n.ToString();
                                }
                                else
                                {
                                    Commands.Rows[a].HeaderCell.Value = k.ToString() + "-" + n.ToString();
                                }
                            }
                            if ((Commands.Rows[a - 1].Cells[1].Value.ToString() == "LAND" && Commands.Rows[a].Cells[1].Value.ToString() == "WAYPOINT"))
                            {
                                k++;
                                n = 1;
                                Commands.Rows[a].HeaderCell.Value = k.ToString() + "-" + n.ToString();
                            }

                        }
                        else
                        {
                            if (count == 1)
                            {
                                Commands.Rows[a].HeaderCell.Value = n.ToString();
                            }
                            else
                            {
                                Commands.Rows[a].HeaderCell.Value = k.ToString() + "-" + n.ToString();
                            }
                        }
                        n++;
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        private void 清楚多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polygongridmode = false;
            if (drawnpolygon == null)
                return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Markers.Clear();
          //  this.myGMAP1.Invalidate();

            writeKML();
        }

        public void clearMissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMission();
        }

        private void 设置家在这ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TXT_homealt.Text = srtm.getAltitude(MouseDownStart.Lat, MouseDownStart.Lng).alt.ToString("0");
            TXT_homelat.Text = MouseDownStart.Lat.ToString();
            TXT_homelng.Text = MouseDownStart.Lng.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.dockMainPanel.Width = this.dockMainPanel.Width + 1;
            this.dockMainPanel.Width = this.dockMainPanel.Width - 1;

            tabStatus.AutoScroll = true;

            InitTelemetryStatus();          
            typeof(Control).GetMethod("OnResize", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(tabStatus, new object[] { EventArgs.Empty });
        }

        private void InitTelemetryStatus()
        {
            int x = 10;
            int y = 10;

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

                if (field.Name.Equals("Roll")
                    || field.Name.Equals("Pitch"))
                {
                    continue;
                }

                MyLabel lbl1 = null;
                MyLabel lbl2 = null;
                try
                {
                    var temp = tabStatus.Controls.Find(field.Name, false);

                    if (temp.Length > 0)
                        lbl1 = (MyLabel)temp[0];

                    var temp2 = tabStatus.Controls.Find(field.Name + "value", false);

                    if (temp2.Length > 0)
                        lbl2 = (MyLabel)temp2[0];
                }
                catch
                {
                }

                if (lbl1 == null)
                    lbl1 = new MyLabel();

                lbl1.Location = new System.Drawing.Point(x, y);
                lbl1.Size = new System.Drawing.Size(90, 13);
                lbl1.Text = field.Name;
                lbl1.Name = field.Name;
                lbl1.Visible = true;

                if (lbl2 == null)
                    lbl2 = new MyLabel();

                lbl2.AutoSize = false;

                lbl2.Location = new System.Drawing.Point(lbl1.Right + 5, y);
                lbl2.Size = new System.Drawing.Size(50, 13);
                //if (lbl2.Name == "")
                lbl2.DataBindings.Clear();
                lbl2.DataBindings.Add(new Binding("Text", bindingSourceStatusTab, field.Name, false,
                    DataSourceUpdateMode.Never, "0"));
                lbl2.Name = field.Name + "value";
                lbl2.Visible = true;
                //lbl2.Text = fieldValue.ToString();

                tabStatus.Controls.Add(lbl1);
                tabStatus.Controls.Add(lbl2);

                x += 0;
                y += 15;

                if (y > tabStatus.Height - 30)
                {
                    x = lbl2.Right + 10; //+= 165;
                    y = 10;
                }
            }

            tabStatus.Width = x;
        }

        private int i = 0;

        /// <summary>
        /// 串口通讯：勾选状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPortComm_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Checked)
            {
                tsmiSerialSet.Enabled = true;
                tsmiOpenSerial.Enabled = true;
                tsmiCloseSerial.Enabled = true;
            }
            else
            {
                tsmiSerialSet.Enabled = false;
                tsmiOpenSerial.Enabled = false;
                tsmiCloseSerial.Enabled = false;
            }
        }

        /// <summary>
        /// 网络串口：勾选状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcpComm_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Checked)
            {
                tsmiTCPSet.Enabled = true;
                tsmiOpenTCP.Enabled = true;
                tsmiCloseTCP.Enabled = true;
            }
            else
            {
                tsmiTCPSet.Enabled = false;
                tsmiOpenTCP.Enabled = false;
                tsmiCloseTCP.Enabled = false;
            }
        }

        /// <summary>
        /// 断开连接******************************************************
        /// </summary>
        public void disConnection()
        {
            log.Info("We are disconnecting");
            try
            {
                if (speechEngine != null) // cancel all pending speech
                    speechEngine.SpeakAsyncCancelAll();

                comPort.BaseStream.DtrEnable = false;
                comPort.Close();
               // telecontrol_comPort.BaseStream.DtrEnable = false;
               // telecontrol_comPort.Close();
                mainCtrl_comPort.BaseStream.DtrEnable = false;
                mainCtrl_comPort.Close();
                mainCtrl_comPort.LinkState = false;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// 视图设置******************************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sBtnComm_Click(object sender, EventArgs e)
        {
            //mapFrm = new MapFrm();
            //wpsFrm = new WpsFrm();
            //hudFrm = new HudFrm();
            //telemetryFrm = new TelemetryFrm();
            //commandsFrm = new CommandsFrm();


            //this.dockMainPanel.Theme = this.vS2005Theme1;
            //this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2005, vS2005Theme1);

            //IsHiddenView();
            //serialShowChanaged();
            //ViewSetFrm viewSetFrm = new ViewSetFrm();

            ////_viewSetFrm.Owner = this;
            ////_viewSetFrm.StartPosition = FormStartPosition.CenterScreen;
            ////_viewSetFrm.ShowDialog();

            //if (!map_ToolStripMenuItem.CheckOnClick)
            //{
            //    mapFrm.IsHidden = true;
            //    wpsFrm.Show(this.dockMainPanel);
            //    wpsFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
            //}
            //else
            //{
            //    mapFrm.Show(this.dockMainPanel);
            //    mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
            //    wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.4);
            //}
            
            
        }

        /// <summary>
        /// 串口/TCP设置******************************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sBtnComm_MouseDown(object sender, MouseEventArgs e)
        {
            serialShowChanaged();
        }

        private void serialShowChanaged()
        {
            if (serialPortComm.Checked)
            {
                tsmiSerialSet.Enabled = true;
                tsmiOpenSerial.Enabled = true;
                tsmiCloseTCP.Enabled = true;
            }
            else
            {
                tsmiSerialSet.Enabled = false;
                tsmiOpenSerial.Enabled = false;
                tsmiCloseSerial.Enabled = false;
            }

            if (tcpComm.Checked)
            {
                tsmiTCPSet.Enabled = true;
                tsmiOpenTCP.Enabled = true;
                tsmiCloseTCP.Enabled = true;
            }
            else
            {
                tsmiTCPSet.Enabled = false;
                tsmiOpenTCP.Enabled = false;
                tsmiCloseTCP.Enabled = false;
            }
        }

        private void cmsComm_MouseHover(object sender, EventArgs e)
        {
            serialShowChanaged();
        }

        /// <summary>
        /// 固件写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFirmwareWrite_Click(object sender, EventArgs e)
        {
            FirmwareWrite firmwareWrite = new FirmwareWrite();
            firmwareWrite.Owner = this;
            firmwareWrite.StartPosition = FormStartPosition.CenterScreen;
            firmwareWrite.ShowDialog();
        }

        /// <summary>
        /// 航线加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timsLoadWps_Click(object sender, EventArgs e)
        {
            IMUset routeLoadFrm = new IMUset();
            routeLoadFrm.StartPosition = FormStartPosition.CenterScreen;
            routeLoadFrm.Show();
        }

        /// <summary>
        /// 测试窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestSetFrm testSetFrm = new TestSetFrm();
            testSetFrm.Owner = this;
            testSetFrm.StartPosition = FormStartPosition.CenterScreen;
            testSetFrm.ShowDialog();
        }

        /// <summary>
        /// 地图设置************************************
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapSet_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapSourceSet.Owner = this;
            mapSourceSet.StartPosition = FormStartPosition.CenterScreen;
            mapSourceSet.ShowDialog();
        }

        /// <summary>
        /// 多机设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManyPlan_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManyMachineSet manyMachineSet = new ManyMachineSet();
            manyMachineSet.Owner = this;
            manyMachineSet.StartPosition = FormStartPosition.CenterScreen;
            manyMachineSet.ShowDialog();
        }


        private void 地面站配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroundStationFrm GSConfig = new GroundStationFrm();
            GSConfig.Owner = this;
            GSConfig.StartPosition = FormStartPosition.CenterScreen;
            GSConfig.ShowDialog();
        }

        /// <summary>
        /// 数据记录设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataReacorSet_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataRecordSet dataRecordSet = new DataRecordSet();
            dataRecordSet.Owner = this;
            dataRecordSet.StartPosition = FormStartPosition.CenterScreen;
            dataRecordSet.ShowDialog();
        }

        public DataRecordSet dataRecordSet = new DataRecordSet();
        public static DataPlayback dataPlayback = new DataPlayback();

        /// <summary>
        /// 数据回放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReplay_ToolStripMenuItem_Click(object sender, EventArgs
            e)
        {
            if (dataPlayback != null)
            {
                if (dataPlayback.IsDisposed)
                    dataPlayback = new DataPlayback();//如果已经销毁，则重新创建子窗口对象
                dataPlayback.Show();
                //dataPlayback.Focus();
            }
            else
            {
                dataPlayback = new DataPlayback();
                dataPlayback.Show();
                //dataPlayback.Focus();
            }
            //dataPlayback.Owner = this;
            //dataPlayback.StartPosition = FormStartPosition.CenterScreen;
            //dataPlayback.Show();
        }

        /// <summary>
        /// 命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commond_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kongyu steeringFrm = new Kongyu();
            steeringFrm.StartPosition = FormStartPosition.CenterScreen;
            steeringFrm.Show();
        }

        /// <summary>
        /// 打开通讯设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TelemetryListFrm_TelemetryMainLoopHandler()
        {
        }

        /// <summary>
        /// 打开通讯连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenConneciton_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            _communicationSetFrm.Owner = this;
            _communicationSetFrm.StartPosition = FormStartPosition.CenterScreen;
            _communicationSetFrm.ShowDialog();

            //打开串口连接
            if (_communicationSetFrm.serial_radioButtonShow.Checked &&! _communicationSetFrm.CloseWindow)
            {
                tsmiOpenSerial_Click(); 
            }
            //打开TCP链接
            else if (_communicationSetFrm.TCP_radioButtonShow.Checked && !_communicationSetFrm.CloseWindow)
            {
                tsmiOpenTCP_Click();
            }
            //实施数据：数据列表
            TelemetryListFrm.TelemetryMainLoopHandler += TelemetryListFrm_TelemetryMainLoopHandler;

            //初始化　    状态栏*********************************************************

            if (mainPlane != null)
            {
                //this.planNum_label.Text = mainPlane.Tag.ToString();//飞机编号
            }

            CurrentState.PlanFlyTimeHandler += PlanFlyTimeHandler;//飞机飞行时间
            CurrentState.PlanFlyGPSTimeHandler += PlanFlyGPSTimeHandler;//GPS
            CurrentState.PlanFlyRemoteControlHandler += PlanFlyRemoteControlHandler;//遥控器图标
            HUD.HUDSignalHandler += HUDSignalHandler1;//信号
            CommandsFrm.SendCommondBackHandler += SendCommondBackHandler;
            isConnect = true;
            DataRecordSet.DataRecordSetHandler += DataRecordSetHandler;
        }
        /// <summary>
        /// 飞机飞行信号
        /// </summary>
        /// <param name="_linkqualitygcs"></param>
        private void HUDSignalHandler1(float _linkqualitygcs)
        { 
            this._linkqualitygcs = _linkqualitygcs;
            if (25 >= _linkqualitygcs && _linkqualitygcs > 0)
            {
                //signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal1.png");
            }
            else if (50 >= _linkqualitygcs && _linkqualitygcs > 25)
            {
               // signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal2.png");
            }
            else if (75 >= _linkqualitygcs && _linkqualitygcs > 50)
            {
               // signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal3.png");
            }
            else if (100 >= _linkqualitygcs && _linkqualitygcs > 75)
            {
               // signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal4.png");
            }
       
        }

        /// <summary>
        /// 使用数据记录
        /// </summary>
        /// <param name="isChecked"></param>
        private void DataRecordSetHandler(bool isChecked)
        {
            string fileLoaction = dataRecordSet.foldPath;//Settings.Instance.LogDir + Path.DirectorySeparatorChar;
            string filepath = fileLoaction + "\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            try
            {
                Directory.CreateDirectory(Settings.Instance.LogDir);
                MessageBox.Show("comPort.logfile = "+filepath);
                comPort.logfile =
                    new BufferedStream(
                        File.Open(
                            filepath + ".tlog", FileMode.CreateNew,
                            FileAccess.ReadWrite, FileShare.None));

      //          log.Info("creating logfile " + filepath + ".tlog");
            }
            catch (Exception exp2)
            {
                log.Error(exp2);
                CustomMessageBox.Show(Strings.Failclog);
            }
        }

        /// <summary>
        /// 命令发送状态图标显示
        /// </summary>
        private void SendCommondBackHandler()
        {
            if (isSendSuccess)
            {
                //isSuccess_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\sucess.png");
                //MessageBox.Show(Application.StartupPath + "\\images\\sucess.png");
                //isSuccess_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\sucess.png");
            }
            else
            {
                //isSuccess_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\unsucess.png");
               // isSuccess_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\unsucess.png");
            }
        }

        /// <summary>
        /// 飞机飞行信号
        /// </summary>
        /// <param name="_linkqualitygcs"></param>
        private void HUDSignalHandler(float _linkqualitygcs)
        {
            MessageBox.Show("abc");
            this._linkqualitygcs = _linkqualitygcs;
            if (25 >= _linkqualitygcs && _linkqualitygcs > 0)
            {
               // signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal1.png");
            }
            else if (50 >= _linkqualitygcs && _linkqualitygcs > 25)
            {
              //  signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal2.png");
            }
            else if (75 >= _linkqualitygcs && _linkqualitygcs > 50)
            {
               // signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal3.png");
            }
            else if (100 >= _linkqualitygcs && _linkqualitygcs > 75)
            {
              //  signal_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\signal4.png");
            }
        }

        /// <summary>
        /// 飞机飞行时间
        /// </summary>
        /// <param name="planflyTime"></param>
        private void PlanFlyTimeHandler(string planflyTime)
        {
          //  this.PlanTime_label.Text = planflyTime;//CurrentState.gpstime.ToLongTimeString().ToString();//获取飞机飞行时间
        }

        /// <summary>
        /// GPS：星数/HDOP
        /// </summary>
        /// <param name="gpshdop"></param>
        /// <param name="satcount"></param>
        private void PlanFlyGPSTimeHandler(float gpshdop, float satcount)
        {
           // this.GPSProportion_label.Text = MainForm._comPort.JY.cs.satcount.ToString() + "/" + gpshdop.ToString();
        }

        /// <summary>
        /// 遥控器图标
        /// </summary>
        /// <param name="ch3in"></param>
        private void PlanFlyRemoteControlHandler(float ch3in)
        {
            MessageBox.Show("123");
            if (ch3in < 990)
            {
               // RemoteControl_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\RemoteUnConnection.png");
            }
            else
            {
                //RemoteControl_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\RemoteConnection.png");
            }
        }

        private void tsmiOpenTCP_Click()
        {
            if (_communicationSetFrm.cancelTCPClick) 
            {
            doConnect(comPort, "TCP", "");
            }
        }
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public void tsmiOpenSerial_Click()
        {
            //timer1.Start();
            if (_communicationSetFrm.cancelSerialClick) 
            { 
                comPort.giveComport = false;

                log.Info("MenuConnect Start");

                // sanity check
                if (comPort.BaseStream.IsOpen && MainForm.comPort.JY.cs.groundspeed > 4)
                {
                    if (DialogResult.No ==
                        CustomMessageBox.Show(Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo))
                    {
                        return;
                    }
                }

                try
                {
                    log.Info("Cleanup last logfiles");
                    // cleanup from any previous sessions
                    if (comPort.logfile != null)
                        comPort.logfile.Close();

                    if (comPort.rawlogfile != null)
                        comPort.rawlogfile.Close();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR);
                }

                comPort.logfile = null;
                comPort.rawlogfile = null;


                /********************************遥控电台初始化**************************************/


                /********************************主控板初始化**************************************/
               

                log.Info("MenuConnect mainCtrl Start");

                // sanity check
                if (mainCtrl_comPort.BaseStream.IsOpen && MainForm.mainCtrl_comPort.JY.cs.groundspeed > 4)
                {
                    if (DialogResult.No ==
                        CustomMessageBox.Show(Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo))
                    {
                        return;
                    }
                }

                try
                {
                    log.Info("mainCtrl_ Cleanup last logfiles");
                    // cleanup from any previous sessions
                    if (mainCtrl_comPort.logfile != null)
                        mainCtrl_comPort.logfile.Close();

                    if (mainCtrl_comPort.rawlogfile != null)
                        mainCtrl_comPort.rawlogfile.Close();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR);
                }

                mainCtrl_comPort.logfile = null;
                mainCtrl_comPort.rawlogfile = null;
                ///////////////////////////////////////ship 初始化/////////////////
                if (!gps.IsOpen)
                {
                    try
                    {
                        gps.BaudRate = 9600;
                        gps.DataBits = int.Parse("8");
                        gps.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                        gps.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                        gps.PortName = "COM2";       
                        //gps.RtsEnable = true;
                        gps.NewLine = "\n";
                        gps.Open();
                        //MessageBox.Show("舰口打开成功！！！");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("舰口打开失败！！！"); 
                    }
                }
                if (!xinbiao.IsOpen && _communicationSetFrm.check3.Checked)
                {
                    try
                    {
                        xinbiao.BaudRate = int.Parse(_communicationSetFrm.baudRateXB_comboBox.Text);
                        xinbiao.DataBits = int.Parse("8");
                        xinbiao.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), "1");
                        xinbiao.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), "None");
                        xinbiao.PortName = _communicationSetFrm.serialXB_comboBox.Text;
                        xinbiao.Open();
                        //MessageBox.Show("舰口打开成功！！！");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("信标打开失败！！！");
                    }
                }
                if (_communicationSetFrm.ZHAN_ID.Text != "")
                {
                    comPort.Zhan_id = (byte)(byte.Parse(_communicationSetFrm.ZHAN_ID.Text) + 0xD0);//地面站ID 
                }
                else
                {
                    comPort.Zhan_id = 0xD0;
                } flielist.Clear();
                stwlist.Clear();
                if (_communicationSetFrm.check1.Checked)
                {
                    doConnect(comPort, serialValue, baudRateValue);
                }
                if (_communicationSetFrm.check2.Checked)
                {
                    doConnectMC(mainCtrl_comPort, mainCtrl_serialValue, mainCtrl_baudRateValue);
                }
            }
        }
        /// <summary>
        /// 关闭通讯连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseConnection_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //timer1.Stop();
            gps.Close();
            xinbiao.Close();
            disConnection();
            isConnect = false;
            TelemetryListFrm.TelemetryMainLoopHandler += null;
            //连接结束后关闭日志记录
            if (comPort.logfile != null)
                comPort.logfile.Close();
            
            if (mainCtrl_comPort.logfile != null)
                mainCtrl_comPort.logfile.Close();
            foreach (var stw in stwlist)
            {
                stw.Value.Close();
            }
            foreach (var file in flielist)
            {
                file.Value.Close();
            }
        }

        /// <summary>
        /// 初始化 视图设置
        /// </summary>
        private void PopulateViewSetFrmList()
        {
            System.Data.DataSet ds = new System.Data.DataSet();

            if (!File.Exists(Application.StartupPath + "\\viewSet.xml"))
            //若文件夹不存在则新建文件
            {
                ds.WriteXml(Application.StartupPath + "\\viewSet.xml");
            }
            else
            {
                ds.ReadXml(Application.StartupPath + "\\viewSet.xml");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //初始化复选框值
                        if (ds.Tables[0].Rows[i][0].Equals("True"))
                        {
                            _viewSet.menuCheckbox = true;
                        }
                        else
                        {
                            _viewSet.menuCheckbox = false;
                        }
                        if (ds.Tables[0].Rows[i][1].Equals("True"))
                        {
                            _viewSet.headStatusCheckbox = true;
                        }
                        else
                        {
                            _viewSet.headStatusCheckbox = false;
                        }

                        if (ds.Tables[0].Rows[i][2].Equals("True"))
                        {
                            _viewSet.headCheckbox = true;
                            _viewSet.solidCheckbox = true;
                        }
                        else
                        {
                            _viewSet.headCheckbox = false;
                        }
                        if (ds.Tables[0].Rows[i][3].Equals("True"))
                        {
                            _viewSet.mainStatusCheckbox = true;
                        }
                        else
                        {
                            _viewSet.mainStatusCheckbox = false;
                        }

                        if (ds.Tables[0].Rows[i][4].Equals("True"))
                        {
                            _viewSet.commondCheckbox = true;
                        }
                        else
                        {
                            _viewSet.commondCheckbox = false;
                        }
                        if (ds.Tables[0].Rows[i][5].Equals("True"))
                        {
                            _viewSet.mapCheckbox = true;
                        }
                        else
                        {
                            _viewSet.mapCheckbox = false;
                        }
                        //if (ds.Tables[0].Rows[i][6].Equals("True"))
                        //{
                        //    _viewSet.solidCheckbox = true;
                        //}
                        //else
                        //{
                        //    _viewSet.solidCheckbox = false;
                        //}

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 视图设置
        /// </summary>
        /// <param name="handlerViewSet"></param>
        private void ViewSetFrm_SaveViewSetHandler(ViewSet handlerViewSet)
        {
            if (isExitSystem)
            {
                return;
            }
            IsHiddenView();
        }

        /// <summary>
        /// 航线规划显示隐藏
        /// </summary>
        /// <param name="isShow"></param>
        private void WpsFrm_IsShowWpsFrmHandler(bool isShow)
        {
            if (isShow)
            {
                if (mapFrm.IsHidden)
                {
                    wpsFrm.Show(this.dockMainPanel);
                    wpsFrm.DockTo(this.dockMainPanel, DockStyle.Bottom);
                }
                else
                {
                    mapFrm.Show(this.dockMainPanel);
                    mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                    wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.03);
                }
                //wpsFrm.Height = 10;
            }
            else
            {
                if (mapFrm.IsHidden)
                {
                    wpsFrm.Show(this.dockMainPanel);
                    wpsFrm.DockTo(this.dockMainPanel, DockStyle.Bottom);
                }
                else
                {
                    mapFrm.Show(this.dockMainPanel);
                    mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                    wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.3);
                }
            }
        }

        /// <summary>
        /// 保存当前窗口布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveWindow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable student = new DataTable();
            student.Columns.Add("menus");
            student.Columns.Add("headStatuss");
            student.Columns.Add("heads");
            student.Columns.Add("mainStatuss");
            student.Columns.Add("commonds");
            student.Columns.Add("maps");
            student.Columns.Add("solids");

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);

            student.Rows[student.Rows.Count - 1][0] = true;
            student.Rows[student.Rows.Count - 1][1] = true;
            if (hudFrm.IsHidden)
            {
                student.Rows[student.Rows.Count - 1][2] = false;
            }
            else
            {
                student.Rows[student.Rows.Count - 1][2] = true;
            }

            if (telemetryFrm.IsHidden)
            {
                student.Rows[student.Rows.Count - 1][3] = false;
            }
            else
            {
                student.Rows[student.Rows.Count - 1][3] = true;
            }

            if (commandsFrm.IsHidden)
            {
                student.Rows[student.Rows.Count - 1][4] = false;
            }
            else
            {
                student.Rows[student.Rows.Count - 1][4] = true;
            }

            if (mapFrm.IsHidden)
            {
                student.Rows[student.Rows.Count - 1][5] = false;
            }
            else
            {
                student.Rows[student.Rows.Count - 1][5] = true;
            }
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\viewShow.xml");
        }

        /// <summary>
        /// 打开保存的窗口布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWindow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            if (!File.Exists(Application.StartupPath + "\\viewShow.xml"))
            //若文件夹不存在则新建文件
            {
                ds.WriteXml(Application.StartupPath + "\\viewShow.xml");
            }
            else
            {
                ds.ReadXml(Application.StartupPath + "\\viewShow.xml");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].Equals("True"))
                    {
                        //  _viewSet.menuCheckbox = true;
                    }
                    else
                    {
                        // _viewSet.menuCheckbox = false;
                    }
                    if (ds.Tables[0].Rows[i][1].Equals("True"))
                    {
                        // _viewSet.headStatusCheckbox = true;
                    }
                    else
                    {
                        // _viewSet.headStatusCheckbox = false;
                    }

                    if (ds.Tables[0].Rows[i][2].Equals("True"))
                    {
                        hudFrm.Show(this.dockMainPanel, DockState.DockRight);
                    }
                    else
                    {
                        hudFrm.IsHidden = true;
                    }

                    if (ds.Tables[0].Rows[i][3].Equals("True"))
                    {
                        if (ds.Tables[0].Rows[i][2].Equals("false"))
                        {
                            telemetryFrm.Show(this.dockMainPanel, DockState.DockRight);
                        }
                        else
                        {
                            telemetryFrm.Show(hudFrm.Pane, DockAlignment.Bottom, 0.45);
                        }
                    }
                    else
                    {
                        telemetryFrm.IsHidden = true;
                    }

                    if (ds.Tables[0].Rows[i][4].Equals("True"))
                    {
                        if (ds.Tables[0].Rows[i][3].Equals("false"))
                        {
                            if (ds.Tables[0].Rows[i][2].Equals("false"))
                            {
                               // commandsFrm.Show(this.dockMainPanel, DockState.DockRight);
                            }
                            else
                            {
                                //commandsFrm.Show(hudFrm.Pane, DockAlignment.Bottom, 0.3);
                            }
                        }
                        else
                        {
                            //commandsFrm.Show(telemetryFrm.Pane, DockAlignment.Bottom, 0.6);
                        }
                    }
                    else
                    {
                        commandsFrm.IsHidden = true;
                    }
                    if (ds.Tables[0].Rows[i][5].Equals("True"))
                    {
                        mapFrm.Show(this.dockMainPanel);
                        mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);                  
                        wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.3);
                    }
                    else
                    {
                        mapFrm.IsHidden = true;
                        wpsFrm.Show(this.dockMainPanel);
                        wpsFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// 初始化地图设置：
        /// </summary>
        private void PopulateMapSourceSet()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            if (!File.Exists(Application.StartupPath + "\\MapLoaction.xml"))
            //若文件夹不存在则新建文件
            {
                ds.WriteXml(Application.StartupPath + "\\MapLoaction.xml");
            }
            else
            {
                ds.ReadXml(Application.StartupPath + "\\MapLoaction.xml");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mapSourceLoaction = ds.Tables[0].Rows[i][0].ToString();

                        mapSourceSet.saveMap_textBoxShow.Text = ds.Tables[0].Rows[i][0].ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 点击查看命令发送日志列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isSuccess_pictureBox_Click(object sender, EventArgs e)
        {
            //命令发送日志列表
            SendCommandLogFrm _sendCommandLogFrm = new SendCommandLogFrm();
            _sendCommandLogFrm.Owner = this;
            _sendCommandLogFrm.StartPosition = FormStartPosition.CenterScreen;
            _sendCommandLogFrm.ShowDialog();
        }

        /// <summary>
        /// 数据监测：遥测状态曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataCheck_toolStripMenuItem_Click(object sender, EventArgs e)
        {


            //zedGraphControl.Owner = this;
            //zedGraphControl.StartPosition = FormStartPosition.CenterScreen;
            //zedGraphControl.ShowDialog();
        }

        /// <summary>
        /// 遥测数据列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataList_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            _telemetryListFrm.Owner = this;
            _telemetryListFrm.StartPosition = FormStartPosition.CenterScreen;
            _telemetryListFrm.ShowDialog();
        }

        private void command_historyMenuItem_Click(object sender, EventArgs e)
        {
            commandHirtoryFrm.Owner = this;
            commandHirtoryFrm.StartPosition = FormStartPosition.CenterScreen;          
            commandHirtoryFrm.ShowDialog();
        }

        /// <summary>
        /// 编号设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ID_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDSetForm idSetFrm = new IDSetForm();
            idSetFrm.Owner = this;
            idSetFrm.StartPosition = FormStartPosition.CenterScreen;
            idSetFrm.ShowDialog();
        }

        private void dockMainPanel_ActiveContentChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 鼠标滑过特效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void System_Btn_MouseHover(object sender, EventArgs e)
        {
            Button tempBTN = (Button)sender;
            if (tempBTN.Name.Equals("System_Btn"))
            {
                this.System_Btn.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
                sBtnComm.BackColor = Color.Transparent;
  //              sBtnSetting.BackColor = Color.Transparent;
                splitButton1.BackColor = Color.Transparent;
                splitButton2.BackColor = Color.Transparent;
                sBtnWindow.BackColor = Color.Transparent;
                splitButton3.BackColor = Color.Transparent;

            }
            if (tempBTN.Name.Equals("sBtnComm"))
            {
                sBtnComm.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
  //              sBtnSetting.BackColor = Color.Transparent;
                splitButton1.BackColor = Color.Transparent;
                splitButton2.BackColor = Color.Transparent;
                sBtnWindow.BackColor = Color.Transparent;
                splitButton3.BackColor = Color.Transparent;
                this.System_Btn.BackColor = Color.Transparent;

            }
            //if (tempBTN.Name.Equals("sBtnSetting"))
            //{
            //    sBtnSetting.BackColor = Color.LightSkyBlue;
            //    return;
            //}
            //else
            //{
            //    splitButton1.BackColor = Color.Transparent;
            //    splitButton2.BackColor = Color.Transparent;
            //    sBtnWindow.BackColor = Color.Transparent;
            //    splitButton3.BackColor = Color.Transparent;

            //    this.System_Btn.BackColor = Color.Transparent;
            //    sBtnComm.BackColor = Color.Transparent;

            //}

            if (tempBTN.Name.Equals("splitButton1"))
            {
                splitButton1.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
                splitButton2.BackColor = Color.Transparent;
                sBtnWindow.BackColor = Color.Transparent;
                splitButton3.BackColor = Color.Transparent;

                this.System_Btn.BackColor = Color.Transparent;
                sBtnComm.BackColor = Color.Transparent;
 //               sBtnSetting.BackColor = Color.Transparent;

            }

            if (tempBTN.Name.Equals("splitButton2"))
            {
                splitButton2.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
                sBtnWindow.BackColor = Color.Transparent;
                splitButton3.BackColor = Color.Transparent;

                this.System_Btn.BackColor = Color.Transparent;
                sBtnComm.BackColor = Color.Transparent;
//                sBtnSetting.BackColor = Color.Transparent;
                splitButton1.BackColor = Color.Transparent;

            }

            if (tempBTN.Name.Equals("sBtnWindow"))
            {
                sBtnWindow.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
                splitButton3.BackColor = Color.Transparent;

                this.System_Btn.BackColor = Color.Transparent;
                sBtnComm.BackColor = Color.Transparent;
 //               sBtnSetting.BackColor = Color.Transparent;
                splitButton1.BackColor = Color.Transparent;
                splitButton2.BackColor = Color.Transparent;

            }
            if (tempBTN.Name.Equals("splitButton3"))
            {
                splitButton3.BackColor = Color.LightSkyBlue;
                return;
            }
            else
            {
                this.System_Btn.BackColor = Color.Transparent;
                sBtnComm.BackColor = Color.Transparent;
 //               sBtnSetting.BackColor = Color.Transparent;
                splitButton1.BackColor = Color.Transparent;
                splitButton2.BackColor = Color.Transparent;
                sBtnWindow.BackColor = Color.Transparent;

            }
        }

        /// <summary>
        /// 鼠标移开时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void System_Btn_MouseMove(object sender, MouseEventArgs e)
        {
            Button tempBTN = (Button)sender;
            if (tempBTN.Name.Equals("System_Btn"))
            {
                this.System_Btn.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    splitButton1.BackColor = Color.SkyBlue;
            //    splitButton2.BackColor = Color.SkyBlue;
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    splitButton3.BackColor = Color.SkyBlue;
            //    return;
            //}
            if (tempBTN.Name.Equals("sBtnComm"))
            {
                sBtnComm.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    splitButton1.BackColor = Color.SkyBlue;
            //    splitButton2.BackColor = Color.SkyBlue;
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    splitButton3.BackColor = Color.SkyBlue;
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    return;
            //}

            //if (tempBTN.Name.Equals("sBtnSetting"))
            //{
            //    //sBtnSetting.BackColor = Color.Transparent;
            //    return;
            //}
            //else
            //{
            //    splitButton1.BackColor = Color.SkyBlue;
            //    splitButton2.BackColor = Color.SkyBlue;
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    splitButton3.BackColor = Color.SkyBlue;
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    return;
            //}
            if (tempBTN.Name.Equals("splitButton1"))
            {
                splitButton1.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    splitButton2.BackColor = Color.SkyBlue;
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    splitButton3.BackColor = Color.SkyBlue;
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    return;
            //}

            if (tempBTN.Name.Equals("splitButton2"))
            {
                splitButton2.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    splitButton3.BackColor = Color.SkyBlue;
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    splitButton1.BackColor = Color.SkyBlue;
            //    return;
            //}

            if (tempBTN.Name.Equals("sBtnWindow"))
            {
                sBtnWindow.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    splitButton3.BackColor = Color.SkyBlue;
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    splitButton1.BackColor = Color.SkyBlue;
            //    splitButton2.BackColor = Color.SkyBlue;
            //    return;
            //}
            if (tempBTN.Name.Equals("splitButton3"))
            {
                splitButton3.BackColor = Color.Transparent;
                return;
            }
            //else
            //{
            //    this.System_Btn.BackColor = Color.SkyBlue;
            //    sBtnComm.BackColor = Color.SkyBlue;
            //    sBtnSetting.BackColor = Color.SkyBlue;
            //    splitButton1.BackColor = Color.SkyBlue;
            //    splitButton2.BackColor = Color.SkyBlue;
            //    sBtnWindow.BackColor = Color.SkyBlue;
            //    return;
            //}
        }
        private void System_Btn_Click(object sender, EventArgs e)
        {
            this.System_Btn.BackColor = Color.Transparent;
            sBtnComm.BackColor = Color.Transparent;
 //           sBtnSetting.BackColor = Color.Transparent;
            splitButton1.BackColor = Color.Transparent;
            splitButton2.BackColor = Color.Transparent;
            sBtnWindow.BackColor = Color.Transparent;
            splitButton3.BackColor = Color.Transparent;
        }

        private void System_Btn_Move(object sender, EventArgs e)
        {
            this.System_Btn.BackColor = Color.Transparent;
            sBtnComm.BackColor = Color.Transparent;
//            sBtnSetting.BackColor = Color.Transparent;
            splitButton1.BackColor = Color.Transparent;
            splitButton2.BackColor = Color.Transparent;
            sBtnWindow.BackColor = Color.Transparent;
            splitButton3.BackColor = Color.Transparent;
        }

        private void MainForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("ok");
            //hudFrm.Invalidate();
        }



        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            //MessageBox.Show("ok");
            //hudFrm.Invalidate();
        }
        /// <summary>
        /// 调参窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void config_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            duojiset configFrm = new duojiset();
            configFrm.StartPosition = FormStartPosition.CenterScreen;
            configFrm.Show();
        }

        private void erect_configToolMenuItem_Click(object sender, EventArgs e)
        {
            ErectConfigFrm erectConfigFrm = new ErectConfigFrm();
            erectConfigFrm.Owner = this;
            erectConfigFrm.StartPosition = FormStartPosition.CenterScreen;
            erectConfigFrm.ShowDialog();
        }

        private void sensor_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            SensorFrm sensorFrm = new SensorFrm();
            sensorFrm.Owner = this;
            sensorFrm.StartPosition = FormStartPosition.CenterScreen;
            sensorFrm.ShowDialog();
        }

        private void telemetry_bandwidthMenuItem_Click(object sender, EventArgs e)
        {
            TelemetryBandwidth telemetry_bandwidthFrm = new TelemetryBandwidth();
            telemetry_bandwidthFrm.Owner = this;
            telemetry_bandwidthFrm.StartPosition = FormStartPosition.CenterScreen;
            telemetry_bandwidthFrm.ShowDialog();
        }
        private void data_manageMenuItem_Click(object sender, EventArgs e)
        {
            Peizhong dataManageFrm = new Peizhong();
            dataManageFrm.StartPosition = FormStartPosition.CenterScreen;
            dataManageFrm.Show();
        }

        private void steering_engineStripMenuItemClick(object sender, EventArgs e)
        {
            SteeringFrm steeringFrm = new SteeringFrm();
            steeringFrm.Owner = this;
            steeringFrm.StartPosition = FormStartPosition.CenterScreen;
            steeringFrm.ShowDialog();
        }
        private void engineCheckMenuItem_Click(object sender, EventArgs e)
        {
            EngineCheckFrm engineCheckFrm = new EngineCheckFrm();
            engineCheckFrm.Owner = this;
            engineCheckFrm.StartPosition = FormStartPosition.CenterScreen;
            engineCheckFrm.ShowDialog();
        }

        private void systemSelfCheck_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelemetryMgrFrm te = new TelemetryMgrFrm();
            te.Show();
        }

        private void menu_ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void headstatus_ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (headstatus_ToolStripMenuItem.Checked != true)
            {
                hudFrm.IsHidden = true;
            }
            else
            {
                hudFrm.Show(this.dockMainPanel, DockState.DockRight);
            }
        }


        

        private void map_ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (map_ToolStripMenuItem.Checked != true)
            {
                mapFrm.IsHidden = true;
                wpsFrm.Show(this.dockMainPanel);
                wpsFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                
            }
            else
            {
                mapFrm.Show(this.dockMainPanel);
                mapFrm.DockTo(this.dockMainPanel, DockStyle.Fill);
                wpsFrm.Show(mapFrm.Pane, DockAlignment.Bottom, 0.4);
                
            }
        }

        CommandsFrm _commandsfrm = new CommandsFrm();

        private void 状态区ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ins_ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (ins_ToolStripMenuItem.Checked != true)
            {
                commandsFrm.IsHidden = true;
            }
            else
            {
                //commandsFrm.Show(this.dockMainPanel, DockState.DockRight);
            }
        }

        private void state_ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (state_ToolStripMenuItem.Checked != true)
            {
                telemetryFrm.IsHidden = true;
            }
            else
            {
                telemetryFrm.Show(this.dockMainPanel, DockState.DockRight);
            }
        }


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newserialPorts.Owner = this;
            _newserialPorts.StartPosition = FormStartPosition.CenterScreen;
            _newserialPorts.ShowDialog();
        }
        private void draw_picture(PictureBox p,string s,int w)
        {
            p.Image = null;
            p.Refresh();
            Brush brush; 
            Graphics text = p.CreateGraphics();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(w*60/34, 0);
            //创建一个画刷，颜色是纯色
            Brush brush1 = new SolidBrush(Color.Red );
            Brush brush2 = new SolidBrush(Color.Lime);
            Brush brush3 = new SolidBrush(Color.Black );
            if (w<25)
            { brush = brush1; }
            else { brush = brush2; }
            Pen pee = new Pen(brush, 40);
            //选择字体、字号、风格
            Font font = new Font("宋体", 9f, FontStyle.Bold);
            //在位置（150，200）处绘制文字
            text.DrawLine(pee, p1, p2);
            text.DrawString(s, font, brush3, 10, 5);
        }
        public void updataShipPoint(double head, double speed)
        {
            //double   daPositionWay[2]   = { 0 };
            double dWayPointLat = 0;
            double dWayPointLon = 0;
            double dVectorX = 0;
            double dVectorY = 0;

            dWayPointLon = CurrentState.xn_lng;
            dWayPointLat = CurrentState.xn_lat;


            dVectorX = speed * 0.51444 * Math.Sin(head * 0.0174532922);
            dVectorY = speed * 0.51444 * Math.Cos(head * 0.0174532922);


            CurrentState.xn_lat = (dVectorY / 6371000.0) * 57.3 + dWayPointLat;
            CurrentState.xn_lng = (dVectorX / (6371000.0 * Math.Cos(dWayPointLat * 0.0174532922))) * 57.3 + dWayPointLon;

        }
        private string GetAngel(JYState JY)
        {
            double temp, temp2;
            string angel = "";
            Point p = new Point();
            PointLatLng p1 = new PointLatLng();//ship1223
            if (double.TryParse(gpssum[2], out temp2) && double.TryParse(gpssum[4], out temp2) && double.TryParse(gpssum[7], out temp2))//1226
            {
                p1.Lat = Convert.ToDouble(gpssum[2]);
                p1.Lng = Convert.ToDouble(gpssum[4]);
                p = LatLng_to_xy(p1, new PointLatLng(JY.cs.lat, JY.cs.lng));
                if (Math.Abs(p.X) < 1000000 && Math.Abs(p.Y) < 1000000 && p1.Lat != 0 && p1.Lng != 0)
                {
                    temp = Math.Atan2(p.Y, p.X) * 180 / Math.PI;
                    if (p.X < 0 && p.Y > 0)
                    {
                        temp = 450 - temp;
                    }
                    else
                    {
                        temp = 90 - temp;
                    }
                    angel_c = temp - Convert.ToDouble(gpssum[7]);
                    if (angel_c > 180)
                    {
                        angel_c = angel_c - 360;
                    }
                    else if (angel_c < -180)
                    {
                        angel_c = angel_c + 360;
                    }
                    angel = angel_c.ToString("N0");

                }
            }

            return angel;
        }
        public byte[] micro_buff;
        DateTime tracklast = DateTime.Now.AddSeconds(0);
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                byte _positionState = 0;
                float battery_voltage = 0;
                byte mode = 0;
                foreach (var port in MainForm.Comports)
                {

                    foreach (var JY in port.JYlist)
                    {
                        if ((JY.targetid.ToString() == targetlabel.Text) || port.JYlist.Count == 1)
                        {
                            _positionState = JY.cs.position_state;
                            battery_voltage = JY.cs.battery_voltage;
                            lbl_homedist.Text = "距舰距离:" + JY.cs.distance_to_home.ToString("N2") + " Km";
                            lbl_angel.Text = "对舰角度:" + GetAngel(JY) + " °";
                        }
                        if (xinbiao.IsOpen)
                        {
                            JYLink.JYLinkMessage microMessage2 = JY.getPacket(0xC8);//微波源参数下传
                            if ((microMessage2 != null))
                            {
                                micro_buff = JylinkUtil.StructureToByteArray(0xC8, microMessage2.data);
                                generatePacket(0xA1, micro_buff);
                                port.JYlist[0, JY.targetid].clearPacket(0xC8);
                            }
                            generatePacket(1, GetBajiMess(JY));  //微波源信息 
                            //Thread.Sleep(1);
                            generatePacket(2, JY.cs.Micro);  //微波源信息 
                            Thread.Sleep(10);
                        }
                    }

                }
                if ((_positionState & 1) == 1)
                {
                    gps1.BackColor = Color.Green;
                }
                else
                {
                    gps1.BackColor = Color.Red;
                }
                if ((_positionState & 2) == 2)
                {
                    gps2.BackColor = Color.Green;
                }
                else
                {
                    gps2.BackColor = Color.Red;
                }

                draw_picture(pictureBox1, battery_voltage);

                if (Xuni_set || MainForm.comPort.logreadmode)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        gpssum[2] = CurrentState.xn_lat.ToString("N6");
                        gpssum[4] = CurrentState.xn_lng.ToString("N6");
                        gpssum[7] = CurrentState.xn_head.ToString();
                        gpssum[6] = CurrentState.xn_speed.ToString();
                        this.TXT_homelat.Text = gpssum[2];
                        this.TXT_homelng.Text = gpssum[4];
                        this.TXT_homeheading.Text = gpssum[7];
                        this.TXT_homesecond.Text = gpssum[6];
                        if (!MainForm.comPort.logreadmode)
                        {
                            updataShipPoint(CurrentState.xn_head, CurrentState.xn_speed);
                        }
                    });
                } 
        
       
            }
            catch (Exception)
            {
                
            }
           
        }
        private JYLink.jylink_bj_status_down GetBajiMess(JYState JY)
        {
            bj.bjid = JY.targetid;
            bj.wbyid = JY.cs.wby_id;
            if ((JY.cs.position_state & 4) == 4 && (JY.cs.position_state & 8) == 8 && (JY.cs.position_state & 16) == 16)
            {
                bj.mode = 0x0F;
            }
            else
            {
                bj.mode = 0xF0;
            }
            bj.lat = JY.cs.lng;
            bj.lng = JY.cs.lat;
            bj.alt = (ushort)JY.cs.zuhe_altitude;
            bj.heading = JY.cs.yaw;
            bj.UTC_year = (ushort)tracklast.Year;
            bj.UTC_month = (byte)tracklast.Month;
            bj.UTC_day = (byte)tracklast.Day;
            //long zhoumiao, temp;
            //byte hour, min, sec;
            //zhoumiao = CurrentState.utc_hour / 1000;
            //Math.DivRem(zhoumiao, 3600 * 24, out temp);
            //hour = (byte)Math.Truncate(temp / 3600.0);
            //min = (byte)Math.Truncate(temp / 60.0 - hour * 60.0);
            //Math.DivRem(temp, 60, out zhoumiao);
            //sec = (byte)zhoumiao;
            bj.UTC_hour = JY.cs.utc_hour;
            bj.UTC_min = JY.cs.utc_minute;
            bj.UTC_sec = JY.cs.utc_second;
            return bj;
        }
        private void draw_picture(PictureBox p, float v)
        {
            string s = string.Format("{0:N2}", v);
            int w = (int)v;
            p.Image = null;
            p.Refresh();
            Brush brush;
            Graphics text = p.CreateGraphics();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(w * 60 / 34, 0);
            //创建一个画刷，颜色是纯色
            Brush brush1 = new SolidBrush(Color.Red);
            Brush brush2 = new SolidBrush(Color.Lime);
            Brush brush3 = new SolidBrush(Color.Black);
            if (w < 25)
            { brush = brush1; }
            else { brush = brush2; }
            Pen pee = new Pen(brush, 40);
            //选择字体、字号、风格
            Font font = new Font("宋体", 9f, FontStyle.Bold);
            //在位置（150，200）处绘制文字
            text.DrawLine(pee, p1, p2);
            text.DrawString(s, font, brush3, 10, 5);
        }
        /////////////////////
        private void Micro(JYState JY) 
        {
            byte _positionState;
            generatePacket(2, JY.cs.Micro);  //微波源信息
            //  }
            bj.bjid = JY.targetid;
            _positionState = JY.cs.position_state;

            bj.wbyid = JY.cs.wby_id;



            if ((_positionState & 4) == 4 && (_positionState & 8) == 8 && (_positionState & 16) == 16)
            {
                bj.mode = 0x0F;
            }
            else
            {
                bj.mode = 0xF0;
            }

            bj.lat = JY.cs.lng;
            bj.lng = JY.cs.lat;
            bj.alt =(ushort) JY.cs.zuhe_altitude;
            bj.heading = JY.cs.yaw;
            bj.UTC_year = (ushort)tracklast.Year;
            bj.UTC_month = (byte)tracklast.Month;
            bj.UTC_day = (byte)tracklast.Day;
            //long zhoumiao, temp;
            //byte hour, min, sec;
            //zhoumiao = JY.cs.ut / 1000;
            ////zhoumiao = 3750;
            //Math.DivRem(zhoumiao, 3600 * 24, out temp);
            //hour = (byte)Math.Truncate(temp / 3600.0);
            //min = (byte)Math.Truncate(temp / 60.0 - hour * 60.0);
            //Math.DivRem(temp, 60, out zhoumiao);
            //sec = (byte)zhoumiao;
            bj.UTC_hour = (byte)tracklast.Hour;
            bj.UTC_min = (byte)tracklast.Minute;
            bj.UTC_sec = (byte)tracklast.Second;
            generatePacket(1, bj);
            
        }
        Goujing goujing = new Goujing();
        public static List<Point> M_hangdian = new List<Point>();
        public List<Point> M_hangdian_up= new List<Point>();
        public double angel_init=0;
        public static string[] gpssum = new string[13];

        PointLatLng p1 = new PointLatLng();//ship1223
        List<PointLatLng> p2 = new List<PointLatLng>();//plane1223
        private void GoujingToolStripMenuItem(object sender, EventArgs e)
        {
            goujing.ShowDialog();
        }
        private void ChangerouteToolStripMenuItem(object sender, EventArgs e)//1944
        { 
            Point p = new Point(0,0);
            if (wpsFrm.gb_heading.Text.Trim() != "")
            {
                M_hangdian_up.Clear();
                mapFrm.p_goujing[0] = Changeroute(p_goujing[0], (Convert.ToDouble(wpsFrm.gb_heading.Text.Trim())) * Math.PI / 180);
                mapFrm.p_goujing[1] = Changeroute(p_goujing[1], (Convert.ToDouble(wpsFrm.gb_heading.Text.Trim())) * Math.PI / 180);
                for (int i = 0; i < M_hangdian.Count; i++)
                {
                    M_hangdian_up.Add(p);
                    M_hangdian_up[i] = Changeroute(M_hangdian[i], (Convert.ToDouble(wpsFrm.gb_heading.Text.Trim())) * Math.PI / 180);
                    //Commands.Rows[i].Cells[Lat.Index].Value = M_hangdian_up[i].X*100;
                    //Commands.Rows[i].Cells[Lon.Index].Value = M_hangdian_up[i].Y*100;
                }               
            }

        }
        private void ChangeHeadingMenuItem(object sender, EventArgs e)//1224 
        {
            //判断是否连接
            if (!comPort.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接！");
                return;
            }
            float f = 0;
            //bool b;
            //b = Single.TryParse(wpsFrm.Heading_input.Text.Trim(), out f);
            if (wpsFrm.gb_heading.Text == "" || !Single.TryParse(wpsFrm.gb_heading.Text.Trim(), out f))
            { return; }
            //gpssum[2] = "2";
            JYLink.Warship_change Warship = new JYLink.Warship_change();
            Warship.Heading_status = Byte.Parse("85");
            Warship.Heading = Single.Parse(wpsFrm.gb_heading.Text.Trim());
            float fl;
            if (Single.TryParse(Warship.Heading.ToString(),out fl))
            {
                //将参数内容发送到飞控
                bool result = comPort.upHomeShipChange(Warship);
                
                //判断执行结果
                if (result)
                {
                    ChangerouteToolStripMenuItem(null, null);
                    angel_init = Convert.ToDouble(gpssum[7]);
                    MessageBox.Show("航向改变设置成功");
                }
                else
                {
                    MessageBox.Show("航向改变设置失败");
                }
            }
            else
            {
                MessageBox.Show("输入航向数据不正确");
            }

        }
        private Point Changeroute(Point p, double angel)//1223
        {
            Point pp = new Point();
            pp.X = Convert.ToInt32(p.X * Math.Cos(angel) + p.Y * Math.Sin(angel));
            pp.Y = Convert.ToInt32(p.Y * Math.Cos(angel) - p.X * Math.Sin(angel));
            return pp;
        }
        private void set_goujingMenuItem(object sender, EventArgs e) //沟径设置
        {
            Point p, p1, center;
            int s;
            string xian;
            double angle,jin_L,wan_L,sin_angel,cos_angel;
            angle = Convert.ToDouble(goujing.angel.Text);
            s = Convert.ToInt32(goujing.distance.Text) ;
            jin_L = Convert.ToDouble(goujing.jinru_L.Text)*1000;
            wan_L = Convert.ToDouble(goujing.wan_L.Text)*1000;
            xian = goujing.xian.Text.Trim();
            Point [] point=new Point[6];
            sin_angel=Math.Sin(angle * Math.PI / 180);
            cos_angel = Math.Cos(angle * Math.PI / 180);
            if (xian=="右")
            {
                point[1].X = (int)((jin_L * sin_angel + s * cos_angel) / 100);
                point[1].Y = (int)((jin_L * cos_angel - s * sin_angel) / 100);

                point[0].X = (int)((jin_L * sin_angel + (s + wan_L) * cos_angel) / 100);
                point[0].Y = (int)((jin_L * cos_angel - (s + wan_L) * sin_angel) / 100);

                point[5].X = (int)(s /cos_angel / 100);
                point[5].Y = (int)(-s*2 / sin_angel / 100);

                point[3].X = -point[0].X;
                point[3].Y = point[0].Y;

                point[4].X = -point[1].X;
                point[4].Y = point[1].Y;

                point[2].X = -point[5].X;
                point[2].Y = point[5].Y;  
            }
            else
            {
                point[4].X = (int)((jin_L * sin_angel + s * cos_angel) / 100);
                point[4].Y = (int)((jin_L * cos_angel - s * sin_angel) / 100);

                point[3].X = (int)((jin_L * sin_angel + (s + wan_L) * cos_angel) / 100);
                point[3].Y = (int)((jin_L * cos_angel - (s + wan_L) * sin_angel) / 100);

                point[2].X = (int)(s / cos_angel / 100);
                point[2].Y = (int)(-s *2/ sin_angel / 100 );

                point[0].X = -point[3].X;
                point[0].Y = point[3].Y;

                point[1].X = -point[4].X;
                point[1].Y = point[4].Y;

                point[5].X = -point[2].X;
                point[5].Y = point[2].Y;  
            }

           // Commands.SuspendLayout();
           // Commands.Enabled = false;
            M_hangdian.Clear();
            M_hangdian_up.Clear();
            mapFrm.hangdian_cmd.Clear();
            Commands.Rows.Clear();
            Commands.RowHeadersVisible = true;
            for (int i = 0; i < 6; i++)
            {
                M_hangdian.Add(point[i]); //1224
                M_hangdian_up.Add(point[i]); //1224
                Commands.Rows.Add();
                
                Commands.Rows[i].HeaderCell.Value = i + 1;
                mapFrm.hangdian_cmd.Add("WAYPOINT");
                Commands.Rows[i].Cells[Lat.Index].Value = point[i].X*100;
                Commands.Rows[i].Cells[Lon.Index].Value = point[i].Y*100;
                Commands.Rows[i].Cells[Alt.Index].Value = 500;
                Commands.EndEdit();
                
            }
            writeKML();
            setgradanddistandaz();
            //Commands.Enabled = true;
           // Commands.ResumeLayout();
            //p1 = new Point(mapFrm.Width / 2 - s, mapFrm.Height / 2);
            
            //center = new Point(mapFrm.Width / 2, mapFrm.Height / 2);
            //p = PointRotate(center, p1, angle);
            //p_goujing[0].X=mapFrm.p_goujing[0].X = (int)(p.X - mapFrm.Width / 2 + 400 * Math.Sin(angle * Math.PI / 180));
            //p_goujing[0].Y=mapFrm.p_goujing[0].Y = (int)(p.Y - mapFrm.Height / 2 + 400 * Math.Cos(angle * Math.PI / 180));
            //p_goujing[1].X=mapFrm.p_goujing[1].X = (int)(p.X - mapFrm.Width / 2 - 400 * Math.Sin(angle * Math.PI / 180));
            //p_goujing[1].Y=mapFrm.p_goujing[1].Y = (int)(p.Y - mapFrm.Height / 2 - 400 * Math.Cos(angle * Math.PI / 180));
            mapFrm.TRefresh(M_hangdian_up);
            goujing.Close();

        }
        private Point PointRotate(Point center, Point p1, double angle) //P1绕着center点旋转angel后
        {
            Point tmp = new Point();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            tmp.X = (int)x1;
            tmp.Y = (int)y1;
            return tmp;
        }
        int Erath_r = 6371000;//m 
        float ratio = 1.0f;
        private Point LatLng_to_xy(PointLatLng p1, PointLatLng p2)     //经纬度距离转换为实际距离
        {
            Point p = new Point();
            double x, y;
            try
            {
                y = (p2.Lat - p1.Lat) * Math.PI / 180 * Erath_r;
                x = (p2.Lng - p1.Lng) * Math.PI / 180 * (Erath_r * Math.Cos(p1.Lat * Math.PI / 180));
                p.X = (int)(x * ratio / 100); //转换为像素距离
                p.Y = (int)(y * ratio / 100);
                return p;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void mapFrm_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)   //1221单击添加航点
        {
            Point p = new Point();
            if (!isPlan)
            {
                return;
            }
            if (e.Button == MouseButtons.Left && !isselect&& !isRange)
            {
                p.X = (int)((e.X - mapFrm.Width / 2-mapFrm.xx) / mapFrm._zoom);
                p.Y = (int)((-e.Y + mapFrm.Height / 2+mapFrm.yy) / mapFrm._zoom);
                M_hangdian.Add(p);
                M_hangdian_up.Add(p);
                mapFrm.hangdian_cmd.Add("WAYPOINT");
                //mapFrm.TRefresh(M_hangdian_up);               
                isMouseDown = true;
                isMouseDraging = false;
                AddCommand(JYLink.JY_CMD.WAYPOINT, 0, 0, 0, 0, p.Y * 100, p.X * 100, 1000);//100是系数，目前50像素对应5km


              //  M_hangdian_up = M_hangdian;
            }

        }
        bool isselect=false;   
        int hd_i=0;
        Point mouseDownPoint = new Point(); 
        public void mapFrm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)   //
        {
            if (isselect)
            {
                this.Cursor = Cursors.Hand; 
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
               
            for (int i = 0; i < M_hangdian.Count; i++)
            {
                if (Math.Abs(M_hangdian[i].X * mapFrm._zoom + mapFrm.Width / 2 - e.X + mapFrm.xx) <= 4 && Math.Abs(-M_hangdian[i].Y * mapFrm._zoom + mapFrm.Height / 2 - e.Y + mapFrm.yy) <= 4)
                {
                    this.Cursor = Cursors.Hand;
                    //Commands.Rows[i].Selected = true;
                    if (Commands.Rows.Count>0)
                    {
                        Commands.CurrentCell = Commands[Lat.Index, i];
                    }
        
                }
            }
            if (isPlan && M_hangdian.Count > 0 && mapFrm.hangdian_cmd.Count>0)
            {
                pointReview.Visible = true;
                Point p = new Point();
                Point p_last = new Point();
                p.X = (int)((e.X - mapFrm.Width / 2-mapFrm.xx) / mapFrm._zoom);
                p.Y = (int)((-e.Y + mapFrm.Height / 2+mapFrm.yy) / mapFrm._zoom);
                double angel = 0;
                if (!isselect)
                {

                    if (mapFrm.hangdian_cmd[M_hangdian.Count - 1]=="LAND")
                    {
                        p_last.X = 0;
                        p_last.Y = 0;
                    }
                    else
                    {
                        p_last.X = M_hangdian[M_hangdian.Count - 1].X;
                        p_last.Y = M_hangdian[M_hangdian.Count - 1].Y;
                    }
                    angel = Math.Atan2(p.Y - p_last.Y, p.X - p_last.X) * 180.0 / 3.14;

                    if (angel>=90&&angel<=180)
                    {
                        angel = 450 - angel;
                    }
                    else
                    {
                        angel = 90 - angel;
                    }
                    pointReview.Text = "与前点距离：" + (Math.Sqrt(Math.Pow(p.X - p_last.X, 2) + Math.Pow(p.Y - p_last.Y, 2)) / 10.0).ToString("0.000Km") + " 与前点角度：" + angel.ToString("0.0 °"); 
                }
                else
                {
                    if (hd_i > 1 && !Commands.Rows[hd_i-1].HeaderCell.Value.ToString().Contains("-1"))
                    {
                        angel = Math.Atan2(p.Y - M_hangdian[hd_i - 2].Y, p.X - M_hangdian[hd_i - 2].X) * 180.0 / 3.14;
                        if (angel >= 90 && angel <= 180)
                        {
                            angel = 450 - angel;
                        }
                        else
                        {
                            angel = 90 - angel;
                        }
                        pointReview.Text = "与前点距离：" + (Math.Sqrt(Math.Pow(p.X - M_hangdian[hd_i - 2].X, 2) + Math.Pow(p.Y - M_hangdian[hd_i - 2].Y, 2))).ToString("0.000Km") + " 与前点角度：" + angel.ToString("0.0 °");           
         
                    }
                    else
                    {
                        angel = Math.Atan2(p.Y, p.X) * 180.0 / 3.14;
                        if (angel >= 90 && angel <= 180)
                        {
                            angel = 450 - angel;
                        }
                        else
                        {
                            angel = 90 - angel;
                        }
                        pointReview.Text = "与前点距离：" + (Math.Sqrt(Math.Pow(p.X , 2) + Math.Pow(p.Y , 2))/10.0).ToString("0.000Km") + " 与前点角度：" + angel.ToString("0.0 °");           
         
                    }
                   
               }
           }
        }

        public void mapFrm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)   // 19215
        {
            if (e.Button == MouseButtons.Left && !isPlan && !isRange)
            {
                mouseDownPoint.X = e.X;
                mouseDownPoint.Y = e.Y;
                return;
            }
            if (isPlan && !isRange)
            {
                if (e.Button == MouseButtons.Left && !isselect)
                {
                    for (int i = 0; i < M_hangdian.Count; i++)
                    {
                        if (Math.Abs(M_hangdian[i].X * mapFrm._zoom + mapFrm.Width / 2 - e.X+ mapFrm.xx) <= 4  && Math.Abs(-M_hangdian[i].Y * mapFrm._zoom + mapFrm.Height / 2 - e.Y+ mapFrm.yy) <= 4 )              
                        {
                            hd_i = i + 1;
                            isselect = true;
                            //this.Cursor = Cursors.Hand;
                            mouseDownPoint.X = Cursor.Position.X;
                            mouseDownPoint.Y = Cursor.Position.Y;
                            
                            return;
                        }
                    }
                }
            }
            if ( isRange)
            {
                if (isRange && e.Button == MouseButtons.Left)
                {
                    mouseDownPoint.X = (int)((e.X - mapFrm.Width / 2-mapFrm.xx) / mapFrm._zoom);
                    mouseDownPoint.Y = (int)((-e.Y + mapFrm.Height / 2+mapFrm.yy) / mapFrm._zoom);
                    mapFrm.p_line.Add(mouseDownPoint);
                    mapFrm.Refresh();
                }
            }

        }
        public void mapFrm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)   //  移动航点位置19215
        {

            if (e.Button == MouseButtons.Left && !isPlan && !isRange)
            {
                mapFrm.diff_x = e.X - mouseDownPoint.X;
                mapFrm.diff_y = e.Y - mouseDownPoint.Y;
                return;
            }
            Point p = new Point();
            if (isselect)
            {
                p.X = M_hangdian[hd_i - 1].X +(int)((Cursor.Position.X - mouseDownPoint.X) / mapFrm._zoom);
                p.Y = M_hangdian[hd_i - 1].Y - (int)((Cursor.Position.Y - mouseDownPoint.Y) / mapFrm._zoom);
                M_hangdian[hd_i - 1] = p;
                M_hangdian_up[hd_i - 1] = p;
                Commands.Rows[hd_i - 1].Cells[6].Value = p.X * 100;
                Commands.Rows[hd_i - 1].Cells[7].Value = p.Y * 100;
                writeKML();
                mapFrm.TRefresh(M_hangdian);
                isselect = false;
                this.Cursor = Cursors.Default;
                //M_hangdian_up = M_hangdian;
            }
            if (isRange&&mapFrm.p_line.Count==2)
            {
                double L;
                L = Math.Sqrt(Math.Pow(mapFrm.p_line[0].X - mapFrm.p_line[1].X, 2) + Math.Pow(mapFrm.p_line[0].Y - mapFrm.p_line[1].Y, 2))/10.0;
                MessageBox.Show("测距距离： "+L.ToString("0.00")+"km");
                mapFrm.p_line.Clear();
                mapFrm.Refresh();
                mapFrm.rang_ToolStripMenuItemReview.Checked = false;
                isRange = false;
            }
            
            pointReview.Visible = false;
        }
        private Point ChangeHangdian(Locationwp p)//1224
        {
            Point pp = new Point();
            pp.X = Convert.ToInt32(p.lng) / 100;
            pp.Y = Convert.ToInt32(p.lat) / 100;
            return pp;
        }
        public static byte crc_calculate(byte[] pBuffer, int length)
        {

            if (length < 1)
            {
                return 0xff;
            }
            byte CRC = pBuffer[1];
            for (int i = 2; i < pBuffer.Length - 4; i++)
            {
                CRC ^= pBuffer[i];
            }
            return CRC;

        }
        private StringBuilder MsgStr = new StringBuilder();
        int jjjj = 0;

        private void gps_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);

            string msg;
            int j = 0;
            string s = gps.ReadLine();
            byte[] buff = System.Text.Encoding.Default.GetBytes(s);
            if (!gps.IsOpen || Xuni_set)
            {
                return;
            }
            byte crc = crc_calculate(buff, buff.Length - 5);
            byte[] byteAscii = new byte[] { buff[buff.Length - 3], buff[buff.Length - 2] };
            string s1 = Convert.ToString(crc, 16);
            string s2 = Encoding.ASCII.GetString(byteAscii).ToLower();
            
            if (s1.Length == 1)
            {
                s1 = "0" + s1;
            }
            if (s1 != s2)
            {
                return;
                                
            }
            else
            {
                MsgStr.Clear();
                for (int i = 1; i < buff.Length - 4; i++)
                {
                    msg = Convert.ToChar(buff[i]).ToString();
                    if (msg=="$")
                    {
                        break; 
                    }
                    MsgStr.Append(msg);
                }
            }
            if (MsgStr.Length > 10)
            {
                int jj = 0;
                int[] gps1 = new int[14];
                string[] gpss = new string[13];
                char[] gpsss = new char[13];

                gpssum = gpss;
                for (int i = 0; i < MsgStr.Length; i++)
                {
                    if (MsgStr[i] == ',' || MsgStr[i] == '*')
                    {
                        gps1[jj] = i;
                        jj++;
                    }
                }
                for (int i = 0; i < 13; i++)
                {

                    if (gps1[i] + 1 == gps1[i + 1])
                    {
                        gpss[i] = null;
                    }
                    else
                    {
                        for (j = gps1[i]; j < gps1[i + 1] - 1; j++)
                        {
                            gpss[i] += MsgStr[j + 1];
                        }

                    }
                }
                //$GNRMC
                double lat, lng;
                if (gpssum[2]==null&&gpssum[4]==null)
                {
                    return;
                }
                lat = double.Parse(gpssum[2].Substring(2, gpssum[2].Length - 2)) / 60;
                lng = double.Parse(gpssum[4].Substring(3, gpssum[4].Length - 3)) / 60;
                gpssum[2] = gpssum[2].Substring(0, 2) + lat.ToString("0.0000000").Substring(1, 7);
                gpssum[4] = gpssum[4].Substring(0, 3) + lng.ToString("0.0000000").Substring(1, 7);
                if (gpss[1] != null)
                { gpssum = gpss; }
                if (gpssum[7] == null)
                {
                    gpssum[7] = "0";
                }
                if (gpssum[6] == null)
                {
                    gpssum[6] = "0";
                }
                if (gpssum[1] != "A")
                {
                    return;
                }
                else
                {
                    if (gpssum[2] != null && gpssum[4] != null && gpssum[6] != null && gpssum[7] != null && !Xuni_set)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            if (gpssum[3]=="S")
                            {
                                gpssum[2] = "-" + gpssum[2];
                            }
                            if (gpssum[5] == "W")
                            {
                                gpssum[4] = "-" + gpssum[4];
                            }
                            this.TXT_homelat.Text = gpssum[2];   
                            this.TXT_homelng.Text = gpssum[4];
                            this.TXT_homeheading.Text = gpssum[7];
                            this.TXT_homesecond.Text = gpssum[6];
                        });
                    }      
                }
            }
        }
        private void shipCtrlReader()//1225  船的航向位置获取
        {
            if (shipCtrlThread == true)
                return;
            shipCtrlThread = true;

            shipCtrlThreadrunner.Reset();
            while (shipCtrlThread && !MainForm.comPort.logreadmode)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                if (gps.IsOpen || MainForm.comPort.logreadmode)
                {
                    try
                    {

                        bool isStop = false;
                        ///数据长度
                        //int count = gps.BytesToRead;

                        int n = gps.BytesToRead;
                        if (n < 2)
                        {
                            return;
                        }
                        byte[] buff = new byte[n];
                        gps.Read(buff, 0, n);//读取缓冲数据 

                        string msg = null;
                        byte test = 0;
                        ///接收数据
                        int j = 0;
                        if (!MainForm.comPort.logreadmode && !Xuni_set)
                        {
                            //byte[] buff= new byte[255];
                            //while (true)
                            //{
                            //    this.gps.Read(buff, 0, 1);
                            //    //Thread.Sleep(1);
                            //    if (buff[0] == 0x24)
                            //    {
                            //        this.gps.Read(buff, 1, 1);
                            //        if (buff[1] == 0x47)
                            //        {
                            //            while (test!=0x2A)
                            //            {
                            //                this.gps.Read(buff, 2+j, 1);
                            //                test=buff[2+j];
                            //                j++;
                            //            }
                            //            this.gps.Read(buff, 2 + j, 2);
                            //            j = j + 4;
                            //            break;  
                            //        }
                            //        else
                            //        {
                            //            continue;
                            //        }

                            //    }

                            //}

                            //Array.Resize<byte>(ref buff, j);
                            //if (j<50)
                            //{
                            //    continue;
                            //}
                            //jjjj = j;
                            byte crc = crc_calculate(buff, buff.Length - 3);
                            byte[] byteAscii = new byte[] { buff[buff.Length - 2], buff[buff.Length - 1] };
                            string s1 = Convert.ToString(crc, 16);
                            string s2 = Encoding.ASCII.GetString(byteAscii).ToLower();
                            if (s1.Length == 1)
                            {
                                s1 = "0" + s1;
                            }
                            if (s1 != s2)
                            {
                                continue;

                            }
                            else
                            {
                                MsgStr.Clear();
                                for (int i = 0; i < buff.Length - 2; i++)
                                {
                                    msg = Convert.ToChar(buff[i]).ToString();
                                    MsgStr.Append(msg);
                                }
                            }



                            if (MsgStr.Length > 10)
                            {
                                int jj = 0;
                                int[] gps1 = new int[14];
                                string[] gpss = new string[13];
                                char[] gpsss = new char[13];

                                gpssum = gpss;
                                for (int i = 0; i < MsgStr.Length; i++)
                                {
                                    if (MsgStr[i] == ',' || MsgStr[i] == '*')
                                    {
                                        gps1[jj] = i;
                                        jj++;
                                    }
                                }
                                for (int i = 0; i < 13; i++)
                                {

                                    if (gps1[i] + 1 == gps1[i + 1])
                                    {
                                        gpss[i] = null;
                                    }
                                    else
                                    {
                                        for (j = gps1[i]; j < gps1[i + 1] - 1; j++)
                                        {
                                            gpss[i] += MsgStr[j + 1];
                                        }

                                    }
                                }
                                //$GNRMC
                                double lat, lng;
                                lat = double.Parse(gpssum[2].Substring(2, gpssum[2].Length - 2)) / 60;
                                lng = double.Parse(gpssum[4].Substring(3, gpssum[4].Length - 3)) / 60;
                                gpssum[2] = gpssum[2].Substring(0, 2) + lat.ToString("0.000000000").Substring(1, 9);
                                gpssum[4] = gpssum[4].Substring(0, 3) + lng.ToString("0.000000000").Substring(1, 9);
                                if (gpss[1] != null)
                                { gpssum = gpss; }
                                if (gpssum[7] == null)
                                {
                                    gpssum[7] = "0";
                                }
                                if (gpssum[6] == null)
                                {
                                    gpssum[6] = "0";
                                }
                                if (gpssum[1] != "A")
                                {
                                    continue;
                                }

                            }
                            /////////////////////

                        }

                        ////////////////////////////////
                        if (gpssum[2] != null && gpssum[4] != null && gpssum[6] != null && gpssum[7] != null)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                this.TXT_homelat.Text = gpssum[2];
                                this.TXT_homelng.Text = gpssum[4];
                                this.TXT_homeheading.Text = gpssum[7];
                                this.TXT_homesecond.Text = gpssum[6];
                            });
                        }




                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(ee.ToString());

                    }


                }

            }

            shipCtrlThreadrunner.Set();
        }

        private void 仿真ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fangzhen fz = new Fangzhen();
            fz.Show();  
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (测试ToolStripMenuItem.Checked == true)
            {
                测试ToolStripMenuItem.Checked = false;
            }
            else
            {
                测试ToolStripMenuItem.Checked = true;
                JYLink.jylink_fangzhe_set mode = new JYLink.jylink_fangzhe_set();
                mode.mode = 1;
                MainForm.comPort.setupMode(mode);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            duojiset dataManageFrm = new duojiset();
            dataManageFrm.Owner = this;
            dataManageFrm.StartPosition = FormStartPosition.CenterScreen;
            dataManageFrm.ShowDialog();
        }

        private void 遥测带宽设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaiKuan band = new DaiKuan();
            band.Show();
        }

        private void 归航模式设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuihangMode mode = new GuihangMode();
            mode.Show();
        }

       //////////////////////////////////
        private bool xbCtrlThread = false;
        private ManualResetEvent xbCtrlThreadrunner = new ManualResetEvent(false);
        public JYLink.jylink_xb_status_down xb = new JYLink.jylink_xb_status_down();//信标接收数据
        public JYLink.jylink_bj_status_down bj = new JYLink.jylink_bj_status_down(); //靶机信息
        public JYLink.jylink_Micro_position_setup position = new JYLink.jylink_Micro_position_setup();
        public bool Xuni_set = false;
        private double  sum_l=0;
        public bool isrun=false;
        //public string telecontrol_serialValue;
        //public string telecontrol_baudRateValue;

        private void xbCtrlReader()//xinbiao
        {
            if (xbCtrlThread == true)
                return;
            xbCtrlThread = true;
            xbCtrlThreadrunner.Reset();
            while (xbCtrlThread)
            {
                if (!xinbiao.IsOpen)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    try
                    {
                        byte[] buff = new byte[512];
                        ///接收数据
                        int readcount = 0;
                        int j = 0;
                        int length = 0;

                        while (readcount < 200)
                        {
                            xinbiao.Read(buff, 0, 1);

                            if (buff[0] == JYLink.JYLINK_STX_3)
                            {
                                break;
                            }
                            readcount++;
                        }
                        if (buff[0] == JYLink.JYLINK_STX_3)
                        {
                            xinbiao.Read(buff, 1, 3);
                        }
                        else
                        {
                            continue;
                        }

                        length = buff[3] + 1;//加上校验位
                        Thread.Sleep(10);
                        //xinbiao.Read(buff, 4, length);
                        for (int i = 0; i < length;i++ )
                        {
                            xinbiao.Read(buff, 4+i, 1);
                        }
                        Array.Resize<byte>(ref buff, length + 4);
                        byte crc = XBcrc_calculate(buff, buff.Length - 1);
                        byte[] dest = new byte[length - 1];
                        if (crc == buff[buff.Length - 1])
                        {
                            if (!Listbuff.Keys.Contains(buff[2]))
                            {
                                Listbuff.Add(buff[2], buff);
                            }
                            else
                            {
                                Listbuff[buff[2]] = buff;
                            }
                            if (buff[2] == 0x50)
                            {
                                Array.Copy(buff, 4, dest, 0, dest.Length);
                                BytesToStruct(dest, ref xb);
                                if (!xbsum.Keys.Contains(buff[4]))
                                {
                                    xbsum.Add(buff[4], xb);
                                }
                                else
                                {
                                    xbsum[buff[4]] = xb;
                                }
                            }
                        }

                    }
                    catch (Exception)
                    {


                    }
                }
            }

        }
        public static byte XBcrc_calculate(byte[] pBuffer, int length)
        {

            if (length < 1)
            {
                return 0xff;
            }
            byte CRC = pBuffer[0];
            for (int i = 1; i < pBuffer.Length - 1; i++)
            {
                CRC += pBuffer[i];
            }
            return CRC;

        }
        public void generatePacket(int messageType, object indata)
        {
            // lock (objlock)
            /// {
            if (!xinbiao.IsOpen)
            {
                return;
            }
            byte[] data;
            if (messageType == 0xA1)
            {
                data = (byte[])indata;
            }
            else
            {
                data = StructureToByteArray(messageType, indata);
            }


            byte[] packet = new byte[0];
            int i = 0;

            // are we mavlink2 enabled for this sysid/compid
            if (messageType < 256)
            {


                packet = new byte[data.Length + 5];

                packet[0] = JYLink.JYLINK_STX_3;
                packet[1] = JYLink.JYLINK_STX_4;
                packet[2] = (byte)messageType;
                if (messageType == 1)
                {
                    packet[3] = 0x20;
                }
                else if (messageType == 2)
                {
                    packet[3] = 0x18;
                }
                else if (messageType == 0xA1)
                {
                    packet[3] = 42;
                }
                i = 4;
                foreach (byte b in data)
                {
                    packet[i] = b;
                    i++;
                }
                byte crc = XBcrc_calculate(packet, packet.Length - 1);
                packet[packet.Length - 1] = crc;

                xinbiao.Write(packet, 0, packet.Length);


            }

        }

        // }

        public static byte[] StructureToByteArray(int messageType, object indata)
        {
            int len = 0;
            if (messageType == 1)
            {
                len = 32;
            }
            else if (messageType == 2)
            {
                len = 24;
            }
            int messg_len = 0;
            byte[] arr = new byte[len];
            //航点查询指令
            if (messageType == 0x01)
            {
                JYLink.jylink_bj_status_down bj = (JYLink.jylink_bj_status_down)indata;
                byte[] bcmd = new byte[3];
                bcmd[0] = bj.bjid;
                bcmd[1] = bj.wbyid;
                bcmd[2] = bj.mode;
                Buffer.BlockCopy(bcmd, 0, arr, messg_len, bcmd.Length);
                messg_len += bcmd.Length;
                double Gyrinv10 = bj.lat;
                byte[] bad3 = BitConverter.GetBytes(Gyrinv10);
                Buffer.BlockCopy(bad3, 0, arr, messg_len, bad3.Length);
                messg_len += bad3.Length;
                double Gyrinv11 = bj.lng;
                byte[] bad4 = BitConverter.GetBytes(Gyrinv11);
                Buffer.BlockCopy(bad4, 0, arr, messg_len, bad4.Length);
                messg_len += bad4.Length;
                UInt16 Gyrinv12 = bj.alt;
                byte[] bad5 = BitConverter.GetBytes(Gyrinv12);
                Buffer.BlockCopy(bad5, 0, arr, messg_len, bad5.Length);
                messg_len += bad5.Length;
                float Gyrinv20 = bj.heading;
                byte[] bad6 = BitConverter.GetBytes(Gyrinv20);
                Buffer.BlockCopy(bad6, 0, arr, messg_len, bad6.Length);
                messg_len += bad6.Length;
                UInt16 Gyrinv21 = bj.UTC_year;
                byte[] bad7 = BitConverter.GetBytes(Gyrinv21);
                Buffer.BlockCopy(bad7, 0, arr, messg_len, bad7.Length);
                messg_len += bad7.Length;
                byte[] bcmd2 = new byte[5];
                bcmd2[0] = bj.UTC_month;
                bcmd2[1] = bj.UTC_day;
                bcmd2[2] = bj.UTC_hour;
                bcmd2[3] = bj.UTC_min;
                bcmd2[4] = bj.UTC_sec;
                Buffer.BlockCopy(bcmd2, 0, arr, messg_len, bcmd2.Length);
            }
            else if (messageType == 0x02)
            {

                JYLink.jylink_Micro_status_down bj = (JYLink.jylink_Micro_status_down)indata;
                byte[] bcmd = new byte[3];
                bcmd[0] = bj.wby_status1;
                bcmd[1] = bj.wby_id;
                bcmd[2] = bj.kdj_id;
                UInt16 Gyrinv10 = bj.kj_time;
                byte[] bad3 = BitConverter.GetBytes(Gyrinv10);
                Buffer.BlockCopy(bad3, 0, arr, messg_len, bad3.Length);
                messg_len += bad3.Length;
                Buffer.BlockCopy(bcmd, 0, arr, messg_len, bcmd.Length);
                messg_len += bcmd.Length;
                UInt16 Gyrinv11 = bj.bj_kdj_l;
                byte[] bad4 = BitConverter.GetBytes(Gyrinv11);
                Buffer.BlockCopy(bad4, 0, arr, messg_len, bad4.Length);
                messg_len += bad4.Length;
                Int16 Gyrinv12 = bj.bj_zxj;
                byte[] bad5 = BitConverter.GetBytes(Gyrinv12);
                Buffer.BlockCopy(bad5, 0, arr, messg_len, bad5.Length);
                messg_len += bad5.Length;
                Int16 Gyrinv20 = bj.bjsf_fkj;
                byte[] bad6 = BitConverter.GetBytes(Gyrinv20);
                Buffer.BlockCopy(bad6, 0, arr, messg_len, bad6.Length);
                messg_len += bad6.Length;
                UInt16 Gyrinv21 = bj.v_60;
                byte[] bad7 = BitConverter.GetBytes(Gyrinv21);
                Buffer.BlockCopy(bad7, 0, arr, messg_len, bad7.Length);
                messg_len += bad7.Length;
                UInt16 Gyrinv22 = bj.v1_28;
                byte[] bad8 = BitConverter.GetBytes(Gyrinv22);
                Buffer.BlockCopy(bad8, 0, arr, messg_len, bad8.Length);
                messg_len += bad7.Length;
                UInt16 Gyrinv23 = bj.v2_28;
                byte[] bad9 = BitConverter.GetBytes(Gyrinv23);
                Buffer.BlockCopy(bad9, 0, arr, messg_len, bad9.Length);
                messg_len += bad7.Length;
                UInt16 Gyrinv24 = bj.v_12;
                byte[] bad10 = BitConverter.GetBytes(Gyrinv24);
                Buffer.BlockCopy(bad10, 0, arr, messg_len, bad10.Length);
                messg_len += bad7.Length;
                UInt16 Gyrinv25 = bj.pz_cyz;
                byte[] bad11 = BitConverter.GetBytes(Gyrinv25);
                Buffer.BlockCopy(bad11, 0, arr, messg_len, bad11.Length);
                messg_len += bad7.Length;
                Int16 Gyrinv26 = bj.beiyong;
                byte[] bad12 = BitConverter.GetBytes(Gyrinv26);
                Buffer.BlockCopy(bad12, 0, arr, messg_len, bad12.Length);
                byte wby_status2 = bj.wby_status2;
                arr[23] = wby_status2;
            }
            return arr;
        }
        private JYLink.jylink_Micro_param_setup GetParm(byte[] buff)
        {
            JYLink.jylink_Micro_param_setup temp = new JYLink.jylink_Micro_param_setup();
            try
            {
                byte[] buffer = new byte[buff.Length - 5];
                Array.Copy(buff, 4, buffer, 0, buffer.Length);

                BytesToStruct(buffer, ref temp);
                return temp;
            }
            catch (Exception)
            {
                return temp;
            }

        }
        public static void BytesToStruct(byte[] bytes, ref JYLink.jylink_Micro_param_setup Head)
        {
            int size = Marshal.SizeOf(Head);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                Head = (JYLink.jylink_Micro_param_setup)Marshal.PtrToStructure(buffer, Head.GetType());
                //return bytes;
            }
            catch
            {
                Marshal.FreeHGlobal(buffer);
                //return bytes;
            }
        }
        public static void BytesToStruct(byte[] bytes, ref JYLink.jylink_xb_status_down Head)
        {
            int size = Marshal.SizeOf(Head);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                Head = (JYLink.jylink_xb_status_down)Marshal.PtrToStructure(buffer, Head.GetType());
                //return bytes;
            }
            catch
            {
                Marshal.FreeHGlobal(buffer);
                //return bytes;
            }
        }

        private void 干扰机指令设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetID id = new SetID();
            id.StartPosition = FormStartPosition.CenterScreen;
            id.Show();
        }
        public void setXuni_ItemClick(object sender, ItemClickEventArgs e)
        {
            double temp;
            if (!double.TryParse(lat_xn.Text,out temp)||!double.TryParse(lng_xn.Text,out temp)||!double.TryParse(head_xn.Text,out temp)||!double.TryParse(speed_xn.Text,out temp))
            {
               MessageBox.Show("输入的数据不合法！");
               return;
            }
            if (!Xuni_set)
            {
                CurrentState.xn_lat = double.Parse(lat_xn.Text);
                CurrentState.xn_lng = double.Parse(lng_xn.Text);
            }
            CurrentState.xn_head = Convert.ToInt16(double.Parse(head_xn.Text));
            CurrentState.xn_speed = Convert.ToInt16(double.Parse(speed_xn.Text));
            Xuni_set = true;
            MessageBox.Show("设置按照虚拟舰飞行成功！");
        }
        public void TUIChungXuni_ItemClick(object sender, ItemClickEventArgs e)
        {
            Xuni_set = false;
            MessageBox.Show("退出虚拟舰飞行成功！");
        }

        private void 设置飞行虚拟点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuNi xuniFrm = new XuNi(); ;
            xuniFrm.Show();
        }
        PointLatLng[] KongYu_init = new PointLatLng[8];

        
        public void setKongyu_ItemClick(PointLatLng[] temp)
        {
            KongYu_init = temp;
            for (int i = 0; i < 8; i++)
            {
                mapFrm.p_kongyu_init[i] = ChangeHangdian2(temp[i]);
            }
        }
        private Point ChangeHangdian2(PointLatLng p)//1224
        {
            Point pp = new Point();

            p1.Lat = Convert.ToDouble(this.TXT_homelat.Text);
            p1.Lng = Convert.ToDouble(this.TXT_homelng.Text);

            pp = LatLng_to_xy(p1, p);
            //pp.X = Convert.ToInt32(p.lng) / 100;
            //pp.Y = Convert.ToInt32(p.lat) / 100;
            return pp;
        }

        private void targetlabel_TextChanged(object sender, EventArgs e)
        {
            comPort.targetid = byte.Parse(targetlabel.Text);
        }

        private void 微波源ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (微波源ToolStripMenuItem.Checked)
            {
                microwave.Show(this.dockMainPanel);
                microwave.PanelPane = wpsFrm.PanelPane;//加载微波源显示界面
            }
            else
            {
                microwave.IsHidden = true;
            }
        }

        private void 多机数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 多机数据ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (多机数据ToolStripMenuItem.Checked)
            {
                hudview.Show();
            }
            else
            {
                hudview.Visible = false;
            }
        }

        private void 干扰机ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (干扰机ToolStripMenuItem.Checked)
            {
                ganraoji.Show(this.dockMainPanel);
                ganraoji.PanelPane = wpsFrm.PanelPane;//加载微波源显示界面
            }
            else
            {
                ganraoji.IsHidden = true;
            }
        }

        private void timsUploadWps_Click(object sender, EventArgs e)
        {
            HightSet hig = new HightSet();
            hig.StartPosition = FormStartPosition.CenterScreen;
            hig.Show();
        }

        private void timsShowWps_Click(object sender, EventArgs e)
        {
            ZhHe hig = new ZhHe();
            hig.StartPosition = FormStartPosition.CenterScreen;
            hig.Show();
        }

        private void 数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataImoport data = new DataImoport();
            data.Show();
        }
        JYLink.jylink_youmen_mode_setup youmen = new JYLink.jylink_youmen_mode_setup();
   
        private void 手动模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!comPort.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bool result = false;
            youmen.status = 0;
            result = comPort.setupYoumenMode(youmen);
        }

        private void 定速模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!comPort.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bool result = false;
            youmen.status = 1;
            result = comPort.setupYoumenMode(youmen);
        }

        private void 编队模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!comPort.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bool result = false;
            youmen.status = 2;
            result = comPort.setupYoumenMode(youmen);
        }

        private void 设定监测ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (设定监测ToolStripMenuItem.Checked)
            {
                telemetryFrm2.Show(this.dockMainPanel);
                telemetryFrm2.PanelPane = wpsFrm.PanelPane;//加载微波源显示界面
            }
            else
            {
                telemetryFrm2.IsHidden = true;
            }
        }

        private void timsClearWps_Click(object sender, EventArgs e)
        {
            BianDuiParm bd = new BianDuiParm();
            bd.StartPosition = FormStartPosition.CenterScreen;
            bd.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //wpsFrm.Dispose();
            //mapFrm.Dispose();
            //hudFrm.Dispose();
            //telemetryFrm.Dispose();
        }

        private void 归航模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuihangMode mode = new GuihangMode();
            mode.Show();
        }
        bool te = false;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.O)
            {
                te = true;

            }
            if (e.Shift && e.KeyCode == Keys.S)
            {
                MapSet_ToolStripMenuItem.Visible = true;
            }
            if (e.Shift && e.KeyCode == Keys.Y)
            {
                MapSet_ToolStripMenuItem.Visible = false;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && te)
            {
                te = false;
                ConfigFrm cn = new ConfigFrm();
                cn.Show();

            }
        }
        public byte hangxian_num = 0;
        public void btnReadNumWaypoints_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Commands.Rows.Count > 0)
            {
                if (
                    CustomMessageBox.Show("查询操作将清除现有航线, 是否继续?", "Confirm",
                        MessageBoxButtons.OKCancel) != DialogResult.OK
                    )
                {
                    return;
                }
            }

            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Receiving WP's"
            };

            frmProgressReporter.DoWork += getWPsNum;
            frmProgressReporter.UpdateProgressAndStatus(-1, "Receiving WP's");

            frmProgressReporter.RunBackgroundOperationAsync();

            //frmProgressReporter.Dispose();
            frmProgressReporter.Close();
            mapFrm.hangdian_cmd.Clear();
            Point p = new Point();
            for (int i = 0; i < Commands.Rows.Count; i++)
            {
                p.X = Convert.ToInt32(Commands.Rows[i].Cells[Lon.Index].Value);
                p.Y = Convert.ToInt32(Commands.Rows[i].Cells[Lat.Index].Value);
                // M_hangdian.Add(p); //1224
                mapFrm.hangdian_cmd.Add(Commands.Rows[i].Cells[Command.Index].Value.ToString());
            }

        }
        private void getWPsNum(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                JYLinkInterface port = MainForm.comPort;

                if (!port.BaseStream.IsOpen)
                {
                    throw new Exception("Please Connect First!");
                }
                MainForm.comPort.giveComport = true;

                param = port.JY.param;

                log.Info("Getting Home");

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Getting WP count");

                int cmdcount = 0;
                log.Info("Getting WP #");
                //wpRoute.Routelist.Clear();
                byte num = hangxian_num;
                cmdcount = port.getWPCount(num);
                //int cmdcount = -1;
                if (cmdcount == -1)
                {
                    MessageBox.Show("获取航点信息错误！");
                    log.Info("wp count = -1");
                    MainForm.comPort.giveComport = false;
                    return;
                }

                for (byte a = 0; a < cmdcount; a++)
                {
                    if (((ProgressReporterDialogue)sender).doWorkArgs.CancelRequested)
                    {
                        ((ProgressReporterDialogue)sender).doWorkArgs.CancelAcknowledged = true;
                        throw new Exception("Cancel Requested");
                    }

                    log.Info("Getting WP" + a);
                    ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / cmdcount, "Getting WP " + a);
                    Locationwp wp = port.getWP(num, a);
                    if (!wp.Tag.Equals("error"))
                    {
                        cmds.Add(wp);
                    }
                    else
                    {
                        MessageBox.Show("获取航点错误!");
                        break;
                    }
                }




                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done");

                log.Info("Done");
            }
            catch
            {
                MainForm.comPort.giveComport = false;
                throw;
            }
            if (cmds.Count > 0)
            {
                M_hangdian.Clear();
                M_hangdian_up.Clear();
                for (int i = 0; i < cmds.Count; i++)
                {
                    M_hangdian.Add(ChangeHangdian(cmds[i])); //1224
                    M_hangdian_up.Add(ChangeHangdian(cmds[i])); //1224
                }
                // mapFrm.TRefresh(M_hangdian);
            }
            WPtoScreen(cmds);
            MainForm.comPort.giveComport = false;
        }

        private void 手动指令ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (手动指令ToolStripMenuItem.Checked)
            {
                commandsFrm.Show(this.dockMainPanel);
                commandsFrm.PanelPane = wpsFrm.PanelPane;
            }
            else
            {

                commandsFrm.IsHidden = true;
            }
        }

        private void 航线参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Route ro = new Route();
            ro.Show();
        }

        private void 电子检查单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckData ch = new CheckData();
            ch.Show();
        }
        Forms.DataView dataView;
        private void toolStripMenuItem5_CheckStateChanged(object sender, EventArgs e)
        {
            if (dataToolStripMenuItem.Checked)
            {
                dataView = new Forms.DataView();
                dataView.Show();
            }
            else
            {
                dataView.Close();
                
            }
        }

        private void 配置靶机ID表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_IdSet id = new Table_IdSet();
            id.Show();
        }

      
    }
}