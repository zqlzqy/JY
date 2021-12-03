﻿namespace FBGroundControl.Forms
{
    partial class CommandsFrm
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
          
            //base.Dispose(disposing);
            if (MainForm.isExitSystem)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else
            {
                IsHidden = true;
            }
           
        }

        #region Windows Form Designer generated code



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.manual_btn = new System.Windows.Forms.Button();
            this.stabilize_btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.alt_hold_btn = new System.Windows.Forms.Button();
            this.loiter_btn = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.longitudinal_btn = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.bindingSourceQuickTab = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).BeginInit();
            this.SuspendLayout();
            // 
            // manual_btn
            // 
            this.manual_btn.Font = new System.Drawing.Font("宋体", 12F);
            this.manual_btn.Location = new System.Drawing.Point(288, 49);
            this.manual_btn.Name = "manual_btn";
            this.manual_btn.Size = new System.Drawing.Size(77, 40);
            this.manual_btn.TabIndex = 12;
            this.manual_btn.Text = "程控";
            this.manual_btn.UseVisualStyleBackColor = true;
            this.manual_btn.Click += new System.EventHandler(this.manual_btn_Click);
            // 
            // stabilize_btn
            // 
            this.stabilize_btn.Font = new System.Drawing.Font("宋体", 12F);
            this.stabilize_btn.Location = new System.Drawing.Point(288, 233);
            this.stabilize_btn.Name = "stabilize_btn";
            this.stabilize_btn.Size = new System.Drawing.Size(77, 40);
            this.stabilize_btn.TabIndex = 13;
            this.stabilize_btn.Text = "巡航";
            this.stabilize_btn.UseVisualStyleBackColor = true;
            this.stabilize_btn.Click += new System.EventHandler(this.stabilize_btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 367);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button25);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.button19);
            this.tabPage1.Controls.Add(this.button17);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button13);
            this.tabPage1.Controls.Add(this.button24);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button22);
            this.tabPage1.Controls.Add(this.button20);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button14);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.alt_hold_btn);
            this.tabPage1.Controls.Add(this.loiter_btn);
            this.tabPage1.Controls.Add(this.button18);
            this.tabPage1.Controls.Add(this.button21);
            this.tabPage1.Controls.Add(this.button23);
            this.tabPage1.Controls.Add(this.button16);
            this.tabPage1.Controls.Add(this.button28);
            this.tabPage1.Controls.Add(this.longitudinal_btn);
            this.tabPage1.Controls.Add(this.button27);
            this.tabPage1.Controls.Add(this.button26);
            this.tabPage1.Controls.Add(this.stabilize_btn);
            this.tabPage1.Controls.Add(this.manual_btn);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(880, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主控指令";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(75, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "ID:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 18F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "255",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox1.Location = new System.Drawing.Point(166, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 32);
            this.comboBox1.TabIndex = 37;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F);
            this.button3.Location = new System.Drawing.Point(288, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 40);
            this.button3.TabIndex = 34;
            this.button3.Text = "下纠";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("宋体", 12F);
            this.button25.Location = new System.Drawing.Point(532, 95);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(77, 40);
            this.button25.TabIndex = 33;
            this.button25.Text = "降高1";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("宋体", 12F);
            this.button11.Location = new System.Drawing.Point(410, 95);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(77, 40);
            this.button11.TabIndex = 33;
            this.button11.Text = "上纠";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("宋体", 12F);
            this.button19.Location = new System.Drawing.Point(776, 141);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(77, 40);
            this.button19.TabIndex = 32;
            this.button19.Text = "抛伞";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("宋体", 12F);
            this.button17.Location = new System.Drawing.Point(654, 187);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(77, 40);
            this.button17.TabIndex = 32;
            this.button17.Text = "开伞";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("宋体", 12F);
            this.button10.Location = new System.Drawing.Point(776, 187);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(77, 40);
            this.button10.TabIndex = 32;
            this.button10.Text = "急停";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("宋体", 12F);
            this.button9.Location = new System.Drawing.Point(44, 95);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(77, 40);
            this.button9.TabIndex = 31;
            this.button9.Text = "左纠";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 12F);
            this.button8.Location = new System.Drawing.Point(166, 95);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(77, 40);
            this.button8.TabIndex = 30;
            this.button8.Text = "右纠";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("宋体", 12F);
            this.button13.Location = new System.Drawing.Point(288, 141);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(77, 40);
            this.button13.TabIndex = 29;
            this.button13.Text = "下舵";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("宋体", 12F);
            this.button24.Location = new System.Drawing.Point(532, 141);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(77, 40);
            this.button24.TabIndex = 28;
            this.button24.Text = "降高2";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 12F);
            this.button7.Location = new System.Drawing.Point(44, 141);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 40);
            this.button7.TabIndex = 29;
            this.button7.Text = "左舵";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("宋体", 12F);
            this.button12.Location = new System.Drawing.Point(410, 141);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(77, 40);
            this.button12.TabIndex = 28;
            this.button12.Text = "上舵";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 12F);
            this.button6.Location = new System.Drawing.Point(166, 141);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 40);
            this.button6.TabIndex = 28;
            this.button6.Text = "右舵";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("宋体", 12F);
            this.button15.Location = new System.Drawing.Point(288, 187);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(77, 40);
            this.button15.TabIndex = 27;
            this.button15.Text = "俯冲";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 12F);
            this.button4.Location = new System.Drawing.Point(44, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 40);
            this.button4.TabIndex = 27;
            this.button4.Text = "左盘";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("宋体", 12F);
            this.button22.Location = new System.Drawing.Point(532, 187);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(77, 40);
            this.button22.TabIndex = 25;
            this.button22.Text = "升高";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("宋体", 12F);
            this.button20.Location = new System.Drawing.Point(532, 49);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(77, 40);
            this.button20.TabIndex = 25;
            this.button20.Text = "归航";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(410, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "平飞";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("宋体", 12F);
            this.button14.Location = new System.Drawing.Point(410, 187);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(77, 40);
            this.button14.TabIndex = 24;
            this.button14.Text = "爬升";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(166, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "右盘";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // alt_hold_btn
            // 
            this.alt_hold_btn.Font = new System.Drawing.Font("宋体", 12F);
            this.alt_hold_btn.Location = new System.Drawing.Point(532, 233);
            this.alt_hold_btn.Name = "alt_hold_btn";
            this.alt_hold_btn.Size = new System.Drawing.Size(77, 40);
            this.alt_hold_btn.TabIndex = 23;
            this.alt_hold_btn.Text = "满车";
            this.alt_hold_btn.UseVisualStyleBackColor = true;
            this.alt_hold_btn.Click += new System.EventHandler(this.alt_hold_btn_Click);
            // 
            // loiter_btn
            // 
            this.loiter_btn.Font = new System.Drawing.Font("宋体", 12F);
            this.loiter_btn.Location = new System.Drawing.Point(410, 233);
            this.loiter_btn.Name = "loiter_btn";
            this.loiter_btn.Size = new System.Drawing.Size(77, 40);
            this.loiter_btn.TabIndex = 22;
            this.loiter_btn.Text = "大车";
            this.loiter_btn.UseVisualStyleBackColor = true;
            this.loiter_btn.Click += new System.EventHandler(this.loiter_btn_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("宋体", 12F);
            this.button18.Location = new System.Drawing.Point(654, 141);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(77, 40);
            this.button18.TabIndex = 21;
            this.button18.Text = "气囊";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("宋体", 12F);
            this.button21.Location = new System.Drawing.Point(776, 95);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(77, 40);
            this.button21.TabIndex = 21;
            this.button21.Text = "火工2";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("宋体", 12F);
            this.button23.Location = new System.Drawing.Point(654, 49);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(77, 40);
            this.button23.TabIndex = 21;
            this.button23.Text = "通电";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("宋体", 12F);
            this.button16.Location = new System.Drawing.Point(654, 95);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(77, 40);
            this.button16.TabIndex = 21;
            this.button16.Text = "火工1";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("宋体", 12F);
            this.button28.Location = new System.Drawing.Point(776, 233);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(77, 40);
            this.button28.TabIndex = 21;
            this.button28.Text = "停车";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // longitudinal_btn
            // 
            this.longitudinal_btn.Font = new System.Drawing.Font("宋体", 12F);
            this.longitudinal_btn.Location = new System.Drawing.Point(654, 233);
            this.longitudinal_btn.Name = "longitudinal_btn";
            this.longitudinal_btn.Size = new System.Drawing.Size(77, 40);
            this.longitudinal_btn.TabIndex = 21;
            this.longitudinal_btn.Text = "小车";
            this.longitudinal_btn.UseVisualStyleBackColor = true;
            this.longitudinal_btn.Click += new System.EventHandler(this.longitudinal_btn_Click);
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("宋体", 12F);
            this.button27.Location = new System.Drawing.Point(44, 233);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(77, 40);
            this.button27.TabIndex = 13;
            this.button27.Text = "启动";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("宋体", 12F);
            this.button26.Location = new System.Drawing.Point(166, 233);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(77, 40);
            this.button26.TabIndex = 13;
            this.button26.Text = "怠速";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button29);
            this.tabPage2.Controls.Add(this.button30);
            this.tabPage2.Controls.Add(this.button31);
            this.tabPage2.Controls.Add(this.button32);
            this.tabPage2.Controls.Add(this.button33);
            this.tabPage2.Controls.Add(this.button34);
            this.tabPage2.Controls.Add(this.button35);
            this.tabPage2.Controls.Add(this.button36);
            this.tabPage2.Controls.Add(this.button37);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(880, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "机动指令";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 12F);
            this.button5.Location = new System.Drawing.Point(325, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 40);
            this.button5.TabIndex = 44;
            this.button5.Text = "左航向180";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button29
            // 
            this.button29.Font = new System.Drawing.Font("宋体", 12F);
            this.button29.Location = new System.Drawing.Point(569, 77);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(90, 40);
            this.button29.TabIndex = 42;
            this.button29.Text = "S机动";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.Font = new System.Drawing.Font("宋体", 12F);
            this.button30.Location = new System.Drawing.Point(447, 77);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(91, 40);
            this.button30.TabIndex = 43;
            this.button30.Text = "半滚倒转";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("宋体", 12F);
            this.button31.Location = new System.Drawing.Point(81, 77);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(91, 40);
            this.button31.TabIndex = 41;
            this.button31.Text = "左盘机动";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("宋体", 12F);
            this.button32.Location = new System.Drawing.Point(203, 77);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(88, 40);
            this.button32.TabIndex = 40;
            this.button32.Text = "左航向90";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button33
            // 
            this.button33.Font = new System.Drawing.Font("宋体", 12F);
            this.button33.Location = new System.Drawing.Point(325, 170);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(94, 40);
            this.button33.TabIndex = 38;
            this.button33.Text = "右盘机动";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button34
            // 
            this.button34.Font = new System.Drawing.Font("宋体", 12F);
            this.button34.Location = new System.Drawing.Point(569, 170);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(90, 40);
            this.button34.TabIndex = 35;
            this.button34.Text = "右航向180";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button35
            // 
            this.button35.Font = new System.Drawing.Font("宋体", 12F);
            this.button35.Location = new System.Drawing.Point(81, 170);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(91, 40);
            this.button35.TabIndex = 39;
            this.button35.Text = "俯冲拉起";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button36
            // 
            this.button36.Font = new System.Drawing.Font("宋体", 12F);
            this.button36.Location = new System.Drawing.Point(447, 170);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(91, 40);
            this.button36.TabIndex = 36;
            this.button36.Text = "右航向90 ";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.Font = new System.Drawing.Font("宋体", 12F);
            this.button37.Location = new System.Drawing.Point(203, 170);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(88, 40);
            this.button37.TabIndex = 37;
            this.button37.Text = "桶滚";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // bindingSourceQuickTab
            // 
            this.bindingSourceQuickTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // CommandsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 367);
            this.Controls.Add(this.tabControl1);
            this.Name = "CommandsFrm";
            this.Text = "命令";
            this.Load += new System.EventHandler(this.CommandsFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuickTab)).EndInit();
            this.ResumeLayout(false);

        }


        


        #endregion

        private System.Windows.Forms.Button manual_btn;
        private System.Windows.Forms.Button stabilize_btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button alt_hold_btn;
        private System.Windows.Forms.Button loiter_btn;
        private System.Windows.Forms.Button longitudinal_btn;
        private System.Windows.Forms.TabPage tabPage2;
        //private System.Windows.Forms.Button takeoff;

        public System.Windows.Forms.BindingSource bindingSourceQuickTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        //private MissionPlanner.Controls.QuickView quickView57;


    }
}