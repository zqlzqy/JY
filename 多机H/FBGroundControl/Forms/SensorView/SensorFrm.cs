using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class SensorFrm : Form
    {
        public SensorFrm()
        {
            InitializeComponent();

            asbaView.Dock = DockStyle.Fill;
            asbaView.Visible = true;

            groupBox2.Controls.Add(asbaView);
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
            asbaView.Visible = true;
        }

        private void SensorFrm_Load(object sender, EventArgs e)
        {

        }
    }
}