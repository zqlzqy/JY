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
    public partial class AttitudeLoopView : UserControl
    {
        private JYLink.jylink_attitudeloop_param_down attitudeloopParam = new JYLink.jylink_attitudeloop_param_down();

        public JYLink.jylink_attitudeloop_param_down AttitudeloopParam
        {
            get { return attitudeloopParam; }
            set { attitudeloopParam = value; }
        }
        //定义一个用于查询、更新页面的对象
        public AttitudeLoopView()
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
                
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
                //弹框显示Please Connect First
            }
            attitudeloopParam = port.searchAttitudeLoop();

            update();
                //更新页面

            
        }
        

        private void update()
        {
            //查询参数的值并写入第一个文本框中
             roll_kp_r_textBox.Text = attitudeloopParam.roll_kp.ToString();
            roll_ki_r_textBox.Text = attitudeloopParam.roll_ki.ToString();
             roll_kd_r_textBox.Text = attitudeloopParam.roll_kd.ToString();
            attitudeloop_remaind1_r_textBox.Text = attitudeloopParam.attitudeloop_remaind1.ToString();
            //滚转
            pitch_kp_u_textBox.Text = attitudeloopParam.pitch_kp.ToString();
           pitch_ki_u_textBox.Text = attitudeloopParam.pitch_ki.ToString();
         pitch_kd_u_textBox.Text = attitudeloopParam.pitch_kd.ToString();
             attitudeloop_remaind2_u_textBox.Text = attitudeloopParam.attitudeloop_remaind2.ToString();
            //俯仰
            heading_offset_kp_y_textBox.Text = attitudeloopParam.heading_offset_kp.ToString();
             heading_offset_ki_y_textBox.Text = attitudeloopParam.heading_offset_ki.ToString();
             heading_offset_kd_y_textBox.Text = attitudeloopParam.heading_offset_kd.ToString();
             attitudeloop_remaind3_y_textBox.Text = attitudeloopParam.attitudeloop_remaind3.ToString();
            //偏航
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.roll_kd = roll_kd_textBox.Text;
            Properties.Settings.Default.roll_kp = roll_kp_textBox.Text;
            Properties.Settings.Default.roll_ki = roll_ki_textBox.Text;
            Properties.Settings.Default.attitudeloop_remaind1 = attitudeloop_remaind1_textBox.Text;
           //滚转
            Properties.Settings.Default.pitch_kp = pitch_kp_textBox.Text;
            Properties.Settings.Default.pitch_ki = pitch_ki_textBox.Text;
            Properties.Settings.Default.pitch_kd = pitch_kd_textBox.Text;
            Properties.Settings.Default.attitudeloop_remaind2 = attitudeloop_remaind2_textBox.Text;
            //俯仰
            Properties.Settings.Default.heading_offset_kp = heading_offset_kp_textBox.Text;
            Properties.Settings.Default.heading_offset_ki = heading_offset_ki_textBox.Text;
            Properties.Settings.Default.heading_offset_kd = heading_offset_kd_textBox.Text;
            Properties.Settings.Default.attitudeloop_remaind3 = attitudeloop_remaind3_textBox.Text;
            //偏航
            Properties.Settings.Default.Save();
             //点击设置保存第二个文本框中的数据

            //检验参数数据类型是否合法
            bool checkresult=true;
            float check;
            if (!float.TryParse(this.roll_kp_textBox.Text, out check))
            {
                this.roll_kp_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.roll_kp_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.roll_ki_textBox.Text, out check))
            {
                this.roll_ki_textBox.ForeColor = Color.Red;
                
            }
            else
            {
                this.roll_ki_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.roll_kd_textBox.Text, out check))
            {
                this.roll_kd_textBox.ForeColor = Color.Red;
                
            }else
            {
                this.roll_kd_textBox.ForeColor = Color.Black;
               
            }
            if (!float.TryParse(this.attitudeloop_remaind1_textBox.Text, out check))
            {
                this.attitudeloop_remaind1_textBox.ForeColor = Color.Red;
               
            }else
            {
                this.attitudeloop_remaind1_textBox.ForeColor = Color.Black;
                
            }

          //滚转



            if (!float.TryParse(this.pitch_kp_textBox.Text, out check))
            {
                this.pitch_kp_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.pitch_kp_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.pitch_ki_textBox.Text, out check))
            {
                this.pitch_ki_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.pitch_ki_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.pitch_kd_textBox.Text, out check))
            {
                this.pitch_kd_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.pitch_kd_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.attitudeloop_remaind2_textBox.Text, out check))
            {
                this.attitudeloop_remaind2_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            } else
            {
                this.attitudeloop_remaind2_textBox.ForeColor = Color.Black;

            }//俯仰


            if (!float.TryParse(this.heading_offset_kp_textBox.Text, out check))
            {
                this.heading_offset_kp_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.heading_offset_kp_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.heading_offset_ki_textBox.Text, out check))
            {
                this.heading_offset_ki_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.heading_offset_ki_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.heading_offset_kd_textBox.Text, out check))
            {
                this.heading_offset_kd_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.heading_offset_kd_textBox.ForeColor = Color.Black;
                
            }
            if (!float.TryParse(this.attitudeloop_remaind3_textBox.Text, out check))
            {
                this.attitudeloop_remaind3_textBox.ForeColor = Color.Red;
                //将字体变成红色
                checkresult = false;
            }else
            {
                this.attitudeloop_remaind3_textBox.ForeColor = Color.Black;

            }//偏航

            if (checkresult == false)
            {
                return;
            }
            

            
            JYLink.jylink_attitudeloop_param_setup attitudeparam = new JYLink.jylink_attitudeloop_param_setup();
            attitudeparam.roll_kp = Single.Parse(roll_kp_textBox.Text);
            attitudeparam.roll_ki = Single.Parse(roll_ki_textBox.Text);
            attitudeparam.roll_kd = Single.Parse(roll_kd_textBox.Text);
            attitudeparam.remaind1 = Single.Parse(attitudeloop_remaind1_textBox.Text);

            attitudeparam.pitch_kp = Single.Parse(pitch_kp_textBox.Text);
            attitudeparam.pitch_ki = Single.Parse(pitch_ki_textBox.Text);
            attitudeparam.pitch_kd = Single.Parse(pitch_kd_textBox.Text);
            attitudeparam.remaind2 = Single.Parse(attitudeloop_remaind2_textBox.Text);

            attitudeparam.heading_offset_kp = Single.Parse(heading_offset_kp_textBox.Text);
            attitudeparam.heading_offset_ki = Single.Parse(heading_offset_ki_textBox.Text);
            attitudeparam.heading_offset_kd = Single.Parse(heading_offset_kd_textBox.Text);
            attitudeparam.remaind3 = Single.Parse(attitudeloop_remaind3_textBox.Text);
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupAttitudeLoop(attitudeparam);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("姿态环参数设置成功");
            }
            else
            {
                MessageBox.Show("姿态环参数设置失败"); 
            }
        }


        //页面加载事件
        private void AttitudeLoopView_Load(object sender, EventArgs e)
        {
            roll_kp_textBox.Text = Properties.Settings.Default.roll_kp;
            roll_ki_textBox.Text = Properties.Settings.Default.roll_ki;
            roll_kd_textBox.Text = Properties.Settings.Default.roll_kd;
            attitudeloop_remaind1_textBox.Text = Properties.Settings.Default.attitudeloop_remaind1;
            //页面加载时显示保存的滚转参数
            pitch_kp_textBox.Text = Properties.Settings.Default.pitch_kp;
            pitch_ki_textBox.Text = Properties.Settings.Default.pitch_ki;
            pitch_kd_textBox.Text = Properties.Settings.Default.pitch_kd;
            attitudeloop_remaind2_textBox.Text = Properties.Settings.Default.attitudeloop_remaind2;
            //页面加载时显示保存的俯仰参数
            heading_offset_kp_textBox.Text = Properties.Settings.Default.heading_offset_kp;
            heading_offset_ki_textBox.Text = Properties.Settings.Default.heading_offset_ki;
            heading_offset_kd_textBox.Text = Properties.Settings.Default.heading_offset_kd;
            attitudeloop_remaind3_textBox.Text = Properties.Settings.Default.attitudeloop_remaind3;
            //页面加载时显示保存的偏航参数
        }

        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "姿态环参数.txt";

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
                    sw.WriteLine(this.roll_kp_textBox.Text);
                    sw.WriteLine(this.roll_ki_textBox.Text);
                    sw.WriteLine(this.roll_kd_textBox.Text);
                    sw.WriteLine(this.attitudeloop_remaind1_textBox.Text);
                    //在文件中写入滚转参数

                    sw.WriteLine(this.pitch_kp_textBox.Text);
                    sw.WriteLine(this.pitch_ki_textBox.Text);
                    sw.WriteLine(this.pitch_kd_textBox.Text);
                    sw.WriteLine(this.attitudeloop_remaind2_textBox.Text);
                    //在文件中写入俯仰参数

                    sw.WriteLine(this.heading_offset_kp_textBox.Text);
                    sw.WriteLine(this.heading_offset_ki_textBox.Text);
                    sw.WriteLine(this.heading_offset_kd_textBox.Text);
                    sw.WriteLine(this.attitudeloop_remaind3_textBox.Text);
                    //在文件中写入偏航参数

                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);

                   
                    sr.WriteLine(this.roll_kp_textBox.Text);
                    sr.WriteLine(this.roll_ki_textBox.Text);
                    sr.WriteLine(this.roll_kd_textBox.Text);
                    sr.WriteLine(this.attitudeloop_remaind1_textBox.Text);

                    sr.WriteLine(this.pitch_kp_textBox.Text);
                    sr.WriteLine(this.pitch_ki_textBox.Text);
                    sr.WriteLine(this.pitch_kd_textBox.Text);
                    sr.WriteLine(this.attitudeloop_remaind2_textBox.Text);

                    sr.WriteLine(this.heading_offset_kp_textBox.Text);
                    sr.WriteLine(this.heading_offset_ki_textBox.Text);
                    sr.WriteLine(this.heading_offset_kd_textBox.Text);
                    sr.WriteLine(this.attitudeloop_remaind3_textBox.Text);
                    sr.Close();
                    fs.Close();
                }

                attitudeloopParam.roll_kp = Convert.ToSingle(this.roll_kp_textBox.Text);
                
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

                 this.roll_kp_textBox.Text = array[0];
                 this.roll_ki_textBox.Text = array[1];
                 this.roll_kd_textBox.Text = array[2];
                 this.attitudeloop_remaind1_textBox.Text = array[3];
                //从文件中读取滚转参数的值

                 this.pitch_kp_textBox.Text = array[4];
                 this.pitch_ki_textBox.Text = array[5];
                 this.pitch_kd_textBox.Text = array[6];
                 this.attitudeloop_remaind2_textBox.Text = array[7];
                //从文件中读取俯仰参数的值

                 this.heading_offset_kp_textBox.Text = array[8];
                 this.heading_offset_ki_textBox.Text = array[9];
                 this.heading_offset_kd_textBox.Text = array[10];
                 this.attitudeloop_remaind3_textBox.Text = array[11];
                //从文件中读取偏航参数的值


             }
        }

        

 
    }
}