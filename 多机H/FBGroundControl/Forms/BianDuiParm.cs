using GMap.NET;
using GMap.NET.Internals;
using MissionPlanner;
using MissionPlanner.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FBGroundControl.Forms
{
    public partial class BianDuiParm : Form
    {
        JYLinkInterface port = MainForm.comPort;
        JYLink.jylink_bd_planeID_param_set bd_param_set = new JYLink.jylink_bd_planeID_param_set();
        JYLink.jylink_bd_planeID_param_down bd_param_down = new JYLink.jylink_bd_planeID_param_down();

        JYLink.jylink_bd_control_param_set bd_control_param_set = new JYLink.jylink_bd_control_param_set();
        JYLink.jylink_bd_control_param_down bd_control_param_down = new JYLink.jylink_bd_control_param_down();  
        public BianDuiParm() 
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "编队模式参数.txt";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                localFilePath = saveFileDialog1.FileName.ToString();
                MessageBox.Show(localFilePath);
                //弹窗显示文件路径
                if (!File.Exists(localFilePath))
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    sw.WriteLine(this.lng.Text);
                    sw.WriteLine(this.lat.Text);
                    sw.WriteLine(this.speed.Text);
                    sw.WriteLine(this.start.Text);
                    sw.WriteLine(this.delaytimeh.Text);
                    sw.WriteLine(this.delaytimem.Text);
                    sw.WriteLine(this.delaytimes.Text);
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));
                    sr.WriteLine(this.lng.Text);
                    sr.WriteLine(this.lat.Text);
                    sr.WriteLine(this.speed.Text);
                    sr.WriteLine(this.start.Text);
                    sr.WriteLine(this.delaytimeh.Text);
                    sr.WriteLine(this.delaytimem.Text);
                    sr.WriteLine(this.delaytimes.Text);
                    sr.Close();
                    fs.Close();
                }


            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //设置默认打开位置
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            localFilePath = openFileDialog1.FileName.ToString();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                localFilePath = openFileDialog1.FileName;
                //弹窗显示文件路径
                MessageBox.Show(localFilePath);
                System.IO.StreamReader st;
                st = new System.IO.StreamReader(localFilePath, System.Text.Encoding.GetEncoding("GB2312"));
                //UTF-8通用编码
                String line;
                int i = 1;
                string paramall = "";
                while ((line = st.ReadLine()) != null)
                {
                    paramall += line.ToString() + ";";
                    i++;
                }

                string[] array = paramall.Split(';');

                //this.lp_jx_t.Text = array[0];
                lng.Text = array[0];
                lat.Text = array[1];
                speed.Text = array[2];
                start.Text = array[3];
                delaytimeh.Text = array[4];
                delaytimem.Text = array[5];
                delaytimes.Text = array[6];
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示Please Connect First！
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }

            bd_param_down = port.searchBianduiStart();
            lngc.Text = bd_param_down.lng.ToString();
            latc.Text = bd_param_down.lat.ToString();
            speedc.Text = bd_param_down.speed.ToString();
            startc.Text = bd_param_down.status == 90 ? "启动" : "停止";
            delaytimehc.Text = bd_param_down.h.ToString();
            delaytimemc.Text = bd_param_down.m.ToString();
            delaytimesc.Text = bd_param_down.s.ToString();
        }

        private void setup_button_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bool checkresult = true;
            float check;
            byte time;
            if (!float.TryParse(this.lng.Text, out check))
            {
                this.lng.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.lng.BackColor = Color.White;
            }
            if (!float.TryParse(this.lat.Text, out check))
            {
                this.lat.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.lat.BackColor = Color.White;
            }
            if (!float.TryParse(this.speed.Text, out check))
            {
                this.speed.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.speed.BackColor = Color.White;
            }
            if (!byte.TryParse(delaytimeh.Text,out time))
            {
                this.delaytimeh.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                if (time<24)
                {
                    this.delaytimeh.BackColor = Color.White;
                }
                else
                {
                    this.delaytimeh.BackColor = Color.Red;
                    checkresult = false;
                }
            }
            if (!byte.TryParse(delaytimem.Text, out time))
            {
                this.delaytimem.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                if (time < 60)
                {
                    this.delaytimem.BackColor = Color.White;
                }
                else
                {
                    this.delaytimem.BackColor = Color.Red;
                    checkresult = false;
                }
            }
            if (!byte.TryParse(delaytimes.Text, out time))
            {
                this.delaytimes.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                if (time < 60)
                {
                    this.delaytimes.BackColor = Color.White;
                }
                else
                {
                    this.delaytimes.BackColor = Color.Red;
                    checkresult = false;
                }
            }
            if (start.SelectedIndex==-1)
            {
                MessageBox.Show("请选择是否长机启动！");
                return;
            }
            if (checkresult == false)
            {
                MessageBox.Show("输入数据不合法！");
                return;
            }
            bd_param_set.lng = float.Parse(lng.Text);
            bd_param_set.lat = float.Parse(lat.Text);
            bd_param_set.speed = byte.Parse(speed.Text);
            bd_param_set.status = (byte)(start.SelectedIndex == 1 ? 90 : 0);
            bd_param_set.h = byte.Parse(delaytimeh.Text);
            bd_param_set.m = byte.Parse(delaytimem.Text);
            bd_param_set.s = byte.Parse(delaytimes.Text);
            Properties.Settings.Default.lng_bd = lng.Text;
            Properties.Settings.Default.lat_bd = lat.Text;
            Properties.Settings.Default.speed_bd = speed.Text;
            Properties.Settings.Default.start_bd = start.Text;
            Properties.Settings.Default.delay_bd = delaytimeh.Text;
            Properties.Settings.Default.delay_bdm = delaytimem.Text;
            Properties.Settings.Default.delay_bds = delaytimes.Text;
            Properties.Settings.Default.Save();
            //将制导参数内容发送到飞控
            bool result = port.setupBianduiStart(bd_param_set);
            //判断执行结果

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "编队队形参数.txt";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                localFilePath = saveFileDialog1.FileName.ToString();
                MessageBox.Show(localFilePath);
                //弹窗显示文件路径
                if (!File.Exists(localFilePath))
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    sw.WriteLine(this.minp.Text);
                    sw.WriteLine(this.maxp.Text);
                    sw.WriteLine(this.cross.Text);
                    sw.WriteLine(this.forward.Text);
                    sw.WriteLine(this.hight.Text);
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));
                    sr.WriteLine(this.minp.Text);
                    sr.WriteLine(this.maxp.Text);
                    sr.WriteLine(this.cross.Text);
                    sr.WriteLine(this.forward.Text);
                    sr.WriteLine(this.hight.Text);
                    sr.Close();
                    fs.Close();
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //设置默认打开位置
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            localFilePath = openFileDialog1.FileName.ToString();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                localFilePath = openFileDialog1.FileName;
                //弹窗显示文件路径
                MessageBox.Show(localFilePath);
                System.IO.StreamReader st;
                st = new System.IO.StreamReader(localFilePath, System.Text.Encoding.UTF8);
                //UTF-8通用编码
                String line;
                int i = 1;
                string paramall = "";
                while ((line = st.ReadLine()) != null)
                {
                    paramall += line.ToString() + ";";
                    i++;
                }

                string[] array = paramall.Split(';');
                minp.Text = array[0];
                maxp.Text = array[1];
                cross.Text = array[2];
                forward.Text = array[3];
                hight.Text = array[4];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bd_control_param_down = port.searchBianduiCtrl();

            minpc.Text = bd_control_param_down.min.ToString();
            maxpc.Text = bd_control_param_down.max.ToString();
            crossc.Text = bd_control_param_down.crossDemand.ToString();
            forwardc.Text = bd_control_param_down.formDemand.ToString();
            hightc.Text = bd_control_param_down.hightdiff.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            bool checkresult = true;
            float check;
            if (!float.TryParse(this.minp.Text, out check))
            {
                this.minp.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.minp.BackColor = Color.White;
            }
            if (!float.TryParse(this.maxp.Text, out check))
            {
                this.maxp.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.maxp.BackColor = Color.White;
            }
            if (!float.TryParse(this.cross.Text, out check))
            {
                this.cross.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.cross.BackColor = Color.White;
            }
            if (!float.TryParse(this.forward.Text, out check))
            {
                this.forward.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.forward.BackColor = Color.White;
            }
            if (!float.TryParse(this.hight.Text, out check))
            {
                this.hight.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.hight.BackColor = Color.White;
            }
            if (checkresult == false)
            {
                return;
            }
            bd_control_param_set.min = float.Parse(minp.Text);
            bd_control_param_set.max = float.Parse(maxp.Text);
            bd_control_param_set.crossDemand = float.Parse(cross.Text);
            bd_control_param_set.formDemand = float.Parse(forward.Text);
            bd_control_param_set.hightdiff = float.Parse(hight.Text);

            Properties.Settings.Default.minp = minp.Text;
            Properties.Settings.Default.maxp = maxp.Text;
            Properties.Settings.Default.cross = cross.Text;
            Properties.Settings.Default.forward = forward.Text;
            Properties.Settings.Default.hight = hight.Text;
   
            Properties.Settings.Default.Save();

            bool result = port.setupBianduiCtrl(bd_control_param_set);
            if (result)
            {
                MessageBox.Show("队形参数设置成功！");
            }
            else
            {
                MessageBox.Show("队形参数设置失败！");
            }  
        }

        private void BianDuiParm_Load(object sender, EventArgs e)
        {
            lng.Text = Properties.Settings.Default.lng_bd;
            lat.Text = Properties.Settings.Default.lat_bd;
            speed.Text = Properties.Settings.Default.speed_bd;
            start.Text = Properties.Settings.Default.start_bd;
            delaytimeh.Text = Properties.Settings.Default.delay_bd;
            delaytimem.Text = Properties.Settings.Default.delay_bdm;
            delaytimes.Text = Properties.Settings.Default.delay_bds;
            minp.Text = Properties.Settings.Default.minp;
            maxp.Text = Properties.Settings.Default.maxp;
            cross.Text = Properties.Settings.Default.cross;
            forward.Text = Properties.Settings.Default.forward;
            hight.Text = Properties.Settings.Default.hight;
        }
    }
}
