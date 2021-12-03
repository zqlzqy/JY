using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FBGroundControl.Forms.utils;

namespace FBGroundControl.Forms
{
    public partial class CommandHistory : Form
    {
        ListViewItem lviItem = new ListViewItem();
        
        public CommandHistory()
        {
            InitializeComponent( );

        }

        public void showCmd( string dataBuf )
        {
            this.Rool_textBox.Text = dataBuf;
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
