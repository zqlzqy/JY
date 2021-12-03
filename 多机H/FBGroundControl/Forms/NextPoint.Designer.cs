namespace FBGroundControl.Forms
{
    partial class NextPoint
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
            this.pointnum = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pointnum
            // 
            this.pointnum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pointnum.Location = new System.Drawing.Point(174, 30);
            this.pointnum.Name = "pointnum";
            this.pointnum.Size = new System.Drawing.Size(48, 21);
            this.pointnum.TabIndex = 14;
            this.pointnum.Text = "0";
            // 
            // label91
            // 
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(46, 33);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(108, 27);
            this.label91.TabIndex = 13;
            this.label91.Text = "跳转至航点号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NextPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 157);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pointnum);
            this.Controls.Add(this.label91);
            this.Name = "NextPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "跳转至任意点";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pointnum;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Button button1;
    }
}