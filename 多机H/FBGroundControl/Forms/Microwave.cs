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
    public partial class Microwave : DockContent
    {
        public static string id
        {
            set;
            get; 
        }
        public static double lat
        {
            set;
            get;
        }
        public static double lng 
        {
            set;  
            get;
        }
        public Microwave()
        {
            InitializeComponent();
        }

        private void Microwave_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            bjdm.BGGradBot = bjdm.BGGradTop = Color.Gray;
            bjqf.BGGradBot = bjqf.BGGradTop = Color.Gray;
            dmc.BGGradBot = dmc.BGGradTop = Color.Gray;
            xxtp.BGGradBot = xxtp.BGGradTop = Color.Gray;
            exbm.BGGradBot = exbm.BGGradTop = Color.Gray;
            cpjb.BGGradBot = cpjb.BGGradTop = Color.Gray;
            pljb.BGGradBot = pljb.BGGradTop = Color.Gray;
            glgl.BGGradBot = glgl.BGGradTop = Color.Gray;
            //bool bit7 = (CurrentState.wby_status1 & 128) == 128; 
            //bool bit6 = (CurrentState.wby_status1 & 64 )== 64;
            //bool bit5 = (CurrentState.wby_status1 & 32) == 32 ;
            //bool bit4 = (CurrentState.wby_status1 & 16) == 16 ;
            //bool bit3 = (CurrentState.wby_status1 & 8) == 8;
            //bool bit2 = (CurrentState.wby_status1 & 4) == 4 ;
            //bool bit1 = (CurrentState.wby_status1 & 2) == 2 ;
            //bool bit0 = (CurrentState.wby_status1 & 1) == 1 ;
            //bool bit77 = (CurrentState.wby_status2 & 128) == 128; 
            //bool bit66 = (CurrentState.wby_status2 & 64) == 64;
            //bool bit55 = (CurrentState.wby_status2 & 32) == 32;
            //bool bit44 = (CurrentState.wby_status2 & 16) == 16;
            //bool bit33 = (CurrentState.wby_status2 & 8) == 8;
            //bool bit22 = (CurrentState.wby_status2 & 4) == 4;
            //bool bit11 = (CurrentState.wby_status2 & 2) == 2;
            //bool bit00 = (CurrentState.wby_status2 & 1) == 1;
            //if (bit0 == false && bit1 == false && bit2 == false)
            //{
            //    wbystatus.Text = "待机";
            //}
            //else if (bit0 == false && bit1 == false && bit2 == true)
            //{
            //    wbystatus.Text = "射检";
            //}
            //else if (bit0 == false && bit1 == true && bit2 == false)
            //{
            //    wbystatus.Text = "装订";
            //}
            //else if (bit0 == false && bit1 == true && bit2 == true)
            //{
            //    wbystatus.Text = "搜索";
            //}
            //else if (bit0 == true && bit1 == false && bit2 == false)
            //{
            //    wbystatus.Text = "跟踪";
            //}
            //if (bit5 == false )
            //{
            //    zdzt.Text = "未装订";
            //}
            //else
            //{
            //    zdzt.Text = "已装订";

            //}
            //if (bit6 == false && bit7 == false )
            //{
            //    sjzt.Text = "未射检";
            //}
            //else if (bit6 == false && bit7 == true )
            //{
            //     sjzt.Text = "射检异常";
            //}
            //else if (bit6 == true && bit7 == true)
            //{
            //    sjzt.Text = "射检正常";
            //}
            //if (bit77==true)
            //{
            //    bjdm.BGGradBot = bjdm.BGGradTop = Color.Green;
            //}
            //if (bit66 == true)
            //{
            //    bjqf.BGGradBot = bjqf.BGGradTop = Color.Green;
            //}
            //if (bit55 == true)
            //{
            //    dmc.BGGradBot = dmc.BGGradTop = Color.Green;
            //}
            //if (bit44== true)
            //{
            //    xxtp.BGGradBot = xxtp.BGGradTop = Color.Green;
            //}
            //if (bit33 == true)
            //{
            //    exbm.BGGradBot = exbm.BGGradTop = Color.Green;
            //}
            //if (bit22 == true)
            //{
            //    cpjb.BGGradBot = cpjb.BGGradTop = Color.Green;
            //}
            //if (bit11 == true)
            //{
            //    pljb.BGGradBot = pljb.BGGradTop = Color.Green;
            //}
            //if (bit00 == true)
            //{
            //    glgl.BGGradBot = glgl.BGGradTop = Color.Green;
            //}
            //if (CurrentState.bjsf_fkj>=30)
            //{
            //    txfx.Text="右";
            //}
            //else if (CurrentState.bjsf_fkj<=-30)
            //{
            //    txfx.Text="左";
            //}
            //else
            //{
            //    txfx.Text="中";
            //}
            //bd_id.Text = CurrentState.wby_id.ToString();
            //bj_id.Text = CurrentState.kdj_id.ToString();
            //mbsxj.Text =( CurrentState.bj_zxj/10.0).ToString();
            //xd_l.Text = (CurrentState.bj_kdj_l/100.0).ToString();
            //v_60.Text = (CurrentState.v_60/100.0).ToString();
            //v1_28.Text = (CurrentState.v1_28/100.0).ToString();
            //v2_28.Text = (CurrentState.v2_28/100.0).ToString();
            //v_12.Text = (CurrentState.v_12/100.0).ToString();
            //pzcyz.Text = CurrentState.pz_cyz.ToString();
            //id = kdjid.Text;
            //lat = Convert.ToDouble(kdjlat.Text.Trim());
            //lng = Convert.ToDouble(kdjlng.Text.Trim());
        }

        private void kdjid_TextChanged(object sender, EventArgs e)
        {
            id = kdjid.Text;
            lat = Convert.ToDouble(kdjlat.Text.Trim());
            lng = Convert.ToDouble(kdjlng.Text.Trim());
        }
    }
}
