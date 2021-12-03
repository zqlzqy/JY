﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Controls.BackstageView;
using log4net;
using MissionPlanner.Controls;
using System.IO;
using System.Collections.Generic;
//using BrightIdeasSoftware;
using FBGroundControl;

namespace MissionPlanner.Utilities
{
    /// <summary>
    /// Helper class for the stylng 'theming' of forms and controls, and provides MessageBox
    /// replacements which are also styled
    /// </summary>
    public class ThemeManager
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Themes _currentTheme = Themes.BurntKermit;

        public static Themes CurrentTheme
        {
            get { return _currentTheme; }
        }

        public enum Themes
        {
            /// <summary>
            /// no theme - standard Winforms appearance
            /// </summary>
            None,

            /// <summary>
            /// Standard Planner Charcoal & Green colours
            /// </summary>
            BurntKermit,
            HighContrast,
            Test,
            Custom,
        }

        // Initialize to the default theme (BurntKermit)
        public static Color BGColor = Color.FromArgb(0x26, 0x27, 0x28);
        public static Color ControlBGColor = Color.FromArgb(0x43, 0x44, 0x45);
        public static Color TextColor = Color.White;
        public static Color ButBG;
        public static Color ButBorder;


        /// <summary>
        /// Will recursively apply the current theme to 'control'
        /// </summary>
        /// <param name="control"></param>
        public static void ApplyThemeTo(Control control)
        {
            switch (_currentTheme)
            {
                case Themes.BurntKermit:
                    ApplyBurntKermitTheme(control, 0);
                    break;

                case Themes.HighContrast:
                    ApplyHighContrast(control, 0);
                    break;

                case Themes.Test:
                    ApplyTestTheme(control, 0);
                    break;

                case Themes.Custom:
                    ApplyCustomTheme(control, 0);
                    break;

                default:
                    break;
            }
        }


