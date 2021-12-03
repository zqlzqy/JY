namespace FBGroundControl.Forms
{
    partial class RouteLoadFrm
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
            this.location_textBox = new System.Windows.Forms.TextBox();
            this.choose_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.load_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(312, 86);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 7;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            // 
            // location_textBox
            // 
            this.location_textBox.Location = new System.Drawing.Point(100, 28);
            this.location_textBox.Name = "location_textBox";
            this.location_textBox.Size = new System.Drawing.Size(198, 21);
            this.location_textBox.TabIndex = 6;
            // 
            // choose_button
            // 
            this.choose_button.Location = new System.Drawing.Point(312, 27);
            this.choose_button.Name = "choose_button";
            this.choose_button.Size = new System.Drawing.Size(75, 23);
            this.choose_button.TabIndex = 5;
            this.choose_button.Text = "选择";
            this.choose_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "选择航线文件：";
            // 
            // load_button
            // 
            this.load_button.Location = new System.Drawing.Point(223, 86);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(75, 23);
            this.load_button.TabIndex = 8;
            this.load_button.Text = "加载";
            this.load_button.UseVisualStyleBackColor = true;
            // 
            // RouteLoadFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 131);
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.location_textBox);
            this.Controls.Add(this.choose_button);
            this.Controls.Add(this.label1);
            this.Name = "RouteLoadFrm";
            this.Text = "航线加载";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.TextBox location_textBox;
        private System.Windows.Forms.Button choose_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button load_button;
    }
}