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
    public partial class TakeOffView : UserControl
    {

        public JYLink.jylink_takeoff_param_down takeoffParam = new JYLink.jylink_takeoff_param_down();
        //定义一个用于查询、更新页面的对象
        public TakeOffView()
        {
            InitializeComponent();
            //初始化下拉框
            takeoff_type_comboBox.DataSource = Common.getTakeOffDirList(MainForm.comPort.JY.cs);
            //获取下拉框内容
            takeoff_type_comboBox.ValueMember = "Key";
            takeoff_type_comboBox.DisplayMember = "Value";

            takeoff_type_comboBox.Text = "滑跑起飞";
            //设置下拉框默认值
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
            takeoffParam = port.searchTakeOff();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            //takeoff_type_comboBox.Text = takeoffParam.takeoff_type.ToString();
            if (takeoffParam.takeoff_type.ToString().Equals( "0" ) )
            {
                takeoff_type_textBox.Text = "滑跑起飞";
            }
            else if (takeoffParam.takeoff_type.ToString().Equals("1"))
            {
                takeoff_type_textBox.Text = "弹射起飞";
            }
            else if (takeoffParam.takeoff_type.ToString().Equals("2"))
            {
                takeoff_type_textBox.Text = "火箭助推";
            }
            else
            {
                takeoff_type_textBox.Text = takeoffParam.takeoff_type.ToString();
            }
            takeoff_offset_t_textBox.Text = takeoffParam.takeoff_offset.ToString();
            lift_pull_t_textBox.Text = takeoffParam.lift_pull.ToString();
            pull_time_t_textBox.Text = takeoffParam.pull_time.ToString();

            pull_alt_t_textBox.Text = takeoffParam.pull_alt.ToString();
            vspeed_t_textBox.Text = takeoffParam.vspeed.ToString();


        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.takeoff_offset = takeoff_offset_textBox.Text;
            Properties.Settings.Default.lift_pull = lift_pull_textBox.Text;
            Properties.Settings.Default.pull_time = pull_time_textBox.Text;
            Properties.Settings.Default.pull_alt = pull_alt_textBox.Text;
            Properties.Settings.Default.vspeed = vspeed_textBox.Text;
            Properties.Settings.Default.takeoff_type = takeoff_type_comboBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据







            //检验参数数据类型是否合法
            bool checkresult = true;
            float check;

            if (!float.TryParse(this.takeoff_offset_textBox.Text, out check))
            {
                this.takeoff_offset_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.takeoff_offset_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.lift_pull_textBox.Text, out check))
            {
                this.lift_pull_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.lift_pull_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.pull_time_textBox.Text, out check))
            {
                this.pull_time_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pull_time_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.pull_alt_textBox.Text, out check))
            {
                this.pull_alt_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pull_alt_textBox.ForeColor = Color.Black;

            }
            if (!float.TryParse(this.vspeed_textBox.Text, out check))
            {
                this.vspeed_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.vspeed_textBox.ForeColor = Color.Black;

            }

            if (checkresult == false)
            {
                return;
            }




            //TODO 校验参数输入框输入是否合法
            JYLink.jylink_takeoff_param_setup takeoffparam = new JYLink.jylink_takeoff_param_setup();
            takeoffparam.takeoff_offset = Single.Parse(takeoff_offset_textBox.Text);
            takeoffparam.lift_pull = Single.Parse(lift_pull_textBox.Text);
            takeoffparam.pull_time = Single.Parse(pull_time_textBox.Text);
            takeoffparam.pull_alt = Single.Parse(pull_alt_textBox.Text);
            takeoffparam.vspeed = Single.Parse(vspeed_textBox.Text);
            takeoffparam.takeoff_type = Byte.Parse(takeoff_type_comboBox.SelectedValue.ToString());//起飞类型


            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将起飞参数内容发送到飞控
            bool result = port.setupTakeOff(takeoffparam);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("起飞参数设置成功");
            }
            else
            {
                MessageBox.Show("起飞参数设置失败");
            }
        }
        //页面加载事件
        private void TakeOffView_Load(object sender, EventArgs e)
        {
            takeoff_offset_textBox.Text = Properties.Settings.Default.takeoff_offset;
            lift_pull_textBox.Text = Properties.Settings.Default.lift_pull;
            pull_time_textBox.Text = Properties.Settings.Default.pull_time;
            pull_alt_textBox.Text = Properties.Settings.Default.pull_alt;
            vspeed_textBox.Text = Properties.Settings.Default.vspeed;









        }

        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "起飞参数.txt";

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
                    sw.WriteLine(takeoff_type_comboBox.Text);
                    sw.WriteLine(this.takeoff_offset_textBox.Text);
                    sw.WriteLine(this.lift_pull_textBox.Text);
                    sw.WriteLine(this.pull_time_textBox.Text);
                    sw.WriteLine(this.pull_alt_textBox.Text);
                    sw.WriteLine(this.vspeed_textBox.Text);
                    //在文件中写入参数
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    
                    //开始写入值
                    
                    sr.WriteLine(takeoff_type_comboBox.Text);
                    sr.WriteLine(this.takeoff_offset_textBox.Text);
                    sr.WriteLine(this.lift_pull_textBox.Text);
                    sr.WriteLine(this.pull_time_textBox.Text);
                    sr.WriteLine(this.pull_alt_textBox.Text);
                    sr.WriteLine(this.vspeed_textBox.Text);

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
                this.takeoff_type_comboBox.Text = array[0];
                this.takeoff_offset_textBox.Text = array[1];
                this.lift_pull_textBox.Text = array[2];
                this.pull_time_textBox.Text = array[3];
                this.pull_alt_textBox.Text = array[4];
                this.vspeed_textBox.Text = array[5];




            }
        }
    }
}

