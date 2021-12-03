using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class AirSpeedBAltView
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
            this.components = new System.ComponentModel.Container();
            this.cal_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.VX = new System.Windows.Forms.TextBox();
            this.TX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VY = new System.Windows.Forms.TextBox();
            this.VZ = new System.Windows.Forms.TextBox();
            this.TZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VA = new System.Windows.Forms.TextBox();
            this.TA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cal_button
            // 
            this.cal_button.Location = new System.Drawing.Point(33, 29);
            this.cal_button.Name = "cal_button";
            this.cal_button.Size = new System.Drawing.Size(135, 23);
            this.cal_button.TabIndex = 1;
            this.cal_button.Text = "空速和气压高度校准";
            this.cal_button.UseVisualStyleBackColor = true;
            this.cal_button.Click += new System.EventHandler(this.cal_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "陀螺加速计校准";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VX
            // 
            this.VX.BackColor = System.Drawing.Color.White;
            this.VX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VX.Enabled = false;
            this.VX.Font = new System.Drawing.Font("宋体", 13F);
            this.VX.Location = new System.Drawing.Point(210, 169);
            this.VX.Name = "VX";
            this.VX.ReadOnly = true;
            this.VX.Size = new System.Drawing.Size(80, 20);
            this.VX.TabIndex = 22;
            this.VX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TX
            // 
            this.TX.BackColor = System.Drawing.Color.Red;
            this.TX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TX.Enabled = false;
            this.TX.Font = new System.Drawing.Font("宋体", 13F);
            this.TX.Location = new System.Drawing.Point(127, 169);
            this.TX.Name = "TX";
            this.TX.ReadOnly = true;
            this.TX.Size = new System.Drawing.Size(51, 20);
            this.TX.TabIndex = 23;
            this.TX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "校准后值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "陀螺X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "陀螺Y";
            // 
            // TY
            // 
            this.TY.BackColor = System.Drawing.Color.Red;
            this.TY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TY.Enabled = false;
            this.TY.Font = new System.Drawing.Font("宋体", 13F);
            this.TY.Location = new System.Drawing.Point(127, 213);
            this.TY.Name = "TY";
            this.TY.ReadOnly = true;
            this.TY.Size = new System.Drawing.Size(51, 20);
            this.TY.TabIndex = 25;
            this.TY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "陀螺Z";
            // 
            // VY
            // 
            this.VY.BackColor = System.Drawing.Color.White;
            this.VY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VY.Enabled = false;
            this.VY.Font = new System.Drawing.Font("宋体", 13F);
            this.VY.Location = new System.Drawing.Point(210, 213);
            this.VY.Name = "VY";
            this.VY.ReadOnly = true;
            this.VY.Size = new System.Drawing.Size(80, 20);
            this.VY.TabIndex = 27;
            this.VY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VZ
            // 
            this.VZ.BackColor = System.Drawing.Color.White;
            this.VZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VZ.Enabled = false;
            this.VZ.Font = new System.Drawing.Font("宋体", 13F);
            this.VZ.Location = new System.Drawing.Point(210, 253);
            this.VZ.Name = "VZ";
            this.VZ.ReadOnly = true;
            this.VZ.Size = new System.Drawing.Size(80, 20);
            this.VZ.TabIndex = 30;
            this.VZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TZ
            // 
            this.TZ.BackColor = System.Drawing.Color.Red;
            this.TZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TZ.Enabled = false;
            this.TZ.Font = new System.Drawing.Font("宋体", 13F);
            this.TZ.Location = new System.Drawing.Point(127, 253);
            this.TZ.Name = "TZ";
            this.TZ.ReadOnly = true;
            this.TZ.Size = new System.Drawing.Size(51, 20);
            this.TZ.TabIndex = 29;
            this.TZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "校准状态";
            // 
            // VA
            // 
            this.VA.BackColor = System.Drawing.Color.White;
            this.VA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VA.Enabled = false;
            this.VA.Font = new System.Drawing.Font("宋体", 13F);
            this.VA.Location = new System.Drawing.Point(210, 296);
            this.VA.Name = "VA";
            this.VA.ReadOnly = true;
            this.VA.Size = new System.Drawing.Size(80, 20);
            this.VA.TabIndex = 33;
            this.VA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TA
            // 
            this.TA.BackColor = System.Drawing.Color.Red;
            this.TA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TA.Enabled = false;
            this.TA.Font = new System.Drawing.Font("宋体", 13F);
            this.TA.Location = new System.Drawing.Point(127, 296);
            this.TA.Name = "TA";
            this.TA.ReadOnly = true;
            this.TA.Size = new System.Drawing.Size(51, 20);
            this.TA.TabIndex = 32;
            this.TA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "加速度";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AirSpeedBAltView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.VA);
            this.Controls.Add(this.TA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VZ);
            this.Controls.Add(this.TZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TX);
            this.Controls.Add(this.VX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cal_button);
            this.Name = "AirSpeedBAltView";
            this.Size = new System.Drawing.Size(650, 382);
            this.Load += new System.EventHandler(this.AirSpeedBAltView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cal_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox VX;
        private System.Windows.Forms.TextBox TX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VY;
        private System.Windows.Forms.TextBox VZ;
        private System.Windows.Forms.TextBox TZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox VA;
        private System.Windows.Forms.TextBox TA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
    }
}
