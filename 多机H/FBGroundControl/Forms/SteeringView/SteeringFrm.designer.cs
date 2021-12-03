using System.Collections.Generic;
using System.Windows.Forms;
namespace FBGroundControl.Forms
{
    partial class SteeringFrm
    {

        private System.ComponentModel.IContainer components = null;


        private SteeringCalibrationView scView;
       

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        /// </summary>
        private void InitializeComponent()
        {
            this.airspeedbaltview_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.check_button = new System.Windows.Forms.Button();
            this.setup_parm = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scView = new FBGroundControl.Forms.SteeringCalibrationView();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // airspeedbaltview_button
            // 
            this.airspeedbaltview_button.Location = new System.Drawing.Point(15, 29);
            this.airspeedbaltview_button.Name = "airspeedbaltview_button";
            this.airspeedbaltview_button.Size = new System.Drawing.Size(168, 23);
            this.airspeedbaltview_button.TabIndex = 2;
            this.airspeedbaltview_button.Text = "空速和气压高度";
            this.airspeedbaltview_button.UseVisualStyleBackColor = true;
            this.airspeedbaltview_button.Click += new System.EventHandler(this.airspeedbaltview_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.check_button);
            this.groupBox2.Controls.Add(this.setup_parm);
            this.groupBox2.Controls.Add(this.search);
            this.groupBox2.Controls.Add(this.type);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 178);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "类型设置";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "JETCAT 400P",
            "JetCat 300P",
            "KingTech 210",
            "JETCAT 500P"});
            this.comboBox1.Location = new System.Drawing.Point(220, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // check_button
            // 
            this.check_button.Location = new System.Drawing.Point(556, 127);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(75, 26);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "关闭";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // setup_parm
            // 
            this.setup_parm.Location = new System.Drawing.Point(373, 127);
            this.setup_parm.Name = "setup_parm";
            this.setup_parm.Size = new System.Drawing.Size(75, 26);
            this.setup_parm.TabIndex = 2;
            this.setup_parm.Text = "设置";
            this.setup_parm.UseVisualStyleBackColor = true;
            this.setup_parm.Click += new System.EventHandler(this.setup_parm_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(465, 127);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 26);
            this.search.TabIndex = 2;
            this.search.Text = "查询";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // type
            // 
            this.type.Enabled = false;
            this.type.Location = new System.Drawing.Point(80, 53);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(103, 21);
            this.type.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型";
            // 
            // scView
            // 
            this.scView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scView.Location = new System.Drawing.Point(0, 0);
            this.scView.Margin = new System.Windows.Forms.Padding(4);
            this.scView.Name = "scView";
            this.scView.Size = new System.Drawing.Size(1009, 471);
            this.scView.TabIndex = 0;
            // 
            // SteeringFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 201);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "SteeringFrm";
            this.Text = " 发动机类型设置";
            this.Load += new System.EventHandler(this.SteeringFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button airspeedbaltview_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button check_button;
        private TextBox type;
        private Label label1;
        private Button setup_parm;
        private Button search;
        private ComboBox comboBox1;

    }
}