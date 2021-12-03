using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class SatelliteStarStatusView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatelliteStarStatusView));
            this.panel2 = new System.Windows.Forms.Panel();
            this.test_button = new System.Windows.Forms.Button();
            this.gps_pictureBox = new System.Windows.Forms.PictureBox();
            this.snr_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gps_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snr_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.test_button);
            this.panel2.Controls.Add(this.gps_pictureBox);
            this.panel2.Location = new System.Drawing.Point(493, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 442);
            this.panel2.TabIndex = 2;
            // 
            // test_button
            // 
            this.test_button.Location = new System.Drawing.Point(306, 392);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(75, 23);
            this.test_button.TabIndex = 1;
            this.test_button.Text = "星况测试";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // gps_pictureBox
            // 
            this.gps_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gps_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gps_pictureBox.BackgroundImage")));
            this.gps_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gps_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gps_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.gps_pictureBox.Name = "gps_pictureBox";
            this.gps_pictureBox.Size = new System.Drawing.Size(379, 311);
            this.gps_pictureBox.TabIndex = 0;
            this.gps_pictureBox.TabStop = false;
            this.gps_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gps_pictureBox_Paint);
            // 
            // snr_pictureBox
            // 
            this.snr_pictureBox.Location = new System.Drawing.Point(3, 3);
            this.snr_pictureBox.Name = "snr_pictureBox";
            this.snr_pictureBox.Size = new System.Drawing.Size(466, 311);
            this.snr_pictureBox.TabIndex = 3;
            this.snr_pictureBox.TabStop = false;
            this.snr_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.snr_pictureBox_Paint);
            // 
            // SatelliteStarStatusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.snr_pictureBox);
            this.Controls.Add(this.panel2);
            this.Name = "SatelliteStarStatusView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.SatelliteStarStatusView_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gps_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snr_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox gps_pictureBox;
        private System.Windows.Forms.Button test_button;
        private System.Windows.Forms.PictureBox snr_pictureBox;
    }
}
