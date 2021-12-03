using MissionPlanner.Arduino;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    public partial class FirmwareWrite : Form
    {
        string fileNameDir = "";
        string fileName = "";
        private readonly Firmware fw = new Firmware();
        public FirmwareWrite()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void choose_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();//新建打开文件对话框
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//设置初始文件目录
           // ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";//设置打开文件类型
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                fileNameDir = ofd.FileName;//FileName就是要打开的文件路径
                //下边可以添加代码
                this.location_textBox.Text = fileNameDir;
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // private void fw_Progress(int progress, string status)
        //{
        //    pdr.UpdateProgressAndStatus(progress, status);
        //}

        /// <summary>
        ///     for when updating fw to hardware
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="status"></param>
        private void fw_Progress1(int progress, string status)
        {
            var change = false;

            if (progress != -1)
            {
                if (this.progress.Value != progress)
                {
                    this.progress.Value = progress;
                    change = true;
                }
            }
            if (lbl_status.Text != status)
            {
                lbl_status.Text = status;
                change = true;
            }

            if (change)
                Refresh();
        }
        /// <summary>
        /// 写入固件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void write_button_Click(object sender, EventArgs e)
        {
            //using (var fd = new OpenFileDialog { Filter = "Firmware (*.hex;*.px4;*.vrx)|*.hex;*.px4;*.vrx" })
            //{
            //    if (Directory.Exists(fileNameDir))
            //        fd.InitialDirectory = fileNameDir;
            //    fd.ShowDialog();
            //    if (File.Exists(fd.FileName))
            //    {
            //        fileNameDir = Path.GetDirectoryName(fd.FileName);

                    //fw.Progress -= fw_Progress;
                    fw.Progress += fw_Progress1;

                    var boardtype = BoardDetect.boards.none;
                    try
                    {
                        if (fileName.ToLower().EndsWith(".px4"))//fd.FileName
                            boardtype = BoardDetect.boards.px4v2;
                        else
                            boardtype = BoardDetect.DetectBoard(MainForm.instance.serialValue);
                    }
                    catch
                    {
                        CustomMessageBox.Show(Strings.CanNotConnectToComPortAnd, Strings.ERROR);
                        return;
                    }

                   // fw.UploadFlash(MainForm.instance.serialValue, fd.FileName, boardtype);
            //    }
            //}

                    fw.UploadFlash(MainForm.instance.serialValue, fileName, boardtype);

        }
        /// <summary>
        /// 点击选择固件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void location_textBox_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();//新建打开文件对话框
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//设置初始文件目录
            //// ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";//设置打开文件类型
            //if (ofd.ShowDialog(this) == DialogResult.OK)
            //{
            //    fileName = ofd.FileName;//FileName就是要打开的文件路径
            //    //下边可以添加代码
            //    this.location_textBox.Text = fileName;
            //}

            using (var fd = new OpenFileDialog { Filter = "Firmware (*.hex;*.px4;*.vrx)|*.hex;*.px4;*.vrx" })
            {
                if (Directory.Exists(fileNameDir))
                    fd.InitialDirectory = fileNameDir;
                fd.ShowDialog();
                if (File.Exists(fd.FileName))
                {
                    fileNameDir = Path.GetDirectoryName(fd.FileName);
                    fileName = fd.FileName;
                    this.location_textBox.Text = fileName;

                    ////fw.Progress -= fw_Progress;
                    //fw.Progress += fw_Progress1;

                    //var boardtype = BoardDetect.boards.none;
                    //try
                    //{
                    //    if (fileName.ToLower().EndsWith(".px4"))//fd.FileName
                    //        boardtype = BoardDetect.boards.px4v2;
                    //    else
                    //        boardtype = BoardDetect.DetectBoard(MainForm.instance.serialValue);
                    //}
                    //catch
                    //{
                    //    CustomMessageBox.Show(Strings.CanNotConnectToComPortAnd, Strings.ERROR);
                    //    return;
                    //}

                    //fw.UploadFlash(MainForm.instance.serialValue, fileName, boardtype);
                }
            }


        }

    }
}
