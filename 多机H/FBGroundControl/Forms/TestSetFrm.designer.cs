using System.Collections.Generic;
using System.Windows.Forms;
namespace FBGroundControl.Forms
{
    partial class TestSetFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //


        //舵机测试
        private SteerTestView steerTestView;

        //线路检查
        private LineConnectView lineConnectView;
        //手动舵面检查
        private ManualCheckView manualCheckView;
        //自动舵面检查
        private StabilizeCheckView stabilizeCheckView;
        //姿态检查
        private AttitudeCheckView attitudeCheckView;
        //磁罗盘检查
        private MagneticView magneticView;

        //应急参数检查
        private MergencyView mergencyView;
        //动压检查
        private YnamicPressurevView ynamicPressurevView;
        //震动检查
        private PassesView passesView;
        //最终确认
        private FinalConfirmationView finalConfirmationView;

        //控制极性
        private CtrlPolarityiew cpView;
        //链路测试
        private LinkTestView linkTestView;
        

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
            this.LineConneect_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckRes_checkBox = new System.Windows.Forms.CheckBox();
            this.export_button = new System.Windows.Forms.Button();
            this.check_button = new System.Windows.Forms.Button();
            this.steerTestView = new FBGroundControl.Forms.SteerTestView();
            this.lineConnectView = new FBGroundControl.Forms.LineConnectView();
            this.manualCheckView = new FBGroundControl.Forms.ManualCheckView();
            this.attitudeCheckView = new FBGroundControl.Forms.AttitudeCheckView();
            this.stabilizeCheckView = new FBGroundControl.Forms.StabilizeCheckView();
            this.magneticView = new FBGroundControl.Forms.MagneticView();
            this.mergencyView = new FBGroundControl.Forms.MergencyView();
            this.ynamicPressurevView = new FBGroundControl.Forms.YnamicPressurevView();
            this.passesView = new FBGroundControl.Forms.PassesView();
            this.finalConfirmationView = new FBGroundControl.Forms.FinalConfirmationView();
            this.cpView = new FBGroundControl.Forms.CtrlPolarityiew();
            this.linkTestView = new FBGroundControl.Forms.LinkTestView();
            this.Manual_button = new System.Windows.Forms.Button();
            this.Stabilize_button = new System.Windows.Forms.Button();
            this.Attitude_button = new System.Windows.Forms.Button();
            this.Magnetic_button = new System.Windows.Forms.Button();
            this.Mergency_button = new System.Windows.Forms.Button();
            this.YnamicPressurev_button = new System.Windows.Forms.Button();
            this.Passes_button = new System.Windows.Forms.Button();
            this.FinalConfirmation_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LineConneect_button
            // 
            this.LineConneect_button.Location = new System.Drawing.Point(15, 29);
            this.LineConneect_button.Name = "LineConneect_button";
            this.LineConneect_button.Size = new System.Drawing.Size(168, 23);
            this.LineConneect_button.TabIndex = 2;
            this.LineConneect_button.Text = "线路检查";
            this.LineConneect_button.UseVisualStyleBackColor = true;
            this.LineConneect_button.Click += new System.EventHandler(this.LineConneect_button_Click);

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Manual_button);
            this.groupBox1.Controls.Add(this.Stabilize_button);
            this.groupBox1.Controls.Add(this.Attitude_button);
            this.groupBox1.Controls.Add(this.Magnetic_button);
            this.groupBox1.Controls.Add(this.Mergency_button);
            this.groupBox1.Controls.Add(this.YnamicPressurev_button);
            this.groupBox1.Controls.Add(this.Passes_button);
            this.groupBox1.Controls.Add(this.FinalConfirmation_button);
            this.groupBox1.Controls.Add(this.LineConneect_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 671);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检查项目";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 671);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测结果";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CheckRes_checkBox);
            this.groupBox3.Controls.Add(this.export_button);
            this.groupBox3.Controls.Add(this.check_button);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(200, 622);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1054, 49);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // CheckRes_checkBox
            // 
            this.CheckRes_checkBox.AutoSize = true;
            this.CheckRes_checkBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CheckRes_checkBox.Location = new System.Drawing.Point(805, 17);
            this.CheckRes_checkBox.Name = "CheckRes_checkBox";
            this.CheckRes_checkBox.Size = new System.Drawing.Size(96, 29);
            this.CheckRes_checkBox.TabIndex = 13;
            this.CheckRes_checkBox.Text = "勾取检测结果";
            this.CheckRes_checkBox.UseVisualStyleBackColor = true;
            // 
            // export_button
            // 
            this.export_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.export_button.Location = new System.Drawing.Point(901, 17);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(75, 29);
            this.export_button.TabIndex = 12;
            this.export_button.Text = "导出";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // check_button
            // 
            this.check_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.check_button.Location = new System.Drawing.Point(976, 17);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(75, 29);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "关闭";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);

            // 
            // steerTestView
            // 
            this.steerTestView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steerTestView.Location = new System.Drawing.Point(0, 0);
            this.steerTestView.Name = "steerTestView";
            this.steerTestView.Size = new System.Drawing.Size(1009, 471);
            this.steerTestView.TabIndex = 0;

            // 
            // lineConnectView
            // 
            this.lineConnectView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lineConnectView.Location = new System.Drawing.Point(0, 0);
            this.lineConnectView.Name = "lineConnectView";
            this.lineConnectView.Size = new System.Drawing.Size(1009, 471);
            this.lineConnectView.TabIndex = 0;
  //          this.lineConnectView.LineConnect_checkBox.Click += new System.EventHandler(this.LineConnect_checkBox_Click);

            // 
            // manualCheckView
            // 
            this.manualCheckView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.manualCheckView.Location = new System.Drawing.Point(0, 0);
            this.manualCheckView.Name = "manualCheckView";
            this.manualCheckView.Size = new System.Drawing.Size(1009, 471);
            this.manualCheckView.TabIndex = 0;

            // 
            // stabilizeCheckView
            // 
            this.stabilizeCheckView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stabilizeCheckView.Location = new System.Drawing.Point(0, 0);
            this.stabilizeCheckView.Name = "stabilizeCheckView";
            this.stabilizeCheckView.Size = new System.Drawing.Size(1009, 471);
            this.stabilizeCheckView.TabIndex = 0;

            // 
            // attitudeCheckView
            // 
            this.attitudeCheckView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attitudeCheckView.Location = new System.Drawing.Point(0, 0);
            this.attitudeCheckView.Name = "attitudeCheckView";
            this.attitudeCheckView.Size = new System.Drawing.Size(1009, 471);
            this.attitudeCheckView.TabIndex = 0;

            // 
            // magneticView
            // 
            this.magneticView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.magneticView.Location = new System.Drawing.Point(0, 0);
            this.magneticView.Name = "magneticView";
            this.magneticView.Size = new System.Drawing.Size(1009, 471);
            this.magneticView.TabIndex = 0;

            // 
            // mergencyView
            // 
            this.mergencyView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mergencyView.Location = new System.Drawing.Point(0, 0);
            this.mergencyView.Name = "mergencyView";
            this.mergencyView.Size = new System.Drawing.Size(1009, 471);
            this.mergencyView.TabIndex = 0;

            // 
            // ynamicPressurevView
            // 
            this.ynamicPressurevView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ynamicPressurevView.Location = new System.Drawing.Point(0, 0);
            this.ynamicPressurevView.Name = "ynamicPressurevView";
            this.ynamicPressurevView.Size = new System.Drawing.Size(1009, 471);
            this.ynamicPressurevView.TabIndex = 0;

            // 
            // passesView
            // 
            this.passesView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.passesView.Location = new System.Drawing.Point(0, 0);
            this.passesView.Name = "passesView";
            this.passesView.Size = new System.Drawing.Size(1009, 471);
            this.passesView.TabIndex = 0;

            // 
            // finalConfirmationView
            // 
            this.finalConfirmationView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finalConfirmationView.Location = new System.Drawing.Point(0, 0);
            this.finalConfirmationView.Name = "finalConfirmationView";
            this.finalConfirmationView.Size = new System.Drawing.Size(1009, 471);
            this.finalConfirmationView.TabIndex = 0;
            // 
            // cpView
            // 
            this.cpView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpView.Location = new System.Drawing.Point(0, 0);
            this.cpView.Name = "cpView";
            this.cpView.Size = new System.Drawing.Size(1009, 471);
            this.cpView.TabIndex = 0;
            // 
            // linkTestView
            // 
            this.linkTestView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.linkTestView.Location = new System.Drawing.Point(0, 0);
            this.linkTestView.Name = "linkTestView";
            this.linkTestView.Size = new System.Drawing.Size(660, 416);
            this.linkTestView.TabIndex = 0;
            // 
            // Manual_button
            // 
            this.Manual_button.Location = new System.Drawing.Point(12, 67);
            this.Manual_button.Name = "Manual_button";
            this.Manual_button.Size = new System.Drawing.Size(168, 23);
            this.Manual_button.TabIndex = 3;
            this.Manual_button.Text = "控制面手动检查";
            this.Manual_button.UseVisualStyleBackColor = true;
            this.Manual_button.Click += new System.EventHandler(this.Manual_button_Click);

            // 
            // Stabilize_button
            // 
            this.Stabilize_button.Location = new System.Drawing.Point(12, 105);
            this.Stabilize_button.Name = "Stabilize_button";
            this.Stabilize_button.Size = new System.Drawing.Size(168, 23);
            this.Stabilize_button.TabIndex = 3;
            this.Stabilize_button.Text = "控制面自动检查";
            this.Stabilize_button.UseVisualStyleBackColor = true;
            this.Stabilize_button.Click += new System.EventHandler(this.Stabilize_button_Click);

            // 
            // Attitude_button
            // 
            this.Attitude_button.Location = new System.Drawing.Point(12, 143);
            this.Attitude_button.Name = "Attitude_button";
            this.Attitude_button.Size = new System.Drawing.Size(168, 23);
            this.Attitude_button.TabIndex = 3;
            this.Attitude_button.Text = "姿态检查";
            this.Attitude_button.UseVisualStyleBackColor = true;
            this.Attitude_button.Click += new System.EventHandler(this.Attitude_button_Click);

            // 
            // Magnetic_button
            // 
            this.Magnetic_button.Location = new System.Drawing.Point(12, 181);
            this.Magnetic_button.Name = "Magnetic_button";
            this.Magnetic_button.Size = new System.Drawing.Size(168, 23);
            this.Magnetic_button.TabIndex = 3;
            this.Magnetic_button.Text = "磁罗盘检查";
            this.Magnetic_button.UseVisualStyleBackColor = true;
            this.Magnetic_button.Click += new System.EventHandler(this.Magnetic_button_Click);

            // 
            // Mergency_button
            // 
            this.Mergency_button.Location = new System.Drawing.Point(12, 219);
            this.Mergency_button.Name = "Mergency_button";
            this.Mergency_button.Size = new System.Drawing.Size(168, 23);
            this.Mergency_button.TabIndex = 3;
            this.Mergency_button.Text = "应急参数检查";
            this.Mergency_button.UseVisualStyleBackColor = true;
            this.Mergency_button.Click += new System.EventHandler(this.Mergency_button_Click);


            // 
            // YnamicPressurev_button
            // 
            this.YnamicPressurev_button.Location = new System.Drawing.Point(12, 257);
            this.YnamicPressurev_button.Name = "YnamicPressurev_button";
            this.YnamicPressurev_button.Size = new System.Drawing.Size(168, 23);
            this.YnamicPressurev_button.TabIndex = 3;
            this.YnamicPressurev_button.Text = "动压检查";
            this.YnamicPressurev_button.UseVisualStyleBackColor = true;
            this.YnamicPressurev_button.Click += new System.EventHandler(this.YnamicPressurev_button_Click);

            // 
            // Passes_button
            // 
            this.Passes_button.Location = new System.Drawing.Point(12, 295);
            this.Passes_button.Name = "Passes_button";
            this.Passes_button.Size = new System.Drawing.Size(168, 23);
            this.Passes_button.TabIndex = 3;
            this.Passes_button.Text = "震动状态检查";
            this.Passes_button.UseVisualStyleBackColor = true;
            this.Passes_button.Click += new System.EventHandler(this.Passes_button_Click);


            // 
            // FinalConfirmation_button
            // 
            this.FinalConfirmation_button.Location = new System.Drawing.Point(12, 333);
            this.FinalConfirmation_button.Name = "FinalConfirmation_button";
            this.FinalConfirmation_button.Size = new System.Drawing.Size(168, 23);
            this.FinalConfirmation_button.TabIndex = 3;
            this.FinalConfirmation_button.Text = "最终确认";
            this.FinalConfirmation_button.UseVisualStyleBackColor = true;
            this.FinalConfirmation_button.Click += new System.EventHandler(this.FinalConfirmation_button_Click);

            // 
            // TestSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 671);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestSetFrm";
            this.Text = "飞前检查";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LineConneect_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CheckRes_checkBox;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button check_button;
        private Button Manual_button;
        private Button Stabilize_button;
        private Button Attitude_button;
        private Button Magnetic_button;
        private Button Mergency_button;
        private Button YnamicPressurev_button;
        private Button Passes_button;
        private Button FinalConfirmation_button;

    }
}