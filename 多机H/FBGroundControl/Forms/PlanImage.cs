using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class PlanImage : UserControl
    {
        public PictureBox up_pictureBoxShow {
            get { return this.up_pictureBox; }
        }
        public PictureBox right_pictureBoxShow
        {
            get { return this.right_pictureBox; }
        }
        public PictureBox left_pictureBoxShow
        {
            get { return this.left_pictureBox; }
        }
        public PictureBox front_pictureBoxShow
        {
            get { return this.front_pictureBox; }
        }
        public PictureBox down_pictureBoxShow
        {
            get { return this.down_pictureBox; }
        }
        public PictureBox back_pictureBoxShow
        {
            get { return this.back_pictureBox; }
        }
        public PlanImage()
        {
            InitializeComponent();
        }
    }
}
