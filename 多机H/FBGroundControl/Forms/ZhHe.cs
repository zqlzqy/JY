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
    public partial class ZhHe : Form
    {
        private JYLink.jylink_zhenghe_param MicroParam = new JYLink.jylink_zhenghe_param();
        public ZhHe()
        {
            InitializeComponent();
        }

        private void setup_button_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            Properties.Settings.Default.hight_textBox = hight_textBox.Text;
            Properties.Settings.Default.guozai_textBox = guozai_textBox.Text;
            Properties.Settings.Default.time_textBox = time_textBox.Text;
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据

            //检验参数数据类型是否合法
            bool checkresult = true;
            float check;
            if (!float.TryParse(this.hight_textBox.Text, out check))
            {
                this.hight_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.hight_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.guozai_textBox.Text, out check))
            {
                this.guozai_textBox.ForeColor = Color.Red;

            }
            else
            {
                this.guozai_textBox.ForeColor = Color.Black;

            }
            //if (!float.TryParse(this.time_textBox.Text, out check))
            //{
            //    this.time_textBox.ForeColor = Color.Red;

            //}
            //else
            //{
            //    this.time_textBox.ForeColor = Color.Black;

            //}
        
            if (checkresult == false)
            {
                return;
            }
            MicroParam.hight = Single.Parse(hight_textBox.Text);
            MicroParam.guozai = Single.Parse(guozai_textBox.Text);
            MicroParam.time = 18;
  
            //将姿态环参数内容发送到飞控
            bool result = port.setupZh(MicroParam);
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

        private void search_button_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示请先连接！
                MessageBox.Show("请先连接!");
                return;
                //throw new Exception("请先连接!");
            }
            MicroParam = port.searchZh();
            hight_y_textBox.Text = MicroParam.hight.ToString();
            guozai_y_textBox.Text = MicroParam.guozai.ToString();
            time_y_textBox.Text = MicroParam.time.ToString();
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
                //从文件中读取参数值并写入到第二列文本框中
                string[] array = paramall.Split(';');
                hight_textBox.Text = array[0];
                guozai_textBox.Text = array[1];
                time_textBox.Text = array[2];

            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "设置参数.txt";

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
                //判断文件是否存在
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                    //创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    //开始写入值


                    sw.WriteLine(hight_textBox.Text);
                    sw.WriteLine(guozai_textBox.Text);
                    sw.WriteLine(time_textBox.Text);
                     //在文件中写入参数
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));

                    //开始写入值

                    sr.WriteLine(hight_textBox.Text);
                    sr.WriteLine(guozai_textBox.Text);
                    sr.WriteLine(time_textBox.Text);
                    sr.Close();
                    fs.Close();
                }

            }
        }

        private void ZhHe_Load(object sender, EventArgs e)
        {
            hight_textBox.Text = Properties.Settings.Default.hight_textBox;
            guozai_textBox.Text = Properties.Settings.Default.guozai_textBox;
            time_textBox.Text = Properties.Settings.Default.time_textBox;
        }
    }
}
