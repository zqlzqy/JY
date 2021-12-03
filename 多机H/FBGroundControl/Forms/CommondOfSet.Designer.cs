namespace FBGroundControl.Forms
{
    partial class CommondOfSet
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
            this.close_button = new System.Windows.Forms.Button();
            this.command_textBox = new System.Windows.Forms.TextBox();
            this.Send_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.planID_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(301, 102);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 7;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // command_textBox
            // 
            this.command_textBox.Location = new System.Drawing.Point(79, 54);
            this.command_textBox.Name = "command_textBox";
            this.command_textBox.Size = new System.Drawing.Size(297, 21);
            this.command_textBox.TabIndex = 6;
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(213, 102);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(75, 23);
            this.Send_button.TabIndex = 5;
            this.Send_button.Text = "发送";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "发送命令：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "飞机ID：";
            // 
            // planID_comboBox
            // 
            this.planID_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.planID_comboBox.DropDownWidth = 200;
            this.planID_comboBox.FormattingEnabled = true;
            this.planID_comboBox.Location = new System.Drawing.Point(79, 18);
            this.planID_comboBox.Name = "planID_comboBox";
            this.planID_comboBox.Size = new System.Drawing.Size(297, 22);
            this.planID_comboBox.TabIndex = 9;
            // 
            // CommondOfSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 137);
            this.Controls.Add(this.planID_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.command_textBox);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.label1);
            this.Name = "CommondOfSet";
            this.Text = "命令";
            this.Load += new System.EventHandler(this.CommondOfSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.TextBox command_textBox;
        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox planID_comboBox;
    }
}