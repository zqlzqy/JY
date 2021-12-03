using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class AttitudeCheckView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Attitude_checkBox = new System.Windows.Forms.CheckBox();
            this.warningShow = new System.Windows.Forms.Label();
            this.Rool_label = new System.Windows.Forms.Label();
            this.Rool_textBox = new System.Windows.Forms.TextBox();
            this.Pitch_textBox = new System.Windows.Forms.TextBox();
            this.Pitch_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Attitude_checkBox
            // 
            this.Attitude_checkBox.AutoSize = true;
            this.Attitude_checkBox.Location = new System.Drawing.Point(200, 17);
            this.Attitude_checkBox.Name = "Attitude_checkBox";
            this.Attitude_checkBox.Size = new System.Drawing.Size(72, 16);
            this.Attitude_checkBox.TabIndex = 13;
            this.Attitude_checkBox.Text = "检查完成";
            this.Attitude_checkBox.UseVisualStyleBackColor = true;
            // 
            // warningShow
            // 
            this.warningShow.AutoSize = true;
            this.warningShow.Location = new System.Drawing.Point(82, 57);
            this.warningShow.Name = "warningShow";
            this.warningShow.Size = new System.Drawing.Size(221, 12);
            this.warningShow.TabIndex = 14;
            this.warningShow.Text = "转动机身，检查显示是否与实际姿态一致";
            // 
            // Rool_label
            // 
            this.Rool_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Rool_label.Location = new System.Drawing.Point(57, 96);
            this.Rool_label.Name = "Rool_label";
            this.Rool_label.Size = new System.Drawing.Size(84, 13);
            this.Rool_label.TabIndex = 15;
            this.Rool_label.Text = "滚转";
            // 
            // Rool_textBox
            // 
            this.Rool_textBox.Enabled = false;
            this.Rool_textBox.Location = new System.Drawing.Point(129, 93);
            this.Rool_textBox.Name = "Rool_textBox";
            this.Rool_textBox.Size = new System.Drawing.Size(90, 21);
            this.Rool_textBox.TabIndex = 16;
            // 
            // Pitch_textBox
            // 
            this.Pitch_textBox.Enabled = false;
            this.Pitch_textBox.Location = new System.Drawing.Point(129, 141);
            this.Pitch_textBox.Name = "Pitch_textBox";
            this.Pitch_textBox.Size = new System.Drawing.Size(90, 21);
            this.Pitch_textBox.TabIndex = 18;
            // 
            // Pitch_label
            // 
            this.Pitch_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pitch_label.Location = new System.Drawing.Point(57, 144);
            this.Pitch_label.Name = "Pitch_label";
            this.Pitch_label.Size = new System.Drawing.Size(84, 13);
            this.Pitch_label.TabIndex = 17;
            this.Pitch_label.Text = "俯仰";
            // 
            // AttitudeCheckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Pitch_textBox);
            this.Controls.Add(this.Pitch_label);
            this.Controls.Add(this.Rool_textBox);
            this.Controls.Add(this.Rool_label);
            this.Controls.Add(this.warningShow);
            this.Controls.Add(this.Attitude_checkBox);
            this.Name = "AttitudeCheckView";
            this.Size = new System.Drawing.Size(660, 416);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox Attitude_checkBox;
        private System.Windows.Forms.Label warningShow;
        private System.Windows.Forms.Label Rool_label;
        private System.Windows.Forms.TextBox Rool_textBox;
        private System.Windows.Forms.TextBox Pitch_textBox;
        private System.Windows.Forms.Label Pitch_label;
    }
}
