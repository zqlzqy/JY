using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class LineConnectView
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
            this.test_button = new System.Windows.Forms.Button();
            this.LineConnect_checkBox = new System.Windows.Forms.CheckBox();
            this.warningShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // test_button
            // 
            this.test_button.Location = new System.Drawing.Point(0, 0);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(75, 23);
            this.test_button.TabIndex = 0;
            // 
            // LineConnect_checkBox
            // 
            this.LineConnect_checkBox.AutoSize = true;
            this.LineConnect_checkBox.Location = new System.Drawing.Point(200, 17);
            this.LineConnect_checkBox.Name = "LineConnect_checkBox";
            this.LineConnect_checkBox.Size = new System.Drawing.Size(72, 16);
            this.LineConnect_checkBox.TabIndex = 13;
            this.LineConnect_checkBox.Text = "检查完成";
            //this.LineConnect_checkBox.Click += new System.EventHandler(this.LineConnect_checkBox_Click);
 //           this.LineConnect_checkBox.Click += new System.EventHandler(testSetFrm.LineConnect_checkBox_Click);
            this.LineConnect_checkBox.UseVisualStyleBackColor = true;
            // 
            // warningShow
            // 
            this.warningShow.AutoSize = true;
            this.warningShow.Location = new System.Drawing.Point(152, 90);
            this.warningShow.Name = "warningShow";
            this.warningShow.Size = new System.Drawing.Size(41, 12);
            this.warningShow.TabIndex = 14;
            this.warningShow.Text = "检查各连接器是否安装牢靠，各舵机安装是否良好";
            // 
            // LineConnectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.warningShow);
            this.Controls.Add(this.LineConnect_checkBox);
            this.Name = "LineConnectView";
            this.Size = new System.Drawing.Size(660, 416);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

   //     private TestSetFrm testSetFrm = new FBGroundControl.Forms.TestSetFrm();
        private System.Windows.Forms.Button test_button;
        public System.Windows.Forms.CheckBox LineConnect_checkBox;
        private System.Windows.Forms.Label warningShow;
    }
}
