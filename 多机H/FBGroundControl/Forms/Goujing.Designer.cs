﻿namespace FBGroundControl.Forms
{
    partial class Goujing
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
            this.label1 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.TextBox();
            this.set_goujing = new System.Windows.Forms.Button();
            this.angel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.jinru_L = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wan_L = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.xian = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "距舰距离：";
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(145, 40);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(100, 21);
            this.distance.TabIndex = 1;
            // 
            // set_goujing
            // 
            this.set_goujing.Location = new System.Drawing.Point(133, 243);
            this.set_goujing.Name = "set_goujing";
            this.set_goujing.Size = new System.Drawing.Size(73, 30);
            this.set_goujing.TabIndex = 2;
            this.set_goujing.Text = "设置勾径";
            this.set_goujing.UseVisualStyleBackColor = true;
            this.set_goujing.Click += new System.EventHandler(this.set_goujing_Click);
            // 
            // angel
            // 
            this.angel.Location = new System.Drawing.Point(145, 71);
            this.angel.Name = "angel";
            this.angel.Size = new System.Drawing.Size(100, 21);
            this.angel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "距舰角度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(257, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(254, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "进入距离：";
            // 
            // jinru_L
            // 
            this.jinru_L.Location = new System.Drawing.Point(145, 104);
            this.jinru_L.Name = "jinru_L";
            this.jinru_L.Size = new System.Drawing.Size(100, 21);
            this.jinru_L.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "转弯距离：";
            // 
            // wan_L
            // 
            this.wan_L.Location = new System.Drawing.Point(145, 138);
            this.wan_L.Name = "wan_L";
            this.wan_L.Size = new System.Drawing.Size(100, 21);
            this.wan_L.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(257, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "km";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(257, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "km";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "发射方向：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(261, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "弦";
            // 
            // xian
            // 
            this.xian.FormattingEnabled = true;
            this.xian.Items.AddRange(new object[] {
            "左",
            "右"});
            this.xian.Location = new System.Drawing.Point(145, 174);
            this.xian.Name = "xian";
            this.xian.Size = new System.Drawing.Size(100, 20);
            this.xian.TabIndex = 9;
            // 
            // Goujing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 285);
            this.Controls.Add(this.xian);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.wan_L);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jinru_L);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.angel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.set_goujing);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.label1);
            this.Name = "Goujing";
            this.Text = "勾径规划";
            this.Load += new System.EventHandler(this.Goujing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button set_goujing;
        public System.Windows.Forms.TextBox distance;
        public System.Windows.Forms.TextBox angel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox jinru_L;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox wan_L;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox xian;
    }
}