using MissionPlanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class IMUset : Form
    {
        public JYLink.jylink_tuoluo_param_setup tuoluo = new JYLink.jylink_tuoluo_param_setup();
        JYLinkInterface port = MainForm.comPort;
        public IMUset()
        {
            InitializeComponent();
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

        private void IMUset_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接！");
                return;
                throw new Exception("请先连接！");
            }
            bool result = port.setupTuoluo(tuoluo);
        }
    }
}
