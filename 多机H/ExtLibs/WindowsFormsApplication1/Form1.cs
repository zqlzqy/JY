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
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode node = null;
        XmlNode root = null;
        public Form1()
        {
            InitializeComponent();

            System.Data.DataSet ds = new System.Data.DataSet();
            MessageBox.Show(Application.StartupPath);
            if (!File.Exists(Application.StartupPath + "\\viewSet.xml"))
            //若文件夹不存在则新建文件
            {
                ds.WriteXml(Application.StartupPath + "\\viewSet.xml");
            }
            MessageBox.Show("1");

            //创建类型声明节点  
            node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点  
            root = xmlDoc.CreateElement("Log");
            xmlDoc.AppendChild(root);
            try
            {
                xmlDoc.Save(Application.StartupPath + "\\log.xml");
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
            MessageBox.Show("end");
        }
    }
}
