using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Kongyu : Form
    {
        private JYLink.jylink_kongyu_param MicroParam = new JYLink.jylink_kongyu_param();

        PointLatLng[] Kongyuu = new PointLatLng[8]; 
        public Kongyu()
        {
            InitializeComponent();
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
                st = new System.IO.StreamReader(localFilePath, System.Text.Encoding.GetEncoding("GB2312"));
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
                search_vs.Text = array[0];
                search_fws.Text = array[1];
                get_modes.Text = array[2];
                search_times.Text = array[3];
                zp_hzs.Text = array[4];
                zp_fws.Text = array[5];
                mc_hzs.Text = array[6];
                cp_xxs.Text = array[7];
                ky5lng.Text = array[8];
                ky5lat.Text = array[9];
                ky6lng.Text = array[10];
                ky6lat.Text = array[11];
                ky7lng.Text = array[12];
                ky7lat.Text = array[13];
                ky8lng.Text = array[14];
                ky8lat.Text = array[15];
                cp_sxs.Text = array[16];
                mc_kds.Text = array[17];
                bm_modes.Text = array[18];
                isrunset.Text = array[19];
            }
        }

        private void Kongyu_Load(object sender, EventArgs e)
        {
            search_vs.Text = Properties.Settings.Default.search_vs;
            search_fws.Text = Properties.Settings.Default.search_fws;
            get_modes.Text = Properties.Settings.Default.get_modes;
            search_times.Text = Properties.Settings.Default.search_times;
            zp_hzs.Text = Properties.Settings.Default.zp_hzs;
            zp_fws.Text = Properties.Settings.Default.zp_fws;
            mc_hzs.Text = Properties.Settings.Default.mc_hzs;
            cp_xxs.Text = Properties.Settings.Default.cp_xxs;
            ky5lng.Text = Properties.Settings.Default.lng5;
            ky6lng.Text = Properties.Settings.Default.lng6;
            ky5lat.Text = Properties.Settings.Default.lat5;
            ky6lat.Text = Properties.Settings.Default.lat6;
            ky7lng.Text = Properties.Settings.Default.lng7;
            ky7lat.Text = Properties.Settings.Default.lat7;
            ky8lng.Text = Properties.Settings.Default.lng8;
            ky8lat.Text = Properties.Settings.Default.lat8;
            cp_sxs.Text = Properties.Settings.Default.cp_sxs;
            mc_kds.Text = Properties.Settings.Default.mc_kds;
            bm_modes.Text = Properties.Settings.Default.bm_modes;
            isrunset.Text = Properties.Settings.Default.isrun;
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "空域参数.txt";

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


                    sw.WriteLine(search_vs.Text);
                    sw.WriteLine(search_fws.Text);
                    sw.WriteLine(get_modes.Text);
                    sw.WriteLine(search_times.Text);
                    sw.WriteLine(zp_hzs.Text);
                    sw.WriteLine(zp_fws.Text);
                    sw.WriteLine(mc_hzs.Text);
                    sw.WriteLine(cp_xxs.Text);
                    sw.WriteLine(ky5lng.Text);
                    sw.WriteLine(ky5lat.Text);
                    sw.WriteLine(ky6lng.Text);
                    sw.WriteLine(ky6lat.Text);
                    sw.WriteLine(ky7lng.Text);
                    sw.WriteLine(ky7lat.Text);
                    sw.WriteLine(ky8lng.Text);
                    sw.WriteLine(ky8lat.Text);
                    sw.WriteLine(cp_sxs.Text);
                    sw.WriteLine(mc_kds.Text);
                    sw.WriteLine(bm_modes.Text);
                    sw.WriteLine(isrunset.Text);


                    //在文件中写入参数
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));

                    //开始写入值

                    sr.WriteLine(search_vs.Text);
                    sr.WriteLine(search_fws.Text);
                    sr.WriteLine(get_modes.Text);
                    sr.WriteLine(search_times.Text);
                    sr.WriteLine(zp_hzs.Text);
                    sr.WriteLine(zp_fws.Text);
                    sr.WriteLine(mc_hzs.Text);
                    sr.WriteLine(cp_xxs.Text);
                    sr.WriteLine(ky5lng.Text);
                    sr.WriteLine(ky5lat.Text);
                    sr.WriteLine(ky6lng.Text);
                    sr.WriteLine(ky6lat.Text);
                    sr.WriteLine(ky7lng.Text);
                    sr.WriteLine(ky7lat.Text);
                    sr.WriteLine(ky8lng.Text);
                    sr.WriteLine(ky8lat.Text);
                    sr.WriteLine(cp_sxs.Text);
                    sr.WriteLine(mc_kds.Text);
                    sr.WriteLine(bm_modes.Text);
                    sr.WriteLine(isrunset.Text);

                    sr.Close();
                    fs.Close();
                }

            }
        }
        private void update()
        {
            search_v.Text = MicroParam.lng1.ToString();
            search_fw.Text = MicroParam.lat1.ToString();
            get_mode.Text = MicroParam.lng2.ToString();
            search_time.Text = MicroParam.lat2.ToString();
            zp_hz.Text = MicroParam.lng3.ToString();
            zp_fw.Text = MicroParam.lat3.ToString();
            mc_hz.Text = MicroParam.lng4.ToString();
            cp_xx.Text = MicroParam.lat4.ToString();
            ky5lngc.Text = MicroParam.lng5.ToString();
            ky5latc.Text = MicroParam.lat5.ToString();
            ky6lngc.Text = MicroParam.lng6.ToString();
            ky6latc.Text = MicroParam.lat6.ToString();
            ky7lngc.Text = MicroParam.lng7.ToString();
            ky7latc.Text = MicroParam.lat7.ToString();
            ky8lngc.Text = MicroParam.lng8.ToString();
            ky8latc.Text = MicroParam.lat8.ToString();
            cp_sx.Text = MicroParam.yujing_l.ToString();
            mc_kd.Text = MicroParam.guihang_l.ToString();
            bm_mode.Text = MicroParam.kaisan_l.ToString(); ;
            isrun.Text = isrunset.Items[MicroParam.isrun].ToString();
        }
        private void search_button_Click(object sender, System.EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                //弹框显示请先连接！
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            MicroParam = port.searchKongyu();
            update();
            if (MicroParam.lng1 != 0 && MicroParam.lng2 != 0 && MicroParam.lng3 != 0 && MicroParam.lng4 != 0)
            {
                Kongyuu[0].Lng = MicroParam.lng1;
                Kongyuu[0].Lat = MicroParam.lat1;
                Kongyuu[1].Lng = MicroParam.lng2;
                Kongyuu[1].Lat = MicroParam.lat2;
                Kongyuu[2].Lng = MicroParam.lng3;
                Kongyuu[2].Lat = MicroParam.lat3;
                Kongyuu[3].Lng = MicroParam.lng4;
                Kongyuu[3].Lat = MicroParam.lat4;
                Kongyuu[4].Lng = MicroParam.lng5;
                Kongyuu[4].Lat = MicroParam.lat5;
                Kongyuu[5].Lng = MicroParam.lng6;
                Kongyuu[5].Lat = MicroParam.lat6;
                Kongyuu[6].Lng = MicroParam.lng7;
                Kongyuu[6].Lat = MicroParam.lat7;
                Kongyuu[7].Lng = MicroParam.lng8;
                Kongyuu[7].Lat = MicroParam.lat8;
                MainForm.instance.setKongyu_ItemClick(Kongyuu);
            }
            if (MicroParam.isrun == 1)
            {
                MainForm.instance.isrun = true;
            }
            else
            {
                MainForm.instance.isrun = false;
            }
        }

        private void setup_button_Click(object sender, System.EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
                throw new Exception("请先连接!");
            }
            try
            {


                Properties.Settings.Default.search_vs = search_vs.Text;
                Properties.Settings.Default.search_fws = search_fws.Text;
                Properties.Settings.Default.get_modes = get_modes.Text;
                Properties.Settings.Default.search_times = search_times.Text;
                Properties.Settings.Default.zp_hzs = zp_hzs.Text;
                Properties.Settings.Default.zp_fws = zp_fws.Text;
                Properties.Settings.Default.mc_hzs = mc_hzs.Text;
                Properties.Settings.Default.cp_xxs = cp_xxs.Text;
                Properties.Settings.Default.lng5 = ky5lng.Text;
                Properties.Settings.Default.lng6 = ky6lng.Text;
                Properties.Settings.Default.lat5 = ky5lat.Text;
                Properties.Settings.Default.lat6 = ky6lat.Text;
                Properties.Settings.Default.lng7 = ky7lng.Text;
                Properties.Settings.Default.lng8 = ky8lng.Text;
                Properties.Settings.Default.lat7 = ky7lat.Text;
                Properties.Settings.Default.lat8 = ky8lat.Text;
                Properties.Settings.Default.cp_sxs = cp_sxs.Text;
                Properties.Settings.Default.mc_kds = mc_kds.Text;
                Properties.Settings.Default.bm_modes = bm_modes.Text;
                Properties.Settings.Default.isrun = isrunset.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                return;
                throw new Exception("输入字符不能为空!"); ;
            }

            JYLink.jylink_kongyu_param microparam = new JYLink.jylink_kongyu_param();

            Kongyuu[0].Lng = microparam.lng1 = float.Parse(search_vs.Text);
            Kongyuu[0].Lat = microparam.lat1 = float.Parse(search_fws.Text);
            Kongyuu[1].Lng = microparam.lng2 = float.Parse(get_modes.Text);
            Kongyuu[1].Lat = microparam.lat2 = float.Parse(search_times.Text);
            Kongyuu[2].Lng = microparam.lng3 = float.Parse(zp_hzs.Text);
            Kongyuu[2].Lat = microparam.lat3 = float.Parse(zp_fws.Text);
            Kongyuu[3].Lng = microparam.lng4 = float.Parse(mc_hzs.Text);
            Kongyuu[3].Lat = microparam.lat4 = float.Parse(cp_xxs.Text);
            Kongyuu[4].Lng = microparam.lng5 = float.Parse(ky5lng.Text);
            Kongyuu[4].Lat = microparam.lat5 = float.Parse(ky5lat.Text);
            Kongyuu[5].Lng = microparam.lng6 = float.Parse(ky6lng.Text);
            Kongyuu[5].Lat = microparam.lat6 = float.Parse(ky6lat.Text);
            Kongyuu[6].Lng = microparam.lng7 = float.Parse(ky7lng.Text);
            Kongyuu[6].Lat = microparam.lat7 = float.Parse(ky7lat.Text);
            Kongyuu[7].Lng = microparam.lng8 = float.Parse(ky8lng.Text);
            Kongyuu[7].Lat = microparam.lat8 = float.Parse(ky8lat.Text);
            microparam.yujing_l = float.Parse(cp_sxs.Text);
            microparam.guihang_l = float.Parse(mc_kds.Text);
            microparam.kaisan_l = float.Parse(bm_modes.Text);
            if (isrunset.SelectedIndex > -1)
            {
                microparam.isrun = (byte)isrunset.SelectedIndex;
            }
            else
            {
                microparam.isrun = 0;
            }



            //将参数内容发送到飞控
            bool result = port.setupKongyu(microparam);
            //result = true;
            //判断执行结果
            if (result)
            {
                if (microparam.isrun == 1)
                {
                    MainForm.instance.isrun = true;
                }
                else
                {
                    MainForm.instance.isrun = false;
                }

                MainForm.instance.setKongyu_ItemClick(Kongyuu);
                MessageBox.Show("参数设置成功");
            }
            else
            {
                MessageBox.Show("参数设置失败");
            }
        }
    }
}
