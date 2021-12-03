namespace FBGroundControl.chao.views
{
    partial class FlyToPointForm
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
            this.lbl_commandpoint = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_selectAircraft = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_targetAlt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_command = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "坐标位置：";
            // 
            // lbl_commandpoint
            // 
            this.lbl_commandpoint.AutoSize = true;
            this.lbl_commandpoint.Location = new System.Drawing.Point(85, 13);
            this.lbl_commandpoint.Name = "lbl_commandpoint";
            this.lbl_commandpoint.Size = new System.Drawing.Size(41, 12);
            this.lbl_commandpoint.TabIndex = 1;
            this.lbl_commandpoint.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择飞机：";
            // 
            // cbx_selectAircraft
            // 
            this.cbx_selectAircraft.FormattingEnabled = true;
            this.cbx_selectAircraft.Location = new System.Drawing.Point(86, 51);
            this.cbx_selectAircraft.Name = "cbx_selectAircraft";
            this.cbx_selectAircraft.Size = new System.Drawing.Size(121, 20);
            this.cbx_selectAircraft.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "高度：";
            // 
            // tb_targetAlt
            // 
            this.tb_targetAlt.Location = new System.Drawing.Point(87, 102);
            this.tb_targetAlt.Name = "tb_targetAlt";
            this.tb_targetAlt.Size = new System.Drawing.Size(120, 21);
            this.tb_targetAlt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "任务：";
            // 
            // cbx_command
            // 
            this.cbx_command.FormattingEnabled = true;
            this.cbx_command.Items.AddRange(new object[] {
            "定点盘旋",
            "自动返航",
            "航迹飞行",
            "开伞"});
            this.cbx_command.Location = new System.Drawing.Point(87, 148);
            this.cbx_command.Name = "cbx_command";
            this.cbx_command.Size = new System.Drawing.Size(121, 20);
            this.cbx_command.TabIndex = 7;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(35, 213);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(158, 213);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // FlyToPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cbx_command);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_targetAlt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_selectAircraft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_commandpoint);
            this.Controls.Add(this.label1);
            this.Name = "FlyToPointForm";
            this.Text = "飞行至此点";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_commandpoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_selectAircraft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_targetAlt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_command;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}