using MissionPlanner;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class HightSet : Form
    {
        public JYLink.jylink_loiter_param_down loiterParam = new JYLink.jylink_loiter_param_down();
        public JYLink.jylink_tuoluo_param_setup tuoluo = new JYLink.jylink_tuoluo_param_setup();
        JYLinkInterface port = MainForm.comPort;
        public HightSet()
        {
            InitializeComponent();
        }



        private void HightSet_Load(object sender, EventArgs e)
        {

        }

        private void cal_button_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接！");
                return;
                throw new Exception("请先连接！");
            }
            bool result = port.calASBA();
        }
    }
}
