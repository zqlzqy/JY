using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class SteeringCalibrationView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox1 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox1 = new System.Windows.Forms.ComboBox();
            this.add_button = new System.Windows.Forms.Button();
            this.set_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox2 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox4 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox3 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox8 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox8 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox7 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox7 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox6 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox6 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.steer_addr_comboBox5 = new System.Windows.Forms.ComboBox();
            this.steer_comboBox5 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.query_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.steer_addr_comboBox1);
            this.groupBox1.Controls.Add(this.steer_comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(196, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 51);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "舵机1";
            // 
            // steer_addr_comboBox1
            // 
            this.steer_addr_comboBox1.FormattingEnabled = true;
            this.steer_addr_comboBox1.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox1.Name = "steer_addr_comboBox1";
            this.steer_addr_comboBox1.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox1.TabIndex = 3;
            this.steer_addr_comboBox1.DataSource = getPwmList();
            this.steer_addr_comboBox1.ValueMember = "Key";
            this.steer_addr_comboBox1.DisplayMember = "Value";
            // 
            // steer_comboBox1
            // 
            this.steer_comboBox1.FormattingEnabled = true;
            this.steer_comboBox1.Location = new System.Drawing.Point(102, 22);
            this.steer_comboBox1.Name = "steer_comboBox1";
            this.steer_comboBox1.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox1.TabIndex = 2;
            this.steer_comboBox1.DataSource = getSteerList();
            this.steer_comboBox1.ValueMember = "Key";
            this.steer_comboBox1.DisplayMember = "Value";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(135, 643);
            this.add_button.Margin = new System.Windows.Forms.Padding(4);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(100, 29);
            this.add_button.TabIndex = 1;
            this.add_button.Text = "添加舵面";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // set_button
            // 
            this.set_button.Location = new System.Drawing.Point(664, 643);
            this.set_button.Margin = new System.Windows.Forms.Padding(4);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(100, 29);
            this.set_button.TabIndex = 1;
            this.set_button.Text = "设置";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.cal_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.steer_addr_comboBox2);
            this.groupBox2.Controls.Add(this.steer_comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(196, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 51);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "舵机2";
            this.groupBox2.Visible = false;
            // 
            // steer_addr_comboBox2
            // 
            this.steer_addr_comboBox2.FormattingEnabled = true;
            this.steer_addr_comboBox2.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox2.Name = "steer_addr_comboBox2";
            this.steer_addr_comboBox2.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox2.TabIndex = 3;
            this.steer_addr_comboBox2.DataSource = getPwmList();
            this.steer_addr_comboBox2.ValueMember = "Key";
            this.steer_addr_comboBox2.DisplayMember = "Value";
            // 
            // steer_comboBox2
            // 
            this.steer_comboBox2.FormattingEnabled = true;
            this.steer_comboBox2.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox2.Name = "steer_comboBox2";
            this.steer_comboBox2.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox2.TabIndex = 2;
            this.steer_comboBox2.DataSource = getSteerList();
            this.steer_comboBox2.ValueMember = "Key";
            this.steer_comboBox2.DisplayMember = "Value";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.steer_addr_comboBox4);
            this.groupBox4.Controls.Add(this.steer_comboBox4);
            this.groupBox4.Location = new System.Drawing.Point(196, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(529, 51);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "舵机4";
            this.groupBox4.Visible = false;
            // 
            // steer_addr_comboBox4
            // 
            this.steer_addr_comboBox4.FormattingEnabled = true;
            this.steer_addr_comboBox4.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox4.Name = "steer_addr_comboBox4";
            this.steer_addr_comboBox4.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox4.TabIndex = 3;
            this.steer_addr_comboBox4.DataSource = getPwmList();
            this.steer_addr_comboBox4.ValueMember = "Key";
            this.steer_addr_comboBox4.DisplayMember = "Value";
            // 
            // steer_comboBox4
            // 
            this.steer_comboBox4.FormattingEnabled = true;
            this.steer_comboBox4.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox4.Name = "steer_comboBox4";
            this.steer_comboBox4.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox4.TabIndex = 2;
            this.steer_comboBox4.DataSource = getSteerList();
            this.steer_comboBox4.ValueMember = "Key";
            this.steer_comboBox4.DisplayMember = "Value";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.steer_addr_comboBox3);
            this.groupBox3.Controls.Add(this.steer_comboBox3);
            this.groupBox3.Location = new System.Drawing.Point(196, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 51);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "舵机3";
            this.groupBox3.Visible = false;
            // 
            // steer_addr_comboBox3
            // 
            this.steer_addr_comboBox3.FormattingEnabled = true;
            this.steer_addr_comboBox3.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox3.Name = "steer_addr_comboBox3";
            this.steer_addr_comboBox3.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox3.TabIndex = 3;
            this.steer_addr_comboBox3.DataSource = getPwmList();
            this.steer_addr_comboBox3.ValueMember = "Key";
            this.steer_addr_comboBox3.DisplayMember = "Value";
            // 
            // steer_comboBox3
            // 
            this.steer_comboBox3.FormattingEnabled = true;
            this.steer_comboBox3.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox3.Name = "steer_comboBox3";
            this.steer_comboBox3.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox3.TabIndex = 2;
            this.steer_comboBox3.DataSource = getSteerList();
            this.steer_comboBox3.ValueMember = "Key";
            this.steer_comboBox3.DisplayMember = "Value";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.steer_addr_comboBox8);
            this.groupBox8.Controls.Add(this.steer_comboBox8);
            this.groupBox8.Location = new System.Drawing.Point(196, 560);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(529, 51);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "舵机8";
            this.groupBox8.Visible = false;
            // 
            // steer_addr_comboBox8
            // 
            this.steer_addr_comboBox8.FormattingEnabled = true;
            this.steer_addr_comboBox8.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox8.Name = "steer_addr_comboBox8";
            this.steer_addr_comboBox8.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox8.TabIndex = 3;
            this.steer_addr_comboBox8.DataSource = getPwmList();
            this.steer_addr_comboBox8.ValueMember = "Key";
            this.steer_addr_comboBox8.DisplayMember = "Value";
            // 
            // steer_comboBox8
            // 
            this.steer_comboBox8.FormattingEnabled = true;
            this.steer_comboBox8.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox8.Name = "steer_comboBox8";
            this.steer_comboBox8.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox8.TabIndex = 2;
            this.steer_comboBox8.DataSource = getSteerList();
            this.steer_comboBox8.ValueMember = "Key";
            this.steer_comboBox8.DisplayMember = "Value";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.steer_addr_comboBox7);
            this.groupBox7.Controls.Add(this.steer_comboBox7);
            this.groupBox7.Location = new System.Drawing.Point(196, 490);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(529, 51);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "舵机7";
            this.groupBox7.Visible = false;
            // 
            // steer_addr_comboBox7
            // 
            this.steer_addr_comboBox7.FormattingEnabled = true;
            this.steer_addr_comboBox7.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox7.Name = "steer_addr_comboBox7";
            this.steer_addr_comboBox7.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox7.TabIndex = 3;
            this.steer_addr_comboBox7.DataSource = getPwmList();
            this.steer_addr_comboBox7.ValueMember = "Key";
            this.steer_addr_comboBox7.DisplayMember = "Value";
            // 
            // steer_comboBox7
            // 
            this.steer_comboBox7.FormattingEnabled = true;
            this.steer_comboBox7.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox7.Name = "steer_comboBox7";
            this.steer_comboBox7.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox7.TabIndex = 2;
            this.steer_comboBox7.DataSource = getSteerList();
            this.steer_comboBox7.ValueMember = "Key";
            this.steer_comboBox7.DisplayMember = "Value";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.steer_addr_comboBox6);
            this.groupBox6.Controls.Add(this.steer_comboBox6);
            this.groupBox6.Location = new System.Drawing.Point(196, 420);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(529, 51);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "舵机6";
            this.groupBox6.Visible = false;
            // 
            // steer_addr_comboBox6
            // 
            this.steer_addr_comboBox6.FormattingEnabled = true;
            this.steer_addr_comboBox6.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox6.Name = "steer_addr_comboBox6";
            this.steer_addr_comboBox6.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox6.TabIndex = 3;
            this.steer_addr_comboBox6.DataSource = getPwmList();
            this.steer_addr_comboBox6.ValueMember = "Key";
            this.steer_addr_comboBox6.DisplayMember = "Value";
            // 
            // steer_comboBox6
            // 
            this.steer_comboBox6.FormattingEnabled = true;
            this.steer_comboBox6.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox6.Name = "steer_comboBox6";
            this.steer_comboBox6.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox6.TabIndex = 2;
            this.steer_comboBox6.DataSource = getSteerList();
            this.steer_comboBox6.ValueMember = "Key";
            this.steer_comboBox6.DisplayMember = "Value";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.steer_addr_comboBox5);
            this.groupBox5.Controls.Add(this.steer_comboBox5);
            this.groupBox5.Location = new System.Drawing.Point(196, 350);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(529, 51);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "舵机5";
            this.groupBox5.Visible = false;
            // 
            // steer_addr_comboBox5
            // 
            this.steer_addr_comboBox5.FormattingEnabled = true;
            this.steer_addr_comboBox5.Location = new System.Drawing.Point(363, 18);
            this.steer_addr_comboBox5.Name = "steer_addr_comboBox5";
            this.steer_addr_comboBox5.Size = new System.Drawing.Size(121, 23);
            this.steer_addr_comboBox5.TabIndex = 3;
            this.steer_addr_comboBox5.DataSource = getPwmList();
            this.steer_addr_comboBox5.ValueMember = "Key";
            this.steer_addr_comboBox5.DisplayMember = "Value";
            // 
            // steer_comboBox5
            // 
            this.steer_comboBox5.FormattingEnabled = true;
            this.steer_comboBox5.Location = new System.Drawing.Point(102, 18);
            this.steer_comboBox5.Name = "steer_comboBox5";
            this.steer_comboBox5.Size = new System.Drawing.Size(121, 23);
            this.steer_comboBox5.TabIndex = 2;
            this.steer_comboBox5.DataSource = getSteerList();
            this.steer_comboBox5.ValueMember = "Key";
            this.steer_comboBox5.DisplayMember = "Value";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 643);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 20;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.dec_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 643);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clc_button_Click);
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(540, 643);
            this.query_button.Margin = new System.Windows.Forms.Padding(4);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(100, 29);
            this.query_button.TabIndex = 22;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(336, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "舵机名";
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(568, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "舵机通道/地址";
            // 
            // SteeringCalibrationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.set_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SteeringCalibrationView";
            this.Size = new System.Drawing.Size(867, 730);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button set_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.ComboBox steer_comboBox1;
        private System.Windows.Forms.ComboBox steer_addr_comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox steer_addr_comboBox2;
        private System.Windows.Forms.ComboBox steer_comboBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox steer_addr_comboBox4;
        private System.Windows.Forms.ComboBox steer_comboBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox steer_addr_comboBox3;
        private System.Windows.Forms.ComboBox steer_comboBox3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox steer_addr_comboBox8;
        private System.Windows.Forms.ComboBox steer_comboBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox steer_addr_comboBox7;
        private System.Windows.Forms.ComboBox steer_comboBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox steer_addr_comboBox6;
        private System.Windows.Forms.ComboBox steer_comboBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox steer_addr_comboBox5;
        private System.Windows.Forms.ComboBox steer_comboBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button query_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;

    }
}
