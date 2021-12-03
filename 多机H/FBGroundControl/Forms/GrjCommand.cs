using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using FBGroundControl.Forms.utils;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using MissionPlanner;


namespace FBGroundControl.Forms
{
    public partial class GrjCommand : DockContent
    {
        JYLinkInterface port = MainForm.comPort;

        public GrjCommand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JYLink.jylink_Grj_setup grj = new JYLink.jylink_Grj_setup();
            byte[] command = { 0x33, 0x35, 0x41, 0x43, 0x45, 0x47, 0x49, 0x4B, 0x4D, 0x4F, 0x53, 0x57, 0x61, 0x63};
            grj.status = 0xCC;
            grj.num = byte.Parse(num_textBox.Text);
            grj.id = byte.Parse(id_textBox.Text);
            grj.command=command[command_com.SelectedIndex];
            grj.retain1 = byte.Parse(b1.Text);
            grj.retain2 = byte.Parse(b2.Text);
            grj.retain3 = byte.Parse(b3.Text);
            grj.retain4 = byte.Parse(b4.Text);
            grj.retain5 = byte.Parse(b5.Text);
            grj.retain6 = byte.Parse(b6.Text);
             // 判断是否连接
            if(!port.BaseStream.IsOpen)
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

        private void GrjCommand_Load(object sender, System.EventArgs e)
        {

        }
    }
}
