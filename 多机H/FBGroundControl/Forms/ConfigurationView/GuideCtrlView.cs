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
    public partial class GuideCtrlView : UserControl
    {
        public JYLink.jylink_guidectrl_param_down guidectrlParam = new JYLink.jylink_guidectrl_param_down();
        //定义一个用于查询、更新页面的对象

        public GuideCtrlView()
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
                //弹框显示Please Connect First！
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            
            guidectrlParam = port.searchGuideCtrl();
            update();
            //更新页面
        }

        private void update()
        {
            //查询参数的值并写入第一个文本框中
            khead_h_textBox.Text = guidectrlParam.khead.ToString();
            kxt_h_textBox.Text = guidectrlParam.kxt.ToString();
            kc_h_textBox.Text = guidectrlParam.kc.ToString();
            kr_h_textBox.Text = guidectrlParam.kr.ToString();
            //盘旋

            l1guide_dr_g_textBox.Text = guidectrlParam.l1guide_dr.ToString();
            l1guide_p_g_textBox.Text = guidectrlParam.l1guide_p.ToString();
            l1guide_kig_g_textBox.Text = guidectrlParam.l1guide_kig.ToString();
            //L1导引

            throttle_t_t_textBox.Text = guidectrlParam.throttle_t.ToString();
            throttle_d_t_textBox.Text = guidectrlParam.throttle_d.ToString();
            throttle_i_t_textBox.Text = guidectrlParam.throttle_i.ToString();
            throttle_turn_t_textBox.Text = guidectrlParam.throttle_turn.ToString();
            //油门

            pitch_kw_p_textBox.Text = guidectrlParam.pitch_kw.ToString();
            pitch_i_p_textBox.Text = guidectrlParam.pitch_i.ToString();
            pitch_t_p_textBox.Text = guidectrlParam.pitch_t.ToString();
            pitch_d_p_textBox.Text = guidectrlParam.pitch_d.ToString();
            //俯仰

            kspd_s_textBox.Text = guidectrlParam.kspd.ToString();
            kspdi_s_textBox.Text = guidectrlParam.kspdi.ToString();
            kspdd_s_textBox.Text = guidectrlParam.kspdd.ToString();
            //速度

            kh_h_textBox.Text = guidectrlParam.kh.ToString();
            khi_h_textBox.Text = guidectrlParam.khi.ToString();
            khd_h_textBox.Text = guidectrlParam.khd.ToString();
            jfmx_textBox.Text = guidectrlParam.jfmx.ToString();
            //高度

            kpd_r_textBox.Text = guidectrlParam.kpd.ToString();
            kid_r_textBox.Text = guidectrlParam.kid.ToString();
            kdd_r_textBox.Text = guidectrlParam.kdd.ToString();
            //滑跑
        
        }

        //点击设置按钮事件
        private void setup_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.khead = khead_textBox.Text;
            Properties.Settings.Default.kxt = kxt_textBox.Text;
            Properties.Settings.Default.kc = kc_textBox.Text;
            Properties.Settings.Default.kr = kr_textBox.Text;
            //盘旋
            Properties.Settings.Default.l1guide_dr = l1guide_dr_textBox.Text;
            Properties.Settings.Default.l1guide_kig = l1guide_kig_textBox.Text;
            Properties.Settings.Default.l1guide_p = l1guide_p_textBox.Text;
            //L1导引
            Properties.Settings.Default.throttle_d = throttle_d_textBox.Text;
            Properties.Settings.Default.throttle_t = throttle_t_textBox.Text;
            Properties.Settings.Default.throttle_i = throttle_i_textBox.Text;
            Properties.Settings.Default.throttle_turn = throttle_turn_textBox.Text;
            //油门
            Properties.Settings.Default.pitch_kw = pitch_kw_textBox.Text;
            Properties.Settings.Default.pitch_i = pitch_i_textBox.Text;
            Properties.Settings.Default.pitch_t = pitch_t_textBox.Text;
            Properties.Settings.Default.pitch_d = pitch_d_textBox.Text;
            //俯仰
            Properties.Settings.Default.kspd = kspd_textBox.Text;
            Properties.Settings.Default.kspdd = kspdd_textBox.Text;
            Properties.Settings.Default.kspdi = kspdi_textBox.Text;
            //速度
            Properties.Settings.Default.kh = kh_textBox.Text;
            Properties.Settings.Default.khi = khi_textBox.Text;
            Properties.Settings.Default.khd = khd_textBox.Text;
            Properties.Settings.Default.jfmx = jfmxS_textBox.Text;
            //高度
            Properties.Settings.Default.kpd = kpd_textBox.Text;
            Properties.Settings.Default.kid = kid_textBox.Text;
            Properties.Settings.Default.kdd = kdd_textBox.Text;
            
            //滑跑
            Properties.Settings.Default.Save();
            //点击设置保存第二个文本框中的数据

            //检验参数数据类型是否合法
            bool checkresult = true;
            float check;
            if (!float.TryParse(this.khead_textBox.Text, out check))
            {
                this.khead_textBox.ForeColor = Color.Red;
                checkresult = false;
            }else
            {
                this.khead_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kxt_textBox.Text, out check))
            {
                this.kxt_textBox.ForeColor = Color.Red;
                checkresult = false;
            }else
            {
                this.kxt_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kc_textBox.Text, out check))
            {
                this.kc_textBox.ForeColor = Color.Red;
                checkresult = false;
            }else
            {
                this.kc_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kr_textBox.Text, out check))
            {
                this.kr_textBox.ForeColor = Color.Red;
                checkresult = false;
            }else
            {
                this.kr_textBox.ForeColor = Color.Black;
            }//盘旋



            if (!float.TryParse(this.l1guide_dr_textBox.Text, out check))
            {
                this.l1guide_dr_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.l1guide_dr_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.l1guide_p_textBox.Text, out check))
            {
                this.l1guide_p_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.l1guide_p_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.l1guide_kig_textBox.Text, out check))
            {
                this.l1guide_kig_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.l1guide_kig_textBox.ForeColor = Color.Black;
            }//L1导引




            if (!float.TryParse(this.throttle_t_textBox.Text, out check))
            {
                this.throttle_t_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.throttle_t_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.throttle_d_textBox.Text, out check))
            {
                this.throttle_d_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.throttle_d_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.throttle_i_textBox.Text, out check))
            {
                this.throttle_i_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.throttle_i_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.throttle_turn_textBox.Text, out check))
            {
                this.throttle_turn_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.throttle_turn_textBox.ForeColor = Color.Black;
            }//油门



            if (!float.TryParse(this.pitch_kw_textBox.Text, out check))
            {
                this.pitch_kw_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pitch_kw_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.pitch_i_textBox.Text, out check))
            {
                this.pitch_i_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pitch_i_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.pitch_t_textBox.Text, out check))
            {
                this.pitch_t_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pitch_t_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.pitch_d_textBox.Text, out check))
            {
                this.pitch_d_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.pitch_d_textBox.ForeColor = Color.Black;
            }//俯仰



            if (!float.TryParse(this.kspd_textBox.Text, out check))
            {
                this.kspd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kspd_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kspdi_textBox.Text, out check))
            {
                this.kspdi_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kspdi_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kspdd_textBox.Text, out check))
            {
                this.kspdd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kspdd_textBox.ForeColor = Color.Black;
            }//速度




            if (!float.TryParse(this.kh_textBox.Text, out check))
            {
                this.kh_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kh_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.khi_textBox.Text, out check))
            {
                this.khi_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.khi_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.khd_textBox.Text, out check))
            {
                this.khd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.khd_textBox.ForeColor = Color.Black;
            }//高度




            if (!float.TryParse(this.kpd_textBox.Text, out check))
            {
                this.kpd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kpd_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kid_textBox.Text, out check))
            {
                this.kid_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kid_textBox.ForeColor = Color.Black;
            }
            if (!float.TryParse(this.kdd_textBox.Text, out check))
            {
                this.kdd_textBox.ForeColor = Color.Red;
                checkresult = false;
            }
            else
            {
                this.kdd_textBox.ForeColor = Color.Black;
            }

            if (checkresult == false)
            {
                return;
            }//滑跑

      
            JYLink.jylink_guidectrl_param_setup guidectrlparam = new JYLink.jylink_guidectrl_param_setup();
            guidectrlparam.khead = Single.Parse(khead_textBox.Text);
            guidectrlparam.kxt = Single.Parse(kxt_textBox.Text);
            guidectrlparam.kc = Single.Parse(kc_textBox.Text);
            guidectrlparam.kr = Single.Parse(kr_textBox.Text);

            guidectrlparam.l1guide_dr = Single.Parse(l1guide_dr_textBox.Text);
            guidectrlparam.l1guide_p = Single.Parse(l1guide_p_textBox.Text);
            guidectrlparam.l1guide_kig = Single.Parse(l1guide_kig_textBox.Text);

            guidectrlparam.throttle_t = Single.Parse(throttle_t_textBox.Text);
            guidectrlparam.throttle_d = Single.Parse(throttle_d_textBox.Text);
            guidectrlparam.throttle_i = Single.Parse(throttle_i_textBox.Text);
            guidectrlparam.throttle_turn = Single.Parse(throttle_turn_textBox.Text);

            guidectrlparam.pitch_kw = Single.Parse(pitch_kw_textBox.Text);
            guidectrlparam.pitch_i = Single.Parse(pitch_i_textBox.Text);
            guidectrlparam.pitch_t = Single.Parse(pitch_t_textBox.Text);
            guidectrlparam.pitch_d = Single.Parse(pitch_d_textBox.Text);

            guidectrlparam.kspd = Single.Parse(kspd_textBox.Text);
            guidectrlparam.kspdi = Single.Parse(kspdi_textBox.Text);
            guidectrlparam.kspdd = Single.Parse(kspdd_textBox.Text);

            guidectrlparam.kh = Single.Parse(kh_textBox.Text);
            guidectrlparam.khi = Single.Parse(khi_textBox.Text);
            guidectrlparam.khd = Single.Parse(khd_textBox.Text);
            guidectrlparam.jfmx = Single.Parse(jfmxS_textBox.Text);

            guidectrlparam.kpd = Single.Parse(kpd_textBox.Text);
            guidectrlparam.kid = Single.Parse(kid_textBox.Text);
            guidectrlparam.kdd = Single.Parse(kdd_textBox.Text);

            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将制导参数内容发送到飞控
            bool result = port.setupGuideCtrl(guidectrlparam);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("制导参数设置成功");
            }
            else
            {
                MessageBox.Show("制导参数设置失败"); 
            }
        }


        //页面加载事件
        private void GuideCtrlView_Load(object sender, EventArgs e)
        {
            //页面加载时显示保存的参数
            khead_textBox.Text = Properties.Settings.Default.khead;
            kxt_textBox.Text = Properties.Settings.Default.kxt;
            kc_textBox.Text = Properties.Settings.Default.kc;
            kr_textBox.Text = Properties.Settings.Default.kr;
            //盘旋
            l1guide_dr_textBox.Text = Properties.Settings.Default.l1guide_dr;
            l1guide_p_textBox.Text = Properties.Settings.Default.l1guide_p;
            l1guide_kig_textBox.Text = Properties.Settings.Default.l1guide_kig;
            //L1导引
            throttle_t_textBox.Text = Properties.Settings.Default.throttle_t;
            throttle_d_textBox.Text = Properties.Settings.Default.throttle_d;
            throttle_i_textBox.Text = Properties.Settings.Default.throttle_i;
            throttle_turn_textBox.Text = Properties.Settings.Default.throttle_turn;
            //油门
            pitch_kw_textBox.Text = Properties.Settings.Default.pitch_kw;
            pitch_i_textBox.Text = Properties.Settings.Default.pitch_i;
            pitch_t_textBox.Text = Properties.Settings.Default.pitch_t;
            pitch_d_textBox.Text = Properties.Settings.Default.pitch_d;
            //俯仰
            kspd_textBox.Text = Properties.Settings.Default.kspd;
            kspdi_textBox.Text = Properties.Settings.Default.kspdi;
            kspdd_textBox.Text = Properties.Settings.Default.kspdd;
            //速度
            kh_textBox.Text = Properties.Settings.Default.kh;
            khi_textBox.Text = Properties.Settings.Default.khi;
            khd_textBox.Text = Properties.Settings.Default.khd;
            //高度
            kpd_textBox.Text = Properties.Settings.Default.kpd;
            kid_textBox.Text = Properties.Settings.Default.kid;
            kdd_textBox.Text = Properties.Settings.Default.kdd;
            jfmxS_textBox.Text = Properties.Settings.Default.jfmx;
            //滑跑
        }

        //点击导出按钮事件
        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "制导参数.txt";

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
                    sw.WriteLine(this.khead_textBox.Text);
                    sw.WriteLine(this.kxt_textBox.Text);
                    sw.WriteLine(this.kc_textBox.Text);
                    sw.WriteLine(this.kr_textBox.Text);
                    //在文件中写入盘旋参数

                    sw.WriteLine(this.l1guide_dr_textBox.Text);
                    sw.WriteLine(this.l1guide_p_textBox.Text);
                    sw.WriteLine(this.l1guide_kig_textBox.Text);
                    //在文件中写入L1导引参数

                    sw.WriteLine(this.throttle_t_textBox.Text);
                    sw.WriteLine(this.throttle_d_textBox.Text);
                    sw.WriteLine(this.throttle_i_textBox.Text);
                    sw.WriteLine(this.throttle_turn_textBox.Text);
                    //在文件中写入油门参数

                    sw.WriteLine(this.pitch_kw_textBox.Text);
                    sw.WriteLine(this.pitch_i_textBox.Text);
                    sw.WriteLine(this.pitch_t_textBox.Text);
                    sw.WriteLine(this.pitch_d_textBox.Text);
                    //在文件中写入俯仰参数

                    sw.WriteLine(this.kspd_textBox.Text);
                    sw.WriteLine(this.kspdi_textBox.Text);
                    sw.WriteLine(this.kspdd_textBox.Text);
                    //在文件中写入速度参数

                    sw.WriteLine(this.kh_textBox.Text);
                    sw.WriteLine(this.khi_textBox.Text);
                    sw.WriteLine(this.khd_textBox.Text);
                    sw.WriteLine(this.jfmxS_textBox.Text);
                    //在文件中写入高度参数

                    sw.WriteLine(this.kpd_textBox.Text);
                    sw.WriteLine(this.kid_textBox.Text);
                    sw.WriteLine(this.kdd_textBox.Text);
                    //在文件中写入滑跑参数




                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //sr.WriteLine(this.textBox3.Text.Trim() + "+" + this.textBox4.Text);//开始写入值
                    
                    sr.WriteLine(this.khead_textBox.Text);
                    sr.WriteLine(this.kxt_textBox.Text);
                    sr.WriteLine(this.kc_textBox.Text);
                    sr.WriteLine(this.kr_textBox.Text);
                    //盘旋

                    sr.WriteLine(this.l1guide_dr_textBox.Text);
                    sr.WriteLine(this.l1guide_p_textBox.Text);
                    sr.WriteLine(this.l1guide_kig_textBox.Text);
                    //L1导引

                    sr.WriteLine(this.throttle_t_textBox.Text);
                    sr.WriteLine(this.throttle_d_textBox.Text);
                    sr.WriteLine(this.throttle_i_textBox.Text);
                    sr.WriteLine(this.throttle_turn_textBox.Text);
                    //油门

                    sr.WriteLine(this.pitch_kw_textBox.Text);
                    sr.WriteLine(this.pitch_i_textBox.Text);
                    sr.WriteLine(this.pitch_t_textBox.Text);
                    sr.WriteLine(this.pitch_d_textBox.Text);
                    //俯仰

                    sr.WriteLine(this.kspd_textBox.Text);
                    sr.WriteLine(this.kspdi_textBox.Text);
                    sr.WriteLine(this.kspdd_textBox.Text);
                    //速度

                    sr.WriteLine(this.kh_textBox.Text);
                    sr.WriteLine(this.khi_textBox.Text);
                    sr.WriteLine(this.khd_textBox.Text);
                    sr.WriteLine(this.jfmxS_textBox.Text);
                    //高度

                    sr.WriteLine(this.kpd_textBox.Text);
                    sr.WriteLine(this.kid_textBox.Text);
                    sr.WriteLine(this.kdd_textBox.Text);
                    //滑跑
                    //sw.Flush();//文件流
                    //sw.Close();//最后要关闭写入状态
                    sr.Close();
                    fs.Close();
                }

            }

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
                //从文件中读取参数的值并写入第二个文本框中

                this.khead_textBox.Text = array[0];
                this.kxt_textBox.Text = array[1];
                this.kc_textBox.Text = array[2];
                this.kr_textBox.Text = array[3];
                //盘旋

                this.l1guide_dr_textBox.Text = array[4];
                this.l1guide_p_textBox.Text = array[5];
                this.l1guide_kig_textBox.Text = array[6];
                //L1导引

                this.throttle_t_textBox.Text = array[7];
                this.throttle_d_textBox.Text = array[8];
                this.throttle_i_textBox.Text = array[9];
                this.throttle_turn_textBox.Text = array[10];
                //油门

                this.pitch_kw_textBox.Text = array[11];
                this.pitch_i_textBox.Text = array[12];
                this.pitch_t_textBox.Text = array[13];
                this.pitch_d_textBox.Text = array[14];
                //俯仰

                this.kspd_textBox.Text = array[15];
                this.kspdi_textBox.Text = array[16];
                this.kspdd_textBox.Text = array[17];
                //速度

                this.kh_textBox.Text = array[18];
                this.khi_textBox.Text = array[19];
                this.khd_textBox.Text = array[20];
                this.jfmxS_textBox.Text = array[21];
                //高度


                this.kpd_textBox.Text = array[22];
                this.kid_textBox.Text = array[23];
                this.kdd_textBox.Text = array[24];
                //滑跑

            }
           
        }

    }
}