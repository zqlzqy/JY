using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.chao.views
{
    public partial class FlyToPointForm : Form
    {
        private List<KeyValuePair<int, string>> cmdList()
        {
            var temp = new List<KeyValuePair<int, string>>()
               {
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.Mode, "切换模式"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.Target, "向目标点飞行"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.Umbrella, "开伞"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.TakeOff, "起飞"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.Return_To_Launch, "一键返航"),
                   new KeyValuePair<int, string>((int) JYLink.JY_TASK_ID.Land, "降落"),
                  
               };
            return temp;
        }
        public Label flyToPointFrm_lbl_commandpoint
        {
            get { return lbl_commandpoint; }
        }

        public ComboBox flyToPointFrm_cbx_selectAircraft
        {
            get { return cbx_selectAircraft; }
        }
        public ComboBox flyToPointFrm_cbx_command
        {
            get { return cbx_command; }
        }
        public TextBox flyToPointFrm_tb_targetAlt
        {
            get { return tb_targetAlt; }
        }


        public Button flyToPointFrm_btn_ok
        {
            get { return btn_ok; }
        }
        public Button flyToPointFrm_btn_cancel
        {
            get { return btn_cancel; }
        }
        public FlyToPointForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            cbx_selectAircraft.DataSource = cmdList();
            cbx_selectAircraft.ValueMember = "Key";
            cbx_selectAircraft.DisplayMember = "Value";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string value = cbx_selectAircraft.SelectedValue.ToString();
            //MainForm.telecontrol_comPort.missionUpLoad(value);
        }
    }
}
