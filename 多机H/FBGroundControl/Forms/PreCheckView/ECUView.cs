using GMap.NET;
using GMap.NET.Internals;
using MissionPlanner;
using MissionPlanner.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 舵机测试
    /// </summary>
    public partial class ECUView : UserControl
    {

        public JYLink.jylink_ecu_setup ecuReturnParam = new JYLink.jylink_ecu_setup();


        public ECUView()
        {
            InitializeComponent();

            cmd_combox.DataSource = Common.getEcuDirList(MainForm.comPort.JY.cs);
            cmd_combox.ValueMember = "Key";
            cmd_combox.DisplayMember = "Value";

            //default to auto
            cmd_combox.Text = "泵";
          
        }

        private void test_button_Click(object sender, EventArgs e)
        {



            bool checkresult = true;
            int check;
           
            if (!int.TryParse(this.param_textBox.Text, out check))
            {
                this.param_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                int checkparam = Convert.ToInt32(this.param_textBox.Text);

                if (!(checkparam >= 0 && checkparam <= 1000))
                {
                    this.param_textBox.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    this.param_textBox.ForeColor = Color.Black;
                    
                }
            }
            

            if (checkresult == false)
            {
                return;
            }

            //TODO 校验参数输入框输入是否合法
            //JYLink.jylink_ecu_setup EcuParam = new JYLink.jylink_ecu_setup();
            //EcuParam.command = Byte.Parse(cmd_combox.SelectedValue.ToString());




        
            JYLink.jylink_ecu_setup ecuparam = new JYLink.jylink_ecu_setup();
            ecuparam.command = Byte.Parse(cmd_combox.SelectedValue.ToString());
            ecuparam.param = UInt16.Parse(param_textBox.Text);

          
        }

        private void cmd_combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool checkresult = true;
            float check;
            if (cmd_combox.Text == "转速")
            {
                param_textBox.ReadOnly = false;
                if (!float.TryParse(this.param_textBox.Text, out check))
                {
                    this.param_textBox.ForeColor = Color.Red;
                    checkresult = false;
                    return;
                }
                else
                {
                    this.param_textBox.ForeColor = Color.Black;
                    return;
                }
            }
            else
            {
                param_textBox.ReadOnly = true;
                param_textBox.Text = "0";
                return;
            }
        }
    }
}