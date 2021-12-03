using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FBGroundControl.Forms.utils;
using System.IO;

namespace FBGroundControl.Forms
{
    public partial class CommandHistoryFrm : Form
    {
        CommandHistory cmdHistryShow = new CommandHistory();
        ListViewItem lviItem = new ListViewItem();
        
        public CommandHistoryFrm()
        {
            InitializeComponent();            
        }


        public void saveCommand(int messageType, string str)
        {
            Dictionary<byte, string> cmdHistory = DictionaryTools.getCmdName();
            lviItem = this.listView1.Items.Add(DateTime.Now.ToString("hh:mm:ss"));
            lviItem.SubItems.Add(cmdHistory[(byte)messageType]);
            lviItem.SubItems.Add(str);

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            cmdHistryShow.showCmd(listView1.SelectedItems[0].SubItems[2].Text);
            cmdHistryShow.Owner = this;
            cmdHistryShow.StartPosition = FormStartPosition.CenterScreen;
            cmdHistryShow.ShowDialog();       
            
        }

        private void 清空ToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认清空历史列表？", "清空列表", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.listView1.Items.Clear();
            }
        }

        private void 导出ToolStripMenuItemClick(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "历史指令.txt";

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

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        sw.WriteLine(this.listView1.Items[i].SubItems[0].Text);
                        sw.WriteLine(this.listView1.Items[i].SubItems[1].Text);
                        sw.WriteLine(this.listView1.Items[i].SubItems[2].Text);
                    }
                    //将数据写入到文件中
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    //开始写入值

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        sr.WriteLine(this.listView1.Items[i].SubItems[0].Text);
                        sr.WriteLine(this.listView1.Items[i].SubItems[1].Text);
                        sr.WriteLine(this.listView1.Items[i].SubItems[2].Text);
                    }


                    sr.Close();
                    fs.Close();
                }

            }

        }

        private void CommandHistoryFrm_Load(object sender, EventArgs e)
        {

        }


    }
}
