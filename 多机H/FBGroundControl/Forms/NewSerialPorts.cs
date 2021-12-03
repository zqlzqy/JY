using FBGroundControl.Forms.NserialPorts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Controls;
using System.Threading;

namespace FBGroundControl.Forms
{
    public partial class NewSerialPorts : Form
    {
        OpenSP OP = new OpenSP();
        OpenPorts OPs = new OpenPorts();
        MainForm mainForm;
        public NewSerialPorts(MainForm mainForm)
        {

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.mainForm = mainForm;
        }

        public ComboBox Nserialport_comboxShow
        {
            get { return this.Nserialport_combox; }
        }

        public ComboBox Nbaudrate_comboxShow
        {
            get { return this.Nbaudrate_combox; }
        }


        private void LoadCombo1()
        {
            Nserialport_combox.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                Nserialport_combox.Items.Add(portNames[i]);
            }
        }


        private void LoadCombo2()
        {
            string[] strlist = new string[]{
                "1200",
                "2400",
                "4800",
                "9600",
                "19200",
                "38400",
                "57600",
                "115200",
            };
            for (int i = 0; i < strlist.Length; i++)
            {
                Nbaudrate_combox.Items.Add(strlist[i]);
            }
        }


        private void SP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = OP.SP.Read(Program.imbuffer, 0, 300);

            string tempStr = string.Empty;
            for (int i = 0; i < count; i++)
            {
                tempStr += Program.imbuffer[i].ToString("X2") + " ";

            }


            this.BeginInvokeIfRequired((MethodInvoker)delegate
                {
                    if (this.mainForm != null)
                    {
                        this.mainForm.telemetryFrm.setRichTextBox(tempStr);
                    }
                });


            // }
            //MessageBox.Show(tempStr);
        }

        private void NewSerialPorts_Load(object sender, EventArgs e)
        {
            LoadCombo1();
            LoadCombo2();
        }

        private void NewSerialPorts_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        //TelemetryFrm tfm = new TelemetryFrm();

        //public bool tab = false;
        //public bool choice()
        //{
        //    //if (this.tabControlactions.SelectedIndex.Equals(6))
        //    {
        //        tab = true;
        //    }
        //    return tab;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //if(tfm.)
            if (mainForm.telemetryFrm.tabControlactions.SelectedIndex.Equals(6))
            {


                if (Nserialport_combox.SelectedItem != null && Nbaudrate_combox.SelectedItem != null)
                {
                    if (!OP.SP.IsOpen)
                    {
                        //if (Nserialport_combox.Text != null && Nbaudrate_combox.Text != null)
                        //{
                        //&& 
                        if (OP.OpenPort(Nserialport_combox.Text, Convert.ToInt32(Nbaudrate_combox.Text)))
                        {
                            openserial_btn.Text = "关闭串口";
                            OP.SP.DataReceived += SP_DataReceived;
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (OP.ClosePort())
                        {
                            openserial_btn.Text = "打开串口";
                            OP.SP.DataReceived -= SP_DataReceived;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择串口/波特率");
                }

                }
            else
            {
                MessageBox.Show("请先选择串口输入选项卡");
            }
            }
        
        
        //else
        //{
        //    MessageBox.Show("请选择串口/波特率");
        //}
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCombo1();
        }
    }
}
