using GMap.NET;
using GMap.NET.Internals;
using MissionPlanner;
using MissionPlanner.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 舵机测试
    /// </summary>
    public partial class SteerTestView : UserControl
    {

        
        public SteerTestView()
        {
            InitializeComponent();
          
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            //JYLinkTeleCtrl port = MainForm.telecontrol_comPort;

            //if (!port.BaseStream.IsOpen)
            //{
            //    MessageBox.Show("Please Connect First!");
            //    return;
            //    throw new Exception("Please Connect First!");
            //}
            //port.steerTest();
        }
       

    }
}