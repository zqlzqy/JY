namespace FBGroundControl.Forms
{
    partial class DaiKuan
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
            this.zhouqi = new System.Windows.Forms.TextBox();
            this.fbl = new System.Windows.Forms.TextBox();
            this.zhouqi_textBox = new System.Windows.Forms.TextBox();
            this.fbl_textBox = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.setup_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zhouqi
            // 
            this.zhouqi.Enabled = false;
            this.zhouqi.Location = new System.Drawing.Point(143, 96);
            this.zhouqi.Name = "zhouqi";
            this.zhouqi.Size = new System.Drawing.Size(77, 21);
            this.zhouqi.TabIndex = 19;
            // 
            // fbl
            // 
            this.fbl.Enabled = false;
            this.fbl.Location = new System.Drawing.Point(143, 35);
            this.fbl.Name = "fbl";
            this.fbl.Size = new System.Drawing.Size(77, 21);
            this.fbl.TabIndex = 18;
            this.fbl.MouseEnter += new System.EventHandler(this.fbl_MouseEnter);
            // 
            // zhouqi_textBox
            // 
            this.zhouqi_textBox.Location = new System.Drawing.Point(227, 96);
            this.zhouqi_textBox.Name = "zhouqi_textBox";
            this.zhouqi_textBox.Size = new System.Drawing.Size(75, 21);
            this.zhouqi_textBox.TabIndex = 17;
            this.zhouqi_textBox.Text = "0";
            // 
            // fbl_textBox
            // 
            this.fbl_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fbl_textBox.Location = new System.Drawing.Point(227, 35);
            this.fbl_textBox.Name = "fbl_textBox";
            this.fbl_textBox.Size = new System.Drawing.Size(75, 21);
            this.fbl_textBox.TabIndex = 16;
            this.fbl_textBox.Text = "0";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(43, 99);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(90, 13);
            this.label90.TabIndex = 15;
            this.label90.Text = "数据包周期";
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(43, 38);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(81, 18);
            this.label91.TabIndex = 14;
            this.label91.Text = "数据包分辨率";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(227, 179);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 21;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(143, 179);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 20;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(308, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "0:单机";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(308, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "1:多机";
            // 
            // DaiKuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.zhouqi);
            this.Controls.Add(this.fbl);
            this.Controls.Add(this.zhouqi_textBox);
            this.Controls.Add(this.fbl_textBox);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label91);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DaiKuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "遥测带宽";
            this.MinimumSizeChanged += new System.EventHandler(this.DaiKuan_MinimumSizeChanged);
            this.Load += new System.EventHandler(this.DaiKuan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox zhouqi;
        private System.Windows.Forms.TextBox fbl;
        private System.Windows.Forms.TextBox zhouqi_textBox;
        private System.Windows.Forms.TextBox fbl_textBox;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}