using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing.Drawing2D;
using System.Threading;



namespace FBGroundControl.Forms
{
    public partial class MapFrm : DockContent
    {
        DateTime updatescreen = DateTime.Now;
        #region 内部变量
        Thread show; 
        private Graphics _g = null;
        private Image _imageCache = null;
        public float ship_angel { get; set; }
        //public List<Point>[] plane = new List<Point>[6];
        public List<string> hangdian_cmd = new List<string>();
        public Point[] p_route = new Point[10];
        public Point[] p_goujing = new Point[2];
        public static List<Point> p_hangdian = new List<Point>();//航点信息
        public List<Point> p_hangdian_way = new List<Point>();
        public List<Point> p_hangdian_land = new List<Point>();
        public List<Point> p_line = new List<Point>(); //测距
        public Point[] p_kongyu_init = new Point[8];
        public Point[] p_kongyu = new Point[9];
        public int diff_x = 0;
        public int diff_y = 0;
        public int xx, yy;//偏移量
        public Dictionary<int, List<Point>> routelist = new Dictionary<int, List<Point>>();
        public Dictionary<int, float> plane_angel = new Dictionary<int, float>();
        /// <summary>
        /// 单元格的宽(100%)
        /// </summary>
        private int _cellWidth_px = 100;
        /// <summary>
        /// 单元格的高(100%)
        /// </summary>
        private int _cellHeight_px = 100;

        private float _zoomOld = 1.0f;
        public float _zoom = 1.0f;//缩放系数
        private float _zoomMin = 0.5f;
        private float _zoomMax = 10f;

        private float offx = 0.0f;
        private float offy = 0.0f;
        private PointF _gridLeftTop = new PointF(200, 200);

        private bool _leftButtonPress = false;

        private PointF _mousePosition = new PointF(0, 0);

        Pen pen = Pens.Black;
        //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        Pen pencircle = new Pen(Color.Gray, 1);

        Pen pen_hangxian;// = new Pen(Color.Blue, 2);
        Pen pen_hangxian_land = new Pen(Color.Red, 2); //
        Pen pen_guiji = new Pen(Color.Orange, 2); //
        Pen pen_gj = Pens.Red;
        Pen pen_ceju = new Pen(Color.Yellow, 2); //测距颜色
        Pen pen_kognyu = new Pen(Color.DarkGreen, 2); //测距颜色 
        Font font = new Font("宋体", 8f, FontStyle.Regular);
        Brush brush = new SolidBrush(Color.Black);
        Brush brush2 = new SolidBrush(Color.Black);
        Brush brush_plane = new SolidBrush(Color.Yellow);
        Font font2 = new Font("宋体", 12f, FontStyle.Bold);
        Font font_plane = new Font("宋体", 15f, FontStyle.Bold);
        Image im_ship;
        Image image_make, plane_image, image_ceju;

        Bitmap bm_plane;//得到图片框中的图片
        Bitmap bm_ship;//得到图片框中的图片
        #endregion

        //lbl_distance
        public ToolStripMenuItem rang_ToolStripMenuItemReview
        {
            get { return rang_ToolStripMenuItem; }
        }
        //public ToolStripMenuItem startRangeToolStripMenuItemShow
        //{
        //    get { return startRangeToolStripMenuItem; }
        //}

        //public ToolStripMenuItem stopRangeToolStripMenuItemShow
        //{
        //    get { return stopRangeToolStripMenuItem; }
        //}
        //将map中的右键--拾取坐标点事件转到主界面实现

        public ToolStripMenuItem goujing_ToolStripMenuItemReview
        {
            get { return 勾径规划ToolStripMenuItem; }
        }



        //public Button ChangeHeading_ItemReview
        //{
        //    get { return ChangeHeading; }
        //}


        //将map中的右键--飞行至此点事件转到主界面实现
        public ToolStripMenuItem flyToPoint_ToolStripMenuItemReview
        {
            get { return flyToPoint_ToolStripMenuItem; }
        }
        //将map中的右键--选择飞机事件转到主界面实现

        //将map中的右键--居中--飞机居中事件转到主界面实现

        //将map中的右键--居中--航线居中事件转到主界面实现

        //将map中的右键--显示--航向 事件转到主界面实现

        //将map中的右键--显示--轨迹 事件转到主界面实现


