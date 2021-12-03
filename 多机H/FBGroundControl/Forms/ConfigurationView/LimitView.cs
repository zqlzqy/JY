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
    public partial class LimitView : UserControl
    {

        public JYLink.jylink_limit_param_down limitParam = new JYLink.jylink_limit_param_down();
        //定义一个用于查询、更新页面的对象
        public LimitView()
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
            limitParam = port.searchLimit();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            aileron_l_textBox.Text = limitParam.aileron.ToString();
            elevator_l_textBox.Text = limitParam.elevator.ToString();
            rudder_l_textBox.Text = limitParam.rudder.ToString();
            frontwheel_l_textBox.Text = limitParam.frontwheel.ToString();
            max_throttle_l_textBox.Text = limitParam.max_throttle.ToString();
            min_throttle_l_textBox.Text = limitParam.min_throttle.ToString();
            max_pitch_angle_l_textBox.Text = limitParam.max_pitch_angle.ToString();
            min_pitch_angle_l_textBox.Text = limitParam.min_pitch_angle.ToString();
            roll_angle_l_textBox.Text = limitParam.roll_angle.ToString();
            stall_speed_l_textBox.Text = limitParam.stall_speed.ToString();
            max_airspeed_l_textBox.Text = limitParam.max_airspeed.ToString();
            max_lateral_overload_l_textBox.Text = limitParam.max_lateral_overload.ToString();
            reserve_l_textBox.Text = limitParam.reserve.ToString();
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.aileron = aileron_textBox.Text;
            Properties.Settings.Default.elevator = elevator_textBox.Text;
            Properties.Settings.Default.rudder = rudder_textBox.Text;
            Properties.Settings.Default.frontwheel = frontwheel_textBox.Text;
            Properties.Settings.Default.max_throttle = max_throttle_textBox.Text;
            Properties.Settings.Default.min_throttle = min_throttle_textBox.Text;
            Properties.Settings.Default.max_pitch_angle = max_pitch_angle_textBox.Text;
            Properties.Settings.Default.min_pitch_angle = min_pitch_angle_textBox.Text;
            Properties.Settings.Default.roll_angle = roll_angle_textBox.Text;
            Properties.Settings.Default.stall_speed = stall_speed_textBox.Text;
            Properties.Settings.Default.max_airspeed = max_airspeed_textBox.Text;
            Properties.Settings.Default.max_lateral_overload = max_lateral_overload_textBox.Text;
            Properties.Settings.Default.reserve = reserve_textBox.Text;
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据










            //检验参数数据类型是否合法
            float check;
            bool checkresult = true;
            if (!float.TryParse(this.aileron_textBox.Text,out check))
            {
                this.aileron_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else 
            {
                this.aileron_textBox.ForeColor = Color.Black;
            }//副翼限幅
            if (!float.TryParse(this.elevator_textBox.Text, out check))
            {
                this.elevator_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.elevator_textBox.ForeColor = Color.Black;
            }//升降舵限幅
            if (!float.TryParse(this.rudder_textBox.Text, out check))
            {
                this.rudder_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.rudder_textBox.ForeColor = Color.Black;
            }//方向舵限幅
            if (!float.TryParse(this.frontwheel_textBox.Text, out check))
            {
                this.frontwheel_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.frontwheel_textBox.ForeColor = Color.Black;
            }//前轮限幅
            if (!float.TryParse(this.max_throttle_textBox.Text, out check))
            {
                this.max_throttle_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.max_throttle_textBox.ForeColor = Color.Black;
            }//最大油门
            if (!float.TryParse(this.min_throttle_textBox.Text, out check))
            {
                this.min_throttle_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.min_throttle_textBox.ForeColor = Color.Black;
            }//最小油门
            if (!float.TryParse(this.max_pitch_angle_textBox.Text, out check))
            {
                this.max_pitch_angle_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.max_pitch_angle_textBox.ForeColor = Color.Black;
            }//最大俯仰角
            if (!float.TryParse(this.min_pitch_angle_textBox.Text, out check))
            {
                this.min_pitch_angle_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.min_pitch_angle_textBox.ForeColor = Color.Black;
            }//最小俯仰角
            if (!float.TryParse(this.roll_angle_textBox.Text, out check))
            {
                this.roll_angle_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.roll_angle_textBox.ForeColor = Color.Black;
            }//滚转角限幅
            if (!float.TryParse(this.stall_speed_textBox.Text, out check))
            {
                this.stall_speed_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.stall_speed_textBox.ForeColor = Color.Black;
            }//失速速度
            if (!float.TryParse(this.max_airspeed_textBox.Text, out check))
            {
                this.max_airspeed_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.max_airspeed_textBox.ForeColor = Color.Black;
            }//最大空速
            if (!float.TryParse(this.max_lateral_overload_textBox.Text, out check))
            {
                this.max_lateral_overload_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.max_lateral_overload_textBox.ForeColor = Color.Black;
            }//最大横向过载
            if (!float.TryParse(this.reserve_textBox.Text, out check))
            {
                this.reserve_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.reserve_textBox.ForeColor = Color.Black;
            }//预留
            if(checkresult == false)
            {
                return;
            }








            
            JYLink.jylink_limit_param_setup limitparam = new JYLink.jylink_limit_param_setup();
            limitparam.aileron = Single.Parse(aileron_textBox.Text);
            limitparam.elevator = Single.Parse(elevator_textBox.Text);
            limitparam.rudder = Single.Parse(rudder_textBox.Text);
            limitparam.frontwheel = Single.Parse(frontwheel_textBox.Text);
            limitparam.max_throttle = Single.Parse(max_throttle_textBox.Text);
            limitparam.min_throttle = Single.Parse(min_throttle_textBox.Text);
            limitparam.max_pitch_angle = Single.Parse(max_pitch_angle_textBox.Text);
            limitparam.min_pitch_angle = Single.Parse(min_pitch_angle_textBox.Text);
            limitparam.roll_angle = Single.Parse(roll_angle_textBox.Text);
            limitparam.stall_speed = Single.Parse(stall_speed_textBox.Text);
            limitparam.max_airspeed = Single.Parse(max_airspeed_textBox.Text);
            limitparam.max_lateral_overload = Single.Parse(max_lateral_overload_textBox.Text);
            limitparam.reserve = Single.Parse(reserve_textBox.Text);
            JYLinkInterface port = MainForm.comPort;

            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            bool result = port.setupLimit(limitparam);
            if (result)
            {
                MessageBox.Show("极限参数设置成功");
            }
            else
            {
                MessageBox.Show("极限参数设置失败"); 
            }
        }

        private void LimitView_Load(object sender, EventArgs e)
        {
            aileron_textBox.Text = Properties.Settings.Default.aileron;
            elevator_textBox.Text = Properties.Settings.Default.elevator;
            rudder_textBox.Text = Properties.Settings.Default.rudder;
            frontwheel_textBox.Text = Properties.Settings.Default.frontwheel;
            max_throttle_textBox.Text = Properties.Settings.Default.max_throttle;
            min_throttle_textBox.Text = Properties.Settings.Default.min_throttle;
            max_pitch_angle_textBox.Text = Properties.Settings.Default.max_pitch_angle;
            min_pitch_angle_textBox.Text = Properties.Settings.Default.min_pitch_angle;
            roll_angle_textBox.Text = Properties.Settings.Default.roll_angle;
            stall_speed_textBox.Text = Properties.Settings.Default.stall_speed;
            max_airspeed_textBox.Text = Properties.Settings.Default.max_airspeed;
            max_lateral_overload_textBox.Text = Properties.Settings.Default.max_lateral_overload;
            reserve_textBox.Text = Properties.Settings.Default.reserve;


        }

        //点击导出按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "极限参数.txt";

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
                    sw.WriteLine(this.aileron_textBox.Text);
                    sw.WriteLine(this.elevator_textBox.Text);
                    sw.WriteLine(this.rudder_textBox.Text);
                    sw.WriteLine(this.frontwheel_textBox.Text);
                    sw.WriteLine(this.max_throttle_textBox.Text);
                    sw.WriteLine(this.min_throttle_textBox.Text);
                    sw.WriteLine(this.max_pitch_angle_textBox.Text);
                    sw.WriteLine(this.min_pitch_angle_textBox.Text);
                    sw.WriteLine(this.roll_angle_textBox.Text);
                    sw.WriteLine(this.stall_speed_textBox.Text);
                    sw.WriteLine(this.max_airspeed_textBox.Text);
                    sw.WriteLine(this.max_lateral_overload_textBox.Text);
                    sw.WriteLine(this.reserve_textBox.Text);
                    //将数据写入到文件中
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值
                    
                    sr.WriteLine(this.aileron_textBox.Text);
                    sr.WriteLine(this.elevator_textBox.Text);
                    sr.WriteLine(this.rudder_textBox.Text);
                    sr.WriteLine(this.frontwheel_textBox.Text);
                    sr.WriteLine(this.max_throttle_textBox.Text);
                    sr.WriteLine(this.min_throttle_textBox.Text);
                    sr.WriteLine(this.max_pitch_angle_textBox.Text);
                    sr.WriteLine(this.min_pitch_angle_textBox.Text);
                    sr.WriteLine(this.roll_angle_textBox.Text);
                    sr.WriteLine(this.stall_speed_textBox.Text);
                    sr.WriteLine(this.max_airspeed_textBox.Text);
                    sr.WriteLine(this.max_lateral_overload_textBox.Text);
                    sr.WriteLine(this.reserve_textBox.Text);
                    

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
            //openFileDialog1.InitialDirectory = "D:\\";
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

                this.aileron_textBox.Text = array[0];
                this.elevator_textBox.Text = array[1];
                this.rudder_textBox.Text = array[2];
                this.frontwheel_textBox.Text = array[3];
                this.max_throttle_textBox.Text = array[4];
                this.min_throttle_textBox.Text = array[5];
                this.max_pitch_angle_textBox.Text = array[6];
                this.min_pitch_angle_textBox.Text = array[7];
                this.roll_angle_textBox.Text = array[8];
                this.stall_speed_textBox.Text = array[9];
                this.max_airspeed_textBox.Text = array[10];
                this.max_lateral_overload_textBox.Text = array[11];
                this.reserve_textBox.Text = array[12];
                //将文件中读取参数值并写入到第二个文本框中
            }
            
        }
        }
        }
       

    
