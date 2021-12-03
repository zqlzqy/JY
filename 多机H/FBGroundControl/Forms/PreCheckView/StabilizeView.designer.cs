using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class StabilizeCheckView
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
            this.Stabilize_checkBox = new System.Windows.Forms.CheckBox();
            this.warningShow = new System.Windows.Forms.Label();
            this.SteerCheck_groupBox = new System.Windows.Forms.GroupBox();
            this.Open_Parachute_button = new System.Windows.Forms.Button();
            this.Pack_Parachute_button = new System.Windows.Forms.Button();
            this.Fix_Brake_button = new System.Windows.Forms.Button();
            this.Un_Brake_button = new System.Windows.Forms.Button();
            this.R_Wheel_button = new System.Windows.Forms.Button();
            this.M_Wheel_button = new System.Windows.Forms.Button();
            this.L_Wheel_button = new System.Windows.Forms.Button();
            this.D_Flap_button = new System.Windows.Forms.Button();
            this.M_Flap_button = new System.Windows.Forms.Button();
            this.U_Flap_button = new System.Windows.Forms.Button();
            this.R_Rudder_button = new System.Windows.Forms.Button();
            this.M_Rudder_button = new System.Windows.Forms.Button();
            this.L_Rudder_button = new System.Windows.Forms.Button();
            this.Max_Throttle_button = new System.Windows.Forms.Button();
            this.Mid_Throttle_button = new System.Windows.Forms.Button();
            this.Min_Throttle_button = new System.Windows.Forms.Button();
            this.D_Elevator_button = new System.Windows.Forms.Button();
            this.M_Elevator_button = new System.Windows.Forms.Button();
            this.U_Elevator_button = new System.Windows.Forms.Button();
            this.R_Aileron_button = new System.Windows.Forms.Button();
            this.M_Aileron_button = new System.Windows.Forms.Button();
            this.L_Aileron_button = new System.Windows.Forms.Button();
            this.Parachute_label = new System.Windows.Forms.Label();
            this.Brake_label = new System.Windows.Forms.Label();
            this.Wheel_label = new System.Windows.Forms.Label();
            this.Flap_label = new System.Windows.Forms.Label();
            this.Rudder_label = new System.Windows.Forms.Label();
            this.Throttle_label = new System.Windows.Forms.Label();
            this.Elevator_label = new System.Windows.Forms.Label();
            this.Aileron_label = new System.Windows.Forms.Label();
            this.Status_groupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SteerCheck_groupBox.SuspendLayout();
            this.Status_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stabilize_checkBox
            // 
            this.Stabilize_checkBox.AutoSize = true;
            this.Stabilize_checkBox.Location = new System.Drawing.Point(200, 17);
            this.Stabilize_checkBox.Name = "Stabilize_checkBox";
            this.Stabilize_checkBox.Size = new System.Drawing.Size(72, 16);
            this.Stabilize_checkBox.TabIndex = 13;
            this.Stabilize_checkBox.Text = "检查完成";
            this.Stabilize_checkBox.UseVisualStyleBackColor = true;
            // 
            // warningShow
            // 
            this.warningShow.AutoSize = true;
            this.warningShow.Location = new System.Drawing.Point(149, 53);
            this.warningShow.Name = "warningShow";
            this.warningShow.Size = new System.Drawing.Size(317, 12);
            this.warningShow.TabIndex = 14;
            this.warningShow.Text = "选择自动控制，输出各舵面指令，检查与实际位置是否一致";
            // 
            // SteerCheck_groupBox
            // 
            this.SteerCheck_groupBox.Controls.Add(this.Open_Parachute_button);
            this.SteerCheck_groupBox.Controls.Add(this.Pack_Parachute_button);
            this.SteerCheck_groupBox.Controls.Add(this.Fix_Brake_button);
            this.SteerCheck_groupBox.Controls.Add(this.Un_Brake_button);
            this.SteerCheck_groupBox.Controls.Add(this.R_Wheel_button);
            this.SteerCheck_groupBox.Controls.Add(this.M_Wheel_button);
            this.SteerCheck_groupBox.Controls.Add(this.L_Wheel_button);
            this.SteerCheck_groupBox.Controls.Add(this.D_Flap_button);
            this.SteerCheck_groupBox.Controls.Add(this.M_Flap_button);
            this.SteerCheck_groupBox.Controls.Add(this.U_Flap_button);
            this.SteerCheck_groupBox.Controls.Add(this.R_Rudder_button);
            this.SteerCheck_groupBox.Controls.Add(this.M_Rudder_button);
            this.SteerCheck_groupBox.Controls.Add(this.L_Rudder_button);
            this.SteerCheck_groupBox.Controls.Add(this.Max_Throttle_button);
            this.SteerCheck_groupBox.Controls.Add(this.Mid_Throttle_button);
            this.SteerCheck_groupBox.Controls.Add(this.Min_Throttle_button);
            this.SteerCheck_groupBox.Controls.Add(this.D_Elevator_button);
            this.SteerCheck_groupBox.Controls.Add(this.M_Elevator_button);
            this.SteerCheck_groupBox.Controls.Add(this.U_Elevator_button);
            this.SteerCheck_groupBox.Controls.Add(this.R_Aileron_button);
            this.SteerCheck_groupBox.Controls.Add(this.M_Aileron_button);
            this.SteerCheck_groupBox.Controls.Add(this.L_Aileron_button);
            this.SteerCheck_groupBox.Controls.Add(this.Parachute_label);
            this.SteerCheck_groupBox.Controls.Add(this.Brake_label);
            this.SteerCheck_groupBox.Controls.Add(this.Wheel_label);
            this.SteerCheck_groupBox.Controls.Add(this.Flap_label);
            this.SteerCheck_groupBox.Controls.Add(this.Rudder_label);
            this.SteerCheck_groupBox.Controls.Add(this.Throttle_label);
            this.SteerCheck_groupBox.Controls.Add(this.Elevator_label);
            this.SteerCheck_groupBox.Controls.Add(this.Aileron_label);
            this.SteerCheck_groupBox.Location = new System.Drawing.Point(82, 97);
            this.SteerCheck_groupBox.Name = "SteerCheck_groupBox";
            this.SteerCheck_groupBox.Size = new System.Drawing.Size(355, 270);
            this.SteerCheck_groupBox.TabIndex = 15;
            this.SteerCheck_groupBox.TabStop = false;
            this.SteerCheck_groupBox.Text = "控制面检查";
            // 
            // Open_Parachute_button
            // 
            this.Open_Parachute_button.Location = new System.Drawing.Point(243, 232);
            this.Open_Parachute_button.Name = "Open_Parachute_button";
            this.Open_Parachute_button.Size = new System.Drawing.Size(87, 23);
            this.Open_Parachute_button.TabIndex = 34;
            this.Open_Parachute_button.Text = "展开";
            this.Open_Parachute_button.UseVisualStyleBackColor = true;
            // 
            // Pack_Parachute_button
            // 
            this.Pack_Parachute_button.Location = new System.Drawing.Point(90, 232);
            this.Pack_Parachute_button.Name = "Pack_Parachute_button";
            this.Pack_Parachute_button.Size = new System.Drawing.Size(87, 23);
            this.Pack_Parachute_button.TabIndex = 33;
            this.Pack_Parachute_button.Text = "收起";
            this.Pack_Parachute_button.UseVisualStyleBackColor = true;
            // 
            // Fix_Brake_button
            // 
            this.Fix_Brake_button.Location = new System.Drawing.Point(243, 202);
            this.Fix_Brake_button.Name = "Fix_Brake_button";
            this.Fix_Brake_button.Size = new System.Drawing.Size(87, 23);
            this.Fix_Brake_button.TabIndex = 32;
            this.Fix_Brake_button.Text = "刹车";
            this.Fix_Brake_button.UseVisualStyleBackColor = true;
            // 
            // Un_Brake_button
            // 
            this.Un_Brake_button.Location = new System.Drawing.Point(90, 202);
            this.Un_Brake_button.Name = "Un_Brake_button";
            this.Un_Brake_button.Size = new System.Drawing.Size(87, 23);
            this.Un_Brake_button.TabIndex = 31;
            this.Un_Brake_button.Text = "松开";
            this.Un_Brake_button.UseVisualStyleBackColor = true;
            // 
            // R_Wheel_button
            // 
            this.R_Wheel_button.Location = new System.Drawing.Point(270, 172);
            this.R_Wheel_button.Name = "R_Wheel_button";
            this.R_Wheel_button.Size = new System.Drawing.Size(60, 23);
            this.R_Wheel_button.TabIndex = 30;
            this.R_Wheel_button.Text = "右偏";
            this.R_Wheel_button.UseVisualStyleBackColor = true;
            // 
            // M_Wheel_button
            // 
            this.M_Wheel_button.Location = new System.Drawing.Point(180, 172);
            this.M_Wheel_button.Name = "M_Wheel_button";
            this.M_Wheel_button.Size = new System.Drawing.Size(60, 23);
            this.M_Wheel_button.TabIndex = 29;
            this.M_Wheel_button.Text = "中立";
            this.M_Wheel_button.UseVisualStyleBackColor = true;
            // 
            // L_Wheel_button
            // 
            this.L_Wheel_button.Location = new System.Drawing.Point(90, 172);
            this.L_Wheel_button.Name = "L_Wheel_button";
            this.L_Wheel_button.Size = new System.Drawing.Size(60, 23);
            this.L_Wheel_button.TabIndex = 28;
            this.L_Wheel_button.Text = "左偏";
            this.L_Wheel_button.UseVisualStyleBackColor = true;
            // 
            // D_Flap_button
            // 
            this.D_Flap_button.Location = new System.Drawing.Point(270, 142);
            this.D_Flap_button.Name = "D_Flap_button";
            this.D_Flap_button.Size = new System.Drawing.Size(60, 23);
            this.D_Flap_button.TabIndex = 27;
            this.D_Flap_button.Text = "下偏";
            this.D_Flap_button.UseVisualStyleBackColor = true;
            // 
            // M_Flap_button
            // 
            this.M_Flap_button.Location = new System.Drawing.Point(180, 142);
            this.M_Flap_button.Name = "M_Flap_button";
            this.M_Flap_button.Size = new System.Drawing.Size(60, 23);
            this.M_Flap_button.TabIndex = 26;
            this.M_Flap_button.Text = "中立";
            this.M_Flap_button.UseVisualStyleBackColor = true;
            // 
            // U_Flap_button
            // 
            this.U_Flap_button.Location = new System.Drawing.Point(90, 142);
            this.U_Flap_button.Name = "U_Flap_button";
            this.U_Flap_button.Size = new System.Drawing.Size(60, 23);
            this.U_Flap_button.TabIndex = 25;
            this.U_Flap_button.Text = "上偏";
            this.U_Flap_button.UseVisualStyleBackColor = true;
            // 
            // R_Rudder_button
            // 
            this.R_Rudder_button.Location = new System.Drawing.Point(270, 112);
            this.R_Rudder_button.Name = "R_Rudder_button";
            this.R_Rudder_button.Size = new System.Drawing.Size(60, 23);
            this.R_Rudder_button.TabIndex = 24;
            this.R_Rudder_button.Text = "右偏";
            this.R_Rudder_button.UseVisualStyleBackColor = true;
            // 
            // M_Rudder_button
            // 
            this.M_Rudder_button.Location = new System.Drawing.Point(180, 112);
            this.M_Rudder_button.Name = "M_Rudder_button";
            this.M_Rudder_button.Size = new System.Drawing.Size(60, 23);
            this.M_Rudder_button.TabIndex = 23;
            this.M_Rudder_button.Text = "中立";
            this.M_Rudder_button.UseVisualStyleBackColor = true;
            // 
            // L_Rudder_button
            // 
            this.L_Rudder_button.Location = new System.Drawing.Point(90, 112);
            this.L_Rudder_button.Name = "L_Rudder_button";
            this.L_Rudder_button.Size = new System.Drawing.Size(60, 23);
            this.L_Rudder_button.TabIndex = 22;
            this.L_Rudder_button.Text = "左偏";
            this.L_Rudder_button.UseVisualStyleBackColor = true;
            // 
            // Max_Throttle_button
            // 
            this.Max_Throttle_button.Location = new System.Drawing.Point(270, 82);
            this.Max_Throttle_button.Name = "Max_Throttle_button";
            this.Max_Throttle_button.Size = new System.Drawing.Size(60, 23);
            this.Max_Throttle_button.TabIndex = 21;
            this.Max_Throttle_button.Text = "最大";
            this.Max_Throttle_button.UseVisualStyleBackColor = true;
            // 
            // Mid_Throttle_button
            // 
            this.Mid_Throttle_button.Location = new System.Drawing.Point(180, 82);
            this.Mid_Throttle_button.Name = "Mid_Throttle_button";
            this.Mid_Throttle_button.Size = new System.Drawing.Size(60, 23);
            this.Mid_Throttle_button.TabIndex = 20;
            this.Mid_Throttle_button.Text = "中立";
            this.Mid_Throttle_button.UseVisualStyleBackColor = true;
            // 
            // Min_Throttle_button
            // 
            this.Min_Throttle_button.Location = new System.Drawing.Point(90, 82);
            this.Min_Throttle_button.Name = "Min_Throttle_button";
            this.Min_Throttle_button.Size = new System.Drawing.Size(60, 23);
            this.Min_Throttle_button.TabIndex = 19;
            this.Min_Throttle_button.Text = "最小";
            this.Min_Throttle_button.UseVisualStyleBackColor = true;
            // 
            // D_Elevator_button
            // 
            this.D_Elevator_button.Location = new System.Drawing.Point(270, 52);
            this.D_Elevator_button.Name = "D_Elevator_button";
            this.D_Elevator_button.Size = new System.Drawing.Size(60, 23);
            this.D_Elevator_button.TabIndex = 18;
            this.D_Elevator_button.Text = "下偏";
            this.D_Elevator_button.UseVisualStyleBackColor = true;
            // 
            // M_Elevator_button
            // 
            this.M_Elevator_button.Location = new System.Drawing.Point(180, 52);
            this.M_Elevator_button.Name = "M_Elevator_button";
            this.M_Elevator_button.Size = new System.Drawing.Size(60, 23);
            this.M_Elevator_button.TabIndex = 17;
            this.M_Elevator_button.Text = "中立";
            this.M_Elevator_button.UseVisualStyleBackColor = true;
            // 
            // U_Elevator_button
            // 
            this.U_Elevator_button.Location = new System.Drawing.Point(90, 52);
            this.U_Elevator_button.Name = "U_Elevator_button";
            this.U_Elevator_button.Size = new System.Drawing.Size(60, 23);
            this.U_Elevator_button.TabIndex = 16;
            this.U_Elevator_button.Text = "上偏";
            this.U_Elevator_button.UseVisualStyleBackColor = true;
            // 
            // R_Aileron_button
            // 
            this.R_Aileron_button.Location = new System.Drawing.Point(270, 22);
            this.R_Aileron_button.Name = "R_Aileron_button";
            this.R_Aileron_button.Size = new System.Drawing.Size(60, 23);
            this.R_Aileron_button.TabIndex = 15;
            this.R_Aileron_button.Text = "右偏";
            this.R_Aileron_button.UseVisualStyleBackColor = true;
            // 
            // M_Aileron_button
            // 
            this.M_Aileron_button.Location = new System.Drawing.Point(180, 22);
            this.M_Aileron_button.Name = "M_Aileron_button";
            this.M_Aileron_button.Size = new System.Drawing.Size(60, 23);
            this.M_Aileron_button.TabIndex = 14;
            this.M_Aileron_button.Text = "中立";
            this.M_Aileron_button.UseVisualStyleBackColor = true;
            // 
            // L_Aileron_button
            // 
            this.L_Aileron_button.Location = new System.Drawing.Point(90, 22);
            this.L_Aileron_button.Name = "L_Aileron_button";
            this.L_Aileron_button.Size = new System.Drawing.Size(60, 23);
            this.L_Aileron_button.TabIndex = 13;
            this.L_Aileron_button.Text = "左偏";
            this.L_Aileron_button.UseVisualStyleBackColor = true;
            // 
            // Parachute_label
            // 
            this.Parachute_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Parachute_label.Location = new System.Drawing.Point(6, 237);
            this.Parachute_label.Name = "Parachute_label";
            this.Parachute_label.Size = new System.Drawing.Size(84, 13);
            this.Parachute_label.TabIndex = 7;
            this.Parachute_label.Text = "降落伞";
            // 
            // Brake_label
            // 
            this.Brake_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Brake_label.Location = new System.Drawing.Point(6, 207);
            this.Brake_label.Name = "Brake_label";
            this.Brake_label.Size = new System.Drawing.Size(84, 13);
            this.Brake_label.TabIndex = 6;
            this.Brake_label.Text = "刹车";
            // 
            // Wheel_label
            // 
            this.Wheel_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Wheel_label.Location = new System.Drawing.Point(6, 177);
            this.Wheel_label.Name = "Wheel_label";
            this.Wheel_label.Size = new System.Drawing.Size(84, 13);
            this.Wheel_label.TabIndex = 5;
            this.Wheel_label.Text = "前起";
            // 
            // Flap_label
            // 
            this.Flap_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Flap_label.Location = new System.Drawing.Point(6, 147);
            this.Flap_label.Name = "Flap_label";
            this.Flap_label.Size = new System.Drawing.Size(84, 13);
            this.Flap_label.TabIndex = 4;
            this.Flap_label.Text = "襟翼";
            // 
            // Rudder_label
            // 
            this.Rudder_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Rudder_label.Location = new System.Drawing.Point(6, 117);
            this.Rudder_label.Name = "Rudder_label";
            this.Rudder_label.Size = new System.Drawing.Size(84, 13);
            this.Rudder_label.TabIndex = 3;
            this.Rudder_label.Text = "方向舵";
            // 
            // Throttle_label
            // 
            this.Throttle_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Throttle_label.Location = new System.Drawing.Point(6, 87);
            this.Throttle_label.Name = "Throttle_label";
            this.Throttle_label.Size = new System.Drawing.Size(84, 13);
            this.Throttle_label.TabIndex = 2;
            this.Throttle_label.Text = "油门";
            // 
            // Elevator_label
            // 
            this.Elevator_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Elevator_label.Location = new System.Drawing.Point(6, 57);
            this.Elevator_label.Name = "Elevator_label";
            this.Elevator_label.Size = new System.Drawing.Size(84, 13);
            this.Elevator_label.TabIndex = 1;
            this.Elevator_label.Text = "升降舵";
            // 
            // Aileron_label
            // 
            this.Aileron_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Aileron_label.Location = new System.Drawing.Point(6, 27);
            this.Aileron_label.Name = "Aileron_label";
            this.Aileron_label.Size = new System.Drawing.Size(59, 13);
            this.Aileron_label.TabIndex = 0;
            this.Aileron_label.Text = "副翼";
            // 
            // Status_groupBox
            // 
            this.Status_groupBox.Controls.Add(this.label8);
            this.Status_groupBox.Location = new System.Drawing.Point(492, 106);
            this.Status_groupBox.Name = "Status_groupBox";
            this.Status_groupBox.Size = new System.Drawing.Size(84, 51);
            this.Status_groupBox.TabIndex = 16;
            this.Status_groupBox.TabStop = false;
            this.Status_groupBox.Text = "自驾状态";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(26, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "自控";
            // 
            // StabilizeCheckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Status_groupBox);
            this.Controls.Add(this.SteerCheck_groupBox);
            this.Controls.Add(this.warningShow);
            this.Controls.Add(this.Stabilize_checkBox);
            this.Name = "StabilizeCheckView";
            this.Size = new System.Drawing.Size(660, 416);
            this.SteerCheck_groupBox.ResumeLayout(false);
            this.Status_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox Stabilize_checkBox;
        private System.Windows.Forms.Label warningShow;
        private System.Windows.Forms.GroupBox SteerCheck_groupBox;
        private System.Windows.Forms.Label Aileron_label;
        private System.Windows.Forms.Label Parachute_label;
        private System.Windows.Forms.Label Brake_label;
        private System.Windows.Forms.Label Wheel_label;
        private System.Windows.Forms.Label Flap_label;
        private System.Windows.Forms.Label Rudder_label;
        private System.Windows.Forms.Label Throttle_label;
        private System.Windows.Forms.Label Elevator_label;
        private System.Windows.Forms.Button R_Aileron_button;
        private System.Windows.Forms.Button M_Aileron_button;
        private System.Windows.Forms.Button L_Aileron_button;
        private System.Windows.Forms.Button D_Elevator_button;
        private System.Windows.Forms.Button M_Elevator_button;
        private System.Windows.Forms.Button U_Elevator_button;
        private System.Windows.Forms.Button Max_Throttle_button;
        private System.Windows.Forms.Button Mid_Throttle_button;
        private System.Windows.Forms.Button Min_Throttle_button;
        private System.Windows.Forms.Button R_Rudder_button;
        private System.Windows.Forms.Button M_Rudder_button;
        private System.Windows.Forms.Button L_Rudder_button;
        private System.Windows.Forms.Button Open_Parachute_button;
        private System.Windows.Forms.Button Pack_Parachute_button;
        private System.Windows.Forms.Button Fix_Brake_button;
        private System.Windows.Forms.Button Un_Brake_button;
        private System.Windows.Forms.Button R_Wheel_button;
        private System.Windows.Forms.Button M_Wheel_button;
        private System.Windows.Forms.Button L_Wheel_button;
        private System.Windows.Forms.Button D_Flap_button;
        private System.Windows.Forms.Button M_Flap_button;
        private System.Windows.Forms.Button U_Flap_button;
        private System.Windows.Forms.GroupBox Status_groupBox;
        private System.Windows.Forms.Label label8;
    }
}
