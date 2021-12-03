using GMap.NET;
using GMap.NET.Internals;
using MissionPlanner;
using MissionPlanner.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

namespace FBGroundControl.Forms
{
    public partial class NextPoint : Form
    {
     
        JYLink.jylink_to_nextpoint_set mode = new JYLink.jylink_to_nextpoint_set();

        public NextPoint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!MainForm.comPort.BaseStream.IsOpen)
            {
                MessageBox.Show("Please Connect First!");
                return;
            }
            byte result = 0;
            if (byte.TryParse(pointnum.Text, out result) && pointnum.Text!="0")
            {
                mode.mode = byte.Parse(pointnum.Text);
                MainForm.comPort.setupToNextPoint(mode); 
            }
            else
            {
                MessageBox.Show("输入字符错误！");
            }

        }
    }
}
