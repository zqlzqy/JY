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
    public partial class panel_PickPoint : Form
    {
        public panel_PickPoint()
        {
            InitializeComponent();
        }
        public Button btn_copyReview
        {
            get  { return btn_copy; }
        }
        public Button btn_cancelReview
        {
            get { return btn_cancel; }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("");
            this.Close();
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.tb_latlng.Text);
        }
    }
}
