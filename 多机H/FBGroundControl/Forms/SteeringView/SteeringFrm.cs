using MissionPlanner;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class SteeringFrm : Form
    {
        
        public SteeringFrm()
        {
            InitializeComponent();

           // scView.Dock = DockStyle.Fill;
            //scView.Visible = true;

            //groupBox2.Controls.Add(scView);
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void airspeedbaltview_button_Click(object sender, EventArgs e)
        {
            //scView.Visible = true;
        }

        private void SteeringFrm_Load(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            JYLink.jylink_engine_param_down engine = new JYLink.jylink_engine_param_down();
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {

                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
                //弹框显示Please Connect First
            }
            engine = port.searchEngine();
            if (engine.type!=0)
            {
                type.Text = comboBox1.Items[engine.type - 1].ToString();  
            }
            else
            {
                type.Text = "0";
            }
            
        }

        private void setup_parm_Click(object sender, EventArgs e)
        {
            JYLink.jylink_engine_param_setup engine = new JYLink.jylink_engine_param_setup();
            engine.type =(byte)( comboBox1.SelectedIndex + 1);
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
                throw new Exception("Please Connect First!");
            }
            //将姿态环参数内容发送到飞控
            bool result = port.setupEngine(engine);
            // 判断执行结果
            if (result)
            {
                MessageBox.Show("参数设置成功");
            }
            else
            {
                MessageBox.Show("参数设置失败");
            }
        }

        private void set_zero_Click(object sender, EventArgs e)
        {

        }
    }
}