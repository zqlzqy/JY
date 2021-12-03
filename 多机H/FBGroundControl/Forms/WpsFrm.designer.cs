using System.Windows.Forms;
namespace FBGroundControl.Forms
{
    partial class WpsFrm
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
          
           // base.Dispose(disposing);
            //base.Hide();
            if (MainForm.isExitSystem)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else {
                if (IsShowWpsFrmHandler != null)
                {
                    if (isShow)
                    {
                        IsShowWpsFrmHandler(false);
                        isShow = false;
                    }
                    else
                    {
                        IsShowWpsFrmHandler(true);
                        isShow = true;
                    }
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.myLabel2 = new MissionPlanner.Controls.MyLabel();
            this.myLabel4 = new MissionPlanner.Controls.MyLabel();
            this.TXT_WPRad = new System.Windows.Forms.TextBox();
            this.TXT_loiterrad = new System.Windows.Forms.TextBox();
            this.myLabel3 = new MissionPlanner.Controls.MyLabel();
            this.CHK_verifyheight = new System.Windows.Forms.CheckBox();
            this.CMB_altmode = new System.Windows.Forms.ComboBox();
            this.TXT_DefaultAlt = new System.Windows.Forms.TextBox();
            this.myLabel1 = new MissionPlanner.Controls.MyLabel();
            this.Commands = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveRoute_button = new System.Windows.Forms.Button();
            this.HomeSearch_button = new System.Windows.Forms.Button();
            this.RouteClear_button = new System.Windows.Forms.Button();
            this.RouteSearch_button = new System.Windows.Forms.Button();
            this.RouteIUpLoad_Button = new System.Windows.Forms.Button();
            this.RouteLoading_Button = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myLabel7 = new MissionPlanner.Controls.MyLabel();
            this.config_change = new System.Windows.Forms.Button();
            this.gb_heading = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SECOND = new System.Windows.Forms.TextBox();
            this.cheading = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.LinkLabel();
            this.TXT_homelng = new System.Windows.Forms.TextBox();
            this.TXT_homelat = new System.Windows.Forms.TextBox();
            this.sec = new MissionPlanner.Controls.MyLabel();
            this.myLabel8 = new MissionPlanner.Controls.MyLabel();
            this.myLabel5 = new MissionPlanner.Controls.MyLabel();
            this.myLabel6 = new MissionPlanner.Controls.MyLabel();
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this.Hxnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.Commands);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 410);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.myLabel2);
            this.flowLayoutPanel2.Controls.Add(this.myLabel4);
            this.flowLayoutPanel2.Controls.Add(this.TXT_WPRad);
            this.flowLayoutPanel2.Controls.Add(this.TXT_loiterrad);
            this.flowLayoutPanel2.Controls.Add(this.myLabel3);
            this.flowLayoutPanel2.Controls.Add(this.CHK_verifyheight);
            this.flowLayoutPanel2.Controls.Add(this.CMB_altmode);
            this.flowLayoutPanel2.Controls.Add(this.TXT_DefaultAlt);
            this.flowLayoutPanel2.Controls.Add(this.myLabel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 384);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(809, 26);
            this.flowLayoutPanel2.TabIndex = 10;
            this.flowLayoutPanel2.Visible = false;
            // 
            // myLabel2
            // 
            this.myLabel2.Location = new System.Drawing.Point(3, 3);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.resize = false;
            this.myLabel2.Size = new System.Drawing.Size(56, 21);
            this.myLabel2.TabIndex = 2;
            this.myLabel2.Text = "高度模式：";
            this.myLabel2.Visible = false;
            // 
            // myLabel4
            // 
            this.myLabel4.Location = new System.Drawing.Point(65, 3);
            this.myLabel4.Name = "myLabel4";
            this.myLabel4.resize = false;
            this.myLabel4.Size = new System.Drawing.Size(56, 21);
            this.myLabel4.TabIndex = 6;
            this.myLabel4.Text = "悬停半径：";
            this.myLabel4.Visible = false;
            // 
            // TXT_WPRad
            // 
            this.TXT_WPRad.Location = new System.Drawing.Point(127, 3);
            this.TXT_WPRad.Name = "TXT_WPRad";
            this.TXT_WPRad.Size = new System.Drawing.Size(100, 21);
            this.TXT_WPRad.TabIndex = 5;
            this.TXT_WPRad.Visible = false;
            // 
            // TXT_loiterrad
            // 
            this.TXT_loiterrad.Location = new System.Drawing.Point(233, 3);
            this.TXT_loiterrad.Name = "TXT_loiterrad";
            this.TXT_loiterrad.Size = new System.Drawing.Size(100, 21);
            this.TXT_loiterrad.TabIndex = 7;
            this.TXT_loiterrad.Visible = false;
            // 
            // myLabel3
            // 
            this.myLabel3.Location = new System.Drawing.Point(339, 3);
            this.myLabel3.Name = "myLabel3";
            this.myLabel3.resize = false;
            this.myLabel3.Size = new System.Drawing.Size(56, 21);
            this.myLabel3.TabIndex = 4;
            this.myLabel3.Text = "航点半径：";
            this.myLabel3.Visible = false;
            // 
            // CHK_verifyheight
            // 
            this.CHK_verifyheight.Location = new System.Drawing.Point(401, 3);
            this.CHK_verifyheight.Name = "CHK_verifyheight";
            this.CHK_verifyheight.Size = new System.Drawing.Size(79, 21);
            this.CHK_verifyheight.TabIndex = 8;
            this.CHK_verifyheight.Text = "验证高度";
            this.CHK_verifyheight.UseVisualStyleBackColor = true;
            this.CHK_verifyheight.Visible = false;
            // 
            // CMB_altmode
            // 
            this.CMB_altmode.FormattingEnabled = true;
            this.CMB_altmode.Location = new System.Drawing.Point(486, 3);
            this.CMB_altmode.Name = "CMB_altmode";
            this.CMB_altmode.Size = new System.Drawing.Size(121, 20);
            this.CMB_altmode.TabIndex = 9;
            this.CMB_altmode.Visible = false;
            // 
            // TXT_DefaultAlt
            // 
            this.TXT_DefaultAlt.Location = new System.Drawing.Point(613, 3);
            this.TXT_DefaultAlt.Name = "TXT_DefaultAlt";
            this.TXT_DefaultAlt.Size = new System.Drawing.Size(100, 21);
            this.TXT_DefaultAlt.TabIndex = 1;
            this.TXT_DefaultAlt.Visible = false;
            // 
            // myLabel1
            // 
            this.myLabel1.Location = new System.Drawing.Point(719, 3);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.resize = false;
            this.myLabel1.Size = new System.Drawing.Size(56, 21);
            this.myLabel1.TabIndex = 0;
            this.myLabel1.Text = "默认高度：";
            this.myLabel1.Visible = false;
            // 
            // Commands
            // 
            this.Commands.AllowUserToAddRows = false;
            this.Commands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Commands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Commands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hxnum,
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
            this.Commands.RowHeadersWidth = 50;
            this.Commands.RowTemplate.Height = 23;
            this.Commands.Size = new System.Drawing.Size(809, 410);
            this.Commands.TabIndex = 0;
            this.Commands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(809, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 410);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(154, 410);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.SaveRoute_button);
            this.tabPage1.Controls.Add(this.HomeSearch_button);
            this.tabPage1.Controls.Add(this.RouteClear_button);
            this.tabPage1.Controls.Add(this.RouteSearch_button);
            this.tabPage1.Controls.Add(this.RouteIUpLoad_Button);
            this.tabPage1.Controls.Add(this.RouteLoading_Button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(146, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "操作";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "退出编队";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveRoute_button
            // 
            this.SaveRoute_button.Location = new System.Drawing.Point(21, 146);
            this.SaveRoute_button.Name = "SaveRoute_button";
            this.SaveRoute_button.Size = new System.Drawing.Size(101, 23);
            this.SaveRoute_button.TabIndex = 25;
            this.SaveRoute_button.Text = "保存航线规划";
            this.SaveRoute_button.UseVisualStyleBackColor = true;
            this.SaveRoute_button.Click += new System.EventHandler(this.SaveRoute_button_Click);
            // 
            // HomeSearch_button
            // 
            this.HomeSearch_button.Location = new System.Drawing.Point(21, 233);
            this.HomeSearch_button.Name = "HomeSearch_button";
            this.HomeSearch_button.Size = new System.Drawing.Size(101, 23);
            this.HomeSearch_button.TabIndex = 25;
            this.HomeSearch_button.Text = "进入编队";
            this.HomeSearch_button.UseVisualStyleBackColor = true;
            this.HomeSearch_button.Click += new System.EventHandler(this.HomeSearch_button_Click);
            // 
            // RouteClear_button
            // 
            this.RouteClear_button.Location = new System.Drawing.Point(21, 111);
            this.RouteClear_button.Name = "RouteClear_button";
            this.RouteClear_button.Size = new System.Drawing.Size(101, 23);
            this.RouteClear_button.TabIndex = 23;
            this.RouteClear_button.Text = "规划航线清除";
            this.RouteClear_button.UseVisualStyleBackColor = true;
            this.RouteClear_button.Click += new System.EventHandler(this.RouteClear_button_Click);
            // 
            // RouteSearch_button
            // 
            this.RouteSearch_button.Location = new System.Drawing.Point(21, 76);
            this.RouteSearch_button.Name = "RouteSearch_button";
            this.RouteSearch_button.Size = new System.Drawing.Size(101, 23);
            this.RouteSearch_button.TabIndex = 22;
            this.RouteSearch_button.Text = "航线查询";
            this.RouteSearch_button.UseVisualStyleBackColor = true;
            this.RouteSearch_button.Click += new System.EventHandler(this.RouteSearch_button_Click);
            // 
            // RouteIUpLoad_Button
            // 
            this.RouteIUpLoad_Button.Location = new System.Drawing.Point(21, 41);
            this.RouteIUpLoad_Button.Name = "RouteIUpLoad_Button";
            this.RouteIUpLoad_Button.Size = new System.Drawing.Size(101, 23);
            this.RouteIUpLoad_Button.TabIndex = 21;
            this.RouteIUpLoad_Button.Text = "航线上传";
            this.RouteIUpLoad_Button.UseVisualStyleBackColor = true;
            this.RouteIUpLoad_Button.Click += new System.EventHandler(this.RouteIUpLoad_Button_Click);
            // 
            // RouteLoading_Button
            // 
            this.RouteLoading_Button.Location = new System.Drawing.Point(21, 6);
            this.RouteLoading_Button.Name = "RouteLoading_Button";
            this.RouteLoading_Button.Size = new System.Drawing.Size(101, 23);
            this.RouteLoading_Button.TabIndex = 20;
            this.RouteLoading_Button.Text = "航线加载";
            this.RouteLoading_Button.UseVisualStyleBackColor = true;
            this.RouteLoading_Button.Click += new System.EventHandler(this.RouteLoading_Button_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.myLabel7);
            this.tabPage2.Controls.Add(this.config_change);
            this.tabPage2.Controls.Add(this.gb_heading);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.SECOND);
            this.tabPage2.Controls.Add(this.cheading);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TXT_homelng);
            this.tabPage2.Controls.Add(this.TXT_homelat);
            this.tabPage2.Controls.Add(this.sec);
            this.tabPage2.Controls.Add(this.myLabel8);
            this.tabPage2.Controls.Add(this.myLabel5);
            this.tabPage2.Controls.Add(this.myLabel6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(146, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "舰";
            // 
            // myLabel7
            // 
            this.myLabel7.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel7.Location = new System.Drawing.Point(34, 134);
            this.myLabel7.Name = "myLabel7";
            this.myLabel7.resize = false;
            this.myLabel7.Size = new System.Drawing.Size(31, 21);
            this.myLabel7.TabIndex = 64;
            this.myLabel7.Text = "(节)";
            // 
            // config_change
            // 
            this.config_change.Location = new System.Drawing.Point(24, 211);
            this.config_change.Name = "config_change";
            this.config_change.Size = new System.Drawing.Size(97, 23);
            this.config_change.TabIndex = 63;
            this.config_change.Text = "确认更改";
            this.config_change.UseVisualStyleBackColor = true;
            this.config_change.Click += new System.EventHandler(this.config_change_Click);
            // 
            // gb_heading
            // 
            this.gb_heading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gb_heading.ForeColor = System.Drawing.Color.Red;
            this.gb_heading.Location = new System.Drawing.Point(77, 169);
            this.gb_heading.Name = "gb_heading";
            this.gb_heading.Size = new System.Drawing.Size(54, 21);
            this.gb_heading.TabIndex = 62;
            this.gb_heading.Text = "0";
            this.gb_heading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "改变航向";
            // 
            // SECOND
            // 
            this.SECOND.Enabled = false;
            this.SECOND.Location = new System.Drawing.Point(77, 134);
            this.SECOND.Name = "SECOND";
            this.SECOND.ReadOnly = true;
            this.SECOND.Size = new System.Drawing.Size(54, 21);
            this.SECOND.TabIndex = 29;
            // 
            // cheading
            // 
            this.cheading.Enabled = false;
            this.cheading.Location = new System.Drawing.Point(53, 98);
            this.cheading.Name = "cheading";
            this.cheading.ReadOnly = true;
            this.cheading.Size = new System.Drawing.Size(78, 21);
            this.cheading.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 17;
            this.label4.TabStop = true;
            this.label4.Text = "Home Location";
            this.label4.Visible = false;
            // 
            // TXT_homelng
            // 
            this.TXT_homelng.Enabled = false;
            this.TXT_homelng.Location = new System.Drawing.Point(52, 34);
            this.TXT_homelng.Name = "TXT_homelng";
            this.TXT_homelng.ReadOnly = true;
            this.TXT_homelng.Size = new System.Drawing.Size(79, 21);
            this.TXT_homelng.TabIndex = 18;
            // 
            // TXT_homelat
            // 
            this.TXT_homelat.Enabled = false;
            this.TXT_homelat.Location = new System.Drawing.Point(52, 65);
            this.TXT_homelat.Name = "TXT_homelat";
            this.TXT_homelat.ReadOnly = true;
            this.TXT_homelat.Size = new System.Drawing.Size(79, 21);
            this.TXT_homelat.TabIndex = 21;
            // 
            // sec
            // 
            this.sec.Font = new System.Drawing.Font("宋体", 9F);
            this.sec.Location = new System.Drawing.Point(5, 134);
            this.sec.Name = "sec";
            this.sec.resize = false;
            this.sec.Size = new System.Drawing.Size(31, 21);
            this.sec.TabIndex = 30;
            this.sec.Text = "航速";
            // 
            // myLabel8
            // 
            this.myLabel8.Location = new System.Drawing.Point(5, 98);
            this.myLabel8.Name = "myLabel8";
            this.myLabel8.resize = false;
            this.myLabel8.Size = new System.Drawing.Size(40, 21);
            this.myLabel8.TabIndex = 28;
            this.myLabel8.Text = "航向";
            // 
            // myLabel5
            // 
            this.myLabel5.Location = new System.Drawing.Point(4, 34);
            this.myLabel5.Name = "myLabel5";
            this.myLabel5.resize = false;
            this.myLabel5.Size = new System.Drawing.Size(40, 21);
            this.myLabel5.TabIndex = 19;
            this.myLabel5.Text = "经度";
            // 
            // myLabel6
            // 
            this.myLabel6.Location = new System.Drawing.Point(4, 65);
            this.myLabel6.Name = "myLabel6";
            this.myLabel6.resize = false;
            this.myLabel6.Size = new System.Drawing.Size(40, 21);
            this.myLabel6.TabIndex = 20;
            this.myLabel6.Text = "纬度";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Transparent;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(809, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // Hxnum
            // 
            this.Hxnum.HeaderText = "航线序号";
            this.Hxnum.Name = "Hxnum";
            // 
            // Command
            // 
            this.Command.HeaderText = "航点属性";
            this.Command.Name = "Command";
            // 
            // Param1
            // 
            this.Param1.HeaderText = "速度";
            this.Param1.Name = "Param1";
            this.Param1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Param1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param2
            // 
            this.Param2.HeaderText = "备用1";
            this.Param2.Name = "Param2";
            this.Param2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Param2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param3
            // 
            this.Param3.HeaderText = "备用2";
            this.Param3.Name = "Param3";
            this.Param3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Param3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param4
            // 
            this.Param4.HeaderText = "备用3";
            this.Param4.Name = "Param4";
            this.Param4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Param4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lat
            // 
            this.Lat.HeaderText = "X";
            this.Lat.Name = "Lat";
            this.Lat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Lat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lon
            // 
            this.Lon.HeaderText = "Y";
            this.Lon.Name = "Lon";
            this.Lon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Lon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Alt
            // 
            this.Alt.HeaderText = "Z";
            this.Alt.Name = "Alt";
            this.Alt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Alt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            // 
            // Up
            // 
            this.Up.HeaderText = "上移";
            this.Up.Image = global::FBGroundControl.Properties.Resources.up;
            this.Up.Name = "Up";
            // 
            // Down
            // 
            this.Down.HeaderText = "下移";
            this.Down.Image = global::FBGroundControl.Properties.Resources.down;
            this.Down.Name = "Down";
            // 
            // Grad
            // 
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            this.Grad.Visible = false;
            // 
            // Angle
            // 
            this.Angle.HeaderText = "Angle";
            this.Angle.Name = "Angle";
            this.Angle.Visible = false;
            // 
            // Dist
            // 
            this.Dist.HeaderText = "与前点距离";
            this.Dist.Name = "Dist";
            this.Dist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AZ
            // 
            this.AZ.HeaderText = "AZ";
            this.AZ.Name = "AZ";
            this.AZ.Visible = false;
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.Visible = false;
            // 
            // WpsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 410);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "WpsFrm";
            this.Text = "航点";
            this.Load += new System.EventHandler(this.WpsFrm_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MissionPlanner.Controls.MyLabel myLabel1;
        public System.Windows.Forms.TextBox TXT_DefaultAlt;
        private MissionPlanner.Controls.MyLabel myLabel2;
        public System.Windows.Forms.ComboBox CMB_altmode;
        private MissionPlanner.Controls.MyLabel myLabel3;
        public System.Windows.Forms.TextBox TXT_WPRad;
        private MissionPlanner.Controls.MyLabel myLabel4;
        public System.Windows.Forms.TextBox TXT_loiterrad;
        public System.Windows.Forms.CheckBox CHK_verifyheight;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView Commands;
        private BSE.Windows.Forms.Splitter splitter1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button SaveRoute_button;
        private Button HomeSearch_button;
        private Button RouteClear_button;
        private Button RouteSearch_button;
        private Button RouteIUpLoad_Button;
        private Button RouteLoading_Button;
        public LinkLabel label4;
        public TextBox TXT_homelng;
        private MissionPlanner.Controls.MyLabel myLabel5;
        public TextBox TXT_homelat;
        private MissionPlanner.Controls.MyLabel myLabel6;
        private Button button1;
        public TextBox SECOND;
        private MissionPlanner.Controls.MyLabel sec;
        public TextBox cheading;
        private MissionPlanner.Controls.MyLabel myLabel8;
        public Button config_change;
        public TextBox gb_heading;
        private Label label2;
        private MissionPlanner.Controls.MyLabel myLabel7;
        private FlowLayoutPanel flowLayoutPanel2;
        public DataGridViewTextBoxColumn Hxnum;
        public DataGridViewComboBoxColumn Command;
        public DataGridViewTextBoxColumn Param1;
        public DataGridViewTextBoxColumn Param2;
        public DataGridViewTextBoxColumn Param3;
        public DataGridViewTextBoxColumn Param4;
        public DataGridViewTextBoxColumn Lat;
        public DataGridViewTextBoxColumn Lon;
        public DataGridViewTextBoxColumn Alt;
        public DataGridViewButtonColumn Delete;
        public DataGridViewImageColumn Up;
        public DataGridViewImageColumn Down;
        public DataGridViewTextBoxColumn Grad;
        public DataGridViewTextBoxColumn Angle;
        public DataGridViewTextBoxColumn Dist;
        public DataGridViewTextBoxColumn AZ;
        public DataGridViewTextBoxColumn Tag;
         


    }
}