using MissionPlanner;
using MissionPlanner.Comms;
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
    /// <summary>
    /// 通讯设置界面
    /// </summary>
    public partial class CommunicationSetFrm : Form
    {
        //初始化通讯设置(串口/TCP)
        internal CommunicationSetFrm _communicationSetFrm;

        public CommunicationSetFrm()
        {
            InitializeComponent();
            this.serial_comboBox.Text = MainForm.instance.serialValue;
            this.baudRate_comboBox.Text = MainForm.instance.baudRateValue;
            //TCP_panel.Visible = false;
            this.serialMC_comboBox.Text = MainForm.instance.mainCtrl_serialValue;
            this.baudRateMC_comboBox.Text = MainForm.instance.mainCtrl_baudRateValue;
        }
        //串口
        public ComboBox serial_comboBoxShow
        {
            get { return this.serial_comboBox; }
        }
        //波特率
        public ComboBox baudRate_comboBoxShow
        {
            get { return this.baudRate_comboBox; }
        }
        //TCPIP

        //串口复选框
        public RadioButton serial_radioButtonShow
        {
            get { return this.serial_radioButton; }
        }
        //TCP复选框
        public RadioButton TCP_radioButtonShow
        {
            get { return this.TCP_radioButton; }
        }
        public ComboBox serialMC_comboBoxShow
        {
            get { return this.serialMC_comboBox; }
        }
        //波特率
        public ComboBox baudRateMC_comboBoxShow
        {
            get { return this.baudRateMC_comboBox; }
        }


        ///// <summary>
        ///// 设置
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void set_button_Click(object sender, EventArgs e)
        //{
        //    if (serial_radioButton.Checked)
        //    {
        //        SerialSetFrm serialSetFrm = new SerialSetFrm();
        //        serialSetFrm.Owner = this;
        //        serialSetFrm.StartPosition = FormStartPosition.CenterScreen;
        //        serialSetFrm.ShowDialog();
        //    }
        //    else if (TCP_radioButton.Checked)
        //    {
        //        TCPSetFrm tCPSetFrm = new TCPSetFrm();
        //        tCPSetFrm.Owner = this;
        //        tCPSetFrm.StartPosition = FormStartPosition.CenterScreen;
        //        tCPSetFrm.ShowDialog();
        //    }
        //}
        /// <summary>
        /// 串口单选状态修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_radioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (serial_radioButton.Checked)
            {
                Serial_panel.Visible = true;
                //TCP_panel.Visible = false;
            }
        }
        /// <summary>
        /// TCP单选状态修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCP_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TCP_radioButton.Checked)
            {
               // TCP_panel.Visible = true;
                Serial_panel.Visible = false;
            }
        }
       
        /// <summary>
        /// 串口设置保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public bool cancelSerialClick = false;
        public bool cancelTCPClick = false;
        private void openSerial_button_Click(object sender, EventArgs e)
        {
            //if (checkBoxUDP.Checked)
            //{
            //    if (time_diff.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("发送间隔请选择！");
            //        return;
            //    }
            //    if(ckGroup.Checked&&(String.IsNullOrEmpty(GroupIP.Text.Trim())|| String.IsNullOrEmpty(GroupPort.Text.Trim())))
            //    {
            //        MessageBox.Show("组播IP或者组播端口不能为空！");
            //        return;
            //    }
            //    if ((ckSingle.Checked) && (String.IsNullOrEmpty(SendUdpIP.Text.Trim()) || String.IsNullOrEmpty(SendUdpPort.Text.Trim())))
            //    {
            //        MessageBox.Show("发送IP1或者发送端口1不能为空！");
            //        return;
            //    }
            //    if ((ckBroad.Checked) && (String.IsNullOrEmpty(SendUdpIP2.Text.Trim()) || String.IsNullOrEmpty(SendUdpPort2.Text.Trim())))
            //    {
            //        MessageBox.Show("发送IP2或者发送端口2不能为空！");
            //        return;
            //    }
            //    if (ckRecv.Checked &&(string.IsNullOrEmpty(LocalIP.Text.Trim())||string.IsNullOrEmpty(LocalPort.Text.Trim())))
            //    {
            //        MessageBox.Show("本地IP或者本地端口不能为空！");
            //        return;
            //    }
            //    if(!ckBroad.Checked && !ckGroup.Checked && !ckSingle.Checked&&!ckRecv.Checked)
            //    {
            //        MessageBox.Show("请选择UDP类型！");
            //        return;
            //    }
                 
            //    //if (xinyuan.SelectedIndex == -1)
            //    //{
            //    //    MessageBox.Show("信源请选择！");
            //    //    return;
            //    //}
            //}


            
            Properties.Settings.Default.xinbiao = serialXB_comboBox.Text;
            Properties.Settings.Default.Save();
            cancelSerialClick = true;
            //保存串口数据
            SerialWriteXml();
            InitConnection();
            this.Close();
            CloseWindow = false;
        }
        public void SerialWriteXml()
        {
            DataTable student = new DataTable();
            student.Columns.Add("serialName");
            student.Columns.Add("baudRate");

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);
            student.Rows[student.Rows.Count - 1][0] = this.serial_comboBox.Text;
            student.Rows[student.Rows.Count - 1][1] = this.baudRate_comboBox.Text;
            DataSet ds = new DataSet();
            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\serial.xml");

            MainForm.instance.serialValue = this.serial_comboBox.Text;
            MainForm.instance.baudRateValue = this.baudRate_comboBox.Text;
            DataTable mainCtrl_student = new DataTable();
            mainCtrl_student.Columns.Add("mainCtrl_serialName");
            mainCtrl_student.Columns.Add("mainCtrl_baudRate");

            DataRow mainCtrl_newRow = mainCtrl_student.NewRow();
            mainCtrl_student.Rows.Add(mainCtrl_newRow);
            mainCtrl_student.Rows[mainCtrl_student.Rows.Count - 1][0] = this.serialMC_comboBox.Text;
            mainCtrl_student.Rows[mainCtrl_student.Rows.Count - 1][1] = this.baudRateMC_comboBox.Text;
            DataSet mainCtrl_ds = new DataSet();
            mainCtrl_ds.Tables.Add(mainCtrl_student);
            mainCtrl_ds.WriteXml(Application.StartupPath + "\\mainCtrl_serial.xml");

            MainForm.instance.mainCtrl_serialValue = this.serialMC_comboBox.Text;
            MainForm.instance.mainCtrl_baudRateValue = this.baudRateMC_comboBox.Text;
            Properties.Settings.Default.xinbiao = serialXB_comboBox.Text;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// TCP设置保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        public void TCPWriteXml()
        {
            DataTable student = new DataTable();
            student.Columns.Add("TCPIP");
            student.Columns.Add("TCPPort");

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);
           // student.Rows[student.Rows.Count - 1][0] = this.ip_textBox.Text;
           // student.Rows[student.Rows.Count - 1][1] = this.port_textBox.Text;

            DataSet ds = new DataSet();
            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\tcp.xml");

           // MainForm.instance.Host = this.ip_textBox.Text;
           // MainForm.instance.Port = this.port_textBox.Text;

        }
      

        private void CommunicationSetFrm_Load(object sender, EventArgs e)
        {

            serialXB_comboBox.Text = Properties.Settings.Default.xinbiao;
            this.serial_comboBox.Text = MainForm.instance.serialValue;
            this.baudRate_comboBox.Text = MainForm.instance.baudRateValue;
            this.serialMC_comboBox.Text = MainForm.instance.mainCtrl_serialValue;
            this.baudRateMC_comboBox.Text = MainForm.instance.mainCtrl_baudRateValue;
            ZHAN_ID.SelectedIndex = -1;
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            //this.ip_textBox.Text = MainForm.instance.Host;
            //this.port_textBox.Text = MainForm.instance.Port;
            CloseWindow = false;
        }
        /// <summary>
        /// 串口设置：点击串口下拉框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),
                    e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                    e.Bounds);

            string text = combo.Items[e.Index].ToString();
            if (!MainForm.MONO)
            {
                text = text + " " + SerialPort.GetNiceName(text);
            }

            e.Graphics.DrawString(text, e.Font,
                new SolidBrush(combo.ForeColor),
                new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        //保存飞控连接方式
        private void InitConnection()
        {
            DataTable connectType = new DataTable();
            connectType.Columns.Add("ConnectType");

            DataRow connectRow = connectType.NewRow();
            connectType.Rows.Add(connectRow);
            if (serial_radioButton.Checked)
            {
                connectType.Rows[connectType.Rows.Count - 1][0] = "serial";
            }
            else
            {
                connectType.Rows[connectType.Rows.Count - 1][0] = "tcp";
            }

            DataSet connectds = new DataSet();
            connectds.Tables.Add(connectType);
            connectds.WriteXml(Application.StartupPath + "\\ConnectType.xml");


        }
        
        private void cancelTCP_button_Click(object sender, EventArgs e)
        {
            new MainForm().disConnection();
            //SerialPort sp = new SerialPort();
            //sp.Close(); 
            this.Close();
        }

        private void openTCP_button_Click(object sender, EventArgs e)
        {
            cancelTCPClick = true;
            //保存TCP数据
            TCPWriteXml();
            InitConnection();

            this.Close();
        }

        private void refreshSerial_btn_Click(object sender, EventArgs e)
        {
            serial_comboBox.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                serial_comboBox.Items.Add(portNames[i]);
            }
            serialMC_comboBox.Items.Clear();
            string[] portMCNames = SerialPort.GetPortNames();
            for (int i = 0; i < portMCNames.Length; i++)
            {
                serialMC_comboBox.Items.Add(portMCNames[i]);
            }
        }

        private void cancelSerial_btn_Click(object sender, EventArgs e)
        {
            cancelSerialClick = false;
            //new MainForm().disConnection();
            //SerialPort sp = new SerialPort();
            //sp.Close();
            this.Close();
        }

        private void cancelTCP_button_Click_1(object sender, EventArgs e)
        {
            cancelTCPClick = false;
            this.Close();
        }

        private void serialMC_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),
                    e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                    e.Bounds);

            string text = combo.Items[e.Index].ToString();
            if (!MainForm.MONO)
            {
                text = text + " " + SerialPort.GetNiceName(text);
            }

            e.Graphics.DrawString(text, e.Font,
                new SolidBrush(combo.ForeColor),
                new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void serialXB_comboBox_Click(object sender, EventArgs e)
        {
            serialXB_comboBox.Items.Clear();
            string[] portMCNames = SerialPort.GetPortNames();
            for (int i = 0; i < portMCNames.Length; i++)
            {
                serialXB_comboBox.Items.Add(portMCNames[i]);
            }
        }

        private void serialXB_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),
                    e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                    e.Bounds);

            string text = combo.Items[e.Index].ToString();
            if (!MainForm.MONO)
            {
                text = text + " " + SerialPort.GetNiceName(text);
            }

            e.Graphics.DrawString(text, e.Font,
                new SolidBrush(combo.ForeColor),
                new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }
        public bool CloseWindow { get; set; }
        private void CommunicationSetFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow = true;
           MainForm.instance.serialValue=this.serial_comboBox.Text ;
           MainForm.instance.baudRateValue= this.baudRate_comboBox.Text ;
           MainForm.instance.mainCtrl_serialValue =this.serialMC_comboBox.Text ;
           MainForm.instance.mainCtrl_baudRateValue=  this.baudRateMC_comboBox.Text ;
        }

        private void ZHAN_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ZHAN_ID.SelectedIndex==0)
            {
                //MainForm.instance.Table_id.Clear();
                //for (int i = 0; i < 6; i++)
                //{
                //    MainForm.instance.Table_id.Add(0); 
                //}
                
                tabPage1.Parent = null;
                tabPage2.Parent = tabControl1;
            }
            else
            {
                tabPage1.Parent = tabControl1;
                tabPage2.Parent = null;
                Z1.Text = Z2.Text = Z3.Text = Z4.Text = Z5.Text = Z6.Text = ZHAN_ID.Text;
            }
            if (ZHAN_ID.SelectedIndex!=-1)
            {
                MainForm.instance.Zhan_id = byte.Parse(ZHAN_ID.Text);
            }
       
        }

        private void button3_Click(object sender, EventArgs e)
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
                //弹窗显示文件路径
                MessageBox.Show(localFilePath);
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

                string[] array = paramall.Split(';');

                this.Z1.Text = array[0];
                this.B1.Text = array[1];
                this.Z2.Text = array[2];
                this.B2.Text = array[3];
                this.Z3.Text = array[4];
                this.B3.Text = array[5];
                this.Z4.Text = array[6];
                this.B4.Text = array[7];
                this.Z5.Text = array[8];
                this.B5.Text = array[9];
                this.Z6.Text = array[10];
                this.B6.Text = array[11];

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "ID配置表.txt";

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
                //弹窗显示文件路径
                if (!File.Exists(localFilePath))
                {
                    FileStream fs1 = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    sw.WriteLine(this.Z1.Text);
                    sw.WriteLine(this.B1.Text);
                    sw.WriteLine(this.Z2.Text);
                    sw.WriteLine(this.B2.Text);
                    sw.WriteLine(this.Z3.Text);
                    sw.WriteLine(this.B3.Text);
                    sw.WriteLine(this.Z4.Text);
                    sw.WriteLine(this.B4.Text);
                    sw.WriteLine(this.Z5.Text);
                    sw.WriteLine(this.B5.Text);
                    sw.WriteLine(this.Z6.Text);
                    sw.WriteLine(this.B6.Text);


                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));
                    sr.WriteLine(this.Z1.Text);
                    sr.WriteLine(this.B1.Text);
                    sr.WriteLine(this.Z2.Text);
                    sr.WriteLine(this.B2.Text);
                    sr.WriteLine(this.Z3.Text);
                    sr.WriteLine(this.B3.Text);
                    sr.WriteLine(this.Z4.Text);
                    sr.WriteLine(this.B4.Text);
                    sr.WriteLine(this.Z5.Text);
                    sr.WriteLine(this.B5.Text);
                    sr.WriteLine(this.Z6.Text);
                    sr.WriteLine(this.B6.Text);
                    sr.Close();
                    fs.Close();
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte id = 0;
                bool result = false;
                MainForm.instance.Table_id.Clear();
                result = byte.TryParse(B1.Text, out id);
                if (result&&id!=0)
                {
                    MainForm.instance.Table_id.Add(id);  
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);  
                }
                result = byte.TryParse(B2.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id.Add(id);
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);
                }
                result = byte.TryParse(B3.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id.Add(id);
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);
                }
                result = byte.TryParse(B4.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id.Add(id);
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);
                }
                result = byte.TryParse(B5.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id.Add(id);
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);
                }
                result = byte.TryParse(B6.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id.Add(id);
                }
                else
                {
                    MainForm.instance.Table_id.Add(0);
                }
                tabPage2.Parent = tabControl1;
                tabPage1.Parent = null;
            }
            catch (Exception ee) 
            {
                MessageBox.Show("数据异常！");
            }

        }

        private void Serial_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GanRaoJiCom_Click(object sender, EventArgs e)
        {
            GanRaoJiCom.Items.Clear();
            string[] portMCNames = SerialPort.GetPortNames();
            for (int i = 0; i < portMCNames.Length; i++)
            {
                GanRaoJiCom.Items.Add(portMCNames[i]);
            }
        }
    }
}
