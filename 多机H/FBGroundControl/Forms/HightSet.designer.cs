namespace FBGroundControl.Forms
{
    partial class HightSet
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
            this.cal_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cal_button
            // 
            this.cal_button.Location = new System.Drawing.Point(115, 66);
            this.cal_button.Name = "cal_button";
            this.cal_button.Size = new System.Drawing.Size(135, 41);
            this.cal_button.TabIndex = 2;
            this.cal_button.Text = "高度校准";
            this.cal_button.UseVisualStyleBackColor = true;
            this.cal_button.Click += new System.EventHandler(this.cal_button_Click);
            // 
            // HightSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 164);
            this.Controls.Add(this.cal_button);
            this.Name = "HightSet";
            this.Text = "高度校准";
            this.Load += new System.EventHandler(this.HightSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cal_button;
    }
}