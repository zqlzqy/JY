
using MissionPlanner.Controls;
using MissionPlanner;

namespace FBGroundControl
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public static bool isExitSystem = false;

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
            isExitSystem = true;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.System_Btn = new MissionPlanner.Controls.SplitButton();
            this.System_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiFirmwareWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRunModel = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仿真ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.飞行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地面站配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communication_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenConneciton_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseConnection_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapSet_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManyPlan_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ID_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBtnComm = new MissionPlanner.Controls.SplitButton();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.map_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headstatus_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.state_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ins_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.微波源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.干扰机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设定监测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多机数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手动指令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBtnWindow = new MissionPlanner.Controls.SplitButton();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataReacorSet_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataReplay_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCheck_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataList_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.command_historyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitButton1 = new MissionPlanner.Controls.SplitButton();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sensor_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.config_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data_manageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commond_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.遥测带宽设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.归航模式设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.干扰机指令设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置飞行虚拟点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置靶机ID表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBtnWaypoints = new MissionPlanner.Controls.SplitButton();
            this.cmsWps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiWpsPlaner = new System.Windows.Forms.ToolStripMenuItem();
            this.WpsPlaner_isShow = new System.Windows.Forms.ToolStripMenuItem();
            this.timsLoadWps = new System.Windows.Forms.ToolStripMenuItem();
            this.timsUploadWps = new System.Windows.Forms.ToolStripMenuItem();
            this.归航模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timsShowWps = new System.Windows.Forms.ToolStripMenuItem();
            this.timsClearWps = new System.Windows.Forms.ToolStripMenuItem();
            this.timsClearPlanWps = new System.Windows.Forms.ToolStripMenuItem();
            this.手动模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定速模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编队模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.空域参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.航线参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电子检查单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitButton2 = new MissionPlanner.Controls.SplitButton();
            this.cmsWindow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemSelfCheck_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engineCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitButton3 = new MissionPlanner.Controls.SplitButton();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveWindow_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWindow_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new BSE.Windows.Forms.Panel();
            this.utctime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.satelite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.youmenmode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gps2 = new System.Windows.Forms.TextBox();
            this.gps1 = new System.Windows.Forms.TextBox();
            this.targetlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.steering_engineStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erect_configToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telemetry_bandwidthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsComm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCommType = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortComm = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpComm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSerialSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTCPSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenTCP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseTCP = new System.Windows.Forms.ToolStripMenuItem();
            this.vS2005Theme1 = new WeifenLuo.WinFormsUI.Docking.VS2005Theme();
            this.ResetWindow_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dockMainPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_angel = new System.Windows.Forms.Label();
            this.lbl_homedist = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pointReview = new System.Windows.Forms.Label();
            this.coords1 = new MissionPlanner.Controls.Coords();
            this.gps = new MissionPlanner.Comms.SerialPort();
            this.xinbiao = new MissionPlanner.Comms.SerialPort();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.System_ContextMenuStrip.SuspendLayout();
            this.contextMenuStrip5.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.cmsWps.SuspendLayout();
            this.cmsWindow.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.cmsComm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1526, 47);
            this.panel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.System_Btn);
            this.flowLayoutPanel1.Controls.Add(this.sBtnComm);
            this.flowLayoutPanel1.Controls.Add(this.sBtnWindow);
            this.flowLayoutPanel1.Controls.Add(this.splitButton1);
            this.flowLayoutPanel1.Controls.Add(this.sBtnWaypoints);
            this.flowLayoutPanel1.Controls.Add(this.splitButton2);
            this.flowLayoutPanel1.Controls.Add(this.splitButton3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 47);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // System_Btn
            // 
            this.System_Btn.BackColor = System.Drawing.Color.Transparent;
            this.System_Btn.ContextMenuStrip = this.System_ContextMenuStrip;
            this.System_Btn.DropDownButton = true;
            this.System_Btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.System_Btn.FlatAppearance.BorderSize = 0;
            this.System_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.System_Btn.Font = new System.Drawing.Font("宋体", 11F);
            this.System_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.System_Btn.Location = new System.Drawing.Point(3, 3);
            this.System_Btn.Name = "System_Btn";
            this.System_Btn.Size = new System.Drawing.Size(80, 41);
            this.System_Btn.TabIndex = 1;
            this.System_Btn.TabStop = false;
            this.System_Btn.Text = "系统设置";
            this.System_Btn.UseVisualStyleBackColor = false;
            this.System_Btn.Click += new System.EventHandler(this.System_Btn_Click);
            this.System_Btn.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.System_Btn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            this.System_Btn.Move += new System.EventHandler(this.System_Btn_Move);
            // 
            // System_ContextMenuStrip
            // 
            this.System_ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.System_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFirmwareWrite,
            this.tsmiRunModel,
            this.地面站配置ToolStripMenuItem,
            this.communication_ToolStripMenuItem,
            this.MapSet_ToolStripMenuItem,
            this.ManyPlan_ToolStripMenuItem,
            this.ID_ToolStripMenuItem,
            this.串口输入ToolStripMenuItem});
            this.System_ContextMenuStrip.Name = "contextMenuStrip1";
            this.System_ContextMenuStrip.Size = new System.Drawing.Size(137, 180);
            // 
            // tsmiFirmwareWrite
            // 
            this.tsmiFirmwareWrite.Name = "tsmiFirmwareWrite";
            this.tsmiFirmwareWrite.Size = new System.Drawing.Size(136, 22);
            this.tsmiFirmwareWrite.Text = "固件写入";
            this.tsmiFirmwareWrite.Visible = false;
            this.tsmiFirmwareWrite.Click += new System.EventHandler(this.tsmiFirmwareWrite_Click);
            // 
            // tsmiRunModel
            // 
            this.tsmiRunModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试ToolStripMenuItem,
            this.仿真ToolStripMenuItem,
            this.飞行ToolStripMenuItem});
            this.tsmiRunModel.Name = "tsmiRunModel";
            this.tsmiRunModel.Size = new System.Drawing.Size(136, 22);
            this.tsmiRunModel.Text = "运行模式";
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Checked = true;
            this.测试ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Visible = false;
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItem_Click);
            // 
            // 仿真ToolStripMenuItem
            // 
            this.仿真ToolStripMenuItem.Name = "仿真ToolStripMenuItem";
            this.仿真ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.仿真ToolStripMenuItem.Text = "仿真";
            this.仿真ToolStripMenuItem.Click += new System.EventHandler(this.仿真ToolStripMenuItem_Click);
            // 
            // 飞行ToolStripMenuItem
            // 
            this.飞行ToolStripMenuItem.Name = "飞行ToolStripMenuItem";
            this.飞行ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.飞行ToolStripMenuItem.Text = "飞行";
            this.飞行ToolStripMenuItem.Visible = false;
            // 
            // 地面站配置ToolStripMenuItem
            // 
            this.地面站配置ToolStripMenuItem.Name = "地面站配置ToolStripMenuItem";
            this.地面站配置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.地面站配置ToolStripMenuItem.Text = "地面站配置";
            this.地面站配置ToolStripMenuItem.Visible = false;
            this.地面站配置ToolStripMenuItem.Click += new System.EventHandler(this.地面站配置ToolStripMenuItem_Click);
            // 
            // communication_ToolStripMenuItem
            // 
            this.communication_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenConneciton_ToolStripMenuItem,
            this.CloseConnection_ToolStripMenuItem});
            this.communication_ToolStripMenuItem.Name = "communication_ToolStripMenuItem";
            this.communication_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.communication_ToolStripMenuItem.Text = "通讯设置";
            // 
            // OpenConneciton_ToolStripMenuItem
            // 
            this.OpenConneciton_ToolStripMenuItem.Name = "OpenConneciton_ToolStripMenuItem";
            this.OpenConneciton_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.OpenConneciton_ToolStripMenuItem.Text = "打开";
            this.OpenConneciton_ToolStripMenuItem.Click += new System.EventHandler(this.OpenConneciton_ToolStripMenuItem_Click);
            // 
            // CloseConnection_ToolStripMenuItem
            // 
            this.CloseConnection_ToolStripMenuItem.Name = "CloseConnection_ToolStripMenuItem";
            this.CloseConnection_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.CloseConnection_ToolStripMenuItem.Text = "关闭";
            this.CloseConnection_ToolStripMenuItem.Click += new System.EventHandler(this.CloseConnection_ToolStripMenuItem_Click);
            // 
            // MapSet_ToolStripMenuItem
            // 
            this.MapSet_ToolStripMenuItem.Name = "MapSet_ToolStripMenuItem";
            this.MapSet_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.MapSet_ToolStripMenuItem.Text = "地图设置";
            this.MapSet_ToolStripMenuItem.Visible = false;
            this.MapSet_ToolStripMenuItem.Click += new System.EventHandler(this.MapSet_ToolStripMenuItem_Click);
            // 
            // ManyPlan_ToolStripMenuItem
            // 
            this.ManyPlan_ToolStripMenuItem.Name = "ManyPlan_ToolStripMenuItem";
            this.ManyPlan_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ManyPlan_ToolStripMenuItem.Text = "多机设置";
            this.ManyPlan_ToolStripMenuItem.Visible = false;
            this.ManyPlan_ToolStripMenuItem.Click += new System.EventHandler(this.ManyPlan_ToolStripMenuItem_Click);
            // 
            // ID_ToolStripMenuItem
            // 
            this.ID_ToolStripMenuItem.Name = "ID_ToolStripMenuItem";
            this.ID_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ID_ToolStripMenuItem.Text = "编号设置";
            this.ID_ToolStripMenuItem.Visible = false;
            this.ID_ToolStripMenuItem.Click += new System.EventHandler(this.ID_ToolStripMenuItem_Click);
            // 
            // 串口输入ToolStripMenuItem
            // 
            this.串口输入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem});
            this.串口输入ToolStripMenuItem.Name = "串口输入ToolStripMenuItem";
            this.串口输入ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.串口输入ToolStripMenuItem.Text = "串口输入";
            this.串口输入ToolStripMenuItem.Visible = false;
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // sBtnComm
            // 
            this.sBtnComm.BackColor = System.Drawing.Color.Transparent;
            this.sBtnComm.ContextMenuStrip = this.contextMenuStrip5;
            this.sBtnComm.DropDownButton = true;
            this.sBtnComm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sBtnComm.FlatAppearance.BorderSize = 0;
            this.sBtnComm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sBtnComm.Font = new System.Drawing.Font("宋体", 11F);
            this.sBtnComm.Location = new System.Drawing.Point(89, 3);
            this.sBtnComm.Name = "sBtnComm";
            this.sBtnComm.Size = new System.Drawing.Size(80, 41);
            this.sBtnComm.TabIndex = 2;
            this.sBtnComm.TabStop = false;
            this.sBtnComm.Text = "视图设置";
            this.sBtnComm.UseVisualStyleBackColor = false;
            this.sBtnComm.Click += new System.EventHandler(this.sBtnComm_Click);
            this.sBtnComm.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.sBtnComm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.map_ToolStripMenuItem,
            this.headstatus_ToolStripMenuItem,
            this.state_ToolStripMenuItem,
            this.ins_ToolStripMenuItem,
            this.微波源ToolStripMenuItem,
            this.干扰机ToolStripMenuItem,
            this.设定监测ToolStripMenuItem,
            this.多机数据ToolStripMenuItem,
            this.手动指令ToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(125, 224);
            // 
            // map_ToolStripMenuItem
            // 
            this.map_ToolStripMenuItem.Checked = true;
            this.map_ToolStripMenuItem.CheckOnClick = true;
            this.map_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.map_ToolStripMenuItem.Name = "map_ToolStripMenuItem";
            this.map_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.map_ToolStripMenuItem.Text = "地图区";
            this.map_ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.map_ToolStripMenuItem_CheckStateChanged);
            // 
            // headstatus_ToolStripMenuItem
            // 
            this.headstatus_ToolStripMenuItem.Checked = true;
            this.headstatus_ToolStripMenuItem.CheckOnClick = true;
            this.headstatus_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headstatus_ToolStripMenuItem.Name = "headstatus_ToolStripMenuItem";
            this.headstatus_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.headstatus_ToolStripMenuItem.Text = "头显区";
            this.headstatus_ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.headstatus_ToolStripMenuItem_CheckedChanged);
            // 
            // state_ToolStripMenuItem
            // 
            this.state_ToolStripMenuItem.Checked = true;
            this.state_ToolStripMenuItem.CheckOnClick = true;
            this.state_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.state_ToolStripMenuItem.Name = "state_ToolStripMenuItem";
            this.state_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.state_ToolStripMenuItem.Text = "状态区";
            this.state_ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.state_ToolStripMenuItem_CheckStateChanged);
            // 
            // ins_ToolStripMenuItem
            // 
            this.ins_ToolStripMenuItem.Checked = true;
            this.ins_ToolStripMenuItem.CheckOnClick = true;
            this.ins_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ins_ToolStripMenuItem.Name = "ins_ToolStripMenuItem";
            this.ins_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ins_ToolStripMenuItem.Text = "指令区";
            this.ins_ToolStripMenuItem.Visible = false;
            this.ins_ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.ins_ToolStripMenuItem_CheckStateChanged);
            // 
            // 微波源ToolStripMenuItem
            // 
            this.微波源ToolStripMenuItem.CheckOnClick = true;
            this.微波源ToolStripMenuItem.Name = "微波源ToolStripMenuItem";
            this.微波源ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.微波源ToolStripMenuItem.Text = "微波源";
            this.微波源ToolStripMenuItem.Visible = false;
            this.微波源ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.微波源ToolStripMenuItem_CheckStateChanged);
            // 
            // 干扰机ToolStripMenuItem
            // 
            this.干扰机ToolStripMenuItem.CheckOnClick = true;
            this.干扰机ToolStripMenuItem.Name = "干扰机ToolStripMenuItem";
            this.干扰机ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.干扰机ToolStripMenuItem.Text = "干扰机";
            this.干扰机ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.干扰机ToolStripMenuItem_CheckStateChanged);
            // 
            // 设定监测ToolStripMenuItem
            // 
            this.设定监测ToolStripMenuItem.CheckOnClick = true;
            this.设定监测ToolStripMenuItem.Name = "设定监测ToolStripMenuItem";
            this.设定监测ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设定监测ToolStripMenuItem.Text = "设定监测";
            this.设定监测ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.设定监测ToolStripMenuItem_CheckStateChanged);
            // 
            // 多机数据ToolStripMenuItem
            // 
            this.多机数据ToolStripMenuItem.CheckOnClick = true;
            this.多机数据ToolStripMenuItem.Name = "多机数据ToolStripMenuItem";
            this.多机数据ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.多机数据ToolStripMenuItem.Text = "多机数据";
            this.多机数据ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.多机数据ToolStripMenuItem_CheckStateChanged);
            this.多机数据ToolStripMenuItem.Click += new System.EventHandler(this.多机数据ToolStripMenuItem_Click);
            // 
            // 手动指令ToolStripMenuItem
            // 
            this.手动指令ToolStripMenuItem.CheckOnClick = true;
            this.手动指令ToolStripMenuItem.Name = "手动指令ToolStripMenuItem";
            this.手动指令ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.手动指令ToolStripMenuItem.Text = "手动指令";
            this.手动指令ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.手动指令ToolStripMenuItem_CheckStateChanged);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.CheckOnClick = true;
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dataToolStripMenuItem.Text = "数据表格";
            this.dataToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem5_CheckStateChanged);
            // 
            // sBtnWindow
            // 
            this.sBtnWindow.ContextMenuStrip = this.contextMenuStrip3;
            this.sBtnWindow.DropDownButton = true;
            this.sBtnWindow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sBtnWindow.FlatAppearance.BorderSize = 0;
            this.sBtnWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sBtnWindow.Font = new System.Drawing.Font("宋体", 11F);
            this.sBtnWindow.Location = new System.Drawing.Point(175, 3);
            this.sBtnWindow.Name = "sBtnWindow";
            this.sBtnWindow.Size = new System.Drawing.Size(80, 41);
            this.sBtnWindow.TabIndex = 6;
            this.sBtnWindow.TabStop = false;
            this.sBtnWindow.Text = "存储管理";
            this.sBtnWindow.UseVisualStyleBackColor = true;
            this.sBtnWindow.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.sBtnWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataReacorSet_ToolStripMenuItem,
            this.DataReplay_ToolStripMenuItem,
            this.dataCheck_toolStripMenuItem,
            this.dataList_toolStripMenuItem,
            this.command_historyMenuItem,
            this.数据导出ToolStripMenuItem});
            this.contextMenuStrip3.Name = "cmsSetting";
            this.contextMenuStrip3.Size = new System.Drawing.Size(149, 136);
            // 
            // dataReacorSet_ToolStripMenuItem
            // 
            this.dataReacorSet_ToolStripMenuItem.Name = "dataReacorSet_ToolStripMenuItem";
            this.dataReacorSet_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.dataReacorSet_ToolStripMenuItem.Text = "数据记录设置";
            this.dataReacorSet_ToolStripMenuItem.Visible = false;
            this.dataReacorSet_ToolStripMenuItem.Click += new System.EventHandler(this.dataReacorSet_ToolStripMenuItem_Click);
            // 
            // DataReplay_ToolStripMenuItem
            // 
            this.DataReplay_ToolStripMenuItem.Name = "DataReplay_ToolStripMenuItem";
            this.DataReplay_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DataReplay_ToolStripMenuItem.Text = "数据回放";
            this.DataReplay_ToolStripMenuItem.Click += new System.EventHandler(this.DataReplay_ToolStripMenuItem_Click);
            // 
            // dataCheck_toolStripMenuItem
            // 
            this.dataCheck_toolStripMenuItem.Name = "dataCheck_toolStripMenuItem";
            this.dataCheck_toolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.dataCheck_toolStripMenuItem.Text = "数据监测";
            this.dataCheck_toolStripMenuItem.Visible = false;
            this.dataCheck_toolStripMenuItem.Click += new System.EventHandler(this.dataCheck_toolStripMenuItem_Click);
            // 
            // dataList_toolStripMenuItem
            // 
            this.dataList_toolStripMenuItem.Name = "dataList_toolStripMenuItem";
            this.dataList_toolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.dataList_toolStripMenuItem.Text = "数据列表";
            this.dataList_toolStripMenuItem.Visible = false;
            this.dataList_toolStripMenuItem.Click += new System.EventHandler(this.dataList_toolStripMenuItem_Click);
            // 
            // command_historyMenuItem
            // 
            this.command_historyMenuItem.Name = "command_historyMenuItem";
            this.command_historyMenuItem.Size = new System.Drawing.Size(148, 22);
            this.command_historyMenuItem.Text = "指令历史";
            this.command_historyMenuItem.Visible = false;
            this.command_historyMenuItem.Click += new System.EventHandler(this.command_historyMenuItem_Click);
            // 
            // 数据导出ToolStripMenuItem
            // 
            this.数据导出ToolStripMenuItem.Name = "数据导出ToolStripMenuItem";
            this.数据导出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据导出ToolStripMenuItem.Text = "数据导出";
            this.数据导出ToolStripMenuItem.Visible = false;
            this.数据导出ToolStripMenuItem.Click += new System.EventHandler(this.数据导出ToolStripMenuItem_Click);
            // 
            // splitButton1
            // 
            this.splitButton1.ContextMenuStrip = this.contextMenuStrip2;
            this.splitButton1.DropDownButton = true;
            this.splitButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitButton1.FlatAppearance.BorderSize = 0;
            this.splitButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitButton1.Font = new System.Drawing.Font("宋体", 11F);
            this.splitButton1.Location = new System.Drawing.Point(261, 3);
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Size = new System.Drawing.Size(80, 41);
            this.splitButton1.TabIndex = 7;
            this.splitButton1.TabStop = false;
            this.splitButton1.Text = "内场测试";
            this.splitButton1.UseVisualStyleBackColor = true;
            this.splitButton1.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.splitButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensor_toolStripMenuItem,
            this.config_toolStripMenuItem,
            this.data_manageMenuItem,
            this.commond_toolStripMenuItem,
            this.toolStripMenuItem2,
            this.遥测带宽设置ToolStripMenuItem,
            this.归航模式设置ToolStripMenuItem,
            this.干扰机指令设置ToolStripMenuItem,
            this.设置飞行虚拟点ToolStripMenuItem,
            this.配置靶机ID表ToolStripMenuItem});
            this.contextMenuStrip2.Name = "cmsSetting";
            this.contextMenuStrip2.Size = new System.Drawing.Size(161, 224);
            // 
            // sensor_toolStripMenuItem
            // 
            this.sensor_toolStripMenuItem.Name = "sensor_toolStripMenuItem";
            this.sensor_toolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sensor_toolStripMenuItem.Text = "传感器校准";
            this.sensor_toolStripMenuItem.Visible = false;
            this.sensor_toolStripMenuItem.Click += new System.EventHandler(this.sensor_toolStripMenuItem_Click);
            // 
            // config_toolStripMenuItem
            // 
            this.config_toolStripMenuItem.Name = "config_toolStripMenuItem";
            this.config_toolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.config_toolStripMenuItem.Text = "舵面参数配置";
            this.config_toolStripMenuItem.Click += new System.EventHandler(this.config_toolStripMenuItem_Click);
            // 
            // data_manageMenuItem
            // 
            this.data_manageMenuItem.Name = "data_manageMenuItem";
            this.data_manageMenuItem.Size = new System.Drawing.Size(160, 22);
            this.data_manageMenuItem.Text = "飞机重心配平";
            this.data_manageMenuItem.Click += new System.EventHandler(this.data_manageMenuItem_Click);
            // 
            // commond_toolStripMenuItem
            // 
            this.commond_toolStripMenuItem.Name = "commond_toolStripMenuItem";
            this.commond_toolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.commond_toolStripMenuItem.Text = "空域参数管理";
            this.commond_toolStripMenuItem.Visible = false;
            this.commond_toolStripMenuItem.Click += new System.EventHandler(this.commond_toolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "舵机配置";
            this.toolStripMenuItem2.Visible = false;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 遥测带宽设置ToolStripMenuItem
            // 
            this.遥测带宽设置ToolStripMenuItem.Name = "遥测带宽设置ToolStripMenuItem";
            this.遥测带宽设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.遥测带宽设置ToolStripMenuItem.Text = "遥测带宽设置";
            this.遥测带宽设置ToolStripMenuItem.Click += new System.EventHandler(this.遥测带宽设置ToolStripMenuItem_Click);
            // 
            // 归航模式设置ToolStripMenuItem
            // 
            this.归航模式设置ToolStripMenuItem.Name = "归航模式设置ToolStripMenuItem";
            this.归航模式设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.归航模式设置ToolStripMenuItem.Text = "归航模式设置";
            this.归航模式设置ToolStripMenuItem.Visible = false;
            this.归航模式设置ToolStripMenuItem.Click += new System.EventHandler(this.归航模式设置ToolStripMenuItem_Click);
            // 
            // 干扰机指令设置ToolStripMenuItem
            // 
            this.干扰机指令设置ToolStripMenuItem.Name = "干扰机指令设置ToolStripMenuItem";
            this.干扰机指令设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.干扰机指令设置ToolStripMenuItem.Text = "配置靶机ID";
            this.干扰机指令设置ToolStripMenuItem.Click += new System.EventHandler(this.干扰机指令设置ToolStripMenuItem_Click);
            // 
            // 设置飞行虚拟点ToolStripMenuItem
            // 
            this.设置飞行虚拟点ToolStripMenuItem.Name = "设置飞行虚拟点ToolStripMenuItem";
            this.设置飞行虚拟点ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置飞行虚拟点ToolStripMenuItem.Text = "设置虚拟舰位置";
            this.设置飞行虚拟点ToolStripMenuItem.Click += new System.EventHandler(this.设置飞行虚拟点ToolStripMenuItem_Click);
            // 
            // 配置靶机ID表ToolStripMenuItem
            // 
            this.配置靶机ID表ToolStripMenuItem.Name = "配置靶机ID表ToolStripMenuItem";
            this.配置靶机ID表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.配置靶机ID表ToolStripMenuItem.Text = "配置靶机ID表";
            this.配置靶机ID表ToolStripMenuItem.Click += new System.EventHandler(this.配置靶机ID表ToolStripMenuItem_Click);
            // 
            // sBtnWaypoints
            // 
            this.sBtnWaypoints.ContextMenuStrip = this.cmsWps;
            this.sBtnWaypoints.DropDownButton = true;
            this.sBtnWaypoints.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sBtnWaypoints.FlatAppearance.BorderSize = 0;
            this.sBtnWaypoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sBtnWaypoints.Font = new System.Drawing.Font("宋体", 11F);
            this.sBtnWaypoints.Location = new System.Drawing.Point(347, 3);
            this.sBtnWaypoints.Name = "sBtnWaypoints";
            this.sBtnWaypoints.Size = new System.Drawing.Size(80, 41);
            this.sBtnWaypoints.TabIndex = 5;
            this.sBtnWaypoints.TabStop = false;
            this.sBtnWaypoints.Text = "外场试验";
            this.sBtnWaypoints.UseVisualStyleBackColor = true;
            // 
            // cmsWps
            // 
            this.cmsWps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsWps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWpsPlaner,
            this.timsLoadWps,
            this.timsUploadWps,
            this.归航模式ToolStripMenuItem,
            this.timsShowWps,
            this.timsClearWps,
            this.timsClearPlanWps,
            this.toolStripMenuItem1,
            this.空域参数ToolStripMenuItem,
            this.航线参数ToolStripMenuItem,
            this.电子检查单ToolStripMenuItem});
            this.cmsWps.Name = "cmsWps";
            this.cmsWps.Size = new System.Drawing.Size(149, 246);
            // 
            // tsmiWpsPlaner
            // 
            this.tsmiWpsPlaner.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WpsPlaner_isShow});
            this.tsmiWpsPlaner.Name = "tsmiWpsPlaner";
            this.tsmiWpsPlaner.Size = new System.Drawing.Size(148, 22);
            this.tsmiWpsPlaner.Text = "航线规划";
            this.tsmiWpsPlaner.Visible = false;
            // 
            // WpsPlaner_isShow
            // 
            this.WpsPlaner_isShow.Name = "WpsPlaner_isShow";
            this.WpsPlaner_isShow.Size = new System.Drawing.Size(100, 22);
            this.WpsPlaner_isShow.Text = "显示";
            // 
            // timsLoadWps
            // 
            this.timsLoadWps.Name = "timsLoadWps";
            this.timsLoadWps.Size = new System.Drawing.Size(148, 22);
            this.timsLoadWps.Text = "IMU自检";
            this.timsLoadWps.Click += new System.EventHandler(this.timsLoadWps_Click);
            // 
            // timsUploadWps
            // 
            this.timsUploadWps.Name = "timsUploadWps";
            this.timsUploadWps.Size = new System.Drawing.Size(148, 22);
            this.timsUploadWps.Text = "高度校准";
            this.timsUploadWps.Click += new System.EventHandler(this.timsUploadWps_Click);
            // 
            // 归航模式ToolStripMenuItem
            // 
            this.归航模式ToolStripMenuItem.Name = "归航模式ToolStripMenuItem";
            this.归航模式ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.归航模式ToolStripMenuItem.Text = "归航模式";
            this.归航模式ToolStripMenuItem.Click += new System.EventHandler(this.归航模式ToolStripMenuItem_Click);
            // 
            // timsShowWps
            // 
            this.timsShowWps.Name = "timsShowWps";
            this.timsShowWps.Size = new System.Drawing.Size(148, 22);
            this.timsShowWps.Text = "配置参数";
            this.timsShowWps.Click += new System.EventHandler(this.timsShowWps_Click);
            // 
            // timsClearWps
            // 
            this.timsClearWps.Name = "timsClearWps";
            this.timsClearWps.Size = new System.Drawing.Size(148, 22);
            this.timsClearWps.Text = "编队控制";
            this.timsClearWps.Click += new System.EventHandler(this.timsClearWps_Click);
            // 
            // timsClearPlanWps
            // 
            this.timsClearPlanWps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手动模式ToolStripMenuItem,
            this.定速模式ToolStripMenuItem,
            this.编队模式ToolStripMenuItem});
            this.timsClearPlanWps.Name = "timsClearPlanWps";
            this.timsClearPlanWps.Size = new System.Drawing.Size(148, 22);
            this.timsClearPlanWps.Text = "油门控制模式";
            // 
            // 手动模式ToolStripMenuItem
            // 
            this.手动模式ToolStripMenuItem.Name = "手动模式ToolStripMenuItem";
            this.手动模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.手动模式ToolStripMenuItem.Text = "遥调模式";
            this.手动模式ToolStripMenuItem.Click += new System.EventHandler(this.手动模式ToolStripMenuItem_Click);
            // 
            // 定速模式ToolStripMenuItem
            // 
            this.定速模式ToolStripMenuItem.Name = "定速模式ToolStripMenuItem";
            this.定速模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.定速模式ToolStripMenuItem.Text = "定速模式";
            this.定速模式ToolStripMenuItem.Click += new System.EventHandler(this.定速模式ToolStripMenuItem_Click);
            // 
            // 编队模式ToolStripMenuItem
            // 
            this.编队模式ToolStripMenuItem.Name = "编队模式ToolStripMenuItem";
            this.编队模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编队模式ToolStripMenuItem.Text = "编队模式";
            this.编队模式ToolStripMenuItem.Click += new System.EventHandler(this.编队模式ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "保存航线规划";
            this.toolStripMenuItem1.Visible = false;
            // 
            // 空域参数ToolStripMenuItem
            // 
            this.空域参数ToolStripMenuItem.Name = "空域参数ToolStripMenuItem";
            this.空域参数ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.空域参数ToolStripMenuItem.Text = "空域参数";
            this.空域参数ToolStripMenuItem.Click += new System.EventHandler(this.commond_toolStripMenuItem_Click);
            // 
            // 航线参数ToolStripMenuItem
            // 
            this.航线参数ToolStripMenuItem.Name = "航线参数ToolStripMenuItem";
            this.航线参数ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.航线参数ToolStripMenuItem.Text = "航线参数";
            this.航线参数ToolStripMenuItem.Click += new System.EventHandler(this.航线参数ToolStripMenuItem_Click);
            // 
            // 电子检查单ToolStripMenuItem
            // 
            this.电子检查单ToolStripMenuItem.Name = "电子检查单ToolStripMenuItem";
            this.电子检查单ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.电子检查单ToolStripMenuItem.Text = "电子检查单";
            this.电子检查单ToolStripMenuItem.Click += new System.EventHandler(this.电子检查单ToolStripMenuItem_Click);
            // 
            // splitButton2
            // 
            this.splitButton2.ContextMenuStrip = this.cmsWindow;
            this.splitButton2.DropDownButton = true;
            this.splitButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitButton2.FlatAppearance.BorderSize = 0;
            this.splitButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitButton2.Font = new System.Drawing.Font("宋体", 11F);
            this.splitButton2.Location = new System.Drawing.Point(433, 3);
            this.splitButton2.Name = "splitButton2";
            this.splitButton2.Size = new System.Drawing.Size(80, 41);
            this.splitButton2.TabIndex = 8;
            this.splitButton2.TabStop = false;
            this.splitButton2.Text = "实时数据";
            this.splitButton2.UseVisualStyleBackColor = true;
            this.splitButton2.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.splitButton2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            // 
            // cmsWindow
            // 
            this.cmsWindow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemSelfCheck_ToolStripMenuItem,
            this.engineCheckMenuItem,
            this.TestToolStripMenuItem});
            this.cmsWindow.Name = "cmsWindow";
            this.cmsWindow.Size = new System.Drawing.Size(137, 70);
            // 
            // systemSelfCheck_ToolStripMenuItem
            // 
            this.systemSelfCheck_ToolStripMenuItem.Name = "systemSelfCheck_ToolStripMenuItem";
            this.systemSelfCheck_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.systemSelfCheck_ToolStripMenuItem.Text = "数据监测";
            this.systemSelfCheck_ToolStripMenuItem.Click += new System.EventHandler(this.systemSelfCheck_ToolStripMenuItem_Click);
            // 
            // engineCheckMenuItem
            // 
            this.engineCheckMenuItem.Name = "engineCheckMenuItem";
            this.engineCheckMenuItem.Size = new System.Drawing.Size(136, 22);
            this.engineCheckMenuItem.Text = "发动机测试";
            this.engineCheckMenuItem.Visible = false;
            this.engineCheckMenuItem.Click += new System.EventHandler(this.engineCheckMenuItem_Click);
            // 
            // TestToolStripMenuItem
            // 
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.TestToolStripMenuItem.Text = "飞前检查";
            this.TestToolStripMenuItem.Visible = false;
            this.TestToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // splitButton3
            // 
            this.splitButton3.ContextMenuStrip = this.contextMenuStrip4;
            this.splitButton3.DropDownButton = true;
            this.splitButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitButton3.FlatAppearance.BorderSize = 0;
            this.splitButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitButton3.Font = new System.Drawing.Font("宋体", 11F);
            this.splitButton3.Location = new System.Drawing.Point(519, 3);
            this.splitButton3.Name = "splitButton3";
            this.splitButton3.Size = new System.Drawing.Size(80, 41);
            this.splitButton3.TabIndex = 9;
            this.splitButton3.TabStop = false;
            this.splitButton3.Text = "窗口";
            this.splitButton3.UseVisualStyleBackColor = true;
            this.splitButton3.Visible = false;
            this.splitButton3.MouseHover += new System.EventHandler(this.System_Btn_MouseHover);
            this.splitButton3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.System_Btn_MouseMove);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveWindow_ToolStripMenuItem,
            this.OpenWindow_ToolStripMenuItem});
            this.contextMenuStrip4.Name = "cmsSetting";
            this.contextMenuStrip4.Size = new System.Drawing.Size(173, 48);
            // 
            // SaveWindow_ToolStripMenuItem
            // 
            this.SaveWindow_ToolStripMenuItem.Name = "SaveWindow_ToolStripMenuItem";
            this.SaveWindow_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SaveWindow_ToolStripMenuItem.Text = "保存当前窗口布局";
            this.SaveWindow_ToolStripMenuItem.Click += new System.EventHandler(this.SaveWindow_ToolStripMenuItem_Click);
            // 
            // OpenWindow_ToolStripMenuItem
            // 
            this.OpenWindow_ToolStripMenuItem.Name = "OpenWindow_ToolStripMenuItem";
            this.OpenWindow_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.OpenWindow_ToolStripMenuItem.Text = "打开保存窗口布局";
            this.OpenWindow_ToolStripMenuItem.Click += new System.EventHandler(this.OpenWindow_ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.AssociatedSplitter = null;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Bold);
            this.panel2.CaptionHeight = 27;
            this.panel2.Controls.Add(this.utctime);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.satelite);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.youmenmode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.targetlabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.panel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.panel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Image = null;
            this.panel2.Location = new System.Drawing.Point(567, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel2.Name = "panel2";
            this.panel2.ShowCaptionbar = false;
            this.panel2.Size = new System.Drawing.Size(959, 47);
            this.panel2.TabIndex = 11;
            this.panel2.ToolTipTextCloseIcon = null;
            this.panel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // utctime
            // 
            this.utctime.AutoSize = true;
            this.utctime.Font = new System.Drawing.Font("宋体", 16F);
            this.utctime.ForeColor = System.Drawing.Color.Red;
            this.utctime.Location = new System.Drawing.Point(127, 10);
            this.utctime.Name = "utctime";
            this.utctime.Size = new System.Drawing.Size(98, 22);
            this.utctime.TabIndex = 43;
            this.utctime.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(63, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "时间：";
            // 
            // satelite
            // 
            this.satelite.AutoSize = true;
            this.satelite.Font = new System.Drawing.Font("宋体", 15F);
            this.satelite.ForeColor = System.Drawing.Color.Red;
            this.satelite.Location = new System.Drawing.Point(589, 13);
            this.satelite.Name = "satelite";
            this.satelite.Size = new System.Drawing.Size(19, 20);
            this.satelite.TabIndex = 33;
            this.satelite.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(533, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "星数：";
            // 
            // youmenmode
            // 
            this.youmenmode.AutoSize = true;
            this.youmenmode.Font = new System.Drawing.Font("宋体", 15F);
            this.youmenmode.ForeColor = System.Drawing.Color.Red;
            this.youmenmode.Location = new System.Drawing.Point(485, 13);
            this.youmenmode.Name = "youmenmode";
            this.youmenmode.Size = new System.Drawing.Size(49, 20);
            this.youmenmode.TabIndex = 31;
            this.youmenmode.Text = "遥调";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(390, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "油门模式：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(851, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(76, 41);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主电源";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(10, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 20);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gps2);
            this.groupBox1.Controls.Add(this.gps1);
            this.groupBox1.Location = new System.Drawing.Point(664, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 44);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "状态指示";
            // 
            // gps2
            // 
            this.gps2.BackColor = System.Drawing.Color.Red;
            this.gps2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gps2.Font = new System.Drawing.Font("宋体", 13F);
            this.gps2.Location = new System.Drawing.Point(96, 16);
            this.gps2.Name = "gps2";
            this.gps2.ReadOnly = true;
            this.gps2.Size = new System.Drawing.Size(51, 20);
            this.gps2.TabIndex = 23;
            this.gps2.Text = "NAV";
            this.gps2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gps1
            // 
            this.gps1.BackColor = System.Drawing.Color.Red;
            this.gps1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gps1.Font = new System.Drawing.Font("宋体", 13F);
            this.gps1.Location = new System.Drawing.Point(23, 16);
            this.gps1.Name = "gps1";
            this.gps1.ReadOnly = true;
            this.gps1.Size = new System.Drawing.Size(51, 20);
            this.gps1.TabIndex = 22;
            this.gps1.Text = "GPS";
            this.gps1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // targetlabel
            // 
            this.targetlabel.AutoSize = true;
            this.targetlabel.Font = new System.Drawing.Font("宋体", 16F);
            this.targetlabel.ForeColor = System.Drawing.Color.Red;
            this.targetlabel.Location = new System.Drawing.Point(344, 11);
            this.targetlabel.Name = "targetlabel";
            this.targetlabel.Size = new System.Drawing.Size(21, 22);
            this.targetlabel.TabIndex = 4;
            this.targetlabel.Text = "0";
            this.targetlabel.TextChanged += new System.EventHandler(this.targetlabel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(233, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "控制靶机ID：";
            // 
            // cmsSetting
            // 
            this.cmsSetting.Name = "cmsSetting";
            this.cmsSetting.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(153, 24);
            this.toolStripMenuItem3.Text = "遥控器校准";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(153, 24);
            this.toolStripMenuItem4.Text = "驱动校准";
            // 
            // steering_engineStripMenuItem
            // 
            this.steering_engineStripMenuItem.Name = "steering_engineStripMenuItem";
            this.steering_engineStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.steering_engineStripMenuItem.Text = "舵面校准";
            this.steering_engineStripMenuItem.Click += new System.EventHandler(this.steering_engineStripMenuItemClick);
            // 
            // erect_configToolMenuItem
            // 
            this.erect_configToolMenuItem.Name = "erect_configToolMenuItem";
            this.erect_configToolMenuItem.Size = new System.Drawing.Size(153, 24);
            this.erect_configToolMenuItem.Text = "自驾仪安装与配置";
            this.erect_configToolMenuItem.Click += new System.EventHandler(this.erect_configToolMenuItem_Click);
            // 
            // telemetry_bandwidthMenuItem
            // 
            this.telemetry_bandwidthMenuItem.Name = "telemetry_bandwidthMenuItem";
            this.telemetry_bandwidthMenuItem.Size = new System.Drawing.Size(153, 24);
            this.telemetry_bandwidthMenuItem.Text = "遥测带宽";
            this.telemetry_bandwidthMenuItem.Click += new System.EventHandler(this.telemetry_bandwidthMenuItem_Click);
            // 
            // cmsComm
            // 
            this.cmsComm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsComm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCommType,
            this.tsmiSerialSet,
            this.tsmiOpenSerial,
            this.tsmiCloseSerial,
            this.tsmiTCPSet,
            this.tsmiOpenTCP,
            this.tsmiCloseTCP});
            this.cmsComm.Name = "cmsComm";
            this.cmsComm.Size = new System.Drawing.Size(125, 158);
            this.cmsComm.MouseHover += new System.EventHandler(this.cmsComm_MouseHover);
            // 
            // tsmiCommType
            // 
            this.tsmiCommType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortComm,
            this.tcpComm});
            this.tsmiCommType.Name = "tsmiCommType";
            this.tsmiCommType.Size = new System.Drawing.Size(124, 22);
            this.tsmiCommType.Text = "通讯方式";
            // 
            // serialPortComm
            // 
            this.serialPortComm.Checked = true;
            this.serialPortComm.CheckOnClick = true;
            this.serialPortComm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serialPortComm.Name = "serialPortComm";
            this.serialPortComm.Size = new System.Drawing.Size(124, 22);
            this.serialPortComm.Text = "串口通讯";
            this.serialPortComm.CheckedChanged += new System.EventHandler(this.serialPortComm_CheckedChanged);
            // 
            // tcpComm
            // 
            this.tcpComm.CheckOnClick = true;
            this.tcpComm.Name = "tcpComm";
            this.tcpComm.Size = new System.Drawing.Size(124, 22);
            this.tcpComm.Text = "网络通讯";
            this.tcpComm.CheckedChanged += new System.EventHandler(this.tcpComm_CheckedChanged);
            // 
            // tsmiSerialSet
            // 
            this.tsmiSerialSet.Name = "tsmiSerialSet";
            this.tsmiSerialSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiSerialSet.Text = "串口设置";
            // 
            // tsmiOpenSerial
            // 
            this.tsmiOpenSerial.Name = "tsmiOpenSerial";
            this.tsmiOpenSerial.Size = new System.Drawing.Size(124, 22);
            this.tsmiOpenSerial.Text = "串口打开";
            // 
            // tsmiCloseSerial
            // 
            this.tsmiCloseSerial.Name = "tsmiCloseSerial";
            this.tsmiCloseSerial.Size = new System.Drawing.Size(124, 22);
            this.tsmiCloseSerial.Text = "串口关闭";
            // 
            // tsmiTCPSet
            // 
            this.tsmiTCPSet.Name = "tsmiTCPSet";
            this.tsmiTCPSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiTCPSet.Text = "TCP设置";
            // 
            // tsmiOpenTCP
            // 
            this.tsmiOpenTCP.Name = "tsmiOpenTCP";
            this.tsmiOpenTCP.Size = new System.Drawing.Size(124, 22);
            this.tsmiOpenTCP.Text = "TCP打开";
            // 
            // tsmiCloseTCP
            // 
            this.tsmiCloseTCP.Name = "tsmiCloseTCP";
            this.tsmiCloseTCP.Size = new System.Drawing.Size(124, 22);
            this.tsmiCloseTCP.Text = "TCP关闭";
            // 
            // ResetWindow_ToolStripMenuItem
            // 
            this.ResetWindow_ToolStripMenuItem.Name = "ResetWindow_ToolStripMenuItem";
            this.ResetWindow_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ResetWindow_ToolStripMenuItem.Text = "重置窗口布局";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 47);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1526, 0);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // dockMainPanel
            // 
            this.dockMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockMainPanel.DockBottomPortion = 0.2D;
            this.dockMainPanel.DockRightPortion = 0.38D;
            this.dockMainPanel.DockTopPortion = 0.6D;
            this.dockMainPanel.Location = new System.Drawing.Point(0, 47);
            this.dockMainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 3, 1);
            this.dockMainPanel.Name = "dockMainPanel";
            this.dockMainPanel.Size = new System.Drawing.Size(1526, 456);
            this.dockMainPanel.TabIndex = 1;
            this.dockMainPanel.ActiveContentChanged += new System.EventHandler(this.dockMainPanel_ActiveContentChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_angel
            // 
            this.lbl_angel.AutoSize = true;
            this.lbl_angel.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_angel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_angel.Location = new System.Drawing.Point(52, 144);
            this.lbl_angel.Name = "lbl_angel";
            this.lbl_angel.Size = new System.Drawing.Size(72, 16);
            this.lbl_angel.TabIndex = 64;
            this.lbl_angel.Text = "对舰角度";
            // 
            // lbl_homedist
            // 
            this.lbl_homedist.AutoSize = true;
            this.lbl_homedist.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_homedist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_homedist.Location = new System.Drawing.Point(52, 123);
            this.lbl_homedist.Name = "lbl_homedist";
            this.lbl_homedist.Size = new System.Drawing.Size(72, 16);
            this.lbl_homedist.TabIndex = 63;
            this.lbl_homedist.Text = "距舰距离";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(68, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 67;
            this.label6.Text = "总距离";
            // 
            // pointReview
            // 
            this.pointReview.AutoSize = true;
            this.pointReview.Font = new System.Drawing.Font("宋体", 12F);
            this.pointReview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pointReview.Location = new System.Drawing.Point(37, 164);
            this.pointReview.Name = "pointReview";
            this.pointReview.Size = new System.Drawing.Size(104, 16);
            this.pointReview.TabIndex = 70;
            this.pointReview.Text = "与前点距离：";
            this.pointReview.Visible = false;
            // 
            // coords1
            // 
            this.coords1.Alt = 0D;
            this.coords1.AltUnit = "m";
            this.coords1.Lat = 0D;
            this.coords1.Lng = 0D;
            this.coords1.Location = new System.Drawing.Point(0, 0);
            this.coords1.Name = "coords1";
            this.coords1.Size = new System.Drawing.Size(200, 21);
            this.coords1.TabIndex = 0;
            this.coords1.Vertical = false;
            // 
            // gps
            // 
            this.gps.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.gps_DataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 503);
            this.Controls.Add(this.pointReview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_angel);
            this.Controls.Add(this.lbl_homedist);
            this.Controls.Add(this.dockMainPanel);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "星网宇达地面站(多机多站2021-10-29)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MinimumSizeChanged += new System.EventHandler(this.MainForm_MinimumSizeChanged);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.System_ContextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip5.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.cmsWps.ResumeLayout(false);
            this.cmsWindow.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmsComm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Panel panel1;

        public System.Windows.Forms.BindingSource bindingSourceQuickTab;

        private System.Windows.Forms.ContextMenuStrip System_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFirmwareWrite;
        private System.Windows.Forms.ToolStripMenuItem tsmiRunModel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private SplitButton System_Btn;
        private SplitButton sBtnComm;
        //private SplitButton sBtnSetting;
        private SplitButton sBtnWaypoints;
        private SplitButton sBtnWindow;
        private System.Windows.Forms.ContextMenuStrip cmsComm;
        private System.Windows.Forms.ToolStripMenuItem tsmiCommType;
        private System.Windows.Forms.ToolStripMenuItem tsmiSerialSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiTCPSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenTCP;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseTCP;
        private System.Windows.Forms.ContextMenuStrip cmsSetting;
        private System.Windows.Forms.ContextMenuStrip cmsWps;
        private System.Windows.Forms.ToolStripMenuItem tsmiWpsPlaner;
        private System.Windows.Forms.ToolStripMenuItem timsLoadWps;
        private System.Windows.Forms.ToolStripMenuItem timsUploadWps;
        private System.Windows.Forms.ToolStripMenuItem timsShowWps;
        private System.Windows.Forms.ToolStripMenuItem timsClearWps;
        private System.Windows.Forms.ToolStripMenuItem timsClearPlanWps;
        private System.Windows.Forms.ContextMenuStrip cmsWindow;
        private System.Windows.Forms.ToolStripMenuItem systemSelfCheck_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engineCheckMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
        private System.Windows.Forms.ToolStripMenuItem serialPortComm;
        private System.Windows.Forms.ToolStripMenuItem tcpComm;
        private BSE.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仿真ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 飞行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WpsPlaner_isShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 地面站配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communication_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MapSet_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManyPlan_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataReacorSet_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataReplay_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem sensor_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telemetry_bandwidthMenuItem;
        private System.Windows.Forms.ToolStripMenuItem data_manageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem steering_engineStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erect_configToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem config_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commond_toolStripMenuItem;
        private SplitButton splitButton1;
        private SplitButton splitButton2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem dataCheck_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataList_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem command_historyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenConneciton_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseConnection_ToolStripMenuItem;
        private SplitButton splitButton3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem SaveWindow_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenWindow_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetWindow_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ID_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem map_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headstatus_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem state_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ins_ToolStripMenuItem;
        private MissionPlanner.Controls.Coords coords1;
        private System.Windows.Forms.ToolStripMenuItem 串口输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockMainPanel;
        private System.Windows.Forms.Timer timer1;
        private MissionPlanner.Comms.SerialPort gps;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 遥测带宽设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 归航模式设置ToolStripMenuItem;
        private MissionPlanner.Comms.SerialPort xinbiao;
        private System.Windows.Forms.ToolStripMenuItem 干扰机指令设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置飞行虚拟点ToolStripMenuItem;
        private System.Windows.Forms.Label lbl_angel;
        private System.Windows.Forms.Label lbl_homedist;
        public System.Windows.Forms.Label targetlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 微波源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 干扰机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多机数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        public System.Windows.Forms.Label youmenmode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox gps2;
        private System.Windows.Forms.TextBox gps1;
        private System.Windows.Forms.ToolStripMenuItem 手动模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定速模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编队模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设定监测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空域参数ToolStripMenuItem;
        public System.Windows.Forms.Label satelite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 归航模式ToolStripMenuItem;
        public System.Windows.Forms.Label utctime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem 手动指令ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 航线参数ToolStripMenuItem;
        private System.Windows.Forms.Label pointReview;
        private System.Windows.Forms.ToolStripMenuItem 电子检查单ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置靶机ID表ToolStripMenuItem;
    }
}