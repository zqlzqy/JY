using MissionPlanner.Controls;
namespace FBGroundControl.Forms
{
    partial class NAVsetView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delaytimec = new System.Windows.Forms.TextBox();
            this.delaytime = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lngc = new System.Windows.Forms.TextBox();
            this.latc = new System.Windows.Forms.TextBox();
            this.startc = new System.Windows.Forms.TextBox();
            this.speedc = new System.Windows.Forms.TextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.lat = new System.Windows.Forms.TextBox();
            this.lng = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Import = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.setup_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.delaytimec);
            this.groupBox1.Controls.Add(this.delaytime);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.lngc);
            this.groupBox1.Controls.Add(this.latc);
            this.groupBox1.Controls.Add(this.startc);
            this.groupBox1.Controls.Add(this.speedc);
            this.groupBox1.Controls.Add(this.speed);
            this.groupBox1.Controls.Add(this.lat);
            this.groupBox1.Controls.Add(this.lng);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Location = new System.Drawing.Point(32, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 359);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // delaytimec
            // 
            this.delaytimec.Enabled = false;
            this.delaytimec.Location = new System.Drawing.Point(192, 244);
            this.delaytimec.Name = "delaytimec";
            this.delaytimec.Size = new System.Drawing.Size(70, 21);
            this.delaytimec.TabIndex = 35;
            // 
            // delaytime
            // 
            this.delaytime.Location = new System.Drawing.Point(268, 244);
            this.delaytime.Name = "delaytime";
            this.delaytime.Size = new System.Drawing.Size(70, 21);
            this.delaytime.TabIndex = 34;
            this.delaytime.Text = "0";
            // 
            // label30
            // 
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(80, 247);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(75, 18);
            this.label30.TabIndex = 33;
            this.label30.Text = "延迟启动时间";
            // 
            // lngc
            // 
            this.lngc.Enabled = false;
            this.lngc.Location = new System.Drawing.Point(192, 48);
            this.lngc.Name = "lngc";
            this.lngc.Size = new System.Drawing.Size(70, 21);
            this.lngc.TabIndex = 32;
            // 
            // latc
            // 
            this.latc.Enabled = false;
            this.latc.Location = new System.Drawing.Point(192, 97);
            this.latc.Name = "latc";
            this.latc.Size = new System.Drawing.Size(70, 21);
            this.latc.TabIndex = 31;
            // 
            // startc
            // 
            this.startc.Enabled = false;
            this.startc.Location = new System.Drawing.Point(192, 195);
            this.startc.Name = "startc";
            this.startc.Size = new System.Drawing.Size(70, 21);
            this.startc.TabIndex = 30;
            // 
            // speedc
            // 
            this.speedc.Enabled = false;
            this.speedc.Location = new System.Drawing.Point(192, 146);
            this.speedc.Name = "speedc";
            this.speedc.Size = new System.Drawing.Size(70, 21);
            this.speedc.TabIndex = 29;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(268, 146);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(70, 21);
            this.speed.TabIndex = 27;
            this.speed.Text = "0";
            // 
            // lat
            // 
            this.lat.Location = new System.Drawing.Point(268, 97);
            this.lat.Name = "lat";
            this.lat.Size = new System.Drawing.Size(70, 21);
            this.lat.TabIndex = 26;
            this.lat.Text = "0";
            // 
            // lng
            // 
            this.lng.Location = new System.Drawing.Point(268, 48);
            this.lng.Name = "lng";
            this.lng.Size = new System.Drawing.Size(70, 21);
            this.lng.TabIndex = 25;
            this.lng.Text = "0";
            // 
            // label20
            // 
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(80, 149);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 18);
            this.label20.TabIndex = 23;
            this.label20.Text = "长机速度";
            // 
            // label21
            // 
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(80, 198);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 18);
            this.label21.TabIndex = 24;
            this.label21.Text = "长机启动";
            // 
            // label22
            // 
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(81, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 18);
            this.label22.TabIndex = 22;
            this.label22.Text = "长机起飞纬度";
            // 
            // label23
            // 
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(81, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 18);
            this.label23.TabIndex = 21;
            this.label23.Text = "长机起飞经度";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(92, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "编队长机参数";
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(252, 464);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 57;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(768, 464);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 55;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(687, 464);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 54;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "s";
            // 
            // start
            // 
            this.start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.start.FormattingEnabled = true;
            this.start.Items.AddRange(new object[] {
            "停止",
            "启动"});
            this.start.Location = new System.Drawing.Point(268, 195);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(70, 20);
            this.start.TabIndex = 37;
            // 
            // NAVsetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Import);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "NAVsetView";
            this.Size = new System.Drawing.Size(1009, 524);
            this.Load += new System.EventHandler(this.NAVsetView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox delaytimec;
        private System.Windows.Forms.TextBox delaytime;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox lngc;
        private System.Windows.Forms.TextBox latc;
        private System.Windows.Forms.TextBox startc;
        private System.Windows.Forms.TextBox speedc;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.TextBox lat;
        private System.Windows.Forms.TextBox lng;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.ComboBox start;
        private System.Windows.Forms.Label label2;
    }
}
