using MissionPlanner;
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
using WeifenLuo.WinFormsUI.Docking;
using FBGroundControl.Forms.utils;
using System.Collections.Generic;
using System.Threading;


namespace FBGroundControl.Forms
{
    public partial class CommandsFrm : DockContent
    {
        //string modeFirstName = "Mode：";
        List<string> firstNameList = new List<string>();
        string sendContent = "";
        int num = 6;
        public delegate void SendCommondBack();//状态栏：飞机飞行信号委托类型声明
        public static event SendCommondBack SendCommondBackHandler;//状态栏：飞机飞行信号基于委托的事件对象
        public delegate void SendCommondLogBack(string sendCommondContext);// 日志委托类型声明
        public static event SendCommondLogBack SendCommondLogBackHandler;// 日志基于委托的事件对象
        JYLink.jylink_mainctrl_command_setup command = new JYLink.jylink_mainctrl_command_setup();
        JYLink.jylink_mainctrl_command_setup command0 = new JYLink.jylink_mainctrl_command_setup();
        public CommandsFrm()
        {
            InitializeComponent();
            firstNameList.Add("Mode");
            //初始化****模式

        }
       
        private void setmode(string mode) {
            MainForm.comPort.setMode(mode);
            //状态栏：发送成功与失败图标更换
            if (SendCommondBackHandler != null)
            {
                SendCommondBackHandler();
            }
            //发送日志记录
            if (SendCommondLogBackHandler != null)
            {
                SendCommondLogBackHandler(mode);
            }
        }

        private void setTask(string task)
        {
            MainForm.comPort.missionUpLoad(task);
            //状态栏：发送成功与失败图标更换
            if (SendCommondBackHandler != null)
            {
                SendCommondBackHandler();
            }
            //发送日志记录
            if (SendCommondLogBackHandler != null)
            {
                SendCommondLogBackHandler(task);
            }
 
        }

        private void manual_btn_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 8;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;

            MainForm.comPort.mainCtrlCmdSetup(command0);
            //Thread.Sleep(50);
            MainForm.comPort.mainCtrlCmdSetup(command);
           // Thread.Sleep(50);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void stabilize_btn_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 128;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void alt_hold_btn_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 64;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
            
        }

        private void loiter_btn_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 16;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void longitudinal_btn_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 1;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void guided_btn_Click(object sender, EventArgs e)
        {
  
        }

        private void rtl_btn_Click(object sender, EventArgs e)
        {

        }

        private void mot_continueRoll_btn_Click(object sender, EventArgs e)
        {

        }

        private void mot_anglePitch_btn_Click(object sender, EventArgs e)
        {

        }

        private void mot_levelTurn_btn_Click(object sender, EventArgs e)
        {
 
        }

        private void mot_YMM_motorized_btn_Click(object sender, EventArgs e)
        {

        }

        private void mot_loop_btn_Click(object sender, EventArgs e)
        {
    
        }

        private void auto_btn_Click(object sender, EventArgs e)
        {

        }

        private void takeoff_btn_Click(object sender, EventArgs e)
        {
 
        }

        private void land_btn_Click(object sender, EventArgs e)
        {

        }

        private void umbrella_btn_Click(object sender, EventArgs e)
        {

        }

        private void takeoff_TextChanged(object sender, EventArgs e)
        {
      
            
           
        }

        private void CommandsFrm_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            if (File.Exists(Application.StartupPath + "\\DataView.xml"))
            {
                ds.ReadXml(Application.StartupPath + "\\DataView.xml");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        num = int.Parse(ds.Tables[0].Rows[i][6].ToString());
                        break;
                    }
                }
            }
            comboBox1.Items.Clear();
            comboBox1.Items.Add(255);
            for (int i = 0; i < num; i++)
            {
                comboBox1.Items.Add(i+1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command.command1 = 128;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command.command1 = 1;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            command.command1 = 2;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            command.command1 = 4;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            command.command1 = 8;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            command.command1 = 16;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command.command1 = 32;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command.command1 = 64;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 1;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 2;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 4;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 8;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 16;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 32;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 64;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 128;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 1;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 2;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 4;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 32;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 2;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 4;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 8;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 16;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 32;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 64;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 128;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 1;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 2;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 4;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 8;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 16;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 32;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 64;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 0;
            command.command8 = 128;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 1;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            command.command1 = 0;
            command.command2 = 0;
            command.command3 = 0;
            command.command4 = 0;
            command.command5 = 0;
            command.command6 = 0;
            command.command7 = 2;
            command.command8 = 0;
            MainForm.comPort.mainCtrlCmdSetup(command0);
            MainForm.comPort.mainCtrlCmdSetup(command);
            MainForm.comPort.mainCtrlCmdSetup(command);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm.instance.targetlabel.Text = comboBox1.Text;  
        }

    }
}
