using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class PassesView
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
            this.Passes_checkBox = new System.Windows.Forms.CheckBox();
            this.warningShow = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // LineConnect_checkBox
            // 
            this.Passes_checkBox.AutoSize = true;
            this.Passes_checkBox.Location = new System.Drawing.Point(200, 17);
            this.Passes_checkBox.Name = "Passes_checkBox";
            this.Passes_checkBox.Size = new System.Drawing.Size(72, 16);
            this.Passes_checkBox.TabIndex = 13;
            this.Passes_checkBox.Text = "检查完成";
            this.Passes_checkBox.UseVisualStyleBackColor = true;
            // 
            // warningShow
            // 
            this.warningShow.AutoSize = true;
            this.warningShow.Location = new System.Drawing.Point(152, 90);
            this.warningShow.Name = "warningShow";
            this.warningShow.Size = new System.Drawing.Size(41, 12);
            this.warningShow.TabIndex = 14;
            this.warningShow.Text = "启动发动机，通过转速变化校验动压、静压、磁罗盘和姿态是否正确运行";
            // 
            // LineConnectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.warningShow);
            this.Controls.Add(this.Passes_checkBox);
            this.Name = "PassesView";
            this.Size = new System.Drawing.Size(660, 416);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox Passes_checkBox;
        private System.Windows.Forms.Label warningShow;
    }
}
