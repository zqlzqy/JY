namespace FBGroundControl.Forms
{
    partial class Ganraoji
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
            this.bindingSourceGanraoji = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.quickView13 = new MissionPlanner.Controls.QuickView();
            this.quickView10 = new MissionPlanner.Controls.QuickView();
            this.quickView12 = new MissionPlanner.Controls.QuickView();
            this.quickView9 = new MissionPlanner.Controls.QuickView();
            this.quickView6 = new MissionPlanner.Controls.QuickView();
            this.quickView5 = new MissionPlanner.Controls.QuickView();
            this.quickView4 = new MissionPlanner.Controls.QuickView();
            this.quickView3 = new MissionPlanner.Controls.QuickView();
            this.quickView72 = new MissionPlanner.Controls.QuickView();
            this.quickView1 = new MissionPlanner.Controls.QuickView();
            this.button1 = new System.Windows.Forms.Button();
            this.command_com = new System.Windows.Forms.ComboBox();
            this.id_textBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.quickView11 = new MissionPlanner.Controls.QuickView();
            this.quickView14 = new MissionPlanner.Controls.QuickView();
            this.quickView2 = new MissionPlanner.Controls.QuickView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGanraoji)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceGanraoji
            // 
            this.bindingSourceGanraoji.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MistyRose;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceGanraoji, "grj_command", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "无"));
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(580, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "无";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MistyRose;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(493, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 61;
            this.label3.Text = "指令回报";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.MistyRose;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox2.Location = new System.Drawing.Point(486, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(159, 35);
            this.textBox2.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.MistyRose;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceGanraoji, "grj_lmd", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "无"));
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(279, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 65;
            this.label5.Text = "无";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.MistyRose;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(182, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 64;
            this.label6.Text = "灵敏度";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.MistyRose;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox3.Location = new System.Drawing.Point(170, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(159, 35);
            this.textBox3.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.MistyRose;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceGanraoji, "grj_qptd", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "无"));
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(434, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 71;
            this.label9.Text = "无";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.MistyRose;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(335, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 70;
            this.label10.Text = "欺骗通道";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.MistyRose;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox5.Location = new System.Drawing.Point(328, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(159, 35);
            this.textBox5.TabIndex = 69;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.MistyRose;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceGanraoji, "grj_yztd", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "无"));
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(580, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 74;
            this.label11.Text = "无";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.MistyRose;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(493, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 73;
            this.label12.Text = "压制通道";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.MistyRose;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox6.Location = new System.Drawing.Point(486, 46);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(159, 35);
            this.textBox6.TabIndex = 72;
            // 
            // quickView13
            // 
            this.quickView13.BackColor = System.Drawing.Color.MistyRose;
            this.quickView13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView13.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_ld4pl", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView13.desc = "压制编号";
            this.quickView13.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView13.Location = new System.Drawing.Point(170, 148);
            this.quickView13.Name = "quickView13";
            this.quickView13.number = -9999D;
            this.quickView13.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView13.numberformat = "0";
            this.quickView13.Size = new System.Drawing.Size(159, 35);
            this.quickView13.TabIndex = 90;
            // 
            // quickView10
            // 
            this.quickView10.BackColor = System.Drawing.Color.MistyRose;
            this.quickView10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView10.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_ld3pl", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView10.desc = "欺骗编号";
            this.quickView10.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView10.Location = new System.Drawing.Point(12, 148);
            this.quickView10.Name = "quickView10";
            this.quickView10.number = -9999D;
            this.quickView10.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView10.numberformat = "0";
            this.quickView10.Size = new System.Drawing.Size(159, 35);
            this.quickView10.TabIndex = 89;
            // 
            // quickView12
            // 
            this.quickView12.BackColor = System.Drawing.Color.MistyRose;
            this.quickView12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView12.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_count", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView12.desc = "假目标个数";
            this.quickView12.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView12.Location = new System.Drawing.Point(486, 114);
            this.quickView12.Name = "quickView12";
            this.quickView12.number = 0D;
            this.quickView12.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView12.numberformat = "00";
            this.quickView12.Size = new System.Drawing.Size(159, 35);
            this.quickView12.TabIndex = 87;
            // 
            // quickView9
            // 
            this.quickView9.BackColor = System.Drawing.Color.MistyRose;
            this.quickView9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView9.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_yzzsdk", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView9.desc = "压制噪声带宽";
            this.quickView9.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView9.Location = new System.Drawing.Point(170, 114);
            this.quickView9.Name = "quickView9";
            this.quickView9.number = -9999D;
            this.quickView9.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView9.numberformat = "0.00MHz";
            this.quickView9.Size = new System.Drawing.Size(159, 35);
            this.quickView9.TabIndex = 82;
            // 
            // quickView6
            // 
            this.quickView6.BackColor = System.Drawing.Color.MistyRose;
            this.quickView6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView6.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "task_b", true));
            this.quickView6.desc = "任务版本";
            this.quickView6.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView6.Location = new System.Drawing.Point(12, 114);
            this.quickView6.Name = "quickView6";
            this.quickView6.number = -9999D;
            this.quickView6.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView6.numberformat = "0";
            this.quickView6.Size = new System.Drawing.Size(159, 35);
            this.quickView6.TabIndex = 79;
            // 
            // quickView5
            // 
            this.quickView5.BackColor = System.Drawing.Color.MistyRose;
            this.quickView5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView5.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_mk", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView5.desc = "脉宽";
            this.quickView5.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView5.Location = new System.Drawing.Point(486, 80);
            this.quickView5.Name = "quickView5";
            this.quickView5.number = -9999D;
            this.quickView5.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView5.numberformat = "0.00μs";
            this.quickView5.Size = new System.Drawing.Size(159, 35);
            this.quickView5.TabIndex = 78;
            // 
            // quickView4
            // 
            this.quickView4.BackColor = System.Drawing.Color.MistyRose;
            this.quickView4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView4.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_cfzq", true));
            this.quickView4.desc = "重复周期";
            this.quickView4.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView4.Location = new System.Drawing.Point(328, 80);
            this.quickView4.Name = "quickView4";
            this.quickView4.number = -9999D;
            this.quickView4.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView4.numberformat = "0.0μs";
            this.quickView4.Size = new System.Drawing.Size(159, 35);
            this.quickView4.TabIndex = 77;
            // 
            // quickView3
            // 
            this.quickView3.BackColor = System.Drawing.Color.MistyRose;
            this.quickView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView3.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_zsldpl", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView3.desc = "侦收雷达频率";
            this.quickView3.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView3.Location = new System.Drawing.Point(170, 80);
            this.quickView3.Name = "quickView3";
            this.quickView3.number = -9999D;
            this.quickView3.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView3.numberformat = "0MHz";
            this.quickView3.Size = new System.Drawing.Size(159, 35);
            this.quickView3.TabIndex = 76;
            // 
            // quickView72
            // 
            this.quickView72.BackColor = System.Drawing.Color.MistyRose;
            this.quickView72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView72.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_second", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView72.desc = "帧计数";
            this.quickView72.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView72.Location = new System.Drawing.Point(12, 12);
            this.quickView72.Name = "quickView72";
            this.quickView72.number = -9999D;
            this.quickView72.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView72.numberformat = "0";
            this.quickView72.Size = new System.Drawing.Size(159, 35);
            this.quickView72.TabIndex = 56;
            // 
            // quickView1
            // 
            this.quickView1.BackColor = System.Drawing.Color.MistyRose;
            this.quickView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView1.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_temp", true));
            this.quickView1.desc = "设备温度";
            this.quickView1.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView1.Location = new System.Drawing.Point(328, 12);
            this.quickView1.Name = "quickView1";
            this.quickView1.number = -9999D;
            this.quickView1.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView1.numberformat = "0℃";
            this.quickView1.Size = new System.Drawing.Size(159, 35);
            this.quickView1.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 29);
            this.button1.TabIndex = 94;
            this.button1.Text = "上传指令";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // command_com
            // 
            this.command_com.FormattingEnabled = true;
            this.command_com.Items.AddRange(new object[] {
            "开干扰",
            "关干扰",
            "任务1",
            "任务2",
            "任务3",
            "任务4",
            "任务5",
            "任务6",
            "任务7",
            "任务8",
            "自检",
            "待机",
            "卸载数据",
            "备份1",
            "备份2"});
            this.command_com.Location = new System.Drawing.Point(737, 81);
            this.command_com.Name = "command_com";
            this.command_com.Size = new System.Drawing.Size(82, 20);
            this.command_com.TabIndex = 96;
            // 
            // id_textBox
            // 
            this.id_textBox.Location = new System.Drawing.Point(736, 22);
            this.id_textBox.Name = "id_textBox";
            this.id_textBox.Size = new System.Drawing.Size(83, 21);
            this.id_textBox.TabIndex = 95;
            this.id_textBox.Text = "0";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(675, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 92;
            this.label17.Text = "飞机号";
            // 
            // label88
            // 
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(675, 84);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(68, 13);
            this.label88.TabIndex = 93;
            this.label88.Text = "开关指令";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MistyRose;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(177, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "信息类别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceGanraoji, "leibie", true));
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(264, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "无";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MistyRose;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox1.Location = new System.Drawing.Point(170, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(159, 35);
            this.textBox1.TabIndex = 57;
            // 
            // quickView11
            // 
            this.quickView11.BackColor = System.Drawing.Color.MistyRose;
            this.quickView11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView11.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_id", true));
            this.quickView11.desc = "设备ID";
            this.quickView11.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView11.Location = new System.Drawing.Point(12, 46);
            this.quickView11.Name = "quickView11";
            this.quickView11.number = -9999D;
            this.quickView11.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView11.numberformat = "0";
            this.quickView11.Size = new System.Drawing.Size(159, 35);
            this.quickView11.TabIndex = 97;
            // 
            // quickView14
            // 
            this.quickView14.BackColor = System.Drawing.Color.MistyRose;
            this.quickView14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView14.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "task_id", true));
            this.quickView14.desc = "任务号";
            this.quickView14.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView14.Location = new System.Drawing.Point(12, 80);
            this.quickView14.Name = "quickView14";
            this.quickView14.number = -9999D;
            this.quickView14.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView14.numberformat = "0";
            this.quickView14.Size = new System.Drawing.Size(159, 35);
            this.quickView14.TabIndex = 98;
            // 
            // quickView2
            // 
            this.quickView2.BackColor = System.Drawing.Color.MistyRose;
            this.quickView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView2.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSourceGanraoji, "grj_secCount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0"));
            this.quickView2.desc = "秒脉冲计数";
            this.quickView2.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView2.Location = new System.Drawing.Point(328, 114);
            this.quickView2.Name = "quickView2";
            this.quickView2.number = -9999D;
            this.quickView2.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView2.numberformat = "00";
            this.quickView2.Size = new System.Drawing.Size(159, 35);
            this.quickView2.TabIndex = 99;
            // 
            // Ganraoji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 439);
            this.CloseButton = false;
            this.Controls.Add(this.quickView2);
            this.Controls.Add(this.quickView14);
            this.Controls.Add(this.quickView11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.command_com);
            this.Controls.Add(this.id_textBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.quickView1);
            this.Controls.Add(this.quickView13);
            this.Controls.Add(this.quickView10);
            this.Controls.Add(this.quickView12);
            this.Controls.Add(this.quickView9);
            this.Controls.Add(this.quickView6);
            this.Controls.Add(this.quickView5);
            this.Controls.Add(this.quickView4);
            this.Controls.Add(this.quickView3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.quickView72);
            this.Name = "Ganraoji";
            this.Text = "干扰机";
            this.Load += new System.EventHandler(this.Ganraoji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGanraoji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MissionPlanner.Controls.QuickView quickView72;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private MissionPlanner.Controls.QuickView quickView3;
        private MissionPlanner.Controls.QuickView quickView4;
        private MissionPlanner.Controls.QuickView quickView5;
        private MissionPlanner.Controls.QuickView quickView6;
        private MissionPlanner.Controls.QuickView quickView9;
        private MissionPlanner.Controls.QuickView quickView10;
        private MissionPlanner.Controls.QuickView quickView12;
        private MissionPlanner.Controls.QuickView quickView13;
        public System.Windows.Forms.BindingSource bindingSourceGanraoji;
        private MissionPlanner.Controls.QuickView quickView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox command_com;
        private System.Windows.Forms.TextBox id_textBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private MissionPlanner.Controls.QuickView quickView11;
        private MissionPlanner.Controls.QuickView quickView14;
        private MissionPlanner.Controls.QuickView quickView2;
    }
}