namespace FBGroundControl.Forms
{
    partial class PlanImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanImage));
            this.back_pictureBox = new System.Windows.Forms.PictureBox();
            this.down_pictureBox = new System.Windows.Forms.PictureBox();
            this.front_pictureBox = new System.Windows.Forms.PictureBox();
            this.left_pictureBox = new System.Windows.Forms.PictureBox();
            this.right_pictureBox = new System.Windows.Forms.PictureBox();
            this.up_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.back_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.down_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.front_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.up_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // back_pictureBox
            // 
            this.back_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_back;
            this.back_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.back_pictureBox.Name = "back_pictureBox";
            this.back_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.back_pictureBox.TabIndex = 5;
            this.back_pictureBox.TabStop = false;
            this.back_pictureBox.Visible = false;
            // 
            // down_pictureBox
            // 
            this.down_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.down_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_down;
            this.down_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.down_pictureBox.Name = "down_pictureBox";
            this.down_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.down_pictureBox.TabIndex = 4;
            this.down_pictureBox.TabStop = false;
            this.down_pictureBox.Visible = false;
            // 
            // front_pictureBox
            // 
            this.front_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.front_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("front_pictureBox.Image")));
            this.front_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.front_pictureBox.Name = "front_pictureBox";
            this.front_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.front_pictureBox.TabIndex = 3;
            this.front_pictureBox.TabStop = false;
            // 
            // left_pictureBox
            // 
            this.left_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.left_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_left;
            this.left_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.left_pictureBox.Name = "left_pictureBox";
            this.left_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.left_pictureBox.TabIndex = 2;
            this.left_pictureBox.TabStop = false;
            this.left_pictureBox.Visible = false;
            // 
            // right_pictureBox
            // 
            this.right_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.right_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_right;
            this.right_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.right_pictureBox.Name = "right_pictureBox";
            this.right_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.right_pictureBox.TabIndex = 1;
            this.right_pictureBox.TabStop = false;
            this.right_pictureBox.Visible = false;
            // 
            // up_pictureBox
            // 
            this.up_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.up_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_up;
            this.up_pictureBox.InitialImage = null;
            this.up_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.up_pictureBox.Name = "up_pictureBox";
            this.up_pictureBox.Size = new System.Drawing.Size(948, 753);
            this.up_pictureBox.TabIndex = 0;
            this.up_pictureBox.TabStop = false;
            this.up_pictureBox.Visible = false;
            // 
            // PlanImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back_pictureBox);
            this.Controls.Add(this.down_pictureBox);
            this.Controls.Add(this.front_pictureBox);
            this.Controls.Add(this.left_pictureBox);
            this.Controls.Add(this.right_pictureBox);
            this.Controls.Add(this.up_pictureBox);
            this.Name = "PlanImage";
            this.Size = new System.Drawing.Size(948, 753);
            ((System.ComponentModel.ISupportInitialize)(this.back_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.down_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.front_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.up_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox up_pictureBox;
        public System.Windows.Forms.PictureBox right_pictureBox;
        public System.Windows.Forms.PictureBox left_pictureBox;
        public System.Windows.Forms.PictureBox front_pictureBox;
        public System.Windows.Forms.PictureBox down_pictureBox;
        public System.Windows.Forms.PictureBox back_pictureBox;
    }
}
