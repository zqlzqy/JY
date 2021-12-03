using MissionPlanner.Controls;
using MissionPlanner.GCSViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 遥测数据曲线图窗体
    /// </summary>
    public partial class EngineCheckFrm : Form
    {
      //  public MissionPlanner.Controls.MainSwitcher MyView;
        public EngineCheckFrm()
        {
            InitializeComponent();
            //TelemetryMgr _telemetryMgr = new TelemetryMgr();
            //_telemetryMgr.Dock = DockStyle.Fill;
            //this.Controls.Add(_telemetryMgr);    

            CreateChart(checkZedGraph);
        }

        private void zg1_Load(object sender, EventArgs e)
        {

        }

        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            myPane.Title.Text = "震动情况";
            myPane.XAxis.Title.Text = "[HZ]";
            myPane.YAxis.Title.Text = "[db]";




        }
    }
}
