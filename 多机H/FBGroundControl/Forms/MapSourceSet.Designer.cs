using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class MapSourceSet
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
            this.mapSource_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveMap_textBox = new System.Windows.Forms.TextBox();
            this.close_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mapSource_comboBox
            // 
            this.mapSource_comboBox.FormattingEnabled = true;
            this.mapSource_comboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "921600",
            "1500000"});
            this.mapSource_comboBox.Location = new System.Drawing.Point(82, 31);
            this.mapSource_comboBox.Name = "mapSource_comboBox";
            this.mapSource_comboBox.Size = new System.Drawing.Size(329, 20);
            this.mapSource_comboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "地图源：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "保存路径：";
            // 
            // saveMap_textBox
            // 
            this.saveMap_textBox.Location = new System.Drawing.Point(83, 78);
            this.saveMap_textBox.Name = "saveMap_textBox";
            this.saveMap_textBox.Size = new System.Drawing.Size(328, 21);
            this.saveMap_textBox.TabIndex = 12;
            this.saveMap_textBox.Click += new System.EventHandler(this.saveMap_textBox_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(323, 136);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(88, 23);
            this.close_button.TabIndex = 14;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(213, 136);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 23);
            this.save_button.TabIndex = 13;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(81, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "下载离线地图保存路径";
            // 
            // MapSourceSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 174);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.saveMap_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapSource_comboBox);
            this.Name = "MapSourceSet";
            this.Text = "地图设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mapSource_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox saveMap_textBox;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label3;
        //public  myGMAP MainMap;
    }
}