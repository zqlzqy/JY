namespace FBGroundControl.Forms
{
    partial class DataManageFrm
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
            this.button4 = new System.Windows.Forms.Button();
            this.check_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.limitlabel = new System.Windows.Forms.Label();
            this.guideCtrllabel = new System.Windows.Forms.Label();
            this.attitudelabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(259, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 29);
            this.button4.TabIndex = 15;
            this.button4.Text = "验证配置文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // check_button
            // 
            this.check_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.check_button.Location = new System.Drawing.Point(408, 148);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(75, 29);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "关闭";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_button);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.limitlabel);
            this.groupBox2.Controls.Add(this.guideCtrllabel);
            this.groupBox2.Controls.Add(this.attitudelabel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(42, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 209);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数管理";
            // 
            // limitlabel
            // 
            this.limitlabel.BackColor = System.Drawing.Color.White;
            this.limitlabel.Location = new System.Drawing.Point(347, 30);
            this.limitlabel.Name = "limitlabel";
            this.limitlabel.Size = new System.Drawing.Size(78, 21);
            this.limitlabel.TabIndex = 22;
            this.limitlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guideCtrllabel
            // 
            this.guideCtrllabel.BackColor = System.Drawing.Color.White;
            this.guideCtrllabel.Location = new System.Drawing.Point(137, 71);
            this.guideCtrllabel.Name = "guideCtrllabel";
            this.guideCtrllabel.Size = new System.Drawing.Size(78, 21);
            this.guideCtrllabel.TabIndex = 18;
            this.guideCtrllabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attitudelabel
            // 
            this.attitudelabel.BackColor = System.Drawing.Color.White;
            this.attitudelabel.Location = new System.Drawing.Point(137, 27);
            this.attitudelabel.Name = "attitudelabel";
            this.attitudelabel.Size = new System.Drawing.Size(78, 21);
            this.attitudelabel.TabIndex = 16;
            this.attitudelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "极限参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "制导参数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姿态环参数";
            // 
            // DataManageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 243);
            this.Controls.Add(this.groupBox2);
            this.Name = "DataManageFrm";
            this.Text = "参数管理";
            this.Load += new System.EventHandler(this.DataManageFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label attitudelabel;
        private System.Windows.Forms.Label limitlabel;
        private System.Windows.Forms.Label guideCtrllabel;

    }
}