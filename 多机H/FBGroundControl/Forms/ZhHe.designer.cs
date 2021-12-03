namespace FBGroundControl.Forms
{
    partial class ZhHe
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hight_y_textBox = new System.Windows.Forms.TextBox();
            this.guozai_y_textBox = new System.Windows.Forms.TextBox();
            this.time_y_textBox = new System.Windows.Forms.TextBox();
            this.time_textBox = new System.Windows.Forms.TextBox();
            this.guozai_textBox = new System.Windows.Forms.TextBox();
            this.hight_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Import = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.setup_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hight_y_textBox);
            this.groupBox2.Controls.Add(this.guozai_y_textBox);
            this.groupBox2.Controls.Add(this.time_y_textBox);
            this.groupBox2.Controls.Add(this.time_textBox);
            this.groupBox2.Controls.Add(this.guozai_textBox);
            this.groupBox2.Controls.Add(this.hight_textBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(23, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 192);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数";
            // 
            // hight_y_textBox
            // 
            this.hight_y_textBox.Enabled = false;
            this.hight_y_textBox.Location = new System.Drawing.Point(137, 15);
            this.hight_y_textBox.Name = "hight_y_textBox";
            this.hight_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.hight_y_textBox.TabIndex = 15;
            // 
            // guozai_y_textBox
            // 
            this.guozai_y_textBox.Enabled = false;
            this.guozai_y_textBox.Location = new System.Drawing.Point(137, 70);
            this.guozai_y_textBox.Name = "guozai_y_textBox";
            this.guozai_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.guozai_y_textBox.TabIndex = 14;
            // 
            // time_y_textBox
            // 
            this.time_y_textBox.Enabled = false;
            this.time_y_textBox.Location = new System.Drawing.Point(137, 129);
            this.time_y_textBox.Name = "time_y_textBox";
            this.time_y_textBox.Size = new System.Drawing.Size(84, 21);
            this.time_y_textBox.TabIndex = 13;
            this.time_y_textBox.Visible = false;
            // 
            // time_textBox
            // 
            this.time_textBox.Location = new System.Drawing.Point(236, 129);
            this.time_textBox.Name = "time_textBox";
            this.time_textBox.Size = new System.Drawing.Size(84, 21);
            this.time_textBox.TabIndex = 10;
            this.time_textBox.Text = "0";
            this.time_textBox.Visible = false;
            // 
            // guozai_textBox
            // 
            this.guozai_textBox.Location = new System.Drawing.Point(236, 70);
            this.guozai_textBox.Name = "guozai_textBox";
            this.guozai_textBox.Size = new System.Drawing.Size(84, 21);
            this.guozai_textBox.TabIndex = 9;
            this.guozai_textBox.Text = "0";
            // 
            // hight_textBox
            // 
            this.hight_textBox.Location = new System.Drawing.Point(236, 15);
            this.hight_textBox.Name = "hight_textBox";
            this.hight_textBox.Size = new System.Drawing.Size(84, 21);
            this.hight_textBox.TabIndex = 8;
            this.hight_textBox.Text = "0";
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "机动桶滚时间";
            this.label6.Visible = false;
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "机动过载";
            // 
            // label9
            // 
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "拉起高度";
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(98, 257);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 14;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(17, 257);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 13;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(332, 257);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 16;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(251, 257);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 15;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // ZhHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 309);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.groupBox2);
            this.Name = "ZhHe";
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.ZhHe_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox hight_y_textBox;
        private System.Windows.Forms.TextBox guozai_y_textBox;
        private System.Windows.Forms.TextBox time_y_textBox;
        private System.Windows.Forms.TextBox time_textBox;
        private System.Windows.Forms.TextBox guozai_textBox;
        private System.Windows.Forms.TextBox hight_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Button search_button;
    }
}