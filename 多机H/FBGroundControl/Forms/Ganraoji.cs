using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using MissionPlanner;

namespace FBGroundControl.Forms
{
    public partial class Ganraoji : DockContent
    {
        JYLinkInterface port = MainForm.comPort;
        public Ganraoji()
        {
            InitializeComponent();
        }

        private void Ganraoji_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (command_com.SelectedIndex==12)
            {
                DialogResult dr = MessageBox.Show("确认卸载数据？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }  
            }
     
            JYLink.jylink_Grj_setup grj = new JYLink.jylink_Grj_setup();
            byte[] command = { 0x33, 0x35, 0x41, 0x43, 0x45, 0x47, 0x49, 0x4B, 0x4D, 0x4F, 0x53, 0x55, 0x57, 0x61, 0x63 };
            grj.status = 0xCC;
            grj.num = 0;
            grj.id = byte.Parse(id_textBox.Text);
            grj.command = command[command_com.SelectedIndex];
            grj.retain1 = 0;
            grj.retain2 = 0;
            grj.retain3 =0;
            grj.retain4 = 0;
            grj.retain5 = 0;
            grj.retain6 =0;
            // 判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupGrj(grj);
            //判断执行结果
            if (result)
            {
                MessageBox.Show("指令上传成功！");
            }
        }
    }
}
