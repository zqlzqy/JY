namespace FBGroundControl.Forms
{
    partial class FirmwareWrite
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
            this.choose_button = new System.Windows.Forms.Button();
            this.location_textBox = new System.Windows.Forms.TextBox();
            this.close_button = new System.Windows.Forms.Button();
            this.write_button = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lbl_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "固件位置：";
            // 
            // choose_button
            // 
            this.choose_button.Location = new System.Drawing.Point(242, 12);
            this.choose_button.Name = "choose_button";
            this.choose_button.Size = new System.Drawing.Size(75, 23);
            this.choose_button.TabIndex = 1;
            this.choose_button.Text = "选择";
            this.choose_button.UseVisualStyleBackColor = true;
            this.choose_button.Visible = false;
            this.choose_button.Click += new System.EventHandler(this.choose_button_Click);
            // 
            // location_textBox
            // 
            this.location_textBox.Location = new System.Drawing.Point(86, 47);
            this.location_textBox.Name = "location_textBox";
            this.location_textBox.Size = new System.Drawing.Size(289, 21);
            this.location_textBox.TabIndex = 2;
            this.location_textBox.Text = "点击选择文件";
            this.location_textBox.Click += new System.EventHandler(this.location_textBox_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(313, 143);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 3;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // write_button
            // 
            this.write_button.Location = new System.Drawing.Point(224, 143);
            this.write_button.Name = "write_button";
            this.write_button.Size = new System.Drawing.Size(75, 23);
            this.write_button.TabIndex = 4;
            this.write_button.Text = "写入";
            this.write_button.UseVisualStyleBackColor = true;
            this.write_button.Click += new System.EventHandler(this.write_button_Click);
            // 
            // progress
            // 
            this.progress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progress.Location = new System.Drawing.Point(86, 86);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(289, 21);
            this.progress.Step = 1;
            this.progress.TabIndex = 7;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(84, 119);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(29, 12);
            this.lbl_status.TabIndex = 8;
            this.lbl_status.Text = "状态";
            // 
            // FirmwareWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 178);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.write_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.location_textBox);
            this.Controls.Add(this.choose_button);
            this.Controls.Add(this.label1);
            this.Name = "FirmwareWrite";
            this.Text = "固件写入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choose_button;
        private System.Windows.Forms.TextBox location_textBox;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button write_button;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lbl_status;
    }
}