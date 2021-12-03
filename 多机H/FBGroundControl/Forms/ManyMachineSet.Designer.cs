namespace FBGroundControl.Forms
{
    partial class ManyMachineSet
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
            this.mainPlan_label = new System.Windows.Forms.Label();
            this.mapPlan_label = new System.Windows.Forms.Label();
            this.CMB_modes = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPlan_label
            // 
            this.mainPlan_label.AutoSize = true;
            this.mainPlan_label.Location = new System.Drawing.Point(25, 31);
            this.mainPlan_label.Name = "mainPlan_label";
            this.mainPlan_label.Size = new System.Drawing.Size(101, 12);
            this.mainPlan_label.TabIndex = 0;
            this.mainPlan_label.Text = "主窗体监视飞机：";
            // 
            // mapPlan_label
            // 
            this.mapPlan_label.AutoSize = true;
            this.mapPlan_label.Location = new System.Drawing.Point(36, 82);
            this.mapPlan_label.Name = "mapPlan_label";
            this.mapPlan_label.Size = new System.Drawing.Size(89, 12);
            this.mapPlan_label.TabIndex = 1;
            this.mapPlan_label.Text = "地图监控飞机：";
            // 
            // CMB_modes
            // 
            this.CMB_modes.FormattingEnabled = true;
            this.CMB_modes.Location = new System.Drawing.Point(132, 28);
            this.CMB_modes.Name = "CMB_modes";
            this.CMB_modes.Size = new System.Drawing.Size(225, 20);
            this.CMB_modes.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(225, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(187, 125);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 4;
            this.save_button.Text = "确定";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(282, 125);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            // 
            // ManyMachineSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 170);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CMB_modes);
            this.Controls.Add(this.mapPlan_label);
            this.Controls.Add(this.mainPlan_label);
            this.Name = "ManyMachineSet";
            this.Text = "多机设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainPlan_label;
        private System.Windows.Forms.Label mapPlan_label;
        public System.Windows.Forms.ComboBox CMB_modes;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button close_button;
    }
}