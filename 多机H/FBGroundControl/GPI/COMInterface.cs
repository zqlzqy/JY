using MissionPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBGroundControl.GPI
{
    public class COMInterface
    { 
        private volatile static COMInterface _instance = null;
        private static readonly object lockHelper = new object();
        private static JYLinkInterface _comPort = new JYLinkInterface();
        private Form _baseForm;
        private COMInterface() { 
        }
          
        public static COMInterface GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new COMInterface();
                }
            }
            return _instance;
        }

        public static  JYLinkInterface comPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if (_comPort == value)
                    return;
                _comPort = value;
                
            }
        }
         
    }

}
