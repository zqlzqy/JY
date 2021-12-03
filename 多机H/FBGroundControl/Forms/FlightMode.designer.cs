namespace FBGroundControl.Forms
{
    partial class FlightMode
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
            this.alt_hold_btn = new System.Windows.Forms.Button();
            this.loiter_btn = new System.Windows.Forms.Button();
            this.longitudinal_btn = new System.Windows.Forms.Button();
            this.guided_btn = new System.Windows.Forms.Button();
            this.rtl_btn = new System.Windows.Forms.Button();
            this.mot_anglePitch_btn = new System.Windows.Forms.Button();
            this.mot_continueRoll_btn = new System.Windows.Forms.Button();
            this.stabilize_btn = new System.Windows.Forms.Button();
            this.manual_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // alt_hold_btn
            // 
            this.alt_hold_btn.Location = new System.Drawing.Point(30, 103);
            this.alt_hold_btn.Name = "alt_hold_btn";
            this.alt_hold_btn.Size = new System.Drawing.Size(75, 23);
            this.alt_hold_btn.TabIndex = 96;
            this.alt_hold_btn.Text = "右盘机动";
            this.alt_hold_btn.UseVisualStyleBackColor = true;
            this.alt_hold_btn.Click += new System.EventHandler(this.alt_hold_btn_Click);
            // 
            // loiter_btn
            // 
            this.loiter_btn.Location = new System.Drawing.Point(478, 35);
            this.loiter_btn.Name = "loiter_btn";
            this.loiter_btn.Size = new System.Drawing.Size(75, 23);
            this.loiter_btn.TabIndex = 95;
            this.loiter_btn.Text = "半滚倒转";
            this.loiter_btn.UseVisualStyleBackColor = true;
            this.loiter_btn.Click += new System.EventHandler(this.loiter_btn_Click);
            // 
            // longitudinal_btn
            // 
            this.longitudinal_btn.Location = new System.Drawing.Point(366, 103);
            this.longitudinal_btn.Name = "longitudinal_btn";
            this.longitudinal_btn.Size = new System.Drawing.Size(75, 23);
            this.longitudinal_btn.TabIndex = 94;
            this.longitudinal_btn.Text = "俯冲拉起";
            this.longitudinal_btn.UseVisualStyleBackColor = true;
            this.longitudinal_btn.Click += new System.EventHandler(this.longitudinal_btn_Click);
            // 
            // guided_btn
            // 
            this.guided_btn.Location = new System.Drawing.Point(142, 103);
            this.guided_btn.Name = "guided_btn";
            this.guided_btn.Size = new System.Drawing.Size(75, 23);
            this.guided_btn.TabIndex = 93;
            this.guided_btn.Text = "右航向90";
            this.guided_btn.UseVisualStyleBackColor = true;
            this.guided_btn.Click += new System.EventHandler(this.guided_btn_Click);
            // 
            // rtl_btn
            // 
            this.rtl_btn.Location = new System.Drawing.Point(254, 103);
            this.rtl_btn.Name = "rtl_btn";
            this.rtl_btn.Size = new System.Drawing.Size(75, 23);
            this.rtl_btn.TabIndex = 92;
            this.rtl_btn.Text = "右航向180";
            this.rtl_btn.UseVisualStyleBackColor = true;
            this.rtl_btn.Click += new System.EventHandler(this.rtl_btn_Click);
            // 
            // mot_anglePitch_btn
            // 
            this.mot_anglePitch_btn.Location = new System.Drawing.Point(366, 35);
            this.mot_anglePitch_btn.Name = "mot_anglePitch_btn";
            this.mot_anglePitch_btn.Size = new System.Drawing.Size(75, 23);
            this.mot_anglePitch_btn.TabIndex = 91;
            this.mot_anglePitch_btn.Text = "S机动";
            this.mot_anglePitch_btn.UseVisualStyleBackColor = true;
            this.mot_anglePitch_btn.Click += new System.EventHandler(this.mot_anglePitch_btn_Click);
            // 
            // mot_continueRoll_btn
            // 
            this.mot_continueRoll_btn.Location = new System.Drawing.Point(254, 35);
            this.mot_continueRoll_btn.Name = "mot_continueRoll_btn";
            this.mot_continueRoll_btn.Size = new System.Drawing.Size(75, 23);
            this.mot_continueRoll_btn.TabIndex = 90;
            this.mot_continueRoll_btn.Text = "左航向180";
            this.mot_continueRoll_btn.UseVisualStyleBackColor = true;
            this.mot_continueRoll_btn.Click += new System.EventHandler(this.mot_continueRoll_btn_Click);
            // 
            // stabilize_btn
            // 
            this.stabilize_btn.Location = new System.Drawing.Point(142, 35);
            this.stabilize_btn.Name = "stabilize_btn";
            this.stabilize_btn.Size = new System.Drawing.Size(75, 23);
            this.stabilize_btn.TabIndex = 89;
            this.stabilize_btn.Text = "左航向90";
            this.stabilize_btn.UseVisualStyleBackColor = true;
            this.stabilize_btn.Click += new System.EventHandler(this.stabilize_btn_Click);
            // 
            // manual_btn
            // 
            this.manual_btn.Location = new System.Drawing.Point(30, 35);
            this.manual_btn.Name = "manual_btn";
            this.manual_btn.Size = new System.Drawing.Size(75, 23);
            this.manual_btn.TabIndex = 88;
            this.manual_btn.Text = "左盘机动";
            this.manual_btn.UseVisualStyleBackColor = true;
            this.manual_btn.Click += new System.EventHandler(this.manual_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 97;
            this.button1.Text = "桶滚";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FlightMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 249);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.alt_hold_btn);
            this.Controls.Add(this.loiter_btn);
            this.Controls.Add(this.longitudinal_btn);
            this.Controls.Add(this.guided_btn);
            this.Controls.Add(this.rtl_btn);
            this.Controls.Add(this.mot_anglePitch_btn);
            this.Controls.Add(this.mot_continueRoll_btn);
            this.Controls.Add(this.stabilize_btn);
            this.Controls.Add(this.manual_btn);
            this.MaximizeBox = false;
            this.Name = "FlightMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "飞行模式设置";
            this.Load += new System.EventHandler(this.FlightMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button alt_hold_btn;
        private System.Windows.Forms.Button loiter_btn;
        private System.Windows.Forms.Button longitudinal_btn;
        private System.Windows.Forms.Button guided_btn;
        private System.Windows.Forms.Button rtl_btn;
        private System.Windows.Forms.Button mot_anglePitch_btn;
        private System.Windows.Forms.Button mot_continueRoll_btn;
        private System.Windows.Forms.Button stabilize_btn;
        private System.Windows.Forms.Button manual_btn;
        private System.Windows.Forms.Button button1;
    }
}