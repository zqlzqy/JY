namespace FBGroundControl.Forms
{
    partial class GuihangMode
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
            this.setup_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.count = new System.Windows.Forms.TextBox();
            this.mode = new System.Windows.Forms.TextBox();
            this.count_textBox = new System.Windows.Forms.TextBox();
            this.mode_textBox = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.lossmode = new System.Windows.Forms.TextBox();
            this.loss_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(232, 213);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 29;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(148, 213);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 28;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // count
            // 
            this.count.Enabled = false;
            this.count.Location = new System.Drawing.Point(159, 88);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(77, 21);
            this.count.TabIndex = 27;
            // 
            // mode
            // 
            this.mode.Enabled = false;
            this.mode.Location = new System.Drawing.Point(159, 33);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(77, 21);
            this.mode.TabIndex = 26;
            // 
            // count_textBox
            // 
            this.count_textBox.Location = new System.Drawing.Point(243, 88);
            this.count_textBox.Name = "count_textBox";
            this.count_textBox.Size = new System.Drawing.Size(75, 21);
            this.count_textBox.TabIndex = 25;
            this.count_textBox.Text = "0";
            // 
            // mode_textBox
            // 
            this.mode_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mode_textBox.Location = new System.Drawing.Point(243, 33);
            this.mode_textBox.Name = "mode_textBox";
            this.mode_textBox.Size = new System.Drawing.Size(75, 21);
            this.mode_textBox.TabIndex = 24;
            this.mode_textBox.Text = "0";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(59, 91);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(90, 13);
            this.label90.TabIndex = 23;
            this.label90.Text = "飞行圈数";
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(59, 36);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(81, 18);
            this.label91.TabIndex = 22;
            this.label91.Text = "归航模式";
            // 
            // lossmode
            // 
            this.lossmode.Enabled = false;
            this.lossmode.Location = new System.Drawing.Point(159, 140);
            this.lossmode.Name = "lossmode";
            this.lossmode.Size = new System.Drawing.Size(77, 21);
            this.lossmode.TabIndex = 32;
            // 
            // loss_textbox
            // 
            this.loss_textbox.Location = new System.Drawing.Point(243, 140);
            this.loss_textbox.Name = "loss_textbox";
            this.loss_textbox.Size = new System.Drawing.Size(75, 21);
            this.loss_textbox.TabIndex = 31;
            this.loss_textbox.Text = "0";
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(34, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "遥控失控模式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(324, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "0:启动自主";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(324, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "1:关闭自主";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(324, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "1:失控归航";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(324, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "0:任务优先";
            // 
            // GuihangMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 264);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lossmode);
            this.Controls.Add(this.loss_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.count);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.count_textBox);
            this.Controls.Add(this.mode_textBox);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label91);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuihangMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "归航模式";
            this.Load += new System.EventHandler(this.GuihangMode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.TextBox mode;
        private System.Windows.Forms.TextBox count_textBox;
        private System.Windows.Forms.TextBox mode_textBox;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox lossmode;
        private System.Windows.Forms.TextBox loss_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}