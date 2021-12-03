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
    public partial class GuihangMode : Form
    {
        JYLinkInterface port = MainForm.comPort;
        private JYLink.jylink_gmode_param_down attitudeloopParam = new JYLink.jylink_gmode_param_down();
        public GuihangMode()
        {
            InitializeComponent();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {

                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
                //弹框显示Please Connect First
            }
            attitudeloopParam = port.searchGmode();
            mode.Text = attitudeloopParam.mode.ToString();
            count.Text = attitudeloopParam.count.ToString();
            lossmode.Text = attitudeloopParam.lossmode.ToString();
         
        }

        private void setup_button_Click(object sender, EventArgs e)
        {
            bool checkresult = true;
            byte check;
            if (!byte.TryParse(this.mode_textBox.Text, out check))
            {
                this.mode_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }
            else
            {
                this.mode_textBox.ForeColor = Color.Black;

            }//偏航
            if (!byte.TryParse(this.count_textBox.Text, out check))
            {
                this.count_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }
            else
            {
                this.count_textBox.ForeColor = Color.Black;

            }//偏航

            if (!byte.TryParse(this.loss_textbox.Text, out check))
            {
                this.loss_textbox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }
            else
            {
                this.loss_textbox.ForeColor = Color.Black;

            }//偏航

     

            if (checkresult == false)
            {
                return;
            }
            Properties.Settings.Default.mode = mode_textBox.Text;
            Properties.Settings.Default.count = count_textBox.Text;
            Properties.Settings.Default.lossmode = loss_textbox.Text;
           
            //偏航
            Properties.Settings.Default.Save();
            JYLink.jylink_gmode_param_setup attitudeparam = new JYLink.jylink_gmode_param_setup();
            attitudeparam.mode = Byte.Parse(mode_textBox.Text);
            attitudeparam.count = Byte.Parse(count_textBox.Text);
            attitudeparam.lossmode = Byte.Parse(loss_textbox.Text);
            attitudeparam.paosan = 0;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupGmode(attitudeparam);
            // 判断执行结果
            if (result)
            {
                MessageBox.Show("参数设置成功");
            }
            else
            {
                MessageBox.Show("参数设置失败");
            }
        }

        private void GuihangMode_Load(object sender, EventArgs e)
        {
            mode_textBox.Text = Properties.Settings.Default.mode;
            count_textBox.Text = Properties.Settings.Default.count;
            loss_textbox.Text = Properties.Settings.Default.lossmode;
            
        }
    }
}
