namespace FBGroundControl.Forms
{
    partial class DataRecordSet
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
            this.saveLocation_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.save_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.user_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveLocation_textBox
            // 
            this.saveLocation_textBox.Location = new System.Drawing.Point(86, 80);
            this.saveLocation_textBox.Name = "saveLocation_textBox";
            this.saveLocation_textBox.Size = new System.Drawing.Size(300, 21);
            this.saveLocation_textBox.TabIndex = 5;
            this.saveLocation_textBox.Click += new System.EventHandler(this.saveLocation_textBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "保存位置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "保存频率：";
            this.label2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(86, 35);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Visible = false;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(222, 151);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 8;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(311, 151);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 9;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // user_checkBox
            // 
            this.user_checkBox.AutoSize = true;
            this.user_checkBox.Location = new System.Drawing.Point(86, 119);
            this.user_checkBox.Name = "user_checkBox";
            this.user_checkBox.Size = new System.Drawing.Size(96, 16);
            this.user_checkBox.TabIndex = 10;
            this.user_checkBox.Text = "使用数据记录";
            this.user_checkBox.UseVisualStyleBackColor = true;
            this.user_checkBox.Visible = false;
            this.user_checkBox.CheckedChanged += new System.EventHandler(this.user_checkBox_CheckedChanged);
            // 
            // DataRecordSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 196);
            this.Controls.Add(this.user_checkBox);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveLocation_textBox);
            this.Controls.Add(this.label1);
            this.Name = "DataRecordSet";
            this.Text = "数据记录设置";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox saveLocation_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.CheckBox user_checkBox;
    }
}