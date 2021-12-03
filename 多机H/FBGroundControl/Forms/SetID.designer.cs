namespace FBGroundControl.Forms
{
    partial class SetID
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
            this.IDC = new System.Windows.Forms.TextBox();
            this.IDS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DmzC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeS = new System.Windows.Forms.ComboBox();
            this.DmzS = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IDC
            // 
            this.IDC.Enabled = false;
            this.IDC.Location = new System.Drawing.Point(142, 112);
            this.IDC.Name = "IDC";
            this.IDC.Size = new System.Drawing.Size(70, 21);
            this.IDC.TabIndex = 21;
            // 
            // IDS
            // 
            this.IDS.Location = new System.Drawing.Point(231, 112);
            this.IDS.Name = "IDS";
            this.IDS.Size = new System.Drawing.Size(70, 21);
            this.IDS.TabIndex = 20;
            this.IDS.Text = "1";
            // 
            // label11
            // 
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(63, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "靶机改变ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(63, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "当前靶机ID";
            // 
            // DmzC
            // 
            this.DmzC.Enabled = false;
            this.DmzC.Location = new System.Drawing.Point(142, 161);
            this.DmzC.Name = "DmzC";
            this.DmzC.Size = new System.Drawing.Size(70, 21);
            this.DmzC.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(63, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "地面站ID";
            // 
            // TypeS
            // 
            this.TypeS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeS.FormattingEnabled = true;
            this.TypeS.Location = new System.Drawing.Point(231, 48);
            this.TypeS.Name = "TypeS";
            this.TypeS.Size = new System.Drawing.Size(70, 20);
            this.TypeS.TabIndex = 28;
            this.TypeS.Click += new System.EventHandler(this.TypeS_Click);
            // 
            // DmzS
            // 
            this.DmzS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DmzS.FormattingEnabled = true;
            this.DmzS.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.DmzS.Location = new System.Drawing.Point(231, 161);
            this.DmzS.Name = "DmzS";
            this.DmzS.Size = new System.Drawing.Size(70, 20);
            this.DmzS.TabIndex = 29;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(231, 203);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 20);
            this.comboBox1.TabIndex = 32;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(142, 203);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 21);
            this.textBox1.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(63, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "靶机类型";
            // 
            // SetID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 320);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DmzS);
            this.Controls.Add(this.TypeS);
            this.Controls.Add(this.DmzC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDC);
            this.Controls.Add(this.IDS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "SetID";
            this.Text = "配置靶机ID";
            this.Load += new System.EventHandler(this.SetID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDC;
        private System.Windows.Forms.TextBox IDS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DmzC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeS;
        private System.Windows.Forms.ComboBox DmzS;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}