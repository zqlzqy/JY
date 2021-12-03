namespace FBGroundControl.Forms
{
    partial class GrjCommand
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
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.command_com = new System.Windows.Forms.ComboBox();
            this.b6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.b5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.b4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.b3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_textBox = new System.Windows.Forms.TextBox();
            this.num_textBox = new System.Windows.Forms.TextBox();
            this.roll_kp_textBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.button1);
            this.groupBox25.Controls.Add(this.command_com);
            this.groupBox25.Controls.Add(this.b6);
            this.groupBox25.Controls.Add(this.label4);
            this.groupBox25.Controls.Add(this.b5);
            this.groupBox25.Controls.Add(this.label5);
            this.groupBox25.Controls.Add(this.b4);
            this.groupBox25.Controls.Add(this.label6);
            this.groupBox25.Controls.Add(this.b3);
            this.groupBox25.Controls.Add(this.label3);
            this.groupBox25.Controls.Add(this.b2);
            this.groupBox25.Controls.Add(this.label2);
            this.groupBox25.Controls.Add(this.b1);
            this.groupBox25.Controls.Add(this.label1);
            this.groupBox25.Controls.Add(this.id_textBox);
            this.groupBox25.Controls.Add(this.num_textBox);
            this.groupBox25.Controls.Add(this.roll_kp_textBox);
            this.groupBox25.Controls.Add(this.label17);
            this.groupBox25.Controls.Add(this.label88);
            this.groupBox25.Controls.Add(this.label90);
            this.groupBox25.Controls.Add(this.label91);
            this.groupBox25.Location = new System.Drawing.Point(12, 12);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(469, 331);
            this.groupBox25.TabIndex = 7;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "干扰机指令";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "上传指令";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // command_com
            // 
            this.command_com.FormattingEnabled = true;
            this.command_com.Items.AddRange(new object[] {
            "开干扰",
            "关干扰",
            "任务1",
            "任务2",
            "任务3",
            "任务4",
            "任务5",
            "任务6",
            "任务7",
            "任务8",
            "自检",
            "待机",
            "卸载数据",
            "备份1",
            "备份2"});
            this.command_com.Location = new System.Drawing.Point(134, 210);
            this.command_com.Name = "command_com";
            this.command_com.Size = new System.Drawing.Size(82, 20);
            this.command_com.TabIndex = 24;
            // 
            // b6
            // 
            this.b6.Location = new System.Drawing.Point(343, 210);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(74, 21);
            this.b6.TabIndex = 23;
            this.b6.Text = "0";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(272, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "保留6";
            // 
            // b5
            // 
            this.b5.Location = new System.Drawing.Point(343, 174);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(74, 21);
            this.b5.TabIndex = 21;
            this.b5.Text = "0";
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(272, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "保留5";
            // 
            // b4
            // 
            this.b4.Location = new System.Drawing.Point(343, 138);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(74, 21);
            this.b4.TabIndex = 19;
            this.b4.Text = "0";
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(272, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "保留4";
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(343, 102);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(74, 21);
            this.b3.TabIndex = 17;
            this.b3.Text = "0";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(272, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "保留3";
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(343, 66);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(74, 21);
            this.b2.TabIndex = 15;
            this.b2.Text = "0";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(272, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "保留2";
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(343, 30);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(74, 21);
            this.b1.TabIndex = 13;
            this.b1.Text = "0";
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(272, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "保留1";
            // 
            // id_textBox
            // 
            this.id_textBox.Location = new System.Drawing.Point(133, 153);
            this.id_textBox.Name = "id_textBox";
            this.id_textBox.Size = new System.Drawing.Size(74, 21);
            this.id_textBox.TabIndex = 10;
            this.id_textBox.Text = "0";
            // 
            // num_textBox
            // 
            this.num_textBox.Location = new System.Drawing.Point(133, 97);
            this.num_textBox.Name = "num_textBox";
            this.num_textBox.Size = new System.Drawing.Size(75, 21);
            this.num_textBox.TabIndex = 9;
            this.num_textBox.Text = "0";
            // 
            // roll_kp_textBox
            // 
            this.roll_kp_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roll_kp_textBox.Location = new System.Drawing.Point(133, 30);
            this.roll_kp_textBox.Name = "roll_kp_textBox";
            this.roll_kp_textBox.Size = new System.Drawing.Size(75, 21);
            this.roll_kp_textBox.TabIndex = 8;
            this.roll_kp_textBox.Text = "0xCC";
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(28, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "飞机号";
            // 
            // label88
            // 
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(29, 213);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(68, 13);
            this.label88.TabIndex = 6;
            this.label88.Text = "开关指令";
            // 
            // label90
            // 
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(29, 100);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(45, 13);
            this.label90.TabIndex = 2;
            this.label90.Text = "批号";
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(29, 33);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(90, 18);
            this.label91.TabIndex = 0;
            this.label91.Text = "指令类型标志";
            // 
            // GrjCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 355);
            this.Controls.Add(this.groupBox25);
            this.Name = "GrjCommand";
            this.Text = "干扰机遥控指令";
            this.Load += new System.EventHandler(this.GrjCommand_Load);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox id_textBox;
        private System.Windows.Forms.TextBox num_textBox;
        private System.Windows.Forms.TextBox roll_kp_textBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.ComboBox command_com;
        private System.Windows.Forms.TextBox b6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox b5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox b4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox b3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox b2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox b1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}