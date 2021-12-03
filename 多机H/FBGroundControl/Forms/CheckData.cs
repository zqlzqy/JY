using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class CheckData : Form
    {
        public CheckData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "电子检查单.txt";

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
                string s = "靶机ID：";
                //开始写入值
                foreach (Control check in groupBox1.Controls)
                {
                    if (check is CheckBox)
                    {
                        CheckBox ch = (CheckBox)check;
                        if (ch.Checked)
                        {
                            s += ch.Text + ",";
                        }
                    }
                }
                s += "\r\n";
                foreach (Control check in groupBox2.Controls)
                {
                    if (check is CheckBox)
                    {
                        CheckBox ch = (CheckBox)check;
                        if (ch.Checked)
                        {
                            s += ch.Text + "\r\n";
                        }
                    }
                }
                if (!File.Exists(localFilePath))
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                    //创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.Write(s);
                    //将数据写入到文件中
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值
                    sr.Write(s);
                    sr.Close();
                    fs.Close();
                }

            }

        }
    }
}
