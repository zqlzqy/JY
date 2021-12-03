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
using System.Xml;

namespace FBGroundControl.Forms
{
    public delegate bool test(JYLinkInterface port, JYLink.jylink_steertrim_param_setup steertrimparam);
    public delegate void GetTextCallback();
    /// <summary>
    /// 盘旋参数查询
    /// </summary>
    public partial class SteerTrimView : UserControl
    {

        public JYLink.jylink_steertrim_param_down steertrimParam = new JYLink.jylink_steertrim_param_down();
        //定义一个用于查询、更新页面的对象
        public SteerTrimView()
        {
            InitializeComponent();
            SteerTrimView.CheckForIllegalCrossThreadCalls = false;
            Control.CheckForIllegalCrossThreadCalls = false;
          
        }

        //点击查询按钮事件
        private void search_button_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示Please Connect First！
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            steertrimParam = port.searchSteerTrim();
            update();
            //更新页面
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
        //点击设置按钮设置
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
            if(!Int16.TryParse(this.LeftAileron_textBox.Text,out check))
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
         
            if(checkresult == false)
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
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            bool result = false;
            test tt = new test(sendCommand);

            result = tt(port,steertrimparam);
           //lock(this){
           //   result = port.setupSteerTrim(steertrimparam);
           //}
            //将舵面配平参数发送到飞控
           // bool result = port.setupSteerTrim(steertrimparam);
            //判断执行结果
           
            //bool result = true;
            if (result)
            {
                MessageBox.Show("舵面配平参数设置成功");
            }
            else
            {

                MessageBox.Show("舵面配平参数设置失败");
            }
            //saveParam();
            //GetTextCallback d = new GetTextCallback(saveParam);
            ////this.Invoke(d);
            //Thread save = new Thread(new ThreadStart(d));
            //save.Start();
         
        }
        public static bool sendCommand(JYLinkInterface port, JYLink.jylink_steertrim_param_setup steertrimparam)
        {
            bool result = port.setupSteerTrim(steertrimparam);
            return result;
        }
        //页面加载事件
        private void SteerTrimView_Load(object sender, EventArgs e)
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



        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "舵面配平参数.txt";

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
                    StreamWriter sw = new StreamWriter(fs1);
                    //开始写入值
                    sw.WriteLine(this.LeftAileron_textBox.Text);
                    sw.WriteLine(this.LeftAileronRatio_textBox.Text);
                    sw.WriteLine(this.RightAileron_textBox.Text);
                    sw.WriteLine(this.RightAileronRatio_textBox.Text);
                    sw.WriteLine(this.LeftTail_textBox.Text);
                    sw.WriteLine(this.LeftTailRatio_textBox.Text);
                    sw.WriteLine(this.RightTail_textBox.Text);
                    sw.WriteLine(this.RightTailRatio_textBox.Text);
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值

                    sr.WriteLine(this.LeftAileron_textBox.Text);
                    sr.WriteLine(this.LeftAileronRatio_textBox.Text);
                    sr.WriteLine(this.RightAileron_textBox.Text);
                    sr.WriteLine(this.RightAileronRatio_textBox.Text);
                    sr.WriteLine(this.LeftTail_textBox.Text);
                    sr.WriteLine(this.LeftTailRatio_textBox.Text);
                    sr.WriteLine(this.RightTail_textBox.Text);
                    sr.WriteLine(this.RightTailRatio_textBox.Text);
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
                //从文件中获取参数的值并写入第二个文本框中
                this.LeftAileron_textBox.Text = array[0];
                this.LeftAileronRatio_textBox.Text = array[1];
                this.RightAileron_textBox.Text = array[2];
                this.RightAileronRatio_textBox.Text = array[3];
                this.LeftTail_textBox.Text = array[4];
                this.LeftTailRatio_textBox.Text = array[5];
                this.RightTail_textBox.Text = array[6];
                this.RightTailRatio_textBox.Text = array[7];

             }
            
        }

        public bool isEnable { get; set; }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void steer1_trim_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        //private void savetbn_Click(object sender, EventArgs e)
        //{
        //    saveParam();
        //}
    }
       

    }
