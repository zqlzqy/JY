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
    public partial class XuNi : Form
    {
        public XuNi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.instance.lng_xn = this.lng_xn;
            MainForm.instance.lat_xn = this.lat_xn;
            MainForm.instance.head_xn = this.heading_xn;
            MainForm.instance.speed_xn = this.speed_xn;
            Properties.Settings.Default.lngxn = lng_xn.Text;
            Properties.Settings.Default.latxn = lat_xn.Text;
            Properties.Settings.Default.headxn = heading_xn.Text;
            Properties.Settings.Default.spxn = speed_xn.Text;
            Properties.Settings.Default.Save();
            MainForm.instance.setXuni_ItemClick(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.instance.TUIChungXuni_ItemClick(null, null);
        }

        private void XuNi_Load(object sender, EventArgs e)
        {
            lng_xn.Text = Properties.Settings.Default.lngxn;
            lat_xn.Text = Properties.Settings.Default.latxn;
            heading_xn.Text = Properties.Settings.Default.headxn;
            speed_xn.Text = Properties.Settings.Default.spxn;
        }
    }
}
