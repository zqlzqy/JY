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
    /// 
    /// </summary>
    public partial class AirSpeedBAltView : UserControl
    {

        public JYLink.jylink_loiter_param_down loiterParam = new JYLink.jylink_loiter_param_down();
        public JYLink.jylink_tuoluo_param_setup tuoluo = new JYLink.jylink_tuoluo_param_setup();
        JYLinkInterface port = MainForm.comPort;
        public AirSpeedBAltView()
        {
            InitializeComponent();
          
        }

      

        private void cal_button_Click(object sender, EventArgs e)
        {
           

            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            bool result = port.calASBA();
            //if (result)
            //{
            //    MessageBox.Show("校准发送成功");
            //}
            //else
            //{
            //    MessageBox.Show("校准发送失败");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            bool result = port.setupTuoluo(tuoluo);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((CurrentState.status & 1) == 1)
            {
                TX.BackColor = Color.Green;
            }
            else
            {
                TX.BackColor = Color.Red;
            }
            if ((CurrentState.status & 2) == 2)
            {
                TY.BackColor = Color.Green;
            }
            else
            {
                TY.BackColor = Color.Red;
            }
            if ((CurrentState.status & 4) == 4)
            {
                TZ.BackColor = Color.Green;
            }
            else
            {
                TZ.BackColor = Color.Red;
            }
            if (CurrentState.acc_status == 1)
            {
                TA.BackColor = Color.Green;
            }
            else
            {
                TA.BackColor = Color.Red;
            }
            VX.Text = CurrentState.Tuo_x.ToString("N4");
            VY.Text = CurrentState.Tuo_y.ToString("N4");
            VZ.Text = CurrentState.Tuo_z.ToString("N4");
            VA.Text = CurrentState.acc_value.ToString("N4");
        }

        private void AirSpeedBAltView_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        

    }
}