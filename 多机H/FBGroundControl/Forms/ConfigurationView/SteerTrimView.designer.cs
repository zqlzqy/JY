using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class SteerTrimView
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
            this.LeftAileron_textBox = new System.Windows.Forms.TextBox();
            this.LeftTail_textBox = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.RightTailRatio_textBox = new System.Windows.Forms.TextBox();
            this.RightAileronRatio_textBox = new System.Windows.Forms.TextBox();
            this.RightAileronRatio_trim_textBox = new System.Windows.Forms.TextBox();
            this.RightTailRatio_trim_textBox = new System.Windows.Forms.TextBox();
            this.LeftTailRatio_textBox = new System.Windows.Forms.TextBox();
            this.LeftAileronRatio_textBox = new System.Windows.Forms.TextBox();
            this.LeftAileronRatio_trim_textBox = new System.Windows.Forms.TextBox();
            this.LeftTailRatio_trim_textBox = new System.Windows.Forms.TextBox();
            this.LeftAileron_trim_textBox = new System.Windows.Forms.TextBox();
            this.LeftTail_trim_textBox = new System.Windows.Forms.TextBox();
            this.RightAileron_trim_textBox = new System.Windows.Forms.TextBox();
            this.RightTail_trim_textBox = new System.Windows.Forms.TextBox();
            this.RightTail_textBox = new System.Windows.Forms.TextBox();
            this.RightAileron_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(711, 427);
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
            this.label1.Text = "舵面参数";
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(792, 427);
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
            this.label91.Location = new System.Drawing.Point(6, 46);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(84, 13);
            this.label91.TabIndex = 0;
            this.label91.Text = "左副翼";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(6, 123);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(84, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "左尾翼";
            // 
            // LeftAileron_textBox
            // 
            this.LeftAileron_textBox.Location = new System.Drawing.Point(284, 43);
            this.LeftAileron_textBox.Name = "LeftAileron_textBox";
            this.LeftAileron_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftAileron_textBox.TabIndex = 8;
            // 
            // LeftTail_textBox
            // 
            this.LeftTail_textBox.Location = new System.Drawing.Point(284, 115);
            this.LeftTail_textBox.Name = "LeftTail_textBox";
            this.LeftTail_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftTail_textBox.TabIndex = 9;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.RightTailRatio_textBox);
            this.groupBox25.Controls.Add(this.RightAileronRatio_textBox);
            this.groupBox25.Controls.Add(this.RightAileronRatio_trim_textBox);
            this.groupBox25.Controls.Add(this.RightTailRatio_trim_textBox);
            this.groupBox25.Controls.Add(this.LeftTailRatio_textBox);
            this.groupBox25.Controls.Add(this.LeftAileronRatio_textBox);
            this.groupBox25.Controls.Add(this.LeftAileronRatio_trim_textBox);
            this.groupBox25.Controls.Add(this.LeftTailRatio_trim_textBox);
            this.groupBox25.Controls.Add(this.LeftAileron_trim_textBox);
            this.groupBox25.Controls.Add(this.LeftTail_trim_textBox);
            this.groupBox25.Controls.Add(this.RightAileron_trim_textBox);
            this.groupBox25.Controls.Add(this.RightTail_trim_textBox);
            this.groupBox25.Controls.Add(this.RightTail_textBox);
            this.groupBox25.Controls.Add(this.RightAileron_textBox);
            this.groupBox25.Controls.Add(this.label10);
            this.groupBox25.Controls.Add(this.label11);
            this.groupBox25.Controls.Add(this.LeftTail_textBox);
            this.groupBox25.Controls.Add(this.LeftAileron_textBox);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(111, 95);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(780, 227);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "舵面参数";
            // 
            // RightTailRatio_textBox
            // 
            this.RightTailRatio_textBox.Location = new System.Drawing.Point(386, 156);
            this.RightTailRatio_textBox.Name = "RightTailRatio_textBox";
            this.RightTailRatio_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightTailRatio_textBox.TabIndex = 56;
            this.RightTailRatio_textBox.Text = "0";
            // 
            // RightAileronRatio_textBox
            // 
            this.RightAileronRatio_textBox.Location = new System.Drawing.Point(386, 80);
            this.RightAileronRatio_textBox.Name = "RightAileronRatio_textBox";
            this.RightAileronRatio_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightAileronRatio_textBox.TabIndex = 55;
            this.RightAileronRatio_textBox.Text = "0";
            // 
            // RightAileronRatio_trim_textBox
            // 
            this.RightAileronRatio_trim_textBox.Enabled = false;
            this.RightAileronRatio_trim_textBox.Location = new System.Drawing.Point(183, 80);
            this.RightAileronRatio_trim_textBox.Name = "RightAileronRatio_trim_textBox";
            this.RightAileronRatio_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightAileronRatio_trim_textBox.TabIndex = 53;
            this.RightAileronRatio_trim_textBox.Text = "0";
            // 
            // RightTailRatio_trim_textBox
            // 
            this.RightTailRatio_trim_textBox.Enabled = false;
            this.RightTailRatio_trim_textBox.Location = new System.Drawing.Point(183, 156);
            this.RightTailRatio_trim_textBox.Name = "RightTailRatio_trim_textBox";
            this.RightTailRatio_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightTailRatio_trim_textBox.TabIndex = 52;
            this.RightTailRatio_trim_textBox.Text = "0";
            // 
            // LeftTailRatio_textBox
            // 
            this.LeftTailRatio_textBox.Location = new System.Drawing.Point(386, 115);
            this.LeftTailRatio_textBox.Name = "LeftTailRatio_textBox";
            this.LeftTailRatio_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftTailRatio_textBox.TabIndex = 46;
            this.LeftTailRatio_textBox.Text = "0";
            // 
            // LeftAileronRatio_textBox
            // 
            this.LeftAileronRatio_textBox.Location = new System.Drawing.Point(386, 43);
            this.LeftAileronRatio_textBox.Name = "LeftAileronRatio_textBox";
            this.LeftAileronRatio_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftAileronRatio_textBox.TabIndex = 45;
            this.LeftAileronRatio_textBox.Text = "0";
            // 
            // LeftAileronRatio_trim_textBox
            // 
            this.LeftAileronRatio_trim_textBox.Enabled = false;
            this.LeftAileronRatio_trim_textBox.Location = new System.Drawing.Point(183, 43);
            this.LeftAileronRatio_trim_textBox.Name = "LeftAileronRatio_trim_textBox";
            this.LeftAileronRatio_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftAileronRatio_trim_textBox.TabIndex = 44;
            this.LeftAileronRatio_trim_textBox.Text = "0";
            // 
            // LeftTailRatio_trim_textBox
            // 
            this.LeftTailRatio_trim_textBox.Enabled = false;
            this.LeftTailRatio_trim_textBox.Location = new System.Drawing.Point(183, 116);
            this.LeftTailRatio_trim_textBox.Name = "LeftTailRatio_trim_textBox";
            this.LeftTailRatio_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftTailRatio_trim_textBox.TabIndex = 43;
            this.LeftTailRatio_trim_textBox.Text = "0";
            // 
            // LeftAileron_trim_textBox
            // 
            this.LeftAileron_trim_textBox.Enabled = false;
            this.LeftAileron_trim_textBox.Location = new System.Drawing.Point(87, 43);
            this.LeftAileron_trim_textBox.Name = "LeftAileron_trim_textBox";
            this.LeftAileron_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftAileron_trim_textBox.TabIndex = 38;
            this.LeftAileron_trim_textBox.TextChanged += new System.EventHandler(this.steer1_trim_textBox_TextChanged);
            // 
            // LeftTail_trim_textBox
            // 
            this.LeftTail_trim_textBox.Enabled = false;
            this.LeftTail_trim_textBox.Location = new System.Drawing.Point(87, 116);
            this.LeftTail_trim_textBox.Name = "LeftTail_trim_textBox";
            this.LeftTail_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.LeftTail_trim_textBox.TabIndex = 37;
            // 
            // RightAileron_trim_textBox
            // 
            this.RightAileron_trim_textBox.Enabled = false;
            this.RightAileron_trim_textBox.Location = new System.Drawing.Point(87, 80);
            this.RightAileron_trim_textBox.Name = "RightAileron_trim_textBox";
            this.RightAileron_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightAileron_trim_textBox.TabIndex = 33;
            // 
            // RightTail_trim_textBox
            // 
            this.RightTail_trim_textBox.Enabled = false;
            this.RightTail_trim_textBox.Location = new System.Drawing.Point(87, 157);
            this.RightTail_trim_textBox.Name = "RightTail_trim_textBox";
            this.RightTail_trim_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightTail_trim_textBox.TabIndex = 32;
            // 
            // RightTail_textBox
            // 
            this.RightTail_textBox.Location = new System.Drawing.Point(284, 157);
            this.RightTail_textBox.Name = "RightTail_textBox";
            this.RightTail_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightTail_textBox.TabIndex = 23;
            // 
            // RightAileron_textBox
            // 
            this.RightAileron_textBox.Location = new System.Drawing.Point(284, 80);
            this.RightAileron_textBox.Name = "RightAileron_textBox";
            this.RightAileron_textBox.Size = new System.Drawing.Size(50, 21);
            this.RightAileron_textBox.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(6, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "右尾翼";
            // 
            // label11
            // 
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(6, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "右副翼";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(394, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "舵面配平";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(494, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "传递系数";
            // 
            // SteerTrimView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.search_button);
            this.Name = "SteerTrimView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.SteerTrimView_Load);
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
        private System.Windows.Forms.TextBox LeftAileron_textBox;
        private System.Windows.Forms.TextBox LeftTail_textBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox RightTail_textBox;
        private System.Windows.Forms.TextBox RightAileron_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LeftAileron_trim_textBox;
        private System.Windows.Forms.TextBox LeftTail_trim_textBox;
        private System.Windows.Forms.TextBox RightAileron_trim_textBox;
        private System.Windows.Forms.TextBox RightTail_trim_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.TextBox RightTailRatio_textBox;
        private System.Windows.Forms.TextBox RightAileronRatio_textBox;
        private System.Windows.Forms.TextBox RightAileronRatio_trim_textBox;
        private System.Windows.Forms.TextBox RightTailRatio_trim_textBox;
        private System.Windows.Forms.TextBox LeftTailRatio_textBox;
        private System.Windows.Forms.TextBox LeftAileronRatio_textBox;
        private System.Windows.Forms.TextBox LeftAileronRatio_trim_textBox;
        private System.Windows.Forms.TextBox LeftTailRatio_trim_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
