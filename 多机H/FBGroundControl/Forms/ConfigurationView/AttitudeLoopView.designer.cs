using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class AttitudeLoopView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.search_button = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.attitudeloop_remaind1_r_textBox = new System.Windows.Forms.TextBox();
            this.roll_kd_r_textBox = new System.Windows.Forms.TextBox();
            this.roll_ki_r_textBox = new System.Windows.Forms.TextBox();
            this.roll_kp_r_textBox = new System.Windows.Forms.TextBox();
            this.attitudeloop_remaind1_textBox = new System.Windows.Forms.TextBox();
            this.roll_kd_textBox = new System.Windows.Forms.TextBox();
            this.roll_ki_textBox = new System.Windows.Forms.TextBox();
            this.roll_kp_textBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pitch_ki_u_textBox = new System.Windows.Forms.TextBox();
            this.pitch_kd_u_textBox = new System.Windows.Forms.TextBox();
            this.attitudeloop_remaind2_u_textBox = new System.Windows.Forms.TextBox();
            this.pitch_kp_u_textBox = new System.Windows.Forms.TextBox();
            this.attitudeloop_remaind2_textBox = new System.Windows.Forms.TextBox();
            this.pitch_kd_textBox = new System.Windows.Forms.TextBox();
            this.pitch_ki_textBox = new System.Windows.Forms.TextBox();
            this.pitch_kp_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.heading_offset_kp_y_textBox = new System.Windows.Forms.TextBox();
            this.heading_offset_ki_y_textBox = new System.Windows.Forms.TextBox();
            this.heading_offset_kd_y_textBox = new System.Windows.Forms.TextBox();
            this.attitudeloop_remaind3_y_textBox = new System.Windows.Forms.TextBox();
            this.attitudeloop_remaind3_textBox = new System.Windows.Forms.TextBox();
            this.heading_offset_kd_textBox = new System.Windows.Forms.TextBox();
            this.heading_offset_ki_textBox = new System.Windows.Forms.TextBox();
            this.heading_offset_kp_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.setup_button = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.groupBox25.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(749, 401);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.attitudeloop_remaind1_r_textBox);
            this.groupBox25.Controls.Add(this.roll_kd_r_textBox);
            this.groupBox25.Controls.Add(this.roll_ki_r_textBox);
            this.groupBox25.Controls.Add(this.roll_kp_r_textBox);
            this.groupBox25.Controls.Add(this.attitudeloop_remaind1_textBox);
            this.groupBox25.Controls.Add(this.roll_kd_textBox);
            this.groupBox25.Controls.Add(this.roll_ki_textBox);
            this.groupBox25.Controls.Add(this.roll_kp_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label88);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(87, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(238, 241);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "滚转";
            // 
            // attitudeloop_remaind1_r_textBox
            // 
            this.attitudeloop_remaind1_r_textBox.Enabled = false;
            this.attitudeloop_remaind1_r_textBox.Location = new System.Drawing.Point(58, 180);
            this.attitudeloop_remaind1_r_textBox.Name = "attitudeloop_remaind1_r_textBox";
            this.attitudeloop_remaind1_r_textBox.Size = new System.Drawing.Size(77, 21);
            this.attitudeloop_remaind1_r_textBox.TabIndex = 15;
            // 
            // roll_kd_r_textBox
            // 
            this.roll_kd_r_textBox.Enabled = false;
            this.roll_kd_r_textBox.Location = new System.Drawing.Point(58, 129);
            this.roll_kd_r_textBox.Name = "roll_kd_r_textBox";
            this.roll_kd_r_textBox.Size = new System.Drawing.Size(77, 21);
            this.roll_kd_r_textBox.TabIndex = 14;
            // 
            // roll_ki_r_textBox
            // 
            this.roll_ki_r_textBox.Enabled = false;
            this.roll_ki_r_textBox.Location = new System.Drawing.Point(58, 73);
            this.roll_ki_r_textBox.Name = "roll_ki_r_textBox";
            this.roll_ki_r_textBox.Size = new System.Drawing.Size(77, 21);
            this.roll_ki_r_textBox.TabIndex = 13;
            // 
            // roll_kp_r_textBox
            // 
            this.roll_kp_r_textBox.Enabled = false;
            this.roll_kp_r_textBox.Location = new System.Drawing.Point(58, 15);
            this.roll_kp_r_textBox.Name = "roll_kp_r_textBox";
            this.roll_kp_r_textBox.Size = new System.Drawing.Size(77, 21);
            this.roll_kp_r_textBox.TabIndex = 12;
            // 
            // attitudeloop_remaind1_textBox
            // 
            this.attitudeloop_remaind1_textBox.Location = new System.Drawing.Point(141, 180);
            this.attitudeloop_remaind1_textBox.Name = "attitudeloop_remaind1_textBox";
            this.attitudeloop_remaind1_textBox.Size = new System.Drawing.Size(75, 21);
            this.attitudeloop_remaind1_textBox.TabIndex = 11;
            this.attitudeloop_remaind1_textBox.Text = "0";
            // 
            // roll_kd_textBox
            // 
            this.roll_kd_textBox.Location = new System.Drawing.Point(142, 129);
            this.roll_kd_textBox.Name = "roll_kd_textBox";
            this.roll_kd_textBox.Size = new System.Drawing.Size(74, 21);
            this.roll_kd_textBox.TabIndex = 10;
            this.roll_kd_textBox.Text = "0";
            // 
            // roll_ki_textBox
            // 
            this.roll_ki_textBox.Location = new System.Drawing.Point(141, 73);
            this.roll_ki_textBox.Name = "roll_ki_textBox";
            this.roll_ki_textBox.Size = new System.Drawing.Size(75, 21);
            this.roll_ki_textBox.TabIndex = 9;
            this.roll_ki_textBox.Text = "0";
            // 
            // roll_kp_textBox
            // 
            this.roll_kp_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roll_kp_textBox.Location = new System.Drawing.Point(142, 15);
            this.roll_kp_textBox.Name = "roll_kp_textBox";
            this.roll_kp_textBox.Size = new System.Drawing.Size(75, 21);
            this.roll_kp_textBox.TabIndex = 8;
            this.roll_kp_textBox.Text = "0";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "D";
            // 
            // label88
            // 
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(6, 188);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(68, 13);
            this.label88.TabIndex = 6;
            this.label88.Text = "预留";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 81);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(10, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "I";
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(6, 18);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(14, 13);
            this.label91.TabIndex = 0;
            this.label91.Text = "P";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "姿态环参数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pitch_ki_u_textBox);
            this.groupBox1.Controls.Add(this.pitch_kd_u_textBox);
            this.groupBox1.Controls.Add(this.attitudeloop_remaind2_u_textBox);
            this.groupBox1.Controls.Add(this.pitch_kp_u_textBox);
            this.groupBox1.Controls.Add(this.attitudeloop_remaind2_textBox);
            this.groupBox1.Controls.Add(this.pitch_kd_textBox);
            this.groupBox1.Controls.Add(this.pitch_ki_textBox);
            this.groupBox1.Controls.Add(this.pitch_kp_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(379, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 241);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "俯仰";
            // 
            // pitch_ki_u_textBox
            // 
            this.pitch_ki_u_textBox.Enabled = false;
            this.pitch_ki_u_textBox.Location = new System.Drawing.Point(50, 73);
            this.pitch_ki_u_textBox.Name = "pitch_ki_u_textBox";
            this.pitch_ki_u_textBox.Size = new System.Drawing.Size(77, 21);
            this.pitch_ki_u_textBox.TabIndex = 16;
            // 
            // pitch_kd_u_textBox
            // 
            this.pitch_kd_u_textBox.Enabled = false;
            this.pitch_kd_u_textBox.Location = new System.Drawing.Point(50, 129);
            this.pitch_kd_u_textBox.Name = "pitch_kd_u_textBox";
            this.pitch_kd_u_textBox.Size = new System.Drawing.Size(77, 21);
            this.pitch_kd_u_textBox.TabIndex = 15;
            // 
            // attitudeloop_remaind2_u_textBox
            // 
            this.attitudeloop_remaind2_u_textBox.Enabled = false;
            this.attitudeloop_remaind2_u_textBox.Location = new System.Drawing.Point(50, 180);
            this.attitudeloop_remaind2_u_textBox.Name = "attitudeloop_remaind2_u_textBox";
            this.attitudeloop_remaind2_u_textBox.Size = new System.Drawing.Size(77, 21);
            this.attitudeloop_remaind2_u_textBox.TabIndex = 14;
            // 
            // pitch_kp_u_textBox
            // 
            this.pitch_kp_u_textBox.Enabled = false;
            this.pitch_kp_u_textBox.Location = new System.Drawing.Point(50, 15);
            this.pitch_kp_u_textBox.Name = "pitch_kp_u_textBox";
            this.pitch_kp_u_textBox.Size = new System.Drawing.Size(77, 21);
            this.pitch_kp_u_textBox.TabIndex = 13;
            // 
            // attitudeloop_remaind2_textBox
            // 
            this.attitudeloop_remaind2_textBox.Location = new System.Drawing.Point(133, 180);
            this.attitudeloop_remaind2_textBox.Name = "attitudeloop_remaind2_textBox";
            this.attitudeloop_remaind2_textBox.Size = new System.Drawing.Size(84, 21);
            this.attitudeloop_remaind2_textBox.TabIndex = 11;
            this.attitudeloop_remaind2_textBox.Text = "0";
            // 
            // pitch_kd_textBox
            // 
            this.pitch_kd_textBox.Location = new System.Drawing.Point(133, 129);
            this.pitch_kd_textBox.Name = "pitch_kd_textBox";
            this.pitch_kd_textBox.Size = new System.Drawing.Size(84, 21);
            this.pitch_kd_textBox.TabIndex = 10;
            this.pitch_kd_textBox.Text = "0";
            // 
            // pitch_ki_textBox
            // 
            this.pitch_ki_textBox.Location = new System.Drawing.Point(133, 73);
            this.pitch_ki_textBox.Name = "pitch_ki_textBox";
            this.pitch_ki_textBox.Size = new System.Drawing.Size(84, 21);
            this.pitch_ki_textBox.TabIndex = 9;
            this.pitch_ki_textBox.Text = "0";
            // 
            // pitch_kp_textBox
            // 
            this.pitch_kp_textBox.Location = new System.Drawing.Point(133, 15);
            this.pitch_kp_textBox.Name = "pitch_kp_textBox";
            this.pitch_kp_textBox.Size = new System.Drawing.Size(84, 21);
            this.pitch_kp_textBox.TabIndex = 8;
            this.pitch_kp_textBox.Text = "0";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "D";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "预留";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "I";
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "P";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.heading_offset_kp_y_textBox);
            this.groupBox2.Controls.Add(this.heading_offset_ki_y_textBox);
            this.groupBox2.Controls.Add(this.heading_offset_kd_y_textBox);
            this.groupBox2.Controls.Add(this.attitudeloop_remaind3_y_textBox);
            this.groupBox2.Controls.Add(this.attitudeloop_remaind3_textBox);
            this.groupBox2.Controls.Add(this.heading_offset_kd_textBox);
            this.groupBox2.Controls.Add(this.heading_offset_ki_textBox);
            this.groupBox2.Controls.Add(this.heading_offset_kp_textBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(672, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 241);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "偏航";
            // 
            // heading_offset_kp_y_textBox
            // 
            this.heading_offset_kp_y_textBox.Enabled = false;
            this.heading_offset_kp_y_textBox.Location = new System.Drawing.Point(53, 15);
            this.heading_offset_kp_y_textBox.Name = "heading_offset_kp_y_textBox";
            this.heading_offset_kp_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_kp_y_textBox.TabIndex = 15;
            // 
            // heading_offset_ki_y_textBox
            // 
            this.heading_offset_ki_y_textBox.Enabled = false;
            this.heading_offset_ki_y_textBox.Location = new System.Drawing.Point(53, 70);
            this.heading_offset_ki_y_textBox.Name = "heading_offset_ki_y_textBox";
            this.heading_offset_ki_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_ki_y_textBox.TabIndex = 14;
            // 
            // heading_offset_kd_y_textBox
            // 
            this.heading_offset_kd_y_textBox.Enabled = false;
            this.heading_offset_kd_y_textBox.Location = new System.Drawing.Point(53, 129);
            this.heading_offset_kd_y_textBox.Name = "heading_offset_kd_y_textBox";
            this.heading_offset_kd_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_kd_y_textBox.TabIndex = 13;
            // 
            // attitudeloop_remaind3_y_textBox
            // 
            this.attitudeloop_remaind3_y_textBox.Enabled = false;
            this.attitudeloop_remaind3_y_textBox.Location = new System.Drawing.Point(53, 180);
            this.attitudeloop_remaind3_y_textBox.Name = "attitudeloop_remaind3_y_textBox";
            this.attitudeloop_remaind3_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.attitudeloop_remaind3_y_textBox.TabIndex = 12;
            // 
            // attitudeloop_remaind3_textBox
            // 
            this.attitudeloop_remaind3_textBox.Location = new System.Drawing.Point(143, 180);
            this.attitudeloop_remaind3_textBox.Name = "attitudeloop_remaind3_textBox";
            this.attitudeloop_remaind3_textBox.Size = new System.Drawing.Size(84, 21);
            this.attitudeloop_remaind3_textBox.TabIndex = 11;
            this.attitudeloop_remaind3_textBox.Text = "0";
            // 
            // heading_offset_kd_textBox
            // 
            this.heading_offset_kd_textBox.Location = new System.Drawing.Point(143, 129);
            this.heading_offset_kd_textBox.Name = "heading_offset_kd_textBox";
            this.heading_offset_kd_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_kd_textBox.TabIndex = 10;
            this.heading_offset_kd_textBox.Text = "0";
            // 
            // heading_offset_ki_textBox
            // 
            this.heading_offset_ki_textBox.Location = new System.Drawing.Point(143, 70);
            this.heading_offset_ki_textBox.Name = "heading_offset_ki_textBox";
            this.heading_offset_ki_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_ki_textBox.TabIndex = 9;
            this.heading_offset_ki_textBox.Text = "0";
            // 
            // heading_offset_kp_textBox
            // 
            this.heading_offset_kp_textBox.Location = new System.Drawing.Point(143, 15);
            this.heading_offset_kp_textBox.Name = "heading_offset_kp_textBox";
            this.heading_offset_kp_textBox.Size = new System.Drawing.Size(84, 21);
            this.heading_offset_kp_textBox.TabIndex = 8;
            this.heading_offset_kp_textBox.Text = "0";
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "D";
            // 
            // label7
            // 
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(6, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "预留";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "I";
            // 
            // label9
            // 
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "P";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(830, 401);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 10;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(87, 401);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 11;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button1_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(168, 401);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 12;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.button2_Click);
            // 
            // AttitudeLoopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Import);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.search_button);
            this.Name = "AttitudeLoopView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.AttitudeLoopView_Load);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox attitudeloop_remaind1_textBox;
        private System.Windows.Forms.TextBox roll_kd_textBox;
        private System.Windows.Forms.TextBox roll_ki_textBox;
        private System.Windows.Forms.TextBox roll_kp_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox attitudeloop_remaind2_textBox;
        private System.Windows.Forms.TextBox pitch_kd_textBox;
        private System.Windows.Forms.TextBox pitch_ki_textBox;
        private System.Windows.Forms.TextBox pitch_kp_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox attitudeloop_remaind3_textBox;
        private System.Windows.Forms.TextBox heading_offset_kd_textBox;
        private System.Windows.Forms.TextBox heading_offset_ki_textBox;
        private System.Windows.Forms.TextBox heading_offset_kp_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.TextBox roll_kp_r_textBox;
        private System.Windows.Forms.TextBox roll_ki_r_textBox;
        private System.Windows.Forms.TextBox attitudeloop_remaind1_r_textBox;
        private System.Windows.Forms.TextBox roll_kd_r_textBox;
        private System.Windows.Forms.TextBox pitch_ki_u_textBox;
        private System.Windows.Forms.TextBox pitch_kd_u_textBox;
        private System.Windows.Forms.TextBox attitudeloop_remaind2_u_textBox;
        private System.Windows.Forms.TextBox pitch_kp_u_textBox;
        private System.Windows.Forms.TextBox heading_offset_kp_y_textBox;
        private System.Windows.Forms.TextBox heading_offset_ki_y_textBox;
        private System.Windows.Forms.TextBox heading_offset_kd_y_textBox;
        private System.Windows.Forms.TextBox attitudeloop_remaind3_y_textBox;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Import;
    }
}
