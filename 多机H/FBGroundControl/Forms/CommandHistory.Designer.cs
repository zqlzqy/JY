namespace FBGroundControl.Forms
{
    partial class CommandHistory
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
        private void InitializeComponent( )
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.Rool_textBox = new System.Windows.Forms.TextBox();
            this.check_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(450, 101);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(90, 21);
            this.textBox.TabIndex = 23;
            // 
            // Rool_textBox
            // 
            this.Rool_textBox.Location = new System.Drawing.Point(2, 0);
            this.Rool_textBox.Multiline = true;
            this.Rool_textBox.Name = "Rool_textBox";
            this.Rool_textBox.Size = new System.Drawing.Size(575, 166);
            this.Rool_textBox.TabIndex = 24;
            // 
            // check_button
            // 
            this.check_button.Location = new System.Drawing.Point(471, 184);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(75, 29);
            this.check_button.TabIndex = 25;
            this.check_button.Text = "关闭";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // CommandHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 237);
            this.Controls.Add(this.check_button);
            this.Controls.Add(this.Rool_textBox);
            this.Name = "CommandHistory";
            this.Text = "指令内容";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox Rool_textBox;
        private System.Windows.Forms.Button check_button;

    }
}