using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System.Reflection;
using ZedGraph;
using System.Threading;
using FBGroundControl;

namespace MissionPlanner.GCSViews
{
    /// <summary>
    /// 遥测数据曲线图
    /// </summary>
    public partial class TelemetryMgr : MyUserControl, IDeactivate, IActivate
    {
        int tickStart;
        public static bool threadrun;
        Thread thisthread;
        public TelemetryMgr()
        {
            InitializeComponent();

            if (Settings.Instance["Tuning_Graph_Selected"] != null)
            {
                string line = Settings.Instance["Tuning_Graph_Selected"].ToString();
                string[] lines = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string option in lines)
                {
                    using (var cb = new CheckBox { Name = option, Checked = true })
                    {
                        chk_box_CheckedChanged(cb, EventArgs.Empty);
                    }
                }
            }
            else
            {
                using (var cb = new CheckBox { Name = "roll", Checked = true })
                {
                    chk_box_CheckedChanged(cb, EventArgs.Empty);
                }
                using (var cb = new CheckBox { Name = "pitch", Checked = true })
                {
                    chk_box_CheckedChanged(cb, EventArgs.Empty);
                }
                using (var cb = new CheckBox { Name = "nav_roll", Checked = true })
                {
                    chk_box_CheckedChanged(cb, EventArgs.Empty);
                }
                using (var cb = new CheckBox { Name = "nav_pitch", Checked = true })
                {
                    chk_box_CheckedChanged(cb, EventArgs.Empty);
                }
            }

            CreateChart(zg1);



        }

