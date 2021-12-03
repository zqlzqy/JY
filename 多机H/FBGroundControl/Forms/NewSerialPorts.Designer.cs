namespace FBGroundControl.Forms
{
    partial class NewSerialPorts
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nserialport_combox = new System.Windows.Forms.ComboBox();
            this.Nbaudrate_combox = new System.Windows.Forms.ComboBox();
            this.openserial_btn = new System.Windows.Forms.Button();
            this.refreshserial_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // Nserialport_combox
            // 
            this.Nserialport_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Nserialport_combox.FormattingEnabled = true;
            this.Nserialport_combox.Location = new System.Drawing.Point(131, 50);
            this.Nserialport_combox.Name = "Nserialport_combox";
            this.Nserialport_combox.Size = new System.Drawing.Size(121, 20);
            this.Nserialport_combox.TabIndex = 2;
            // 
            // Nbaudrate_combox
            // 
            this.Nbaudrate_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Nbaudrate_combox.FormattingEnabled = true;
            this.Nbaudrate_combox.Location = new System.Drawing.Point(131, 102);
            this.Nbaudrate_combox.Name = "Nbaudrate_combox";
            this.Nbaudrate_combox.Size = new System.Drawing.Size(121, 20);
            this.Nbaudrate_combox.TabIndex = 3;
            // 
            // openserial_btn
            // 
            this.openserial_btn.Location = new System.Drawing.Point(112, 186);
            this.openserial_btn.Name = "openserial_btn";
            this.openserial_btn.Size = new System.Drawing.Size(75, 23);
            this.openserial_btn.TabIndex = 4;
            this.openserial_btn.Text = "打开";
            this.openserial_btn.UseVisualStyleBackColor = true;
            this.openserial_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshserial_btn
            // 
            this.refreshserial_btn.Location = new System.Drawing.Point(215, 186);
            this.refreshserial_btn.Name = "refreshserial_btn";
            this.refreshserial_btn.Size = new System.Drawing.Size(75, 23);
            this.refreshserial_btn.TabIndex = 5;
            this.refreshserial_btn.Text = "刷新";
            this.refreshserial_btn.UseVisualStyleBackColor = true;
            this.refreshserial_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewSerialPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 257);
            this.Controls.Add(this.refreshserial_btn);
            this.Controls.Add(this.openserial_btn);
            this.Controls.Add(this.Nbaudrate_combox);
            this.Controls.Add(this.Nserialport_combox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewSerialPorts";
            this.Text = "NewSerialPorts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewSerialPorts_FormClosed);
            this.Load += new System.EventHandler(this.NewSerialPorts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Nserialport_combox;
        private System.Windows.Forms.ComboBox Nbaudrate_combox;
        private System.Windows.Forms.Button openserial_btn;
        private System.Windows.Forms.Button refreshserial_btn;
    }
}