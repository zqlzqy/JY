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

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 姿态环参数查询
    /// </summary>
    public partial class OverLoadLoopView : UserControl
    {

        public JYLink.jylink_overloadloop_param_down overloadloopParam = new JYLink.jylink_overloadloop_param_down();
        //定义一个用于查询、更新页面的对象
        public OverLoadLoopView()
        {
            InitializeComponent();

        }
        //点击查询按钮事件
        private void search_button_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
                //弹框显示请先连接
            }
            overloadloopParam = port.searchOverLoadLoop();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            head_kp_f_textBox.Text = overloadloopParam.head_kp.ToString();
            head_ki_f_textBox.Text = overloadloopParam.head_ki.ToString();
            head_kd_f_textBox.Text = overloadloopParam.head_kd.ToString();
            overloadloop_remaind1_f_textBox.Text = overloadloopParam.remaind1.ToString();
            //前向
            side_kp_l_textBox.Text = overloadloopParam.side_kp.ToString();
            side_ki_l_textBox.Text = overloadloopParam.side_ki.ToString();
            side_kd_l_textBox.Text = overloadloopParam.side_kd.ToString();
            overloadloop_remaind2_l_textBox.Text = overloadloopParam.remaind2.ToString();
            //侧向
            up_kp_u_textBox.Text = overloadloopParam.up_kp.ToString();
            up_ki_u_textBox.Text = overloadloopParam.up_ki.ToString();
            up_kd_u_textBox.Text = overloadloopParam.up_kd.ToString();
            overloadloop_remaind3_u_textBox.Text = overloadloopParam.remaind3.ToString();
            //天向
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.head_kp = head_kp_textBox.Text;
            Properties.Settings.Default.head_ki = head_ki_textBox.Text;
            Properties.Settings.Default.head_kd = head_kd_textBox.Text;
            Properties.Settings.Default.overloadloop_remaind1 = overloadloop_remaind1_textBox.Text;
            //前向
            Properties.Settings.Default.side_kp = side_kp_textBox.Text;
            Properties.Settings.Default.side_ki = side_ki_textBox.Text;
            Properties.Settings.Default.side_kd = side_kd_textBox.Text;
            Properties.Settings.Default.overloadloop_remaind2 = overloadloop_remaind2_textBox.Text;
            //侧向
            Properties.Settings.Default.up_kp = up_kp_textBox.Text;
            Properties.Settings.Default.up_ki = up_ki_textBox.Text;
            Properties.Settings.Default.up_kd = up_kd_textBox.Text;
            Properties.Settings.Default.overloadloop_remaind3 = overloadloop_remaind3_textBox.Text;
            //天向
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据









           //检验参数数据类型是否合法
            bool checkresult = true;
            float check;
            if (!float.TryParse(this.head_kp_textBox.Text, out check))
            {
                this.head_kp_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.head_kp_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.head_ki_textBox.Text, out check))
            {
                this.head_ki_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.head_ki_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.head_kd_textBox.Text, out check))
            {
                this.head_kd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.head_kd_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.overloadloop_remaind1_textBox.Text, out check))
            {
                this.overloadloop_remaind1_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.overloadloop_remaind1_textBox.ForeColor = Color.Black;
            }//前向


            if (!float.TryParse(this.side_kp_textBox.Text, out check))
            {
                this.side_kp_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.side_kp_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.side_ki_textBox.Text, out check))
            {
                this.side_ki_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.side_ki_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.side_kd_textBox.Text, out check))
            {
                this.side_kd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.side_kd_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.overloadloop_remaind2_textBox.Text, out check))
            {
                this.overloadloop_remaind2_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.overloadloop_remaind2_textBox.ForeColor = Color.Black;
            }//侧向



            if (!float.TryParse(this.up_kp_textBox.Text, out check))
            {
                this.up_kp_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.up_kp_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.up_ki_textBox.Text, out check))
            {
                this.up_ki_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.up_ki_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.up_kd_textBox.Text, out check))
            {
                this.up_kd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.up_kd_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.overloadloop_remaind3_textBox.Text, out check))
            {
                this.overloadloop_remaind3_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.overloadloop_remaind3_textBox.ForeColor = Color.Black;
            }//天向



            if (checkresult == false)
            {
                return;
            }
            

            JYLink.jylink_overloadloop_param_setup overloadparam = new JYLink.jylink_overloadloop_param_setup();
            overloadparam.head_kp = Single.Parse(head_kp_textBox.Text);
            overloadparam.head_ki = Single.Parse(head_ki_textBox.Text);
            overloadparam.head_kd = Single.Parse(head_kd_textBox.Text);
            overloadparam.remaind1 = Single.Parse(overloadloop_remaind1_textBox.Text);

            overloadparam.side_kp = Single.Parse(side_kp_textBox.Text);
            overloadparam.side_ki = Single.Parse(side_ki_textBox.Text);
            overloadparam.side_kd = Single.Parse(side_kd_textBox.Text);
            overloadparam.remaind2 = Single.Parse(overloadloop_remaind2_textBox.Text);

            overloadparam.up_kp = Single.Parse(up_kp_textBox.Text);
            overloadparam.up_ki = Single.Parse(up_ki_textBox.Text);
            overloadparam.up_kd = Single.Parse(up_kd_textBox.Text);
            overloadparam.remaind3 = Single.Parse(overloadloop_remaind3_textBox.Text);
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            //将过载环参数内容发送到飞控
            bool result = port.setupOverLoadLoop(overloadparam);
            if (result)
            //判断执行结果
            {
                MessageBox.Show("过载环参数设置成功");
            }
            else
            {
                MessageBox.Show("过载环参数设置失败");
            }
        }

        //页面加载事件
        private void OverLoadLoopView_Load(object sender, EventArgs e)
        {
            //页面加载时显示保存的参数


            head_kp_textBox.Text = Properties.Settings.Default.head_kp;
            head_ki_textBox.Text = Properties.Settings.Default.head_ki;
            head_kd_textBox.Text = Properties.Settings.Default.head_kd;
            overloadloop_remaind1_textBox.Text = Properties.Settings.Default.overloadloop_remaind1;
            //前向
            side_kp_textBox.Text = Properties.Settings.Default.side_kp;
            side_ki_textBox.Text = Properties.Settings.Default.side_ki;
            side_kd_textBox.Text = Properties.Settings.Default.side_kd;
            overloadloop_remaind2_textBox.Text = Properties.Settings.Default.overloadloop_remaind2;
            //侧向
            up_kp_textBox.Text = Properties.Settings.Default.up_kp;
            up_ki_textBox.Text = Properties.Settings.Default.up_ki;
            up_kd_textBox.Text = Properties.Settings.Default.up_kd;
            overloadloop_remaind3_textBox.Text = Properties.Settings.Default.overloadloop_remaind3;
            //天向




        }

        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "过载环参数.txt";

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
                    StreamWriter sw = new StreamWriter(fs1);
                    //开始写入值
                    sw.WriteLine(this.head_kp_textBox.Text);
                    sw.WriteLine(this.head_ki_textBox.Text);
                    sw.WriteLine(this.head_kd_textBox.Text);
                    sw.WriteLine(this.overloadloop_remaind1_textBox.Text);
                    //前向

                    sw.WriteLine(this.side_kp_textBox.Text);
                    sw.WriteLine(this.side_ki_textBox.Text);
                    sw.WriteLine(this.side_kd_textBox.Text);
                    sw.WriteLine(this.overloadloop_remaind2_textBox.Text);
                    //侧向

                    sw.WriteLine(this.up_kp_textBox.Text);
                    sw.WriteLine(this.up_ki_textBox.Text);
                    sw.WriteLine(this.up_kd_textBox.Text);
                    sw.WriteLine(this.overloadloop_remaind3_textBox.Text);
                    //天向

                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值
                    
                    
                    //在文件中写入参数值

                    sr.WriteLine(this.head_kp_textBox.Text);
                    sr.WriteLine(this.head_ki_textBox.Text);
                    sr.WriteLine(this.head_kd_textBox.Text);
                    sr.WriteLine(this.overloadloop_remaind1_textBox.Text);
                    //前向

                    sr.WriteLine(this.side_kp_textBox.Text);
                    sr.WriteLine(this.side_ki_textBox.Text);
                    sr.WriteLine(this.side_kd_textBox.Text);
                    sr.WriteLine(this.overloadloop_remaind2_textBox.Text);
                    //侧向

                    sr.WriteLine(this.up_kp_textBox.Text);
                    sr.WriteLine(this.up_ki_textBox.Text);
                    sr.WriteLine(this.up_kd_textBox.Text);
                    sr.WriteLine(this.overloadloop_remaind3_textBox.Text);
                    //天向
                    sr.Close();
                    fs.Close();
                }

            }
        }

        //点击导入按钮事件
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

                //从文件中读取参数的值并写入到第二个文本框中
                this.head_kp_textBox.Text = array[0];
                this.head_ki_textBox.Text = array[1];
                this.head_kd_textBox.Text = array[2];
                this.overloadloop_remaind1_textBox.Text = array[3];
                //前向

                this.side_kp_textBox.Text = array[4];
                this.side_ki_textBox.Text = array[5];
                this.side_kd_textBox.Text = array[6];
                this.overloadloop_remaind2_textBox.Text = array[7];
                //侧向

                this.up_kp_textBox.Text = array[8];
                this.up_ki_textBox.Text = array[9];
                this.up_kd_textBox.Text = array[10];
                this.overloadloop_remaind3_textBox.Text = array[11];
                //天向
            }
            
        }
    }
}
       

