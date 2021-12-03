using GMap.NET;
using GMap.NET.Internals;
using MissionPlanner;
using MissionPlanner.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 卫星星况测试
    /// </summary>
    public partial class SatelliteStarStatusView : UserControl
    {
        private Dictionary<int, int> listLocation = new Dictionary<int, int>();
       
        private Random rand = new Random();
        private bool b = false;
        private Point point = new Point();
        private List<Point> list = new List<Point>();

        private int py = 0;
        private int px = 0;
        int index = 0;
        public JYLink.jylink_satlate_status sat;
        public SatelliteStarStatusView()
        {
            InitializeComponent();
          
        }

       

        private void SatelliteStarStatusView_Load(object sender, EventArgs e)
        {
            // initImageLabel();
        }
        /// <summary>
        /// GPS定位显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gps_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (b == false) return;
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Green);
            int radius = 8;
            for (int i = 0; i < list.Count; i++)
            {
                Rectangle rect = new Rectangle(list[i], Size.Empty);
                rect.Inflate(radius, radius);
                g.FillEllipse(brush, rect);
            }
        }

     

        /// <summary>
        /// SNR 信噪比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snr_button_Click(object sender, EventArgs e)
        {
            //CreateTable();                 //绘制坐标XY轴
            //DrawTable();                   //静态绘制报表
            snr_pictureBox.Refresh();
        }
        private void test_button_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    JYLinkTeleCtrl port = MainForm.telecontrol_comPort;

            //    if (!port.BaseStream.IsOpen)
            //    {
            //        throw new Exception("Please Connect First!");
            //    }
            //    sat = port.searchSatStatus("a");
            //    if (sat != null)
            //    {
            //        int width = gps_pictureBox.Width;
            //        int height = gps_pictureBox.Height;
            //        int x = width / 2; //左边地球圆形的圆心位置X坐标 
            //        int y = height / 2; //左边地球圆形的圆心位置Y坐标
            //        int r = 30;

            //        for (int i = 0; i < sat.stacounts; i++)
            //        {
            //            //方向角 
            //            double azimuth = sat.satlist[i].Az;
            //            //高度角 
            //            double elevation = sat.satlist[i].Elev;
            //            //根据方向角和高度角计算出，卫星显示的位置 
            //            Point point = new Point();
            //            x += (int)((r * elevation * Math.Sin(Math.PI * azimuth / 180) / 90));
            //            y -= (int)((r * elevation * Math.Cos(Math.PI * azimuth / 180) / 90));
            //            point.X = x;
            //            point.Y = y;
            //            list.Add(point);
            //        }
            //        b = true;
            //        gps_pictureBox.Refresh();
            //        snr_pictureBox.Refresh();
            //    }
            //    //point就是你需要绘画卫星图的起始坐标
            //}
            //catch
            //{
            //    throw;
            //}
        }
        /// <summary>
        /// SNR柱状图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snr_pictureBox_Paint(object sender, PaintEventArgs e)
        {

            //定义变量
            Graphics graphic = e.Graphics;                                      //GDI+绘图图面
            SolidBrush Bfill = new SolidBrush(Color.Black);        //定义单色画刷用于填充图形   
            Pen Rpen = new Pen(Color.Red, 3);                      //创建红色画笔 

            //graphic = this.CreateGraphics();
            Rectangle rect = new Rectangle(20, 0, 380, 311); //绘制黑色背景
            graphic.FillRectangle(Bfill, rect);       



            //定义变量
            Brush Bbrush = Brushes.White;                         //创建蓝色画刷 文字
            Font myFont = new Font("黑体", 12);                  //创建字体
            Font tFont = new Font("宋体", 8);                    //创建字体 显示在直方图上的数量
            SolidBrush Wfill = new SolidBrush(Color.Yellow);      //定义单色画刷用于填充图形 



            //输出文字
           // graphic.DrawString("卫星", myFont, Bbrush, new RectangleF(15, 280, 40, 40));
            graphic.DrawString("SNR", myFont, Bbrush, new RectangleF(30, 30, 200, 40));

            if (sat != null)
            {
                for (int i = 1; i <= sat.stacounts; i++)
                {
                    graphic.DrawString(i.ToString(), myFont, Bbrush, 70 + (i - 1) * 26, 280);  //(470-150)/12约26

                }
                int yv = 0;
                for (int i = 0; i <= 4; i++)
                {
                    graphic.DrawString(yv.ToString(), myFont, Bbrush, 30, 218 - (i - 1) * 25 * 2);
                    yv = yv + 25;
                }
                //定义绘制柱状图坐标|宽|高
                int x, y, width, heigh;
                x = 70;                 //X坐标定值=160 Y轴的x坐标为150
                width = 13;              //width坐标=(470-150)/(12*2)=13
                for (int i = 0; i < sat.stacounts; i++)
                {
                    heigh = rand.Next(1, 100) * 2;             //X轴y坐标=300 heigh=200
                    //heigh = sat.satlist[i].SNR;
                    y = 180 + (100 - heigh); //Y坐标 y=300-200 

                    //填充图形
                    Rectangle rect1 = new Rectangle(x + i * 26, y, width, heigh);
                    graphic.FillRectangle(Wfill, rect1);

                    //显示数量
                    graphic.DrawString(heigh / 2 + "", tFont, Brushes.White, x + i * 26, y - 15);
                }
            }


        }

    }
}