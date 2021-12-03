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
    public partial class Route : Form
    {
        public Route()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JYLink.jylink_bianhao_setup bh = new JYLink.jylink_bianhao_setup();
            if (routes.SelectedIndex >= 0 && MainForm.comPort.BaseStream.IsOpen)
            {
                bh.status = Convert.ToByte(routes.Text);
               bool result= MainForm.comPort.setupBianhao(bh);
               if (result)
               {
                   MessageBox.Show("参数设置成功！");
               }
               else
               {
                   MessageBox.Show("参数设置失败！");
               }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JYLink.jylink_bianhao_setup bh = new JYLink.jylink_bianhao_setup();
            //判断是否连接
            if (!MainForm.comPort.BaseStream.IsOpen)
            {

                MessageBox.Show("请先连接!");
                return;            
            }
            bh = MainForm.comPort.searchBianHao();
            routec.Text = bh.status.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm.instance.hangxian_num = (byte)(routes.SelectedIndex + 1);
            MainForm.instance.btnReadNumWaypoints_ItemClick(null, null);
        }

        private void Route_Load(object sender, EventArgs e)
        {

        }
    }
}
