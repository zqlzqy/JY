using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using log4net.Config;
using log4net;
using System.Text;
using System.IO;
namespace FBGroundControl
{
    static class Program
    {
        public static string IpPlc = string.Empty;//IP地址
        public static string Port = string.Empty;//端口
        public static string Header = string.Empty;//头长度
        public static string Data = string.Empty;//数据
        public static string CheckMode = string.Empty;//校验
        public static int CheckNum;//校验
        public static string EndByte;//结束符
        public static int EndByteSg;//有无结束符
        public static string Send;
        public static int count;

        public static byte[] imbuffer = new byte[300];
        public static byte[] ombuffer = new byte[300];
        public static string TempStr;
        public static byte[] TempByte = new byte[300];
        public static string Mac;
        public static string Licenses;
        public static bool IsReg = false;
        public static bool Runable = false;
        public static string OutDate = "2013-12-31";
        /// <summary>
        /////////////////////// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SolidShowFrm());

            //Application.EnableVisualStyles();//系统自带
            //Application.SetCompatibleTextRenderingDefault(false);//系统自带
            //Application.Run(new MainForm());//系统自带
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                //log4net.Config.XmlConfigurator.Configure();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                GMap.NET.GMaps.Instance.PrimaryCache = new MissionPlanner.Maps.MyImageCache();
                // add my custom map providers
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.WMSProvider.Instance);
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.Custom.Instance);
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.Earthbuilder.Instance);
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.Statkart_Topo2.Instance);
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.MapBox.Instance);
                GMap.NET.MapProviders.GMapProviders.List.Add(MissionPlanner.Maps.MapboxNoFly.Instance);
                if (Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "gdal"))
                    GMap.NET.MapProviders.GMapProviders.List.Add(GDAL.GDALProvider.Instance);



                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                Application.Run(new MainForm());

            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);

                sb.AppendLine("【异常方法】：" + ex.TargetSite);

            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
