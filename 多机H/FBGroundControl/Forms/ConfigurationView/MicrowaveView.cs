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
    public partial class MicrowaveView : UserControl 
    {

       //定义一个用于查询、更新页面的对象
        private JYLink.jylink_Micro_param_down MicroParam = new JYLink.jylink_Micro_param_down();
        Microwave micro = new Microwave();
        public static List<JYLink.jylink_xb_status_down> xbsum_m = new List<JYLink.jylink_xb_status_down>();
        public static string id
        {
            set;
            get;
        }
        public static double lat
        {
            set;
            get;
        }
        public static double lng
        {
            set;
            get;
        }
        public MicrowaveView()
        {
            InitializeComponent();

        }

        //点击查询按钮事件
        private void search_button_Click(object sender, EventArgs e)
        {

            //更新页面
        }

        private void update()
        {
            search_v.Text = MicroParam.search_vs.ToString();
            search_fw.Text = MicroParam.search_fws.ToString();
            if (MicroParam.get_modes>0)
            {
                get_mode.Text = get_modes.Items[MicroParam.get_modes - 1].ToString();  
            }
            else
            {
                get_mode.Text = "0";
            }
            
            zdyf0_c.Text = MicroParam.zp_hzs.ToString();
            jbfw_c.Text = MicroParam.zp_fws.ToString();
            sszq_c.Text = MicroParam.search_times.ToString();
            cfzq_c.Text = MicroParam.mc_hzs.ToString();
            mckd_c.Text = MicroParam.lmf_dks.ToString();
            if (MicroParam.bm_modes>0)
            {
                xcxh_c.Text = xcxh_t.Items[MicroParam.bm_modes - 1].ToString();  
            }
            else
            {
                xcxh_c.Text = "0";
            }
            ld_id_c.Text = MicroParam.micro_ids.ToString();
            kdj_id_c.Text = MicroParam.zkdj_ids.ToString();
            kj_l.Text = (MicroParam.kj_ls/10.0).ToString("N1");
            jq_l.Text = (MicroParam.jq_ls/10.0).ToString("N1");
            zj_lng_c.Text = DuFenMiao(MicroParam.zkdj_lngs);
            zj_lat_c.Text = DuFenMiao(MicroParam.zkdj_lats);
            if (MicroParam.pz_sj>0)
            {
              pzglsj_c.Text = pzglsj_t.Items[MicroParam.pz_sj - 1].ToString();  
            }
            else
            {
                pzglsj_c.Text = "0";     
            }
            if (MicroParam.gf_sj>0)
            {
                gfglsj_c.Text = gfglsj_t.Items[MicroParam.gf_sj - 1].ToString();  
            }
            else
            {
                gfglsj_c.Text = "0";
            }
            if (MicroParam.jd_kg>0)
            {
                jdkgj_c.Text = jdkgj_t.Items[MicroParam.jd_kg - 1].ToString();  
            }
            else
            {
                jdkgj_c.Text = "0";
            }
            

            fxpt_lx_c.Text = Properties.Settings.Default.fxpt_lx_t;
            fxpt_bh_c.Text= Properties.Settings.Default.fxpt_bh_t;
            fxpt_id_c.Text=Properties.Settings.Default.fxpt_id_t;
            zj_lx_c.Text = Properties.Settings.Default.zj_lx_t;
            zj_xh_c.Text = Properties.Settings.Default.zj_xh_t;
            zj_id_c.Text = Properties.Settings.Default.zj_id_t;
            //zj_lng_c.Text = Properties.Settings.Default.zj_lng_d + "°" + Properties.Settings.Default.zj_lng_f + "‘" + Properties.Settings.Default.zj_lng_m + "”";
            //zj_lat_c.Text = Properties.Settings.Default.zj_lat_d + "°" + Properties.Settings.Default.zj_lat_f + "‘" + Properties.Settings.Default.zj_lat_m + "”";
            zj_ys_c.Text = Properties.Settings.Default.zj_ys_t;
            kdj_count_c.Text = Properties.Settings.Default.kdj_count;
            cxj1_xh_c.Text = Properties.Settings.Default.cxj1_xh_t;
            cxj1_id_c.Text = Properties.Settings.Default.cxj1_id_t;
            cxj1_lng_c.Text = Properties.Settings.Default.cxj1_lng_d + "°" + Properties.Settings.Default.cxj1_lng_f + "‘" + Properties.Settings.Default.cxj1_lng_m + "”";
            cxj1_lat_c.Text = Properties.Settings.Default.cxj1_lat_d + "°" + Properties.Settings.Default.cxj1_lat_f + "‘" + Properties.Settings.Default.cxj1_lat_m + "”";
            cxj2_xh_c.Text = Properties.Settings.Default.cxj2_xh_t;
            cxj2_id_c.Text = Properties.Settings.Default.cxj2_id_t;
            cxj2_lng_c.Text = Properties.Settings.Default.cxj2_lng_d + "°" + Properties.Settings.Default.cxj2_lng_f + "‘" + Properties.Settings.Default.cxj2_lng_m + "”";
            cxj2_lat_c.Text = Properties.Settings.Default.cxj2_lat_d + "°" + Properties.Settings.Default.cxj2_lat_f + "‘" + Properties.Settings.Default.cxj2_lat_m + "”";
            cxj3_xh_c.Text = Properties.Settings.Default.cxj3_xh_t;
            cxj3_id_c.Text = Properties.Settings.Default.cxj3_id_t;
            cxj3_lng_c.Text = Properties.Settings.Default.cxj3_lng_d + "°" + Properties.Settings.Default.cxj3_lng_f + "‘" + Properties.Settings.Default.cxj3_lng_m + "”";
            cxj3_lat_c.Text = Properties.Settings.Default.cxj3_lat_d + "°" + Properties.Settings.Default.cxj3_lat_f + "‘" + Properties.Settings.Default.cxj3_lat_m + "”";
            cxj4_xh_c.Text = Properties.Settings.Default.cxj4_xh_t;
            cxj4_id_c.Text = Properties.Settings.Default.cxj4_id_t;
            cxj4_lng_c.Text = Properties.Settings.Default.cxj4_lng_d + "°" + Properties.Settings.Default.cxj4_lng_f + "‘" + Properties.Settings.Default.cxj4_lng_m + "”";
            cxj4_lat_c.Text = Properties.Settings.Default.cxj4_lat_d + "°" + Properties.Settings.Default.cxj4_lat_f + "‘" + Properties.Settings.Default.cxj4_lat_m + "”";
            wby_style_c.Text = Properties.Settings.Default.wby_style;
            zppl_c.Text= Properties.Settings.Default.zppl_t;
            //zdyf0_c.Text=Properties.Settings.Default.zdyf0;
             // Properties.Settings.Default.jbfw = jbfw.Text;
            //xcxh_c.Text=Properties.Settings.Default.xcxh_t;
            //Properties.Settings.Default.pzglsj_t = pzglsj_t.Text;
            //Properties.Settings.Default.gfglsj_t = gfglsj_t.Text;
            //Properties.Settings.Default.cfzq_t = cfzq_t.Text;
            //Properties.Settings.Default.mckd_t = mckd_t.Text;
            //Properties.Settings.Default.kj_ls = kj_ls.Text;
           // Properties.Settings.Default.jq_ls = jq_ls.Text;
            //Properties.Settings.Default.search_vs = search_vs.Text;
            //Properties.Settings.Default.search_fws = search_fws.Text;
           // Properties.Settings.Default.get_modes = get_modes.Text;
            //Properties.Settings.Default.sszq_t = sszq_t.Text;
            glglms_c.Text=Properties.Settings.Default.glglms_t;
            jdkgj_c.Text=Properties.Settings.Default.jdkgj_t ;
        
        
        }
        private string DuFenMiao(double temp)
        {
            double temp1, temp2;
            string dfm;
            temp1 = (temp - Math.Truncate(temp)) * 60;
            temp2 = (temp1 - Math.Truncate(temp1)) * 60;
            dfm = Math.Truncate(temp).ToString() + "°" + Math.Truncate(temp1).ToString() + "'" + temp2.ToString("0.00") + "''";
            return dfm;
        }
        private void MicroView_Load(object sender, EventArgs e)
        {
            Jtbiandui.Visible = false;
            zdyf0_l.Visible = false;
            zdyf0_c.Visible = false;
            zdyf0.Visible = false;
            zdyf0_l2.Visible = false;
            jbfw_l.Visible = false;
            jbfw_c.Visible = false;
            jbfw.Visible = false;
            jbfw_l2.Visible = false;
            sp_parm.Visible = false;
            jd_kgj.Visible = false;
            shebei_parm.Location = new System.Drawing.Point(16, 162);
            sp_parm.Location = new System.Drawing.Point(16, 233);
            jd_kgj.Location = new System.Drawing.Point(16, 383);

            fxpt_lx_t.Text = Properties.Settings.Default.fxpt_lx_t;
            fxpt_bh_t.Text = Properties.Settings.Default.fxpt_bh_t;
            fxpt_id_t.Text = Properties.Settings.Default.fxpt_id_t;
            zj_lx_t.Text = Properties.Settings.Default.zj_lx_t;
            zj_xh_t.Text = Properties.Settings.Default.zj_xh_t;
            zj_id_t.Text = Properties.Settings.Default.zj_id_t;
            zj_lng_d.Text = Properties.Settings.Default.zj_lng_d;
            zj_lng_f.Text = Properties.Settings.Default.zj_lng_f;
            zj_lng_m.Text =Properties.Settings.Default.zj_lng_m ;
            zj_lat_d.Text = Properties.Settings.Default.zj_lat_d;
            zj_lat_f.Text = Properties.Settings.Default.zj_lat_f;
            zj_lat_m.Text = Properties.Settings.Default.zj_lat_m;
            zj_ys_t.Text = Properties.Settings.Default.zj_ys_t;
            kdj_count.Text = Properties.Settings.Default.kdj_count;
            cxj1_xh_t.Text = Properties.Settings.Default.cxj1_xh_t;
            cxj1_id_t.Text = Properties.Settings.Default.cxj1_id_t;
            cxj1_lng_d.Text = Properties.Settings.Default.cxj1_lng_d;
            cxj1_lng_f.Text = Properties.Settings.Default.cxj1_lng_f;
            cxj1_lng_m.Text = Properties.Settings.Default.cxj1_lng_m ;
            cxj1_lat_d.Text = Properties.Settings.Default.cxj1_lat_d;
            cxj1_lat_f.Text = Properties.Settings.Default.cxj1_lat_f;
            cxj1_lat_m.Text = Properties.Settings.Default.cxj1_lat_m;
            cxj2_xh_t.Text = Properties.Settings.Default.cxj2_xh_t;
            cxj2_id_t.Text = Properties.Settings.Default.cxj2_id_t;
            cxj2_lng_d.Text = Properties.Settings.Default.cxj2_lng_d;
            cxj2_lng_f.Text = Properties.Settings.Default.cxj2_lng_f;
            cxj2_lng_m.Text = Properties.Settings.Default.cxj2_lng_m;
            cxj2_lat_d.Text = Properties.Settings.Default.cxj2_lat_d;
            cxj2_lat_f.Text = Properties.Settings.Default.cxj2_lat_f;
            cxj2_lat_m.Text = Properties.Settings.Default.cxj2_lat_m;
            cxj3_xh_t.Text = Properties.Settings.Default.cxj3_xh_t;
            cxj3_id_t.Text = Properties.Settings.Default.cxj3_id_t;
            cxj3_lng_d.Text = Properties.Settings.Default.cxj3_lng_d;
            cxj3_lng_f.Text = Properties.Settings.Default.cxj3_lng_f;
            cxj3_lng_m.Text = Properties.Settings.Default.cxj3_lng_m;
            cxj3_lat_d.Text = Properties.Settings.Default.cxj3_lat_d;
            cxj3_lat_f.Text = Properties.Settings.Default.cxj3_lat_f;
            cxj3_lat_m.Text = Properties.Settings.Default.cxj3_lat_m;
            cxj4_xh_t.Text = Properties.Settings.Default.cxj4_xh_t;
            cxj4_id_t.Text = Properties.Settings.Default.cxj4_id_t;
            cxj4_lng_d.Text = Properties.Settings.Default.cxj4_lng_d;
            cxj4_lng_f.Text = Properties.Settings.Default.cxj4_lng_f;
            cxj4_lng_m.Text = Properties.Settings.Default.cxj4_lng_m;
            cxj4_lat_d.Text = Properties.Settings.Default.cxj4_lat_d;
            cxj4_lat_f.Text = Properties.Settings.Default.cxj4_lat_f;
            cxj4_lat_m.Text = Properties.Settings.Default.cxj4_lat_m;
            wby_style.Text = Properties.Settings.Default.wby_style;
            zppl_t.Text = Properties.Settings.Default.zppl_t;
            zdyf0.Text=Properties.Settings.Default.zdyf0;
            jbfw.Text=Properties.Settings.Default.jbfw;
            xcxh_t.Text = Properties.Settings.Default.xcxh_t;
            pzglsj_t.Text=Properties.Settings.Default.pzglsj_t;
            gfglsj_t.Text=Properties.Settings.Default.gfglsj_t;
            cfzq_t.Text=Properties.Settings.Default.cfzq_t ;
            mckd_t.Text=Properties.Settings.Default.mckd_t;
            kj_ls.Text=Properties.Settings.Default.kj_ls;
            jq_ls.Text=Properties.Settings.Default.jq_ls;
            search_vs.Text=Properties.Settings.Default.search_vs;
            search_fws.Text=Properties.Settings.Default.search_fws;
            get_modes.Text=Properties.Settings.Default.get_modes;
            sszq_t.Text=Properties.Settings.Default.sszq_t;
            glglms_t.Text = Properties.Settings.Default.glglms_t;
            jdkgj_t.Text = Properties.Settings.Default.jdkgj_t;
        }

        //点击导ru按钮事件
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
                //从文件中读取参数值并写入到第二列文本框中
                string[] array = paramall.Split(';');
                fxpt_lx_t.Text=array[0];
                fxpt_bh_t.Text=array[1];
                fxpt_id_t.Text=array[2];
                zj_lx_t.Text=array[3];
                zj_xh_t.Text=array[4];
                zj_id_t.Text=array[5];
                zj_lng_d.Text=array[6];
                zj_lng_f.Text=array[7];
                zj_lng_m.Text=array[8];
                zj_lat_d.Text=array[9];
                zj_lat_f.Text=array[10];
                zj_lat_m.Text=array[11];
                zj_ys_t.Text=array[12];

                kdj_count.Text=array[13];
                cxj1_xh_t.Text=array[14];
                cxj1_id_t.Text=array[15];
                cxj1_lng_d.Text=array[16];
                cxj1_lng_f.Text=array[17];
                cxj1_lng_m.Text=array[18];
                cxj1_lat_d.Text=array[19];
                cxj1_lat_f.Text=array[20];
                cxj1_lat_m.Text=array[21];
                cxj2_xh_t.Text=array[22];
                cxj2_id_t.Text=array[23];
                cxj2_lng_d.Text=array[24];
                cxj2_lng_f.Text=array[25];
                cxj2_lng_m.Text=array[26];
                cxj2_lat_d.Text=array[27];
                cxj2_lat_f.Text=array[28];
                cxj2_lat_m.Text=array[29];
                cxj3_xh_t.Text=array[30];
                cxj3_id_t.Text=array[31];
                cxj3_lng_d.Text=array[32];
                cxj3_lng_f.Text=array[33];
                cxj3_lng_m.Text=array[34];
                cxj3_lat_d.Text=array[35];
                cxj3_lat_f.Text=array[36];
                cxj3_lat_m.Text=array[37];
                cxj4_xh_t.Text=array[38];
                cxj4_id_t.Text=array[39];
                cxj4_lng_d.Text=array[40];
                cxj4_lng_f.Text=array[41];
                cxj4_lng_m.Text=array[42];
                cxj4_lat_d.Text=array[43];
                cxj4_lat_f.Text=array[44];
                cxj4_lat_m.Text=array[45];

                ld_id_t.Text=array[46];
                kdj_id_t.Text=array[47];
                wby_style.Text=array[48];

                zppl_t.Text=array[49];
                zdyf0.Text=array[50];
                jbfw.Text=array[51];
                xcxh_t.Text=array[52];
                pzglsj_t.Text=array[53];
                gfglsj_t.Text=array[54];
                cfzq_t.Text=array[55];
                mckd_t.Text=array[56];

                kj_ls.Text=array[57];
                jq_ls.Text=array[58];
                search_vs.Text=array[59];
                search_fws.Text=array[60];
                get_modes.Text=array[61];
                sszq_t.Text=array[62];
                glglms_t.Text=array[63];
                jdkgj_t.Text=array[64];

            }

        }


        
            

        //点击导chu按钮事件
        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "微波源参数.txt";

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
                    sw.WriteLine(fxpt_lx_t.Text);
                    sw.WriteLine(fxpt_bh_t.Text);
                    sw.WriteLine(fxpt_id_t.Text);
                    sw.WriteLine(zj_lx_t.Text);
                    sw.WriteLine(zj_xh_t.Text);
                    sw.WriteLine(zj_id_t.Text);
                    sw.WriteLine(zj_lng_d.Text);
                    sw.WriteLine(zj_lng_f.Text);
                    sw.WriteLine(zj_lng_m.Text);
                    sw.WriteLine(zj_lat_d.Text);
                    sw.WriteLine(zj_lat_f.Text);
                    sw.WriteLine(zj_lat_m.Text);
                    sw.WriteLine(zj_ys_t.Text);

                    sw.WriteLine(kdj_count.Text);
                    sw.WriteLine(cxj1_xh_t.Text);
                    sw.WriteLine(cxj1_id_t.Text);
                    sw.WriteLine(cxj1_lng_d.Text);
                    sw.WriteLine(cxj1_lng_f.Text);
                    sw.WriteLine(cxj1_lng_m.Text);
                    sw.WriteLine(cxj1_lat_d.Text);
                    sw.WriteLine(cxj1_lat_f.Text);
                    sw.WriteLine(cxj1_lat_m.Text);
                    sw.WriteLine(cxj2_xh_t.Text);
                    sw.WriteLine(cxj2_id_t.Text);
                    sw.WriteLine(cxj2_lng_d.Text);
                    sw.WriteLine(cxj2_lng_f.Text);
                    sw.WriteLine(cxj2_lng_m.Text);
                    sw.WriteLine(cxj2_lat_d.Text);
                    sw.WriteLine(cxj2_lat_f.Text);
                    sw.WriteLine(cxj2_lat_m.Text);
                    sw.WriteLine(cxj3_xh_t.Text);
                    sw.WriteLine(cxj3_id_t.Text);
                    sw.WriteLine(cxj3_lng_d.Text);
                    sw.WriteLine(cxj3_lng_f.Text);
                    sw.WriteLine(cxj3_lng_m.Text);
                    sw.WriteLine(cxj3_lat_d.Text);
                    sw.WriteLine(cxj3_lat_f.Text);
                    sw.WriteLine(cxj3_lat_m.Text);
                    sw.WriteLine(cxj4_xh_t.Text);
                    sw.WriteLine(cxj4_id_t.Text);
                    sw.WriteLine(cxj4_lng_d.Text);
                    sw.WriteLine(cxj4_lng_f.Text);
                    sw.WriteLine(cxj4_lng_m.Text);
                    sw.WriteLine(cxj4_lat_d.Text);
                    sw.WriteLine(cxj4_lat_f.Text);
                    sw.WriteLine(cxj4_lat_m.Text);

                    sw.WriteLine(ld_id_t.Text);
                    sw.WriteLine(kdj_id_t.Text);
                    sw.WriteLine(wby_style.Text);

                    sw.WriteLine(zppl_t.Text);
                    sw.WriteLine(zdyf0.Text);
                    sw.WriteLine(jbfw.Text);
                    sw.WriteLine(xcxh_t.Text);
                    sw.WriteLine(pzglsj_t.Text);
                    sw.WriteLine(gfglsj_t.Text);
                    sw.WriteLine(cfzq_t.Text);
                    sw.WriteLine(mckd_t.Text);

                    sw.WriteLine(kj_ls.Text);
                    sw.WriteLine(jq_ls.Text);
                    sw.WriteLine(search_vs.Text);
                    sw.WriteLine(search_fws.Text);
                    sw.WriteLine(get_modes.Text);
                    sw.WriteLine(sszq_t.Text);
                    sw.WriteLine(glglms_t.Text);
                    sw.WriteLine(jdkgj_t.Text);
                    //在文件中写入参数
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);

                    //开始写入值

                    sr.WriteLine(fxpt_lx_t.Text);
                    sr.WriteLine(fxpt_bh_t.Text);
                    sr.WriteLine(fxpt_id_t.Text);
                    sr.WriteLine(zj_lx_t.Text);
                    sr.WriteLine(zj_xh_t.Text);
                    sr.WriteLine(zj_id_t.Text);
                    sr.WriteLine(zj_lng_d.Text);
                    sr.WriteLine(zj_lng_f.Text);
                    sr.WriteLine(zj_lng_m.Text);
                    sr.WriteLine(zj_lat_d.Text);
                    sr.WriteLine(zj_lat_f.Text);
                    sr.WriteLine(zj_lat_m.Text);
                    sr.WriteLine(zj_ys_t.Text);

                    sr.WriteLine(kdj_count.Text);
                    sr.WriteLine(cxj1_xh_t.Text);
                    sr.WriteLine(cxj1_id_t.Text);
                    sr.WriteLine(cxj1_lng_d.Text);
                    sr.WriteLine(cxj1_lng_f.Text);
                    sr.WriteLine(cxj1_lng_m.Text);
                    sr.WriteLine(cxj1_lat_d.Text);
                    sr.WriteLine(cxj1_lat_f.Text);
                    sr.WriteLine(cxj1_lat_m.Text);
                    sr.WriteLine(cxj2_xh_t.Text);
                    sr.WriteLine(cxj2_id_t.Text);
                    sr.WriteLine(cxj2_lng_d.Text);
                    sr.WriteLine(cxj2_lng_f.Text);
                    sr.WriteLine(cxj2_lng_m.Text);
                    sr.WriteLine(cxj2_lat_d.Text);
                    sr.WriteLine(cxj2_lat_f.Text);
                    sr.WriteLine(cxj2_lat_m.Text);
                    sr.WriteLine(cxj3_xh_t.Text);
                    sr.WriteLine(cxj3_id_t.Text);
                    sr.WriteLine(cxj3_lng_d.Text);
                    sr.WriteLine(cxj3_lng_f.Text);
                    sr.WriteLine(cxj3_lng_m.Text);
                    sr.WriteLine(cxj3_lat_d.Text);
                    sr.WriteLine(cxj3_lat_f.Text);
                    sr.WriteLine(cxj3_lat_m.Text);
                    sr.WriteLine(cxj4_xh_t.Text);
                    sr.WriteLine(cxj4_id_t.Text);
                    sr.WriteLine(cxj4_lng_d.Text);
                    sr.WriteLine(cxj4_lng_f.Text);
                    sr.WriteLine(cxj4_lng_m.Text);
                    sr.WriteLine(cxj4_lat_d.Text);
                    sr.WriteLine(cxj4_lat_f.Text);
                    sr.WriteLine(cxj4_lat_m.Text);

                    sr.WriteLine(ld_id_t.Text);
                    sr.WriteLine(kdj_id_t.Text);
                    sr.WriteLine(wby_style.Text);

                    sr.WriteLine(zppl_t.Text);
                    sr.WriteLine(zdyf0.Text);
                    sr.WriteLine(jbfw.Text);
                    sr.WriteLine(xcxh_t.Text);
                    sr.WriteLine(pzglsj_t.Text);
                    sr.WriteLine(gfglsj_t.Text);
                    sr.WriteLine(cfzq_t.Text);
                    sr.WriteLine(mckd_t.Text);

                    sr.WriteLine(kj_ls.Text);
                    sr.WriteLine(jq_ls.Text);
                    sr.WriteLine(search_vs.Text);
                    sr.WriteLine(search_fws.Text);
                    sr.WriteLine(get_modes.Text);
                    sr.WriteLine(sszq_t.Text);
                    sr.WriteLine(glglms_t.Text);
                    sr.WriteLine(jdkgj_t.Text);


                    sr.Close();
                    fs.Close();
                }

            }
        }

        private void parm_set_Click(object sender, EventArgs e)
        {
            int[] zppl = new int[15] {0,100,200,300,-100,-200,-300,0,0,0,150,-150,0,0,0 };
            UInt16[] zpfw = new UInt16[15] { 0, 0, 0, 0, 0, 0, 0, 100, 200, 300, 100, 100, 0, 100, 200 };
            UInt16[] cfzq = new UInt16[9] { 500, 600, 700, 800, 900, 1000, 1100, 1200, 65535};  
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            try
            {

                Properties.Settings.Default.fxpt_lx_t= fxpt_lx_t.Text;
                Properties.Settings.Default.fxpt_bh_t= fxpt_bh_t.Text;
                Properties.Settings.Default.fxpt_id_t= fxpt_id_t.Text;
                Properties.Settings.Default.zj_lx_t= zj_lx_t.Text;
                Properties.Settings.Default.zj_xh_t= zj_xh_t.Text;
                Properties.Settings.Default.zj_id_t= zj_id_t.Text;
                Properties.Settings.Default.zj_lng_d= zj_lng_d.Text;
                Properties.Settings.Default.zj_lng_f= zj_lng_f.Text;
                Properties.Settings.Default.zj_lng_m= zj_lng_m.Text;
                Properties.Settings.Default.zj_lat_d= zj_lat_d.Text;
                Properties.Settings.Default.zj_lat_f= zj_lat_f.Text;
                Properties.Settings.Default.zj_lat_m= zj_lat_m.Text;
                Properties.Settings.Default.zj_ys_t=zj_ys_t.Text;
                Properties.Settings.Default.kdj_count= kdj_count.Text;
                Properties.Settings.Default.cxj1_xh_t= cxj1_xh_t.Text;
                Properties.Settings.Default.cxj1_id_t= cxj1_id_t.Text;
                Properties.Settings.Default.cxj1_lng_d= cxj1_lng_d.Text;
                Properties.Settings.Default.cxj1_lng_f= cxj1_lng_f.Text;
                Properties.Settings.Default.cxj1_lng_m= cxj1_lng_m.Text;
                Properties.Settings.Default.cxj1_lat_d= cxj1_lat_d.Text;
                Properties.Settings.Default.cxj1_lat_f= cxj1_lat_f.Text;
                Properties.Settings.Default.cxj1_lat_m= cxj1_lat_m.Text;
                Properties.Settings.Default.cxj2_xh_t= cxj2_xh_t.Text;
                Properties.Settings.Default.cxj2_id_t= cxj2_id_t.Text;
                Properties.Settings.Default.cxj2_lng_d= cxj2_lng_d.Text;
                Properties.Settings.Default.cxj2_lng_f= cxj2_lng_f.Text;
                Properties.Settings.Default.cxj2_lng_m= cxj2_lng_m.Text;
                Properties.Settings.Default.cxj2_lat_d= cxj2_lat_d.Text;
                Properties.Settings.Default.cxj2_lat_f= cxj2_lat_f.Text;
                Properties.Settings.Default.cxj2_lat_m= cxj2_lat_m.Text;
                Properties.Settings.Default.cxj3_xh_t= cxj3_xh_t.Text;
                Properties.Settings.Default.cxj3_id_t= cxj3_id_t.Text;
                Properties.Settings.Default.cxj3_lng_d= cxj3_lng_d.Text;
                Properties.Settings.Default.cxj3_lng_f= cxj3_lng_f.Text;
                Properties.Settings.Default.cxj3_lng_m= cxj3_lng_m.Text;
                Properties.Settings.Default.cxj3_lat_d= cxj3_lat_d.Text;
                Properties.Settings.Default.cxj3_lat_f= cxj3_lat_f.Text;
                Properties.Settings.Default.cxj3_lat_m= cxj3_lat_m.Text;
                Properties.Settings.Default.cxj4_xh_t= cxj4_xh_t.Text;
                Properties.Settings.Default.cxj4_id_t= cxj4_id_t.Text;
                Properties.Settings.Default.cxj4_lng_d= cxj4_lng_d.Text;
                Properties.Settings.Default.cxj4_lng_f= cxj4_lng_f.Text;
                Properties.Settings.Default.cxj4_lng_m= cxj4_lng_m.Text;
                Properties.Settings.Default.cxj4_lat_d= cxj4_lat_d.Text;
                Properties.Settings.Default.cxj4_lat_f= cxj4_lat_f.Text;
                Properties.Settings.Default.cxj4_lat_m= cxj4_lat_m.Text;
                Properties.Settings.Default.ld_id_t= ld_id_t.Text;
                Properties.Settings.Default.kdj_id_t= kdj_id_t.Text;
                Properties.Settings.Default.wby_style= wby_style.Text;
                Properties.Settings.Default.zppl_t= zppl_t.Text;
                Properties.Settings.Default.zdyf0= zdyf0.Text;
                Properties.Settings.Default.jbfw= jbfw.Text;
                Properties.Settings.Default.xcxh_t= xcxh_t.Text;
                Properties.Settings.Default.pzglsj_t= pzglsj_t.Text;
                Properties.Settings.Default.gfglsj_t= gfglsj_t.Text;
                Properties.Settings.Default.cfzq_t= cfzq_t.Text;
                Properties.Settings.Default.mckd_t= mckd_t.Text;
                Properties.Settings.Default.kj_ls= kj_ls.Text;
                Properties.Settings.Default.jq_ls= jq_ls.Text;
                Properties.Settings.Default.search_vs= search_vs.Text;
                Properties.Settings.Default.search_fws= search_fws.Text;
                Properties.Settings.Default.get_modes= get_modes.Text;
                Properties.Settings.Default.sszq_t= sszq_t.Text;
                Properties.Settings.Default.glglms_t= glglms_t.Text;
                Properties.Settings.Default.jdkgj_t= jdkgj_t.Text;

                Properties.Settings.Default.Save();
                JYLink.jylink_Micro_param_setup microparam = new JYLink.jylink_Micro_param_setup();
                microparam.search_vs = byte.Parse(search_vs.Text);
                microparam.search_fws = byte.Parse(search_fws.Text);
                microparam.get_modes = (byte)(get_modes.SelectedIndex+1);
                microparam.search_times = byte.Parse(sszq_t.Text);//搜索周期
                if (wby_style.SelectedIndex == 0)
                {
                    microparam.zp_hzs = (ushort)(8500 + zppl[zppl_t.SelectedIndex]);
                }
                else if (wby_style.SelectedIndex == 1 || wby_style.SelectedIndex == 2)
                {
                    microparam.zp_hzs = (ushort)(16800 + zppl[zppl_t.SelectedIndex]);
                }
                if (zppl_t.SelectedIndex >= 0)
                {
                    microparam.zp_fws = zpfw[zppl_t.SelectedIndex];
                    if (zppl_t.SelectedIndex > 11)
                    {
                        microparam.zp_hzs = UInt16.Parse(zdyf0.Text);
                    }
                }
                microparam.mc_hzs = cfzq[cfzq_t.SelectedIndex];
                if (wby_style.SelectedIndex == 2)
                {
                    microparam.mc_kds = 0;
                    microparam.bm_modes = (byte)(xcxh_t.SelectedIndex + 1);
                }
                else
                {
                    microparam.mc_kds = 0.8f;
                    microparam.bm_modes = 0;
                }
                if (mckd_t.SelectedIndex>=0)
                {
                    microparam.lmf_dks = UInt16.Parse(mckd_t.Text);   
                }
                else
                {
                    microparam.lmf_dks = 0;
                }
                
                microparam.micro_ids = byte.Parse(ld_id_t.Text);
                microparam.kj_ls = (byte)(float.Parse(kj_ls.Text) * 10);
                microparam.jq_ls = (byte)(float.Parse(jq_ls.Text) * 10);
                if (glglms_t.SelectedIndex == 0)
                {
                    microparam.gl_kz1s = 5;
                    microparam.gl_kz2s = 12;
                }
                else
                {
                    microparam.gl_kz1s = 0;
                    microparam.gl_kz2s = 0;
                }
                microparam.zkdj_ids = byte.Parse(kdj_id_t.Text);
                microparam.zkdj_lngs = byte.Parse(zj_lng_d.Text) + float.Parse(zj_lng_f.Text) / 60.0 + float.Parse(zj_lng_m.Text) / 3600.0;
                microparam.zkdj_lats = byte.Parse(zj_lat_d.Text) + float.Parse(zj_lat_f.Text) / 60.0 + float.Parse(zj_lat_m.Text) / 3600.0;
                microparam.pz_sj = (byte)(pzglsj_t.SelectedIndex + 1);
                microparam.gf_sj = (byte)(gfglsj_t.SelectedIndex + 1);
                microparam.jd_kg = (byte)jdkgj_t.SelectedIndex;
                //将起飞参数内容发送到飞控
                bool result=false;// = port.setupMicro(microparam);
                //判断执行结果
                if (result)
                {
                    JYLink.jylink_xb_status_down xb = new JYLink.jylink_xb_status_down();
                    //xbsum_m
                    xb.id = microparam.zkdj_ids;
                    xb.lng = microparam.zkdj_lngs;
                    xb.lat = microparam.zkdj_lats;
                    xb.by = 0;
                    if (!xbsum_m.Contains(xb))
                    {
                        xbsum_m.Add(xb);
                    }                  
                    MessageBox.Show("微波源参数设置成功");
                }
                else
                {
                    MessageBox.Show("微波源参数设置失败");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入的字符不合法！");
            }

        }

        private void parm_search_Click(object sender, EventArgs e)
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
            //MicroParam = port.searchMicro();
            update();
        }

        private void fly_check_Click(object sender, EventArgs e)
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
            JYLink.jylink_Micro_status_down param = new JYLink.jylink_Micro_status_down();
            //param = port.searchMicrostatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void kdj_count_TextChanged(object sender, EventArgs e)
        {
            if (kdj_count.SelectedIndex==0)
            {
                cxj1.Visible = true;
                cxj2.Visible = false;
                cxj3.Visible = false;
                cxj4.Visible = false;
                Jtbiandui.Size = new System.Drawing.Size(855, 207);
            }
            else if (kdj_count.SelectedIndex==1)
            {
                cxj1.Visible = true;
                cxj2.Visible = true;
                cxj3.Visible = false;
                cxj4.Visible = false;
                Jtbiandui.Size = new System.Drawing.Size(855, 207);
            }
            else if (kdj_count.SelectedIndex == 2)
            {
                cxj1.Visible = true;
                cxj2.Visible = true;
                cxj3.Visible = true;
                cxj4.Visible = false;
                Jtbiandui.Size = new System.Drawing.Size(855, 377);
            }
            else
            {
                cxj1.Visible = true;
                cxj2.Visible = true;
                cxj3.Visible = true;
                cxj4.Visible = true;
                Jtbiandui.Size = new System.Drawing.Size(855, 377);
            }
            shebei_parm.Location = new System.Drawing.Point(16,Jtbiandui.Location.Y+ Jtbiandui.Size.Height+4);
            sp_parm.Location = new System.Drawing.Point(16, shebei_parm.Location.Y + shebei_parm.Size.Height + 4);
            jd_kgj.Location = new System.Drawing.Point(16, sp_parm.Location.Y + sp_parm.Size.Height + 4);
        }

        private void kdj_style_TextChanged(object sender, EventArgs e)
        {
            if (zj_ys_t.SelectedIndex==0)
            {
                Jtbiandui.Visible = false;
                shebei_parm.Location = new System.Drawing.Point(16, 162);
                sp_parm.Location = new System.Drawing.Point(16, 233);
                jd_kgj.Location = new System.Drawing.Point(16, 383);
            }
            else if (zj_ys_t.SelectedIndex==1)
            {
                Jtbiandui.Visible = true;
                kdj_count.Text = "1";
                cxj1.Visible = true;
                cxj2.Visible = false;
                cxj3.Visible = false;
                cxj4.Visible = false;
                Jtbiandui.Size = new System.Drawing.Size(855, 207);
                shebei_parm.Location = new System.Drawing.Point(16, 372);
                sp_parm.Location = new System.Drawing.Point(16, 443);
                jd_kgj.Location = new System.Drawing.Point(16, 593);
            }
        }

        private void wby_style_TextChanged(object sender, EventArgs e)
        {
            sp_parm.Visible = true;
            jd_kgj.Visible = true;
            if (wby_style.SelectedIndex==2)
	        {
                xcxh_c.Visible = true;
                xcxh_l.Visible = true;
                xcxh_t.Visible = true;
                mckd_l.Visible = true;
                mckd_c.Visible = true;
                mckd_t.Visible = true;
                xcus.Visible = true;
	        }
            else
            {
                xcxh_c.Visible = false;
                xcxh_l.Visible = false;
                xcxh_t.Visible = false;
                mckd_l.Visible = false;
                mckd_c.Visible = false;
                mckd_t.Visible = false;
                xcus.Visible = false;
            }
            
        }

        private void zppl_t_TextChanged(object sender, EventArgs e)
        {
            if (zppl_t.SelectedIndex>11)
            {
                zdyf0_l.Visible = true;
                zdyf0_c.Visible = true;
                zdyf0.Visible = true;
                zdyf0_l2.Visible = true;
                //jbfw_l.Visible = true;
                //jbfw_c.Visible = true;
               // jbfw.Visible = true;
               // jbfw_l2.Visible = true;
            }
            else
            {
                zdyf0_l.Visible = false;
                zdyf0_c.Visible = false;
                zdyf0.Visible = false;
                zdyf0_l2.Visible = false;
                jbfw_l.Visible = false;
                jbfw_c.Visible = false;
                jbfw.Visible = false;
                jbfw_l2.Visible = false;
            }
        }
    }
}

