namespace FBGroundControl.Forms
{
    partial class XuNi
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.speed_xn = new System.Windows.Forms.TextBox();
            this.heading_xn = new System.Windows.Forms.TextBox();
            this.lat_xn = new System.Windows.Forms.TextBox();
            this.lng_xn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "虚拟舰速度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "虚拟舰方向：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "虚拟舰纬度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "虚拟舰经度";
            // 
            // speed_xn
            // 
            this.speed_xn.Location = new System.Drawing.Point(128, 157);
            this.speed_xn.Name = "speed_xn";
            this.speed_xn.Size = new System.Drawing.Size(83, 21);
            this.speed_xn.TabIndex = 3;
            // 
            // heading_xn
            // 
            this.heading_xn.Location = new System.Drawing.Point(128, 114);
            this.heading_xn.Name = "heading_xn";
            this.heading_xn.Size = new System.Drawing.Size(83, 21);
            this.heading_xn.TabIndex = 4;
            // 
            // lat_xn
            // 
            this.lat_xn.Location = new System.Drawing.Point(128, 72);
            this.lat_xn.Name = "lat_xn";
            this.lat_xn.Size = new System.Drawing.Size(83, 21);
            this.lat_xn.TabIndex = 5;
            // 
            // lng_xn
            // 
            this.lng_xn.Location = new System.Drawing.Point(128, 32);
            this.lng_xn.Name = "lng_xn";
            this.lng_xn.Size = new System.Drawing.Size(83, 21);
            this.lng_xn.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "节";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "（0-360）";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "设置虚拟舰";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "退出虚拟舰";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // XuNi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 256);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed_xn);
            this.Controls.Add(this.heading_xn);
            this.Controls.Add(this.lat_xn);
            this.Controls.Add(this.lng_xn);
            this.Name = "XuNi";
            this.Text = "虚拟舰设置";
            this.Load += new System.EventHandler(this.XuNi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox speed_xn;
        public System.Windows.Forms.TextBox heading_xn;
        public System.Windows.Forms.TextBox lat_xn;
        public System.Windows.Forms.TextBox lng_xn;
        private System.Windows.Forms.Button button2;
    }
}