        private void mainloop()
        {
            DateTime tunning = DateTime.Now.AddSeconds(0);

            while (!IsHandleCreated)
            {
                Thread.Sleep(100);
            }

            threadrun = true;

            while (threadrun)
            {

                Thread.Sleep(50);
                updateBindingSource();

                if (tunning.AddMilliseconds(50) < DateTime.Now)
                {
                    double time = (Environment.TickCount - tickStart) / 1000.0;
                    if (list1item != null)
                        list1.Add(time, ConvertToDouble(list1item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list2item != null)
                        list2.Add(time, ConvertToDouble(list2item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list3item != null)
                        list3.Add(time, ConvertToDouble(list3item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list4item != null)
                        list4.Add(time, ConvertToDouble(list4item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list5item != null)
                        list5.Add(time, ConvertToDouble(list5item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list6item != null)
                        list6.Add(time, ConvertToDouble(list6item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list7item != null)
                        list7.Add(time, ConvertToDouble(list7item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list8item != null)
                        list8.Add(time, ConvertToDouble(list8item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list9item != null)
                        list9.Add(time, ConvertToDouble(list9item.GetValue(MainForm.comPort.JY.cs, null)));
                    if (list10item != null)
                        list10.Add(time, ConvertToDouble(list10item.GetValue(MainForm.comPort.JY.cs, null)));
                }


            }

        }

        private double ConvertToDouble(object input)
        {
            if (input.GetType() == typeof(float))
            {
                return (float)input;
            }
            if (input.GetType() == typeof(double))
            {
                return (double)input;
            }
            if (input.GetType() == typeof(ulong))
            {
                return (ulong)input;
            }
            if (input.GetType() == typeof(long))
            {
                return (long)input;
            }
            if (input.GetType() == typeof(int))
            {
                return (int)input;
            }
            if (input.GetType() == typeof(uint))
            {
                return (uint)input;
            }
            if (input.GetType() == typeof(short))
            {
                return (short)input;
            }
            if (input.GetType() == typeof(ushort))
            {
                return (ushort)input;
            }
            if (input.GetType() == typeof(bool))
            {
                return (bool)input ? 1 : 0;
            }
            if (input.GetType() == typeof(string))
            {
                double ans = 0;
                if (double.TryParse((string)input, out ans))
                {
                    return ans;
                }
            }

            if (input == null)
                throw new Exception("Bad Type Null");
            else
                throw new Exception("Bad Type " + input.GetType().ToString());
        }

        private void updateBindingSource()
        {
            MainForm.comPort.JY.cs.UpdateCurrentSettings(bindingSourceStatus);
            MainForm.comPort.JY.cs.UpdateCurrentSettings(bindingSourceGauges);
            //  CurrentState cur =(CurrentState) bindingSourceStatus.List[0];
        }


        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Tuning";
            myPane.XAxis.Title.Text = "Time (s)";
            myPane.YAxis.Title.Text = "Unit";

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            myPane.YAxis.Scale.Min = -40;
            myPane.YAxis.Scale.Max = 40;

            // Fill the axis background with a gradient
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Sample at 50ms intervals
            ZgTimer.Interval = 200;
            ZgTimer.Enabled = true;
            ZgTimer.Start();


            // Calculate the Axis Scale Ranges
            //zgc.AxisChange();

            //  tickStart = Environment.TickCount;
        }


        CurveItem list1curve;
        CurveItem list2curve;
        CurveItem list3curve;
        CurveItem list4curve;
        CurveItem list5curve;
        CurveItem list6curve;
        CurveItem list7curve;
        CurveItem list8curve;
        CurveItem list9curve;
        CurveItem list10curve;


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

        RollingPointPairList list1 = new RollingPointPairList(1200);
        RollingPointPairList list2 = new RollingPointPairList(1200);
        RollingPointPairList list3 = new RollingPointPairList(1200);
        RollingPointPairList list4 = new RollingPointPairList(1200);
        RollingPointPairList list5 = new RollingPointPairList(1200);
        RollingPointPairList list6 = new RollingPointPairList(1200);
        RollingPointPairList list7 = new RollingPointPairList(1200);
        RollingPointPairList list8 = new RollingPointPairList(1200);
        RollingPointPairList list9 = new RollingPointPairList(1200);
        RollingPointPairList list10 = new RollingPointPairList(1200);

        public void Activate()
        {
            OnResize(EventArgs.Empty);
            ZgTimer.Enabled = true;
            ZgTimer.Start();
            zg1.Refresh();
            zg1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Make sure that the curvelist has at least one curve
                if (zg1.GraphPane.CurveList.Count <= 0)
                    return;

                // Get the first CurveItem in the graph
                LineItem curve = zg1.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    return;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    return;

                // Time is measured in seconds
                double time = (Environment.TickCount - tickStart) / 1000.0;

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale xScale = zg1.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 10.0;
                }

                // Make sure the Y axis is rescaled to accommodate actual data
                zg1.AxisChange();

                // Force a redraw

                zg1.Invalidate();
            }
            catch
            {
            }
        }


        public void Deactivate()
        {
            ZgTimer.Stop();
        }
        void chk_log_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                zg1.GraphPane.YAxis.Type = AxisType.Log;
            }
            else
            {
                zg1.GraphPane.YAxis.Type = AxisType.Linear;
            }
        }
        private void zg1_DoubleClick(object sender, EventArgs e)
        {
            Form selectform = new Form
            {
                Name = "select",
                Width = 400,
                Height = 250,
                Text = "数据选择"
            };

            int x = 10;
            int y = 10;

            {
                //CheckBox chk_box = new CheckBox();
                //chk_box.Text = "Logarithmic";
                //chk_box.Name = "Logarithmic";
                //chk_box.Location = new Point(x, y);
                //chk_box.Size = new Size(100, 20);

                //selectform.Controls.Add(chk_box);
            }

            ThemeManager.ApplyThemeTo(selectform);



            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();

            foreach (var field in test.GetProperties())
            {
                if (field.Name.Equals("angle_x") || field.Name.Equals("angle_y") || field.Name.Equals("Accx") || field.Name.Equals("Accy") || field.Name.Equals("Accz"))
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
                    chk_box.Text = ToChina(field.Name);
                    //if (field.Name.Equals("angle_x"))
                    //{
                    //    chk_box.Text = "X向角速度";
                    //}
                    //if (field.Name.Equals("angle_y"))
                    //{
                    //    chk_box.Text = "Y向角速度";
                    //}
                    //if (field.Name.Equals("Accx"))
                    //{
                    //    chk_box.Text = "X向加速度";
                    //}
                    //if (field.Name.Equals("Accy"))
                    //{
                    //    chk_box.Text = "Y向加速度";
                    //}
                    //if (field.Name.Equals("Accz"))
                    //{
                    //    chk_box.Text = "Z向加速度";
                    //}
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
        private string ToChina(string text)
        {
            string s = "";
            if (text.Equals("angle_x"))
            {
                s = "X向角速度";
            }
            if (text.Equals("angle_y"))
            {
                s = "Y向角速度";
            }
            if (text.Equals("Accx"))
            {
                s = "X向加速度";
            }
            if (text.Equals("Accy"))
            {
                s = "Y向加速度";
            }
            if (text.Equals("Accz"))
            {
                s = "Z向加速度";
            }
            return s;
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
                    if (setupPropertyInfo(ref list1item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list1.Clear();
                        list1curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list1, Color.Red, SymbolType.None);
                    }
                }
                else if (list2item == null)
                {
                    if (setupPropertyInfo(ref list2item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list2.Clear();
                        list2curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list2, Color.Blue, SymbolType.None);
                    }
                }
                else if (list3item == null)
                {
                    if (setupPropertyInfo(ref list3item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list3.Clear();
                        list3curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list3, Color.Green,
                            SymbolType.None);
                    }
                }
                else if (list4item == null)
                {
                    if (setupPropertyInfo(ref list4item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list4.Clear();
                        list4curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list4, Color.Orange,
                            SymbolType.None);
                    }
                }
                else if (list5item == null)
                {
                    if (setupPropertyInfo(ref list5item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list5.Clear();
                        list5curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list5, Color.Yellow,
                            SymbolType.None);
                    }
                }
                else if (list6item == null)
                {
                    if (setupPropertyInfo(ref list6item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list6.Clear();
                        list6curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list6, Color.Magenta,
                            SymbolType.None);
                    }
                }
                else if (list7item == null)
                {
                    if (setupPropertyInfo(ref list7item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list7.Clear();
                        list7curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list7, Color.Purple,
                            SymbolType.None);
                    }
                }
                else if (list8item == null)
                {
                    if (setupPropertyInfo(ref list8item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list8.Clear();
                        list8curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list8, Color.LimeGreen,
                            SymbolType.None);
                    }
                }
                else if (list9item == null)
                {
                    if (setupPropertyInfo(ref list9item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list9.Clear();
                        list9curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list9, Color.Cyan, SymbolType.None);
                    }
                }
                else if (list10item == null)
                {
                    if (setupPropertyInfo(ref list10item, ((CheckBox)sender).Name, MainForm.comPort.JY.cs))
                    {
                        list10.Clear();
                        list10curve = zg1.GraphPane.AddCurve(ToChina(((CheckBox)sender).Name), list10, Color.Violet,
                            SymbolType.None);
                    }
                }
                else
                {
                    CustomMessageBox.Show("Max 10 at a time.");
                    ((CheckBox)sender).Checked = false;
                }
                ThemeManager.ApplyThemeTo(this);

                string selected = "";
                try
                {
                    foreach (var curve in zg1.GraphPane.CurveList)
                    {
                        selected = selected + curve.Label.Text + "|";
                    }
                }
                catch
                {
                }
                Settings.Instance["Tuning_Graph_Selected"] = selected;
            }
            else
            {
                ((CheckBox)sender).BackColor = Color.Transparent;

                // reset old stuff
                if (list1item != null && list1item.Name == ((CheckBox)sender).Name)
                {
                    list1item = null;
                    zg1.GraphPane.CurveList.Remove(list1curve);
                }
                if (list2item != null && list2item.Name == ((CheckBox)sender).Name)
                {
                    list2item = null;
                    zg1.GraphPane.CurveList.Remove(list2curve);
                }
                if (list3item != null && list3item.Name == ((CheckBox)sender).Name)
                {
                    list3item = null;
                    zg1.GraphPane.CurveList.Remove(list3curve);
                }
                if (list4item != null && list4item.Name == ((CheckBox)sender).Name)
                {
                    list4item = null;
                    zg1.GraphPane.CurveList.Remove(list4curve);
                }
                if (list5item != null && list5item.Name == ((CheckBox)sender).Name)
                {
                    list5item = null;
                    zg1.GraphPane.CurveList.Remove(list5curve);
                }
                if (list6item != null && list6item.Name == ((CheckBox)sender).Name)
                {
                    list6item = null;
                    zg1.GraphPane.CurveList.Remove(list6curve);
                }
                if (list7item != null && list7item.Name == ((CheckBox)sender).Name)
                {
                    list7item = null;
                    zg1.GraphPane.CurveList.Remove(list7curve);
                }
                if (list8item != null && list8item.Name == ((CheckBox)sender).Name)
                {
                    list8item = null;
                    zg1.GraphPane.CurveList.Remove(list8curve);
                }
                if (list9item != null && list9item.Name == ((CheckBox)sender).Name)
                {
                    list9item = null;
                    zg1.GraphPane.CurveList.Remove(list9curve);
                }
                if (list10item != null && list10item.Name == ((CheckBox)sender).Name)
                {
                    list10item = null;
                    zg1.GraphPane.CurveList.Remove(list10curve);
                }
            }
        }

        private void TelemetryMgr_Load(object sender, EventArgs e)
        {
            ShowStatus();
            thisthread = new Thread(mainloop);
            thisthread.IsBackground = true;
            thisthread.Start();

        }

        private void ShowStatus()
        {
            // localise it
            //Control tabStatus = sender as Control;

            //  tabStatus.SuspendLayout();

            //foreach (Control temp in tabStatus.Controls)
            {
                //  temp.DataBindings.Clear();
                //temp.Dispose();
            }
            //tabStatus.Controls.Clear();

            int x = 10;
            int y = 10;

            object thisBoxed = MainForm.comPort.JY.cs;
            Type test = thisBoxed.GetType();

            PropertyInfo[] props = test.GetProperties();

            //props

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
                }
                catch
                {
                    continue;
                }

                MyLabel lbl1 = null;
                MyLabel lbl2 = null;
                try
                {
                    var temp = pnlStatus.Controls.Find(field.Name, false);

                    if (temp.Length > 0)
                        lbl1 = (MyLabel)temp[0];

                    var temp2 = pnlStatus.Controls.Find(field.Name + "value", false);

                    if (temp2.Length > 0)
                        lbl2 = (MyLabel)temp2[0];
                }
                catch
                {
                }


                if (lbl1 == null)
                    lbl1 = new MyLabel();

                lbl1.Location = new Point(x, y);
                lbl1.Size = new Size(90, 13);
                lbl1.Text = field.Name;
                lbl1.Name = field.Name;
                lbl1.Visible = true;

                if (lbl2 == null)
                    lbl2 = new MyLabel();

                lbl2.AutoSize = false;

                lbl2.Location = new Point(lbl1.Right + 5, y);
                lbl2.Size = new Size(50, 13);
                //if (lbl2.Name == "")
                lbl2.DataBindings.Clear();
                lbl2.DataBindings.Add(new Binding("Text", bindingSourceStatus, field.Name, false,
                    DataSourceUpdateMode.Never, "0"));
                lbl2.Name = field.Name + "value";
                lbl2.Visible = true;
                //lbl2.Text = fieldValue.ToString();

                pnlStatus.Controls.Add(lbl1);
                pnlStatus.Controls.Add(lbl2);


                x += 0;
                y += 15;

                if (y > pnlStatus.Height - 30)
                {
                    x = lbl2.Right + 10; //+= 165;
                    y = 10;
                }
            }

            pnlStatus.Width = x;

            ThemeManager.ApplyThemeTo(pnlStatus);
        }

        private void TelemetryMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadrun = false;

            while (thisthread.IsAlive)
            {
                Application.DoEvents();
            }
        }

    }
}
