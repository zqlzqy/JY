using GMap.NET.MapProviders;
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
using MissionPlanner.Controls;
using MissionPlanner;
using System.Globalization;

namespace FBGroundControl.Forms
{
    public partial class MapSourceSet : Form
    {
        private string foldPath = "";
        public TextBox saveMap_textBoxShow
        {
            get { return this.saveMap_textBox; }
        }

        public MapSourceSet()
        {
            InitializeComponent();

            this.saveMap_textBox.Text = MainForm.instance.mapSourceLoaction;


            mapSource_comboBox.ValueMember = "Name";
            mapSource_comboBox.DataSource = GMapProviders.List.ToArray();
           // mapSource_comboBox.SelectedItem = MainForm.instance.myGMAP1.MapProvider;//MainMap
            mapSource_comboBox.SelectedValueChanged += mapSource_comboBox_SelectedValueChanged;

            string mapType = Settings.Instance["MapType"];
            if (!string.IsNullOrEmpty(mapType))
            {
                try
                {
                    var index = GMapProviders.List.FindIndex(x => (x.Name == mapType));

                    if (index != -1)
                        mapSource_comboBox.SelectedIndex = index;
                }
                catch
                {
                }
            }
            else
            {
                if (L10N.ConfigLang.IsChildOf(CultureInfo.GetCultureInfo("zh-Hans")))
                {
                    CustomMessageBox.Show("亲爱的中国用户，为保证地图使用正常，已为您将默认地图自动切换到具有中国特色的【谷歌中国卫星地图】！\r\n与默认【谷歌卫星地图】的区别：使用.cn服务器，加入火星坐标修正\r\n如果您所在的地区仍然无法使用，天书同时推荐必应或高德地图，其它地图由于没有加入坐标修正功能，为确保飞行安全，请谨慎选择", "默认地图已被切换");

                    try
                    {
                        var index = GMapProviders.List.FindIndex(x => (x.Name == "谷歌中国卫星地图"));

                        if (index != -1)
                            mapSource_comboBox.SelectedIndex = index;
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void mapSource_comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
               // MainForm.instance.myGMAP1.MapProvider = (GMapProvider)mapSource_comboBox.SelectedItem;
               // FlightData.mymap.MapProvider = (GMapProvider)mapSource_comboBox.SelectedItem;
                Settings.Instance["MapType"] = mapSource_comboBox.Text;
            }
            catch
            {
                CustomMessageBox.Show("Map change failed. try zooming out first.");
            }
        }

        /// <summary>
        /// 地图保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMap_textBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
               // MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.saveMap_textBox.Text = foldPath;
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 地图下载保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_button_Click(object sender, EventArgs e)
        {
            MapLoactionWriteXml();
            this.Close();
        }
        private void MapLoactionWriteXml()
        {
            DataTable student = new DataTable();
            student.Columns.Add("mapLoaction");

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);
            student.Rows[student.Rows.Count - 1][0] = this.saveMap_textBox.Text;

            DataSet ds = new DataSet();
            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\MapLoaction.xml");
        }
    }
}
