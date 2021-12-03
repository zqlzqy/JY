using MissionPlanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class Table_IdSet : Form
    {
        JYLink.jylink_planeID_param_set duoji = new JYLink.jylink_planeID_param_set();
        JYLinkInterface port = MainForm.comPort;
        public Table_IdSet()
        {
            InitializeComponent();
        }

        private void Table_IdSet_Load(object sender, EventArgs e)
        {
            Z1.Text = Z2.Text = Z3.Text = Z4.Text = Z5.Text = Z6.Text = MainForm.instance.Zhan_id.ToString();
            if (MainForm.instance.Table_id.Count!=0)
            {
                B1.Text = MainForm.instance.Table_id[0].ToString();
                B2.Text = MainForm.instance.Table_id[1].ToString();
                B3.Text = MainForm.instance.Table_id[2].ToString();
                B4.Text = MainForm.instance.Table_id[3].ToString();
                B5.Text = MainForm.instance.Table_id[4].ToString();
                B6.Text = MainForm.instance.Table_id[5].ToString();
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    MainForm.instance.Table_id.Add(0);
                }    
            }
                        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否连接
                //if (!port.BaseStream.IsOpen)
                //{
                //    MessageBox.Show("请先连接!");
                //    return;
                //}

                byte id = 0;
                bool result = false;
                result = byte.TryParse(B1.Text, out id);
                if (result && id != 0 )
                {
                    MainForm.instance.Table_id[0]=id;
                }
                else
                {
                    MainForm.instance.Table_id[0] = 0;
                }
                result = byte.TryParse(B2.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id[1] = id;
                }
                else
                {
                    MainForm.instance.Table_id[1] = 0;
                }
                result = byte.TryParse(B3.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id[2] = id;
                }
                else
                {
                    MainForm.instance.Table_id[2] = 0;
                }
                result = byte.TryParse(B4.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id[3] = id;
                }
                else
                {
                    MainForm.instance.Table_id[3] = 0;
                }
                result = byte.TryParse(B5.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id[4] = id;
                }
                else
                {
                    MainForm.instance.Table_id[4] = 0;
                }
                result = byte.TryParse(B6.Text, out id);
                if (result && id != 0)
                {
                    MainForm.instance.Table_id[5] = id;
                }
                else
                {
                    MainForm.instance.Table_id[5] = 0;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("数据异常！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Z1.Text != MainForm.instance.Zhan_id.ToString())
            {
              
                duoji.planeID = UInt16.Parse(B1.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z1.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B1.Text));
                // 判断执行结果
                if (result1)
                {
                    int id = duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[0] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Z2.Text != MainForm.instance.Zhan_id.ToString())
            {
                
                duoji.planeID = UInt16.Parse(B2.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z2.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B2.Text));
                // 判断执行结果
                if (result1)
                {
                    int id =  duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[1] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Z3.Text != MainForm.instance.Zhan_id.ToString())
            {
               
                duoji.planeID = UInt16.Parse(B3.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z3.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B3.Text));
                // 判断执行结果
                if (result1)
                {
                    int id =  duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[2] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Z4.Text != MainForm.instance.Zhan_id.ToString())
            {
                
                duoji.planeID = UInt16.Parse(B4.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z4.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B4.Text));
                // 判断执行结果
                if (result1)
                {
                    int id = duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[3] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Z5.Text != MainForm.instance.Zhan_id.ToString())
            {
              
                duoji.planeID = UInt16.Parse(B5.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z5.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B5.Text));
                // 判断执行结果
                if (result1)
                {
                    int id = duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[4] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Z6.Text != MainForm.instance.Zhan_id.ToString())
            {
                
                duoji.planeID = UInt16.Parse(B6.Text);
                duoji.planeType = 0;
                duoji.dmzID = (byte)(byte.Parse(Z6.Text) + 0xD0);

                bool result1 = port.setupPlaneId(duoji, byte.Parse(B6.Text));
                // 判断执行结果
                if (result1)
                {
                    int id = duoji.planeID;
                    port.JYlist.remove(id);//移除组内成员
                    MainForm.instance.Table_id[5] = 0;
                    MessageBox.Show("设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
        }
    }
}
