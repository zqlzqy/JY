using System.Collections.Generic;
using System.Windows.Forms;
namespace FBGroundControl.Forms
{
    partial class SensorFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       
    
       
  
        private AirSpeedBAltView asbaView;
       

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
            this.airspeedbaltview_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_button = new System.Windows.Forms.Button();
            this.asbaView = new FBGroundControl.Forms.AirSpeedBAltView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // airspeedbaltview_button
            // 
            this.airspeedbaltview_button.Location = new System.Drawing.Point(15, 29);
            this.airspeedbaltview_button.Name = "airspeedbaltview_button";
            this.airspeedbaltview_button.Size = new System.Drawing.Size(168, 23);
            this.airspeedbaltview_button.TabIndex = 2;
            this.airspeedbaltview_button.Text = "空速气压高度陀螺";
            this.airspeedbaltview_button.UseVisualStyleBackColor = true;
            this.airspeedbaltview_button.Click += new System.EventHandler(this.airspeedbaltview_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.airspeedbaltview_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 431);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "传感器项目";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 432);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.check_button);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 53);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // check_button
            // 
            this.check_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.check_button.Location = new System.Drawing.Point(344, 17);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(75, 33);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "关闭";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // asbaView
            // 
            this.asbaView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.asbaView.Location = new System.Drawing.Point(0, 0);
            this.asbaView.Name = "asbaView";
            this.asbaView.Size = new System.Drawing.Size(1009, 471);
            this.asbaView.TabIndex = 0;
            // 
            // SensorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "SensorFrm";
            this.Text = "传感器校准";
            this.Load += new System.EventHandler(this.SensorFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button airspeedbaltview_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button check_button;

    }
}