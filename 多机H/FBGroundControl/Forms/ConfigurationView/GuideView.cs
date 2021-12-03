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
    public partial class GuideView : UserControl
    {

        public JYLink.jylink_guide_param_down guideParam = new JYLink.jylink_guide_param_down();
        //定义一个用于查询、更新页面的对象

        public GuideView()
        {
            InitializeComponent();
          
        }

        //点击查询按钮事件
        private void search_button_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;

            if (!port.BaseStream.IsOpen)
            {
                //弹框显示Please Connect First！
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            guideParam = port.searchGuide();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            alt_g_textBox.Text = guideParam.alt.ToString();
            speed_g_textBox.Text = guideParam.speed.ToString();
            heading_g_textBox.Text = guideParam.heading.ToString();
            
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.alt = alt_textBox.Text;
            Properties.Settings.Default.speed = speed_textBox.Text;
            Properties.Settings.Default.heading = heading_textBox.Text;
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据





            //检验参数数据类型是否合法
            float check;
            bool checkresult = true;
            if (!float.TryParse(this.alt_textBox.Text,out check))
            {
                this.alt_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else 
            {
                this.alt_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.speed_textBox.Text, out check))
            {
                this.speed_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.speed_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.heading_textBox.Text, out check))
            {
                this.heading_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.heading_textBox.ForeColor = Color.Black;
            }
            if(checkresult == false)
            {
                return;
            }


            JYLink.jylink_guide_param_setup guideparam = new JYLink.jylink_guide_param_setup();
            guideparam.alt = Single.Parse(alt_textBox.Text);
            guideparam.speed = Single.Parse(speed_textBox.Text);
            guideparam.heading = Single.Parse(heading_textBox.Text);

            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将引导参数内容发送到飞控
            bool result = port.setupGuide(guideparam);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("引导参数设置成功");
            }
            else
            {
                MessageBox.Show("引导参数设置失败"); 
            }
        }

        private void GuideView_Load(object sender, EventArgs e)
        {
            alt_textBox.Text = Properties.Settings.Default.alt;
            speed_textBox.Text = Properties.Settings.Default.speed;
            heading_textBox.Text = Properties.Settings.Default.heading;

        }

        //点击导入按钮事件
        private void button1_Click(object sender, EventArgs e)
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
                //弹窗显示文件路径
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
                //从文件中读取参数值并写入第二个文本框中

                 this.alt_textBox.Text = array[0];
                 this.speed_textBox.Text = array[1];
                 this.heading_textBox.Text = array[2];
                
             }
           
        }

        //点击导出按钮事件
        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "引导参数.txt";

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
                if (!File.Exists(localFilePath))
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                    //创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    //开始写入值
                    sw.WriteLine(this.alt_textBox.Text);
                    sw.WriteLine(this.speed_textBox.Text);
                    sw.WriteLine(this.heading_textBox.Text);
                    //将数据写入到文件中
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值
                   
                    sr.WriteLine(this.alt_textBox.Text);
                    sr.WriteLine(this.speed_textBox.Text);
                    sr.WriteLine(this.heading_textBox.Text);
                    sr.Close();
                    fs.Close();
                }
                
            }

        }
        }
       

    }
