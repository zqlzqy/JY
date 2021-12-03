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
using MissionPlanner;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 状态区
    /// </summary>
    
    public partial class TelemetryFrm : DockContent
    {
        public TelemetryFrm()
        {
            InitializeComponent();
            //richTextBox.AppendText("aaaaa");
        }
        
        /// <summary>
        /// 调整控件大小时发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage1_Resize(object sender, EventArgs e)
        {
            int mywidth, myheight;

            // localize it
            Control tabGauges = sender as Control;

            float scale = tabGauges.Width / (float)tabGauges.Height;

            if (scale > 0.5 && scale < 1.9)
            {
                // square
                //Gvspeed.Visible = true;

                if (tabGauges.Height < tabGauges.Width)
                    myheight = tabGauges.Height / 2;
                else
                    myheight = tabGauges.Width / 2;

                //Gvspeed.Height = myheight;
                //Gspeed.Height = myheight;
                //Galt.Height = myheight;
                //Gheading.Height = myheight;

                //Gvspeed.Location = new Point(0, 0);
                //Gspeed.Location = new Point(Gvspeed.Right, 0);

                //Galt.Location = new Point(0, Gspeed.Bottom);
                //Gheading.Location = new Point(Galt.Right, Gspeed.Bottom);

                return;
            }



            //Galt.Location = new Point(Gspeed.Right, 0);
            //Gheading.Location = new Point(Galt.Right, 0);

        }
        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void setRichTextBox(string message)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
           // this.richTextBox.AppendText(message);
        }
        public static bool a;
        public bool srtbox(bool a)
        {
            if (tabControlactions.SelectedTab.Name == "NewSerialPorts")
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }

        void chk_box_quickview_CheckedChanged(object sender, EventArgs e)
        {

        }

        //航线
        private void quickView_route_DoubleClick(object sender, EventArgs e)
        {
            QuickView qv = (QuickView)sender;

            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 50,
                Text = "Display This",
                AutoSize = true,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };
            ThemeManager.ApplyThemeTo(selectform);

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();
            int max_length = 0;
            List<string> fields = new List<string>();

            List<System.Reflection.PropertyInfo> list = new List<System.Reflection.PropertyInfo>();
            foreach (var field in test.GetProperties())//in隔开，右边集合左边变量
            {
                list.Add(field);
                Console.WriteLine("name: " + field.Name);
                if (field.Name.Equals("wpno") || field.Name.Equals("wp_dist") || field.Name.Equals("waypoint_cmd") || field.Name.Equals("next_waypoint_cmd")
                    || field.Name.Equals("distance_to_home"))
                //       选取所需的值
                {
                    // field.Name has the field's name.
                    object fieldValue = field.GetValue(thisBoxed, null); // Get value
                    if (fieldValue == null)
                        continue;
                    
                    max_length = Math.Max(max_length, TextRenderer.MeasureText(field.Name, selectform.Font).Width);
                    fields.Add(field.Name);
                }
            }
            int count = list.Count();
            max_length += 15;
            fields.Sort();

            int col_count = (int)(Screen.FromControl(this).Bounds.Width * 0.8f) / max_length;
            int row_count = fields.Count / col_count + ((fields.Count % col_count == 0) ? 0 : 1);
            int row_height = 20;
            selectform.MinimumSize = new Size(col_count * max_length, row_count * row_height);
            IList<string> result = new List<string>();

            Dictionary<string, string> telemDic = DictionaryTools.getTelemDic();
            for (int i = 0; i < fields.Count; i++)
            {
                string name = fields[i];
                if (telemDic.ContainsKey(name))
                    name = telemDic[fields[i]];

                CheckBox chk_box = new CheckBox
                {
                    // dont change to ToString() = null exception
                    Checked = qv.Tag != null && qv.Tag.ToString() == fields[i],

                    //Text = fields[i],
                    Text = name,
                    Name = fields[i],
                    Tag = qv,
                    Location = new Point(5 + (i / row_count) * (max_length + 5), 2 + (i % row_count) * row_height),

                    Size = new Size(max_length, row_height)
                };
                chk_box.CheckedChanged += chk_box_quickview_CheckedChanged;
                if (chk_box.Checked)
                    chk_box.BackColor = Color.Green;
                selectform.Controls.Add(chk_box);
                Application.DoEvents();
            }

            selectform.ShowDialog(this);
        }

        private void quickView_load_DoubleClick(object sender, EventArgs e)
        {
            QuickView qv = (QuickView)sender;

            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 50,
                Text = "Display This",
                AutoSize = true,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };
            ThemeManager.ApplyThemeTo(selectform);

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();
            int max_length = 0;
            List<string> fields = new List<string>();

            List<System.Reflection.PropertyInfo> list = new List<System.Reflection.PropertyInfo>();
            foreach (var field in test.GetProperties())//in隔开，右边集合左边变量
            {
                list.Add(field);
                Console.WriteLine("name: " + field.Name);
                if (field.Name.Equals("battery_voltage") || field.Name.Equals("servo_voltage") || field.Name.Equals("land_stage") || field.Name.Equals("load2_voltage")
                    || field.Name.Equals("load3_voltage") || field.Name.Equals("load4_voltage") || field.Name.Equals("load5_voltage") ||
                    field.Name.Equals("ecu_voltage1")|| field.Name.Equals("ecu_voltage2") || field.Name.Equals("current") || field.Name.Equals("servo_current") 
                    || field.Name.Equals("load1_current") ||field.Name.Equals("load2_current") || field.Name.Equals("load3_current") || field.Name.Equals("load4_current") || field.Name.Equals("load5_current") ||
                    field.Name.Equals("ecu_voltage"))
                //       选取所需的值
                {
                    // field.Name has the field's name.
                    object fieldValue = field.GetValue(thisBoxed, null); // Get value
                    if (fieldValue == null)
                        continue;
                    
                    max_length = Math.Max(max_length, TextRenderer.MeasureText(field.Name, selectform.Font).Width);
                    fields.Add(field.Name);
                }
            }
            int count = list.Count();
            max_length += 15;
            fields.Sort();

            int col_count = (int)(Screen.FromControl(this).Bounds.Width * 0.8f) / max_length;
            int row_count = fields.Count / col_count + ((fields.Count % col_count == 0) ? 0 : 1);
            int row_height = 20;
            selectform.MinimumSize = new Size(col_count * max_length, row_count * row_height);
            IList<string> result = new List<string>();

            Dictionary<string, string> telemDic = DictionaryTools.getTelemDic();
            for (int i = 0; i < fields.Count; i++)
            {
                string name = fields[i];
                if (telemDic.ContainsKey(name))
                    name = telemDic[fields[i]];

                CheckBox chk_box = new CheckBox
                {
                    // dont change to ToString() = null exception
                    Checked = qv.Tag != null && qv.Tag.ToString() == fields[i],

                    //Text = fields[i],
                    Text = name,
                    Name = fields[i],
                    Tag = qv,
                    Location = new Point(5 + (i / row_count) * (max_length + 5), 2 + (i % row_count) * row_height),

                    Size = new Size(max_length, row_height)
                };
                chk_box.CheckedChanged += chk_box_quickview_CheckedChanged;
                if (chk_box.Checked)
                    chk_box.BackColor = Color.Green;
                selectform.Controls.Add(chk_box);
                Application.DoEvents();
            }

            selectform.ShowDialog(this);
        }

        private void leftConditionbox_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("发动机状态 : " + leftConditionbox.Text);
        }
        private void rightConditionbox_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("发动机状态 : " + rightConditionbox.Text);
        }

        private void quickView_ECU_DoubleClick(object sender, EventArgs e)
        {
            QuickView qv = (QuickView)sender;

            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 50,
                Text = "Display This",
                AutoSize = true,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };
            ThemeManager.ApplyThemeTo(selectform);

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();
            int max_length = 0;
            List<string> fields = new List<string>();

            List<System.Reflection.PropertyInfo> list = new List<System.Reflection.PropertyInfo>();
            foreach (var field in test.GetProperties())//in隔开，右边集合左边变量
            {
                list.Add(field);
                Console.WriteLine("name: " + field.Name);
                if (field.Name.Equals("ecu_head_tempreture") || field.Name.Equals("ecu_voltage1") || field.Name.Equals("ecu_voltage2") || field.Name.Equals("ecu_voltage") || field.Name.Equals("ecu_duty_cycle")
                    || field.Name.Equals("ignition_pump_choke"))
                //       选取所需的值
                {
                    // field.Name has the field's name.
                    object fieldValue = field.GetValue(thisBoxed, null); // Get value
                    if (fieldValue == null)
                        continue;
                    
                    max_length = Math.Max(max_length, TextRenderer.MeasureText(field.Name, selectform.Font).Width);
                    fields.Add(field.Name);
                }
            }
            int count = list.Count();
            max_length += 15;
            fields.Sort();

            int col_count = (int)(Screen.FromControl(this).Bounds.Width * 0.8f) / max_length;
            int row_count = fields.Count / col_count + ((fields.Count % col_count == 0) ? 0 : 1);
            int row_height = 20;
            selectform.MinimumSize = new Size(col_count * max_length, row_count * row_height);
            IList<string> result = new List<string>();

            Dictionary<string, string> telemDic = DictionaryTools.getTelemDic();
            for (int i = 0; i < fields.Count; i++)
            {
                string name = fields[i];
                if (telemDic.ContainsKey(name))
                    name = telemDic[fields[i]];

                CheckBox chk_box = new CheckBox
                {
                    // dont change to ToString() = null exception
                    Checked = qv.Tag != null && qv.Tag.ToString() == fields[i],

                    //Text = fields[i],
                    Text = name,
                    Name = fields[i],
                    Tag = qv,
                    Location = new Point(5 + (i / row_count) * (max_length + 5), 2 + (i % row_count) * row_height),

                    Size = new Size(max_length, row_height)
                };
                chk_box.CheckedChanged += chk_box_quickview_CheckedChanged;
                if (chk_box.Checked)
                    chk_box.BackColor = Color.Green;
                selectform.Controls.Add(chk_box);
                Application.DoEvents();
            }

            selectform.ShowDialog(this);
        }

        private void quickView_attitude_DoubleClick(object sender, EventArgs e)
        {
            QuickView qv = (QuickView)sender;

            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 50,
                Text = "Display This",
                AutoSize = true,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };
            ThemeManager.ApplyThemeTo(selectform);

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();
            int max_length = 0;
            List<string> fields = new List<string>();

            List<System.Reflection.PropertyInfo> list = new List<System.Reflection.PropertyInfo>();
            foreach (var field in test.GetProperties())//in隔开，右边集合左边变量
            {
                list.Add(field);
                Console.WriteLine("name: " + field.Name);
                if (field.Name.Equals("roll") || field.Name.Equals("pitch") || field.Name.Equals("yaw") || field.Name.Equals("accel_cal_x")
                    || field.Name.Equals("accel_cal_y") || field.Name.Equals("accel_cal_z") || field.Name.Equals("angle_x") ||
                    field.Name.Equals("angle_y") || field.Name.Equals("angle_z"))
                //       选取所需的值
                {
                    // field.Name has the field's name.
                    object fieldValue = field.GetValue(thisBoxed, null); // Get value
                    if (fieldValue == null)
                        continue;
                    
                    max_length = Math.Max(max_length, TextRenderer.MeasureText(field.Name, selectform.Font).Width);
                    fields.Add(field.Name);
                }
            }
            int count = list.Count();
            max_length += 15;
            fields.Sort();

            int col_count = (int)(Screen.FromControl(this).Bounds.Width * 0.8f) / max_length;
            int row_count = fields.Count / col_count + ((fields.Count % col_count == 0) ? 0 : 1);
            int row_height = 20;
            selectform.MinimumSize = new Size(col_count * max_length, row_count * row_height);
            IList<string> result = new List<string>();

            Dictionary<string, string> telemDic = DictionaryTools.getTelemDic();
            for (int i = 0; i < fields.Count; i++)
            {
                string name = fields[i];
                if (telemDic.ContainsKey(name))
                    name = telemDic[fields[i]];

                CheckBox chk_box = new CheckBox
                {
                    // dont change to ToString() = null exception
                    Checked = qv.Tag != null && qv.Tag.ToString() == fields[i],

                    //Text = fields[i],
                    Text = name,
                    Name = fields[i],
                    Tag = qv,
                    Location = new Point(5 + (i / row_count) * (max_length + 5), 2 + (i % row_count) * row_height),

                    Size = new Size(max_length, row_height)
                };
                chk_box.CheckedChanged += chk_box_quickview_CheckedChanged;
                if (chk_box.Checked)
                    chk_box.BackColor = Color.Green;
                selectform.Controls.Add(chk_box);
                Application.DoEvents();
            }

            selectform.ShowDialog(this);
        }

        private void quickView_speed_DoubleClick(object sender, EventArgs e)
        {
            QuickView qv = (QuickView)sender;

            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 50,
                Text = "Display This",
                AutoSize = true,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };
            ThemeManager.ApplyThemeTo(selectform);

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();
            int max_length = 0;
            List<string> fields = new List<string>();

            List<System.Reflection.PropertyInfo> list = new List<System.Reflection.PropertyInfo>();
            foreach (var field in test.GetProperties())//in隔开，右边集合左边变量
            {
                list.Add(field);
                Console.WriteLine("name: " + field.Name);
                if (field.Name.Equals("lng") || field.Name.Equals("lat") || field.Name.Equals("alt") || field.Name.Equals("airspeed")
                    || field.Name.Equals("east_speed") || field.Name.Equals("north_speed") || field.Name.Equals("air_speed"))
                //       选取所需的值
                {
                    // field.Name has the field's name.
                    object fieldValue = field.GetValue(thisBoxed, null); // Get value
                    if (fieldValue == null)
                        continue;
                  
                    max_length = Math.Max(max_length, TextRenderer.MeasureText(field.Name, selectform.Font).Width);
                    fields.Add(field.Name);
                }
            }
            int count = list.Count();
            max_length += 15;
            fields.Sort();

            int col_count = (int)(Screen.FromControl(this).Bounds.Width * 0.8f) / max_length;
            int row_count = fields.Count / col_count + ((fields.Count % col_count == 0) ? 0 : 1);
            int row_height = 20;
            selectform.MinimumSize = new Size(col_count * max_length, row_count * row_height);
            IList<string> result = new List<string>();

            Dictionary<string, string> telemDic = DictionaryTools.getTelemDic();
            for (int i = 0; i < fields.Count; i++)
            {
                string name = fields[i];
                if (telemDic.ContainsKey(name))
                    name = telemDic[fields[i]];

                CheckBox chk_box = new CheckBox
                {
                    // dont change to ToString() = null exception
                    Checked = qv.Tag != null && qv.Tag.ToString() == fields[i],

                    //Text = fields[i],
                    Text = name,
                    Name = fields[i],
                    Tag = qv,
                    Location = new Point(5 + (i / row_count) * (max_length + 5), 2 + (i % row_count) * row_height),

                    Size = new Size(max_length, row_height)
                };
                chk_box.CheckedChanged += chk_box_quickview_CheckedChanged;
                if (chk_box.Checked)
                    chk_box.BackColor = Color.Green;
                selectform.Controls.Add(chk_box);
                Application.DoEvents();
            }

            selectform.ShowDialog(this);
        }

        private void clear_Click(object sender, EventArgs e)
        {
          //  this.richTextBox.Clear();
        }

        private void TelemetryFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
          
        private void label16_TextChanged(object sender, EventArgs e)
        {

        }

        private void quickView63_Load(object sender, EventArgs e)
        {

        }

        private void quickView64_Load(object sender, EventArgs e)
        {

        }

        private void quickView65_Load(object sender, EventArgs e)
        {

        }

        private void quickView3_Load(object sender, EventArgs e)
        {

        }


        
            //this.richTextBox.Clear();
            //this.tabControlactions.SelectedIndex = 6;
       
    }
}

