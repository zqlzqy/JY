namespace FBGroundControl.Forms
{
    partial class Route
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
            this.routec = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.routes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // routec
            // 
            this.routec.Enabled = false;
            this.routec.Font = new System.Drawing.Font("宋体", 9F);
            this.routec.Location = new System.Drawing.Point(106, 56);
            this.routec.Name = "routec";
            this.routec.Size = new System.Drawing.Size(43, 21);
            this.routec.TabIndex = 22;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("宋体", 9F);
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(22, 59);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(115, 23);
            this.label90.TabIndex = 20;
            this.label90.Text = "航线编号";
            // 
            // routes
            // 
            this.routes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.routes.FormattingEnabled = true;
            this.routes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.routes.Location = new System.Drawing.Point(165, 56);
            this.routes.Name = "routes";
            this.routes.Size = new System.Drawing.Size(41, 20);
            this.routes.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "查询编号航线";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 259);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.routes);
            this.Controls.Add(this.routec);
            this.Controls.Add(this.label90);
            this.Name = "Route";
            this.Text = "航线参数";
            this.Load += new System.EventHandler(this.Route_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox routec;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.ComboBox routes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}