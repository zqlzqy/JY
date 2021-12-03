using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using log4net;
using MissionPlanner.Controls;
using FBGroundControl;
using System.Collections.Generic;

namespace FBGroundControl.Forms
{
    public partial class ConfigAccelerometerCalibration : UserControl, IActivate, IDeactivate
    {
        private const float DisabledOpacity = 0.2F;
        private const float EnabledOpacity = 1.0F;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public delegate void ShowImageViewSet(int count);//委托类型声明
        public static event ShowImageViewSet ShowImageViewSetHandler;//基于委托的事件对象
        public byte count;
      
        public ConfigAccelerometerCalibration()
        {
            InitializeComponent();
          
        }

        public void Activate()
        {
            BUT_calib_accell.Enabled = true;
        }

        public void Deactivate()
        {
            MainForm.comPort.giveComport = false;
        }

       
        private void BUT_calib_accell_Click(object sender, EventArgs e)
        {
            if (MainForm.comPort.giveComport)
            {
                count++;
                try
                {
                    //MainForm.comPort.sendPacket(new MAVLink.mavlink_command_ack_t {command = 1, result = count},
                    //MainForm.comPort.sysidcurrent, MainForm.comPort.compidcurrent);
                    if (ShowImageViewSetHandler != null)
                    {
                        ShowImageViewSetHandler(count);
                    }
                }
                catch
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                    return;
                }

                return;
            }

            try
            {
                count = 0;

                Log.Info("Sending accel command (mavlink 1.0)");
                MainForm.comPort.giveComport = true;

                MainForm.comPort.Write("\n\n\n\n\n\n\n\n\n\n\n");
                Thread.Sleep(200);

                //MainForm.comPort.doCommand(JYLink.JY_CMD.PREFLIGHT_CALIBRATION, 0, 0, 0, 0, 1, 0, 0);
                MainForm.comPort.giveComport = true;

                ThreadPool.QueueUserWorkItem(readmessage, this);

                BUT_calib_accell.Text = Strings.Click_when_Done;
            }
            catch (Exception ex)
            {
                MainForm.comPort.giveComport = false;
                Log.Error("Exception on level", ex);
                CustomMessageBox.Show("Failed to level", Strings.ERROR);
            }
        }

        private static void readmessage(object item)
        {
            var local = (ConfigAccelerometerCalibration) item;

            // clean up history
            MainForm.comPort.JY.cs.messages.Clear();

            while (
                !(MainForm.comPort.JY.cs.message.ToLower().Contains("calibration successful") ||
                  MainForm.comPort.JY.cs.message.ToLower().Contains("calibration failed")))
            {
                try
                {
                    Thread.Sleep(10);
                    // read the message
                    MainForm.comPort.readPacket();
                    // update cs with the message
                    MainForm.comPort.JY.cs.UpdateCurrentSettings(null);
                    // update user display
                    local.UpdateUserMessage();
                }
                catch
                {
                    break;
                }
            }

            MainForm.comPort.giveComport = false;

            try
            {
                local.Invoke((MethodInvoker) delegate
                {
                    local.BUT_calib_accell.Text = Strings.Done;
                    local.BUT_calib_accell.Enabled = false;
                });
            }
            catch
            {
            }
        }

        public void UpdateUserMessage()
        {
            Invoke((MethodInvoker) delegate
            {
                if (MainForm.comPort.JY.cs.message.ToLower().Contains("place vehicle") || MainForm.comPort.JY.cs.message.ToLower().Contains("calibration"))
                    lbl_Accel_user.Text = MainForm.comPort.JY.cs.message;
            });
        }

        private void BUT_level_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Info("Sending level command (mavlink 1.0)");
              //  MainForm.comPort.doCommand(JYLink.JY_CMD.PREFLIGHT_CALIBRATION, 0, 0, 0, 0, 2, 0, 0);

                BUT_level.Text = Strings.Completed;
            }
            catch (Exception ex)
            {
                Log.Error("Exception on level", ex);
                CustomMessageBox.Show("Failed to level", Strings.ERROR);
            }
        }
    }
}