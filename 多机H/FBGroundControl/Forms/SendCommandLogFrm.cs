using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FBGroundControl.Forms
{
    /// <summary>
    /// 日志列表(命令发送日志记录)
    /// </summary>
    public partial class SendCommandLogFrm : Form
    {
        string strPath = Application.StartupPath + "\\log.xml";

        List<string> listLog = new List<string>();
        public SendCommandLogFrm()
        {
            InitializeComponent();
            
            log_listView.View = View.Details;
            //XML
            //加载xml文件
            XmlDocument doc = new XmlDocument();
            doc.Load(strPath);  //加载Xml文件 
            //XmlElement rootElem = doc.DocumentElement;  //获取根节点
           // XmlNodeList ColumnpersonNodes = rootElem.GetElementsByTagName("Log"); //获取列节点数组
            XmlNode xn = doc.SelectSingleNode("Log");
            if (xn.ChildNodes.Count > 0)
            {
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode node in xnl)
                {
                    ListViewItem lvi = new ListViewItem();//开辟行数据空间
                    XmlNodeList subNodes = ((XmlElement)node).GetElementsByTagName("index");
                    XmlElement xe = (XmlElement)node;
                    lvi.SubItems[0].Text = xe.InnerText;//将第一个值给行头

                    int Count = subNodes.Count;
                    for (int i = 1; i < Count; i++)//遍历第一个值之外的值
                    {
                        //将行数据写入到ListView中
                        string str = subNodes[i].InnerText;
                        lvi.SubItems.Add(str);
                    }
                    log_listView.Items.Add(lvi);
                }
            }
           
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendCommandLogFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
