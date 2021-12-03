using MissionPlanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using FBGroundControl.Forms.utils;
using System.Collections.Generic;
using System.Threading;

namespace FBGroundControl.Forms
{
    public partial class FlightMode : DockContent
    {
        JYLink.jylink_flightmode_setup mode = new JYLink.jylink_flightmode_setup();
        JYLinkInterface port = MainForm.comPort;
        public FlightMode()
        {
            InitializeComponent();
        }

        private void FlightMode_Load(object sender, EventArgs e)
        {

        }

        private void manual_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认切换左盘机动？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 1;
                port.setupJiDongMode(mode);
            }
        }

        private void alt_hold_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认切换右盘机动？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 2;
                port.setupJiDongMode(mode);
            }
        }

        private void stabilize_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认切换左航向90？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 3;
                port.setupJiDongMode(mode);
            }
        }

        private void guided_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认切换右航向90？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 4;
                port.setupJiDongMode(mode);
            }
        }

        private void mot_continueRoll_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认发送左航向180？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 5;
                port.setupJiDongMode(mode);
            }
        }

        private void rtl_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认发送右航向180？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 6;
                port.setupJiDongMode(mode);
            }
        }

        private void mot_anglePitch_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认发送S机动？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 7;
                port.setupJiDongMode(mode);
            }
        }

        private void loiter_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认切换半滚倒转？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 8;
                port.setupJiDongMode(mode);
            }
        }

        private void longitudinal_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认发送俯冲拉起？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 9;
                port.setupJiDongMode(mode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认发送桶滚？", "发送命令", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                mode.flight_mode = 10;
                port.setupJiDongMode(mode);
            }
        }
    }
}
