using MissionPlanner.Controls;

namespace FBGroundControl.Forms
{
    partial class ConfigAccelerometerCalibration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigAccelerometerCalibration));
            this.back_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.down_pictureBox = new System.Windows.Forms.PictureBox();
            this.front_pictureBox = new System.Windows.Forms.PictureBox();
            this.left_pictureBox = new System.Windows.Forms.PictureBox();
            this.right_pictureBox = new System.Windows.Forms.PictureBox();
            this.up_pictureBox = new System.Windows.Forms.PictureBox();
            this.lbl_Accel_user = new System.Windows.Forms.Label();
            this.lineSeparator2 = new MissionPlanner.Controls.LineSeparator();
            this.BUT_level = new MissionPlanner.Controls.MyButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BUT_calib_accell = new MissionPlanner.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize)(this.back_pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.down_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.front_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.up_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // back_pictureBox
            // 
            resources.ApplyResources(this.back_pictureBox, "back_pictureBox");
            this.back_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_back;
            this.back_pictureBox.Name = "back_pictureBox";
            this.back_pictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BUT_calib_accell);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BUT_level);
            this.panel1.Controls.Add(this.lineSeparator2);
            this.panel1.Controls.Add(this.lbl_Accel_user);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.down_pictureBox);
            this.panel2.Controls.Add(this.back_pictureBox);
            this.panel2.Controls.Add(this.front_pictureBox);
            this.panel2.Controls.Add(this.left_pictureBox);
            this.panel2.Controls.Add(this.right_pictureBox);
            this.panel2.Controls.Add(this.up_pictureBox);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // down_pictureBox
            // 
            resources.ApplyResources(this.down_pictureBox, "down_pictureBox");
            this.down_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_down;
            this.down_pictureBox.Name = "down_pictureBox";
            this.down_pictureBox.TabStop = false;
            // 
            // front_pictureBox
            // 
            resources.ApplyResources(this.front_pictureBox, "front_pictureBox");
            this.front_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_front;
            this.front_pictureBox.Name = "front_pictureBox";
            this.front_pictureBox.TabStop = false;
            // 
            // left_pictureBox
            // 
            resources.ApplyResources(this.left_pictureBox, "left_pictureBox");
            this.left_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_left;
            this.left_pictureBox.Name = "left_pictureBox";
            this.left_pictureBox.TabStop = false;
            // 
            // right_pictureBox
            // 
            resources.ApplyResources(this.right_pictureBox, "right_pictureBox");
            this.right_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_right;
            this.right_pictureBox.Name = "right_pictureBox";
            this.right_pictureBox.TabStop = false;
            // 
            // up_pictureBox
            // 
            resources.ApplyResources(this.up_pictureBox, "up_pictureBox");
            this.up_pictureBox.Image = global::FBGroundControl.Properties.Resources.accel_up;
            this.up_pictureBox.Name = "up_pictureBox";
            this.up_pictureBox.TabStop = false;
            // 
            // lbl_Accel_user
            // 
            this.lbl_Accel_user.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lbl_Accel_user, "lbl_Accel_user");
            this.lbl_Accel_user.Name = "lbl_Accel_user";
            // 
            // lineSeparator2
            // 
            resources.ApplyResources(this.lineSeparator2, "lineSeparator2");
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Opacity1 = 0.6F;
            this.lineSeparator2.Opacity2 = 0.7F;
            this.lineSeparator2.Opacity3 = 0.1F;
            this.lineSeparator2.PrimaryColor = System.Drawing.Color.Black;
            this.lineSeparator2.SecondaryColor = System.Drawing.Color.Gainsboro;
            // 
            // BUT_level
            // 
            resources.ApplyResources(this.BUT_level, "BUT_level");
            this.BUT_level.Name = "BUT_level";
            this.BUT_level.UseVisualStyleBackColor = true;
            this.BUT_level.Click += new System.EventHandler(this.BUT_level_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Name = "label5";
            // 
            // BUT_calib_accell
            // 
            resources.ApplyResources(this.BUT_calib_accell, "BUT_calib_accell");
            this.BUT_calib_accell.Name = "BUT_calib_accell";
            this.BUT_calib_accell.UseVisualStyleBackColor = true;
            this.BUT_calib_accell.Click += new System.EventHandler(this.BUT_calib_accell_Click);
            // 
            // ConfigAccelerometerCalibration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ConfigAccelerometerCalibration";
            ((System.ComponentModel.ISupportInitialize)(this.back_pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.down_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.front_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.up_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox back_pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox up_pictureBox;
        public System.Windows.Forms.PictureBox right_pictureBox;
        public System.Windows.Forms.PictureBox left_pictureBox;
        public System.Windows.Forms.PictureBox front_pictureBox;
        public System.Windows.Forms.PictureBox down_pictureBox;
        private MyButton BUT_calib_accell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private MyButton BUT_level;
        private LineSeparator lineSeparator2;
        private System.Windows.Forms.Label lbl_Accel_user;
    }
}
