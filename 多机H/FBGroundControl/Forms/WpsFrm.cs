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
using System.Threading;
using MissionPlanner;

namespace FBGroundControl.Forms
{

    public partial class WpsFrm : DockContent
    {
        public bool isShow {get;set; }
     
        public delegate void IsShowWpsFrm(bool isShow);//委托类型声明
        public static event IsShowWpsFrm IsShowWpsFrmHandler;//基于委托的事件对象
       
        public WpsFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存航线规划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveRoute_button_Click(object sender, EventArgs e)
        {
            MainForm.instance.SaveFile_Click(null,null);
        }

        /// 查询HOME点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeSearch_button_Click(object sender, EventArgs e)
        {
            MainForm.instance.btnReadHome_ItemClick(null, null);
        }
        
        /// <summary>
        /// 加载航线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteLoading_Button_Click(object sender, EventArgs e)
        {
            MainForm.instance.LoadFile_Click();
        }
        /// <summary>
        /// 航线规划清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteClear_button_Click(object sender, EventArgs e)
        {
            MainForm.instance.clearMissionToolStripMenuItem_Click(null, null);
        }
        /// <summary>
        /// 航线上传（写入航点）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteIUpLoad_Button_Click(object sender, EventArgs e)
        {
            MainForm.instance.btnWriteWaypoints_ItemClick(null,null);
        }
        /// <summary>
        /// 航线查询（读取航点）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteSearch_button_Click(object sender, EventArgs e)
        {
            MainForm.instance.btnReadWaypoints_ItemClick(null,null);
        }
        /// <summary>
        /// 飞控航线规划清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FLyRoute_button_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.instance.btnReadHome_ItemClick2(null, null);
        }
        public Button ChangeHeading_ItemReview
        {
            get { return config_change; }
        }
        private void WpsFrm_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //JYLink.jylink_hight_setup hightparam = new JYLink.jylink_hight_setup();
            //hightparam.hightmode = byte.Parse("1");
            //JYLinkTeleCtrl port = MainForm.telecontrol_comPort;
            ////判断是否连接
            //if (!port.BaseStream.IsOpen)
            //{
            //    MessageBox.Show("Please Connect First!");
            //    return;
            //}

            //bool result = port.setuphight(hightparam);
            ////判断执行结果
            //if (result)
            //{
            //    MessageBox.Show("高度源参数设置成功");
            //}
            //else
            //{
            //    MessageBox.Show("高度源参数设置失败");
            //}
        }

        private void ChangeHeading_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Commands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void config_change_Click(object sender, EventArgs e)
        {

        }
     
        
    }
}
