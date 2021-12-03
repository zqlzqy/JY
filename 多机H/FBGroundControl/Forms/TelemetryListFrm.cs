using MissionPlanner;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 遥测列表数据显示
    /// </summary>
    public partial class TelemetryListFrm : Form
    {
        public int tickStart;
        public static bool threadrun;
        public  Thread thisthread;
        public CurrentState cur = null;
        public Hashtable ht = new Hashtable(); //创建一个Hashtable实例
        public delegate void TelemetryMainLoop();//委托类型声明
        public static event TelemetryMainLoop TelemetryMainLoopHandler;//基于委托的事件对象
        public TelemetryListFrm()
        {
            InitializeComponent();
            telementry_listView.View = View.Details;
            //this.telementry_listView.Columns.Add("roll", 135, HorizontalAlignment.Center);
            //this.telementry_listView.Columns.Add("pitch", 135, HorizontalAlignment.Center);

            //this.telementry_listView.Items.Add("1");
            //this.telementry_listView.Items.Add("2");


            initData();

            //获取复选框选中项，初始化列表标题显示标题列
            if (Settings.Instance["Tuning_Graph_Selected"] != null && !"".Equals(Settings.Instance["Tuning_Graph_Selected"]))
            {
                string line = Settings.Instance["Tuning_Graph_Selected"].ToString();
                string[] lines = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string option in lines)
                {
                    foreach (DictionaryEntry de in ht)
                    {
                        if (option.Equals(de.Key))
                        {
                            using (var cb = new CheckBox { Name = option, Checked = true })
                            {
                                chk_box_CheckedChanged(cb, EventArgs.Empty);
                            }
                            if ("pitch".Equals(de.Key))
                            {
                                telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }

                        }

                    }

                }
            }
            else
            {
                foreach (DictionaryEntry de in ht)
                {
                    if ("roll".Equals(de.Key))
                    {
                        using (var cb = new CheckBox { Name = "roll", Checked = true })
                        {
                            chk_box_CheckedChanged(cb, EventArgs.Empty);
                        }
                        telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                    }
                }
                foreach (DictionaryEntry de in ht)
                {
                    if ("pitch".Equals(de.Key))
                    {
                        using (var cb = new CheckBox { Name = "pitch", Checked = true })
                        {
                            chk_box_CheckedChanged(cb, EventArgs.Empty);
                        }
                        telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                    }
                }
                //foreach (DictionaryEntry de in ht)
                //{
                //    if ("nav_roll".Equals(de.Key))
                //    {
                //        using (var cb = new CheckBox { Name = "nav_roll", Checked = true })
                //        {
                //            chk_box_CheckedChanged(cb, EventArgs.Empty);
                //        }
                //        telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                //    }
                //}
                //foreach (DictionaryEntry de in ht)
                //{
                //    if ("nav_pitch".Equals(de.Key))
                //    {
                //        using (var cb = new CheckBox { Name = "nav_pitch", Checked = true })
                //        {
                //            chk_box_CheckedChanged(cb, EventArgs.Empty);
                //        }
                //        telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                //    }
                //}


            }

        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void initData()
        {         
           if (bindingSourceStatus.List.Count > 0)
           {
               cur = (CurrentState)bindingSourceStatus.List[0];
           }
            //初始化标题

           object thisBoxed = MainForm.comPort.JY.cs;
           Type test = thisBoxed.GetType();

           PropertyInfo[] props = test.GetProperties();

           //props
           int index = 0;
           foreach (var field in props)
           {
               // field.Name has the field's name.
               object fieldValue;
               TypeCode typeCode;
               try
               {
                   fieldValue = field.GetValue(thisBoxed, null); // Get value

                   if (fieldValue == null)
                       continue;
                   // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                   typeCode = Type.GetTypeCode(fieldValue.GetType());

                   //添加标题
                   this.telementry_listView.Columns.Add(field.Name, 135, HorizontalAlignment.Center);
                   ht.Add(field.Name, index);
                   this.telementry_listView.Columns[index].Width = 0;
                   // this.telementry_listView.Items.Add("2");
                   index++;
               }
               catch
               {
                   continue;
               }

           }
            //定时器
           ZgTimer.Interval = 200;
           ZgTimer.Enabled = true;
           ZgTimer.Start();

        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        PropertyInfo list1item;
        PropertyInfo list2item;
        PropertyInfo list3item;
        PropertyInfo list4item;
        PropertyInfo list5item;
        PropertyInfo list6item;
        PropertyInfo list7item;
        PropertyInfo list8item;
        PropertyInfo list9item;
        PropertyInfo list10item;

        ListViewItem list1 = new ListViewItem();
        ListViewItem list2 = new ListViewItem();
        ListViewItem list3 = new ListViewItem();
        ListViewItem list4 = new ListViewItem();
        ListViewItem list5 = new ListViewItem();
        ListViewItem list6 = new ListViewItem();
        ListViewItem list7 = new ListViewItem();
        ListViewItem list8 = new ListViewItem();
        ListViewItem list9 = new ListViewItem();
        ListViewItem list10 = new ListViewItem();

        void chk_log_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                //zg1.GraphPane.YAxis.Type = AxisType.Log;
            }
            else
            {
                //zg1.GraphPane.YAxis.Type = AxisType.Linear;
            }
        }
       
        bool setupPropertyInfo(ref PropertyInfo input, string name, object source)
        {
            Type test = source.GetType();

            foreach (var field in test.GetProperties())
            {
                if (field.Name == name)
                {
                    input = field;
                    return true;
                }
            }

            return false;
        }

        void chk_box_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)sender).BackColor = Color.Green;

                if (list1item == null)
                {
                    list1.SubItems.Clear(); ;
                    if (setupPropertyInfo(ref list1item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }

                    }
                }
                else if (list2item == null)
                {
                    if (setupPropertyInfo(ref list2item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list2.SubItems.Clear(); 
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list3item == null)
                {
                    if (setupPropertyInfo(ref list3item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list3.SubItems.Clear(); 
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list4item == null)
                {
                    if (setupPropertyInfo(ref list4item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list4.SubItems.Clear(); 
                        
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list5item == null)
                {
                    if (setupPropertyInfo(ref list5item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list6item == null)
                {
                    if (setupPropertyInfo(ref list6item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list7item == null)
                {
                    if (setupPropertyInfo(ref list7item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list8item == null)
                {
                    if (setupPropertyInfo(ref list8item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list9item == null)
                {
                    if (setupPropertyInfo(ref list9item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else if (list10item == null)
                {
                    if (setupPropertyInfo(ref list10item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        foreach (DictionaryEntry de in ht)
                        {
                            if (de.Key.Equals(((CheckBox)sender).Text))
                            {
                                this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                            }
                        }
                    }
                }
                else
                {
                    CustomMessageBox.Show("Max 10 at a time.");
                    ((CheckBox)sender).Checked = false;
                }
                ThemeManager.ApplyThemeTo(this);

                string selected = "";
                //try
                //{
                //    foreach (var curve in zg1.GraphPane.CurveList)
                //    {
                //        selected = selected + curve.Label.Text + "|";
                //    }
                //}
                //catch
                //{
                //}
                Settings.Instance["Tuning_Graph_Selected"] = selected;
            }
            else
            {
                ((CheckBox)sender).BackColor = Color.Transparent;

                // reset old stuff
                if (list1item != null && list1item.Name == ((CheckBox)sender).Name)
                {
                    list1item = null;
                    //zg1.GraphPane.CurveList.Remove(list1curve);
                }
                if (list2item != null && list2item.Name == ((CheckBox)sender).Name)
                {
                    list2item = null;
                    // zg1.GraphPane.CurveList.Remove(list2curve);
                }
                if (list3item != null && list3item.Name == ((CheckBox)sender).Name)
                {
                    list3item = null;
                    //zg1.GraphPane.CurveList.Remove(list3curve);
                }
                if (list4item != null && list4item.Name == ((CheckBox)sender).Name)
                {
                    list4item = null;
                    // zg1.GraphPane.CurveList.Remove(list4curve);
                }
                if (list5item != null && list5item.Name == ((CheckBox)sender).Name)
                {
                    list5item = null;
                    // zg1.GraphPane.CurveList.Remove(list5curve);
                }
                if (list6item != null && list6item.Name == ((CheckBox)sender).Name)
                {
                    list6item = null;
                    // zg1.GraphPane.CurveList.Remove(list6curve);
                }
                if (list7item != null && list7item.Name == ((CheckBox)sender).Name)
                {
                    list7item = null;
                    // zg1.GraphPane.CurveList.Remove(list7curve);
                }
                if (list8item != null && list8item.Name == ((CheckBox)sender).Name)
                {
                    list8item = null;
                    //  zg1.GraphPane.CurveList.Remove(list8curve);
                }
                if (list9item != null && list9item.Name == ((CheckBox)sender).Name)
                {
                    list9item = null;
                    // zg1.GraphPane.CurveList.Remove(list9curve);
                }
                if (list10item != null && list10item.Name == ((CheckBox)sender).Name)
                {
                    list10item = null;
                    //zg1.GraphPane.CurveList.Remove(list10curve);
                }
            }
        }
        ///// <summary>
        ///// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelemetryListFrm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (TelemetryMainLoopHandler != null)
            {
                thisthread = new Thread(mainloop);
                thisthread.IsBackground = true;
                thisthread.Start();
            }
        }
        private void mainloop()
        {
            DateTime tunning = DateTime.Now.AddSeconds(0);

            while (!IsHandleCreated)
            {
                Thread.Sleep(1000);
            }
            threadrun = true;
            while (threadrun)
            {
                if (MainForm.isExitSystem)
                {
                    break;
                }

                Thread.Sleep(1000);
                ////更新数据源
                updateBindingSource();

                if (bindingSourceStatus.List.Count > 0)
                {
                    cur = (CurrentState)bindingSourceStatus.List[0];
                }



                if (tunning.AddMilliseconds(50) < DateTime.Now)
                {
                    double time = (Environment.TickCount - tickStart) / 1000.0;
                    if (list1item != null)
                    {
  //                      list1.SubItems.Clear();
                        list1.SubItems.Add(list1item.GetValue(MainForm.comPort.JY.cs, null).ToString());

                    }       
                    if (list2item != null)
                    {
                        list2.SubItems.Add(list2item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list3item != null)
                    {
                        list3.SubItems.Add(list3item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list4item != null)
                    {
                        list4.SubItems.Add(list4item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list5item != null)
                    {
                        list5.SubItems.Add(list5item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list6item != null)
                    {
                        list6.SubItems.Add(list6item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list7item != null)
                    {
                        list7.SubItems.Add(list7item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list8item != null)
                    {
                        list8.SubItems.Add(list8item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list9item != null)
                    {
                        list9.SubItems.Add(list9item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                    if (list10item != null)
                    {
                        list10.SubItems.Add(list10item.GetValue(MainForm.comPort.JY.cs, null).ToString());
                    }
                }







                //Type test = cur.GetType();
                //PropertyInfo[] props = test.GetProperties();

                //ListViewItem Item = null;
                //if (!MainForm.isExitSystem)
                //{
                //    Item = telementry_listView.Items.Add((telementry_listView.Items.Count + 1) + "");//定义Item变量
                //}
                //else
                //{
                //    break;
                //}
                //Item.SubItems.Clear();
                //foreach (var field in props)
                //{
                //    object fieldValue;
                //    try
                //    {
                //        fieldValue = field.GetValue(cur, null); // Get value

                //        if (fieldValue == null)
                //            continue;

                //        foreach (DictionaryEntry de in ht)
                //        {
                //            if (de.Key.Equals(field.Name))
                //            {


                //                Item.SubItems.Add(fieldValue.ToString());

                //                // this.telementry_listView.Columns[Convert.ToInt32(de.Value)].Width = 100;
                //            }
                //        }
                //    }
                //    catch
                //    {
                //        continue;
                //    }
                //}
                ////始终显示最新的一条数据
                //Item.EnsureVisible();

            }

        }
        private void updateBindingSource()
        {
            MainForm.comPort.JY.cs.UpdateCurrentSettings(bindingSourceStatus);
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelemetryListFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TelemetryMainLoopHandler != null)
            {
                threadrun = false;

                while (thisthread.IsAlive)
                {
                    Application.DoEvents();
                }
            }
        }

        private void telementry_listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Form selectform = new Form
            {
                Name = "select",
                Width = 50,
                Height = 550,
                Text = "Graph This"
            };

            int x = 10;
            int y = 10;

            {
                CheckBox chk_box = new CheckBox();
                chk_box.Text = "Logarithmic";
                chk_box.Name = "Logarithmic";
                chk_box.Location = new Point(x, y);
                chk_box.Size = new Size(100, 20);
                chk_box.CheckedChanged += chk_log_CheckedChanged;

                selectform.Controls.Add(chk_box);
            }

            ThemeManager.ApplyThemeTo(selectform);

            y += 40;

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();

            foreach (var field in test.GetProperties())
            {
                if (field.Name.Equals("satcount") || field.Name.Equals("lat") || field.Name.Equals("lng") || field.Name.Equals("alt") || field.Name.Equals("roll") ||
                     field.Name.Equals("pitch") || field.Name.Equals("yaw") || field.Name.Equals("airspeed") || field.Name.Equals("battery_voltage") ||
                     field.Name.Equals("current") || field.Name.Equals("accel_cal_x") || field.Name.Equals("accel_cal_y") || field.Name.Equals("accel_cal_z") ||
                     field.Name.Equals("second_count") || field.Name.Equals("barome_altitude") || field.Name.Equals("rpm") || field.Name.Equals("rpm1") ||
                     field.Name.Equals("east_speed") || field.Name.Equals("north_speed") || field.Name.Equals("air_speed") || field.Name.Equals("change_flag") ||
                     field.Name.Equals("setcontrol_mode") || field.Name.Equals("flightcontrol_mode") || field.Name.Equals("angle_x") || field.Name.Equals("angle_y") ||
                     field.Name.Equals("angle_z"))
                {

                    // field.Name has the field's name.
                    object fieldValue;
                    TypeCode typeCode;
                    try
                    {
                        fieldValue = field.GetValue(thisBoxed, null); // Get value

                        if (fieldValue == null)
                            continue;

                        // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                        typeCode = Type.GetTypeCode(fieldValue.GetType());
                    }
                    catch
                    {
                        continue;
                    }

                    if (
                        !(typeCode == TypeCode.Single || typeCode == TypeCode.Double || typeCode == TypeCode.Int32 ||
                          typeCode == TypeCode.UInt16))
                        continue;

                    CheckBox chk_box = new CheckBox();

                    ThemeManager.ApplyThemeTo(chk_box);

                    if (list1item != null && list1item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list2item != null && list2item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list3item != null && list3item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list4item != null && list4item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list5item != null && list5item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list6item != null && list6item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list7item != null && list7item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list8item != null && list8item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list9item != null && list9item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }
                    if (list10item != null && list10item.Name == field.Name)
                    {
                        chk_box.Checked = true;
                        chk_box.BackColor = Color.Green;
                    }

                    chk_box.Text = field.Name;
                    chk_box.Name = field.Name;
                    chk_box.Location = new Point(x, y);
                    chk_box.Size = new Size(100, 20);
                    chk_box.CheckedChanged += chk_box_CheckedChanged;

                    selectform.Controls.Add(chk_box);

                    Application.DoEvents();

                    x += 0;
                    y += 40;

                    if (y > selectform.Height - 50)
                    {
                        x += 100;
                        y = 10;

                        selectform.Width = x + 100;
                    }

                }



            }

            selectform.Show();
        }

  
    }
}
