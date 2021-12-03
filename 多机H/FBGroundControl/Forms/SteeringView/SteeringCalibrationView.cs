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
 
    public partial class SteeringCalibrationView : UserControl
    {

        private static int steerNum = 0;

        public JYLink.jylink_steer_cac_param_down steerCacParam = new JYLink.jylink_steer_cac_param_down();
        public SteeringCalibrationView()
        {
            steerNum = 0;
            InitializeComponent();
          
        }


        private void add_button_Click(object sender, EventArgs e)
        {
            steerNum++;
            if (steerNum.Equals( 1 ))
            {
                this.groupBox2.Visible = true;
            }
            else if (steerNum.Equals(2))
            {
                this.groupBox3.Visible = true;
            }
            else if (steerNum.Equals(3))
            {
                this.groupBox4.Visible = true;
            }
            else if (steerNum.Equals(4))
            {
                this.groupBox5.Visible = true;
            }
            else if (steerNum.Equals(5))
            {
                this.groupBox6.Visible = true;
            }
            else if (steerNum.Equals(6))
            {
                this.groupBox7.Visible = true;
            }
            else if (steerNum.Equals(7))
            {
                this.groupBox8.Visible = true;
            }
            else if (steerNum.Equals(8))
            {
                steerNum = 7;
                MessageBox.Show("已达到最多通道");
            }

        }

        private void dec_button_Click(object sender, EventArgs e)
        {
            steerNum--;
            if (steerNum.Equals(-1))
            {
                steerNum = 0;
                MessageBox.Show("最少需1通道");
            }
            else if (steerNum.Equals(0))
            {
                this.groupBox2.Visible = false; 
            }
            else if (steerNum.Equals(1))
            {
                this.groupBox3.Visible = false; 
            }
            else if (steerNum.Equals(2))
            {
                this.groupBox4.Visible = false; 
            }
            else if (steerNum.Equals(3))
            {
                this.groupBox5.Visible = false; 
            }
            else if (steerNum.Equals(4))
            {
                this.groupBox6.Visible = false; 
            }
            else if (steerNum.Equals(5))
            {
                this.groupBox7.Visible = false; 
            }
            else if (steerNum.Equals(6))
            {
                this.groupBox8.Visible = false; 
            }
        }

        private void clc_button_Click(object sender, EventArgs e)
        {
            steerNum = 0;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = false;
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;
            this.groupBox7.Visible = false;
            this.groupBox8.Visible = false;
        }

        private void cal_button_Click(object sender, EventArgs e)
        {

            JYLink.jylink_steer_cac_setup steerCac = new JYLink.jylink_steer_cac_setup();
            steerCac.channel_num = (byte)(steerNum+1);
            steerCac.channel1_name = (byte)steer_comboBox1.SelectedIndex;
            steerCac.channel1_addr = (byte)steer_addr_comboBox1.SelectedIndex;
            steerCac.channel2_name = (byte)steer_comboBox2.SelectedIndex;
            steerCac.channel2_addr = (byte)steer_addr_comboBox2.SelectedIndex;
            steerCac.channel3_name = (byte)steer_comboBox3.SelectedIndex;
            steerCac.channel3_addr = (byte)steer_addr_comboBox3.SelectedIndex;
            steerCac.channel4_name = (byte)steer_comboBox4.SelectedIndex;
            steerCac.channel4_addr = (byte)steer_addr_comboBox4.SelectedIndex;
            steerCac.channel5_name = (byte)steer_comboBox5.SelectedIndex;
            steerCac.channel5_addr = (byte)steer_addr_comboBox5.SelectedIndex;
            steerCac.channel6_name = (byte)steer_comboBox6.SelectedIndex;
            steerCac.channel6_addr = (byte)steer_addr_comboBox6.SelectedIndex;
            steerCac.channel7_name = (byte)steer_comboBox7.SelectedIndex;
            steerCac.channel7_addr = (byte)steer_addr_comboBox7.SelectedIndex;
            steerCac.channel8_name = (byte)steer_comboBox8.SelectedIndex;
            steerCac.channel8_addr = (byte)steer_addr_comboBox8.SelectedIndex;


            //JYLinkTeleCtrl port = MainForm.telecontrol_comPort;

            //if (!port.BaseStream.IsOpen)
            //{
            //    MessageBox.Show("Please Connect First!");
            //    return;
            //    throw new Exception("Please Connect First!");
            //}

            //bool result = port.setupSteerCac(steerCac); 
        }

        private void query_button_Click(object sender, EventArgs e)
        {

            //JYLinkTeleCtrl port = MainForm.telecontrol_comPort;
            ////判断是否连接
            //if (!port.BaseStream.IsOpen)
            //{
            //    MessageBox.Show("Please Connect First!");
            //    return;
            //    throw new Exception("Please Connect First!");
            //    //弹框显示Please Connect First
            //}
            //steerCacParam = port.searchSteerCac();
            //if (MainForm.instance.isSendSuccess)
            //{
            //    update();
            //}
            //else
            //{
            //    MessageBox.Show("查询舵机参数失败!");
            //}
            
        }

        private void update()
        {
            steerNum = steerCacParam.channel_num-1;
           
            if( steerNum.Equals(0))
            {
                this.groupBox1.Visible = true; 
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
            }
            else if (steerNum.Equals(1))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
            }
            else if (steerNum.Equals(2))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
            }
            else if (steerNum.Equals(3))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
                this.groupBox4.Visible = true;
                steer_comboBox4.SelectedIndex = steerCacParam.channel4_name;
                steer_addr_comboBox4.SelectedIndex = steerCacParam.channel4_addr;
            }
            else if (steerNum.Equals(4))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
                this.groupBox4.Visible = true;
                steer_comboBox4.SelectedIndex = steerCacParam.channel4_name;
                steer_addr_comboBox4.SelectedIndex = steerCacParam.channel4_addr;
                this.groupBox5.Visible = true;
                steer_comboBox5.SelectedIndex = steerCacParam.channel5_name;
                steer_addr_comboBox5.SelectedIndex = steerCacParam.channel5_addr;
            }
            else if (steerNum.Equals(5))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
                this.groupBox4.Visible = true;
                steer_comboBox4.SelectedIndex = steerCacParam.channel4_name;
                steer_addr_comboBox4.SelectedIndex = steerCacParam.channel4_addr;
                this.groupBox5.Visible = true;
                steer_comboBox5.SelectedIndex = steerCacParam.channel5_name;
                steer_addr_comboBox5.SelectedIndex = steerCacParam.channel5_addr;
                this.groupBox6.Visible = true;
                steer_comboBox6.SelectedIndex = steerCacParam.channel6_name;
                steer_addr_comboBox6.SelectedIndex = steerCacParam.channel6_addr;
            }
            else if (steerNum.Equals(6))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
                this.groupBox4.Visible = true;
                steer_comboBox4.SelectedIndex = steerCacParam.channel4_name;
                steer_addr_comboBox4.SelectedIndex = steerCacParam.channel4_addr;
                this.groupBox5.Visible = true;
                steer_comboBox5.SelectedIndex = steerCacParam.channel5_name;
                steer_addr_comboBox5.SelectedIndex = steerCacParam.channel5_addr;
                this.groupBox6.Visible = true;
                steer_comboBox6.SelectedIndex = steerCacParam.channel6_name;
                steer_addr_comboBox6.SelectedIndex = steerCacParam.channel6_addr;
                this.groupBox7.Visible = true;
                steer_comboBox7.SelectedIndex = steerCacParam.channel7_name;
                steer_addr_comboBox7.SelectedIndex = steerCacParam.channel7_addr;
            }
            else if (steerNum.Equals(7))
            {
                this.groupBox1.Visible = true;
                steer_comboBox1.SelectedIndex = steerCacParam.channel1_name;
                steer_addr_comboBox1.SelectedIndex = steerCacParam.channel1_addr;
                this.groupBox2.Visible = true;
                steer_comboBox2.SelectedIndex = steerCacParam.channel2_name;
                steer_addr_comboBox2.SelectedIndex = steerCacParam.channel2_addr;
                this.groupBox3.Visible = true;
                steer_comboBox3.SelectedIndex = steerCacParam.channel3_name;
                steer_addr_comboBox3.SelectedIndex = steerCacParam.channel3_addr;
                this.groupBox4.Visible = true;
                steer_comboBox4.SelectedIndex = steerCacParam.channel4_name;
                steer_addr_comboBox4.SelectedIndex = steerCacParam.channel4_addr;
                this.groupBox5.Visible = true;
                steer_comboBox5.SelectedIndex = steerCacParam.channel5_name;
                steer_addr_comboBox5.SelectedIndex = steerCacParam.channel5_addr;
                this.groupBox6.Visible = true;
                steer_comboBox6.SelectedIndex = steerCacParam.channel6_name;
                steer_addr_comboBox6.SelectedIndex = steerCacParam.channel6_addr;
                this.groupBox8.Visible = true;
                steer_comboBox8.SelectedIndex = steerCacParam.channel8_name;
                steer_addr_comboBox8.SelectedIndex = steerCacParam.channel8_addr;
            }

        }

       public List<KeyValuePair<int,string>> getSteerList(  )
        {
            var temp = new List<KeyValuePair<int, string>>()
           {
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.左副翼, "左副翼"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.右副翼, "右副翼"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.左升降, "左升降"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.右升降, "右升降"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.左襟翼, "左襟翼"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.右襟翼, "右襟翼"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.油门, "油门"),
               new KeyValuePair<int, string>((int)JYLink.JY_STEERING_ID.方向, "方向"),
           };
            
           return temp;
        }

       public List<KeyValuePair<int, string>> getPwmList()
       {
           var temp = new List<KeyValuePair<int, string>>()
           {
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM1, "PWM1"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM2, "PWM2"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM3, "PWM3"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM4, "PWM4"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM5, "PWM5"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM6, "PWM6"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM7, "PWM7"),
               new KeyValuePair<int, string>((int)JYLink.JY_PWM_ID.PWM8, "PWM8"),
           };

           return temp;
       }

    }
}