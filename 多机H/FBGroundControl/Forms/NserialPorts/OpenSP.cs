using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.Forms.NserialPorts
{
    class OpenSP
    {
        public SerialPort SP = new SerialPort();

        public bool OpenPort(string portName, int baud)
        {
            try
            {
                SP.PortName = portName;
                SP.BaudRate = baud;

                SP.ReadTimeout = -1;
                try
                {
                    SP.Open();
                    return true;
                }
                catch
                {
                    MessageBox.Show("无法打开串口", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        public bool ClosePort()
        {
            try
            {
                SP.Close();
                return true;
            }
            catch { }
            return false;
        }
    }
}