        //将map中的右键--显示--飞机编号 事件转到主界面实现
        public ToolStripMenuItem clearTracks_ToolStripMenuItemReview
        {
            get { return clearTracks_ToolStripMenuItem; }
        }
        //将map中的右键--模式--数据模式 实践转到主界面实现
        public ToolStripMenuItem datamode_ToolStripMenuItemReview
        {
            get { return datamode_ToolStripMenuItem; }
        }
        //将map中的右键--模式--规划模式 实践转到主界面实现
        public ToolStripMenuItem planmode_ToolStripMenuItemReview
        {
            get { return planmode_ToolStripMenuItem; }
        }


        private List<List<Locationwp>> history = new List<List<Locationwp>>();

        public MapFrm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
           // show = new Thread(paint_show);
           // show.IsBackground = true;
           // show.Start();
            this.MouseWheel += Form1_MouseWheel;
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            var delta = e.Delta;
            if (Math.Abs(delta) < 10)
            {
                return;
            }
            var mousePosition = new PointF();
            mousePosition.X = e.X;
            mousePosition.Y = e.Y;
            _zoomOld = _zoom;

            if (delta < 0)
            {
                _zoom -= FetchStep(delta);
            }
            else if (delta > 0)
            {
                _zoom += FetchStep(delta);
            }
            if (_zoom < _zoomMin)
            {
                _zoom = _zoomMin;
            }
            else if (_zoom > _zoomMax)
            {
                _zoom = _zoomMax;
            }

            var zoomNew = _zoom;
            var zoomOld = _zoomOld;
            var deltaZoomNewToOld = zoomNew / zoomOld;


            var zero = _gridLeftTop;
            zero.X = mousePosition.X - (mousePosition.X - zero.X) * deltaZoomNewToOld;
            zero.Y = mousePosition.Y - (mousePosition.Y - zero.Y) * deltaZoomNewToOld;
            _gridLeftTop = zero;
            trackBar1.Value = (int)(_zoom * 10);
            this.Refresh();
        }
        private float FetchStep(float delta)
        {
            if (_zoom == 1)
            {
                return delta > 0 ? 1 : 0.1f;
            }
            else
            {
                return _zoom >= 1 ? 1 : 0.1f;
            }
        }

