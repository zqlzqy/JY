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
using MissionPlanner.Controls;

namespace FBGroundControl.Forms
{
    public partial class DaiKuan : Form
    {
        JYLinkInterface port = MainForm.comPort;
        private JYLink.jylink_bandwidth_param_down attitudeloopParam = new JYLink.jylink_bandwidth_param_down();

        public DaiKuan()
        {
            InitializeComponent();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {

                MessageBox.Show("请先连接!");
                return;
                //弹框显示Please Connect First
            }
            attitudeloopParam = port.searchBandWidth();
            fbl.Text = attitudeloopParam.fbl.ToString();
            zhouqi.Text = attitudeloopParam.zq.ToString();
        }

        private void setup_button_Click(object sender, EventArgs e)
        {
            bool checkresult = true;
            byte check;
            UInt16 check2;
            if (!byte.TryParse(this.fbl_textBox.Text, out check))
            {
                this.fbl_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }
            else
            {
                this.fbl_textBox.ForeColor = Color.Black;

            }//偏航
            if (!UInt16.TryParse(this.zhouqi_textBox.Text, out check2))
            {
                this.zhouqi_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }
            else
            {
                this.zhouqi_textBox.ForeColor = Color.Black;

            }//偏航



            if (checkresult == false)
            {
                return;
            }
            Properties.Settings.Default.fbl = fbl_textBox.Text;
            Properties.Settings.Default.zhouqi = zhouqi_textBox.Text;
            //偏航
            Properties.Settings.Default.Save();
            JYLink.jylink_bandwidth_param_setup attitudeparam = new JYLink.jylink_bandwidth_param_setup();
            attitudeparam.fbl = Byte.Parse(fbl_textBox.Text);
            attitudeparam.zq = UInt16.Parse(zhouqi_textBox.Text);
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupBandWidth(attitudeparam);
            // 判断执行结果
            if (result)
            {
                port.JYlist.Clear();
                MessageBox.Show("参数设置成功");
            }
            else
            {
                MessageBox.Show("参数设置失败");
            }
        }

        private void DaiKuan_Load(object sender, EventArgs e)
        {
            fbl_textBox.Text = Properties.Settings.Default.fbl;
            zhouqi_textBox.Text = Properties.Settings.Default.zhouqi;
        }

        private void fbl_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void DaiKuan_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DaiKuan_MinimumSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
