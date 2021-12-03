using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class GuideView
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
            this.alt_textBox = new System.Windows.Forms.TextBox();
            this.speed_textBox = new System.Windows.Forms.TextBox();
            this.heading_textBox = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.speed_g_textBox = new System.Windows.Forms.TextBox();
            this.heading_g_textBox = new System.Windows.Forms.TextBox();
            this.alt_g_textBox = new System.Windows.Forms.TextBox();
            this.Import = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(676, 427);
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
            this.label1.Text = "引导参数";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(757, 427);
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
            this.label91.Text = "飞行高度";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 57);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(84, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "飞行速度";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "飞行航向";
            // 
            // alt_textBox
            // 
            this.alt_textBox.Location = new System.Drawing.Point(191, 15);
            this.alt_textBox.Name = "alt_textBox";
            this.alt_textBox.Size = new System.Drawing.Size(78, 21);
            this.alt_textBox.TabIndex = 8;
            this.alt_textBox.Text = "0";
            // 
            // speed_textBox
            // 
            this.speed_textBox.Location = new System.Drawing.Point(191, 49);
            this.speed_textBox.Name = "speed_textBox";
            this.speed_textBox.Size = new System.Drawing.Size(78, 21);
            this.speed_textBox.TabIndex = 9;
            this.speed_textBox.Text = "0";
            // 
            // heading_textBox
            // 
            this.heading_textBox.Location = new System.Drawing.Point(191, 88);
            this.heading_textBox.Name = "heading_textBox";
            this.heading_textBox.Size = new System.Drawing.Size(78, 21);
            this.heading_textBox.TabIndex = 10;
            this.heading_textBox.Text = "0";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.speed_g_textBox);
            this.groupBox25.Controls.Add(this.heading_g_textBox);
            this.groupBox25.Controls.Add(this.alt_g_textBox);
            this.groupBox25.Controls.Add(this.heading_textBox);
            this.groupBox25.Controls.Add(this.speed_textBox);
            this.groupBox25.Controls.Add(this.alt_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(87, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(304, 143);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "引导";
            // 
            // speed_g_textBox
            // 
            this.speed_g_textBox.Enabled = false;
            this.speed_g_textBox.Location = new System.Drawing.Point(88, 49);
            this.speed_g_textBox.Name = "speed_g_textBox";
            this.speed_g_textBox.Size = new System.Drawing.Size(78, 21);
            this.speed_g_textBox.TabIndex = 13;
            // 
            // heading_g_textBox
            // 
            this.heading_g_textBox.Enabled = false;
            this.heading_g_textBox.Location = new System.Drawing.Point(88, 88);
            this.heading_g_textBox.Name = "heading_g_textBox";
            this.heading_g_textBox.Size = new System.Drawing.Size(78, 21);
            this.heading_g_textBox.TabIndex = 12;
            // 
            // alt_g_textBox
            // 
            this.alt_g_textBox.Enabled = false;
            this.alt_g_textBox.Location = new System.Drawing.Point(88, 15);
            this.alt_g_textBox.Name = "alt_g_textBox";
            this.alt_g_textBox.Size = new System.Drawing.Size(78, 21);
            this.alt_g_textBox.TabIndex = 11;
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(168, 427);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 11;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.button1_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(87, 427);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 12;
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button2_Click);
            // 
            // GuideView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.search_button);
            this.Name = "GuideView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.GuideView_Load);
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
        private System.Windows.Forms.TextBox alt_textBox;
        private System.Windows.Forms.TextBox speed_textBox;
        private System.Windows.Forms.TextBox heading_textBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox speed_g_textBox;
        private System.Windows.Forms.TextBox heading_g_textBox;
        private System.Windows.Forms.TextBox alt_g_textBox;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button Export;
    }
}