        private void DrawGrid(Graphics g)
        {
            float cellWidth = _zoom * _cellWidth_px;
            float cellHeight = _zoom * _cellHeight_px;
            string s1, s2;
            //单元格的宽和高最小为1像素
            cellWidth = cellWidth < 1 ? 1 : cellWidth;
            cellHeight = cellHeight < 1 ? 1 : cellHeight;
            var p1 = new PointF(this.Width / 2, -yy);
            var p2 = new PointF(this.Width / 2, this.Height - yy);
            var p3 = new PointF(0 - xx, this.Height / 2);
            var p4 = new PointF(this.Width - xx, this.Height / 2);
            Point pl1 = new Point(0, 0);
            Point pl2 = new Point(0, 0);
            for (int i = 0; i < p_line.Count; i++)
            {
                pl1.X = (int)(p_line[i].X * _zoom) + this.Width / 2 - 4;
                pl1.Y = -(int)(p_line[i].Y * _zoom) + this.Height / 2 - 4;
                g.DrawImage(image_ceju, pl1);
            }
            if (p_line.Count == 2)
            {
                pl1.X = (int)(p_line[0].X * _zoom) + this.Width / 2;
                pl1.Y = -(int)(p_line[0].Y * _zoom) + this.Height / 2;
                pl2.X = (int)(p_line[1].X * _zoom) + this.Width / 2;
                pl2.Y = -(int)(p_line[1].Y * _zoom) + this.Height / 2;
                g.DrawLine(pen_ceju, pl1, pl2);
            }
            //绘制圆圈
            for (int i = 0; i < 30; i++)
            {
                g.DrawPie(pencircle, this.Width / 2 - (i + 1) * 50 * _zoom, this.Height / 2 - (i + 1) * 50 * _zoom, (i + 1) * 100 * _zoom, (i + 1) * 100 * _zoom, 0, 360);
                if (i % 2 == 1)
                {
                    s1 = (5 * (i + 1)).ToString() + "km";
                    s2 = "-" + (5 * (i + 1)).ToString() + "km";
                    g.DrawString(s2, font, brush, this.Width / 2 - (i + 1) * 50 * _zoom, this.Height / 2);
                    g.DrawString(s1, font, brush, this.Width / 2 + (i + 1) * 50 * _zoom, this.Height / 2);
                }
            }
            //绘制坐标系
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
            Point[] p_gj = new Point[2];
            if (p_goujing[0] != p_goujing[1])
            {
                p_gj[0].X = this.Width / 2 + (int)(p_goujing[0].X * _zoom);
                p_gj[0].Y = this.Height / 2 - (int)(p_goujing[0].Y * _zoom);
                p_gj[1].X = this.Width / 2 + (int)(p_goujing[1].X * _zoom);
                p_gj[1].Y = this.Height / 2 - (int)(p_goujing[1].Y * _zoom);
                g.DrawLines(pen_gj, p_gj);
            }
            try
            {
                im_ship = Rotate(bm_ship, ship_angel);
                Point pppp = new Point(this.Width / 2 - im_ship.Width / 2, this.Height / 2 - im_ship.Height / 2);
                g.DrawImage(im_ship, pppp);
                int k = 0, pen_k = 1;
                Point p_m = new Point();
                Point p_b = new Point();
                Point[] pp = new Point[p_hangdian.Count];
                p_hangdian_way.Clear();
                p_hangdian_land.Clear();

                for (int i = 0; i < p_hangdian.Count; i++)
                {
                    pp[i].X = (int)(p_hangdian[i].X * _zoom) + this.Width / 2;
                    pp[i].Y = -(int)(p_hangdian[i].Y * _zoom) + this.Height / 2;
                    k++;
                    p_m.X = (int)(p_hangdian[i].X * _zoom) + this.Width / 2 - image_make.Width / 2;
                    p_m.Y = -(int)(p_hangdian[i].Y * _zoom) + this.Height / 2 - image_make.Height / 2;
                    p_b.X = (int)(p_hangdian[i].X * _zoom) + this.Width / 2 - 7;
                    p_b.Y = -(int)(p_hangdian[i].Y * _zoom) + this.Height / 2 - image_make.Height + 15;

                    if (i > 0 && hangdian_cmd.Count > 1)
                    {
                        //if (hangdian_cmd[i - 1] == hangdian_cmd[i])
                        //{
                        pen_hangxian = new Pen(getPenColor(pen_k), 2);
                        if (!(hangdian_cmd[i - 1] == "LAND" && hangdian_cmd[i] == "WAYPOINT"))
                        {
                            g.DrawLine(pen_hangxian, pp[i - 1], pp[i]);
                        }
                        //if (hangdian_cmd[i] == "LAND" )
                        //{
                        //    g.DrawLine(pen_hangxian_land, pp[i - 1], pp[i]);
                        //}
                        // }
                        if ((hangdian_cmd[i - 1] == "LAND") && (hangdian_cmd[i] == "WAYPOINT"))
                        {
                            pen_k++;
                            k = 1;
                        }

                    }
                    g.DrawImage(image_make, p_m);
                    g.DrawString(k.ToString(), font2, brush2, p_b);//航点号

                }
                for (int i = 0; i < 8; i++)
                {
                    p_kongyu[i].X = (int)(p_kongyu_init[i].X * _zoom) + this.Width / 2;
                    p_kongyu[i].Y = -(int)(p_kongyu_init[i].Y * _zoom) + this.Height / 2;
                    p_kongyu[8] = p_kongyu[0];
                }
                Point[] pp1 = new Point[p_hangdian_way.Count];
                Point[] pp2 = new Point[p_hangdian_land.Count];
                pp1 = p_hangdian_way.ToArray();
                pp2 = p_hangdian_land.ToArray();
                if (MainForm.instance.isrun)
                {
                    g.DrawLines(pen_kognyu, p_kongyu);
                }
                foreach (var item in routelist)
                {
                    if (item.Value.Count > 0)
                    {
                        Point[] p_track = new Point[item.Value.Count];
                        for (int i = 0; i < item.Value.Count; i++)
                        {
                            p_track[i].X = (int)(item.Value[i].X * _zoom) + this.Width / 2;
                            p_track[i].Y = -(int)(item.Value[i].Y * _zoom) + this.Height / 2;
                        }
                        pen_guiji.Color = getColor(item.Key);
                        g.DrawLines(pen_guiji, p_track);
                        g.DrawLine(pen_hangxian_land, p_track[item.Value.Count - 1], new Point(p_track[item.Value.Count - 1].X + (int)(300 * Math.Sin((360 - plane_angel[item.Key]) / 180 * 3.14)), p_track[item.Value.Count - 1].Y - (int)(300 * Math.Cos((360 - plane_angel[item.Key]) / 180 * 3.14))));
                        plane_image = Rotate(bm_plane, plane_angel[item.Key], item.Key.ToString());
                        g.DrawImage(plane_image, new Point((p_track[item.Value.Count - 1].X) - plane_image.Width / 2, (p_track[item.Value.Count - 1].Y) - plane_image.Height / 2));
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private Color getPenColor(int num)
        {
            switch (num)
            {
                case 1: return Color.YellowGreen;
                case 2: return Color.Gold;
                case 3: return Color.Red;
                case 4: return Color.DeepPink;
                case 5: return Color.Orange;
                case 6: return Color.DarkOrange;
                case 7: return Color.PaleGreen;
                case 8: return Color.LightGray;
                case 9: return Color.LightPink;
                case 10: return Color.Aqua;
                case 11: return Color.CadetBlue;
                case 12: return Color.Blue;
                case 13: return Color.DeepPink;
                case 14: return Color.Khaki;
                case 15: return Color.SpringGreen;
                default: return Color.Yellow;

            }
        }
        public Color getColor(int num)
        {
            switch (num)
            {
                case 1: return Color.SpringGreen;
                case 2: return Color.Black;
                case 3: return Color.YellowGreen;
                case 4: return Color.Blue;
                case 5: return Color.Orange;
                case 6: return Color.SeaGreen;
                case 7: return Color.PaleGreen;
                case 8: return Color.LightGray;
                case 9: return Color.LightPink;
                case 10: return Color.Aqua;
                case 11: return Color.CadetBlue;
                case 12: return Color.DarkOrange;
                case 13: return Color.DeepPink;
                case 14: return Color.Khaki;
                default: return Color.Yellow;

            }
        }
        public Point point_chang(Point p)
        {
            p.X = this.Width / 2 + (int)(p.X * _zoom);
            p.Y = this.Height / 2 + (int)(p.Y * _zoom);
            return p;
        }
        private void insertWP4RangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void rang_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void planmode_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MapFrm_Load(object sender, EventArgs e)
        {
            pencircle.DashStyle = DashStyle.DashDot;
            pen_kognyu.DashStyle = DashStyle.Dot;
            im_ship = global::FBGroundControl.Properties.Resources.quadicon5;//ship
            image_make = global::FBGroundControl.Properties.Resources.quadicon4;//make
            plane_image = global::FBGroundControl.Properties.Resources.planeicon;//plane
            image_ceju = global::FBGroundControl.Properties.Resources.marker_01;
            bm_ship = new Bitmap(im_ship);//得到图片框中的图片
            bm_plane = new Bitmap(plane_image);
            ship_angel = 0;
            //plane_angel = 0;
            trackBar1.Value = (int)(_zoom * 10);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

        }

        private void MapFrm_Paint(object sender, PaintEventArgs e)
        {


        }

        private void MapFrm_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void MapFrm_MouseUp(object sender, MouseEventArgs e)
        {
            _leftButtonPress = false;
            this.Cursor = Cursors.Default;
        }

        private void MapFrm_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    _mousePosition.X = e.X;
            //    _mousePosition.Y = e.Y;

            //    _leftButtonPress = true;
            //    this.Cursor = Cursors.Hand;
            //}
        }

        private void MapFrm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (_imageCache != null && this.Width != 0 && this.Height != 0)
                {
                    _imageCache = new Bitmap(this.Width, this.Height);
                    if (_g != null)
                    {
                        _g = Graphics.FromImage(_imageCache);
                        _g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    }
                }


                //pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Width / 2);
                this.Refresh();
            }
            catch (Exception)
            {


            }

        }

        private void MapFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_imageCache = null;
            _g = null;
            this.Dispose();
        }
        /// <summary>
        /// 旋转变化
        /// </summary>
        /// <param name="b"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Bitmap Rotate(Bitmap b, float angle, string s)
        {
            angle = angle % 360;

            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);

