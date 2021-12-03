using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class ManualCheckView
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
            this.Manual_checkBox = new System.Windows.Forms.CheckBox();
            this.warningShow = new System.Windows.Forms.Label();
            this.Status_groupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Status_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Manual_checkBox
            // 
            this.Manual_checkBox.AutoSize = true;
            this.Manual_checkBox.Location = new System.Drawing.Point(200, 17);
            this.Manual_checkBox.Name = "Manual_checkBox";
            this.Manual_checkBox.Size = new System.Drawing.Size(72, 16);
            this.Manual_checkBox.TabIndex = 13;
            this.Manual_checkBox.Text = "检查完成";
            this.Manual_checkBox.UseVisualStyleBackColor = true;
            // 
            // warningShow
            // 
            this.warningShow.AutoSize = true;
            this.warningShow.Location = new System.Drawing.Point(99, 99);
            this.warningShow.Name = "warningShow";
            this.warningShow.Size = new System.Drawing.Size(317, 12);
            this.warningShow.TabIndex = 14;
            this.warningShow.Text = "选择手动控制，检查舵面，检验舵面对齐，舵面大小和方向";
            // 
            // Status_groupBox
            // 
            this.Status_groupBox.Controls.Add(this.label8);
            this.Status_groupBox.Location = new System.Drawing.Point(483, 76);
            this.Status_groupBox.Name = "Status_groupBox";
            this.Status_groupBox.Size = new System.Drawing.Size(84, 51);
            this.Status_groupBox.TabIndex = 17;
            this.Status_groupBox.TabStop = false;
            this.Status_groupBox.Text = "自驾状态";
            // 
            // label8
            // 
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(26, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "自控";
            // 
            // ManualCheckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Status_groupBox);
            this.Controls.Add(this.warningShow);
            this.Controls.Add(this.Manual_checkBox);
            this.Name = "ManualCheckView";
            this.Size = new System.Drawing.Size(660, 416);
            this.Status_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox Manual_checkBox;
        private System.Windows.Forms.Label warningShow;
        private System.Windows.Forms.GroupBox Status_groupBox;
        private System.Windows.Forms.Label label8;
    }
}
