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
    public partial class duojiset : Form
    {
        JYLinkInterface port = MainForm.comPort;
        JYLink.jylink_duoji_param_setup duoji = new JYLink.jylink_duoji_param_setup();
        public JYLink.jylink_steertrim_param_down steertrimParam = new JYLink.jylink_steertrim_param_down();
        public duojiset()
        {
            InitializeComponent();
        }
        private void update()
        {
            //查询参数的值并写入第一个文本框中
            LeftAileron_trim_textBox.Text = steertrimParam.LeftAileron.ToString();
            LeftAileronRatio_trim_textBox.Text = steertrimParam.LeftAileronRatio.ToString();
            RightAileron_trim_textBox.Text = steertrimParam.RightAileron.ToString();
            RightAileronRatio_trim_textBox.Text = steertrimParam.RightAileronRatio.ToString();
            LeftTail_trim_textBox.Text = steertrimParam.LeftTail.ToString();
            LeftTailRatio_trim_textBox.Text = steertrimParam.LeftTailRatio.ToString();
            RightTail_trim_textBox.Text = steertrimParam.RightTail.ToString();
            RightTailRatio_trim_textBox.Text = steertrimParam.RightTailRatio.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            duoji.status = 0x55;
            
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupDuoji(duoji);
            // 判断执行结果
            if (result)
            {
                MessageBox.Show("舵机中位锁定成功");
            }
            else
            {
                MessageBox.Show("舵机中位锁定失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            duoji.status = 0xAA;

            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupDuoji(duoji);
            // 判断执行结果
            if (result)
            {
                MessageBox.Show("舵机中位解除成功");
            }
            else
            {
                MessageBox.Show("舵机中位解除失败");
            }
        }

        private void duojiset_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            LeftAileron_textBox.Text = Properties.Settings.Default.LeftAileron;
            LeftAileronRatio_textBox.Text = Properties.Settings.Default.LeftAileronRatio;
            LeftTail_textBox.Text = Properties.Settings.Default.LeftTail;
            LeftTailRatio_textBox.Text = Properties.Settings.Default.LeftTailRatio;
            RightAileron_textBox.Text = Properties.Settings.Default.RightAileron;
            RightAileronRatio_textBox.Text = Properties.Settings.Default.RightAileronRatio;
            RightTail_textBox.Text = Properties.Settings.Default.RightTail;
            RightTailRatio_textBox.Text = Properties.Settings.Default.RightTailRatio;
        }
        public static bool sendCommand(JYLinkInterface port, JYLink.jylink_steertrim_param_setup steertrimparam)
        {
            bool result = port.setupSteerTrim(steertrimparam);
            return result;
        }
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LeftAileron = LeftAileron_textBox.Text;
            Properties.Settings.Default.LeftAileronRatio = LeftAileronRatio_textBox.Text;
            Properties.Settings.Default.RightAileron = RightAileron_textBox.Text;
            Properties.Settings.Default.RightAileronRatio = RightAileronRatio_textBox.Text;
            Properties.Settings.Default.LeftTail = LeftTail_textBox.Text;
            Properties.Settings.Default.LeftTailRatio = LeftTailRatio_textBox.Text;
            Properties.Settings.Default.RightTail = RightTail_textBox.Text;
            Properties.Settings.Default.RightTailRatio = RightTailRatio_textBox.Text;
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据

            //检验参数数据类型是否合法
            Int16 check;
            Single check_trans;
            bool checkresult = true;
            if (!Int16.TryParse(this.LeftAileron_textBox.Text, out check))
            {
                this.LeftAileron_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.LeftAileron_textBox.ForeColor = Color.Black;
            }
            if (!Single.TryParse(this.LeftAileron_textBox.Text, out check_trans))
            {
                this.LeftAileronRatio_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.LeftAileronRatio_textBox.ForeColor = Color.Black;
            }
            if (!Int16.TryParse(this.LeftTail_textBox.Text, out check))
            {
                this.LeftTail_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.LeftTail_textBox.ForeColor = Color.Black;
            }
            if (!Single.TryParse(this.LeftTail_textBox.Text, out check_trans))
            {
                this.LeftTailRatio_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.LeftTailRatio_textBox.ForeColor = Color.Black;
            }

            if (!Int16.TryParse(this.RightAileron_textBox.Text, out check))
            {
                this.RightAileron_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.RightAileron_textBox.ForeColor = Color.Black;
            }
            if (!Single.TryParse(this.RightAileron_textBox.Text, out check_trans))
            {
                this.RightAileronRatio_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.RightAileronRatio_textBox.ForeColor = Color.Black;
            }
            if (!Int16.TryParse(this.RightTail_textBox.Text, out check))
            {
                this.RightTail_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.RightTail_textBox.ForeColor = Color.Black;
            }
            if (!Single.TryParse(this.RightTail_textBox.Text, out check_trans))
            {
                this.RightTailRatio_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.RightTailRatio_textBox.ForeColor = Color.Black;
            }

            if (checkresult == false)
            {
                return;
            }
            //TODO 校验参数输入框输入是否合法
            JYLink.jylink_steertrim_param_setup steertrimparam = new JYLink.jylink_steertrim_param_setup();
            steertrimparam.LeftAileron = Int16.Parse(LeftAileron_textBox.Text);
            steertrimparam.LeftAileronRatio = Single.Parse(LeftAileronRatio_textBox.Text);
            steertrimparam.RightAileron = Int16.Parse(RightAileron_textBox.Text);
            steertrimparam.RightAileronRatio = Single.Parse(RightAileronRatio_textBox.Text);
            steertrimparam.LeftTail = Int16.Parse(LeftTail_textBox.Text);
            steertrimparam.LeftTailRatio = Single.Parse(LeftTailRatio_textBox.Text);
            steertrimparam.RightTail = Int16.Parse(RightTail_textBox.Text);
            steertrimparam.RightTailRatio = Single.Parse(RightTailRatio_textBox.Text);
            //JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            bool result = false; 
            result = port.setupSteerTrim(steertrimparam);

            if (result)
            {
                MessageBox.Show("舵面配平参数设置成功");
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示请先连接！
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            steertrimParam = port.searchSteerTrim();
            update();
        }
    }
}
