using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class ConfigFrm : Form
    {

        public ConfigFrm()
        {
            InitializeComponent();

            attitudeLoopView.Dock = DockStyle.Fill;
            
            overloadLoopView.Dock = DockStyle.Fill;
            guidectrlView.Dock = DockStyle.Fill;
            takeoffView.Dock = DockStyle.Fill;
            guideView.Dock = DockStyle.Fill;
            loiterView.Dock = DockStyle.Fill;
            limitView.Dock = DockStyle.Fill;
            steertrimView.Dock = DockStyle.Fill;
            imutrimView.Dock = DockStyle.Fill;
            kongyuView.Dock = DockStyle.Fill;
            navsetView.Dock = DockStyle.Fill;
            microwaveView.Dock = DockStyle.Fill;
            
            groupBox2.Controls.Add(attitudeLoopView);
            groupBox2.Controls.Add(overloadLoopView);
            groupBox2.Controls.Add(guidectrlView);
            groupBox2.Controls.Add(takeoffView);
            groupBox2.Controls.Add(guideView);
            groupBox2.Controls.Add(loiterView);
            groupBox2.Controls.Add(limitView);
            groupBox2.Controls.Add(steertrimView);
            groupBox2.Controls.Add(imutrimView);
            groupBox2.Controls.Add(kongyuView);
            groupBox2.Controls.Add(navsetView);
            groupBox2.Controls.Add(microwaveView);
        }

        //public void ShowImageViewSetHandler(int count)
        //{
        //    if (count == 6)
        //    {
        //        this.configAccelerometerCalibration.front_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\accel_front1.png");
        //    }
        //    else
        //    {
        //        this.configAccelerometerCalibration.front_pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\accel_front" + (count + 1) + ".png");
        //    }
        //}

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void attitudeloop_button_Click(object sender, EventArgs e)
        {

            attitudeLoopView.Visible = true;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void overloadloop_button_Click(object sender, EventArgs e)
        {
            microwaveView.Visible = false;
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = true;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
        }

        private void guidectrl_button_Click(object sender, EventArgs e)
        {
            microwaveView.Visible = false;
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = true;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
        }

        private void takeoff_button_Click(object sender, EventArgs e)
        {
            microwaveView.Visible = false;
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = true;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
        }

        private void guide_button_Click(object sender, EventArgs e)
        {
            microwaveView.Visible = false;
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = true;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
        }

        private void loiter_button_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = true;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void limit_button_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = true;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void steertrim_button_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = true;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = true;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void navset_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = true;
            navsetView.Visible = false;
            microwaveView.Visible = false;
        }

        private void Microwaveset_Click(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = true;
            microwaveView.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            attitudeLoopView.Visible = false;
            overloadLoopView.Visible = false;
            guidectrlView.Visible = false;
            takeoffView.Visible = false;
            guideView.Visible = false;
            loiterView.Visible = false;
            limitView.Visible = false;
            steertrimView.Visible = false;
            imutrimView.Visible = false;
            kongyuView.Visible = false;
            navsetView.Visible = false;
            microwaveView.Visible = true;
        }



    }
}