            g.InterpolationMode = InterpolationMode.Bilinear;

            g.SmoothingMode = SmoothingMode.HighQuality;

            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            Rectangle rect2 = new Rectangle(Offset.X + 6, Offset.Y + 3, w, h);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            g.DrawString(s, font_plane, brush_plane, rect2);
            //重至绘图的所有变换
            g.ResetTransform();

            g.Save();
            g.Dispose();
            return dsImage;
        }
        public Bitmap Rotate(Bitmap b, float angle)
        {
            angle = angle % 360;

            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);

            g.InterpolationMode = InterpolationMode.Bilinear;

            g.SmoothingMode = SmoothingMode.HighQuality;

            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);

            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();

            g.Save();
            g.Dispose();
            return dsImage;
        }

        /// <summary>
        /// 画轨迹函数
        /// </summary>
        /// <param name="p"></param>
        public void tests(Point[] p)
        {
            p = p_route;
            Pen pen = new Pen(Brushes.Black, 2);
            _g.DrawLines(pen, p);
        }

        /// <summary>
        /// 更新轨迹信息
        /// </summary>
        /// <param name="p"></param>
        public void TRefresh(List<Point> p)
        {
            p_hangdian = p;
            this.Refresh();
        }
        public void TRefresh()
        {
            this.Refresh();
        }


        private void MapFrm_Paint_1(object sender, PaintEventArgs e)
        {
            try
            {

                if (this.Width != 0 && this.Height != 0)
                {

                    _imageCache = new Bitmap(this.Width, this.Height);
                    _g = Graphics.FromImage(_imageCache);
                    _g.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
                    _g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量
                    _g.CompositingQuality = CompositingQuality.HighQuality;//再加一点
                    _g.Clear(this.BackColor);
                    xx += diff_x;
                    yy += diff_y;
                    _g.TranslateTransform(xx, yy);
                    //重至绘图的所有变换                   
                    DrawGrid(_g);
                    diff_x = diff_y = 0;
                    e.Graphics.DrawImage(_imageCache, new Point(0, 0));
                    _g.ResetTransform();
                    _imageCache.Dispose();
                    _g.Dispose();
                    e.Dispose();
                    updatescreen = DateTime.Now;
                    Thread.Sleep(1);
                    Application.DoEvents();

                }    

            }
            catch (Exception)
            {

            }
     
        }
        /// <summary>
        /// goujing
        /// </summary>
        /// <param name="p"></param>
        public void Draw_goujing()
        {
            Pen pen = new Pen(Brushes.Black, 2);
            _g.DrawLines(pen, p_goujing);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _zoom = Convert.ToSingle(trackBar1.Value / 10.0);
            this.Refresh();
        }

        private void ChangeHeading_Click(object sender, EventArgs e)
        {

        }

        private void planmode_ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {


        }

        private void pickPoint_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MapFrm_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

        private void config_change_Click(object sender, EventArgs e)
        {

        }

        private void config_change_Click_1(object sender, EventArgs e)
        {

        }

        private void 地图复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diff_x = diff_y = xx = yy = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }



        //public void paint_show()
        //{

        //    if (this.Width != 0 && this.Height != 0)
        //    {

        //        _imageCache = new Bitmap(this.Width, this.Height);
        //        _g = Graphics.FromImage(_imageCache);
        //        _g.SmoothingMode = SmoothingMode.HighQuality;  //图片柔顺模式选择
        //        _g.InterpolationMode = InterpolationMode.HighQualityBicubic;//高质量
        //        _g.CompositingQuality = CompositingQuality.HighQuality;//再加一点
        //        _g.Clear(this.BackColor);
        //        xx += diff_x;
        //        yy += diff_y;
        //        _g.TranslateTransform(xx, yy);
        //        //重至绘图的所有变换                   
        //        DrawGrid(_g);
        //        diff_x = diff_y = 0;
        //        this.CreateGraphics().DrawImage(_imageCache, new Point(0, 0));
        //        _g.ResetTransform();
        //        _imageCache.Dispose();
        //        _g.Dispose();
        //        this.CreateGraphics().Dispose();
        //        updatescreen = DateTime.Now;
        //        Thread.Sleep(1);
        //        Application.DoEvents();

        //    }   
        
        //}
    }
}
