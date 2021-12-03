using FBGroundControl.view;
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
    /// <summary>
    /// 视图设置
    /// </summary>
    public partial class ViewSetFrm : Form
    {
        public delegate void SaveViewSet(ViewSet _viewSet);//委托类型声明
        public static event SaveViewSet SaveViewSetHandler;//基于委托的事件对象
        public ViewSetFrm()
        {
            InitializeComponent();
        }
        //菜单栏
        public CheckBox menu_checkBoxShow {
            get { return this.menu_checkBox; }
        }
        //状态栏
        public CheckBox headstatus_checkBoxShow
        {
            get { return this.headstatus_checkBox; }
        }
        //头显区
        public CheckBox head_checkBoxShow
        {
            get { return this.head_checkBox; }
        }
        //立体显示
        public CheckBox solid_checkBoxShow
        {
            get { return this.solid_checkBox; }
        }
        //状态区
        public CheckBox mainstatus_checkBoxShow
        {
            get { return this.mainstatus_checkBox; }
        }
        //指令区
        public CheckBox commond_checkBoxShow
        {
            get { return this.commond_checkBox; }
        }
        //地图区
        public CheckBox map_checkBoxShow {
            get { return this.map_checkBox; }
        }

        public Button save_buttonShow {
            get { return this.save_button; }
        }
        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewSetFrm_Load(object sender, EventArgs e)
        {
            if (MainForm.instance._viewSet!= null)
            {
                this.menu_checkBox.Checked = MainForm.instance._viewSet.menuCheckbox;
                this.headstatus_checkBox.Checked = MainForm.instance._viewSet.headStatusCheckbox;
                this.head_checkBox.Checked = MainForm.instance._viewSet.headCheckbox;
                this.solid_checkBox.Checked = MainForm.instance._viewSet.solidCheckbox;
                this.mainstatus_checkBox.Checked = MainForm.instance._viewSet.mainStatusCheckbox;
                this.commond_checkBox.Checked = MainForm.instance._viewSet.commondCheckbox;
                this.map_checkBox.Checked = MainForm.instance._viewSet.mapCheckbox;
            }
            
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {

         //   Console.WriteLine("Double and byte arrays conversion sample.");
            
            //double d = 39.90;
            //Console.WriteLine("Double value: " + d.ToString());
            //byte[] bytes = ConvertDoubleToByteArray(d);
            //Console.WriteLine("Byte array value:");
            //Console.WriteLine(BitConverter.ToString(bytes));


            //float f = (float)100;
            //byte[] bytes1 = BitConverter.GetBytes(f);
            //float float1 = BitConverter.ToSingle(bytes1, 0);
            //Console.WriteLine(float1);
            //Console.WriteLine(BitConverter.ToString(bytes1));

            this.Close();
            
        }
        public static byte[] ConvertDoubleToByteArray(double d)
        {
            return BitConverter.GetBytes(d);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_button_Click(object sender, EventArgs e)
        {
            ViewSetWriteXml();
            if (SaveViewSetHandler != null)
            {
                SaveViewSetHandler(MainForm.instance._viewSet);
            }
            this.Close();
        }
        public void ViewSetWriteXml()
        {
            DataSet ds = new DataSet();
            DataTable student = new DataTable();
            student.Columns.Add("menu");
            student.Columns.Add("headStatus");
            student.Columns.Add("head");
            student.Columns.Add("mainStatus");
            student.Columns.Add("commond");
            student.Columns.Add("map");
            student.Columns.Add("solid");

            DataRow newRow = student.NewRow();
            student.Rows.Add(newRow);
            student.Rows[student.Rows.Count - 1][0] = this.menu_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][1] = this.headstatus_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][2] = this.head_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][3] = this.mainstatus_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][4] = this.commond_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][5] = this.map_checkBox.Checked;
            student.Rows[student.Rows.Count - 1][6] = this.solid_checkBox.Checked;
            
            ds.Tables.Add(student);
            ds.WriteXml(Application.StartupPath + "\\viewSet.xml");

            MainForm.instance._viewSet.menuCheckbox = this.menu_checkBox.Checked;
            MainForm.instance._viewSet.headStatusCheckbox = this.headstatus_checkBox.Checked;
            MainForm.instance._viewSet.headCheckbox = this.head_checkBox.Checked;
            MainForm.instance._viewSet.solidCheckbox = this.solid_checkBox.Checked;
            MainForm.instance._viewSet.mainStatusCheckbox = this.mainstatus_checkBox.Checked;
            MainForm.instance._viewSet.commondCheckbox = this.commond_checkBox.Checked;
            MainForm.instance._viewSet.mapCheckbox = this.map_checkBox.Checked;
        }

    }
}
