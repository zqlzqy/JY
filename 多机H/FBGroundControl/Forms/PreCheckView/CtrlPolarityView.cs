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
    public partial class CtrlPolarityiew : UserControl
    {
        public JYLink.jylink_ctrlpolarity_test steer_actionParam = new JYLink.jylink_ctrlpolarity_test();

        public CtrlPolarityiew()
        {
            InitializeComponent();
            steer_action_comboBox.DataSource = Common.SteerActionDirList(MainForm.comPort.JY.cs);
            steer_action_comboBox.ValueMember = "Key";
            steer_action_comboBox.DisplayMember = "Value";

            steer_action_comboBox.Text = "飞机抬头";

          
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            //steer_action_
           
        }
       

    }
}