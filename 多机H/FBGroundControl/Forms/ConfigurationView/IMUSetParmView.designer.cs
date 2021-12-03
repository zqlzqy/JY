namespace FBGroundControl.Forms
{
    partial class IMUSetParmView
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
            this.label1 = new System.Windows.Forms.Label();
            this.Import = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.setup_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.maxsc = new System.Windows.Forms.TextBox();
            this.minsc = new System.Windows.Forms.TextBox();
            this.maxs = new System.Windows.Forms.TextBox();
            this.mins = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.kpsc = new System.Windows.Forms.TextBox();
            this.kisc = new System.Windows.Forms.TextBox();
            this.klsc = new System.Windows.Forms.TextBox();
            this.kdsc = new System.Windows.Forms.TextBox();
            this.kls = new System.Windows.Forms.TextBox();
            this.kds = new System.Windows.Forms.TextBox();
            this.kis = new System.Windows.Forms.TextBox();
            this.kps = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.maxpc = new System.Windows.Forms.TextBox();
            this.minpc = new System.Windows.Forms.TextBox();
            this.maxp = new System.Windows.Forms.TextBox();
            this.minp = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.kppc = new System.Windows.Forms.TextBox();
            this.kipc = new System.Windows.Forms.TextBox();
            this.klpc = new System.Windows.Forms.TextBox();
            this.kdpc = new System.Windows.Forms.TextBox();
            this.klp = new System.Windows.Forms.TextBox();
            this.kdp = new System.Windows.Forms.TextBox();
            this.kip = new System.Windows.Forms.TextBox();
            this.kpp = new System.Windows.Forms.TextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(87, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "多机控制参数";
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(185, 430);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 43;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setup_button
            // 
            this.setup_button.Location = new System.Drawing.Point(701, 430);
            this.setup_button.Name = "setup_button";
            this.setup_button.Size = new System.Drawing.Size(75, 23);
            this.setup_button.TabIndex = 41;
            this.setup_button.Text = "设置";
            this.setup_button.UseVisualStyleBackColor = true;
            this.setup_button.Click += new System.EventHandler(this.setup_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(620, 430);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 40;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.maxsc);
            this.groupBox3.Controls.Add(this.minsc);
            this.groupBox3.Controls.Add(this.maxs);
            this.groupBox3.Controls.Add(this.mins);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label138);
            this.groupBox3.Controls.Add(this.kpsc);
            this.groupBox3.Controls.Add(this.kisc);
            this.groupBox3.Controls.Add(this.klsc);
            this.groupBox3.Controls.Add(this.kdsc);
            this.groupBox3.Controls.Add(this.kls);
            this.groupBox3.Controls.Add(this.kds);
            this.groupBox3.Controls.Add(this.kis);
            this.groupBox3.Controls.Add(this.kps);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(90, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 254);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "速度";
            // 
            // maxsc
            // 
            this.maxsc.Enabled = false;
            this.maxsc.Location = new System.Drawing.Point(108, 213);
            this.maxsc.Name = "maxsc";
            this.maxsc.Size = new System.Drawing.Size(70, 21);
            this.maxsc.TabIndex = 21;
            // 
            // minsc
            // 
            this.minsc.Enabled = false;
            this.minsc.Location = new System.Drawing.Point(108, 172);
            this.minsc.Name = "minsc";
            this.minsc.Size = new System.Drawing.Size(70, 21);
            this.minsc.TabIndex = 20;
            // 
            // maxs
            // 
            this.maxs.Location = new System.Drawing.Point(184, 213);
            this.maxs.Name = "maxs";
            this.maxs.Size = new System.Drawing.Size(70, 21);
            this.maxs.TabIndex = 19;
            this.maxs.Text = "0";
            // 
            // mins
            // 
            this.mins.Location = new System.Drawing.Point(184, 172);
            this.mins.Name = "mins";
            this.mins.Size = new System.Drawing.Size(70, 21);
            this.mins.TabIndex = 18;
            this.mins.Text = "0";
            // 
            // label30
            // 
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(7, 175);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(95, 18);
            this.label30.TabIndex = 16;
            this.label30.Text = "积分限幅最小值";
            // 
            // label138
            // 
            this.label138.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label138.Location = new System.Drawing.Point(7, 216);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(95, 18);
            this.label138.TabIndex = 17;
            this.label138.Text = "积分限幅最大值";
            // 
            // kpsc
            // 
            this.kpsc.Enabled = false;
            this.kpsc.Location = new System.Drawing.Point(108, 18);
            this.kpsc.Name = "kpsc";
            this.kpsc.Size = new System.Drawing.Size(70, 21);
            this.kpsc.TabIndex = 15;
            // 
            // kisc
            // 
            this.kisc.Enabled = false;
            this.kisc.Location = new System.Drawing.Point(108, 53);
            this.kisc.Name = "kisc";
            this.kisc.Size = new System.Drawing.Size(70, 21);
            this.kisc.TabIndex = 14;
            // 
            // klsc
            // 
            this.klsc.Enabled = false;
            this.klsc.Location = new System.Drawing.Point(108, 132);
            this.klsc.Name = "klsc";
            this.klsc.Size = new System.Drawing.Size(70, 21);
            this.klsc.TabIndex = 13;
            // 
            // kdsc
            // 
            this.kdsc.Enabled = false;
            this.kdsc.Location = new System.Drawing.Point(108, 91);
            this.kdsc.Name = "kdsc";
            this.kdsc.Size = new System.Drawing.Size(70, 21);
            this.kdsc.TabIndex = 12;
            // 
            // kls
            // 
            this.kls.Location = new System.Drawing.Point(184, 132);
            this.kls.Name = "kls";
            this.kls.Size = new System.Drawing.Size(70, 21);
            this.kls.TabIndex = 11;
            this.kls.Text = "0";
            // 
            // kds
            // 
            this.kds.Location = new System.Drawing.Point(184, 91);
            this.kds.Name = "kds";
            this.kds.Size = new System.Drawing.Size(70, 21);
            this.kds.TabIndex = 10;
            this.kds.Text = "0";
            // 
            // kis
            // 
            this.kis.Location = new System.Drawing.Point(184, 53);
            this.kis.Name = "kis";
            this.kis.Size = new System.Drawing.Size(70, 21);
            this.kis.TabIndex = 9;
            this.kis.Text = "0";
            // 
            // kps
            // 
            this.kps.Location = new System.Drawing.Point(184, 18);
            this.kps.Name = "kps";
            this.kps.Size = new System.Drawing.Size(70, 21);
            this.kps.TabIndex = 8;
            this.kps.Text = "0";
            // 
            // label20
            // 
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(31, 94);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 18);
            this.label20.TabIndex = 4;
            this.label20.Text = "KD";
            // 
            // label21
            // 
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(31, 135);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 18);
            this.label21.TabIndex = 6;
            this.label21.Text = "KL";
            // 
            // label22
            // 
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(31, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 10);
            this.label22.TabIndex = 2;
            this.label22.Text = "KI";
            // 
            // label23
            // 
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(31, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "KP";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.maxpc);
            this.groupBox5.Controls.Add(this.kppc);
            this.groupBox5.Controls.Add(this.kipc);
            this.groupBox5.Controls.Add(this.minpc);
            this.groupBox5.Controls.Add(this.klpc);
            this.groupBox5.Controls.Add(this.kdpc);
            this.groupBox5.Controls.Add(this.maxp);
            this.groupBox5.Controls.Add(this.klp);
            this.groupBox5.Controls.Add(this.kdp);
            this.groupBox5.Controls.Add(this.minp);
            this.groupBox5.Controls.Add(this.kip);
            this.groupBox5.Controls.Add(this.kpp);
            this.groupBox5.Controls.Add(this.label139);
            this.groupBox5.Controls.Add(this.label141);
            this.groupBox5.Controls.Add(this.label140);
            this.groupBox5.Controls.Add(this.label142);
            this.groupBox5.Controls.Add(this.label143);
            this.groupBox5.Controls.Add(this.label144);
            this.groupBox5.Location = new System.Drawing.Point(428, 76);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 254);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "位置";
            // 
            // maxpc
            // 
            this.maxpc.Enabled = false;
            this.maxpc.Location = new System.Drawing.Point(102, 213);
            this.maxpc.Name = "maxpc";
            this.maxpc.Size = new System.Drawing.Size(70, 21);
            this.maxpc.TabIndex = 21;
            // 
            // minpc
            // 
            this.minpc.Enabled = false;
            this.minpc.Location = new System.Drawing.Point(102, 172);
            this.minpc.Name = "minpc";
            this.minpc.Size = new System.Drawing.Size(70, 21);
            this.minpc.TabIndex = 20;
            // 
            // maxp
            // 
            this.maxp.Location = new System.Drawing.Point(178, 213);
            this.maxp.Name = "maxp";
            this.maxp.Size = new System.Drawing.Size(70, 21);
            this.maxp.TabIndex = 19;
            this.maxp.Text = "0";
            // 
            // minp
            // 
            this.minp.Location = new System.Drawing.Point(178, 172);
            this.minp.Name = "minp";
            this.minp.Size = new System.Drawing.Size(70, 21);
            this.minp.TabIndex = 18;
            this.minp.Text = "0";
            // 
            // label139
            // 
            this.label139.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label139.Location = new System.Drawing.Point(6, 175);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(90, 18);
            this.label139.TabIndex = 16;
            this.label139.Text = "速度指令最小值";
            // 
            // label140
            // 
            this.label140.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label140.Location = new System.Drawing.Point(6, 216);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(90, 18);
            this.label140.TabIndex = 17;
            this.label140.Text = "速度指令最大值";
            // 
            // kppc
            // 
            this.kppc.Enabled = false;
            this.kppc.Location = new System.Drawing.Point(103, 18);
            this.kppc.Name = "kppc";
            this.kppc.Size = new System.Drawing.Size(70, 21);
            this.kppc.TabIndex = 15;
            // 
            // kipc
            // 
            this.kipc.Enabled = false;
            this.kipc.Location = new System.Drawing.Point(103, 53);
            this.kipc.Name = "kipc";
            this.kipc.Size = new System.Drawing.Size(70, 21);
            this.kipc.TabIndex = 14;
            // 
            // klpc
            // 
            this.klpc.Enabled = false;
            this.klpc.Location = new System.Drawing.Point(103, 132);
            this.klpc.Name = "klpc";
            this.klpc.Size = new System.Drawing.Size(70, 21);
            this.klpc.TabIndex = 13;
            // 
            // kdpc
            // 
            this.kdpc.Enabled = false;
            this.kdpc.Location = new System.Drawing.Point(103, 91);
            this.kdpc.Name = "kdpc";
            this.kdpc.Size = new System.Drawing.Size(70, 21);
            this.kdpc.TabIndex = 12;
            // 
            // klp
            // 
            this.klp.Location = new System.Drawing.Point(179, 132);
            this.klp.Name = "klp";
            this.klp.Size = new System.Drawing.Size(70, 21);
            this.klp.TabIndex = 11;
            this.klp.Text = "0";
            // 
            // kdp
            // 
            this.kdp.Location = new System.Drawing.Point(179, 91);
            this.kdp.Name = "kdp";
            this.kdp.Size = new System.Drawing.Size(70, 21);
            this.kdp.TabIndex = 10;
            this.kdp.Text = "0";
            // 
            // kip
            // 
            this.kip.Location = new System.Drawing.Point(179, 53);
            this.kip.Name = "kip";
            this.kip.Size = new System.Drawing.Size(70, 21);
            this.kip.TabIndex = 9;
            this.kip.Text = "0";
            // 
            // kpp
            // 
            this.kpp.BackColor = System.Drawing.Color.White;
            this.kpp.Location = new System.Drawing.Point(179, 18);
            this.kpp.Name = "kpp";
            this.kpp.Size = new System.Drawing.Size(70, 21);
            this.kpp.TabIndex = 8;
            this.kpp.Text = "0";
            // 
            // label141
            // 
            this.label141.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label141.Location = new System.Drawing.Point(32, 94);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(28, 18);
            this.label141.TabIndex = 4;
            this.label141.Text = "KD";
            // 
            // label142
            // 
            this.label142.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label142.Location = new System.Drawing.Point(32, 135);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(26, 18);
            this.label142.TabIndex = 6;
            this.label142.Text = "KL";
            // 
            // label143
            // 
            this.label143.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label143.Location = new System.Drawing.Point(32, 57);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(25, 10);
            this.label143.TabIndex = 2;
            this.label143.Text = "KI";
            // 
            // label144
            // 
            this.label144.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label144.Location = new System.Drawing.Point(32, 26);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(27, 13);
            this.label144.TabIndex = 0;
            this.label144.Text = "KP";
            // 
            // IMUSetParmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setup_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.label1);
            this.Name = "IMUSetParmView";
            this.Size = new System.Drawing.Size(1009, 471);
            this.Load += new System.EventHandler(this.IMUSetParmView_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setup_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox maxsc;
        private System.Windows.Forms.TextBox minsc;
        private System.Windows.Forms.TextBox maxs;
        private System.Windows.Forms.TextBox mins;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.TextBox kpsc;
        private System.Windows.Forms.TextBox kisc;
        private System.Windows.Forms.TextBox klsc;
        private System.Windows.Forms.TextBox kdsc;
        private System.Windows.Forms.TextBox kls;
        private System.Windows.Forms.TextBox kds;
        private System.Windows.Forms.TextBox kis;
        private System.Windows.Forms.TextBox kps;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox maxpc;
        private System.Windows.Forms.TextBox minpc;
        private System.Windows.Forms.TextBox maxp;
        private System.Windows.Forms.TextBox minp;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.TextBox kppc;
        private System.Windows.Forms.TextBox kipc;
        private System.Windows.Forms.TextBox klpc;
        private System.Windows.Forms.TextBox kdpc;
        private System.Windows.Forms.TextBox klp;
        private System.Windows.Forms.TextBox kdp;
        private System.Windows.Forms.TextBox kip;
        private System.Windows.Forms.TextBox kpp;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.Label label144;
    }
}
