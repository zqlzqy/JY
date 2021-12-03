namespace FBGroundControl.Forms
{
    partial class ViewSetFrm
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
            this.menu_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.headstatus_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.map_checkBox = new System.Windows.Forms.CheckBox();
            this.commond_checkBox = new System.Windows.Forms.CheckBox();
            this.mainstatus_checkBox = new System.Windows.Forms.CheckBox();
            this.head_checkBox = new System.Windows.Forms.CheckBox();
            this.solid_checkBox = new System.Windows.Forms.CheckBox();
            this.save_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_checkBox
            // 
            this.menu_checkBox.AutoSize = true;
            this.menu_checkBox.Location = new System.Drawing.Point(49, 26);
            this.menu_checkBox.Name = "menu_checkBox";
            this.menu_checkBox.Size = new System.Drawing.Size(60, 16);
            this.menu_checkBox.TabIndex = 0;
            this.menu_checkBox.Text = "菜单栏";
            this.menu_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menu_checkBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单栏";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.headstatus_checkBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态栏";
            // 
            // headstatus_checkBox
            // 
            this.headstatus_checkBox.AutoSize = true;
            this.headstatus_checkBox.Location = new System.Drawing.Point(49, 25);
            this.headstatus_checkBox.Name = "headstatus_checkBox";
            this.headstatus_checkBox.Size = new System.Drawing.Size(60, 16);
            this.headstatus_checkBox.TabIndex = 1;
            this.headstatus_checkBox.Text = "状态栏";
            this.headstatus_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.map_checkBox);
            this.groupBox3.Controls.Add(this.commond_checkBox);
            this.groupBox3.Controls.Add(this.mainstatus_checkBox);
            this.groupBox3.Controls.Add(this.head_checkBox);
            this.groupBox3.Controls.Add(this.solid_checkBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "主操作区";
            // 
            // map_checkBox
            // 
            this.map_checkBox.AutoSize = true;
            this.map_checkBox.Location = new System.Drawing.Point(49, 29);
            this.map_checkBox.Name = "map_checkBox";
            this.map_checkBox.Size = new System.Drawing.Size(60, 16);
            this.map_checkBox.TabIndex = 3;
            this.map_checkBox.Text = "地图区";
            this.map_checkBox.UseVisualStyleBackColor = true;
            // 
            // commond_checkBox
            // 
            this.commond_checkBox.AutoSize = true;
            this.commond_checkBox.Location = new System.Drawing.Point(247, 29);
            this.commond_checkBox.Name = "commond_checkBox";
            this.commond_checkBox.Size = new System.Drawing.Size(60, 16);
            this.commond_checkBox.TabIndex = 2;
            this.commond_checkBox.Text = "指令区";
            this.commond_checkBox.UseVisualStyleBackColor = true;
            // 
            // mainstatus_checkBox
            // 
            this.mainstatus_checkBox.AutoSize = true;
            this.mainstatus_checkBox.Location = new System.Drawing.Point(181, 29);
            this.mainstatus_checkBox.Name = "mainstatus_checkBox";
            this.mainstatus_checkBox.Size = new System.Drawing.Size(60, 16);
            this.mainstatus_checkBox.TabIndex = 1;
            this.mainstatus_checkBox.Text = "状态区";
            this.mainstatus_checkBox.UseVisualStyleBackColor = true;
            // 
            // head_checkBox
            // 
            this.head_checkBox.AutoSize = true;
            this.head_checkBox.Location = new System.Drawing.Point(115, 29);
            this.head_checkBox.Name = "head_checkBox";
            this.head_checkBox.Size = new System.Drawing.Size(60, 16);
            this.head_checkBox.TabIndex = 0;
            this.head_checkBox.Text = "头显区";
            this.head_checkBox.UseVisualStyleBackColor = true;

            this.solid_checkBox.AutoSize = true;
            this.solid_checkBox.Location = new System.Drawing.Point(115, 29);
            this.solid_checkBox.Name = "solid_checkBox";
            this.solid_checkBox.Size = new System.Drawing.Size(60, 16);
            this.solid_checkBox.TabIndex = 0;
            this.solid_checkBox.Text = "立体显示";
            this.solid_checkBox.UseVisualStyleBackColor = true;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(193, 244);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 4;
            this.save_button.Text = "确定";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(289, 244);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "取消";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // ViewSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 279);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewSetFrm";
            this.Text = "视图设置";
            this.Load += new System.EventHandler(this.ViewSetFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox menu_checkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox headstatus_checkBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox commond_checkBox;
        private System.Windows.Forms.CheckBox mainstatus_checkBox;
        private System.Windows.Forms.CheckBox head_checkBox;
        private System.Windows.Forms.CheckBox solid_checkBox;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.CheckBox map_checkBox;
    }
}