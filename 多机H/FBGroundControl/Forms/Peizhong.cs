using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MissionPlanner;
using MissionPlanner.Controls;

namespace FBGroundControl.Forms
{
    public partial class Peizhong : Form
    {
        public Peizhong()
        {
            InitializeComponent();
        }
        double L1=0, L2=0;
        double k1, k2, k3, k4;

        List<double> kk = new List<double>();
        List<double> xx = new List<double>(); 
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            type.Items.Clear();
            StreamReader sr = new StreamReader(Application.StartupPath + "\\config.txt", false);
            String line;
            string[] array = new string[3];
            string paramall = "";
            while ((line = sr.ReadLine()) != null)
            {
                paramall = line.ToString();
                array = paramall.Split(',');
                type.Items.Add(array[0]);
            }
            sr.Close();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text.Trim() == "")
            {
                MessageBox.Show("编号不能为空！");
                return;
            }
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.png)|All files(*.*)";
            //设置文件名称：
            saveFileDialog1.FileName = "编号 "+id.Text+" "+type.Text+" "+ DateTime.Now.ToString("yyyyMMdd") + "-" + "数据.png";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮进入  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                //弹窗显示文件路径
                if (!File.Exists(localFilePath))
                {
                    Thread.Sleep(1000);//延时1秒
                    Bitmap bmp2 = new Bitmap(this.Width, this.Height );
                    Graphics g2 = Graphics.FromImage(bmp2);  //创建画笔
                    g2.CopyFromScreen(new Point(this.Location.X , this.Location.Y ), new Point(0, 0), bmp2.Size);//截屏
                    bmp2.Save(localFilePath); //保存为文件  ,注意格式是否正确.
                    bmp2.Dispose();//关闭对象
                    g2.Dispose();//关闭画笔
                }
                else
                {
                    Thread.Sleep(1000);//延时1秒
                    Bitmap bmp2 = new Bitmap(this.Width, this.Height);
                    Graphics g2 = Graphics.FromImage(bmp2);  //创建画笔
                    g2.CopyFromScreen(new Point(this.Location.X, this.Location.Y ), new Point(0, 0), bmp2.Size);//截屏                
                    bmp2.Save(localFilePath); //保存为文件  ,注意格式是否正确.
                    bmp2.Dispose();//关闭对象
                    g2.Dispose();//关闭画笔
                }
                

                //if (Directory.Exists(" c:\\屏幕截图"))  //判断目录是否存在,不存在就创建
                //{ }
                //else
                //{
                //    DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\屏幕截图");
                //    directoryInfo.Create();
                //}
                //创建图片对象

            //    localFilePath = saveFileDialog1.FileName.ToString();
            //    //弹窗显示文件路径
            //    if (!File.Exists(localFilePath))
            //    {
            //        FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
            //        StreamWriter sw = new StreamWriter(fs1,Encoding.UTF8);

            //        if (checkBox1.Checked )
            //        {
            //            sw.WriteLine("飞机总重"+PK.Text);
            //            sw.WriteLine("飞机重心" + PX.Text);
            //            sw.WriteLine("前配重" + QP.Text);
            //            sw.WriteLine("前配L" + QX.Text);
            //        }
            //        else
            //        {
            //            sw.WriteLine("飞机总重" + PK.Text);
            //            sw.WriteLine("飞机重心" + PX.Text);
            //            sw.WriteLine("后配重" + HP.Text);
            //            sw.WriteLine("后配L" + HX.Text);
            //        }
            //        sw.Close();
            //        fs1.Close();
            //    }
            //    else
            //    {
            //        FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
            //        StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
            //        if (checkBox1.Checked)
            //        {
            //            sr.WriteLine("飞机总重" + PK.Text);
            //            sr.WriteLine("飞机重心" + PX.Text);
            //            sr.WriteLine("前配重" + QP.Text);
            //            sr.WriteLine("前配L" + QX.Text);
            //        }
            //        else
            //        {
            //            sr.WriteLine("飞机总重" + PK.Text);
            //            sr.WriteLine("飞机重心" + PX.Text);
            //            sr.WriteLine("后配重" + HP.Text);
            //            sr.WriteLine("后配L" + HX.Text);
            //        }
            //        sr.Close();
            //        fs.Close();
            //    }
            }

            ///////////////////////////////////////////////////////////
            //this.WindowState = FormWindowState.Minimized; //最小化当前窗口

        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (type.SelectedIndex==0)
	            {
                    PX.Text = "1800";
	            }
                else if (type.SelectedIndex==1)
                {
                    PX.Text = "1750";
                }
                StreamReader sr = new StreamReader(Application.StartupPath + "\\config.txt", false);
                String line;
                string[] array = new string[7];
                string paramall = "";
                while ((line = sr.ReadLine()) != null)
                {
                    paramall = line.ToString();
                    array = paramall.Split(',');
                    if (array[0] == type.Text.Trim())
                    {
                        break;
                    }
                }
                PX.Text = array[1];
                L1 = Convert.ToDouble(array[2]);
                L2 = Convert.ToDouble(array[3]);
                k1 = Convert.ToDouble(array[4]);
                k2 = Convert.ToDouble(array[5]);
                k3 = Convert.ToDouble(array[6]);
                k4 = Convert.ToDouble(array[7]);
                label23.Text = "L1:" + array[2] + " " + "L2:" + array[3] + " " + "k1,k2,k3,k4:" + array[4] + "," + array[5] + "," + array[6] + "," + array[7] ;
                sr.Close();
            }
            catch (Exception)
            {               
                throw;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double d,kkk=0,xxx=0;
            kk.Clear();
            xx.Clear();
            bool b1, b2, b3, b4, b5, b6;
            if (double.TryParse(Z11.Text.Trim(), out d) && double.TryParse(Y12.Text.Trim(), out d) && double.TryParse(Y13.Text.Trim(), out d) && double.TryParse(Z14.Text.Trim(), out d))
            {
                K1.Text = ((Convert.ToDouble(Z11.Text) + Convert.ToDouble(Y12.Text) + Convert.ToDouble(Y13.Text) + Convert.ToDouble(Z14.Text))-k1-k2-k3-k4 ).ToString("0.00");
                X1.Text = ((Convert.ToDouble(Y13.Text) + Convert.ToDouble(Z14.Text) - k3 - k4) * L2 / Convert.ToDouble(K1.Text) + L1).ToString("0.00");
                b1 = true;
                kk.Add(Convert.ToDouble(K1.Text));
                xx.Add(Convert.ToDouble(X1.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K1.Text.Trim(), out d) && double.TryParse(X1.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K1.Text));
                    xx.Remove(Convert.ToDouble(X1.Text));
                }
                b1 = false;
            }
            if (double.TryParse(Z21.Text.Trim(), out d) && double.TryParse(Y22.Text.Trim(), out d) && double.TryParse(Y23.Text.Trim(), out d) && double.TryParse(Z24.Text.Trim(), out d))
            {
                K2.Text = ((Convert.ToDouble(Z21.Text) + Convert.ToDouble(Y22.Text) + Convert.ToDouble(Y23.Text) + Convert.ToDouble(Z24.Text)) - k1 - k2 - k3 - k4).ToString("0.00");
                X2.Text = ((Convert.ToDouble(Y23.Text) + Convert.ToDouble(Z24.Text) - k3 - k4) * L2 / Convert.ToDouble(K2.Text) + L1).ToString("0.00");
                b2 = true;
                kk.Add(Convert.ToDouble(K2.Text));
                xx.Add(Convert.ToDouble(X2.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K2.Text.Trim(), out d) && double.TryParse(X2.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K2.Text));
                    xx.Remove(Convert.ToDouble(X2.Text));
                }
                b2 = false;
            }
            if (double.TryParse(Z31.Text.Trim(), out d) && double.TryParse(Y32.Text.Trim(), out d) && double.TryParse(Y33.Text.Trim(), out d) && double.TryParse(Z34.Text.Trim(), out d))
            {
                K3.Text = ((Convert.ToDouble(Z31.Text) + Convert.ToDouble(Y32.Text) + Convert.ToDouble(Y33.Text) + Convert.ToDouble(Z34.Text)) - k1 - k2 - k3 - k4).ToString("0.00");
                X3.Text = ((Convert.ToDouble(Y33.Text) + Convert.ToDouble(Z34.Text)  - k3 - k4) * L2 / Convert.ToDouble(K3.Text) + L1).ToString("0.00");
                b3 = true;
                kk.Add(Convert.ToDouble(K3.Text));
                xx.Add(Convert.ToDouble(X3.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K3.Text.Trim(), out d) && double.TryParse(X3.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K3.Text));
                    xx.Remove(Convert.ToDouble(X3.Text));
                }
                b3 = false;
            }
            if (double.TryParse(Z41.Text.Trim(), out d) && double.TryParse(Y42.Text.Trim(), out d) && double.TryParse(Y43.Text.Trim(), out d) && double.TryParse(Z44.Text.Trim(), out d))
            {
                K4.Text = ((Convert.ToDouble(Z41.Text) + Convert.ToDouble(Y42.Text) + Convert.ToDouble(Y43.Text) + Convert.ToDouble(Z44.Text)) - k1 - k2 - k3 - k4).ToString("0.00");
                X4.Text = ((Convert.ToDouble(Y43.Text) + Convert.ToDouble(Z44.Text)  - k3 - k4) * L2 / Convert.ToDouble(K4.Text) + L1).ToString("0.00");
                b4 = true;
                kk.Add(Convert.ToDouble(K4.Text));
                xx.Add(Convert.ToDouble(X4.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K4.Text.Trim(), out d) && double.TryParse(X4.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K4.Text));
                    xx.Remove(Convert.ToDouble(X4.Text));
                }
                b4 = false;
            }
            if (double.TryParse(Z51.Text.Trim(), out d) && double.TryParse(Y52.Text.Trim(), out d) && double.TryParse(Y53.Text.Trim(), out d) && double.TryParse(Z54.Text.Trim(), out d))
            {
                K5.Text = ((Convert.ToDouble(Z51.Text) + Convert.ToDouble(Y52.Text) + Convert.ToDouble(Y53.Text) + Convert.ToDouble(Z54.Text)) - k1 - k2 - k3 - k4).ToString("0.00");
                X5.Text = ((Convert.ToDouble(Y53.Text) + Convert.ToDouble(Z54.Text)  - k3 - k4) * L2 / Convert.ToDouble(K5.Text) + L1).ToString("0.00");
                b5 = true;
                kk.Add(Convert.ToDouble(K5.Text));
                xx.Add(Convert.ToDouble(X5.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K5.Text.Trim(), out d) && double.TryParse(X5.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K5.Text));
                    xx.Remove(Convert.ToDouble(X5.Text));
                }
                b5 = false;
            }
            if (double.TryParse(Z61.Text.Trim(), out d) && double.TryParse(Y62.Text.Trim(), out d) && double.TryParse(Y63.Text.Trim(), out d) && double.TryParse(Z64.Text.Trim(), out d))
            {
                K6.Text = ((Convert.ToDouble(Z61.Text) + Convert.ToDouble(Y62.Text) + Convert.ToDouble(Y63.Text) + Convert.ToDouble(Z64.Text)) - k1 - k2 - k3 - k4).ToString("0.00");
                X6.Text = ((Convert.ToDouble(Y63.Text) + Convert.ToDouble(Z64.Text)  - k3 - k4) * L2 / Convert.ToDouble(K6.Text) + L1).ToString("0.00");
                b6 = true;
                kk.Add(Convert.ToDouble(K6.Text));
                xx.Add(Convert.ToDouble(X6.Text));
            }
            else
            {
                if (kk.Count > 0 && double.TryParse(K6.Text.Trim(), out d) && double.TryParse(X6.Text.Trim(), out d))
                {
                    kk.Remove(Convert.ToDouble(K6.Text));
                    xx.Remove(Convert.ToDouble(X6.Text));
                }
                b6 = false;
            }
            for (int i = 0; i < kk.Count; i++)
            {
                kkk += kk[i];
                xxx += xx[i];
            }
            if (kk.Count>0)
            {
                KK.Text = (kkk / kk.Count).ToString("0.00");
                XX.Text = (xxx / kk.Count).ToString("0.00");
            }
            else
            {
                KK.Text = null;
                XX.Text = null;
            }
            if (checkBox1.Checked && double.TryParse(KK.Text.Trim(), out d) && double.TryParse(XX.Text.Trim(), out d) && double.TryParse(PX.Text.Trim(), out d) && double.TryParse(QX.Text.Trim(), out d))
            {
                QP.Text = (Convert.ToDouble(KK.Text) * (Convert.ToDouble(PX.Text) - Convert.ToDouble(XX.Text)) / (Convert.ToDouble(QX.Text) - Convert.ToDouble(PX.Text))).ToString("0.00");
                PK.Text=(Convert.ToDouble(KK.Text)+Convert.ToDouble(QP.Text)).ToString("0.00");
            }
            if (checkBox2.Checked && double.TryParse(KK.Text.Trim(), out d) && double.TryParse(XX.Text.Trim(), out d) && double.TryParse(PX.Text.Trim(), out d) && double.TryParse(HX.Text.Trim(), out d))
            {
                HP.Text = (Convert.ToDouble(KK.Text) * (Convert.ToDouble(PX.Text) - Convert.ToDouble(XX.Text)) / ( Convert.ToDouble(HX.Text)-Convert.ToDouble(PX.Text) )).ToString("0.00");
                PK.Text=(Convert.ToDouble(KK.Text)+Convert.ToDouble(HP.Text)).ToString("0.00");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked )
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Z11.Text = Y12.Text= Y13.Text=Z14.Text=K1.Text=X1.Text= null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Z21.Text = Y22.Text = Y23.Text = Z24.Text = K2.Text = X2.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Z31.Text = Y32.Text = Y33.Text = Z34.Text = K3.Text = X3.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Z41.Text = Y42.Text = Y43.Text = Z44.Text = K4.Text = X4.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Z51.Text = Y52.Text = Y53.Text = Z54.Text = K5.Text = X5.Text = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Z61.Text = Y62.Text = Y63.Text = Z64.Text = K6.Text = X6.Text = null;
        }
    }
}
