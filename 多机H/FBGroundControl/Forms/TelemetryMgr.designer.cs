namespace MissionPlanner.GCSViews
{
    partial class TelemetryMgr
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpStatus = new BSE.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.panel2 = new BSE.Windows.Forms.Panel();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.bindingSourceGauges = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceStatus = new System.Windows.Forms.BindingSource(this.components);
            this.ZgTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.gpStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGauges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gpStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 700);
            this.panel1.TabIndex = 1;
            // 
            // gpStatus
            // 
            this.gpStatus.AssociatedSplitter = null;
            this.gpStatus.BackColor = System.Drawing.Color.Transparent;
            this.gpStatus.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Bold);
            this.gpStatus.CaptionHeight = 27;
            this.gpStatus.Controls.Add(this.pnlStatus);
            this.gpStatus.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.gpStatus.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.gpStatus.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.gpStatus.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.gpStatus.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.gpStatus.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gpStatus.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.gpStatus.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.gpStatus.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.gpStatus.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.gpStatus.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.gpStatus.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.gpStatus.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.gpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpStatus.Image = null;
            this.gpStatus.Location = new System.Drawing.Point(0, 331);
            this.gpStatus.MinimumSize = new System.Drawing.Size(27, 27);
            this.gpStatus.Name = "gpStatus";
            this.gpStatus.Size = new System.Drawing.Size(1027, 245);
            this.gpStatus.TabIndex = 2;
            this.gpStatus.Text = "遥测状态数据";
            this.gpStatus.ToolTipTextCloseIcon = null;
            this.gpStatus.ToolTipTextExpandIconPanelCollapsed = null;
            this.gpStatus.ToolTipTextExpandIconPanelExpanded = null;
            this.gpStatus.Visible = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.AutoScroll = true;
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(1, 28);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1025, 216);
            this.pnlStatus.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AssociatedSplitter = null;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Bold);
            this.panel2.CaptionHeight = 27;
            this.panel2.Controls.Add(this.zg1);
            this.panel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.panel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.panel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Image = null;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 331);
            this.panel2.TabIndex = 0;
            this.panel2.Text = "遥测状态曲线";
            this.panel2.ToolTipTextCloseIcon = null;
            this.panel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // zg1
            // 
            this.zg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zg1.Location = new System.Drawing.Point(1, 28);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(1025, 302);
            this.zg1.TabIndex = 0;
            this.zg1.DoubleClick += new System.EventHandler(this.zg1_DoubleClick);
            // 
            // bindingSourceGauges
            // 
            this.bindingSourceGauges.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceStatus
            // 
            this.bindingSourceStatus.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // ZgTimer
            // 
            this.ZgTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TelemetryMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TelemetryMgr";
            this.Size = new System.Drawing.Size(1027, 700);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelemetryMgr_FormClosing);
            this.Load += new System.EventHandler(this.TelemetryMgr_Load);
            this.panel1.ResumeLayout(false);
            this.gpStatus.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGauges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BSE.Windows.Forms.Panel gpStatus;
        private BSE.Windows.Forms.Panel panel2;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.BindingSource bindingSourceGauges;
        private System.Windows.Forms.BindingSource bindingSourceStatus;
        private System.Windows.Forms.Timer ZgTimer;

    }
}
