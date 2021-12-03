using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using FBGroundControl.Forms.utils;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MissionPlanner.Utilities;


namespace FBGroundControl.Forms
{
    public partial class HudView   : DockContent
    {
        public MissionPlanner.Controls.HUD hud1, hud2, hud3, hud4, hud5, hud6;  
        JYLinkInterface port = MainForm.comPort;
        //JYLink.jylink_biandui_mode_setup param = new JYLink.jylink_biandui_mode_setup();
        JYLink.jylink_bd_control_param_set bd_param_set = new JYLink.jylink_bd_control_param_set();
        JYLink.jylink_bd_control_param_down bd_param_down = new JYLink.jylink_bd_control_param_down();  
        
        public HudView()
        {
            InitializeComponent();
            this.InitializeHud();
            this.IDhud1.Controls.Add(this.hud1);
            this.IDhud2.Controls.Add(this.hud2);
            this.IDhud3.Controls.Add(this.hud3);
            this.IDhud4.Controls.Add(this.hud4); 
            this.IDhud5.Controls.Add(this.hud5); 
            this.IDhud6.Controls.Add(this.hud6); 
        }

        private void HudView_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quickView44_Load(object sender, EventArgs e)
        {

        }

        private void quickView21_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                group1.Visible = false;
                IDhud1.Visible = false;
            }
            else
            {
                group1.Visible = true;
                IDhud1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                group2.Visible = false;
                IDhud2.Visible = false;
            }
            else
            {
                group2.Visible = true;
                IDhud2.Visible = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                group3.Visible = false;
                IDhud3.Visible = false;
            }
            else
            {
                group3.Visible = true;
                IDhud3.Visible = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked)
            {
                group4.Visible = false;
                IDhud4.Visible = false;
            }
            else
            {
                group4.Visible = true;
                IDhud4.Visible = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox5.Checked)
            {
                group5.Visible = false;
                IDhud5.Visible = false;
            }
            else
            {
                group5.Visible = true;
                IDhud5.Visible = true;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox6.Checked)
            {
                group6.Visible = false;
                IDhud6.Visible = false;
            }
            else
            {
                group6.Visible = true;
                IDhud6.Visible = true;
            }
        }
        /// <summary>
        /// 进入编队功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 退出编队功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MainForm.instance.targetlabel.Text = comboBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void quickView7_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void labe1_TextChanged(object sender, EventArgs e)
        {
            if (labe1.Text == "正常运行")
            {
                labe1.BackColor = textB1.BackColor = lab1.BackColor = Color.Linen;
            }
            else
            {
                labe1.BackColor = textB1.BackColor = lab1.BackColor = Color.Red;
            }
        }

        private void labe2_TextChanged(object sender, EventArgs e)
        {
            if (labe2.Text == "正常运行")
            {
                labe2.BackColor = textB2.BackColor = lab2.BackColor = Color.Linen;
            }
            else
            {
                labe2.BackColor = textB2.BackColor = lab2.BackColor = Color.Red;
            }
        }

        private void labe3_TextChanged(object sender, EventArgs e)
        {
            if (labe3.Text == "正常运行")
            {
                labe3.BackColor = textB3.BackColor = lab3.BackColor = Color.Linen;
            }
            else
            {
                labe3.BackColor = textB3.BackColor = lab3.BackColor = Color.Red;
            }
        }

        private void labe4_TextChanged(object sender, EventArgs e)
        {
            if (labe4.Text == "正常运行")
            {
                labe4.BackColor = textB4.BackColor = lab4.BackColor = Color.Linen;
            }
            else
            {
                labe4.BackColor = textB4.BackColor = lab4.BackColor = Color.Red;
            }
        }

        private void labe5_TextChanged(object sender, EventArgs e)
        {
            if (labe5.Text == "正常运行")
            {
                labe5.BackColor = textB5.BackColor = lab5.BackColor = Color.Linen;
            }
            else
            {
                labe5.BackColor = textB5.BackColor = lab5.BackColor = Color.Red;
            }
        }

        private void labe6_TextChanged(object sender, EventArgs e)
        {
            if (labe6.Text == "正常运行")
            {
                labe6.BackColor = textB6.BackColor = lab6.BackColor = Color.Linen;
            }
            else
            {
                labe6.BackColor = textB6.BackColor = lab6.BackColor = Color.Red;
            }
        }
    }
}
