using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class LimitView
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
            this.label1 = new System.Windows.Forms.Label();
            this.setup_button = new System.Windows.Forms.Button();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.aileron_textBox = new System.Windows.Forms.TextBox();
            this.elevator_textBox = new System.Windows.Forms.TextBox();
            this.rudder_textBox = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.roll_angle_l_textBox = new System.Windows.Forms.TextBox();
            this.stall_speed_l_textBox = new System.Windows.Forms.TextBox();
            this.max_airspeed_l_textBox = new System.Windows.Forms.TextBox();
            this.max_lateral_overload_l_textBox = new System.Windows.Forms.TextBox();
            this.reserve_l_textBox = new System.Windows.Forms.TextBox();
            this.min_pitch_angle_l_textBox = new System.Windows.Forms.TextBox();
            this.elevator_l_textBox = new System.Windows.Forms.TextBox();
            this.rudder_l_textBox = new System.Windows.Forms.TextBox();
            this.frontwheel_l_textBox = new System.Windows.Forms.TextBox();
            this.max_throttle_l_textBox = new System.Windows.Forms.TextBox();
            this.min_throttle_l_textBox = new System.Windows.Forms.TextBox();
            this.max_pitch_angle_l_textBox = new System.Windows.Forms.TextBox();
            this.aileron_l_textBox = new System.Windows.Forms.TextBox();
            this.reserve_textBox = new System.Windows.Forms.TextBox();
            this.max_lateral_overload_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.max_airspeed_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stall_speed_textBox = new System.Windows.Forms.TextBox();
            this.roll_angle_textBox = new System.Windows.Forms.TextBox();
            this.min_pitch_angle_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.max_pitch_angle_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.min_throttle_textBox = new System.Windows.Forms.TextBox();
            this.max_throttle_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.frontwheel_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(590, 436);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "极限参数";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(671, 436);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 10;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(6, 18);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(84, 13);
            this.label91.TabIndex = 0;
            this.label91.Text = "副翼限幅";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 57);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(84, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "升降舵限幅";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "方向舵限幅";
            // 
            // aileron_textBox
            // 
            this.aileron_textBox.Location = new System.Drawing.Point(185, 15);
            this.aileron_textBox.Name = "aileron_textBox";
            this.aileron_textBox.Size = new System.Drawing.Size(90, 21);
            this.aileron_textBox.TabIndex = 8;
            this.aileron_textBox.Text = "0";
            // 
            // elevator_textBox
            // 
            this.elevator_textBox.Location = new System.Drawing.Point(185, 49);
            this.elevator_textBox.Name = "elevator_textBox";
            this.elevator_textBox.Size = new System.Drawing.Size(90, 21);
            this.elevator_textBox.TabIndex = 9;
            this.elevator_textBox.Text = "0";
            // 
            // rudder_textBox
            // 
            this.rudder_textBox.Location = new System.Drawing.Point(185, 88);
            this.rudder_textBox.Name = "rudder_textBox";
            this.rudder_textBox.Size = new System.Drawing.Size(90, 21);
            this.rudder_textBox.TabIndex = 10;
            this.rudder_textBox.Text = "0";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.roll_angle_l_textBox);
            this.groupBox25.Controls.Add(this.stall_speed_l_textBox);
            this.groupBox25.Controls.Add(this.max_airspeed_l_textBox);
            this.groupBox25.Controls.Add(this.max_lateral_overload_l_textBox);
            this.groupBox25.Controls.Add(this.reserve_l_textBox);
            this.groupBox25.Controls.Add(this.min_pitch_angle_l_textBox);
            this.groupBox25.Controls.Add(this.elevator_l_textBox);
            this.groupBox25.Controls.Add(this.rudder_l_textBox);
            this.groupBox25.Controls.Add(this.frontwheel_l_textBox);
            this.groupBox25.Controls.Add(this.max_throttle_l_textBox);
            this.groupBox25.Controls.Add(this.min_throttle_l_textBox);
            this.groupBox25.Controls.Add(this.max_pitch_angle_l_textBox);
            this.groupBox25.Controls.Add(this.aileron_l_textBox);
            this.groupBox25.Controls.Add(this.reserve_textBox);
            this.groupBox25.Controls.Add(this.max_lateral_overload_textBox);
            this.groupBox25.Controls.Add(this.label6);
            this.groupBox25.Controls.Add(this.label7);
            this.groupBox25.Controls.Add(this.max_airspeed_textBox);
            this.groupBox25.Controls.Add(this.label8);
            this.groupBox25.Controls.Add(this.stall_speed_textBox);
            this.groupBox25.Controls.Add(this.roll_angle_textBox);
            this.groupBox25.Controls.Add(this.min_pitch_angle_textBox);
            this.groupBox25.Controls.Add(this.label9);
            this.groupBox25.Controls.Add(this.label10);
            this.groupBox25.Controls.Add(this.label11);
            this.groupBox25.Controls.Add(this.max_pitch_angle_textBox);
            this.groupBox25.Controls.Add(this.label3);
            this.groupBox25.Controls.Add(this.min_throttle_textBox);
            this.groupBox25.Controls.Add(this.max_throttle_textBox);
            this.groupBox25.Controls.Add(this.label4);
            this.groupBox25.Controls.Add(this.label5);
            this.groupBox25.Controls.Add(this.frontwheel_textBox);
            this.groupBox25.Controls.Add(this.label2);
            this.groupBox25.Controls.Add(this.rudder_textBox);
            this.groupBox25.Controls.Add(this.elevator_textBox);
            this.groupBox25.Controls.Add(this.aileron_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(87, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(659, 277);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "极限";
            // 
            // roll_angle_l_textBox
            // 
            this.roll_angle_l_textBox.Enabled = false;
            this.roll_angle_l_textBox.Location = new System.Drawing.Point(417, 50);
            this.roll_angle_l_textBox.Name = "roll_angle_l_textBox";
            this.roll_angle_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.roll_angle_l_textBox.TabIndex = 43;
            // 
            // stall_speed_l_textBox
            // 
            this.stall_speed_l_textBox.Enabled = false;
            this.stall_speed_l_textBox.Location = new System.Drawing.Point(417, 89);
            this.stall_speed_l_textBox.Name = "stall_speed_l_textBox";
            this.stall_speed_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.stall_speed_l_textBox.TabIndex = 42;
            // 
            // max_airspeed_l_textBox
            // 
            this.max_airspeed_l_textBox.Enabled = false;
            this.max_airspeed_l_textBox.Location = new System.Drawing.Point(417, 126);
            this.max_airspeed_l_textBox.Name = "max_airspeed_l_textBox";
            this.max_airspeed_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_airspeed_l_textBox.TabIndex = 41;
            // 
            // max_lateral_overload_l_textBox
            // 
            this.max_lateral_overload_l_textBox.Enabled = false;
            this.max_lateral_overload_l_textBox.Location = new System.Drawing.Point(417, 166);
            this.max_lateral_overload_l_textBox.Name = "max_lateral_overload_l_textBox";
            this.max_lateral_overload_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_lateral_overload_l_textBox.TabIndex = 40;
            // 
            // reserve_l_textBox
            // 
            this.reserve_l_textBox.Enabled = false;
            this.reserve_l_textBox.Location = new System.Drawing.Point(417, 204);
            this.reserve_l_textBox.Name = "reserve_l_textBox";
            this.reserve_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.reserve_l_textBox.TabIndex = 39;
            // 
            // min_pitch_angle_l_textBox
            // 
            this.min_pitch_angle_l_textBox.Enabled = false;
            this.min_pitch_angle_l_textBox.Location = new System.Drawing.Point(417, 16);
            this.min_pitch_angle_l_textBox.Name = "min_pitch_angle_l_textBox";
            this.min_pitch_angle_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.min_pitch_angle_l_textBox.TabIndex = 38;
            // 
            // elevator_l_textBox
            // 
            this.elevator_l_textBox.Enabled = false;
            this.elevator_l_textBox.Location = new System.Drawing.Point(88, 49);
            this.elevator_l_textBox.Name = "elevator_l_textBox";
            this.elevator_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.elevator_l_textBox.TabIndex = 37;
            // 
            // rudder_l_textBox
            // 
            this.rudder_l_textBox.Enabled = false;
            this.rudder_l_textBox.Location = new System.Drawing.Point(88, 88);
            this.rudder_l_textBox.Name = "rudder_l_textBox";
            this.rudder_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.rudder_l_textBox.TabIndex = 36;
            // 
            // frontwheel_l_textBox
            // 
            this.frontwheel_l_textBox.Enabled = false;
            this.frontwheel_l_textBox.Location = new System.Drawing.Point(88, 126);
            this.frontwheel_l_textBox.Name = "frontwheel_l_textBox";
            this.frontwheel_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.frontwheel_l_textBox.TabIndex = 35;
            // 
            // max_throttle_l_textBox
            // 
            this.max_throttle_l_textBox.Enabled = false;
            this.max_throttle_l_textBox.Location = new System.Drawing.Point(88, 166);
            this.max_throttle_l_textBox.Name = "max_throttle_l_textBox";
            this.max_throttle_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_throttle_l_textBox.TabIndex = 34;
            // 
            // min_throttle_l_textBox
            // 
            this.min_throttle_l_textBox.Enabled = false;
            this.min_throttle_l_textBox.Location = new System.Drawing.Point(88, 204);
            this.min_throttle_l_textBox.Name = "min_throttle_l_textBox";
            this.min_throttle_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.min_throttle_l_textBox.TabIndex = 33;
            // 
            // max_pitch_angle_l_textBox
            // 
            this.max_pitch_angle_l_textBox.Enabled = false;
            this.max_pitch_angle_l_textBox.Location = new System.Drawing.Point(88, 242);
            this.max_pitch_angle_l_textBox.Name = "max_pitch_angle_l_textBox";
            this.max_pitch_angle_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_pitch_angle_l_textBox.TabIndex = 32;
            // 
            // aileron_l_textBox
            // 
            this.aileron_l_textBox.Enabled = false;
            this.aileron_l_textBox.Location = new System.Drawing.Point(88, 15);
            this.aileron_l_textBox.Name = "aileron_l_textBox";
            this.aileron_l_textBox.Size = new System.Drawing.Size(90, 21);
            this.aileron_l_textBox.TabIndex = 31;
            // 
            // reserve_textBox
            // 
            this.reserve_textBox.Location = new System.Drawing.Point(513, 205);
            this.reserve_textBox.Name = "reserve_textBox";
            this.reserve_textBox.Size = new System.Drawing.Size(90, 21);
            this.reserve_textBox.TabIndex = 30;
            this.reserve_textBox.Text = "0";
            // 
            // max_lateral_overload_textBox
            // 
            this.max_lateral_overload_textBox.Location = new System.Drawing.Point(513, 166);
            this.max_lateral_overload_textBox.Name = "max_lateral_overload_textBox";
            this.max_lateral_overload_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_lateral_overload_textBox.TabIndex = 29;
            this.max_lateral_overload_textBox.Text = "0";
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(334, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "预留";
            // 
            // label7
            // 
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(334, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "最大横向过载";
            // 
            // max_airspeed_textBox
            // 
            this.max_airspeed_textBox.Location = new System.Drawing.Point(513, 126);
            this.max_airspeed_textBox.Name = "max_airspeed_textBox";
            this.max_airspeed_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_airspeed_textBox.TabIndex = 26;
            this.max_airspeed_textBox.Text = "0";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(334, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "最大空速";
            // 
            // stall_speed_textBox
            // 
            this.stall_speed_textBox.Location = new System.Drawing.Point(513, 89);
            this.stall_speed_textBox.Name = "stall_speed_textBox";
            this.stall_speed_textBox.Size = new System.Drawing.Size(90, 21);
            this.stall_speed_textBox.TabIndex = 24;
            this.stall_speed_textBox.Text = "0";
            // 
            // roll_angle_textBox
            // 
            this.roll_angle_textBox.Location = new System.Drawing.Point(513, 50);
            this.roll_angle_textBox.Name = "roll_angle_textBox";
            this.roll_angle_textBox.Size = new System.Drawing.Size(90, 21);
            this.roll_angle_textBox.TabIndex = 23;
            this.roll_angle_textBox.Text = "0";
            // 
            // min_pitch_angle_textBox
            // 
            this.min_pitch_angle_textBox.Location = new System.Drawing.Point(513, 16);
            this.min_pitch_angle_textBox.Name = "min_pitch_angle_textBox";
            this.min_pitch_angle_textBox.Size = new System.Drawing.Size(90, 21);
            this.min_pitch_angle_textBox.TabIndex = 22;
            this.min_pitch_angle_textBox.Text = "0";
            // 
            // label9
            // 
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(334, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "失速速度";
            // 
            // label10
            // 
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(334, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "滚转角限幅";
            // 
            // label11
            // 
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(334, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "最小俯仰角";
            // 
            // max_pitch_angle_textBox
            // 
            this.max_pitch_angle_textBox.Location = new System.Drawing.Point(185, 242);
            this.max_pitch_angle_textBox.Name = "max_pitch_angle_textBox";
            this.max_pitch_angle_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_pitch_angle_textBox.TabIndex = 18;
            this.max_pitch_angle_textBox.Text = "0";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "最大俯仰角";
            // 
            // min_throttle_textBox
            // 
            this.min_throttle_textBox.Location = new System.Drawing.Point(185, 204);
            this.min_throttle_textBox.Name = "min_throttle_textBox";
            this.min_throttle_textBox.Size = new System.Drawing.Size(90, 21);
            this.min_throttle_textBox.TabIndex = 16;
            this.min_throttle_textBox.Text = "0";
            // 
            // max_throttle_textBox
            // 
            this.max_throttle_textBox.Location = new System.Drawing.Point(185, 165);
            this.max_throttle_textBox.Name = "max_throttle_textBox";
            this.max_throttle_textBox.Size = new System.Drawing.Size(90, 21);
            this.max_throttle_textBox.TabIndex = 15;
            this.max_throttle_textBox.Text = "0";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(6, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "最小油门";
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "最大油门";
            // 
            // frontwheel_textBox
            // 
            this.frontwheel_textBox.Location = new System.Drawing.Point(185, 126);
            this.frontwheel_textBox.Name = "frontwheel_textBox";
            this.frontwheel_textBox.Size = new System.Drawing.Size(90, 21);
            this.frontwheel_textBox.TabIndex = 12;
            this.frontwheel_textBox.Text = "0";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "前轮限幅";
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(87, 436);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 11;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button1_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(168, 436);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 12;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.button2_Click);
            // 
            // LimitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Import);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.search_button);
            this.Name = "LimitView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.LimitView_Load);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox aileron_textBox;
        private System.Windows.Forms.TextBox elevator_textBox;
        private System.Windows.Forms.TextBox rudder_textBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox frontwheel_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox reserve_textBox;
        private System.Windows.Forms.TextBox max_lateral_overload_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox max_airspeed_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stall_speed_textBox;
        private System.Windows.Forms.TextBox roll_angle_textBox;
        private System.Windows.Forms.TextBox min_pitch_angle_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox max_pitch_angle_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox min_throttle_textBox;
        private System.Windows.Forms.TextBox max_throttle_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox roll_angle_l_textBox;
        private System.Windows.Forms.TextBox stall_speed_l_textBox;
        private System.Windows.Forms.TextBox max_airspeed_l_textBox;
        private System.Windows.Forms.TextBox max_lateral_overload_l_textBox;
        private System.Windows.Forms.TextBox reserve_l_textBox;
        private System.Windows.Forms.TextBox min_pitch_angle_l_textBox;
        private System.Windows.Forms.TextBox elevator_l_textBox;
        private System.Windows.Forms.TextBox rudder_l_textBox;
        private System.Windows.Forms.TextBox frontwheel_l_textBox;
        private System.Windows.Forms.TextBox max_throttle_l_textBox;
        private System.Windows.Forms.TextBox min_throttle_l_textBox;
        private System.Windows.Forms.TextBox max_pitch_angle_l_textBox;
        private System.Windows.Forms.TextBox aileron_l_textBox;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Import;
    }
}
