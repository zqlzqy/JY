﻿using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class CtrlPolarityiew
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.steer_action_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // test_button
            // 
            this.test_button.Location = new System.Drawing.Point(96, 312);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(75, 23);
            this.test_button.TabIndex = 1;
            this.test_button.Text = "测试";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "控制极性";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.steer_action_comboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(84, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 154);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制极性";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "舵机动作位";
            // 
            // steer_action_comboBox
            // 
            this.steer_action_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.steer_action_comboBox.FormattingEnabled = true;
            this.steer_action_comboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.steer_action_comboBox.Location = new System.Drawing.Point(149, 24);
            this.steer_action_comboBox.Name = "steer_action_comboBox";
            this.steer_action_comboBox.Size = new System.Drawing.Size(121, 20);
            this.steer_action_comboBox.TabIndex = 1;
            // 
            // CtrlPolarityiew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.test_button);
            this.Name = "CtrlPolarityiew";
            this.Size = new System.Drawing.Size(660, 416);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox steer_action_comboBox;
    }
}
