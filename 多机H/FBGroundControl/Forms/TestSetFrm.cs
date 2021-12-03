using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class TestSetFrm : Form
    {
        public TestSetFrm()
        {
            InitializeComponent();


            lineConnectView.Dock = DockStyle.Fill;
            manualCheckView.Dock = DockStyle.Fill;
            stabilizeCheckView.Dock = DockStyle.Fill;
            attitudeCheckView.Dock = DockStyle.Fill;
            magneticView.Dock = DockStyle.Fill;
            mergencyView.Dock = DockStyle.Fill;
            ynamicPressurevView.Dock = DockStyle.Fill;
            passesView.Dock = DockStyle.Fill;
            finalConfirmationView.Dock = DockStyle.Fill;

            groupBox2.Controls.Add(lineConnectView);
            groupBox2.Controls.Add(manualCheckView);
            groupBox2.Controls.Add(stabilizeCheckView);
            groupBox2.Controls.Add(attitudeCheckView);
            groupBox2.Controls.Add(magneticView);
            groupBox2.Controls.Add(mergencyView);
            groupBox2.Controls.Add(ynamicPressurevView);
            groupBox2.Controls.Add(passesView);
            groupBox2.Controls.Add(finalConfirmationView);


            this.lineConnectView.LineConnect_checkBox.Click += new System.EventHandler(this.LineConnect_checkBox_Click);
            this.manualCheckView.Manual_checkBox.Click += new System.EventHandler(this.Manual_checkBox_Click);
            this.stabilizeCheckView.Stabilize_checkBox.Click += new System.EventHandler(this.Stabilize_checkBox_Click);
            this.attitudeCheckView.Attitude_checkBox.Click += new System.EventHandler(this.Attitude_checkBox_Click);
            this.magneticView.Magnetic_checkBox.Click += new System.EventHandler(this.Magnetic_checkBox_Click);
            this.mergencyView.Mergency_checkBox.Click += new System.EventHandler(this.Mergency_checkBox_Click);
            this.ynamicPressurevView.YnamicPressurev_checkBox.Click += new System.EventHandler(this.YnamicPressurev_checkBox_Click);
            this.passesView.Passes_checkBox.Click += new System.EventHandler(this.Passes_checkBox_Click);
            this.finalConfirmationView.FinalConfirmation_checkBox.Click += new System.EventHandler(this.FinalConfirmation_checkBox_Click);


        }





        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string foldPath = "";
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_button_Click(object sender, EventArgs e)
        {
            if (CheckRes_checkBox.Checked)
            {
                //if (satelliteStarStatusView.sat != null)
                //{
                //    //选择保存地址，文件名称为当前时间.txt
                //    FolderBrowserDialog dialog = new FolderBrowserDialog();
                //    dialog.Description = "请选择文件路径";
                //    if (dialog.ShowDialog() == DialogResult.OK)
                //    {
                //        foldPath = dialog.SelectedPath;
                //    }
                    
                //    FileStream fs = new
                //                      FileStream(foldPath + "\\star.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                //    DateTime dt1 = DateTime.Now;
                //    sw.Write(Convert.ToString(dt1));
                //    sw.Write("卫星数量  " + satelliteStarStatusView.sat.stacounts+"：");

                //    for (int i = 0; i < satelliteStarStatusView.sat.stacounts; i++)
                //    { 
                //        JYLink.Satlate_status status = satelliteStarStatusView.sat.satlist[i];
                //        sw.Write("    卫星号  " + status.PRN);
                //        sw.Write("    GLONASS号  " + status.Glofreq);
                //        sw.Write("    信噪比  " + status.SNR);
                //        sw.Write("    高度（度）  " + status.Elev);
                //        sw.Write("    方位（度）  " + status.Az);
                //    }

                //    sw.WriteLine();
                //    //  sw.WriteLine("操作人：yun");
                //    //  sw.WriteLine("日期：" + Convert.ToString(dt1));
                //    sw.Flush();
                //    sw.Close();
                //}
            }
        }




        /// <summary>
        /// 线路检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineConneect_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = true;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;

        }

        private void LineConnect_checkBox_Click(object sender, EventArgs e)
        {

            if (lineConnectView.LineConnect_checkBox.Checked)
            {
                LineConneect_button.ForeColor = Color.LightGreen;
            }
            else
            {
                LineConneect_button.ForeColor = Color.Black;
            }
        }


        /// <summary>
        /// 控制面手动检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manual_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = true;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void Manual_checkBox_Click(object sender, EventArgs e)
        {

            if (manualCheckView.Manual_checkBox.Checked)
            {
                Manual_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Manual_button.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 控制面自动检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stabilize_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = true;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void Stabilize_checkBox_Click(object sender, EventArgs e)
        {

            if (stabilizeCheckView.Stabilize_checkBox.Checked)
            {
                Stabilize_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Stabilize_button.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 姿态检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Attitude_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = true;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void Attitude_checkBox_Click(object sender, EventArgs e)
        {

            if (attitudeCheckView.Attitude_checkBox.Checked)
            {
                Attitude_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Attitude_button.ForeColor = Color.Black;
            }
        }

        private void Magnetic_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = true;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void Magnetic_checkBox_Click(object sender, EventArgs e)
        {

            if (magneticView.Magnetic_checkBox.Checked)
            {
                Magnetic_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Magnetic_button.ForeColor = Color.Black;
            }
        }

        private void Mergency_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = true;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void Mergency_checkBox_Click(object sender, EventArgs e)
        {

            if (mergencyView.Mergency_checkBox.Checked)
            {
                Mergency_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Mergency_button.ForeColor = Color.Black;
            }
        }

        private void YnamicPressurev_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = true;
            passesView.Visible = false;
            finalConfirmationView.Visible = false;
        }

        private void YnamicPressurev_checkBox_Click(object sender, EventArgs e)
        {

            if (ynamicPressurevView.YnamicPressurev_checkBox.Checked)
            {
                YnamicPressurev_button.ForeColor = Color.LightGreen;
            }
            else
            {
                YnamicPressurev_button.ForeColor = Color.Black;
            }
        }

        private void Passes_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = true;
            finalConfirmationView.Visible = false;
        }

        private void Passes_checkBox_Click(object sender, EventArgs e)
        {

            if (passesView.Passes_checkBox.Checked)
            {
                Passes_button.ForeColor = Color.LightGreen;
            }
            else
            {
                Passes_button.ForeColor = Color.Black;
            }
        }

        private void FinalConfirmation_button_Click(object sender, EventArgs e)
        {
            lineConnectView.Visible = false;
            manualCheckView.Visible = false;
            stabilizeCheckView.Visible = false;
            attitudeCheckView.Visible = false;
            magneticView.Visible = false;
            mergencyView.Visible = false;
            ynamicPressurevView.Visible = false;
            passesView.Visible = false;
            finalConfirmationView.Visible = true;
        }

        private void FinalConfirmation_checkBox_Click(object sender, EventArgs e)
        {

            if (finalConfirmationView.FinalConfirmation_checkBox.Checked)
            {
                FinalConfirmation_button.ForeColor = Color.LightGreen;
            }
            else
            {
                FinalConfirmation_button.ForeColor = Color.Black;
            }
        }


    }
}