namespace FBGroundControl.Forms
{
    partial class Telemetry2
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
            this.quickView5 = new MissionPlanner.Controls.QuickView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quickView3 = new MissionPlanner.Controls.QuickView();
            this.quickView2 = new MissionPlanner.Controls.QuickView();
            this.quickView1 = new MissionPlanner.Controls.QuickView();
            this.quickView20 = new MissionPlanner.Controls.QuickView();
            this.quickView19 = new MissionPlanner.Controls.QuickView();
            this.quickView4 = new MissionPlanner.Controls.QuickView();
            this.quickView63 = new MissionPlanner.Controls.QuickView();
            this.quickView64 = new MissionPlanner.Controls.QuickView();
            this.quickView69 = new MissionPlanner.Controls.QuickView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // quickView5
            // 
            this.quickView5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.quickView5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView5.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "groundspeed", true));
            this.quickView5.desc = "速度";
            this.quickView5.Location = new System.Drawing.Point(11, 110);
            this.quickView5.Name = "quickView5";
            this.quickView5.number = -9999D;
            this.quickView5.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView5.numberformat = "0.0m/s";
            this.quickView5.Size = new System.Drawing.Size(154, 35);
            this.quickView5.TabIndex = 153;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // quickView3
            // 
            this.quickView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView3.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "pitch_set", true));
            this.quickView3.desc = "俯仰设定";
            this.quickView3.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView3.Location = new System.Drawing.Point(164, 42);
            this.quickView3.Name = "quickView3";
            this.quickView3.number = -9999D;
            this.quickView3.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView3.numberformat = "0.00°";
            this.quickView3.Size = new System.Drawing.Size(154, 35);
            this.quickView3.TabIndex = 152;
            // 
            // quickView2
            // 
            this.quickView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView2.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "roll", true));
            this.quickView2.desc = "滚转角";
            this.quickView2.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView2.Location = new System.Drawing.Point(11, 76);
            this.quickView2.Name = "quickView2";
            this.quickView2.number = -9999D;
            this.quickView2.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView2.numberformat = "0.00°";
            this.quickView2.Size = new System.Drawing.Size(154, 35);
            this.quickView2.TabIndex = 151;
            // 
            // quickView1
            // 
            this.quickView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.quickView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView1.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "roll_set", true));
            this.quickView1.desc = "滚转设定";
            this.quickView1.Location = new System.Drawing.Point(164, 76);
            this.quickView1.Name = "quickView1";
            this.quickView1.number = -9999D;
            this.quickView1.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView1.numberformat = "0.00°";
            this.quickView1.Size = new System.Drawing.Size(154, 35);
            this.quickView1.TabIndex = 150;
            // 
            // quickView20
            // 
            this.quickView20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.quickView20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView20.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "yaw", true));
            this.quickView20.desc = "航向";
            this.quickView20.Location = new System.Drawing.Point(164, 110);
            this.quickView20.Name = "quickView20";
            this.quickView20.number = -9999D;
            this.quickView20.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView20.numberformat = "0.0°";
            this.quickView20.Size = new System.Drawing.Size(154, 35);
            this.quickView20.TabIndex = 148;
            // 
            // quickView19
            // 
            this.quickView19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView19.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "Accz", true));
            this.quickView19.desc = "法向过载";
            this.quickView19.Location = new System.Drawing.Point(164, 144);
            this.quickView19.Name = "quickView19";
            this.quickView19.number = -9999D;
            this.quickView19.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView19.numberformat = "0.00g";
            this.quickView19.Size = new System.Drawing.Size(154, 35);
            this.quickView19.TabIndex = 147;
            // 
            // quickView4
            // 
            this.quickView4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView4.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "air_speed", true));
            this.quickView4.desc = "垂速";
            this.quickView4.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView4.Location = new System.Drawing.Point(11, 144);
            this.quickView4.Name = "quickView4";
            this.quickView4.number = -9999D;
            this.quickView4.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView4.numberformat = "0.0m/s";
            this.quickView4.Size = new System.Drawing.Size(154, 35);
            this.quickView4.TabIndex = 146;
            // 
            // quickView63
            // 
            this.quickView63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView63.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "zuhe_altitude", true));
            this.quickView63.desc = "高度";
            this.quickView63.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quickView63.Location = new System.Drawing.Point(11, 7);
            this.quickView63.Name = "quickView63";
            this.quickView63.number = -9999D;
            this.quickView63.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView63.numberformat = "0.0";
            this.quickView63.Size = new System.Drawing.Size(154, 35);
            this.quickView63.TabIndex = 143;
            // 
            // quickView64
            // 
            this.quickView64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.quickView64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView64.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "hight_set", true));
            this.quickView64.desc = "高度设定";
            this.quickView64.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quickView64.Location = new System.Drawing.Point(164, 7);
            this.quickView64.Name = "quickView64";
            this.quickView64.number = -9999D;
            this.quickView64.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView64.numberformat = "0.0";
            this.quickView64.Size = new System.Drawing.Size(154, 35);
            this.quickView64.TabIndex = 142;
            // 
            // quickView69
            // 
            this.quickView69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.quickView69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickView69.DataBindings.Add(new System.Windows.Forms.Binding("number", this.bindingSource1, "pitch", true));
            this.quickView69.desc = "俯仰角";
            this.quickView69.Font = new System.Drawing.Font("宋体", 5F);
            this.quickView69.Location = new System.Drawing.Point(11, 42);
            this.quickView69.Name = "quickView69";
            this.quickView69.number = -9999D;
            this.quickView69.numberColor = System.Drawing.SystemColors.ControlText;
            this.quickView69.numberformat = "0.00°";
            this.quickView69.Size = new System.Drawing.Size(154, 35);
            this.quickView69.TabIndex = 145;
            // 
            // Telemetry2
            // 
            this.AutoHidePortion = 0.4D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(332, 192);
            this.CloseButton = false;
            this.Controls.Add(this.quickView5);
            this.Controls.Add(this.quickView3);
            this.Controls.Add(this.quickView2);
            this.Controls.Add(this.quickView1);
            this.Controls.Add(this.quickView20);
            this.Controls.Add(this.quickView19);
            this.Controls.Add(this.quickView4);
            this.Controls.Add(this.quickView63);
            this.Controls.Add(this.quickView64);
            this.Controls.Add(this.quickView69);
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.Name = "Telemetry2";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            this.Text = "遥测显示";
            this.DockStateChanged += new System.EventHandler(this.Telemetry2_DockStateChanged);
            this.Activated += new System.EventHandler(this.Telemetry2_Activated);
            this.Load += new System.EventHandler(this.Telemetry2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Telemetry2_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource bindingSource1;
        private MissionPlanner.Controls.QuickView quickView20;
        private MissionPlanner.Controls.QuickView quickView19;
        private MissionPlanner.Controls.QuickView quickView4;
        private MissionPlanner.Controls.QuickView quickView63;
        private MissionPlanner.Controls.QuickView quickView64;
        private MissionPlanner.Controls.QuickView quickView69;
        private MissionPlanner.Controls.QuickView quickView1;
        private MissionPlanner.Controls.QuickView quickView2;
        private MissionPlanner.Controls.QuickView quickView3;
        private MissionPlanner.Controls.QuickView quickView5;

    }
}