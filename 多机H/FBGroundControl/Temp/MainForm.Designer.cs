namespace FBGroundControl
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (thisthread != null)
            {
                thisthread.Abort();
                thisthread = null;
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.cboProtocolType = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cboPort = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnArm = new DevExpress.XtraBars.BarButtonItem();
            this.TXT_homelng = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TXT_homelat = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TXT_homealt = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TXT_DefaultAlt = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TXT_WPRad = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TXT_loiterrad = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.CMB_altmode1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.CHK_verifyheight = new DevExpress.XtraBars.BarCheckItem();
            this.txtSpace = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnSplice = new DevExpress.XtraBars.BarButtonItem();
            this.CMB_altmode = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnReadWaypoints = new DevExpress.XtraBars.BarButtonItem();
            this.btnWriteWaypoints = new DevExpress.XtraBars.BarButtonItem();
            this.btnReadWpsFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveWpsFile = new DevExpress.XtraBars.BarButtonItem();
            this.cboFlightModel = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnAutoFlight = new DevExpress.XtraBars.BarButtonItem();
            this.btnThrottleUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThrottleDown = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.飞行至此ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制多边形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加多边形点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清楚多边形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置家在这ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hud1 = new MissionPlanner.Controls.HUD();
            this.bindingSourceHud = new System.Windows.Forms.BindingSource(this.components);
            this.Commands = new System.Windows.Forms.DataGridView();
            this.Command = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Param1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Up = new System.Windows.Forms.DataGridViewImageColumn();
            this.Down = new System.Windows.Forms.DataGridViewImageColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelQuick = new System.Windows.Forms.TableLayoutPanel();
            this.quickView7 = new MissionPlanner.Controls.QuickView();
            this.quickView8 = new MissionPlanner.Controls.QuickView();
            this.quickView9 = new MissionPlanner.Controls.QuickView();
            this.quickView10 = new MissionPlanner.Controls.QuickView();
            this.quickView11 = new MissionPlanner.Controls.QuickView();
            this.quickView12 = new MissionPlanner.Controls.QuickView();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.myGMAP1 = new MissionPlanner.Controls.myGMAP();
            this.quickView1 = new MissionPlanner.Controls.QuickView();
            this.quickView2 = new MissionPlanner.Controls.QuickView();
            this.quickView3 = new MissionPlanner.Controls.QuickView();
            this.quickView4 = new MissionPlanner.Controls.QuickView();
            this.quickView5 = new MissionPlanner.Controls.QuickView();
            this.quickView6 = new MissionPlanner.Controls.QuickView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDistance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblAreaText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelQuick.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.cboProtocolType,
            this.cboPort,
            this.btnConnect,
            this.btnArm,
            this.TXT_homelng,
            this.TXT_homelat,
            this.TXT_homealt,
            this.TXT_DefaultAlt,
            this.TXT_WPRad,
            this.TXT_loiterrad,
            this.CMB_altmode1,
            this.CHK_verifyheight,
            this.txtSpace,
            this.btnSplice,
            this.CMB_altmode,
            this.btnReadWaypoints,
            this.btnWriteWaypoints,
            this.btnReadWpsFile,
            this.btnSaveWpsFile,
            this.cboFlightModel,
            this.btnAutoFlight,
            this.btnThrottleUp,
            this.btnThrottleDown});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemTextEdit6,
            this.repositoryItemComboBox3,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit7,
            this.repositoryItemComboBox4,
            this.repositoryItemComboBox5,
            this.repositoryItemComboBox6});
            this.ribbon.Size = new System.Drawing.Size(1251, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // cboProtocolType
            // 
            this.cboProtocolType.Edit = this.repositoryItemComboBox1;
            this.cboProtocolType.EditValue = "TCP";
            this.cboProtocolType.EditWidth = 100;
            this.cboProtocolType.Id = 3;
            this.cboProtocolType.Name = "cboProtocolType";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "TCP"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // cboPort
            // 
            this.cboPort.Edit = this.repositoryItemComboBox2;
            this.cboPort.EditValue = "57600";
            this.cboPort.EditWidth = 100;
            this.cboPort.Id = 6;
            this.cboPort.Name = "cboPort";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "         连接";
            this.btnConnect.Id = 7;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // btnArm
            // 
            this.btnArm.Caption = "解锁";
            this.btnArm.Id = 8;
            this.btnArm.Name = "btnArm";
            this.btnArm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnArm_ItemClick);
            // 
            // TXT_homelng
            // 
            this.TXT_homelng.Caption = "经度";
            this.TXT_homelng.Edit = this.repositoryItemTextEdit1;
            this.TXT_homelng.EditValue = "";
            this.TXT_homelng.EditWidth = 100;
            this.TXT_homelng.Id = 9;
            this.TXT_homelng.Name = "TXT_homelng";
            this.TXT_homelng.EditValueChanged += new System.EventHandler(this.TXT_homelng_TextChanged);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // TXT_homelat
            // 
            this.TXT_homelat.Caption = "纬度";
            this.TXT_homelat.Edit = this.repositoryItemTextEdit2;
            this.TXT_homelat.EditValue = "";
            this.TXT_homelat.EditWidth = 100;
            this.TXT_homelat.Id = 10;
            this.TXT_homelat.Name = "TXT_homelat";
            this.TXT_homelat.EditValueChanged += new System.EventHandler(this.TXT_homelat_TextChanged);
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // TXT_homealt
            // 
            this.TXT_homealt.Caption = "高度";
            this.TXT_homealt.Edit = this.repositoryItemTextEdit3;
            this.TXT_homealt.EditValue = "";
            this.TXT_homealt.EditWidth = 100;
            this.TXT_homealt.Id = 11;
            this.TXT_homealt.Name = "TXT_homealt";
            this.TXT_homealt.EditValueChanged += new System.EventHandler(this.TXT_homealt_TextChanged);
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // TXT_DefaultAlt
            // 
            this.TXT_DefaultAlt.Caption = "默认高度";
            this.TXT_DefaultAlt.Edit = this.repositoryItemTextEdit4;
            this.TXT_DefaultAlt.EditValue = "";
            this.TXT_DefaultAlt.EditWidth = 100;
            this.TXT_DefaultAlt.Id = 12;
            this.TXT_DefaultAlt.Name = "TXT_DefaultAlt";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // TXT_WPRad
            // 
            this.TXT_WPRad.Caption = "航点半径";
            this.TXT_WPRad.Edit = this.repositoryItemTextEdit5;
            this.TXT_WPRad.EditWidth = 100;
            this.TXT_WPRad.Id = 13;
            this.TXT_WPRad.Name = "TXT_WPRad";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // TXT_loiterrad
            // 
            this.TXT_loiterrad.Caption = "悬停半径";
            this.TXT_loiterrad.Edit = this.repositoryItemTextEdit6;
            this.TXT_loiterrad.EditWidth = 100;
            this.TXT_loiterrad.Id = 14;
            this.TXT_loiterrad.Name = "TXT_loiterrad";
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // CMB_altmode1
            // 
            this.CMB_altmode1.Caption = "高度模式";
            this.CMB_altmode1.Edit = this.repositoryItemComboBox3;
            this.CMB_altmode1.EditValue = "Relative";
            this.CMB_altmode1.EditWidth = 100;
            this.CMB_altmode1.Id = 15;
            this.CMB_altmode1.Name = "CMB_altmode1";
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // CHK_verifyheight
            // 
            this.CHK_verifyheight.Caption = "验证高度";
            this.CHK_verifyheight.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.CHK_verifyheight.Id = 17;
            this.CHK_verifyheight.Name = "CHK_verifyheight";
            // 
            // txtSpace
            // 
            this.txtSpace.Caption = "间距";
            this.txtSpace.Edit = this.repositoryItemTextEdit7;
            this.txtSpace.EditWidth = 100;
            this.txtSpace.Id = 18;
            this.txtSpace.Name = "txtSpace";
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.Name = "repositoryItemTextEdit7";
            // 
            // btnSplice
            // 
            this.btnSplice.Caption = "           切片";
            this.btnSplice.Id = 19;
            this.btnSplice.Name = "btnSplice";
            this.btnSplice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSplice_ItemClick);
            // 
            // CMB_altmode
            // 
            this.CMB_altmode.Caption = "高度模式";
            this.CMB_altmode.Edit = this.repositoryItemComboBox6;
            this.CMB_altmode.EditValue = "";
            this.CMB_altmode.EditWidth = 100;
            this.CMB_altmode.Id = 20;
            this.CMB_altmode.Name = "CMB_altmode";
            this.CMB_altmode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CMB_altmode_ItemClick);
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            this.repositoryItemComboBox6.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnReadWaypoints
            // 
            this.btnReadWaypoints.Caption = "读取航点";
            this.btnReadWaypoints.Id = 21;
            this.btnReadWaypoints.Name = "btnReadWaypoints";
            this.btnReadWaypoints.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReadWaypoints_ItemClick);
            // 
            // btnWriteWaypoints
            // 
            this.btnWriteWaypoints.Caption = "写入航点";
            this.btnWriteWaypoints.Id = 22;
            this.btnWriteWaypoints.Name = "btnWriteWaypoints";
            this.btnWriteWaypoints.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWriteWaypoints_ItemClick);
            // 
            // btnReadWpsFile
            // 
            this.btnReadWpsFile.Caption = "读取文件";
            this.btnReadWpsFile.Id = 23;
            this.btnReadWpsFile.Name = "btnReadWpsFile";
            this.btnReadWpsFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReadWpsFile_ItemClick);
            // 
            // btnSaveWpsFile
            // 
            this.btnSaveWpsFile.Caption = "写入文件";
            this.btnSaveWpsFile.Id = 24;
            this.btnSaveWpsFile.Name = "btnSaveWpsFile";
            this.btnSaveWpsFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveWpsFile_ItemClick);
            // 
            // cboFlightModel
            // 
            this.cboFlightModel.Caption = "模式";
            this.cboFlightModel.Edit = this.repositoryItemComboBox5;
            this.cboFlightModel.EditWidth = 100;
            this.cboFlightModel.Id = 27;
            this.cboFlightModel.Name = "cboFlightModel";
            this.cboFlightModel.EditValueChanged += new System.EventHandler(this.cboFlightModel_EditValueChanged_1);
            // 
            // repositoryItemComboBox5
            // 
            this.repositoryItemComboBox5.AutoHeight = false;
            this.repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox5.Name = "repositoryItemComboBox5";
            this.repositoryItemComboBox5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnAutoFlight
            // 
            this.btnAutoFlight.Caption = "自动飞行";
            this.btnAutoFlight.Id = 30;
            this.btnAutoFlight.Name = "btnAutoFlight";
            this.btnAutoFlight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoFlight_ItemClick);
            // 
            // btnThrottleUp
            // 
            this.btnThrottleUp.Caption = "加油门";
            this.btnThrottleUp.Id = 31;
            this.btnThrottleUp.Name = "btnThrottleUp";
            this.btnThrottleUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThrottleUp_ItemClick);
            // 
            // btnThrottleDown
            // 
            this.btnThrottleDown.Caption = "减油门";
            this.btnThrottleDown.Id = 2;
            this.btnThrottleDown.Name = "btnThrottleDown";
            this.btnThrottleDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThrottleDown_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "监控";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.cboProtocolType);
            this.ribbonPageGroup1.ItemLinks.Add(this.cboPort);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnConnect);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "监控";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnArm);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnThrottleUp);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnThrottleDown);
            this.ribbonPageGroup2.ItemLinks.Add(this.cboFlightModel);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "操作";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.TXT_homelng);
            this.ribbonPageGroup3.ItemLinks.Add(this.TXT_homelat);
            this.ribbonPageGroup3.ItemLinks.Add(this.TXT_homealt);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "家";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.TXT_DefaultAlt);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "默认值";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.TXT_WPRad);
            this.ribbonPageGroup5.ItemLinks.Add(this.TXT_loiterrad);
            this.ribbonPageGroup5.ItemLinks.Add(this.CHK_verifyheight);
            this.ribbonPageGroup5.ItemLinks.Add(this.CMB_altmode);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "配置";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.txtSpace);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSplice);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnReadWaypoints);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnWriteWaypoints);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnReadWpsFile);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSaveWpsFile);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "航点";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnAutoFlight);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "自动飞行";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 699);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1251, 31);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.飞行至此ToolStripMenuItem,
            this.绘制多边形ToolStripMenuItem,
            this.清除任务ToolStripMenuItem,
            this.设置家在这ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 114);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "删除航点";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 飞行至此ToolStripMenuItem
            // 
            this.飞行至此ToolStripMenuItem.Name = "飞行至此ToolStripMenuItem";
            this.飞行至此ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.飞行至此ToolStripMenuItem.Text = "飞行至此";
            this.飞行至此ToolStripMenuItem.Click += new System.EventHandler(this.goHereToolStripMenuItem_Click);
            // 
            // 绘制多边形ToolStripMenuItem
            // 
            this.绘制多边形ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加多边形点ToolStripMenuItem,
            this.清楚多边形ToolStripMenuItem});
            this.绘制多边形ToolStripMenuItem.Name = "绘制多边形ToolStripMenuItem";
            this.绘制多边形ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.绘制多边形ToolStripMenuItem.Text = "绘制多边形";
            // 
            // 添加多边形点ToolStripMenuItem
            // 
            this.添加多边形点ToolStripMenuItem.Name = "添加多边形点ToolStripMenuItem";
            this.添加多边形点ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加多边形点ToolStripMenuItem.Text = "添加多边形点";
            this.添加多边形点ToolStripMenuItem.Click += new System.EventHandler(this.addPolygonPointToolStripMenuItem_Click);
            // 
            // 清楚多边形ToolStripMenuItem
            // 
            this.清楚多边形ToolStripMenuItem.Name = "清楚多边形ToolStripMenuItem";
            this.清楚多边形ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清楚多边形ToolStripMenuItem.Text = "清除多边形";
            this.清楚多边形ToolStripMenuItem.Click += new System.EventHandler(this.清楚多边形ToolStripMenuItem_Click);
            // 
            // 清除任务ToolStripMenuItem
            // 
            this.清除任务ToolStripMenuItem.Name = "清除任务ToolStripMenuItem";
            this.清除任务ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.清除任务ToolStripMenuItem.Text = "清除任务";
            this.清除任务ToolStripMenuItem.Click += new System.EventHandler(this.清除任务ToolStripMenuItem_Click);
            // 
            // 设置家在这ToolStripMenuItem
            // 
            this.设置家在这ToolStripMenuItem.Name = "设置家在这ToolStripMenuItem";
            this.设置家在这ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.设置家在这ToolStripMenuItem.Text = "设置家在这";
            this.设置家在这ToolStripMenuItem.Click += new System.EventHandler(this.设置家在这ToolStripMenuItem_Click);
            // 
            // hud1
            // 
            this.hud1.opengl = false;
            this.hud1.airspeed = 0F;
            this.hud1.alt = 0F;
            this.hud1.BackColor = System.Drawing.Color.Black;
            this.hud1.batterylevel = 0F;
            this.hud1.batteryremaining = 0F;
            this.hud1.bgimage = null;
            this.hud1.connected = false;
            this.hud1.current = 0F;
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("airspeed", this.bindingSourceHud, "airspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("alt", this.bindingSourceHud, "alt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("batterylevel", this.bindingSourceHud, "battery_voltage", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("batteryremaining", this.bindingSourceHud, "battery_remaining", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("connected", this.bindingSourceHud, "connected", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("current", this.bindingSourceHud, "current", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("datetime", this.bindingSourceHud, "datetime", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("disttowp", this.bindingSourceHud, "wp_dist", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("ekfstatus", this.bindingSourceHud, "ekfstatus", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("failsafe", this.bindingSourceHud, "failsafe", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix", this.bindingSourceHud, "gpsstatus", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop", this.bindingSourceHud, "gpshdop", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundalt", this.bindingSourceHud, "HomeAlt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundcourse", this.bindingSourceHud, "groundcourse", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundspeed", this.bindingSourceHud, "groundspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("heading", this.bindingSourceHud, "yaw", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("linkqualitygcs", this.bindingSourceHud, "linkqualitygcs", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("message", this.bindingSourceHud, "messageHigh", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("messagetime", this.bindingSourceHud, "messageHighTime", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("mode", this.bindingSourceHud, "mode", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("navpitch", this.bindingSourceHud, "nav_pitch", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("navroll", this.bindingSourceHud, "nav_roll", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("pitch", this.bindingSourceHud, "pitch", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("roll", this.bindingSourceHud, "roll", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("status", this.bindingSourceHud, "armed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetalt", this.bindingSourceHud, "targetalt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetheading", this.bindingSourceHud, "nav_bearing", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetspeed", this.bindingSourceHud, "targetairspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("turnrate", this.bindingSourceHud, "turnrate", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("verticalspeed", this.bindingSourceHud, "verticalspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibex", this.bindingSourceHud, "vibex", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibey", this.bindingSourceHud, "vibey", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibez", this.bindingSourceHud, "vibez", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("wpno", this.bindingSourceHud, "wpno", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("xtrack_error", this.bindingSourceHud, "xtrack_error", true));
            this.hud1.datetime = new System.DateTime(((long)(0)));
            this.hud1.disttowp = 0F;
            this.hud1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hud1.ekfstatus = 0F;
            this.hud1.failsafe = false;
            this.hud1.gpsfix = 0F;
            this.hud1.gpshdop = 0F;
            this.hud1.groundalt = 0F;
            this.hud1.groundcourse = 0F;
            this.hud1.groundspeed = 0F;
            this.hud1.heading = 0F;
            this.hud1.hudcolor = System.Drawing.Color.LightGray;
            this.hud1.linkqualitygcs = 0F;
            this.hud1.Location = new System.Drawing.Point(0, 0);
            this.hud1.lowairspeed = false;
            this.hud1.lowgroundspeed = false;
            this.hud1.lowvoltagealert = false;
            this.hud1.message = "";
            this.hud1.messagetime = new System.DateTime(((long)(0)));
            this.hud1.mode = "Unknown";
            this.hud1.Name = "hud1";
            this.hud1.navpitch = 0F;
            this.hud1.navroll = 0F;
            this.hud1.pitch = 0F;
            this.hud1.roll = 0F;
            this.hud1.Russian = false;
            this.hud1.Size = new System.Drawing.Size(465, 330);
            this.hud1.status = false;
            this.hud1.streamjpg = null;
            this.hud1.TabIndex = 0;
            this.hud1.targetalt = 0F;
            this.hud1.targetheading = 0F;
            this.hud1.targetspeed = 0F;
            this.hud1.turnrate = 0F;
            this.hud1.verticalspeed = 0F;
            this.hud1.vibex = 0F;
            this.hud1.vibey = 0F;
            this.hud1.vibez = 0F;
            this.hud1.wpno = 0;
            this.hud1.xtrack_error = 0F;
            // 
            // bindingSourceHud
            // 
            this.bindingSourceHud.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // Commands
            // 
            this.Commands.AllowUserToAddRows = false;
            this.Commands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Commands.ColumnHeadersHeight = 30;
            this.Commands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Param1,
            this.Param2,
            this.Param3,
            this.Param4,
            this.Lat,
            this.Lon,
            this.Alt,
            this.Delete,
            this.Up,
            this.Down,
            this.Grad,
            this.Angle,
            this.Dist,
            this.AZ,
            this.Tag});
            this.Commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Commands.Location = new System.Drawing.Point(0, 0);
            this.Commands.Name = "Commands";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Commands.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Commands.RowHeadersWidth = 50;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Commands.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Commands.Size = new System.Drawing.Size(770, 175);
            this.Commands.TabIndex = 8;
            this.Commands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellContentClick);
            this.Commands.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellEndEdit);
            this.Commands.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Commands_DataError);
            this.Commands.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Commands_DefaultValuesNeeded);
            this.Commands.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Commands_EditingControlShowing);
            this.Commands.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_RowEnter);
            this.Commands.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Commands_RowsAdded);
            this.Commands.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Commands_RowValidating);
            // 
            // Command
            // 
            this.Command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Command.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Command.HeaderText = "命令";
            this.Command.MinimumWidth = 80;
            this.Command.Name = "Command";
            this.Command.ToolTipText = "命令";
            this.Command.Width = 80;
            // 
            // Param1
            // 
            this.Param1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Param1.HeaderText = "P1";
            this.Param1.MinimumWidth = 30;
            this.Param1.Name = "Param1";
            this.Param1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param1.Width = 30;
            // 
            // Param2
            // 
            this.Param2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Param2.HeaderText = "P2";
            this.Param2.MinimumWidth = 30;
            this.Param2.Name = "Param2";
            this.Param2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param2.Width = 30;
            // 
            // Param3
            // 
            this.Param3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Param3.HeaderText = "P3";
            this.Param3.MinimumWidth = 30;
            this.Param3.Name = "Param3";
            this.Param3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param3.Width = 30;
            // 
            // Param4
            // 
            this.Param4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Param4.HeaderText = "P4";
            this.Param4.MinimumWidth = 30;
            this.Param4.Name = "Param4";
            this.Param4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param4.Width = 30;
            // 
            // Lat
            // 
            this.Lat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Lat.HeaderText = "纬度";
            this.Lat.MinimumWidth = 60;
            this.Lat.Name = "Lat";
            this.Lat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Lat.Width = 60;
            // 
            // Lon
            // 
            this.Lon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Lon.HeaderText = "经度";
            this.Lon.MinimumWidth = 60;
            this.Lon.Name = "Lon";
            this.Lon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Lon.Width = 60;
            // 
            // Alt
            // 
            this.Alt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Alt.HeaderText = "高度";
            this.Alt.MinimumWidth = 60;
            this.Alt.Name = "Alt";
            this.Alt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Alt.Width = 60;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Delete.HeaderText = "删除";
            this.Delete.MinimumWidth = 50;
            this.Delete.Name = "Delete";
            this.Delete.Text = "X";
            this.Delete.ToolTipText = "Delete the row";
            this.Delete.Width = 50;
            // 
            // Up
            // 
            this.Up.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Up.DefaultCellStyle = dataGridViewCellStyle1;
            this.Up.HeaderText = "上移";
            this.Up.Image = ((System.Drawing.Image)(resources.GetObject("Up.Image")));
            this.Up.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Up.MinimumWidth = 40;
            this.Up.Name = "Up";
            this.Up.ToolTipText = "Move the row UP";
            this.Up.Width = 40;
            // 
            // Down
            // 
            this.Down.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Down.DefaultCellStyle = dataGridViewCellStyle2;
            this.Down.HeaderText = "下移";
            this.Down.Image = ((System.Drawing.Image)(resources.GetObject("Down.Image")));
            this.Down.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Down.MinimumWidth = 40;
            this.Down.Name = "Down";
            this.Down.ToolTipText = "Move the row down";
            this.Down.Width = 40;
            // 
            // Grad
            // 
            this.Grad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Grad.HeaderText = "Grad %";
            this.Grad.MinimumWidth = 60;
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            this.Grad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Grad.Width = 60;
            // 
            // Angle
            // 
            this.Angle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Angle.HeaderText = "角度";
            this.Angle.MinimumWidth = 50;
            this.Angle.Name = "Angle";
            this.Angle.ReadOnly = true;
            this.Angle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Angle.Width = 50;
            // 
            // Dist
            // 
            this.Dist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Dist.HeaderText = "距离";
            this.Dist.MinimumWidth = 40;
            this.Dist.Name = "Dist";
            this.Dist.ReadOnly = true;
            this.Dist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dist.Width = 40;
            // 
            // AZ
            // 
            this.AZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.AZ.HeaderText = "AZ";
            this.AZ.MinimumWidth = 30;
            this.AZ.Name = "AZ";
            this.AZ.ReadOnly = true;
            this.AZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AZ.Width = 30;
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Visible = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2,
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.ID = new System.Guid("9f07f2b3-3665-4d49-9cc2-86afcb9bc0a0");
            this.dockPanel2.Location = new System.Drawing.Point(0, 147);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(473, 200);
            this.dockPanel2.Size = new System.Drawing.Size(473, 552);
            this.dockPanel2.Text = "参数";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.splitContainerControl1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(465, 525);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hud1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel1.Resize += new System.EventHandler(this.splitContainerControl1_Panel1_Resize);
            this.splitContainerControl1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(465, 525);
            this.splitContainerControl1.SplitterPosition = 330;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 190);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelQuick);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 163);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelQuick
            // 
            this.tableLayoutPanelQuick.AutoScroll = true;
            this.tableLayoutPanelQuick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelQuick.ColumnCount = 2;
            this.tableLayoutPanelQuick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelQuick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelQuick.Controls.Add(this.quickView7, 1, 2);
            this.tableLayoutPanelQuick.Controls.Add(this.quickView8, 0, 2);
            this.tableLayoutPanelQuick.Controls.Add(this.quickView9, 1, 1);
            this.tableLayoutPanelQuick.Controls.Add(this.quickView10, 0, 1);
            this.tableLayoutPanelQuick.Controls.Add(this.quickView11, 1, 0);
            this.tableLayoutPanelQuick.Controls.Add(this.quickView12, 0, 0);
            this.tableLayoutPanelQuick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelQuick.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelQuick.Name = "tableLayoutPanelQuick";
            this.tableLayoutPanelQuick.RowCount = 3;
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelQuick.Size = new System.Drawing.Size(451, 157);
            this.tableLayoutPanelQuick.TabIndex = 74;
            // 
            // quickView7
            // 
            this.quickView7.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "DistToHome", true));
            this.quickView7.desc = "DistToMAV";
            this.quickView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView7.Location = new System.Drawing.Point(228, 107);
            this.quickView7.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView7.Name = "quickView7";
            this.quickView7.number = 0D;
            this.quickView7.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.quickView7.numberformat = "0.00";
            this.quickView7.Size = new System.Drawing.Size(220, 47);
            this.quickView7.TabIndex = 10;
            // 
            // quickView8
            // 
            this.quickView8.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "verticalspeed", true));
            this.quickView8.desc = "verticalspeed";
            this.quickView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView8.Location = new System.Drawing.Point(3, 107);
            this.quickView8.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView8.Name = "quickView8";
            this.quickView8.number = 0D;
            this.quickView8.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            this.quickView8.numberformat = "0.00";
            this.quickView8.Size = new System.Drawing.Size(219, 47);
            this.quickView8.TabIndex = 9;
            // 
            // quickView9
            // 
            this.quickView9.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "yaw", true));
            this.quickView9.desc = "yaw";
            this.quickView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView9.Location = new System.Drawing.Point(228, 55);
            this.quickView9.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView9.Name = "quickView9";
            this.quickView9.number = 0D;
            this.quickView9.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(83)))));
            this.quickView9.numberformat = "0.00";
            this.quickView9.Size = new System.Drawing.Size(220, 46);
            this.quickView9.TabIndex = 8;
            // 
            // quickView10
            // 
            this.quickView10.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "wp_dist", true));
            this.quickView10.desc = "wp_dist";
            this.quickView10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView10.Location = new System.Drawing.Point(3, 55);
            this.quickView10.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView10.Name = "quickView10";
            this.quickView10.number = 0D;
            this.quickView10.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.quickView10.numberformat = "0.00";
            this.quickView10.Size = new System.Drawing.Size(219, 46);
            this.quickView10.TabIndex = 3;
            // 
            // quickView11
            // 
            this.quickView11.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "groundspeed", true));
            this.quickView11.desc = "groundspeed";
            this.quickView11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView11.Location = new System.Drawing.Point(228, 3);
            this.quickView11.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView11.Name = "quickView11";
            this.quickView11.number = 0D;
            this.quickView11.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(132)))), ((int)(((byte)(46)))));
            this.quickView11.numberformat = "0.00";
            this.quickView11.Size = new System.Drawing.Size(220, 46);
            this.quickView11.TabIndex = 1;
            // 
            // quickView12
            // 
            this.quickView12.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceHud, "alt", true));
            this.quickView12.desc = "alt";
            this.quickView12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView12.Location = new System.Drawing.Point(3, 3);
            this.quickView12.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView12.Name = "quickView12";
            this.quickView12.number = 0D;
            this.quickView12.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(151)))), ((int)(((byte)(248)))));
            this.quickView12.numberformat = "0.00";
            this.quickView12.Size = new System.Drawing.Size(219, 46);
            this.quickView12.TabIndex = 1;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.ID = new System.Guid("4d270d64-84dd-449f-9eac-120dba859a04");
            this.dockPanel1.Location = new System.Drawing.Point(473, 497);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(437, 202);
            this.dockPanel1.Size = new System.Drawing.Size(778, 202);
            this.dockPanel1.Text = "航点列表";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.Commands);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(770, 175);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
            // 
            // document1
            // 
            this.document1.Caption = "dockPanel3";
            this.document1.ControlName = "dockPanel3";
            this.document1.FloatLocation = new System.Drawing.Point(0, 0);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            // 
            // myGMAP1
            // 
            this.myGMAP1.Bearing = 0F;
            this.myGMAP1.CanDragMap = true;
            this.myGMAP1.ContextMenuStrip = this.contextMenuStrip1;
            this.myGMAP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGMAP1.EmptyTileColor = System.Drawing.Color.Gray;
            this.myGMAP1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myGMAP1.GrayScaleMode = false;
            this.myGMAP1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.myGMAP1.LevelsKeepInMemmory = 5;
            this.myGMAP1.Location = new System.Drawing.Point(473, 147);
            this.myGMAP1.MarkersEnabled = true;
            this.myGMAP1.MaxZoom = 19;
            this.myGMAP1.MinZoom = 0;
            this.myGMAP1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.myGMAP1.Name = "myGMAP1";
            this.myGMAP1.NegativeMode = false;
            this.myGMAP1.PolygonsEnabled = true;
            this.myGMAP1.RetryLoadTile = 0;
            this.myGMAP1.RoutesEnabled = false;
            this.myGMAP1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.myGMAP1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.myGMAP1.ShowTileGridLines = false;
            this.myGMAP1.Size = new System.Drawing.Size(778, 312);
            this.myGMAP1.TabIndex = 6;
            this.myGMAP1.Zoom = 3D;
            this.myGMAP1.Click += new System.EventHandler(this.myGMAP1_Click);
            this.myGMAP1.Paint += new System.Windows.Forms.PaintEventHandler(this.myGMAP1_Paint);
            this.myGMAP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myGMAP1_MouseDown);
            this.myGMAP1.MouseLeave += new System.EventHandler(this.myGMAP1_MouseLeave);
            this.myGMAP1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myGMAP1_MouseMove);
            this.myGMAP1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseUp);
            // 
            // quickView1
            // 
            this.quickView1.desc = "";
            this.quickView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView1.Location = new System.Drawing.Point(3, 3);
            this.quickView1.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView1.Name = "quickView1";
            this.quickView1.number = -9999D;
            this.quickView1.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(151)))), ((int)(((byte)(248)))));
            this.quickView1.numberformat = "0.00";
            this.quickView1.Size = new System.Drawing.Size(100, 25);
            this.quickView1.TabIndex = 1;
            // 
            // quickView2
            // 
            this.quickView2.desc = "";
            this.quickView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView2.Location = new System.Drawing.Point(96, 3);
            this.quickView2.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView2.Name = "quickView2";
            this.quickView2.number = -9999D;
            this.quickView2.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(132)))), ((int)(((byte)(46)))));
            this.quickView2.numberformat = "0.00";
            this.quickView2.Size = new System.Drawing.Size(100, 25);
            this.quickView2.TabIndex = 1;
            // 
            // quickView3
            // 
            this.quickView3.desc = "";
            this.quickView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView3.Location = new System.Drawing.Point(3, 25);
            this.quickView3.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView3.Name = "quickView3";
            this.quickView3.number = -9999D;
            this.quickView3.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.quickView3.numberformat = "0.00";
            this.quickView3.Size = new System.Drawing.Size(100, 25);
            this.quickView3.TabIndex = 3;
            // 
            // quickView4
            // 
            this.quickView4.desc = "";
            this.quickView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView4.Location = new System.Drawing.Point(96, 25);
            this.quickView4.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView4.Name = "quickView4";
            this.quickView4.number = -9999D;
            this.quickView4.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(83)))));
            this.quickView4.numberformat = "0.00";
            this.quickView4.Size = new System.Drawing.Size(100, 25);
            this.quickView4.TabIndex = 8;
            // 
            // quickView5
            // 
            this.quickView5.desc = "";
            this.quickView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView5.Location = new System.Drawing.Point(3, 47);
            this.quickView5.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView5.Name = "quickView5";
            this.quickView5.number = -9999D;
            this.quickView5.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            this.quickView5.numberformat = "0.00";
            this.quickView5.Size = new System.Drawing.Size(100, 25);
            this.quickView5.TabIndex = 9;
            // 
            // quickView6
            // 
            this.quickView6.desc = "";
            this.quickView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickView6.Location = new System.Drawing.Point(96, 47);
            this.quickView6.MinimumSize = new System.Drawing.Size(100, 25);
            this.quickView6.Name = "quickView6";
            this.quickView6.number = -9999D;
            this.quickView6.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.quickView6.numberformat = "0.00";
            this.quickView6.Size = new System.Drawing.Size(100, 25);
            this.quickView6.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDistance);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblArea);
            this.panel1.Controls.Add(this.lblAreaText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(473, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 38);
            this.panel1.TabIndex = 11;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(229, 14);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(32, 14);
            this.lblDistance.TabIndex = 3;
            this.lblDistance.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "距离：";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(66, 14);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 14);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "0.00";
            // 
            // lblAreaText
            // 
            this.lblAreaText.AutoSize = true;
            this.lblAreaText.Location = new System.Drawing.Point(7, 14);
            this.lblAreaText.Name = "lblAreaText";
            this.lblAreaText.Size = new System.Drawing.Size(43, 14);
            this.lblAreaText.TabIndex = 0;
            this.lblAreaText.Text = "面积：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 730);
            this.Controls.Add(this.myGMAP1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelQuick.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarEditItem cboProtocolType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem cboPort;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarButtonItem btnConnect;
        private MissionPlanner.Controls.HUD hud1;
        private System.Windows.Forms.BindingSource bindingSourceHud;
        private DevExpress.XtraBars.BarButtonItem btnArm;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 飞行至此ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制多边形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加多边形点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清楚多边形ToolStripMenuItem;
        private System.Windows.Forms.DataGridView Commands;
        private DevExpress.XtraBars.BarEditItem TXT_homelng;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem TXT_homelat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem TXT_homealt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarEditItem TXT_DefaultAlt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarEditItem TXT_WPRad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarEditItem TXT_loiterrad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraBars.BarEditItem CMB_altmode1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarCheckItem CHK_verifyheight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraBars.BarEditItem txtSpace;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraBars.BarButtonItem btnSplice;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarEditItem CMB_altmode;
        
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarButtonItem btnReadWaypoints;
        private DevExpress.XtraBars.BarButtonItem btnWriteWaypoints;
        private DevExpress.XtraBars.BarButtonItem btnReadWpsFile;
        private DevExpress.XtraBars.BarButtonItem btnSaveWpsFile;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        public MissionPlanner.Controls.myGMAP myGMAP1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MissionPlanner.Controls.QuickView quickView1;
        private MissionPlanner.Controls.QuickView quickView2;
        private MissionPlanner.Controls.QuickView quickView3;
        private MissionPlanner.Controls.QuickView quickView4;
        private MissionPlanner.Controls.QuickView quickView5;
        private MissionPlanner.Controls.QuickView quickView6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelQuick;
        private MissionPlanner.Controls.QuickView quickView7;
        private MissionPlanner.Controls.QuickView quickView8;
        private MissionPlanner.Controls.QuickView quickView9;
        private MissionPlanner.Controls.QuickView quickView10;
        private MissionPlanner.Controls.QuickView quickView11;
        private MissionPlanner.Controls.QuickView quickView12;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
       
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraBars.BarEditItem cboFlightModel;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox5;
        private System.Windows.Forms.ToolStripMenuItem 清除任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置家在这ToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnAutoFlight;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblAreaText;
        private DevExpress.XtraBars.BarButtonItem btnThrottleUp;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private DevExpress.XtraBars.BarButtonItem btnThrottleDown;
    }
}