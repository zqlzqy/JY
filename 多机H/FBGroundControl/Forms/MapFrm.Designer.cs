namespace FBGroundControl.Forms
{
    partial class MapFrm
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
           
            //base.Dispose(disposing);
            if (MainForm.isExitSystem)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else
            {
                IsHidden = true;
            }
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rang_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flyToPoint_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTracks_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datamode_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planmode_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.勾径规划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图复位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_pickMousePoint = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rang_ToolStripMenuItem,
            this.flyToPoint_ToolStripMenuItem,
            this.clearTracks_ToolStripMenuItem,
            this.模式ToolStripMenuItem,
            this.勾径规划ToolStripMenuItem,
            this.地图复位ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 136);
            // 
            // rang_ToolStripMenuItem
            // 
            this.rang_ToolStripMenuItem.CheckOnClick = true;
            this.rang_ToolStripMenuItem.Name = "rang_ToolStripMenuItem";
            this.rang_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.rang_ToolStripMenuItem.Text = "测距";
            this.rang_ToolStripMenuItem.Click += new System.EventHandler(this.rang_ToolStripMenuItem_Click);
            // 
            // flyToPoint_ToolStripMenuItem
            // 
            this.flyToPoint_ToolStripMenuItem.Name = "flyToPoint_ToolStripMenuItem";
            this.flyToPoint_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.flyToPoint_ToolStripMenuItem.Text = "跳转至某点";
            // 
            // clearTracks_ToolStripMenuItem
            // 
            this.clearTracks_ToolStripMenuItem.Name = "clearTracks_ToolStripMenuItem";
            this.clearTracks_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearTracks_ToolStripMenuItem.Text = "清除轨迹";
            // 
            // 模式ToolStripMenuItem
            // 
            this.模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datamode_ToolStripMenuItem,
            this.planmode_ToolStripMenuItem});
            this.模式ToolStripMenuItem.Name = "模式ToolStripMenuItem";
            this.模式ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.模式ToolStripMenuItem.Text = "模式";
            // 
            // datamode_ToolStripMenuItem
            // 
            this.datamode_ToolStripMenuItem.Checked = true;
            this.datamode_ToolStripMenuItem.CheckOnClick = true;
            this.datamode_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.datamode_ToolStripMenuItem.Name = "datamode_ToolStripMenuItem";
            this.datamode_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.datamode_ToolStripMenuItem.Text = "数据模式";
            // 
            // planmode_ToolStripMenuItem
            // 
            this.planmode_ToolStripMenuItem.CheckOnClick = true;
            this.planmode_ToolStripMenuItem.Name = "planmode_ToolStripMenuItem";
            this.planmode_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.planmode_ToolStripMenuItem.Text = "规划模式";
            this.planmode_ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.planmode_ToolStripMenuItem_CheckStateChanged);
            // 
            // 勾径规划ToolStripMenuItem
            // 
            this.勾径规划ToolStripMenuItem.Name = "勾径规划ToolStripMenuItem";
            this.勾径规划ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.勾径规划ToolStripMenuItem.Text = "勾径规划";
            // 
            // 地图复位ToolStripMenuItem
            // 
            this.地图复位ToolStripMenuItem.Name = "地图复位ToolStripMenuItem";
            this.地图复位ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.地图复位ToolStripMenuItem.Text = "地图复位";
            this.地图复位ToolStripMenuItem.Click += new System.EventHandler(this.地图复位ToolStripMenuItem_Click);
            // 
            // lbl_pickMousePoint
            // 
            this.lbl_pickMousePoint.AutoSize = true;
            this.lbl_pickMousePoint.Location = new System.Drawing.Point(707, 9);
            this.lbl_pickMousePoint.Name = "lbl_pickMousePoint";
            this.lbl_pickMousePoint.Size = new System.Drawing.Size(65, 12);
            this.lbl_pickMousePoint.TabIndex = 51;
            this.lbl_pickMousePoint.Text = "当前坐标：";
            this.lbl_pickMousePoint.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.Location = new System.Drawing.Point(14, 134);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 124);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 55;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MapFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 421);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lbl_pickMousePoint);
            this.DoubleBuffered = true;
            this.Name = "MapFrm";
            this.Text = "地图区";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapFrm_FormClosing);
            this.Load += new System.EventHandler(this.MapFrm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapFrm_Paint_1);
            this.Resize += new System.EventHandler(this.MapFrm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rang_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flyToPoint_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTracks_ToolStripMenuItem;
        private System.Windows.Forms.Label lbl_pickMousePoint;
        private System.Windows.Forms.ToolStripMenuItem 模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datamode_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planmode_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 勾径规划ToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem 地图复位ToolStripMenuItem;
    }
}