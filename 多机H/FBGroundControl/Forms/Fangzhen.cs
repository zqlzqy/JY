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
    public partial class Fangzhen : Form
    {
        JYLink.jylink_fangzhe_set mode = new JYLink.jylink_fangzhe_set();

        public Fangzhen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.comPort.BaseStream.IsOpen)
            {
                try
                {
                    mode.mode = 1;
                    mode.lng = Convert.ToSingle(lng.Text);
                    mode.lat = Convert.ToSingle(lat.Text);
                    mode.alt = Convert.ToSingle(alt.Text);
                    mode.heading = Convert.ToSingle(heading.Text);
                    //if (comboBox1.SelectedIndex!=-1)
                    //{
                    //    mode.hg=(byte)(comboBox1.SelectedIndex);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("请确认火工是否开启！");
                    //    return;
                    //}
                    
                    MainForm.comPort.setupMode(mode);
                    Properties.Settings.Default.ka0z1 = lng.Text;
                    Properties.Settings.Default.ka0z2 = lat.Text;
                    Properties.Settings.Default.ka0z3 = alt.Text;
                    Properties.Settings.Default.ka0z4 = heading.Text;
                    Properties.Settings.Default.Save();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("请先连接!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainForm.comPort.BaseStream.IsOpen)
            {
                mode.mode = 2;
                mode.lng = 0;
                mode.lat = 0;
                mode.alt = 0;
                mode.heading = 0;
                //mode.hg = 0;
                MainForm.comPort.setupMode(mode);
            }
            else
            {
                MessageBox.Show("请先连接!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainForm.comPort.BaseStream.IsOpen)
            {
                mode.mode = 3;
                mode.lng = 0;
                mode.lat = 0;
                mode.alt = 0;
                mode.heading = 0;
                //mode.hg = 0;
                MainForm.comPort.setupMode(mode);
            }
            else
            {
                MessageBox.Show("请先连接!");
            }
        }

        private void Fangzhen_Load(object sender, EventArgs e)
        {
            lng.Text = Properties.Settings.Default.ka0z1;
            lat.Text = Properties.Settings.Default.ka0z2;
            alt.Text = Properties.Settings.Default.ka0z3;
            heading.Text = Properties.Settings.Default.ka0z4;
            comboBox1.SelectedIndex = 0;
        }
    }
}
