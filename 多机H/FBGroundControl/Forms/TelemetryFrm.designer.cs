namespace FBGroundControl.Forms
{
    partial class TelemetryFrm
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
           
           //base.Dispose(disposing);
           //base.Visible = false;
            if (MainForm.isExitSystem)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else {
                IsHidden = true;
            }
           
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabStatus = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabControlactions = new System.Windows.Forms.TabControl();
            this.quickView1 = new MissionPlanner.Controls.QuickView();
            this.bindingSourceQuickTab = new System.Windows.Forms.BindingSource(this.components);
            this.quickView11 = new MissionPlanner.Controls.QuickView();
            this.quickView12 = new MissionPlanner.Controls.QuickView();
            this.quickView13 = new MissionPlanner.Controls.QuickView();
            this.quickView14 = new MissionPlanner.Controls.QuickView();
            this.quickView10 = new MissionPlanner.Controls.QuickView();
            this.quickView9 = new MissionPlanner.Controls.QuickView();
            this.quickView8 = new MissionPlanner.Controls.QuickView();
            this.quickView6 = new MissionPlanner.Controls.QuickView();
            this.quickView3 = new MissionPlanner.Controls.QuickView();
            this.quickView2 = new MissionPlanner.Controls.QuickView();
            this.quickView55 = new MissionPlanner.Controls.QuickView();
            this.quickView52 = new MissionPlanner.Controls.QuickView();
            this.quickView5 = new MissionPlanner.Controls.QuickView();
            this.quickView7 = new MissionPlanner.Controls.QuickView();
            this.quickView20 = new MissionPlanner.Controls.QuickView();
            this.quickView19 = new MissionPlanner.Controls.QuickView();
            this.quickView4 = new MissionPlanner.Controls.QuickView();
            this.quickView62 = new MissionPlanner.Controls.QuickView();
            this.quickView63 = new MissionPlanner.Controls.QuickView();
            this.quickView64 = new MissionPlanner.Controls.QuickView();
            this.quickView65 = new MissionPlanner.Controls.QuickView();
            this.quickView68 = new MissionPlanner.Controls.QuickView();
            this.quickView69 = new MissionPlanner.Controls.QuickView();
            this.quickView70 = new MissionPlanner.Controls.QuickView();
            this.quickView72 = new MissionPlanner.Controls.QuickView();
            this.quickView73 = new MissionPlanner.Controls.QuickView();
            this.bindingSourceGaugesTab = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceStatusTab = new System.Windows.Forms.BindingSource(this.components);
            this.arduinoSTK1 = new MissionPlanner.Arduino.ArduinoSTK();
            this.quickView34 = new MissionPlanner.Controls.QuickView();
            this.quickView33 = new MissionPlanner.Controls.QuickView();
            this.quickView32 = new MissionPlanner.Controls.QuickView();
            this.quickView31 = new MissionPlanner.Controls.QuickView();
            this.quickView30 = new MissionPlanner.Controls.QuickView();
            this.quickView29 = new MissionPlanner.Controls.QuickView();
            this.quickView28 = new MissionPlanner.Controls.QuickView();
            this.quickView27 = new MissionPlanner.Controls.QuickView();
            this.quickView26 = new MissionPlanner.Controls.QuickView();
            this.quickView25 = new MissionPlanner.Controls.QuickView();
            this.tabPage6.SuspendLayout();
            this.tabControlactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).BeginInit();
            this.SuspendLayout();
            // 
            // tabStatus
            // 
            this.tabStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStatus.Location = new System.Drawing.Point(0, 0);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(737, 32);
            this.tabStatus.TabIndex = 0;
            this.tabStatus.Visible = false;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Silver;
            this.tabPage6.Controls.Add(this.quickView1);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.textBox4);
            this.tabPage6.Controls.Add(this.quickView11);
            this.tabPage6.Controls.Add(this.quickView12);
            this.tabPage6.Controls.Add(this.quickView13);
            this.tabPage6.Controls.Add(this.quickView14);
            this.tabPage6.Controls.Add(this.quickView10);
            this.tabPage6.Controls.Add(this.quickView9);
            this.tabPage6.Controls.Add(this.quickView8);
            this.tabPage6.Controls.Add(this.quickView6);
            this.tabPage6.Controls.Add(this.quickView3);
            this.tabPage6.Controls.Add(this.label30);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.quickView2);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.textBox3);
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.textBox2);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.quickView55);
            this.tabPage6.Controls.Add(this.quickView52);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.textBox1);
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.textBox5);
            this.tabPage6.Controls.Add(this.quickView5);
            this.tabPage6.Controls.Add(this.quickView7);
            this.tabPage6.Controls.Add(this.quickView20);
            this.tabPage6.Controls.Add(this.quickView19);
            this.tabPage6.Controls.Add(this.quickView4);
            this.tabPage6.Controls.Add(this.quickView62);
            this.tabPage6.Controls.Add(this.quickView63);
            this.tabPage6.Controls.Add(this.quickView64);
            this.tabPage6.Controls.Add(this.quickView65);
            this.tabPage6.Controls.Add(this.quickView68);
            this.tabPage6.Controls.Add(this.quickView69);
            this.tabPage6.Controls.Add(this.quickView70);
            this.tabPage6.Controls.Add(this.quickView72);
            this.tabPage6.Controls.Add(this.quickView73);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(729, 448);
            this.tabPage6.TabIndex = 9;
            this.tabPage6.Text = "监测";
            this.tabPage6.Click += new System.EventHandler(this.tabPage6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceQuickTab, "control_youmen", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0%"));
            this.label14.Font = new System.Drawing.Font("宋体", 11F);
            this.label14.Location = new System.Drawing.Point(374, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 176;
            this.label14.Text = "无";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(270, 271);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 175;
            this.label15.Text = "控制油门";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("宋体", 22F);
            this.textBox4.Location = new System.Drawing.Point(255, 257);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(210, 41);
            this.textBox4.TabIndex = 174;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 12F);
            this.label30.ForeColor = System.Drawing.Color.Navy;
            this.label30.Location = new System.Drawing.Point(13, 357);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 32);
            this.label30.TabIndex = 164;
            this.label30.Text = "舵\r\n机\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(8, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 16);
            this.label13.TabIndex = 139;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceQuickTab, "lat_dfm", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "00°00\'00.00\""));
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(340, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 15);
            this.label11.TabIndex = 137;
            this.label11.Text = "无";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(289, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 136;
            this.label12.Text = "纬度";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("宋体", 21.5F);
            this.textBox3.Location = new System.Drawing.Point(255, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(210, 40);
            this.textBox3.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceQuickTab, "lng_dfm", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "000°00\'00.00\""));
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(126, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 134;
            this.label3.Text = "无";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(77, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 133;
            this.label10.Text = "经度";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("宋体", 21.5F);
            this.textBox2.Location = new System.Drawing.Point(45, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(210, 40);
            this.textBox2.TabIndex = 132;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(13, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 32);
            this.label9.TabIndex = 75;
            this.label9.Text = "速\r\n度\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(13, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 48);
            this.label8.TabIndex = 74;
            this.label8.Text = "E\r\nC\r\nU\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(13, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 64);
            this.label7.TabIndex = 73;
            this.label7.Text = "位\r\n置\r\n信\r\n息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(13, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 64);
            this.label6.TabIndex = 71;
            this.label6.Text = "飞\r\n控\r\n信\r\n息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceQuickTab, "telecommand", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "无指令"));
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(572, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "无";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(485, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 54;
            this.label4.Text = "指令回传";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 21.5F);
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(465, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(210, 40);
            this.textBox1.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceQuickTab, "ecu_errorno", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "no error"));
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(571, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "无";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(484, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 51;
            this.label5.Text = "ECU状态";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("宋体", 22F);
            this.textBox5.Location = new System.Drawing.Point(465, 257);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(210, 41);
            this.textBox5.TabIndex = 50;
            // 
            // tabControlactions
            // 
            this.tabControlactions.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlactions.Controls.Add(this.tabPage6);
            this.tabControlactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlactions.Location = new System.Drawing.Point(0, 32);
            this.tabControlactions.Name = "tabControlactions";
            this.tabControlactions.Padding = new System.Drawing.Point(0, 0);
            this.tabControlactions.SelectedIndex = 6;
            this.tabControlactions.Size = new System.Drawing.Size(737, 474);
            this.tabControlactions.TabIndex = 85;
            // 
            // quickView1
            // 
            this.quickView1.BackColor = System.Drawing.Color.Goldenrod;
            this.quickView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView1.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "groundspeed", true));
            this.quickView1.desc = "地速";
            this.quickView1.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView1.Location = new System.Drawing.Point(255, 296);
            this.quickView1.Name = "quickView1";
            this.quickView1.number = -9999D;
            this.quickView1.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView1.numberformat = "0.0m/s";
            this.quickView1.Size = new System.Drawing.Size(210, 40);
            this.quickView1.TabIndex = 177;
            // 
            // bindingSourceQuickTab
            // 
            this.bindingSourceQuickTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // quickView11
            // 
            this.quickView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView11.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "get4", true));
            this.quickView11.desc = "右尾反馈";
            this.quickView11.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView11.Location = new System.Drawing.Point(518, 374);
            this.quickView11.Name = "quickView11";
            this.quickView11.number = 0D;
            this.quickView11.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView11.numberformat = "0.00";
            this.quickView11.Size = new System.Drawing.Size(157, 40);
            this.quickView11.TabIndex = 173;
            // 
            // quickView12
            // 
            this.quickView12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView12.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "get3", true));
            this.quickView12.desc = "左尾反馈";
            this.quickView12.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView12.Location = new System.Drawing.Point(360, 374);
            this.quickView12.Name = "quickView12";
            this.quickView12.number = 0D;
            this.quickView12.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView12.numberformat = "0.00";
            this.quickView12.Size = new System.Drawing.Size(158, 40);
            this.quickView12.TabIndex = 172;
            // 
            // quickView13
            // 
            this.quickView13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView13.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "get2", true));
            this.quickView13.desc = "右副反馈";
            this.quickView13.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView13.Location = new System.Drawing.Point(202, 374);
            this.quickView13.Name = "quickView13";
            this.quickView13.number = 0D;
            this.quickView13.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView13.numberformat = "0.00";
            this.quickView13.Size = new System.Drawing.Size(158, 40);
            this.quickView13.TabIndex = 171;
            // 
            // quickView14
            // 
            this.quickView14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView14.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "get1", true));
            this.quickView14.desc = "左副反馈";
            this.quickView14.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView14.Location = new System.Drawing.Point(45, 374);
            this.quickView14.Name = "quickView14";
            this.quickView14.number = 0D;
            this.quickView14.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView14.numberformat = "0.00";
            this.quickView14.Size = new System.Drawing.Size(157, 40);
            this.quickView14.TabIndex = 170;
            // 
            // quickView10
            // 
            this.quickView10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quickView10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView10.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "set4", true));
            this.quickView10.desc = "右尾设定";
            this.quickView10.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView10.Location = new System.Drawing.Point(518, 335);
            this.quickView10.Name = "quickView10";
            this.quickView10.number = 0D;
            this.quickView10.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView10.numberformat = "0.00";
            this.quickView10.Size = new System.Drawing.Size(157, 40);
            this.quickView10.TabIndex = 169;
            // 
            // quickView9
            // 
            this.quickView9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quickView9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView9.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "set3", true));
            this.quickView9.desc = "左尾设定";
            this.quickView9.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView9.Location = new System.Drawing.Point(360, 335);
            this.quickView9.Name = "quickView9";
            this.quickView9.number = 0D;
            this.quickView9.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView9.numberformat = "0.00";
            this.quickView9.Size = new System.Drawing.Size(158, 40);
            this.quickView9.TabIndex = 168;
            // 
            // quickView8
            // 
            this.quickView8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quickView8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView8.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "set2", true));
            this.quickView8.desc = "右副设定";
            this.quickView8.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView8.Location = new System.Drawing.Point(202, 335);
            this.quickView8.Name = "quickView8";
            this.quickView8.number = 0D;
            this.quickView8.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView8.numberformat = "0.00";
            this.quickView8.Size = new System.Drawing.Size(158, 40);
            this.quickView8.TabIndex = 167;
            // 
            // quickView6
            // 
            this.quickView6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quickView6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView6.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "set1", true));
            this.quickView6.desc = "左副设定";
            this.quickView6.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView6.Location = new System.Drawing.Point(45, 335);
            this.quickView6.Name = "quickView6";
            this.quickView6.number = 0D;
            this.quickView6.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView6.numberformat = "0.00";
            this.quickView6.Size = new System.Drawing.Size(157, 40);
            this.quickView6.TabIndex = 166;
            // 
            // quickView3
            // 
            this.quickView3.BackColor = System.Drawing.Color.Goldenrod;
            this.quickView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView3.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "Accz", true));
            this.quickView3.desc = "法向过载";
            this.quickView3.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView3.Location = new System.Drawing.Point(45, 296);
            this.quickView3.Name = "quickView3";
            this.quickView3.number = -9999D;
            this.quickView3.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView3.numberformat = "0.00g";
            this.quickView3.Size = new System.Drawing.Size(210, 40);
            this.quickView3.TabIndex = 165;
            this.quickView3.Load += new System.EventHandler(this.quickView3_Load);
            // 
            // quickView2
            // 
            this.quickView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView2.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "alt", true));
            this.quickView2.desc = "高度表";
            this.quickView2.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView2.Location = new System.Drawing.Point(465, 179);
            this.quickView2.Name = "quickView2";
            this.quickView2.number = -9999D;
            this.quickView2.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView2.numberformat = "0.00m";
            this.quickView2.Size = new System.Drawing.Size(210, 40);
            this.quickView2.TabIndex = 138;
            // 
            // quickView55
            // 
            this.quickView55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.quickView55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView55.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "zuhe_altitude", true));
            this.quickView55.desc = "组合高度";
            this.quickView55.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView55.Location = new System.Drawing.Point(465, 101);
            this.quickView55.Name = "quickView55";
            this.quickView55.number = -9999D;
            this.quickView55.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView55.numberformat = "0.00m";
            this.quickView55.Size = new System.Drawing.Size(210, 40);
            this.quickView55.TabIndex = 61;
            // 
            // quickView52
            // 
            this.quickView52.BackColor = System.Drawing.Color.Goldenrod;
            this.quickView52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView52.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "air_speed", true));
            this.quickView52.desc = "垂速";
            this.quickView52.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView52.Location = new System.Drawing.Point(465, 296);
            this.quickView52.Name = "quickView52";
            this.quickView52.number = -9999D;
            this.quickView52.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView52.numberformat = "0.00m/s";
            this.quickView52.Size = new System.Drawing.Size(210, 40);
            this.quickView52.TabIndex = 57;
            // 
            // quickView5
            // 
            this.quickView5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quickView5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView5.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "ecu_pw", true));
            this.quickView5.desc = "温度";
            this.quickView5.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView5.Location = new System.Drawing.Point(45, 257);
            this.quickView5.Name = "quickView5";
            this.quickView5.number = -9999D;
            this.quickView5.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView5.numberformat = "0.00℃";
            this.quickView5.Size = new System.Drawing.Size(210, 40);
            this.quickView5.TabIndex = 49;
            // 
            // quickView7
            // 
            this.quickView7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView7.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "ecu_throttle", true));
            this.quickView7.desc = "耗油量";
            this.quickView7.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView7.Location = new System.Drawing.Point(465, 218);
            this.quickView7.Name = "quickView7";
            this.quickView7.number = -9999D;
            this.quickView7.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView7.numberformat = "0.000L";
            this.quickView7.Size = new System.Drawing.Size(210, 40);
            this.quickView7.TabIndex = 48;
            // 
            // quickView20
            // 
            this.quickView20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.quickView20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView20.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "distance_to_home", true));
            this.quickView20.desc = "距家距离";
            this.quickView20.Location = new System.Drawing.Point(255, 140);
            this.quickView20.Name = "quickView20";
            this.quickView20.number = -9999D;
            this.quickView20.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView20.numberformat = "0.000km";
            this.quickView20.Size = new System.Drawing.Size(210, 40);
            this.quickView20.TabIndex = 44;
            // 
            // quickView19
            // 
            this.quickView19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView19.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "wp_dist", true));
            this.quickView19.desc = "距下航点距离";
            this.quickView19.Location = new System.Drawing.Point(255, 179);
            this.quickView19.Name = "quickView19";
            this.quickView19.number = -9999D;
            this.quickView19.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView19.numberformat = "0.000km";
            this.quickView19.Size = new System.Drawing.Size(210, 40);
            this.quickView19.TabIndex = 43;
            // 
            // quickView4
            // 
            this.quickView4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView4.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "second_run", true));
            this.quickView4.desc = "航时";
            this.quickView4.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView4.Location = new System.Drawing.Point(45, 179);
            this.quickView4.Name = "quickView4";
            this.quickView4.number = -9999D;
            this.quickView4.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView4.numberformat = "0s";
            this.quickView4.Size = new System.Drawing.Size(210, 40);
            this.quickView4.TabIndex = 42;
            // 
            // quickView62
            // 
            this.quickView62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.quickView62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView62.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "air_altitude", true));
            this.quickView62.desc = "气压高度";
            this.quickView62.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView62.Location = new System.Drawing.Point(465, 140);
            this.quickView62.Name = "quickView62";
            this.quickView62.number = -9999D;
            this.quickView62.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView62.numberformat = "0.00m";
            this.quickView62.Size = new System.Drawing.Size(210, 40);
            this.quickView62.TabIndex = 30;
            // 
            // quickView63
            // 
            this.quickView63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView63.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "roll", true));
            this.quickView63.desc = "滚转";
            this.quickView63.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quickView63.Location = new System.Drawing.Point(45, 23);
            this.quickView63.Name = "quickView63";
            this.quickView63.number = -9999D;
            this.quickView63.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView63.numberformat = "0.00°";
            this.quickView63.Size = new System.Drawing.Size(210, 40);
            this.quickView63.TabIndex = 30;
            this.quickView63.Load += new System.EventHandler(this.quickView63_Load);
            // 
            // quickView64
            // 
            this.quickView64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView64.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "pitch", true));
            this.quickView64.desc = "俯仰";
            this.quickView64.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quickView64.Location = new System.Drawing.Point(255, 23);
            this.quickView64.Name = "quickView64";
            this.quickView64.number = -9999D;
            this.quickView64.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView64.numberformat = "0.00°";
            this.quickView64.Size = new System.Drawing.Size(210, 40);
            this.quickView64.TabIndex = 30;
            this.quickView64.Load += new System.EventHandler(this.quickView64_Load);
            // 
            // quickView65
            // 
            this.quickView65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView65.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "yaw", true));
            this.quickView65.desc = "偏航";
            this.quickView65.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView65.Location = new System.Drawing.Point(465, 23);
            this.quickView65.Name = "quickView65";
            this.quickView65.number = -9999D;
            this.quickView65.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView65.numberformat = "0.00°";
            this.quickView65.Size = new System.Drawing.Size(210, 40);
            this.quickView65.TabIndex = 30;
            this.quickView65.Load += new System.EventHandler(this.quickView65_Load);
            // 
            // quickView68
            // 
            this.quickView68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.quickView68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView68.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "wpno", true));
            this.quickView68.desc = "航点序号";
            this.quickView68.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView68.Location = new System.Drawing.Point(45, 140);
            this.quickView68.Name = "quickView68";
            this.quickView68.number = 0D;
            this.quickView68.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView68.numberformat = "00";
            this.quickView68.Size = new System.Drawing.Size(210, 40);
            this.quickView68.TabIndex = 30;
            // 
            // quickView69
            // 
            this.quickView69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView69.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "battery_voltage", true));
            this.quickView69.desc = "飞控电压";
            this.quickView69.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView69.Location = new System.Drawing.Point(45, 62);
            this.quickView69.Name = "quickView69";
            this.quickView69.number = -9999D;
            this.quickView69.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView69.numberformat = "0.0V";
            this.quickView69.Size = new System.Drawing.Size(210, 40);
            this.quickView69.TabIndex = 30;
            // 
            // quickView70
            // 
            this.quickView70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView70.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "ecu_voltage1", true));
            this.quickView70.desc = "ECU电压";
            this.quickView70.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView70.Location = new System.Drawing.Point(45, 218);
            this.quickView70.Name = "quickView70";
            this.quickView70.number = -9999D;
            this.quickView70.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView70.numberformat = "0.00V";
            this.quickView70.Size = new System.Drawing.Size(210, 40);
            this.quickView70.TabIndex = 30;
            // 
            // quickView72
            // 
            this.quickView72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView72.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "second_count", true));
            this.quickView72.desc = "秒计数";
            this.quickView72.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView72.Location = new System.Drawing.Point(255, 62);
            this.quickView72.Name = "quickView72";
            this.quickView72.number = 0D;
            this.quickView72.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView72.numberformat = "00";
            this.quickView72.Size = new System.Drawing.Size(210, 40);
            this.quickView72.TabIndex = 30;
            // 
            // quickView73
            // 
            this.quickView73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView73.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceQuickTab, "rpm", true));
            this.quickView73.desc = " 转速";
            this.quickView73.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView73.Location = new System.Drawing.Point(255, 218);
            this.quickView73.Name = "quickView73";
            this.quickView73.number = -9999D;
            this.quickView73.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView73.numberformat = "0.00万";
            this.quickView73.Size = new System.Drawing.Size(210, 40);
            this.quickView73.TabIndex = 30;
            // 
            // bindingSourceGaugesTab
            // 
            this.bindingSourceGaugesTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceStatusTab
            // 
            this.bindingSourceStatusTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // quickView34
            // 
            this.quickView34.desc = "Altitude:";
            this.quickView34.Location = new System.Drawing.Point(0, -15);
            this.quickView34.Name = "quickView34";
            this.quickView34.number = -9999D;
            this.quickView34.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView34.numberformat = "0.00";
            this.quickView34.Size = new System.Drawing.Size(122, 30);
            this.quickView34.TabIndex = 0;
            // 
            // quickView33
            // 
            this.quickView33.desc = "Altitude:";
            this.quickView33.Location = new System.Drawing.Point(0, -15);
            this.quickView33.Name = "quickView33";
            this.quickView33.number = -9999D;
            this.quickView33.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView33.numberformat = "0.00";
            this.quickView33.Size = new System.Drawing.Size(122, 30);
            this.quickView33.TabIndex = 0;
            // 
            // quickView32
            // 
            this.quickView32.desc = "Altitude:";
            this.quickView32.Location = new System.Drawing.Point(0, -15);
            this.quickView32.Name = "quickView32";
            this.quickView32.number = -9999D;
            this.quickView32.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView32.numberformat = "0.00";
            this.quickView32.Size = new System.Drawing.Size(122, 30);
            this.quickView32.TabIndex = 0;
            // 
            // quickView31
            // 
            this.quickView31.desc = "Altitude:";
            this.quickView31.Location = new System.Drawing.Point(0, -15);
            this.quickView31.Name = "quickView31";
            this.quickView31.number = -9999D;
            this.quickView31.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView31.numberformat = "0.00";
            this.quickView31.Size = new System.Drawing.Size(122, 30);
            this.quickView31.TabIndex = 0;
            // 
            // quickView30
            // 
            this.quickView30.desc = "Altitude:";
            this.quickView30.Location = new System.Drawing.Point(0, -15);
            this.quickView30.Name = "quickView30";
            this.quickView30.number = -9999D;
            this.quickView30.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView30.numberformat = "0.00";
            this.quickView30.Size = new System.Drawing.Size(122, 30);
            this.quickView30.TabIndex = 0;
            // 
            // quickView29
            // 
            this.quickView29.desc = "Altitude:";
            this.quickView29.Location = new System.Drawing.Point(0, -15);
            this.quickView29.Name = "quickView29";
            this.quickView29.number = -9999D;
            this.quickView29.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView29.numberformat = "0.00";
            this.quickView29.Size = new System.Drawing.Size(122, 30);
            this.quickView29.TabIndex = 0;
            // 
            // quickView28
            // 
            this.quickView28.desc = "Altitude:";
            this.quickView28.Location = new System.Drawing.Point(0, -15);
            this.quickView28.Name = "quickView28";
            this.quickView28.number = -9999D;
            this.quickView28.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView28.numberformat = "0.00";
            this.quickView28.Size = new System.Drawing.Size(122, 30);
            this.quickView28.TabIndex = 0;
            // 
            // quickView27
            // 
            this.quickView27.desc = "Altitude:";
            this.quickView27.Location = new System.Drawing.Point(0, -15);
            this.quickView27.Name = "quickView27";
            this.quickView27.number = -9999D;
            this.quickView27.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView27.numberformat = "0.00";
            this.quickView27.Size = new System.Drawing.Size(122, 30);
            this.quickView27.TabIndex = 0;
            // 
            // quickView26
            // 
            this.quickView26.desc = "Altitude:";
            this.quickView26.Location = new System.Drawing.Point(0, -15);
            this.quickView26.Name = "quickView26";
            this.quickView26.number = -9999D;
            this.quickView26.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView26.numberformat = "0.00";
            this.quickView26.Size = new System.Drawing.Size(122, 30);
            this.quickView26.TabIndex = 0;
            // 
            // quickView25
            // 
            this.quickView25.desc = "Altitude:";
            this.quickView25.Location = new System.Drawing.Point(0, -15);
            this.quickView25.Name = "quickView25";
            this.quickView25.number = -9999D;
            this.quickView25.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView25.numberformat = "0.00";
            this.quickView25.Size = new System.Drawing.Size(122, 30);
            this.quickView25.TabIndex = 0;
            // 
            // TelemetryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 506);
            this.Controls.Add(this.tabControlactions);
            this.Controls.Add(this.tabStatus);
            this.Name = "TelemetryFrm";
            this.Text = "遥测";
            this.Load += new System.EventHandler(this.TelemetryFrm_Load);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabControlactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel tabStatus;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.BindingSource bindingSourceGaugesTab;
        public System.Windows.Forms.BindingSource bindingSourceQuickTab;
        public System.Windows.Forms.BindingSource bindingSourceStatusTab;
        private MissionPlanner.Arduino.ArduinoSTK arduinoSTK1;
        private MissionPlanner.Controls.QuickView quickView34;
        private MissionPlanner.Controls.QuickView quickView33;
        private MissionPlanner.Controls.QuickView quickView32;
        private MissionPlanner.Controls.QuickView quickView31;
        private MissionPlanner.Controls.QuickView quickView30;
        private MissionPlanner.Controls.QuickView quickView29;
        private MissionPlanner.Controls.QuickView quickView28;
        private MissionPlanner.Controls.QuickView quickView27;
        private MissionPlanner.Controls.QuickView quickView26;
        private MissionPlanner.Controls.QuickView quickView25;
        private System.Windows.Forms.TabPage tabPage6;
        private MissionPlanner.Controls.QuickView quickView62;
        private MissionPlanner.Controls.QuickView quickView63;
        private MissionPlanner.Controls.QuickView quickView64;
        private MissionPlanner.Controls.QuickView quickView65;
        private MissionPlanner.Controls.QuickView quickView68;
        private MissionPlanner.Controls.QuickView quickView69;
        private MissionPlanner.Controls.QuickView quickView70;
        private MissionPlanner.Controls.QuickView quickView72;
        private MissionPlanner.Controls.QuickView quickView73;
        public System.Windows.Forms.TabControl tabControlactions;
        private MissionPlanner.Controls.QuickView quickView4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private MissionPlanner.Controls.QuickView quickView5;
        private MissionPlanner.Controls.QuickView quickView7;
        private MissionPlanner.Controls.QuickView quickView20;
        private MissionPlanner.Controls.QuickView quickView19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private MissionPlanner.Controls.QuickView quickView55;
        private MissionPlanner.Controls.QuickView quickView52;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private MissionPlanner.Controls.QuickView quickView2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label30;
        private MissionPlanner.Controls.QuickView quickView3;
        private MissionPlanner.Controls.QuickView quickView11;
        private MissionPlanner.Controls.QuickView quickView12;
        private MissionPlanner.Controls.QuickView quickView13;
        private MissionPlanner.Controls.QuickView quickView14;
        private MissionPlanner.Controls.QuickView quickView10;
        private MissionPlanner.Controls.QuickView quickView9;
        private MissionPlanner.Controls.QuickView quickView8;
        private MissionPlanner.Controls.QuickView quickView6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox4;
        private MissionPlanner.Controls.QuickView quickView1;
      
    }
}