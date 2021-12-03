using FBGroundControl.chao.models;
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
    public partial class IDSetForm : Form
    {
        BindingList<AircraftModel> mAircrafts = new BindingList<AircraftModel>();
        BindingSource mBbindingSource = new BindingSource();
        public IDSetForm()
        {
            InitializeComponent();
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y,dataGridView.RowHeadersWidth - 4,
         e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,(e.RowIndex + 1).ToString(),dataGridView.RowHeadersDefaultCellStyle.Font,
                   rectangle, dataGridView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }

        private void IDSetForm_Load(object sender, EventArgs e)
        {
            dataGridView.CellClick +=new DataGridViewCellEventHandler(dataGridView_CellClick);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectCol = dataGridView.SelectedColumns.Count;
        }

        /// <summary>
        /// 发送指令查询飞控端，关于飞机的系统编号、自定义编号等属性。by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchIDBtn_Click(object sender, EventArgs e)
        {
            //TODO 
            mAircrafts.Add(new AircraftModel("0001", "plane01"));
            mAircrafts.Add(new AircraftModel("0002", "plane02"));
            mAircrafts.Add(new AircraftModel("0003", "plane03"));
            mBbindingSource.DataSource = mAircrafts;
            dataGridView.DataSource = mBbindingSource;
        }
        /// <summary>
        /// 设置飞控自定义编号。by lichao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setIDBtn_Click(object sender, EventArgs e)
        {
            //TODO

        }
    }
}
