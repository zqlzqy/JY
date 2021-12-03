using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class LoiterView
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
            this.search_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.setup_button = new System.Windows.Forms.Button();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.loiter_radius_textBox = new System.Windows.Forms.TextBox();
            this.op_lng_textBox = new System.Windows.Forms.TextBox();
            this.op_lat_textBox = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.loiter_dir_textBox = new System.Windows.Forms.TextBox();
            this.loiter_radius_h_textBox = new System.Windows.Forms.TextBox();
            this.op_lng_h_textBox = new System.Windows.Forms.TextBox();
            this.op_lat_h_textBox = new System.Windows.Forms.TextBox();
            this.loiter_dir_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(565, 436);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "盘旋参数";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(646, 436);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 10;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(6, 18);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(84, 13);
            this.label91.TabIndex = 0;
            this.label91.Text = "盘旋半径";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 57);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(84, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "原点坐标经度";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "原点坐标纬度";
            // 
            // loiter_radius_textBox
            // 
            this.loiter_radius_textBox.Location = new System.Drawing.Point(208, 15);
            this.loiter_radius_textBox.Name = "loiter_radius_textBox";
            this.loiter_radius_textBox.Size = new System.Drawing.Size(90, 21);
            this.loiter_radius_textBox.TabIndex = 8;
            this.loiter_radius_textBox.Text = "0";
            // 
            // op_lng_textBox
            // 
            this.op_lng_textBox.Location = new System.Drawing.Point(208, 49);
            this.op_lng_textBox.Name = "op_lng_textBox";
            this.op_lng_textBox.Size = new System.Drawing.Size(90, 21);
            this.op_lng_textBox.TabIndex = 9;
            this.op_lng_textBox.Text = "0";
            // 
            // op_lat_textBox
            // 
            this.op_lat_textBox.Location = new System.Drawing.Point(208, 88);
            this.op_lat_textBox.Name = "op_lat_textBox";
            this.op_lat_textBox.Size = new System.Drawing.Size(90, 21);
            this.op_lat_textBox.TabIndex = 10;
            this.op_lat_textBox.Text = "0";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.loiter_dir_textBox);
            this.groupBox25.Controls.Add(this.loiter_radius_h_textBox);
            this.groupBox25.Controls.Add(this.op_lng_h_textBox);
            this.groupBox25.Controls.Add(this.op_lat_h_textBox);
            this.groupBox25.Controls.Add(this.loiter_dir_comboBox);
            this.groupBox25.Controls.Add(this.label2);
            this.groupBox25.Controls.Add(this.op_lat_textBox);
            this.groupBox25.Controls.Add(this.op_lng_textBox);
            this.groupBox25.Controls.Add(this.loiter_radius_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(87, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(304, 187);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "盘旋";
            // 
            // loiter_dir_textBox
            // 
            this.loiter_dir_textBox.Enabled = false;
            this.loiter_dir_textBox.Location = new System.Drawing.Point(112, 125);
            this.loiter_dir_textBox.Name = "loiter_dir_textBox";
            this.loiter_dir_textBox.Size = new System.Drawing.Size(90, 21);
            this.loiter_dir_textBox.TabIndex = 16;
            // 
            // loiter_radius_h_textBox
            // 
            this.loiter_radius_h_textBox.Enabled = false;
            this.loiter_radius_h_textBox.Location = new System.Drawing.Point(112, 15);
            this.loiter_radius_h_textBox.Name = "loiter_radius_h_textBox";
            this.loiter_radius_h_textBox.Size = new System.Drawing.Size(90, 21);
            this.loiter_radius_h_textBox.TabIndex = 15;
            // 
            // op_lng_h_textBox
            // 
            this.op_lng_h_textBox.Enabled = false;
            this.op_lng_h_textBox.Location = new System.Drawing.Point(112, 49);
            this.op_lng_h_textBox.Name = "op_lng_h_textBox";
            this.op_lng_h_textBox.Size = new System.Drawing.Size(90, 21);
            this.op_lng_h_textBox.TabIndex = 14;
            // 
            // op_lat_h_textBox
            // 
            this.op_lat_h_textBox.Enabled = false;
            this.op_lat_h_textBox.Location = new System.Drawing.Point(112, 88);
            this.op_lat_h_textBox.Name = "op_lat_h_textBox";
            this.op_lat_h_textBox.Size = new System.Drawing.Size(90, 21);
            this.op_lat_h_textBox.TabIndex = 13;
            // 
            // loiter_dir_comboBox
            // 
            this.loiter_dir_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loiter_dir_comboBox.FormattingEnabled = true;
            this.loiter_dir_comboBox.Location = new System.Drawing.Point(208, 125);
            this.loiter_dir_comboBox.Name = "loiter_dir_comboBox";
            this.loiter_dir_comboBox.Size = new System.Drawing.Size(90, 20);
            this.loiter_dir_comboBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "盘旋方向";
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(87, 436);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 11;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button1_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(168, 436);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 12;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Import);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.search_button);
            this.Name = "LoiterView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.LoiterView_Load);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox loiter_radius_textBox;
        private System.Windows.Forms.TextBox op_lng_textBox;
        private System.Windows.Forms.TextBox op_lat_textBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox loiter_dir_comboBox;
        private System.Windows.Forms.TextBox loiter_radius_h_textBox;
        private System.Windows.Forms.TextBox op_lng_h_textBox;
        private System.Windows.Forms.TextBox op_lat_h_textBox;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.TextBox loiter_dir_textBox;
    }
}
