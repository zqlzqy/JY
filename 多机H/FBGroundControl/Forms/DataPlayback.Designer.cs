namespace FBGroundControl.Forms
{
    partial class DataPlayback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ZedGraph.ZedGraphControl zg1;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
           
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlactions = new System.Windows.Forms.TabControl();
            this.tabTLogs = new System.Windows.Forms.TabPage();
            this.tableLayoutPaneltlogs = new System.Windows.Forms.TableLayoutPanel();
            this.tracklog = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ZedGraphTimer = new System.Windows.Forms.Timer(this.components);
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.BUT_loadtelem = new MissionPlanner.Controls.MyButton();
            this.lbl_playbackspeed = new MissionPlanner.Controls.MyLabel();
            this.lbl_logpercent = new MissionPlanner.Controls.MyLabel();
            this.LBL_logfn = new MissionPlanner.Controls.MyLabel();
            this.BUT_playlog = new MissionPlanner.Controls.MyButton();
            this.BUT_speed10 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed5 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed2 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_2 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_4 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_10 = new MissionPlanner.Controls.MyButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceHud = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceStatusTab = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceQuickTab = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceGaugesTab = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlactions.SuspendLayout();
            this.tabTLogs.SuspendLayout();
            this.tableLayoutPaneltlogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlactions
            // 
            this.tabControlactions.Controls.Add(this.tabTLogs);
            this.tabControlactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlactions.Location = new System.Drawing.Point(0, 0);
            this.tabControlactions.Name = "tabControlactions";
            this.tabControlactions.Padding = new System.Drawing.Point(0, 0);
            this.tabControlactions.SelectedIndex = 0;
            this.tabControlactions.Size = new System.Drawing.Size(735, 297);
            this.tabControlactions.TabIndex = 85;
            // 
            // tabTLogs
            // 
            this.tabTLogs.Controls.Add(this.tableLayoutPaneltlogs);
            this.tabTLogs.Location = new System.Drawing.Point(4, 22);
            this.tabTLogs.Name = "tabTLogs";
            this.tabTLogs.Size = new System.Drawing.Size(727, 271);
            this.tabTLogs.TabIndex = 3;
            this.tabTLogs.Text = "数据回放";
            this.tabTLogs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPaneltlogs
            // 
            this.tableLayoutPaneltlogs.ColumnCount = 3;
            this.tableLayoutPaneltlogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPaneltlogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPaneltlogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPaneltlogs.Controls.Add(this.BUT_loadtelem, 0, 0);
            this.tableLayoutPaneltlogs.Controls.Add(this.lbl_playbackspeed, 2, 2);
            this.tableLayoutPaneltlogs.Controls.Add(this.lbl_logpercent, 2, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.tracklog, 1, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.LBL_logfn, 1, 0);
            this.tableLayoutPaneltlogs.Controls.Add(this.BUT_playlog, 0, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPaneltlogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPaneltlogs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPaneltlogs.Name = "tableLayoutPaneltlogs";
            this.tableLayoutPaneltlogs.RowCount = 3;
            this.tableLayoutPaneltlogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPaneltlogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPaneltlogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPaneltlogs.Size = new System.Drawing.Size(727, 271);
            this.tableLayoutPaneltlogs.TabIndex = 81;
            // 
            // tracklog
            // 
            this.tracklog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tracklog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tracklog.Location = new System.Drawing.Point(89, 33);
            this.tracklog.Maximum = 100;
            this.tracklog.Name = "tracklog";
            this.tracklog.Size = new System.Drawing.Size(594, 24);
            this.tracklog.TabIndex = 75;
            this.tracklog.TickFrequency = 5;
            this.tracklog.Scroll += new System.EventHandler(this.tracklog_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BUT_speed10);
            this.panel2.Controls.Add(this.BUT_speed5);
            this.panel2.Controls.Add(this.BUT_speed2);
            this.panel2.Controls.Add(this.BUT_speed1);
            this.panel2.Controls.Add(this.BUT_speed1_2);
            this.panel2.Controls.Add(this.BUT_speed1_4);
            this.panel2.Controls.Add(this.BUT_speed1_10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(89, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 205);
            this.panel2.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(90, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "Speed";
            // 
            // ZedGraphTimer
            // 
            this.ZedGraphTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(0, 0);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(150, 138);
            this.zg1.TabIndex = 0;
            // 
            // BUT_loadtelem
            // 
            this.BUT_loadtelem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_loadtelem.Location = new System.Drawing.Point(3, 3);
            this.BUT_loadtelem.Name = "BUT_loadtelem";
            this.BUT_loadtelem.Size = new System.Drawing.Size(80, 21);
            this.BUT_loadtelem.TabIndex = 71;
            this.BUT_loadtelem.Text = "加载日志";
            this.BUT_loadtelem.UseVisualStyleBackColor = true;
            this.BUT_loadtelem.Click += new System.EventHandler(this.BUT_loadtelem_Click);
            // 
            // lbl_playbackspeed
            // 
            this.lbl_playbackspeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_playbackspeed.Location = new System.Drawing.Point(689, 63);
            this.lbl_playbackspeed.Name = "lbl_playbackspeed";
            this.lbl_playbackspeed.resize = false;
            this.lbl_playbackspeed.Size = new System.Drawing.Size(35, 42);
            this.lbl_playbackspeed.TabIndex = 79;
            this.lbl_playbackspeed.Text = "x 1.0";
            // 
            // lbl_logpercent
            // 
            this.lbl_logpercent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_logpercent.Location = new System.Drawing.Point(689, 33);
            this.lbl_logpercent.Name = "lbl_logpercent";
            this.lbl_logpercent.resize = false;
            this.lbl_logpercent.Size = new System.Drawing.Size(35, 18);
            this.lbl_logpercent.TabIndex = 78;
            this.lbl_logpercent.Text = "0.00 %";
            // 
            // LBL_logfn
            // 
            this.tableLayoutPaneltlogs.SetColumnSpan(this.LBL_logfn, 2);
            this.LBL_logfn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_logfn.Location = new System.Drawing.Point(89, 3);
            this.LBL_logfn.Name = "LBL_logfn";
            this.LBL_logfn.resize = false;
            this.LBL_logfn.Size = new System.Drawing.Size(635, 24);
            this.LBL_logfn.TabIndex = 80;
            // 
            // BUT_playlog
            // 
            this.BUT_playlog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_playlog.Location = new System.Drawing.Point(3, 33);
            this.BUT_playlog.Name = "BUT_playlog";
            this.BUT_playlog.Size = new System.Drawing.Size(80, 21);
            this.BUT_playlog.TabIndex = 73;
            this.BUT_playlog.Text = "Play/Pause";
            this.BUT_playlog.UseVisualStyleBackColor = true;
            this.BUT_playlog.Click += new System.EventHandler(this.BUT_playlog_Click);
            // 
            // BUT_speed10
            // 
            this.BUT_speed10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed10.Location = new System.Drawing.Point(184, 21);
            this.BUT_speed10.Name = "BUT_speed10";
            this.BUT_speed10.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed10.TabIndex = 83;
            this.BUT_speed10.Tag = "10";
            this.BUT_speed10.Text = "10x";
            this.BUT_speed10.UseVisualStyleBackColor = true;
            this.BUT_speed10.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed5
            // 
            this.BUT_speed5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed5.Location = new System.Drawing.Point(155, 21);
            this.BUT_speed5.Name = "BUT_speed5";
            this.BUT_speed5.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed5.TabIndex = 82;
            this.BUT_speed5.Tag = "5";
            this.BUT_speed5.Text = "5x";
            this.BUT_speed5.UseVisualStyleBackColor = true;
            this.BUT_speed5.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed2
            // 
            this.BUT_speed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed2.Location = new System.Drawing.Point(126, 21);
            this.BUT_speed2.Name = "BUT_speed2";
            this.BUT_speed2.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed2.TabIndex = 81;
            this.BUT_speed2.Tag = "2";
            this.BUT_speed2.Text = "2x";
            this.BUT_speed2.UseVisualStyleBackColor = true;
            this.BUT_speed2.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed1
            // 
            this.BUT_speed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed1.Location = new System.Drawing.Point(97, 21);
            this.BUT_speed1.Name = "BUT_speed1";
            this.BUT_speed1.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed1.TabIndex = 80;
            this.BUT_speed1.Tag = "1";
            this.BUT_speed1.Text = "1x";
            this.BUT_speed1.UseVisualStyleBackColor = true;
            this.BUT_speed1.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed1_2
            // 
            this.BUT_speed1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed1_2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed1_2.Location = new System.Drawing.Point(68, 21);
            this.BUT_speed1_2.Name = "BUT_speed1_2";
            this.BUT_speed1_2.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed1_2.TabIndex = 79;
            this.BUT_speed1_2.Tag = "0.5";
            this.BUT_speed1_2.Text = "1/2";
            this.BUT_speed1_2.UseVisualStyleBackColor = true;
            this.BUT_speed1_2.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed1_4
            // 
            this.BUT_speed1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed1_4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed1_4.Location = new System.Drawing.Point(39, 21);
            this.BUT_speed1_4.Name = "BUT_speed1_4";
            this.BUT_speed1_4.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed1_4.TabIndex = 78;
            this.BUT_speed1_4.Tag = "0.25";
            this.BUT_speed1_4.Text = "1/4";
            this.BUT_speed1_4.UseVisualStyleBackColor = true;
            this.BUT_speed1_4.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // BUT_speed1_10
            // 
            this.BUT_speed1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.BUT_speed1_10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_speed1_10.Location = new System.Drawing.Point(10, 21);
            this.BUT_speed1_10.Name = "BUT_speed1_10";
            this.BUT_speed1_10.Size = new System.Drawing.Size(23, 18);
            this.BUT_speed1_10.TabIndex = 77;
            this.BUT_speed1_10.Tag = "0.1";
            this.BUT_speed1_10.Text = "1/10";
            this.BUT_speed1_10.UseVisualStyleBackColor = true;
            this.BUT_speed1_10.Click += new System.EventHandler(this.BUT_speed1_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceHud
            // 
            this.bindingSourceHud.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceStatusTab
            // 
            this.bindingSourceStatusTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceQuickTab
            // 
            this.bindingSourceQuickTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // bindingSourceGaugesTab
            // 
            this.bindingSourceGaugesTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // DataPlayback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 297);
            this.Controls.Add(this.tabControlactions);
            this.Name = "DataPlayback";
            this.Text = "数据回放";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataPlayback_FormClosing);
            this.Load += new System.EventHandler(this.DataPlayback_Load);
            this.tabControlactions.ResumeLayout(false);
            this.tabTLogs.ResumeLayout(false);
            this.tableLayoutPaneltlogs.ResumeLayout(false);
            this.tableLayoutPaneltlogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStatusTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGaugesTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControlactions;
        private System.Windows.Forms.TabPage tabTLogs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPaneltlogs;
        private MissionPlanner.Controls.MyButton BUT_loadtelem;
        private MissionPlanner.Controls.MyLabel lbl_playbackspeed;
        private MissionPlanner.Controls.MyLabel lbl_logpercent;
        private System.Windows.Forms.TrackBar tracklog;
        private MissionPlanner.Controls.MyLabel LBL_logfn;
        private MissionPlanner.Controls.MyButton BUT_playlog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private MissionPlanner.Controls.MyButton BUT_speed10;
        private MissionPlanner.Controls.MyButton BUT_speed5;
        private MissionPlanner.Controls.MyButton BUT_speed2;
        private MissionPlanner.Controls.MyButton BUT_speed1;
        private MissionPlanner.Controls.MyButton BUT_speed1_2;
        private MissionPlanner.Controls.MyButton BUT_speed1_4;
        private MissionPlanner.Controls.MyButton BUT_speed1_10;
        private System.Windows.Forms.Timer ZedGraphTimer;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSourceHud;
        private System.Windows.Forms.BindingSource bindingSourceStatusTab;
        private System.Windows.Forms.BindingSource bindingSourceQuickTab;
        private System.Windows.Forms.BindingSource bindingSourceGaugesTab;

    }
}