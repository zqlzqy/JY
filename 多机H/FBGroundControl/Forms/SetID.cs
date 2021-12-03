using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using MissionPlanner.Controls;
using System.IO;
using System.Xml;

namespace FBGroundControl.Forms
{
    public partial class SetID : Form
    {
        JYLinkInterface port = MainForm.comPort;
        JYLink.jylink_planeID_param_set duoji = new JYLink.jylink_planeID_param_set();
        JYLink.jylink_planeID_param_down duoji2 = new JYLink.jylink_planeID_param_down(); 
        
        public SetID()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TypeS.SelectedIndex==-1|| DmzS.SelectedIndex==-1||IDS.Text==""||comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("数据不能为空！");
                return;
            }
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            byte targid = byte.Parse(TypeS.Text);
            duoji.planeID = UInt16.Parse(IDS.Text);
            duoji.planeType =(byte)(comboBox1.SelectedIndex+1);
            duoji.dmzID = (byte)(byte.Parse(DmzS.Text) + 0xD0);
            if (duoji.planeID < 1 || duoji.planeID>208)
            {
                MessageBox.Show("靶机ID设置范围错误必须是1到208!");
                return;
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupPlaneId(duoji,targid);
            // 判断执行结果
            if (result)
            {
                port.JYlist.Clear();
                MessageBox.Show("设置成功！");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("请先连接!");
                return;
            }
            if (TypeS.SelectedIndex == -1 )
            {
                MessageBox.Show("数据不能为空！");
                return;
            }
            byte targid = byte.Parse(TypeS.Text);
            //将姿态环参数内容发送到飞控
            duoji2 = port.searchPlaneId(targid);
            // 判断执行结果
            IDC.Text = duoji2.planeID.ToString();
            if (duoji2.planeType == 0)
            {

                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = comboBox1.Items[duoji2.planeType - 1].ToString();
            }
            if (duoji2.dmzID==0)
            {
                DmzC.Text = "0";
            }
            else
            {
                DmzC.Text = (duoji2.dmzID - 0xD0).ToString();
            }
            
            
        }

        private void SetID_Load(object sender, EventArgs e)
        {
            string file = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "mavcmd.xml";

            if (!File.Exists(file))
            {
                CustomMessageBox.Show("Missing mavcmd.xml file");
                return ;
            }
            comboBox1.Items.Clear();
            using (XmlReader reader = XmlReader.Create(file))
            {
                reader.Read();
                reader.ReadStartElement("CMD");
                reader.ReadToFollowing("TYPE");
                XmlReader inner = reader.ReadSubtree();
                inner.Read();
                inner.MoveToElement();
                inner.Read();
                while (inner.Read())
                {
                    inner.MoveToElement();
                    if (inner.IsStartElement())
                    {
                        comboBox1.Items.Add(inner.Name); 
                    }                   
                    inner.Read();
                    
                }
                
            }
        }

        private void TypeS_Click(object sender, EventArgs e)
        {
            TypeS.Items.Clear();
            foreach (var JY in port.JYlist)
            {
                TypeS.Items.Add(JY.targetid);
            }
        }
    }
}