        private static void ApplyCustomTheme(Control temp, int level)
        {
            if (level == 0)
            {
                temp.BackColor = BGColor;
                temp.ForeColor = TextColor;
            }

            foreach (Control ctl in temp.Controls)
            {
                if (ctl.GetType() == typeof (Panel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (GroupBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (TreeView))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    TreeView txtr = (TreeView) ctl;
                    txtr.LineColor = TextColor;
                }
                else if (ctl.GetType() == typeof (MyLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (Button))
                {
                    ctl.ForeColor = TextColor;
                    ctl.BackColor = ButBG;
                }
                else if (ctl.GetType() == typeof (MyButton))
                {
                    Controls.MyButton but = (MyButton) ctl;
                    but.BGGradTop = ButBG;
                    try
                    {
                        but.BGGradBot = Color.FromArgb(ButBG.ToArgb() - 0x333333);
                    }
                    catch
                    {
                    }
                    but.TextColor = TextColor;
                    but.Outline = ButBorder;
                }
                else if (ctl.GetType() == typeof (TextBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    TextBox txt = (TextBox) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (DomainUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    DomainUpDown txt = (DomainUpDown) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (GroupBox) || ctl.GetType() == typeof (UserControl))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (ZedGraph.ZedGraphControl))
                {
                    var zg1 = (ZedGraph.ZedGraphControl) ctl;
                    zg1.GraphPane.Chart.Fill = new ZedGraph.Fill(ControlBGColor);
                    zg1.GraphPane.Fill = new ZedGraph.Fill(BGColor);

                    foreach (ZedGraph.LineItem li in zg1.GraphPane.CurveList)
                        li.Line.Width = 2;

                    zg1.GraphPane.Title.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.XAxis.MajorTic.Color = TextColor;
                    zg1.GraphPane.XAxis.MinorTic.Color = TextColor;
                    zg1.GraphPane.YAxis.MajorTic.Color = TextColor;
                    zg1.GraphPane.YAxis.MinorTic.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MajorTic.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MinorTic.Color = TextColor;

                    zg1.GraphPane.XAxis.MajorGrid.Color = TextColor;
                    zg1.GraphPane.YAxis.MajorGrid.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MajorGrid.Color = TextColor;

                    zg1.GraphPane.YAxis.Scale.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.YAxis.Title.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.Y2Axis.Title.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.Y2Axis.Scale.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.XAxis.Scale.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.XAxis.Title.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.Legend.Fill = new ZedGraph.Fill(ControlBGColor);
                    zg1.GraphPane.Legend.FontSpec.FontColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BSE.Windows.Forms.Panel) || ctl.GetType() == typeof (SplitterPanel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor; // Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof(RadialGradientBG))
                {
                    var rbg = ctl as RadialGradientBG;
                    rbg.CenterColor = ControlBGColor;
                    rbg.OutsideColor = ButBG;
                }
                else if (ctl.GetType() == typeof(GradientBG))
                {
                    var rbg = ctl as GradientBG;
                    rbg.CenterColor = ControlBGColor;
                    rbg.OutsideColor = ButBG;
                }
                else if (ctl.GetType() == typeof (Form))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    //if (Program.IconFile != null)
                    //    ((Form)ctl).Icon = Icon.FromHandle(((Bitmap)Program.IconFile).GetHicon());
                }
                else if (ctl.GetType() == typeof (RichTextBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    RichTextBox txtr = (RichTextBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (CheckedListBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    CheckedListBox txtr = (CheckedListBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabPage))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabPage txtr = (TabPage) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabControl))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabControl txtr = (TabControl) ctl;
                }
                else if (ctl.GetType() == typeof (DataGridView))
                {
                    ctl.ForeColor = TextColor;
                    DataGridView dgv = (DataGridView) ctl;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.BackgroundColor = BGColor;
                    DataGridViewCellStyle rs = new DataGridViewCellStyle();
                    rs.BackColor = ControlBGColor;
                    rs.ForeColor = TextColor;
                    dgv.RowsDefaultCellStyle = rs;

                    DataGridViewCellStyle hs = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
                    hs.BackColor = BGColor;
                    hs.ForeColor = TextColor;

                    dgv.ColumnHeadersDefaultCellStyle = hs;
                    dgv.RowHeadersDefaultCellStyle = hs;
                }
                else if (ctl.GetType() == typeof (CheckBox) || ctl.GetType() == typeof (MavlinkCheckBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    CheckBox CHK = (CheckBox) ctl;
                    // CHK.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (ComboBox) || ctl.GetType() == typeof (MavlinkComboBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    ComboBox CMB = (ComboBox) ctl;
                    CMB.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (NumericUpDown) || ctl.GetType() == typeof (MavlinkNumericUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (TrackBar))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (LinkLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    LinkLabel LNK = (LinkLabel) ctl;
                    LNK.ActiveLinkColor = TextColor;
                    LNK.LinkColor = TextColor;
                    LNK.VisitedLinkColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BackstageView))
                {
                    var bsv = ctl as BackstageView;

                    bsv.BackColor = BGColor;
                    bsv.ButtonsAreaBgColor = ControlBGColor;
                    bsv.HighlightColor2 = Color.FromArgb(0x94, 0xc1, 0x1f);
                    bsv.HighlightColor1 = Color.FromArgb(0x40, 0x57, 0x04);
                    bsv.SelectedTextColor = Color.White;
                    bsv.UnSelectedTextColor = Color.Gray;
                    bsv.ButtonsAreaPencilColor = Color.DarkGray;
                }
                else if (ctl.GetType() == typeof (HorizontalProgressBar2) ||
                         ctl.GetType() == typeof (VerticalProgressBar2))
                {
                    ((HorizontalProgressBar2) ctl).BackgroundColor = ControlBGColor;
                    ((HorizontalProgressBar2) ctl).ValueColor = Color.FromArgb(148, 193, 31);
                }
                else if (ctl.GetType() == typeof(MyProgressBar))
                {
                    ((MyProgressBar)ctl).BGGradBot = ControlBGColor;
                    ((MyProgressBar)ctl).BGGradTop = BGColor;
                }

                if (ctl.Controls.Count > 0)
                    ApplyCustomTheme(ctl, 1);
            }
        }

        private static void ApplyTestTheme(Control temp, int level)
        {
            foreach (Control ctl in temp.Controls)
            {
                if (ctl.GetType() == typeof (MyButton))
                {
                    Controls.MyButton but = (MyButton) ctl;
                    but.BGGradTop = SystemColors.ControlLight;
                    but.BGGradBot = SystemColors.ControlDark;
                    but.TextColor = SystemColors.ControlText;
                    but.Outline = SystemColors.ControlDark;
                }

                if (ctl.Controls.Count > 0)
                    ApplyTestTheme(ctl, 1);
            }
        }

        private static void ApplyHighContrast(Control temp, int level)
        {
            unchecked
            {
                BGColor = Color.FromArgb((int) 0xffeeeeee); // background
                ControlBGColor = Color.FromArgb((int) 0xffe2e2e2); // editable bg color
                TextColor = Color.Black;
                ButBG = Color.FromArgb((int) 0xffffff99);
            }

            if (level == 0)
            {
                temp.BackColor = BGColor;
                temp.ForeColor = TextColor;
            }

            foreach (Control ctl in temp.Controls)
            {
                if (ctl.GetType() == typeof (Panel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (GroupBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (MyLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (Button))
                {
                    ctl.ForeColor = TextColor;
                    ctl.BackColor = ButBG;
                }
                else if (ctl.GetType() == typeof (MyButton))
                {
                    Controls.MyButton but = (MyButton) ctl;
                    but.BGGradTop = ButBG;
                    but.BGGradBot = Color.FromArgb(ButBG.ToArgb() - 0x333333);
                    but.TextColor = TextColor;
                    but.Outline = ButBorder;
                }
                else if (ctl.GetType() == typeof (TextBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    TextBox txt = (TextBox) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (DomainUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    DomainUpDown txt = (DomainUpDown) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                //else if (ctl.GetType() == typeof (GroupBox) || ctl.GetType() == typeof (UserControl) ||
                //         ctl.GetType() == typeof (DataTreeListView))
                //{
                //    ctl.BackColor = BGColor;
                //    ctl.ForeColor = TextColor;
                //}
                else if (ctl.GetType() == typeof (ZedGraph.ZedGraphControl))
                {
                    var zg1 = (ZedGraph.ZedGraphControl) ctl;
                    zg1.GraphPane.Chart.Fill = new ZedGraph.Fill(ControlBGColor);
                    zg1.GraphPane.Fill = new ZedGraph.Fill(BGColor);

                    foreach (ZedGraph.LineItem li in zg1.GraphPane.CurveList)
                        li.Line.Width = 2;

                    zg1.GraphPane.Title.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.XAxis.MajorTic.Color = TextColor;
                    zg1.GraphPane.XAxis.MinorTic.Color = TextColor;
                    zg1.GraphPane.YAxis.MajorTic.Color = TextColor;
                    zg1.GraphPane.YAxis.MinorTic.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MajorTic.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MinorTic.Color = TextColor;

                    zg1.GraphPane.XAxis.MajorGrid.Color = TextColor;
                    zg1.GraphPane.YAxis.MajorGrid.Color = TextColor;
                    zg1.GraphPane.Y2Axis.MajorGrid.Color = TextColor;

                    zg1.GraphPane.YAxis.Scale.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.YAxis.Title.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.Y2Axis.Title.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.Y2Axis.Scale.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.XAxis.Scale.FontSpec.FontColor = TextColor;
                    zg1.GraphPane.XAxis.Title.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.Legend.Fill = new ZedGraph.Fill(ControlBGColor);
                    zg1.GraphPane.Legend.FontSpec.FontColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BSE.Windows.Forms.Panel) || ctl.GetType() == typeof (SplitterPanel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor; // Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof (RadialGradientBG))
                {
                    var rbg = ctl as RadialGradientBG;
                    rbg.CenterColor = ControlBGColor;
                    rbg.OutsideColor = ButBG;
                }
                else if (ctl.GetType() == typeof(GradientBG))
                {
                    var rbg = ctl as GradientBG;
                    rbg.CenterColor = ControlBGColor;
                    rbg.OutsideColor = ButBG;
                }
                else if (ctl.GetType() == typeof (Form))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    //if (Program.IconFile != null)
                    //    ((Form)ctl).Icon = Icon.FromHandle(((Bitmap)Program.IconFile).GetHicon());
                }
                else if (ctl.GetType() == typeof (RichTextBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    RichTextBox txtr = (RichTextBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (CheckedListBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    CheckedListBox txtr = (CheckedListBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabPage))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabPage txtr = (TabPage) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabControl))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabControl txtr = (TabControl) ctl;
                }
                else if (ctl.GetType() == typeof (DataGridView))
                {
                    ctl.ForeColor = TextColor;
                    DataGridView dgv = (DataGridView) ctl;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.BackgroundColor = BGColor;
                    DataGridViewCellStyle rs = new DataGridViewCellStyle();
                    rs.BackColor = ControlBGColor;
                    rs.ForeColor = TextColor;
                    dgv.RowsDefaultCellStyle = rs;

                    dgv.AlternatingRowsDefaultCellStyle = rs;

                    DataGridViewCellStyle hs = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
                    hs.BackColor = BGColor;
                    hs.ForeColor = TextColor;

                    dgv.ColumnHeadersDefaultCellStyle = hs;
                    dgv.RowHeadersDefaultCellStyle = hs;
                }
                else if (ctl.GetType() == typeof (CheckBox) || ctl.GetType() == typeof (MavlinkCheckBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    CheckBox CHK = (CheckBox) ctl;
                    // CHK.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (ComboBox) || ctl.GetType() == typeof (MavlinkComboBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    ComboBox CMB = (ComboBox) ctl;
                    CMB.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (NumericUpDown) ||
                         ctl.GetType() == typeof (MavlinkNumericUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (TrackBar))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (LinkLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    LinkLabel LNK = (LinkLabel) ctl;
                    LNK.ActiveLinkColor = TextColor;
                    LNK.LinkColor = TextColor;
                    LNK.VisitedLinkColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BackstageView))
                {
                    var bsv = ctl as BackstageView;

                    bsv.BackColor = BGColor;
                    bsv.ButtonsAreaBgColor = ControlBGColor;
                    bsv.HighlightColor2 = Color.FromArgb(0x94, 0xc1, 0x1f);
                    bsv.HighlightColor1 = Color.FromArgb(0x40, 0x57, 0x04);
                    bsv.SelectedTextColor = Color.White;
                    bsv.UnSelectedTextColor = Color.Gray;
                    bsv.ButtonsAreaPencilColor = Color.DarkGray;
                }
                else if (ctl.GetType() == typeof (HorizontalProgressBar2) ||
                         ctl.GetType() == typeof (VerticalProgressBar2))
                {
                    ((HorizontalProgressBar2) ctl).BackgroundColor = ControlBGColor;
                    ((HorizontalProgressBar2) ctl).ValueColor = Color.FromArgb(148, 193, 31);
                }
                else if (ctl.GetType() == typeof(MyProgressBar))
                {
                    ((MyProgressBar)ctl).BGGradBot= ControlBGColor;
                    ((MyProgressBar)ctl).BGGradTop = BGColor;
                }

                if (ctl.Controls.Count > 0)
                    ApplyHighContrast(ctl, 1);
            }
        }

        private static void ApplyBurntKermitTheme(Control temp, int level)
        {
            BGColor = Color.FromArgb(0x26, 0x27, 0x28); // background
            ControlBGColor = Color.FromArgb(0x43, 0x44, 0x45); // editable bg color
            TextColor = Color.White;

            if (level == 0)
            {
                temp.BackColor = BGColor;
                temp.ForeColor = TextColor;
            }

            foreach (Control ctl in temp.Controls)
            {
                if (ctl.GetType() == typeof (TreeView))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    TreeView txtr = (TreeView) ctl;
                    txtr.LineColor = TextColor;
                }
                else if (ctl.GetType() == typeof (Panel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (GroupBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (MyLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (Button))
                {
                    ctl.ForeColor = Color.Black;
                }
                else if (ctl.GetType() == typeof (MyButton))
                {
                    Controls.MyButton but = (MyButton) ctl;
                }
                else if (ctl.GetType() == typeof (TextBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    TextBox txt = (TextBox) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (DomainUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    DomainUpDown txt = (DomainUpDown) ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (GroupBox) || ctl.GetType() == typeof (UserControl))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (ZedGraph.ZedGraphControl))
                {
                    var zg1 = (ZedGraph.ZedGraphControl) ctl;
                    zg1.GraphPane.Chart.Fill = new ZedGraph.Fill(Color.FromArgb(0x1f, 0x1f, 0x20));
                    zg1.GraphPane.Fill = new ZedGraph.Fill(Color.FromArgb(0x37, 0x37, 0x38));

                    try
                    {
                        foreach (ZedGraph.LineItem li in zg1.GraphPane.CurveList)
                            li.Line.Width = 2;
                    }
                    catch
                    {
                    }

                    zg1.GraphPane.Title.FontSpec.FontColor = TextColor;

                    zg1.GraphPane.XAxis.MajorTic.Color = Color.White;
                    zg1.GraphPane.XAxis.MinorTic.Color = Color.White;
                    zg1.GraphPane.YAxis.MajorTic.Color = Color.White;
                    zg1.GraphPane.YAxis.MinorTic.Color = Color.White;
                    zg1.GraphPane.Y2Axis.MajorTic.Color = Color.White;
                    zg1.GraphPane.Y2Axis.MinorTic.Color = Color.White;

                    zg1.GraphPane.XAxis.MajorGrid.Color = Color.White;
                    zg1.GraphPane.YAxis.MajorGrid.Color = Color.White;
                    zg1.GraphPane.Y2Axis.MajorGrid.Color = Color.White;

                    zg1.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.Y2Axis.Title.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.Y2Axis.Scale.FontSpec.FontColor = Color.White;

                    zg1.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;

                    zg1.GraphPane.Legend.Fill = new ZedGraph.Fill(Color.FromArgb(0x85, 0x84, 0x83));
                    zg1.GraphPane.Legend.FontSpec.FontColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BSE.Windows.Forms.Panel) || ctl.GetType() == typeof (SplitterPanel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor; // Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof (Form))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    //if (Program.IconFile != null)
                    //    ((Form)ctl).Icon = Icon.FromHandle(((Bitmap)Program.IconFile).GetHicon());
                }
                else if (ctl.GetType() == typeof (RichTextBox))
                {
                    //ctl.BackColor = ControlBGColor;
                    //ctl.ForeColor = TextColor;
                    RichTextBox txtr = (RichTextBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                    txtr.ForeColor = Color.WhiteSmoke;
                    txtr.BackColor = ControlBGColor;
                }
                else if (ctl.GetType() == typeof (CheckedListBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    CheckedListBox txtr = (CheckedListBox) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabPage))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabPage txtr = (TabPage) ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof (TabControl))
                {
                    ctl.BackColor = BGColor; //ControlBGColor
                    ctl.ForeColor = TextColor;
                    TabControl txtr = (TabControl) ctl;
                }
                else if (ctl.GetType() == typeof (DataGridView))
                {
                    ctl.ForeColor = TextColor;
                    DataGridView dgv = (DataGridView) ctl;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.BackgroundColor = BGColor;
                    DataGridViewCellStyle rs = new DataGridViewCellStyle();
                    rs.BackColor = ControlBGColor;
                    rs.ForeColor = TextColor;
                    dgv.RowsDefaultCellStyle = rs;

                    dgv.AlternatingRowsDefaultCellStyle.BackColor = BGColor;

                    DataGridViewCellStyle hs = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
                    hs.BackColor = BGColor;
                    hs.ForeColor = TextColor;

                    dgv.ColumnHeadersDefaultCellStyle = hs;
                    dgv.RowHeadersDefaultCellStyle = hs;
                }
                else if (ctl.GetType() == typeof (CheckBox) || ctl.GetType() == typeof (MavlinkCheckBox))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    CheckBox CHK = (CheckBox) ctl;
                    // CHK.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (ComboBox) || ctl.GetType() == typeof (MavlinkComboBox))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                    ComboBox CMB = (ComboBox) ctl;
                    CMB.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof (NumericUpDown) || ctl.GetType() == typeof (MavlinkNumericUpDown))
                {
                    ctl.BackColor = ControlBGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (TrackBar))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                }
                else if (ctl.GetType() == typeof (LinkLabel))
                {
                    ctl.BackColor = BGColor;
                    ctl.ForeColor = TextColor;
                    LinkLabel LNK = (LinkLabel) ctl;
                    LNK.ActiveLinkColor = TextColor;
                    LNK.LinkColor = TextColor;
                    LNK.VisitedLinkColor = TextColor;
                }
                else if (ctl.GetType() == typeof (BackstageView))
                {
                    var bsv = ctl as BackstageView;

                    bsv.BackColor = BGColor;
                    bsv.ButtonsAreaBgColor = Color.Black; // ControlBGColor;
                    bsv.HighlightColor2 = Color.FromArgb(0x94, 0xc1, 0x1f);
                    bsv.HighlightColor1 = Color.FromArgb(0x40, 0x57, 0x04);
                    bsv.SelectedTextColor = Color.White;
                    bsv.UnSelectedTextColor = Color.WhiteSmoke;
                    bsv.ButtonsAreaPencilColor = Color.DarkGray;
                }
                else if (ctl.GetType() == typeof (HorizontalProgressBar2) ||
                         ctl.GetType() == typeof (VerticalProgressBar2))
                {
                    ((HorizontalProgressBar2) ctl).BackgroundColor = ControlBGColor;
                    ((HorizontalProgressBar2) ctl).ValueColor = Color.FromArgb(148, 193, 31);
                }

                if (ctl.Controls.Count > 0)
                    ApplyBurntKermitTheme(ctl, 1);
            }
        }
    }
}