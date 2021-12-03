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
    public partial class CommondOfSet : Form
    {
        public delegate void SendCommondBack();// 委托类型声明
        public static event SendCommondBack SendCommondBackHandler;// 基于委托的事件对象

        public delegate void SendCommondLogBack(string sendCommondContext);// 日志委托类型声明
        public static event SendCommondLogBack SendCommondLogBackHandler;// 日志基于委托的事件对象

        public CommondOfSet()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send_button_Click(object sender, EventArgs e)
        {
            if (command_textBox.Text != null && command_textBox.Text != "")
            {
              //  MainForm.telecontrol_comPort.setMode(command_textBox.Text);

                //状态栏：发送成功与失败图标更换
                if (SendCommondBackHandler != null)
                {
                    SendCommondBackHandler();
                }
                //发送日志记录
                if (SendCommondLogBackHandler != null)
                {
                    SendCommondLogBackHandler(command_textBox.Text);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入命令");
            }
            
        }

        private void CommondOfSet_Load(object sender, EventArgs e)
        {

        }  
        
    }
}
