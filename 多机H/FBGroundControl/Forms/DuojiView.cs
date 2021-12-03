using System;
using System.Collections.Generic;
using System.ComponentModel;
using FBGroundControl.Forms.utils;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FBGroundControl.Forms
{
    public partial class DuojiView : DockContent
    {
        public DuojiView()
        {
            InitializeComponent();
        }

        private void DuojiView_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox1.BackColor);
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Red, groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2); 

        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox2.BackColor);
            e.Graphics.DrawString(groupBox2.Text, groupBox2.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(groupBox2.Text, groupBox2.Font).Width + 8, 7, groupBox2.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, groupBox2.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, 1, groupBox2.Height - 2, groupBox2.Width - 2, groupBox2.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, groupBox2.Width - 2, 7, groupBox2.Width - 2, groupBox2.Height - 2); 
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox3.BackColor);
            e.Graphics.DrawString(groupBox3.Text, groupBox3.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.YellowGreen, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.YellowGreen, e.Graphics.MeasureString(groupBox3.Text, groupBox3.Font).Width + 8, 7, groupBox3.Width - 2, 7);
            e.Graphics.DrawLine(Pens.YellowGreen, 1, 7, 1, groupBox3.Height - 2);
            e.Graphics.DrawLine(Pens.YellowGreen, 1, groupBox3.Height - 2, groupBox3.Width - 2, groupBox3.Height - 2);
            e.Graphics.DrawLine(Pens.YellowGreen, groupBox3.Width - 2, 7, groupBox3.Width - 2, groupBox3.Height - 2); 
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox4.BackColor);
            e.Graphics.DrawString(groupBox4.Text, groupBox4.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.PaleGreen, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.PaleGreen, e.Graphics.MeasureString(groupBox4.Text, groupBox4.Font).Width + 8, 7, groupBox4.Width - 2, 7);
            e.Graphics.DrawLine(Pens.PaleGreen, 1, 7, 1, groupBox4.Height - 2);
            e.Graphics.DrawLine(Pens.PaleGreen, 1, groupBox4.Height - 2, groupBox4.Width - 2, groupBox4.Height - 2);
            e.Graphics.DrawLine(Pens.PaleGreen, groupBox4.Width - 2, 7, groupBox4.Width - 2, groupBox4.Height - 2); 
        }

        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox5.BackColor);
            e.Graphics.DrawString(groupBox5.Text, groupBox5.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.Orange, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Orange, e.Graphics.MeasureString(groupBox5.Text, groupBox5.Font).Width + 8, 7, groupBox5.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Orange, 1, 7, 1, groupBox5.Height - 2);
            e.Graphics.DrawLine(Pens.Orange, 1, groupBox5.Height - 2, groupBox5.Width - 2, groupBox5.Height - 2);
            e.Graphics.DrawLine(Pens.Orange, groupBox5.Width - 2, 7, groupBox5.Width - 2, groupBox5.Height - 2); 
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox6.BackColor);
            e.Graphics.DrawString(groupBox6.Text, groupBox6.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.NavajoWhite, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.NavajoWhite, e.Graphics.MeasureString(groupBox6.Text, groupBox6.Font).Width + 8, 7, groupBox6.Width - 2, 7);
            e.Graphics.DrawLine(Pens.NavajoWhite, 1, 7, 1, groupBox6.Height - 2);
            e.Graphics.DrawLine(Pens.NavajoWhite, 1, groupBox6.Height - 2, groupBox6.Width - 2, groupBox6.Height - 2);
            e.Graphics.DrawLine(Pens.NavajoWhite, groupBox6.Width - 2, 7, groupBox6.Width - 2, groupBox6.Height - 2); 
        }
    }
}
