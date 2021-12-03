namespace FBGroundControl.Forms
{
    partial class TelemetryListFrm
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
            this.components = new System.ComponentModel.Container();
            this.telementry_listView = new System.Windows.Forms.ListView();
            this.close_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ZgTimer = new System.Windows.Forms.Timer(this.components);
            this.bindingSourceStatus = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // telementry_listView
            // 
            this.telementry_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telementry_listView.Location = new System.Drawing.Point(0, 0);
            this.telementry_listView.Name = "telementry_listView";
            this.telementry_listView.Size = new System.Drawing.Size(837, 564);
            this.telementry_listView.TabIndex = 0;
            this.telementry_listView.UseCompatibleStateImageBehavior = false;
            this.telementry_listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.telementry_listView_ColumnClick);
            // 
            // close_button
            // 
            this.close_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_button.Location = new System.Drawing.Point(750, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(87, 45);
            this.close_button.TabIndex = 1;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.close_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 45);
            this.panel1.TabIndex = 2;
            // 
            // ZgTimer
            // 
            // 
            // bindingSourceStatus
            // 
            this.bindingSourceStatus.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // TelemetryListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.telementry_listView);
            this.Name = "TelemetryListFrm";
            this.Text = "TelemetryListFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelemetryListFrm_FormClosing);
            this.Load += new System.EventHandler(this.TelemetryListFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView telementry_listView;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSourceStatus;
        private System.Windows.Forms.Timer ZgTimer;
    }
}