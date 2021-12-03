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
    public partial class NAVsetView : UserControl
    {

        JYLinkInterface port = MainForm.comPort;
        JYLink.jylink_bd_planeID_param_set bd_param_set = new JYLink.jylink_bd_planeID_param_set();
        JYLink.jylink_bd_planeID_param_down bd_param_down = new JYLink.jylink_bd_planeID_param_down();  

        public NAVsetView()
        {
            InitializeComponent();
        }
        private void update()
        {

        }
        private void setup_button_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
            }
            bool checkresult = true;
            float check;
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
            //if (!float.TryParse(this.start.Text, out check))
            //{
            //    this.start.BackColor = Color.Red;
            //    checkresult = false;
            //}
            //else
            //{
            //    this.start.BackColor = Color.White;
            //}
            if (!float.TryParse(this.delaytime.Text, out check))
            {
                this.delaytime.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.delaytime.BackColor = Color.White;
            }
            if (checkresult == false)
            {
                return;
            }
            bd_param_set.lng = float.Parse(lng.Text);
            bd_param_set.lat = float.Parse(lat.Text);
            bd_param_set.speed = byte.Parse(speed.Text);
            bd_param_set.status =(byte)(start.SelectedIndex==1?90:0);

            Properties.Settings.Default.lng_bd = lng.Text;
            Properties.Settings.Default.lat_bd = lat.Text;
            Properties.Settings.Default.speed_bd = speed.Text;
            Properties.Settings.Default.start_bd = start.Text;
            Properties.Settings.Default.delay_bd = delaytime.Text;
            Properties.Settings.Default.Save();
            //将制导参数内容发送到飞控
            bool result = port.setupBianduiStart(bd_param_set);
            //判断执行结果

        }

      

        private void NAVsetView_Load(object sender, EventArgs e)
        {
             lng.Text=Properties.Settings.Default.lng_bd ;
             lat.Text=Properties.Settings.Default.lat_bd ;
             speed.Text=Properties.Settings.Default.speed_bd ;
             start.Text=Properties.Settings.Default.start_bd ;
             delaytime.Text=Properties.Settings.Default.delay_bd ;
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

                //this.lp_jx_t.Text = array[0];
                lng.Text = array[0];
                lat.Text = array[1];
                speed.Text = array[2];
                start.Text = array[3];
                delaytime.Text = array[4];  
            }
        }  
       private void search_button_Click_1(object sender, EventArgs e)
        {
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示Please Connect First！
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }

            bd_param_down = port.searchBianduiStart();

            lngc.Text = bd_param_down.lng.ToString();
            latc.Text = bd_param_down.lat.ToString();
            speedc.Text = bd_param_down.speed.ToString();
            startc.Text = bd_param_down.status==90?"启动":"停止";


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
                   StreamWriter sw = new StreamWriter(fs1);
                   sw.WriteLine(this.lng.Text);
                   sw.WriteLine(this.lat.Text);
                   sw.WriteLine(this.speed.Text);
                   sw.WriteLine(this.start.Text);
                   sw.WriteLine(this.delaytime.Text);

                   sw.Close();
                   fs1.Close();
               }
               else
               {
                   FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                   StreamWriter sr = new StreamWriter(fs);
                   sr.WriteLine(this.lng.Text);
                   sr.WriteLine(this.lat.Text);
                   sr.WriteLine(this.speed.Text);
                   sr.WriteLine(this.start.Text);
                   sr.WriteLine(this.delaytime.Text);
                   sr.Close();
                   fs.Close();
               }


           }
       }
    }
}
