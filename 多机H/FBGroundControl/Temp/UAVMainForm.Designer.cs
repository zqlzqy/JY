namespace FBGroundControl
{
    partial class UAVMainForm
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnParameterSetting = new System.Windows.Forms.Button();
            this.btnPlanningCourse = new System.Windows.Forms.Button();
            this.btnFlighData = new System.Windows.Forms.Button();
            this.btnConnect = new MetroFramework.Controls.MetroButton();
            this.cboPort = new MetroFramework.Controls.MetroComboBox();
            this.cboProtocolType = new MetroFramework.Controls.MetroComboBox();
            this.TabContent = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.myGMAP1 = new MissionPlanner.Controls.myGMAP();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.labDistToAV = new System.Windows.Forms.Label();
            this.labVSNum = new System.Windows.Forms.Label();
            this.labYawNum = new System.Windows.Forms.Label();
            this.labWpDistNum = new System.Windows.Forms.Label();
            this.labGroundSeepd = new System.Windows.Forms.Label();
            this.labAltNum = new System.Windows.Forms.Label();
            this.labDistToMAV = new MetroFramework.Controls.MetroLabel();
            this.labVerticalspeed = new MetroFramework.Controls.MetroLabel();
            this.labYaw = new MetroFramework.Controls.MetroLabel();
            this.labWpDist = new MetroFramework.Controls.MetroLabel();
            this.labGroundSpeed = new MetroFramework.Controls.MetroLabel();
            this.labAlt = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceHud = new System.Windows.Forms.BindingSource(this.components);
            this.menuPanel.SuspendLayout();
            this.TabContent.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.htmlLabel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.menuPanel.Controls.Add(this.btnParameterSetting);
            this.menuPanel.Controls.Add(this.btnPlanningCourse);
            this.menuPanel.Controls.Add(this.btnFlighData);
            this.menuPanel.Controls.Add(this.btnConnect);
            this.menuPanel.Controls.Add(this.cboPort);
            this.menuPanel.Controls.Add(this.cboProtocolType);
            this.menuPanel.Location = new System.Drawing.Point(1, 62);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(216, 620);
            this.menuPanel.TabIndex = 0;
            // 
            // btnParameterSetting
            // 
            this.btnParameterSetting.FlatAppearance.BorderSize = 0;
            this.btnParameterSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParameterSetting.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnParameterSetting.Location = new System.Drawing.Point(0, 151);
            this.btnParameterSetting.Name = "btnParameterSetting";
            this.btnParameterSetting.Size = new System.Drawing.Size(216, 78);
            this.btnParameterSetting.TabIndex = 8;
            this.btnParameterSetting.Text = "参数设置";
            this.btnParameterSetting.UseVisualStyleBackColor = true;
            this.btnParameterSetting.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnPlanningCourse
            // 
            this.btnPlanningCourse.FlatAppearance.BorderSize = 0;
            this.btnPlanningCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanningCourse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPlanningCourse.Location = new System.Drawing.Point(0, 75);
            this.btnPlanningCourse.Name = "btnPlanningCourse";
            this.btnPlanningCourse.Size = new System.Drawing.Size(216, 78);
            this.btnPlanningCourse.TabIndex = 7;
            this.btnPlanningCourse.Text = "航线规划";
            this.btnPlanningCourse.UseVisualStyleBackColor = true;
            this.btnPlanningCourse.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnFlighData
            // 
            this.btnFlighData.FlatAppearance.BorderSize = 0;
            this.btnFlighData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlighData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlighData.Location = new System.Drawing.Point(0, 0);
            this.btnFlighData.Name = "btnFlighData";
            this.btnFlighData.Size = new System.Drawing.Size(216, 78);
            this.btnFlighData.TabIndex = 6;
            this.btnFlighData.Text = "飞行数据";
            this.btnFlighData.UseVisualStyleBackColor = true;
            this.btnFlighData.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(22, 573);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(147, 29);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "立刻连接";
            this.btnConnect.UseSelectable = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.ItemHeight = 23;
            this.cboPort.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
            this.cboPort.Location = new System.Drawing.Point(22, 519);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(147, 29);
            this.cboPort.TabIndex = 4;
            this.cboPort.UseSelectable = true;
            // 
            // cboProtocolType
            // 
            this.cboProtocolType.FormattingEnabled = true;
            this.cboProtocolType.ItemHeight = 23;
            this.cboProtocolType.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "COM"});
            this.cboProtocolType.Location = new System.Drawing.Point(22, 482);
            this.cboProtocolType.Name = "cboProtocolType";
            this.cboProtocolType.Size = new System.Drawing.Size(147, 29);
            this.cboProtocolType.TabIndex = 3;
            this.cboProtocolType.UseSelectable = true;
            // 
            // TabContent
            // 
            this.TabContent.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabContent.Controls.Add(this.metroTabPage1);
            this.TabContent.Controls.Add(this.metroTabPage2);
            this.TabContent.Controls.Add(this.metroTabPage3);
            this.TabContent.Location = new System.Drawing.Point(168, 37);
            this.TabContent.Multiline = true;
            this.TabContent.Name = "TabContent";
            this.TabContent.SelectedIndex = 0;
            this.TabContent.Size = new System.Drawing.Size(912, 650);
            this.TabContent.TabIndex = 1;
            this.TabContent.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TabContent.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.myGMAP1);
            this.metroTabPage1.Controls.Add(this.htmlLabel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(39, 4);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(869, 642);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "metroTabPage1";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // myGMAP1
            // 
            this.myGMAP1.Bearing = 0F;
            this.myGMAP1.CanDragMap = true;
            this.myGMAP1.EmptyTileColor = System.Drawing.Color.Gray;
            this.myGMAP1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myGMAP1.GrayScaleMode = false;
            this.myGMAP1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.myGMAP1.LevelsKeepInMemmory = 5;
            this.myGMAP1.Location = new System.Drawing.Point(9, 96);
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
            this.myGMAP1.Size = new System.Drawing.Size(876, 569);
            this.myGMAP1.TabIndex = 7;
            this.myGMAP1.Zoom = 3D;
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Controls.Add(this.labDistToAV);
            this.htmlLabel1.Controls.Add(this.labVSNum);
            this.htmlLabel1.Controls.Add(this.labYawNum);
            this.htmlLabel1.Controls.Add(this.labWpDistNum);
            this.htmlLabel1.Controls.Add(this.labGroundSeepd);
            this.htmlLabel1.Controls.Add(this.labAltNum);
            this.htmlLabel1.Controls.Add(this.labDistToMAV);
            this.htmlLabel1.Controls.Add(this.labVerticalspeed);
            this.htmlLabel1.Controls.Add(this.labYaw);
            this.htmlLabel1.Controls.Add(this.labWpDist);
            this.htmlLabel1.Controls.Add(this.labGroundSpeed);
            this.htmlLabel1.Controls.Add(this.labAlt);
            this.htmlLabel1.Location = new System.Drawing.Point(48, -7);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(870, 107);
            this.htmlLabel1.TabIndex = 2;
            this.htmlLabel1.Click += new System.EventHandler(this.htmlLabel1_Click);
            // 
            // labDistToAV
            // 
            this.labDistToAV.AutoSize = true;
            this.labDistToAV.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDistToAV.ForeColor = System.Drawing.Color.Turquoise;
            this.labDistToAV.Location = new System.Drawing.Point(677, 55);
            this.labDistToAV.Name = "labDistToAV";
            this.labDistToAV.Size = new System.Drawing.Size(37, 40);
            this.labDistToAV.TabIndex = 11;
            this.labDistToAV.Text = "0";
            // 
            // labVSNum
            // 
            this.labVSNum.AutoSize = true;
            this.labVSNum.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labVSNum.ForeColor = System.Drawing.Color.YellowGreen;
            this.labVSNum.Location = new System.Drawing.Point(531, 55);
            this.labVSNum.Name = "labVSNum";
            this.labVSNum.Size = new System.Drawing.Size(37, 40);
            this.labVSNum.TabIndex = 10;
            this.labVSNum.Text = "0";
            // 
            // labYawNum
            // 
            this.labYawNum.AutoSize = true;
            this.labYawNum.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labYawNum.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labYawNum.Location = new System.Drawing.Point(403, 55);
            this.labYawNum.Name = "labYawNum";
            this.labYawNum.Size = new System.Drawing.Size(37, 40);
            this.labYawNum.TabIndex = 9;
            this.labYawNum.Text = "0";
            // 
            // labWpDistNum
            // 
            this.labWpDistNum.AutoSize = true;
            this.labWpDistNum.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labWpDistNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labWpDistNum.Location = new System.Drawing.Point(293, 55);
            this.labWpDistNum.Name = "labWpDistNum";
            this.labWpDistNum.Size = new System.Drawing.Size(37, 40);
            this.labWpDistNum.TabIndex = 8;
            this.labWpDistNum.Text = "0";
            // 
            // labGroundSeepd
            // 
            this.labGroundSeepd.AutoSize = true;
            this.labGroundSeepd.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labGroundSeepd.ForeColor = System.Drawing.Color.Coral;
            this.labGroundSeepd.Location = new System.Drawing.Point(153, 55);
            this.labGroundSeepd.Name = "labGroundSeepd";
            this.labGroundSeepd.Size = new System.Drawing.Size(37, 40);
            this.labGroundSeepd.TabIndex = 7;
            this.labGroundSeepd.Text = "0";
            // 
            // labAltNum
            // 
            this.labAltNum.AutoSize = true;
            this.labAltNum.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAltNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labAltNum.Location = new System.Drawing.Point(27, 55);
            this.labAltNum.Name = "labAltNum";
            this.labAltNum.Size = new System.Drawing.Size(37, 40);
            this.labAltNum.TabIndex = 6;
            this.labAltNum.Text = "0";
            // 
            // labDistToMAV
            // 
            this.labDistToMAV.AutoSize = true;
            this.labDistToMAV.Location = new System.Drawing.Point(661, 14);
            this.labDistToMAV.Name = "labDistToMAV";
            this.labDistToMAV.Size = new System.Drawing.Size(70, 19);
            this.labDistToMAV.TabIndex = 5;
            this.labDistToMAV.Text = "distToMAV";
            // 
            // labVerticalspeed
            // 
            this.labVerticalspeed.AutoSize = true;
            this.labVerticalspeed.Location = new System.Drawing.Point(506, 14);
            this.labVerticalspeed.Name = "labVerticalspeed";
            this.labVerticalspeed.Size = new System.Drawing.Size(86, 19);
            this.labVerticalspeed.TabIndex = 4;
            this.labVerticalspeed.Text = "verticalspeed";
            // 
            // labYaw
            // 
            this.labYaw.AutoSize = true;
            this.labYaw.Location = new System.Drawing.Point(406, 14);
            this.labYaw.Name = "labYaw";
            this.labYaw.Size = new System.Drawing.Size(31, 19);
            this.labYaw.TabIndex = 3;
            this.labYaw.Text = "yaw";
            this.labYaw.Click += new System.EventHandler(this.labYaw_Click);
            // 
            // labWpDist
            // 
            this.labWpDist.AutoSize = true;
            this.labWpDist.Location = new System.Drawing.Point(285, 14);
            this.labWpDist.Name = "labWpDist";
            this.labWpDist.Size = new System.Drawing.Size(52, 19);
            this.labWpDist.TabIndex = 2;
            this.labWpDist.Text = "wp_dist";
            // 
            // labGroundSpeed
            // 
            this.labGroundSpeed.AutoSize = true;
            this.labGroundSpeed.Location = new System.Drawing.Point(126, 14);
            this.labGroundSpeed.Name = "labGroundSpeed";
            this.labGroundSpeed.Size = new System.Drawing.Size(89, 19);
            this.labGroundSpeed.TabIndex = 1;
            this.labGroundSpeed.Text = "groundSeepd";
            // 
            // labAlt
            // 
            this.labAlt.AutoSize = true;
            this.labAlt.Location = new System.Drawing.Point(34, 14);
            this.labAlt.Name = "labAlt";
            this.labAlt.Size = new System.Drawing.Size(23, 19);
            this.labAlt.TabIndex = 0;
            this.labAlt.Text = "alt";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLink1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(39, 4);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(869, 642);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "metroTabPage2";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(148, 200);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(75, 23);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.Text = "metroLink1";
            this.metroLink1.UseSelectable = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroTile1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(39, 4);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(869, 642);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "metroTabPage3";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(132, 106);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(75, 23);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.UseSelectable = true;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Location = new System.Drawing.Point(216, 5);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(865, 31);
            this.panelTitle.TabIndex = 2;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::FBGroundControl.Properties.Resources.关闭;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(827, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.BackgroundImage = global::FBGroundControl.Properties.Resources.应用图标_窗口面板最小化_;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(790, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(31, 30);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MistyRose;
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "云豹无人机  版本号0000";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // UAVMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 700);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.TabContent);
            this.Controls.Add(this.panelTitle);
            this.Name = "UAVMainForm";
            this.Text = "云豹无人机";
            this.menuPanel.ResumeLayout(false);
            this.TabContent.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.htmlLabel1.ResumeLayout(false);
            this.htmlLabel1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private MetroFramework.Controls.MetroComboBox cboPort;
        private MetroFramework.Controls.MetroComboBox cboProtocolType;
        private MetroFramework.Controls.MetroTabControl TabContent;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private MetroFramework.Controls.MetroLabel labDistToMAV;
        private MetroFramework.Controls.MetroLabel labVerticalspeed;
        private MetroFramework.Controls.MetroLabel labYaw;
        private MetroFramework.Controls.MetroLabel labWpDist;
        private MetroFramework.Controls.MetroLabel labGroundSpeed;
        private MetroFramework.Controls.MetroLabel labAlt;
        private System.Windows.Forms.Label labAltNum;
        private System.Windows.Forms.Label labDistToAV;
        private System.Windows.Forms.Label labVSNum;
        private System.Windows.Forms.Label labYawNum;
        private System.Windows.Forms.Label labWpDistNum;
        private System.Windows.Forms.Label labGroundSeepd;
        public MissionPlanner.Controls.myGMAP myGMAP1;
        private MetroFramework.Controls.MetroButton btnConnect;
        private System.Windows.Forms.Button btnFlighData;
        private System.Windows.Forms.Button btnParameterSetting;
        private System.Windows.Forms.Button btnPlanningCourse;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.BindingSource bindingSourceHud;







    }
}