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
    /// 盘旋参数查询
    /// </summary>
    public partial class LoiterView : UserControl
    {
       
        public JYLink.jylink_loiter_param_down loiterParam = new JYLink.jylink_loiter_param_down();
        //定义一个用于查询、更新页面的对象
        public LoiterView()
        {
            InitializeComponent();
            //初始化下拉框

            loiter_dir_comboBox.DataSource = Common.getLoiterDirList(MainForm.comPort.JY.cs);
            //获取下拉框内容
            loiter_dir_comboBox.ValueMember = "Key";
            loiter_dir_comboBox.DisplayMember = "Value";

            
            loiter_dir_comboBox.Text = "顺时针";
            //设置下拉框默认值
          
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
            loiterParam = port.searchLoiter();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            loiter_radius_h_textBox.Text = loiterParam.loiter_radius.ToString();
            op_lng_h_textBox.Text = loiterParam.op_lng.ToString();
            op_lat_h_textBox.Text = loiterParam.op_lat.ToString();
            if (loiterParam.loiter_dir.ToString().Equals( "1" ))
            {
                loiter_dir_textBox.Text = "顺时针";
            }
            else if(loiterParam.loiter_dir.ToString().Equals( "2" ))
            {
                loiter_dir_textBox.Text = "逆时针";
            }
            else
            {
                loiter_dir_textBox.Text = loiterParam.loiter_dir.ToString();
            }
            
             
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.loiter_radius = loiter_radius_textBox.Text;
            Properties.Settings.Default.op_lng = op_lng_textBox.Text;
            Properties.Settings.Default.op_lat = op_lat_textBox.Text;
            Properties.Settings.Default.loiter_dir = loiter_dir_comboBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据
            
            
            
            
            
            
            //检验参数数据类型是否合法
            double dcheck;
            float fcheck;
            bool checkresult = true;
            if (!float.TryParse(this.loiter_radius_textBox.Text, out fcheck))
            {
                this.loiter_radius_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else 
            {
                this.loiter_radius_textBox.ForeColor = Color.Black;
                
            }
            if (!double.TryParse(this.op_lng_textBox.Text, out dcheck))
            {
                this.op_lng_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else 
            {
                this.op_lng_textBox.ForeColor = Color.Black;
                

            }
            if (!double.TryParse(this.op_lat_textBox.Text, out dcheck))
            {
                this.op_lat_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.op_lat_textBox.ForeColor = Color.Black;


            }

            //盘旋方向

            if(checkresult == false)
            {
                return;
            }

            
            JYLink.jylink_loiter_param_setup loiterparam = new JYLink.jylink_loiter_param_setup();
            loiterparam.loiter_radius = Single.Parse(loiter_radius_textBox.Text);
            loiterparam.op_lng = Double.Parse(op_lng_textBox.Text);
            loiterparam.op_lat = Double.Parse(op_lat_textBox.Text);
            loiterparam.loiter_dir = Byte.Parse(loiter_dir_comboBox.SelectedValue.ToString());

            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将盘旋参数内容发送到飞控
            bool result = port.setupLoiter(loiterparam);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("盘旋参数设置成功");
            }
            else
            {
                MessageBox.Show("盘旋参数设置失败"); 
            }
        }
        //页面加载事件
        private void LoiterView_Load(object sender, EventArgs e)
        {
            loiter_radius_textBox.Text = Properties.Settings.Default.loiter_radius;
            op_lng_textBox.Text = Properties.Settings.Default.op_lng;
            op_lat_textBox.Text = Properties.Settings.Default.op_lat;
        }

        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "盘旋参数.txt";

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
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    //开始写入值
                    sw.WriteLine(this.loiter_dir_comboBox.Text);
                    sw.WriteLine(this.loiter_radius_textBox.Text);
                    sw.WriteLine(this.op_lng_textBox.Text);
                    sw.WriteLine(this.op_lat_textBox.Text);
                    //在文件中写入盘旋参数
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值
                   
                    sr.WriteLine(this.loiter_dir_comboBox.Text);
                    sr.WriteLine(this.loiter_radius_textBox.Text);
                    sr.WriteLine(this.op_lng_textBox.Text);
                    sr.WriteLine(this.op_lat_textBox.Text);
                    sr.Close();
                    fs.Close();
                }

            }
        }

        //点击导出按钮事件
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
                //从文件中读取参数值并写入到第二列文本框中
                 string[] array = paramall.Split(';');
                 this.loiter_dir_comboBox.Text = array[0];
                 this.loiter_radius_textBox.Text = array[1];
                 this.op_lng_textBox.Text = array[2];
                 this.op_lat_textBox.Text = array[3];
             }
            
        }
        }
    }
