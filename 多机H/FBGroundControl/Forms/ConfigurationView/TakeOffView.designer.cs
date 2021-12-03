using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class TakeOffView
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
            this.label88 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.takeoff_offset_textBox = new System.Windows.Forms.TextBox();
            this.lift_pull_textBox = new System.Windows.Forms.TextBox();
            this.pull_time_textBox = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.takeoff_type_textBox = new System.Windows.Forms.TextBox();
            this.takeoff_offset_t_textBox = new System.Windows.Forms.TextBox();
            this.lift_pull_t_textBox = new System.Windows.Forms.TextBox();
            this.vspeed_t_textBox = new System.Windows.Forms.TextBox();
            this.pull_alt_t_textBox = new System.Windows.Forms.TextBox();
            this.pull_time_t_textBox = new System.Windows.Forms.TextBox();
            this.takeoff_type_comboBox = new System.Windows.Forms.ComboBox();
            this.vspeed_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pull_alt_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(661, 427);
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
            this.label1.Text = "起飞参数";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(742, 427);
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
            this.label91.Text = "起飞类型";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 57);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(84, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "起飞偏转量";
            // 
            // label88
            // 
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(6, 133);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(84, 13);
            this.label88.TabIndex = 6;
            this.label88.Text = "拉杆过渡时间";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "离地拉杆";
            // 
            // takeoff_offset_textBox
            // 
            this.takeoff_offset_textBox.Location = new System.Drawing.Point(203, 49);
            this.takeoff_offset_textBox.Name = "takeoff_offset_textBox";
            this.takeoff_offset_textBox.Size = new System.Drawing.Size(95, 21);
            this.takeoff_offset_textBox.TabIndex = 9;
            this.takeoff_offset_textBox.Text = "0";
            // 
            // lift_pull_textBox
            // 
            this.lift_pull_textBox.Location = new System.Drawing.Point(203, 88);
            this.lift_pull_textBox.Name = "lift_pull_textBox";
            this.lift_pull_textBox.Size = new System.Drawing.Size(95, 21);
            this.lift_pull_textBox.TabIndex = 10;
            this.lift_pull_textBox.Text = "0";
            // 
            // pull_time_textBox
            // 
            this.pull_time_textBox.Location = new System.Drawing.Point(203, 130);
            this.pull_time_textBox.Name = "pull_time_textBox";
            this.pull_time_textBox.Size = new System.Drawing.Size(95, 21);
            this.pull_time_textBox.TabIndex = 11;
            this.pull_time_textBox.Text = "0";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.takeoff_type_textBox);
            this.groupBox25.Controls.Add(this.takeoff_offset_t_textBox);
            this.groupBox25.Controls.Add(this.lift_pull_t_textBox);
            this.groupBox25.Controls.Add(this.vspeed_t_textBox);
            this.groupBox25.Controls.Add(this.pull_alt_t_textBox);
            this.groupBox25.Controls.Add(this.pull_time_t_textBox);
            this.groupBox25.Controls.Add(this.takeoff_type_comboBox);
            this.groupBox25.Controls.Add(this.vspeed_textBox);
            this.groupBox25.Controls.Add(this.label3);
            this.groupBox25.Controls.Add(this.pull_alt_textBox);
            this.groupBox25.Controls.Add(this.label2);
            this.groupBox25.Controls.Add(this.pull_time_textBox);
            this.groupBox25.Controls.Add(this.lift_pull_textBox);
            this.groupBox25.Controls.Add(this.takeoff_offset_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label88);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(87, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(304, 288);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "起飞";
            // 
            // takeoff_type_textBox
            // 
            this.takeoff_type_textBox.Enabled = false;
            this.takeoff_type_textBox.Location = new System.Drawing.Point(102, 11);
            this.takeoff_type_textBox.Name = "takeoff_type_textBox";
            this.takeoff_type_textBox.Size = new System.Drawing.Size(95, 21);
            this.takeoff_type_textBox.TabIndex = 22;
            // 
            // takeoff_offset_t_textBox
            // 
            this.takeoff_offset_t_textBox.Enabled = false;
            this.takeoff_offset_t_textBox.Location = new System.Drawing.Point(102, 49);
            this.takeoff_offset_t_textBox.Name = "takeoff_offset_t_textBox";
            this.takeoff_offset_t_textBox.Size = new System.Drawing.Size(95, 21);
            this.takeoff_offset_t_textBox.TabIndex = 21;
            // 
            // lift_pull_t_textBox
            // 
            this.lift_pull_t_textBox.Enabled = false;
            this.lift_pull_t_textBox.Location = new System.Drawing.Point(102, 88);
            this.lift_pull_t_textBox.Name = "lift_pull_t_textBox";
            this.lift_pull_t_textBox.Size = new System.Drawing.Size(95, 21);
            this.lift_pull_t_textBox.TabIndex = 20;
            // 
            // vspeed_t_textBox
            // 
            this.vspeed_t_textBox.Enabled = false;
            this.vspeed_t_textBox.Location = new System.Drawing.Point(102, 212);
            this.vspeed_t_textBox.Name = "vspeed_t_textBox";
            this.vspeed_t_textBox.Size = new System.Drawing.Size(95, 21);
            this.vspeed_t_textBox.TabIndex = 19;
            // 
            // pull_alt_t_textBox
            // 
            this.pull_alt_t_textBox.Enabled = false;
            this.pull_alt_t_textBox.Location = new System.Drawing.Point(102, 173);
            this.pull_alt_t_textBox.Name = "pull_alt_t_textBox";
            this.pull_alt_t_textBox.Size = new System.Drawing.Size(95, 21);
            this.pull_alt_t_textBox.TabIndex = 18;
            // 
            // pull_time_t_textBox
            // 
            this.pull_time_t_textBox.Enabled = false;
            this.pull_time_t_textBox.Location = new System.Drawing.Point(102, 130);
            this.pull_time_t_textBox.Name = "pull_time_t_textBox";
            this.pull_time_t_textBox.Size = new System.Drawing.Size(95, 21);
            this.pull_time_t_textBox.TabIndex = 17;
            // 
            // takeoff_type_comboBox
            // 
            this.takeoff_type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.takeoff_type_comboBox.FormattingEnabled = true;
            this.takeoff_type_comboBox.Location = new System.Drawing.Point(203, 11);
            this.takeoff_type_comboBox.Name = "takeoff_type_comboBox";
            this.takeoff_type_comboBox.Size = new System.Drawing.Size(95, 20);
            this.takeoff_type_comboBox.TabIndex = 16;
            // 
            // vspeed_textBox
            // 
            this.vspeed_textBox.Location = new System.Drawing.Point(203, 212);
            this.vspeed_textBox.Name = "vspeed_textBox";
            this.vspeed_textBox.Size = new System.Drawing.Size(95, 21);
            this.vspeed_textBox.TabIndex = 15;
            this.vspeed_textBox.Text = "0";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "垂向速度";
            // 
            // pull_alt_textBox
            // 
            this.pull_alt_textBox.Location = new System.Drawing.Point(203, 173);
            this.pull_alt_textBox.Name = "pull_alt_textBox";
            this.pull_alt_textBox.Size = new System.Drawing.Size(95, 21);
            this.pull_alt_textBox.TabIndex = 13;
            this.pull_alt_textBox.Text = "0";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "拉起高度";
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(87, 427);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 11;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button1_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(168, 427);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 12;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.button2_Click);
            // 
            // TakeOffView
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
            this.Name = "TakeOffView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.TakeOffView_Load);
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
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox takeoff_offset_textBox;
        private System.Windows.Forms.TextBox lift_pull_textBox;
        private System.Windows.Forms.TextBox pull_time_textBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox vspeed_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pull_alt_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox takeoff_type_comboBox;
        private System.Windows.Forms.TextBox takeoff_offset_t_textBox;
        private System.Windows.Forms.TextBox lift_pull_t_textBox;
        private System.Windows.Forms.TextBox vspeed_t_textBox;
        private System.Windows.Forms.TextBox pull_alt_t_textBox;
        private System.Windows.Forms.TextBox pull_time_t_textBox;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.TextBox takeoff_type_textBox;
    }
}
