using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using FBGroundControl.Forms.utils;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MissionPlanner.Utilities;

namespace FBGroundControl.Forms
{
    public partial class DataView : DockContent
    {
        byte[] idsum;
        float _alt = 100; 
        float _roll = 35;
        float _pitch = 10;
        float _speed = 90;
        float _rpm = 2;
        float _air_speed = 20; 

        public DataView()
        {
            
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataView_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            if (File.Exists(Application.StartupPath + "\\DataView.xml"))
            {
                ds.ReadXml(Application.StartupPath + "\\DataView.xml");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        _alt = float.Parse(ds.Tables[0].Rows[i][0].ToString());
                        _roll = float.Parse(ds.Tables[0].Rows[i][1].ToString());
                        _pitch = float.Parse(ds.Tables[0].Rows[i][2].ToString());
                        _speed = float.Parse(ds.Tables[0].Rows[i][3].ToString());
                        _rpm = float.Parse(ds.Tables[0].Rows[i][4].ToString());
                        _air_speed = float.Parse(ds.Tables[0].Rows[i][5].ToString());
                        break;
                   }
                }
            }
            timer1.Start();
        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.instance.dataToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainForm.comPort.JYlist.Count==0)
            {
                return;
            }
            this.dataGridView1.Rows.Clear();
            idsum = new byte[MainForm.comPort.JYlist.Count];
            this.dataGridView1.Rows.Add(MainForm.comPort.JYlist.Count);
            int ii=0;
            foreach (var JY  in MainForm.comPort.JYlist)
            {
                idsum[ii] = JY.targetid;
                ii++;
            }
            Array.Sort(idsum);
            for (int i = 0; i < idsum.Length; i++)
            {
                dataGridView1.Rows[i].Cells[id.Index].Value = idsum[i].ToString();
                foreach (var JY in MainForm.comPort.JYlist)
                {
                    if (idsum[i]==JY.targetid)
                    {
                        dataGridView1.Rows[i].Cells[lng.Index].Value = JY.cs.lng.ToString("0.00000");
                        dataGridView1.Rows[i].Cells[lat.Index].Value = JY.cs.lat.ToString("0.00000");
                        dataGridView1.Rows[i].Cells[alt.Index].Value = JY.cs.zuhe_altitude.ToString("F0");
                        if (JY.cs.zuhe_altitude<_alt)
                        {
                            dataGridView1.Rows[i].Cells[alt.Index].Style.BackColor = Color.Red; 
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[alt.Index].Style.BackColor = Color.White; 
                        }
                        dataGridView1.Rows[i].Cells[roll.Index].Value = JY.cs.roll.ToString("0.0");
                        if (Math.Abs(JY.cs.roll) > _roll)
                        {
                            dataGridView1.Rows[i].Cells[roll.Index].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[roll.Index].Style.BackColor = Color.White;
                        }
                        dataGridView1.Rows[i].Cells[pitch.Index].Value = JY.cs.pitch.ToString("0.0");
                        if (Math.Abs(JY.cs.pitch) > _pitch)
                        {
                            dataGridView1.Rows[i].Cells[pitch.Index].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[pitch.Index].Style.BackColor = Color.White;
                        }
                        dataGridView1.Rows[i].Cells[speed.Index].Value = JY.cs.groundspeed.ToString("F0");
                        if (JY.cs.groundspeed<_speed)
                        {
                            dataGridView1.Rows[i].Cells[speed.Index].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[speed.Index].Style.BackColor = Color.White;
                        }
                        dataGridView1.Rows[i].Cells[rpm.Index].Value = JY.cs.rpm.ToString("0.0");
                        if (JY.cs.rpm < _rpm)
                        {
                            dataGridView1.Rows[i].Cells[rpm.Index].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[rpm.Index].Style.BackColor = Color.White;
                        }
                        dataGridView1.Rows[i].Cells[sky_speed.Index].Value = JY.cs.air_speed.ToString("0.0");
                        if (Math.Abs(JY.cs.air_speed)>_air_speed)
                        {
                            dataGridView1.Rows[i].Cells[sky_speed.Index].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[sky_speed.Index].Style.BackColor = Color.White;
                        }
                    }

                }

            }

        }
    }
}
