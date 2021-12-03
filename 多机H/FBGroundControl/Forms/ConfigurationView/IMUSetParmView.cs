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
    public partial class IMUSetParmView : UserControl
    {
        JYLinkInterface port = MainForm.comPort;
        JYLink.jylink_biandui_mode_setup param = new JYLink.jylink_biandui_mode_setup();
        JYLink.jylink_bd_control_param_set bd_param_set = new JYLink.jylink_bd_control_param_set();
        JYLink.jylink_bd_control_param_down bd_param_down = new JYLink.jylink_bd_control_param_down();  
        public IMUSetParmView()
        {
            InitializeComponent();
        }

        private void IMUSetParmView_Load(object sender, EventArgs e)
        {
            //页面加载时显示保存的参数
            kps.Text = Properties.Settings.Default.Accx;
            kis.Text = Properties.Settings.Default.Accy;
            kds.Text = Properties.Settings.Default.Accz;
            kls.Text = Properties.Settings.Default.Gccx;
            mins.Text = Properties.Settings.Default.Gccy;
            maxs.Text = Properties.Settings.Default.Gccz;
            kpp.Text = Properties.Settings.Default.SAccx;
            kip.Text = Properties.Settings.Default.SAccy;
            kdp.Text = Properties.Settings.Default.SAccz;
            klp.Text = Properties.Settings.Default.SGccx;
            minp.Text = Properties.Settings.Default.SGccy;
            maxp.Text = Properties.Settings.Default.SGccz;

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示Please Connect First！
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }

            bd_param_down = port.searchBianduiCtrl();


        }
        private void update()
        {
            //查询参数的值并写入第一个文本框中

        }

        private void setup_button_Click(object sender, EventArgs e)
        {
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            bool checkresult = true;
            float check;
            if (!float.TryParse(this.kps.Text, out check))
            {
                this.kps.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kps.BackColor = Color.White;
            }
            if (!float.TryParse(this.kis.Text, out check))
            {
                this.kis.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kis.BackColor = Color.White;
            }
            if (!float.TryParse(this.kds.Text, out check))
            {
                this.kds.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kds.BackColor = Color.White;
            }
            if (!float.TryParse(this.kls.Text, out check))
            {
                this.kls.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kls.BackColor = Color.White;
            }
            if (!float.TryParse(this.mins.Text, out check))
            {
                this.mins.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.mins.BackColor = Color.White;
            }
            if (!float.TryParse(this.maxs.Text, out check))
            {
                this.maxs.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.maxs.BackColor = Color.White;
            }
            ////
            if (!float.TryParse(this.kpp.Text, out check))
            {
                this.kpp.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kpp.BackColor = Color.White;
            }
            if (!float.TryParse(this.kip.Text, out check))
            {
                this.kip.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kip.BackColor = Color.White;
            }
            if (!float.TryParse(this.kdp.Text, out check))
            {
                this.kdp.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kdp.BackColor = Color.White;
            }
            if (!float.TryParse(this.klp.Text, out check))
            {
                this.klp.BackColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.klp.BackColor = Color.White;
            }
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
            if (checkresult == false)
            {
                return;
            }


            Properties.Settings.Default.Accx = kps.Text;
            Properties.Settings.Default.Accy = kis.Text;
            Properties.Settings.Default.Accz = kds.Text;
            Properties.Settings.Default.Gccx = kls.Text;
            Properties.Settings.Default.Gccy = mins.Text;
            Properties.Settings.Default.Gccz = maxs.Text;
            Properties.Settings.Default.SAccx = kpp.Text;
            Properties.Settings.Default.SAccy = kip.Text;
            Properties.Settings.Default.SAccz = kdp.Text;
            Properties.Settings.Default.SGccx = klp.Text;
            Properties.Settings.Default.SGccy = minp.Text;
            Properties.Settings.Default.SGccz = maxp.Text;
            Properties.Settings.Default.Save();
            //将制导参数内容发送到飞控
            bool result = port.setupBianduiCtrl(bd_param_set);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("编队参数设置成功！");
            }
            else
            {
                MessageBox.Show("编队参数设置失败！");
            }      
        }
        //导入
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
                kps.Text = array[0];
                kis.Text = array[1];
                kds.Text = array[2];
                kls.Text = array[3];
                mins.Text = array[4];
                maxs.Text = array[5];
                kpp.Text = array[6];
                kip.Text = array[7];
                kdp.Text = array[8];
                klp.Text = array[9];
                minp.Text = array[10];
                maxp.Text = array[11];
            }
        
        }
        //导出
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "编队控制参数.txt";

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
                    sw.WriteLine(this.kps.Text);
                    sw.WriteLine(this.kis.Text);
                    sw.WriteLine(this.kds.Text);
                    sw.WriteLine(this.kls.Text);
                    sw.WriteLine(this.mins.Text);
                    sw.WriteLine(this.maxs.Text);
                    sw.WriteLine(this.kpp.Text);
                    sw.WriteLine(this.kip.Text);
                    sw.WriteLine(this.kdp.Text);
                    sw.WriteLine(this.klp.Text);
                    sw.WriteLine(this.minp.Text);
                    sw.WriteLine(this.maxp.Text);
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);

                    //sr.WriteLine(this.lp_jx_t.Text);
                    sr.WriteLine(this.kps.Text);
                    sr.WriteLine(this.kis.Text);
                    sr.WriteLine(this.kds.Text);
                    sr.WriteLine(this.kls.Text);
                    sr.WriteLine(this.mins.Text);
                    sr.WriteLine(this.maxs.Text);
                    sr.WriteLine(this.kpp.Text);
                    sr.WriteLine(this.kip.Text);
                    sr.WriteLine(this.kdp.Text);
                    sr.WriteLine(this.klp.Text);
                    sr.WriteLine(this.minp.Text);
                    sr.WriteLine(this.maxp.Text);
                    sr.Close();
                    fs.Close();
                }


            }
        }
    }
}
