using System.Collections.Generic;
using System.Windows.Forms;
namespace FBGroundControl.Forms
{
    partial class ConfigFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        //姿态环参数
        private AttitudeLoopView attitudeLoopView;
        //过载环参数
        private OverLoadLoopView overloadLoopView;
        //制导参数
        private GuideCtrlView guidectrlView;
        //起飞参数
        private TakeOffView takeoffView;
        //引导参数
        private GuideView guideView;
        //盘旋参数
        private LoiterView loiterView;
        //极限参数
        private LimitView limitView;
        //舵面配平参数
        private SteerTrimView steertrimView;

        private IMUSetParmView imutrimView;

        private NAVsetView navsetView;


        private MicrowaveView microwaveView;

        private KongyuView kongyuView;
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
            this.attitudeloop_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Microwaveset = new System.Windows.Forms.Button();
            this.navset = new System.Windows.Forms.Button();
            this.imutrim_button = new System.Windows.Forms.Button();
            this.steertrim_button = new System.Windows.Forms.Button();
            this.limit_button = new System.Windows.Forms.Button();
            this.loiter_button = new System.Windows.Forms.Button();
            this.guide_button = new System.Windows.Forms.Button();
            this.takeoff_button = new System.Windows.Forms.Button();
            this.guidectrl_button = new System.Windows.Forms.Button();
            this.overloadloop_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_button = new System.Windows.Forms.Button();
            this.attitudeLoopView = new FBGroundControl.Forms.AttitudeLoopView();
            this.overloadLoopView = new FBGroundControl.Forms.OverLoadLoopView();
            this.guidectrlView = new FBGroundControl.Forms.GuideCtrlView();
            this.takeoffView = new FBGroundControl.Forms.TakeOffView();
            this.guideView = new FBGroundControl.Forms.GuideView();
            this.loiterView = new FBGroundControl.Forms.LoiterView();
            this.limitView = new FBGroundControl.Forms.LimitView();
            this.steertrimView = new FBGroundControl.Forms.SteerTrimView();
            this.imutrimView = new FBGroundControl.Forms.IMUSetParmView();
            this.navsetView = new FBGroundControl.Forms.NAVsetView();
            this.microwaveView = new FBGroundControl.Forms.MicrowaveView();
            this.kongyuView = new FBGroundControl.Forms.KongyuView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // attitudeloop_button
            // 
            this.attitudeloop_button.Location = new System.Drawing.Point(15, 29);
            this.attitudeloop_button.Name = "attitudeloop_button";
            this.attitudeloop_button.Size = new System.Drawing.Size(168, 23);
            this.attitudeloop_button.TabIndex = 2;
            this.attitudeloop_button.Text = "姿态环参数";
            this.attitudeloop_button.UseVisualStyleBackColor = true;
            this.attitudeloop_button.Click += new System.EventHandler(this.attitudeloop_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Microwaveset);
            this.groupBox1.Controls.Add(this.navset);
            this.groupBox1.Controls.Add(this.imutrim_button);
            this.groupBox1.Controls.Add(this.steertrim_button);
            this.groupBox1.Controls.Add(this.limit_button);
            this.groupBox1.Controls.Add(this.loiter_button);
            this.groupBox1.Controls.Add(this.guide_button);
            this.groupBox1.Controls.Add(this.takeoff_button);
            this.groupBox1.Controls.Add(this.guidectrl_button);
            this.groupBox1.Controls.Add(this.overloadloop_button);
            this.groupBox1.Controls.Add(this.attitudeloop_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 618);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调参项目";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Microwaveset
            // 
            this.Microwaveset.Location = new System.Drawing.Point(16, 480);
            this.Microwaveset.Name = "Microwaveset";
            this.Microwaveset.Size = new System.Drawing.Size(168, 23);
            this.Microwaveset.TabIndex = 12;
            this.Microwaveset.Text = "多机模式参数";
            this.Microwaveset.UseVisualStyleBackColor = true;
            this.Microwaveset.Click += new System.EventHandler(this.Microwaveset_Click);
            // 
            // navset
            // 
            this.navset.Location = new System.Drawing.Point(16, 357);
            this.navset.Name = "navset";
            this.navset.Size = new System.Drawing.Size(168, 23);
            this.navset.TabIndex = 11;
            this.navset.Text = "空域参数";
            this.navset.UseVisualStyleBackColor = true;
            this.navset.Click += new System.EventHandler(this.navset_Click);
            // 
            // imutrim_button
            // 
            this.imutrim_button.Location = new System.Drawing.Point(16, 439);
            this.imutrim_button.Name = "imutrim_button";
            this.imutrim_button.Size = new System.Drawing.Size(168, 23);
            this.imutrim_button.TabIndex = 10;
            this.imutrim_button.Text = "多机控制参数";
            this.imutrim_button.UseVisualStyleBackColor = true;
            this.imutrim_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // steertrim_button
            // 
            this.steertrim_button.Location = new System.Drawing.Point(16, 316);
            this.steertrim_button.Name = "steertrim_button";
            this.steertrim_button.Size = new System.Drawing.Size(168, 23);
            this.steertrim_button.TabIndex = 9;
            this.steertrim_button.Text = "舵面参数";
            this.steertrim_button.UseVisualStyleBackColor = true;
            this.steertrim_button.Click += new System.EventHandler(this.steertrim_button_Click);
            // 
            // limit_button
            // 
            this.limit_button.Location = new System.Drawing.Point(16, 275);
            this.limit_button.Name = "limit_button";
            this.limit_button.Size = new System.Drawing.Size(168, 23);
            this.limit_button.TabIndex = 8;
            this.limit_button.Text = "极限参数";
            this.limit_button.UseVisualStyleBackColor = true;
            this.limit_button.Click += new System.EventHandler(this.limit_button_Click);
            // 
            // loiter_button
            // 
            this.loiter_button.Location = new System.Drawing.Point(16, 234);
            this.loiter_button.Name = "loiter_button";
            this.loiter_button.Size = new System.Drawing.Size(168, 23);
            this.loiter_button.TabIndex = 7;
            this.loiter_button.Text = "盘旋飞行参数";
            this.loiter_button.UseVisualStyleBackColor = true;
            this.loiter_button.Click += new System.EventHandler(this.loiter_button_Click);
            // 
            // guide_button
            // 
            this.guide_button.Location = new System.Drawing.Point(15, 193);
            this.guide_button.Name = "guide_button";
            this.guide_button.Size = new System.Drawing.Size(168, 23);
            this.guide_button.TabIndex = 6;
            this.guide_button.Text = "引导参数";
            this.guide_button.UseVisualStyleBackColor = true;
            this.guide_button.Click += new System.EventHandler(this.guide_button_Click);
            // 
            // takeoff_button
            // 
            this.takeoff_button.Location = new System.Drawing.Point(15, 152);
            this.takeoff_button.Name = "takeoff_button";
            this.takeoff_button.Size = new System.Drawing.Size(168, 23);
            this.takeoff_button.TabIndex = 5;
            this.takeoff_button.Text = "起飞参数";
            this.takeoff_button.UseVisualStyleBackColor = true;
            this.takeoff_button.Click += new System.EventHandler(this.takeoff_button_Click);
            // 
            // guidectrl_button
            // 
            this.guidectrl_button.Location = new System.Drawing.Point(16, 111);
            this.guidectrl_button.Name = "guidectrl_button";
            this.guidectrl_button.Size = new System.Drawing.Size(168, 23);
            this.guidectrl_button.TabIndex = 4;
            this.guidectrl_button.Text = "制导参数";
            this.guidectrl_button.UseVisualStyleBackColor = true;
            this.guidectrl_button.Click += new System.EventHandler(this.guidectrl_button_Click);
            // 
            // overloadloop_button
            // 
            this.overloadloop_button.Location = new System.Drawing.Point(15, 70);
            this.overloadloop_button.Name = "overloadloop_button";
            this.overloadloop_button.Size = new System.Drawing.Size(168, 23);
            this.overloadloop_button.TabIndex = 3;
            this.overloadloop_button.Text = "过载环参数";
            this.overloadloop_button.UseVisualStyleBackColor = true;
            this.overloadloop_button.Click += new System.EventHandler(this.overloadloop_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1054, 618);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.check_button);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(200, 569);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1054, 49);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
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
            // attitudeLoopView
            // 
            this.attitudeLoopView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attitudeLoopView.Location = new System.Drawing.Point(0, 0);
            this.attitudeLoopView.Margin = new System.Windows.Forms.Padding(4);
            this.attitudeLoopView.Name = "attitudeLoopView";
            this.attitudeLoopView.Size = new System.Drawing.Size(1009, 471);
            this.attitudeLoopView.TabIndex = 0;
            // 
            // overloadLoopView
            // 
            this.overloadLoopView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overloadLoopView.Location = new System.Drawing.Point(0, 0);
            this.overloadLoopView.Margin = new System.Windows.Forms.Padding(4);
            this.overloadLoopView.Name = "overloadLoopView";
            this.overloadLoopView.Size = new System.Drawing.Size(1009, 471);
            this.overloadLoopView.TabIndex = 0;
            // 
            // guidectrlView
            // 
            this.guidectrlView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guidectrlView.Location = new System.Drawing.Point(0, 0);
            this.guidectrlView.Margin = new System.Windows.Forms.Padding(4);
            this.guidectrlView.Name = "guidectrlView";
            this.guidectrlView.Size = new System.Drawing.Size(1009, 471);
            this.guidectrlView.TabIndex = 0;
            // 
            // takeoffView
            // 
            this.takeoffView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.takeoffView.Location = new System.Drawing.Point(0, 0);
            this.takeoffView.Margin = new System.Windows.Forms.Padding(4);
            this.takeoffView.Name = "takeoffView";
            this.takeoffView.Size = new System.Drawing.Size(1009, 471);
            this.takeoffView.TabIndex = 0;
            // 
            // guideView
            // 
            this.guideView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guideView.Location = new System.Drawing.Point(0, 0);
            this.guideView.Margin = new System.Windows.Forms.Padding(4);
            this.guideView.Name = "guideView";
            this.guideView.Size = new System.Drawing.Size(1009, 471);
            this.guideView.TabIndex = 0;
            // 
            // loiterView
            // 
            this.loiterView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loiterView.Location = new System.Drawing.Point(0, 0);
            this.loiterView.Margin = new System.Windows.Forms.Padding(4);
            this.loiterView.Name = "loiterView";
            this.loiterView.Size = new System.Drawing.Size(1009, 471);
            this.loiterView.TabIndex = 0;
            // 
            // limitView
            // 
            this.limitView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.limitView.Location = new System.Drawing.Point(0, 0);
            this.limitView.Margin = new System.Windows.Forms.Padding(4);
            this.limitView.Name = "limitView";
            this.limitView.Size = new System.Drawing.Size(1009, 471);
            this.limitView.TabIndex = 0;
            // 
            // steertrimView
            // 
            this.steertrimView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steertrimView.isEnable = false;
            this.steertrimView.Location = new System.Drawing.Point(0, 0);
            this.steertrimView.Margin = new System.Windows.Forms.Padding(4);
            this.steertrimView.Name = "steertrimView";
            this.steertrimView.Size = new System.Drawing.Size(1009, 471);
            this.steertrimView.TabIndex = 0;
            // 
            // imutrimView
            // 
            this.imutrimView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imutrimView.Location = new System.Drawing.Point(0, 0);
            this.imutrimView.Margin = new System.Windows.Forms.Padding(4);
            this.imutrimView.Name = "imutrimView";
            this.imutrimView.Size = new System.Drawing.Size(1009, 471);
            this.imutrimView.TabIndex = 0;
            // 
            // navsetView
            // 
            this.navsetView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navsetView.Location = new System.Drawing.Point(0, 0);
            this.navsetView.Margin = new System.Windows.Forms.Padding(4);
            this.navsetView.Name = "navsetView";
            this.navsetView.Size = new System.Drawing.Size(1009, 471);
            this.navsetView.TabIndex = 0;
            // 
            // microwaveView
            // 
            this.microwaveView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.microwaveView.Location = new System.Drawing.Point(0, 0);
            this.microwaveView.Name = "microwaveView";
            this.microwaveView.Size = new System.Drawing.Size(1009, 579);
            this.microwaveView.TabIndex = 0;
            // 
            // kongyuView
            // 
            this.kongyuView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kongyuView.Location = new System.Drawing.Point(0, 0);
            this.kongyuView.Name = "kongyuView";
            this.kongyuView.Size = new System.Drawing.Size(1009, 579);
            this.kongyuView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "微波源参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 618);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigFrm";
            this.Text = "调参";
            this.Load += new System.EventHandler(this.ConfigFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button attitudeloop_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button guide_button;
        private System.Windows.Forms.Button takeoff_button;
        private System.Windows.Forms.Button guidectrl_button;
        private System.Windows.Forms.Button overloadloop_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button check_button;
        private Button limit_button;
        private Button loiter_button;
        private Button steertrim_button;
        private Button imutrim_button;
        private Button navset;
        private Button Microwaveset;
        private Button button1;

    }
}