namespace FBGroundControl.Forms
{
    partial class CommunicationSetFrm
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
            this.serial_radioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TCP_radioButton = new System.Windows.Forms.RadioButton();
            this.Serial_panel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check4 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GanRaoJiCom = new System.Windows.Forms.ComboBox();
            this.GanRaoJiBau = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialXB_comboBox = new System.Windows.Forms.ComboBox();
            this.baudRateXB_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check1 = new System.Windows.Forms.CheckBox();
            this.serial_comboBox = new System.Windows.Forms.ComboBox();
            this.serialName = new System.Windows.Forms.Label();
            this.baudRateName = new System.Windows.Forms.Label();
            this.baudRate_comboBox = new System.Windows.Forms.ComboBox();
            this.MainCtrl_Group = new System.Windows.Forms.GroupBox();
            this.check2 = new System.Windows.Forms.CheckBox();
            this.serial_MainCtrl = new System.Windows.Forms.Label();
            this.serialMC_comboBox = new System.Windows.Forms.ComboBox();
            this.baudRateMC_comboBox = new System.Windows.Forms.ComboBox();
            this.baudRate_mainCtrl = new System.Windows.Forms.Label();
            this.refreshSerial_btn = new System.Windows.Forms.Button();
            this.cancelSerial_btn = new System.Windows.Forms.Button();
            this.openSerial_button = new System.Windows.Forms.Button();
            this.ZHAN_ID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.B4 = new System.Windows.Forms.TextBox();
            this.B3 = new System.Windows.Forms.TextBox();
            this.B6 = new System.Windows.Forms.TextBox();
            this.B5 = new System.Windows.Forms.TextBox();
            this.B2 = new System.Windows.Forms.TextBox();
            this.B1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Z4 = new System.Windows.Forms.TextBox();
            this.Z3 = new System.Windows.Forms.TextBox();
            this.Z6 = new System.Windows.Forms.TextBox();
            this.Z5 = new System.Windows.Forms.TextBox();
            this.Z2 = new System.Windows.Forms.TextBox();
            this.Z1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Serial_panel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MainCtrl_Group.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serial_radioButton
            // 
            this.serial_radioButton.AutoSize = true;
            this.serial_radioButton.Checked = true;
            this.serial_radioButton.Location = new System.Drawing.Point(77, 27);
            this.serial_radioButton.Name = "serial_radioButton";
            this.serial_radioButton.Size = new System.Drawing.Size(47, 16);
            this.serial_radioButton.TabIndex = 0;
            this.serial_radioButton.TabStop = true;
            this.serial_radioButton.Text = "串口";
            this.serial_radioButton.UseVisualStyleBackColor = true;
            this.serial_radioButton.CheckedChanged += new System.EventHandler(this.serial_radioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "类型：";
            // 
            // TCP_radioButton
            // 
            this.TCP_radioButton.AutoSize = true;
            this.TCP_radioButton.Location = new System.Drawing.Point(482, 27);
            this.TCP_radioButton.Name = "TCP_radioButton";
            this.TCP_radioButton.Size = new System.Drawing.Size(65, 16);
            this.TCP_radioButton.TabIndex = 2;
            this.TCP_radioButton.Text = "TCP设置";
            this.TCP_radioButton.UseVisualStyleBackColor = true;
            this.TCP_radioButton.Visible = false;
            this.TCP_radioButton.CheckedChanged += new System.EventHandler(this.TCP_radioButton_CheckedChanged);
            // 
            // Serial_panel
            // 
            this.Serial_panel.BackColor = System.Drawing.Color.Transparent;
            this.Serial_panel.Controls.Add(this.groupBox3);
            this.Serial_panel.Controls.Add(this.groupBox1);
            this.Serial_panel.Controls.Add(this.groupBox2);
            this.Serial_panel.Controls.Add(this.MainCtrl_Group);
            this.Serial_panel.Controls.Add(this.refreshSerial_btn);
            this.Serial_panel.Controls.Add(this.cancelSerial_btn);
            this.Serial_panel.Controls.Add(this.openSerial_button);
            this.Serial_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Serial_panel.Location = new System.Drawing.Point(3, 3);
            this.Serial_panel.Name = "Serial_panel";
            this.Serial_panel.Size = new System.Drawing.Size(887, 288);
            this.Serial_panel.TabIndex = 5;
            this.Serial_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Serial_panel_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.check4);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.GanRaoJiCom);
            this.groupBox3.Controls.Add(this.GanRaoJiBau);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(675, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 139);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "干扰机";
            // 
            // check4
            // 
            this.check4.AutoSize = true;
            this.check4.Checked = true;
            this.check4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check4.Location = new System.Drawing.Point(71, 103);
            this.check4.Name = "check4";
            this.check4.Size = new System.Drawing.Size(72, 16);
            this.check4.TabIndex = 20;
            this.check4.Text = "是否连接";
            this.check4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "串口：";
            // 
            // GanRaoJiCom
            // 
            this.GanRaoJiCom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GanRaoJiCom.DropDownWidth = 79;
            this.GanRaoJiCom.FormattingEnabled = true;
            this.GanRaoJiCom.Location = new System.Drawing.Point(74, 20);
            this.GanRaoJiCom.Name = "GanRaoJiCom";
            this.GanRaoJiCom.Size = new System.Drawing.Size(79, 22);
            this.GanRaoJiCom.TabIndex = 16;
            this.GanRaoJiCom.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.serialXB_comboBox_DrawItem);
            this.GanRaoJiCom.Click += new System.EventHandler(this.GanRaoJiCom_Click);
            // 
            // GanRaoJiBau
            // 
            this.GanRaoJiBau.FormattingEnabled = true;
            this.GanRaoJiBau.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "921600",
            "1500000"});
            this.GanRaoJiBau.Location = new System.Drawing.Point(74, 56);
            this.GanRaoJiBau.Name = "GanRaoJiBau";
            this.GanRaoJiBau.Size = new System.Drawing.Size(79, 20);
            this.GanRaoJiBau.TabIndex = 18;
            this.GanRaoJiBau.Text = "115200";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "波特率：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.serialXB_comboBox);
            this.groupBox1.Controls.Add(this.baudRateXB_comboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(464, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 139);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信标";
            // 
            // check3
            // 
            this.check3.AutoSize = true;
            this.check3.Checked = true;
            this.check3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check3.Location = new System.Drawing.Point(71, 103);
            this.check3.Name = "check3";
            this.check3.Size = new System.Drawing.Size(72, 16);
            this.check3.TabIndex = 20;
            this.check3.Text = "是否连接";
            this.check3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "串口：";
            // 
            // serialXB_comboBox
            // 
            this.serialXB_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.serialXB_comboBox.DropDownWidth = 79;
            this.serialXB_comboBox.FormattingEnabled = true;
            this.serialXB_comboBox.Location = new System.Drawing.Point(74, 20);
            this.serialXB_comboBox.Name = "serialXB_comboBox";
            this.serialXB_comboBox.Size = new System.Drawing.Size(79, 22);
            this.serialXB_comboBox.TabIndex = 16;
            this.serialXB_comboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.serialXB_comboBox_DrawItem);
            this.serialXB_comboBox.Click += new System.EventHandler(this.serialXB_comboBox_Click);
            // 
            // baudRateXB_comboBox
            // 
            this.baudRateXB_comboBox.FormattingEnabled = true;
            this.baudRateXB_comboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "921600",
            "1500000"});
            this.baudRateXB_comboBox.Location = new System.Drawing.Point(74, 56);
            this.baudRateXB_comboBox.Name = "baudRateXB_comboBox";
            this.baudRateXB_comboBox.Size = new System.Drawing.Size(79, 20);
            this.baudRateXB_comboBox.TabIndex = 18;
            this.baudRateXB_comboBox.Text = "115200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "波特率：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check1);
            this.groupBox2.Controls.Add(this.serial_comboBox);
            this.groupBox2.Controls.Add(this.serialName);
            this.groupBox2.Controls.Add(this.baudRateName);
            this.groupBox2.Controls.Add(this.baudRate_comboBox);
            this.groupBox2.Location = new System.Drawing.Point(31, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 139);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测控电台";
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Checked = true;
            this.check1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check1.Location = new System.Drawing.Point(62, 103);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(72, 16);
            this.check1.TabIndex = 19;
            this.check1.Text = "是否连接";
            this.check1.UseVisualStyleBackColor = true;
            // 
            // serial_comboBox
            // 
            this.serial_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.serial_comboBox.DropDownWidth = 200;
            this.serial_comboBox.FormattingEnabled = true;
            this.serial_comboBox.Location = new System.Drawing.Point(66, 20);
            this.serial_comboBox.Name = "serial_comboBox";
            this.serial_comboBox.Size = new System.Drawing.Size(82, 22);
            this.serial_comboBox.TabIndex = 13;
            this.serial_comboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.serial_comboBox_DrawItem);
            // 
            // serialName
            // 
            this.serialName.AutoSize = true;
            this.serialName.Location = new System.Drawing.Point(24, 23);
            this.serialName.Name = "serialName";
            this.serialName.Size = new System.Drawing.Size(41, 12);
            this.serialName.TabIndex = 9;
            this.serialName.Text = "串口：";
            // 
            // baudRateName
            // 
            this.baudRateName.AutoSize = true;
            this.baudRateName.Location = new System.Drawing.Point(12, 61);
            this.baudRateName.Name = "baudRateName";
            this.baudRateName.Size = new System.Drawing.Size(53, 12);
            this.baudRateName.TabIndex = 10;
            this.baudRateName.Text = "波特率：";
            // 
            // baudRate_comboBox
            // 
            this.baudRate_comboBox.FormattingEnabled = true;
            this.baudRate_comboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "921600",
            "1500000"});
            this.baudRate_comboBox.Location = new System.Drawing.Point(65, 58);
            this.baudRate_comboBox.Name = "baudRate_comboBox";
            this.baudRate_comboBox.Size = new System.Drawing.Size(83, 20);
            this.baudRate_comboBox.TabIndex = 14;
            // 
            // MainCtrl_Group
            // 
            this.MainCtrl_Group.Controls.Add(this.check2);
            this.MainCtrl_Group.Controls.Add(this.serial_MainCtrl);
            this.MainCtrl_Group.Controls.Add(this.serialMC_comboBox);
            this.MainCtrl_Group.Controls.Add(this.baudRateMC_comboBox);
            this.MainCtrl_Group.Controls.Add(this.baudRate_mainCtrl);
            this.MainCtrl_Group.Location = new System.Drawing.Point(252, 45);
            this.MainCtrl_Group.Name = "MainCtrl_Group";
            this.MainCtrl_Group.Size = new System.Drawing.Size(186, 139);
            this.MainCtrl_Group.TabIndex = 24;
            this.MainCtrl_Group.TabStop = false;
            this.MainCtrl_Group.Text = "主控板";
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Checked = true;
            this.check2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check2.Location = new System.Drawing.Point(65, 103);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(72, 16);
            this.check2.TabIndex = 20;
            this.check2.Text = "是否连接";
            this.check2.UseVisualStyleBackColor = true;
            // 
            // serial_MainCtrl
            // 
            this.serial_MainCtrl.AutoSize = true;
            this.serial_MainCtrl.Location = new System.Drawing.Point(33, 25);
            this.serial_MainCtrl.Name = "serial_MainCtrl";
            this.serial_MainCtrl.Size = new System.Drawing.Size(41, 12);
            this.serial_MainCtrl.TabIndex = 15;
            this.serial_MainCtrl.Text = "串口：";
            // 
            // serialMC_comboBox
            // 
            this.serialMC_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.serialMC_comboBox.DropDownWidth = 79;
            this.serialMC_comboBox.FormattingEnabled = true;
            this.serialMC_comboBox.Location = new System.Drawing.Point(74, 20);
            this.serialMC_comboBox.Name = "serialMC_comboBox";
            this.serialMC_comboBox.Size = new System.Drawing.Size(79, 22);
            this.serialMC_comboBox.TabIndex = 16;
            this.serialMC_comboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.serialMC_comboBox_DrawItem);
            // 
            // baudRateMC_comboBox
            // 
            this.baudRateMC_comboBox.FormattingEnabled = true;
            this.baudRateMC_comboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "921600",
            "1500000"});
            this.baudRateMC_comboBox.Location = new System.Drawing.Point(74, 56);
            this.baudRateMC_comboBox.Name = "baudRateMC_comboBox";
            this.baudRateMC_comboBox.Size = new System.Drawing.Size(79, 20);
            this.baudRateMC_comboBox.TabIndex = 18;
            // 
            // baudRate_mainCtrl
            // 
            this.baudRate_mainCtrl.AutoSize = true;
            this.baudRate_mainCtrl.Location = new System.Drawing.Point(21, 60);
            this.baudRate_mainCtrl.Name = "baudRate_mainCtrl";
            this.baudRate_mainCtrl.Size = new System.Drawing.Size(53, 12);
            this.baudRate_mainCtrl.TabIndex = 17;
            this.baudRate_mainCtrl.Text = "波特率：";
            // 
            // refreshSerial_btn
            // 
            this.refreshSerial_btn.Location = new System.Drawing.Point(329, 211);
            this.refreshSerial_btn.Name = "refreshSerial_btn";
            this.refreshSerial_btn.Size = new System.Drawing.Size(75, 23);
            this.refreshSerial_btn.TabIndex = 20;
            this.refreshSerial_btn.Text = "刷新";
            this.refreshSerial_btn.UseVisualStyleBackColor = true;
            this.refreshSerial_btn.Click += new System.EventHandler(this.refreshSerial_btn_Click);
            // 
            // cancelSerial_btn
            // 
            this.cancelSerial_btn.Location = new System.Drawing.Point(532, 211);
            this.cancelSerial_btn.Name = "cancelSerial_btn";
            this.cancelSerial_btn.Size = new System.Drawing.Size(75, 23);
            this.cancelSerial_btn.TabIndex = 21;
            this.cancelSerial_btn.Text = "取消";
            this.cancelSerial_btn.UseVisualStyleBackColor = true;
            this.cancelSerial_btn.Click += new System.EventHandler(this.cancelSerial_btn_Click);
            // 
            // openSerial_button
            // 
            this.openSerial_button.Location = new System.Drawing.Point(112, 211);
            this.openSerial_button.Name = "openSerial_button";
            this.openSerial_button.Size = new System.Drawing.Size(75, 23);
            this.openSerial_button.TabIndex = 11;
            this.openSerial_button.Text = "打开";
            this.openSerial_button.UseVisualStyleBackColor = true;
            this.openSerial_button.Click += new System.EventHandler(this.openSerial_button_Click);
            // 
            // ZHAN_ID
            // 
            this.ZHAN_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ZHAN_ID.FormattingEnabled = true;
            this.ZHAN_ID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.ZHAN_ID.Location = new System.Drawing.Point(224, 26);
            this.ZHAN_ID.Name = "ZHAN_ID";
            this.ZHAN_ID.Size = new System.Drawing.Size(50, 20);
            this.ZHAN_ID.TabIndex = 6;
            this.ZHAN_ID.SelectedIndexChanged += new System.EventHandler(this.ZHAN_ID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "地面站ID：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(34, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 320);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.B4);
            this.tabPage1.Controls.Add(this.B3);
            this.tabPage1.Controls.Add(this.B6);
            this.tabPage1.Controls.Add(this.B5);
            this.tabPage1.Controls.Add(this.B2);
            this.tabPage1.Controls.Add(this.B1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Z4);
            this.tabPage1.Controls.Add(this.Z3);
            this.tabPage1.Controls.Add(this.Z6);
            this.tabPage1.Controls.Add(this.Z5);
            this.tabPage1.Controls.Add(this.Z2);
            this.tabPage1.Controls.Add(this.Z1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1239, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配置表";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "靶机ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "组号";
            // 
            // B4
            // 
            this.B4.Location = new System.Drawing.Point(289, 142);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(62, 21);
            this.B4.TabIndex = 25;
            // 
            // B3
            // 
            this.B3.Location = new System.Drawing.Point(289, 108);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(62, 21);
            this.B3.TabIndex = 24;
            // 
            // B6
            // 
            this.B6.Location = new System.Drawing.Point(289, 210);
            this.B6.Name = "B6";
            this.B6.Size = new System.Drawing.Size(62, 21);
            this.B6.TabIndex = 23;
            // 
            // B5
            // 
            this.B5.Location = new System.Drawing.Point(289, 176);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(62, 21);
            this.B5.TabIndex = 22;
            // 
            // B2
            // 
            this.B2.Location = new System.Drawing.Point(289, 74);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(62, 21);
            this.B2.TabIndex = 21;
            // 
            // B1
            // 
            this.B1.Location = new System.Drawing.Point(289, 40);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(62, 21);
            this.B1.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 36);
            this.button3.TabIndex = 19;
            this.button3.Text = "导入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 36);
            this.button2.TabIndex = 18;
            this.button2.Text = "导出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 36);
            this.button1.TabIndex = 17;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Z4
            // 
            this.Z4.Enabled = false;
            this.Z4.Location = new System.Drawing.Point(202, 142);
            this.Z4.Name = "Z4";
            this.Z4.Size = new System.Drawing.Size(62, 21);
            this.Z4.TabIndex = 16;
            // 
            // Z3
            // 
            this.Z3.Enabled = false;
            this.Z3.Location = new System.Drawing.Point(202, 108);
            this.Z3.Name = "Z3";
            this.Z3.Size = new System.Drawing.Size(62, 21);
            this.Z3.TabIndex = 15;
            // 
            // Z6
            // 
            this.Z6.Enabled = false;
            this.Z6.Location = new System.Drawing.Point(202, 210);
            this.Z6.Name = "Z6";
            this.Z6.Size = new System.Drawing.Size(62, 21);
            this.Z6.TabIndex = 14;
            // 
            // Z5
            // 
            this.Z5.Enabled = false;
            this.Z5.Location = new System.Drawing.Point(202, 176);
            this.Z5.Name = "Z5";
            this.Z5.Size = new System.Drawing.Size(62, 21);
            this.Z5.TabIndex = 13;
            // 
            // Z2
            // 
            this.Z2.Enabled = false;
            this.Z2.Location = new System.Drawing.Point(202, 74);
            this.Z2.Name = "Z2";
            this.Z2.Size = new System.Drawing.Size(62, 21);
            this.Z2.TabIndex = 12;
            // 
            // Z1
            // 
            this.Z1.Enabled = false;
            this.Z1.Location = new System.Drawing.Point(202, 40);
            this.Z1.Name = "Z1";
            this.Z1.Size = new System.Drawing.Size(62, 21);
            this.Z1.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(116, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "靶机ID-6：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(116, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "靶机ID-5：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "靶机ID-4：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "靶机ID-3：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "靶机ID-2：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "靶机ID-1：";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.Serial_panel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "端口选择";
            // 
            // CommunicationSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 398);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ZHAN_ID);
            this.Controls.Add(this.TCP_radioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serial_radioButton);
            this.Name = "CommunicationSetFrm";
            this.Text = "通讯设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommunicationSetFrm_FormClosing);
            this.Load += new System.EventHandler(this.CommunicationSetFrm_Load);
            this.Serial_panel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MainCtrl_Group.ResumeLayout(false);
            this.MainCtrl_Group.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.RadioButton serial_radioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TCP_radioButton;
        private System.Windows.Forms.Panel Serial_panel;
        private System.Windows.Forms.ComboBox baudRate_comboBox;
        private System.Windows.Forms.ComboBox serial_comboBox;
        private System.Windows.Forms.Button openSerial_button;
        private System.Windows.Forms.Label baudRateName;
        private System.Windows.Forms.Label serialName;
        private System.Windows.Forms.Button refreshSerial_btn;
        private System.Windows.Forms.Button cancelSerial_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox MainCtrl_Group;
        private System.Windows.Forms.Label serial_MainCtrl;
        private System.Windows.Forms.ComboBox serialMC_comboBox;
        private System.Windows.Forms.ComboBox baudRateMC_comboBox;
        private System.Windows.Forms.Label baudRate_mainCtrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox serialXB_comboBox;
        public System.Windows.Forms.ComboBox baudRateXB_comboBox;
        public System.Windows.Forms.CheckBox check3;
        public System.Windows.Forms.CheckBox check1;
        public System.Windows.Forms.CheckBox check2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox ZHAN_ID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Z4;
        private System.Windows.Forms.TextBox Z3;
        private System.Windows.Forms.TextBox Z6;
        private System.Windows.Forms.TextBox Z5;
        private System.Windows.Forms.TextBox Z2;
        private System.Windows.Forms.TextBox Z1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox B4;
        private System.Windows.Forms.TextBox B3;
        private System.Windows.Forms.TextBox B6;
        private System.Windows.Forms.TextBox B5;
        private System.Windows.Forms.TextBox B2;
        private System.Windows.Forms.TextBox B1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox check4;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox GanRaoJiCom;
        public System.Windows.Forms.ComboBox GanRaoJiBau;
        private System.Windows.Forms.Label label14;
    }
}