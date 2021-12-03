namespace FBGroundControl.Forms
{
    partial class SendCommandLogFrm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.close_button = new System.Windows.Forms.Button();
            this.log_listView = new System.Windows.Forms.ListView();
            this.loginfoList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(740, 389);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 7;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // log_listView
            // 
            this.log_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginfoList});
            this.log_listView.Location = new System.Drawing.Point(12, 12);
            this.log_listView.Name = "log_listView";
            this.log_listView.Size = new System.Drawing.Size(803, 360);
            this.log_listView.TabIndex = 8;
            this.log_listView.UseCompatibleStateImageBehavior = false;
            // 
            // loginfoList
            // 
            this.loginfoList.Text = "日志列表";
            this.loginfoList.Width = 800;
            // 
            // SendCommandLogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 424);
            this.Controls.Add(this.log_listView);
            this.Controls.Add(this.close_button);
            this.Name = "SendCommandLogFrm";
            this.Text = "命令发送日志";
            this.Load += new System.EventHandler(this.SendCommandLogFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.ListView log_listView;
        private System.Windows.Forms.ColumnHeader loginfoList;

    }
}