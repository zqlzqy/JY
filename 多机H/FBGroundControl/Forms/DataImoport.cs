using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class DataImoport : Form
    {
        List<JYLink.jylink_status_down> jylink_B7_sum = new List<JYLink.jylink_status_down>();
        List<JYLink.Satlate_status> jylink_B6_sum = new List<JYLink.Satlate_status>();
        List<JYLink.jylink_status_param_down> jylink_A0_sum = new List<JYLink.jylink_status_param_down>();
        List<Warship_location> jylink_ship_sum = new List<Warship_location>(); 
        byte[] buffer;
        public DataImoport()
        {
            InitializeComponent();
        }
        public static byte crc_calculate(byte[] pBuffer, int length)
        {
            if (length < 1)
            {
                return 0xff;
            }
            byte CRC = pBuffer[2];
            for (int i = 3; i < pBuffer.Length - 1; i++)
            {
                CRC ^= pBuffer[i];
            }
            return CRC;
        }
        public object BytesToStruct(byte[] bytes, Type strcutType)
        {
            int Size;
            IntPtr ptr;
            object obj;
            Size = Marshal.SizeOf(strcutType);
            ptr = Marshal.AllocHGlobal(Size);
            try
            {
                Marshal.Copy(bytes, 0, ptr, Size);
                obj = Marshal.PtrToStructure(ptr, strcutType);
                return obj;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private void DataImoport_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label3.Visible = false;
                comboBox2.Visible = false;
            }
            else
            {
                label3.Visible = true;
                comboBox2.Visible = true;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 25)]
        public struct Warship_location
        {
            
            /// <summary> 经度</summary> 
            public double h_lon;
            /// <summary> 纬度</summary>
            public double h_lat;
            /// <summary> 高度</summary>
            public Int16 h_head;
            public Int16 h_speed;
            public byte crc;
            public uint utc;
        }
        private void DataGet()
        {
            byte[] A0 = new byte[62];
            byte[] B6 = new byte[74];
            byte[] ship = new byte[25]; 
            int i = 0;
            while (i < buffer.Length)
            {
                if (buffer[i] == 0xEB && buffer[i + 1] == 0x90)
                {

                    if (buffer[i + 2] == 0xA0)
                    {
                        if (i + 62 > buffer.Length)
                        {
                            break;
                        }
                        Array.Copy(buffer, i + 7, A0, 0, 62);
                        jylink_A0_sum.Add((JYLink.jylink_status_param_down)BytesToStruct(A0, typeof(JYLink.jylink_status_param_down)));
                        i = i + 62;
                        continue;

                    }
                    else if (buffer[i + 2] == 0x25)
                    {
                        if (i+24>buffer.Length)
                        {
                            break;
                        }
                        Array.Copy(buffer, i + 7, ship, 0, 25);
                        jylink_ship_sum.Add((Warship_location)BytesToStruct(ship, typeof(Warship_location)));
                        i = i + 25;
                        continue;
                    }
                    else
                    {
                        i++;
                        continue;
                    }
                }
                else
                {
                    i++;
                }
            }
        }

        private void DataGet(byte id)
        {
            byte[] B7 = new byte[66];
            byte[] ship = new byte[25]; 
            int i = 0;
            while (i < buffer.Length)
            {
                if (buffer[i] == 0xEB && buffer[i + 1] == 0x90)
                {
                  
                    if (buffer[i + 2] == 0xB7&&buffer[i + 3] ==id)
                    {
                        if (i + 66 > buffer.Length)
                        {
                            break;
                        }
                        Array.Copy(buffer, i + 7, B7, 0, 66);
                        jylink_B7_sum.Add((JYLink.jylink_status_down)BytesToStruct(B7, typeof(JYLink.jylink_status_down)));
                        i = i + 66;
                        continue;

                    }
                    else if (buffer[i + 2] == 0x25)
                    {
                        if (i + 24 > buffer.Length)
                        {
                            break;
                        }
                        Array.Copy(buffer, i + 7, ship, 0, 25);
                        jylink_ship_sum.Add((Warship_location)BytesToStruct(ship, typeof(Warship_location)));
                        i = i + 25;
                        continue;
                    }
                    else
                    {
                        i++;
                        continue;
                    }
                }
                else
                {
                    i++;
                }
            } 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;                        
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //设置默认打开位置
            openFileDialog1.Filter = "tlog files (*.tlog)|*.tlog|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                localFilePath = openFileDialog1.FileName;
                textBox1.Text = openFileDialog1.SafeFileName;
                Stream stream = new FileStream(localFilePath, FileMode.Open);
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                stream.Close();
               
            }
        }
        private byte[] time(UInt32 utctime )
        {
            byte[] hms=new byte[3];
            long zhoumiao, temp;
            byte hour, min, sec;
            zhoumiao = utctime / 1000;
            //zhoumiao = 3750;
            Math.DivRem(zhoumiao, 3600 * 24, out temp);
            hour = (byte)Math.Truncate(temp / 3600.0);
            min = (byte)Math.Truncate(temp / 60.0 - hour * 60.0);
            Math.DivRem(temp, 60, out zhoumiao);
            sec = (byte)zhoumiao;
            hms[0] = hour;
            hms[1] = min;
            hms[2] = sec;
            return hms;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            string localFilePath2 = String.Empty;
            string localFilePath3 = String.Empty; 
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd");// +"-" + "飞行数据.txt";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                localFilePath = saveFileDialog1.FileName.ToString() + "-" + "位置数据.txt";
                localFilePath2 = saveFileDialog1.FileName.ToString() + "-" + "姿态数据.txt";
                localFilePath3 = saveFileDialog1.FileName.ToString() + "-" + "舰船数据.txt";
                //弹窗显示文件路径
                if (!File.Exists(localFilePath))
                {
                    if (comboBox1.SelectedIndex==-1 )
                    { 
                        MessageBox.Show("请选择数据源类型");
                        return;
                    }
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    FileStream fs2 = new FileStream(localFilePath2, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw2 = new StreamWriter(fs2, System.Text.Encoding.GetEncoding("GB2312"));
                    FileStream fs3 = new FileStream(localFilePath3, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw3 = new StreamWriter(fs3, System.Text.Encoding.GetEncoding("GB2312"));
                    //sw.Encoding.EncodingName = Encoding.Unicode;
                    jylink_ship_sum.Clear();
                    jylink_B7_sum.Clear();
                    jylink_A0_sum.Clear();
                    //sw.WriteLine("时" + " 分" + " 秒" + "  经度" + "       纬度" + "        高度" + "  东速" + "      北速" + "      天速" + "      转速");
                    sw.WriteLine("时" + " 分" + " 秒" + "  经度" + "       纬度" + "        高度" + "  东速" + "      北速" + "      天速" + "      转速");
                    string stime = "";
                    if (comboBox1.SelectedIndex==1 && comboBox2.SelectedIndex>-1)
                    {
                        DataGet(byte.Parse(comboBox2.Text));
                        for (int i = 0; i < jylink_B7_sum.Count; i++)
                        {
                          //  stime = time(jylink_B7_sum[i].utc_time)[0].ToString("D2") + " " + time(jylink_B7_sum[i].utc_time)[1].ToString("D2") + " " + time(jylink_B7_sum[i].utc_time)[2].ToString("D2");
                            sw.WriteLine(stime + " " + string.Format("{0,-12}", jylink_B7_sum[i].lng.ToString())  +string.Format("{0,-12}", jylink_B7_sum[i].lat.ToString())  + string.Format("{0,-6}", jylink_B7_sum[i].zuhe_altitude.ToString())
                                + string.Format("{0,-10}", (jylink_B7_sum[i].east_speed / 100.0).ToString("N2")) + string.Format("{0,-10}", (jylink_B7_sum[i].north_speed / 100.0).ToString("N2"))
                                + string.Format("{0,-10}", (jylink_B7_sum[i].sky_speed / 100.0).ToString("N2")) + string.Format("{0,-8}", (jylink_B7_sum[i].rpm / 100.0).ToString("N2")));
                        }
                    }
                    if (comboBox1.SelectedIndex==0)
                    {
                        DataGet();
                        for (int i = 0; i < jylink_A0_sum.Count; i++)
                        {
                            //stime = time(jylink_A0_sum[i].utc_time)[0].ToString("D2") + " " + time(jylink_A0_sum[i].utc_time)[1].ToString("D2") + " " + time(jylink_A0_sum[i].utc_time)[2].ToString("D2");
                            sw.WriteLine(stime + " " + string.Format("{0,-12}", jylink_A0_sum[i].gnss_lng.ToString()) + string.Format("{0,-12}", jylink_A0_sum[i].gnss_lat.ToString())+
                                string.Format("{0,-6}",((Int16)(jylink_A0_sum[i].zuhe_altitude)).ToString())
                                 + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_east / 100.0).ToString("N2")) + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_north / 100.0).ToString("N2"))
                                 + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_sky / 100.0).ToString("N2")) + string.Format("{0,-8}", (jylink_A0_sum[i].rpm / 100.0).ToString("N2")));
                        }
                    }
                    sw.WriteLine("时" + " 分" + " 秒" + "  船经度" + "       船纬度" + "      船航向" + "  船速（节）" );
                    for (int i = 0; i < jylink_ship_sum.Count; i++)
                    {
                        stime = time(jylink_ship_sum[i].utc)[0].ToString("D2") + " " + time(jylink_ship_sum[i].utc)[1].ToString("D2") + " " + time(jylink_ship_sum[i].utc)[2].ToString("D2");
                        sw.WriteLine(stime + "  " + string.Format("{0,-12}", jylink_ship_sum[i].h_lon.ToString()) + string.Format("{0,-12}", jylink_ship_sum[i].h_lat.ToString()) +
                                string.Format("{0,-8}", (jylink_ship_sum[i].h_head).ToString())
                                 + string.Format("{0,-10}", (jylink_ship_sum[i].h_speed / 100.0).ToString()) );
                       
                    }

                    sw.Close();
                    fs1.Close();
                    sw2.Close();
                    fs2.Close();
                    MessageBox.Show("数据导出成功");
                }
                else
                {
                    if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("请选择数据源类型");
                        return;
                    }
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs,System.Text.Encoding.GetEncoding("GB2312"));
                    jylink_ship_sum.Clear();
                    jylink_B7_sum.Clear();
                    jylink_A0_sum.Clear();
                    sr.WriteLine("时" + " 分" + " 秒" + "  经度" + "       纬度" + "        高度" + "  东速" + "      北速" + "      天速" + "      转速");
                    string stime = "";
                    if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex > -1)
                    {
                        DataGet(byte.Parse(comboBox2.Text));
                        for (int i = 0; i < jylink_B7_sum.Count; i++)
                        {
                           // stime = time(jylink_B7_sum[i].utc_time)[0].ToString("D2") + " " + time(jylink_B7_sum[i].utc_time)[1].ToString("D2") + " " + time(jylink_B7_sum[i].utc_time)[2].ToString("D2");
                            sr.WriteLine(stime + " " + string.Format("{0,-12}", jylink_B7_sum[i].lng.ToString()) + string.Format("{0,-12}", jylink_B7_sum[i].lat.ToString()) + string.Format("{0,-6}", jylink_B7_sum[i].zuhe_altitude.ToString())
                                + string.Format("{0,-10}", (jylink_B7_sum[i].east_speed / 100.0).ToString("N2")) + string.Format("{0,-10}", (jylink_B7_sum[i].north_speed / 100.0).ToString("N2"))
                                + string.Format("{0,-10}", (jylink_B7_sum[i].sky_speed / 100.0).ToString("N2")) + string.Format("{0,-8}", (jylink_B7_sum[i].rpm / 100.0).ToString("N2")));
                        }
                    }
                    if (comboBox1.SelectedIndex == 0)
                    {
                        DataGet();
                        for (int i = 0; i < jylink_A0_sum.Count; i++)
                        {
                           // stime = time(jylink_A0_sum[i].utc_time)[0].ToString("D2") + " " + time(jylink_A0_sum[i].utc_time)[1].ToString("D2") + " " + time(jylink_A0_sum[i].utc_time)[2].ToString("D2");
                            sr.WriteLine(stime + " " + string.Format("{0,-12}", jylink_A0_sum[i].gnss_lng.ToString()) + string.Format("{0,-12}", jylink_A0_sum[i].gnss_lat.ToString()) +
                                string.Format("{0,-6}", ((Int16)(jylink_A0_sum[i].zuhe_altitude)).ToString())
                                 + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_east / 100.0).ToString("N2")) + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_north / 100.0).ToString("N2"))
                                 + string.Format("{0,-10}", (jylink_A0_sum[i].gnss_sky / 100.0).ToString("N2")) + string.Format("{0,-8}", (jylink_A0_sum[i].rpm / 100.0).ToString("N2")));
                        }
                    }
                    sr.WriteLine("时" + " 分" + " 秒" + "  船经度" + "       船纬度" + "      船航向" + "  船速（节）");
                    for (int i = 0; i < jylink_ship_sum.Count; i++)
                    {
                        stime = time(jylink_ship_sum[i].utc)[0].ToString("D2") + " " + time(jylink_ship_sum[i].utc)[1].ToString("D2") + " " + time(jylink_ship_sum[i].utc)[2].ToString("D2");
                        sr.WriteLine(stime + "  " + string.Format("{0,-12}", jylink_ship_sum[i].h_lon.ToString()) + string.Format("{0,-12}", jylink_ship_sum[i].h_lat.ToString()) +
                                string.Format("{0,-8}", (jylink_ship_sum[i].h_head).ToString())
                                 + string.Format("{0,-10}", (jylink_ship_sum[i].h_speed / 100.0).ToString()));

                    }
                    sr.Close();
                    fs.Close();
                    MessageBox.Show("数据导出成功");
                }


            }

        }
    }
}
