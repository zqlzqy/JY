using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class DataRecordSet : Form
    {
        public bool isChecked;
        public string foldPath = "";
        public delegate void DataRecordSetView (bool isChecked);//委托类型声明
        public static event DataRecordSetView DataRecordSetHandler;//基于委托的事件对象
        public DataRecordSet()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 选择目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveLocation_textBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                // MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.saveLocation_textBox.Text = foldPath;
            }
        }
        /// <summary>
        /// 使用数据记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void user_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (user_checkBox.Checked)
            {
                if (MainForm.instance.isConnect && DataRecordSetHandler != null)
                {
                    isChecked = true;
                }
                else
                {
                    MessageBox.Show("请先连接飞控");
                    user_checkBox.Checked = false;
                    isChecked = false;
                    return;
                }
            }
            else {
                isChecked = false;
            }
        }
        /// <summary>
        /// 保存数据记录设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_button_Click(object sender, EventArgs e)
        {
            DataRecordSetWriteXml();
            if (DataRecordSetHandler != null)
            {
                DataRecordSetHandler(isChecked);
            }
            this.Close();
        }
        public void DataRecordSetWriteXml()
        {
            DataSet ds = new DataSet();
            DataTable student = new DataTable();
            student.Columns.Add("CheckedStatus");
            student.Columns.Add("SaveLocation");
            

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);
            student.Rows[student.Rows.Count - 1][0] = this.user_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][1] = this.saveLocation_textBox.Text;

            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\dataRecordSet.xml");
           
        }
    }
}
