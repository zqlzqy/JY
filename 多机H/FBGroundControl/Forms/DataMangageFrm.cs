using FBGroundControl.Forms.utils;
using MissionPlanner;
using MissionPlanner.Controls;
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
using System.IO;


namespace FBGroundControl.Forms
{
    public partial class DataManageFrm : DockContent
    {
        public DataManageFrm()
        {
            InitializeComponent();

        }

        private void check_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*  private void dataSavebutton_Click(object sender, EventArgs e)
          {
              string localFilePath = String.Empty;
              SaveFileDialog saveFileDialog1 = new SaveFileDialog();

              //设置文件类型  
              saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
              //设置文件名称：
              saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "F150参数文件.txt";

              //设置默认文件类型显示顺序  
              saveFileDialog1.FilterIndex = 2;

              //保存对话框是否记忆上次打开的目录  
              saveFileDialog1.RestoreDirectory = true;

              //点了保存按钮进入  
              if (saveFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  //获得文件路径  
                  localFilePath = saveFileDialog1.FileName.ToString();
                  //MessageBox.Show(localFilePath);
                  //弹窗显示文件路径

                
                

                  if (!File.Exists(localFilePath))
                  {
                      FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                      StreamWriter sr = new StreamWriter(fs);

                      sr.WriteLine("AttitudeLoopView");
                      sr.WriteLine(Properties.Settings.Default.roll_kp);
                      sr.WriteLine(Properties.Settings.Default.roll_ki);
                      sr.WriteLine(Properties.Settings.Default.roll_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind1);
                      sr.WriteLine(Properties.Settings.Default.pitch_kp);
                      sr.WriteLine(Properties.Settings.Default.pitch_ki);
                      sr.WriteLine(Properties.Settings.Default.pitch_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind2);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_kp);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_ki);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind3);
                      attitudelabel.ForeColor = System.Drawing.Color.Black;
                      attitudelabel.Text = "导出成功";

                      sr.WriteLine("OverLoadLoopView");
                      sr.WriteLine(Properties.Settings.Default.head_kp);
                      sr.WriteLine(Properties.Settings.Default.head_ki);
                      sr.WriteLine(Properties.Settings.Default.head_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind1);
                      sr.WriteLine(Properties.Settings.Default.side_kp);
                      sr.WriteLine(Properties.Settings.Default.side_ki);
                      sr.WriteLine(Properties.Settings.Default.side_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind2);
                      sr.WriteLine(Properties.Settings.Default.up_kp);
                      sr.WriteLine(Properties.Settings.Default.up_ki);
                      sr.WriteLine(Properties.Settings.Default.up_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind3);
                      overloadlabel.ForeColor = System.Drawing.Color.Black;
                      overloadlabel.Text = "导出成功";

                      sr.WriteLine("GuideCtrlView");
                      sr.WriteLine(Properties.Settings.Default.khead);
                      sr.WriteLine(Properties.Settings.Default.kxt);
                      sr.WriteLine(Properties.Settings.Default.kc);
                      sr.WriteLine(Properties.Settings.Default.kr);
                      sr.WriteLine(Properties.Settings.Default.l1guide_dr);
                      sr.WriteLine(Properties.Settings.Default.l1guide_p);
                      sr.WriteLine(Properties.Settings.Default.l1guide_kig);
                      sr.WriteLine(Properties.Settings.Default.throttle_t);
                      sr.WriteLine(Properties.Settings.Default.throttle_d);
                      sr.WriteLine(Properties.Settings.Default.throttle_i);
                      sr.WriteLine(Properties.Settings.Default.throttle_turn);
                      sr.WriteLine(Properties.Settings.Default.pitch_kw);
                      sr.WriteLine(Properties.Settings.Default.pitch_i);
                      sr.WriteLine(Properties.Settings.Default.pitch_t);
                      sr.WriteLine(Properties.Settings.Default.pitch_d);
                      sr.WriteLine(Properties.Settings.Default.kspd);
                      sr.WriteLine(Properties.Settings.Default.kspdi);
                      sr.WriteLine(Properties.Settings.Default.kspdd);
                      sr.WriteLine(Properties.Settings.Default.kh);
                      sr.WriteLine(Properties.Settings.Default.khi);
                      sr.WriteLine(Properties.Settings.Default.khd);
                      sr.WriteLine(Properties.Settings.Default.kpd);
                      sr.WriteLine(Properties.Settings.Default.kid);
                      sr.WriteLine(Properties.Settings.Default.kdd);
                      guideCtrllabel.ForeColor = System.Drawing.Color.Black;
                      guideCtrllabel.Text = "导出成功";

                      sr.WriteLine("TakeOffView");
                      sr.WriteLine(Properties.Settings.Default.takeoff_offset);
                      sr.WriteLine(Properties.Settings.Default.lift_pull);
                      sr.WriteLine(Properties.Settings.Default.pull_time);
                      sr.WriteLine(Properties.Settings.Default.pull_alt);
                      sr.WriteLine(Properties.Settings.Default.vspeed);
                      sr.WriteLine(Properties.Settings.Default.takeoff_type);
                      takeofflabel.ForeColor = System.Drawing.Color.Black;
                      takeofflabel.Text = "导出成功";

                      sr.WriteLine("GuideView");
                      sr.WriteLine(Properties.Settings.Default.alt);
                      sr.WriteLine(Properties.Settings.Default.speed);
                      sr.WriteLine(Properties.Settings.Default.heading);
                      guidelabel.ForeColor = System.Drawing.Color.Black;
                      guidelabel.Text = "导出成功";

                      sr.WriteLine("LoiterView");
                      sr.WriteLine(Properties.Settings.Default.loiter_radius);
                      sr.WriteLine(Properties.Settings.Default.op_lng);
                      sr.WriteLine(Properties.Settings.Default.op_lat);
                      sr.WriteLine(Properties.Settings.Default.loiter_dir);
                      loiterlabel.ForeColor = System.Drawing.Color.Black;
                      loiterlabel.Text = "导出成功";

                      sr.WriteLine("LimitView");
                      sr.WriteLine(Properties.Settings.Default.aileron);
                      sr.WriteLine(Properties.Settings.Default.elevator);
                      sr.WriteLine(Properties.Settings.Default.rudder);
                      sr.WriteLine(Properties.Settings.Default.frontwheel);
                      sr.WriteLine(Properties.Settings.Default.max_throttle);
                      sr.WriteLine(Properties.Settings.Default.min_throttle);
                      sr.WriteLine(Properties.Settings.Default.max_pitch_angle);
                      sr.WriteLine(Properties.Settings.Default.min_pitch_angle);
                      sr.WriteLine(Properties.Settings.Default.roll_angle);
                      sr.WriteLine(Properties.Settings.Default.stall_speed);
                      sr.WriteLine(Properties.Settings.Default.max_airspeed);
                      sr.WriteLine(Properties.Settings.Default.max_lateral_overload);
                      sr.WriteLine(Properties.Settings.Default.reserve);
                      limitlabel.ForeColor = System.Drawing.Color.Black;
                      limitlabel.Text = "导出成功";

                      sr.WriteLine("SteerTrimView");
                      sr.WriteLine(Properties.Settings.Default.LeftAileron);
                      sr.WriteLine(Properties.Settings.Default.LeftAileronRatio);
                      sr.WriteLine(Properties.Settings.Default.RightAileron);
                      sr.WriteLine(Properties.Settings.Default.RightAileronRatio);
                      sr.WriteLine(Properties.Settings.Default.LeftTail);
                      sr.WriteLine(Properties.Settings.Default.LeftTailRatio);
                      sr.WriteLine(Properties.Settings.Default.RightTail);
                      sr.WriteLine(Properties.Settings.Default.RightTailRatio);
                      steertrimlabel.ForeColor = System.Drawing.Color.Black;
                      steertrimlabel.Text = "导出成功";

                      sr.Close();
                      fs.Close();
                  }
                  else
                  {
                      FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Write);
                      StreamWriter sr = new StreamWriter(fs);

                      sr.WriteLine("AttitudeLoopView");
                      sr.WriteLine(Properties.Settings.Default.roll_kp);
                      sr.WriteLine(Properties.Settings.Default.roll_ki);
                      sr.WriteLine(Properties.Settings.Default.roll_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind1);
                      sr.WriteLine(Properties.Settings.Default.pitch_kp);
                      sr.WriteLine(Properties.Settings.Default.pitch_ki);
                      sr.WriteLine(Properties.Settings.Default.pitch_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind2);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_kp);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_ki);
                      sr.WriteLine(Properties.Settings.Default.heading_offset_kd);
                      sr.WriteLine(Properties.Settings.Default.attitudeloop_remaind3);
                      attitudelabel.ForeColor = System.Drawing.Color.Black;
                      attitudelabel.Text = "导出成功";

                      sr.WriteLine("OverLoadLoopView");
                      sr.WriteLine(Properties.Settings.Default.head_kp);
                      sr.WriteLine(Properties.Settings.Default.head_ki);
                      sr.WriteLine(Properties.Settings.Default.head_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind1);
                      sr.WriteLine(Properties.Settings.Default.side_kp);
                      sr.WriteLine(Properties.Settings.Default.side_ki);
                      sr.WriteLine(Properties.Settings.Default.side_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind2);
                      sr.WriteLine(Properties.Settings.Default.up_kp);
                      sr.WriteLine(Properties.Settings.Default.up_ki);
                      sr.WriteLine(Properties.Settings.Default.up_kd);
                      sr.WriteLine(Properties.Settings.Default.overloadloop_remaind3);
                      overloadlabel.ForeColor = System.Drawing.Color.Black;
                      overloadlabel.Text = "导出成功";

                      sr.WriteLine("GuideCtrlView");
                      sr.WriteLine(Properties.Settings.Default.khead);
                      sr.WriteLine(Properties.Settings.Default.kxt);
                      sr.WriteLine(Properties.Settings.Default.kc);
                      sr.WriteLine(Properties.Settings.Default.kr);
                      sr.WriteLine(Properties.Settings.Default.l1guide_dr);
                      sr.WriteLine(Properties.Settings.Default.l1guide_p);
                      sr.WriteLine(Properties.Settings.Default.l1guide_kig);
                      sr.WriteLine(Properties.Settings.Default.throttle_t);
                      sr.WriteLine(Properties.Settings.Default.throttle_d);
                      sr.WriteLine(Properties.Settings.Default.throttle_i);
                      sr.WriteLine(Properties.Settings.Default.throttle_turn);
                      sr.WriteLine(Properties.Settings.Default.pitch_kw);
                      sr.WriteLine(Properties.Settings.Default.pitch_i);
                      sr.WriteLine(Properties.Settings.Default.pitch_t);
                      sr.WriteLine(Properties.Settings.Default.pitch_d);
                      sr.WriteLine(Properties.Settings.Default.kspd);
                      sr.WriteLine(Properties.Settings.Default.kspdi);
                      sr.WriteLine(Properties.Settings.Default.kspdd);
                      sr.WriteLine(Properties.Settings.Default.kh);
                      sr.WriteLine(Properties.Settings.Default.khi);
                      sr.WriteLine(Properties.Settings.Default.khd);
                      sr.WriteLine(Properties.Settings.Default.kpd);
                      sr.WriteLine(Properties.Settings.Default.kid);
                      sr.WriteLine(Properties.Settings.Default.kdd);
                      guideCtrllabel.ForeColor = System.Drawing.Color.Black;
                      guideCtrllabel.Text = "导出成功";

                      sr.WriteLine("TakeOffView");
                      sr.WriteLine(Properties.Settings.Default.takeoff_offset);
                      sr.WriteLine(Properties.Settings.Default.lift_pull);
                      sr.WriteLine(Properties.Settings.Default.pull_time);
                      sr.WriteLine(Properties.Settings.Default.pull_alt);
                      sr.WriteLine(Properties.Settings.Default.vspeed);
                      sr.WriteLine(Properties.Settings.Default.takeoff_type);
                      takeofflabel.ForeColor = System.Drawing.Color.Black;
                      takeofflabel.Text = "导出成功";

                      sr.WriteLine("GuideView");
                      sr.WriteLine(Properties.Settings.Default.alt);
                      sr.WriteLine(Properties.Settings.Default.speed);
                      sr.WriteLine(Properties.Settings.Default.heading);
                      guidelabel.ForeColor = System.Drawing.Color.Black;
                      guidelabel.Text = "导出成功";

                      sr.WriteLine("LoiterView");
                      sr.WriteLine(Properties.Settings.Default.loiter_radius);
                      sr.WriteLine(Properties.Settings.Default.op_lng);
                      sr.WriteLine(Properties.Settings.Default.op_lat);
                      sr.WriteLine(Properties.Settings.Default.loiter_dir);
                      loiterlabel.ForeColor = System.Drawing.Color.Black;
                      loiterlabel.Text = "导出成功";

                      sr.WriteLine("LimitView");
                      sr.WriteLine(Properties.Settings.Default.aileron);
                      sr.WriteLine(Properties.Settings.Default.elevator);
                      sr.WriteLine(Properties.Settings.Default.rudder);
                      sr.WriteLine(Properties.Settings.Default.frontwheel);
                      sr.WriteLine(Properties.Settings.Default.max_throttle);
                      sr.WriteLine(Properties.Settings.Default.min_throttle);
                      sr.WriteLine(Properties.Settings.Default.max_pitch_angle);
                      sr.WriteLine(Properties.Settings.Default.min_pitch_angle);
                      sr.WriteLine(Properties.Settings.Default.roll_angle);
                      sr.WriteLine(Properties.Settings.Default.stall_speed);
                      sr.WriteLine(Properties.Settings.Default.max_airspeed);
                      sr.WriteLine(Properties.Settings.Default.max_lateral_overload);
                      sr.WriteLine(Properties.Settings.Default.reserve);
                      limitlabel.ForeColor = System.Drawing.Color.Black;
                      limitlabel.Text = "导出成功";

                      sr.WriteLine("SteerTrimView");
                      sr.WriteLine(Properties.Settings.Default.LeftAileron);
                      sr.WriteLine(Properties.Settings.Default.LeftAileronRatio);
                      sr.WriteLine(Properties.Settings.Default.RightAileron);
                      sr.WriteLine(Properties.Settings.Default.RightAileronRatio);
                      sr.WriteLine(Properties.Settings.Default.LeftTail);
                      sr.WriteLine(Properties.Settings.Default.LeftTailRatio);
                      sr.WriteLine(Properties.Settings.Default.RightTail);
                      sr.WriteLine(Properties.Settings.Default.RightTailRatio);
                      steertrimlabel.ForeColor = System.Drawing.Color.Black;
                      steertrimlabel.Text = "导出成功";

                      sr.Close();
                      fs.Close();
                  }





              }
          }*/

        /* private void button5_Click(object sender, EventArgs e)
         {
             string localFilePath = String.Empty;


             OpenFileDialog openFileDialog1 = new OpenFileDialog();
             //设置默认打开位置
             openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
             openFileDialog1.RestoreDirectory = true;
             localFilePath = openFileDialog1.FileName.ToString();
             if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 localFilePath = openFileDialog1.FileName;
  //               MessageBox.Show(localFilePath);
                 System.IO.StreamReader st;
                 st = new System.IO.StreamReader(localFilePath, System.Text.Encoding.UTF8);
                 //UTF-8通用编码
                 String line;
                 int i = 1;
                 string paramall = "";
                 while ((line = st.ReadLine()) != null)
                 {
                     paramall += line.ToString() + ";";
                     i++;
                 }

                 string[] array = paramall.Split(';');

                 for (int index = 0; index < array.Length; index++)
                 {
                     if (array[index].Equals("AttitudeLoopView"))
                     {
                         JYLink.jylink_attitudeloop_param_setup attitudeparam = new JYLink.jylink_attitudeloop_param_setup();
                         attitudeparam.roll_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.roll_kp = array[index];
                         attitudeparam.roll_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.roll_ki = array[index];
                         attitudeparam.roll_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.roll_kd = array[index];
                         attitudeparam.remaind1 = Single.Parse(array[++index]);
                         Properties.Settings.Default.attitudeloop_remaind1 = array[index];
                         attitudeparam.pitch_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_kp = array[index];
                         attitudeparam.pitch_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_ki = array[index];
                         attitudeparam.pitch_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_kd = array[index];
                         attitudeparam.remaind2 = Single.Parse(array[++index]);
                         Properties.Settings.Default.attitudeloop_remaind2 = array[index];
                         attitudeparam.heading_offset_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.heading_offset_kp = array[index];
                         attitudeparam.heading_offset_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.heading_offset_ki = array[index];
                         attitudeparam.heading_offset_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.heading_offset_kd = array[index];
                         attitudeparam.remaind3 = Single.Parse(array[++index]);
                         Properties.Settings.Default.attitudeloop_remaind3 = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }
                         //将姿态环参数内容发送到飞控
                         bool result = port.setupAttitudeLoop(attitudeparam);
                         //判断执行结果
                         if (result)
                         {
                             attitudelabel.ForeColor = System.Drawing.Color.Black;
                             attitudelabel.Text = "设置成功";
                         }
                         else
                         {
                             attitudelabel.ForeColor = System.Drawing.Color.Red;
                             attitudelabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("OverLoadLoopView"))
                     {
                         JYLink.jylink_overloadloop_param_setup overloadparam = new JYLink.jylink_overloadloop_param_setup();
                         overloadparam.head_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.head_kp = array[index];
                         overloadparam.head_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.head_ki = array[index];
                         overloadparam.head_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.head_kd = array[index];
                         overloadparam.remaind1 = Single.Parse(array[++index]);
                         Properties.Settings.Default.overloadloop_remaind1 = array[index];
                         overloadparam.side_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.side_kp = array[index];
                         overloadparam.side_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.side_ki = array[index];
                         overloadparam.side_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.side_kd = array[index];
                         overloadparam.remaind2 = Single.Parse(array[++index]);
                         Properties.Settings.Default.overloadloop_remaind2 = array[index];
                         overloadparam.up_kp = Single.Parse(array[++index]);
                         Properties.Settings.Default.up_kp = array[index];
                         overloadparam.up_ki = Single.Parse(array[++index]);
                         Properties.Settings.Default.up_ki = array[index];
                         overloadparam.up_kd = Single.Parse(array[++index]);
                         Properties.Settings.Default.up_kd = array[index];
                         overloadparam.remaind3 = Single.Parse(array[++index]);
                         Properties.Settings.Default.overloadloop_remaind3 = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }
                         //将过载环参数内容发送到飞控
                         bool result = port.setupOverLoadLoop(overloadparam);
                         if (result)
                         {
                             overloadlabel.ForeColor = System.Drawing.Color.Black;
                             overloadlabel.Text = "设置成功";
                         }
                         else
                         {
                             overloadlabel.ForeColor = System.Drawing.Color.Red;
                             overloadlabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("GuideCtrlView"))
                     {
                         JYLink.jylink_guidectrl_param_setup guidectrlparam = new JYLink.jylink_guidectrl_param_setup();
                         guidectrlparam.khead = Single.Parse(array[++index]);
                         Properties.Settings.Default.khead = array[index];
                         guidectrlparam.kxt = Single.Parse(array[++index]);
                         Properties.Settings.Default.kxt = array[index];
                         guidectrlparam.kc = Single.Parse(array[++index]);
                         Properties.Settings.Default.kc = array[index];
                         guidectrlparam.kr = Single.Parse(array[++index]);
                         Properties.Settings.Default.kr = array[index];
                         guidectrlparam.l1guide_dr = Single.Parse(array[++index]);
                         Properties.Settings.Default.l1guide_dr = array[index];
                         guidectrlparam.l1guide_p = Single.Parse(array[++index]);
                         Properties.Settings.Default.l1guide_p = array[index];
                         guidectrlparam.l1guide_kig = Single.Parse(array[++index]);
                         Properties.Settings.Default.l1guide_kig = array[index];

                         guidectrlparam.throttle_t = Single.Parse(array[++index]);
                         Properties.Settings.Default.throttle_t = array[index];
                         guidectrlparam.throttle_d = Single.Parse(array[++index]);
                         Properties.Settings.Default.throttle_d = array[index];
                         guidectrlparam.throttle_i = Single.Parse(array[++index]);
                         Properties.Settings.Default.throttle_i = array[index];
                         guidectrlparam.throttle_turn = Single.Parse(array[++index]);
                         Properties.Settings.Default.throttle_turn = array[index];
                         guidectrlparam.pitch_kw = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_kw = array[index];
                         guidectrlparam.pitch_i = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_i = array[index];
                         guidectrlparam.pitch_t = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_t = array[index];
                         guidectrlparam.pitch_d = Single.Parse(array[++index]);
                         Properties.Settings.Default.pitch_d = array[index];
                         guidectrlparam.kspd = Single.Parse(array[++index]);
                         Properties.Settings.Default.kspd = array[index];
                         guidectrlparam.kspdi = Single.Parse(array[++index]);
                         Properties.Settings.Default.kspdi = array[index];
                         guidectrlparam.kspdd = Single.Parse(array[++index]);
                         Properties.Settings.Default.kspdd = array[index];
                         guidectrlparam.kh = Single.Parse(array[++index]);
                         Properties.Settings.Default.kh = array[index];
                         guidectrlparam.khi = Single.Parse(array[++index]);
                         Properties.Settings.Default.khi = array[index];
                         guidectrlparam.khd = Single.Parse(array[++index]);
                         Properties.Settings.Default.khd = array[index];
                         guidectrlparam.kpd = Single.Parse(array[++index]);
                         Properties.Settings.Default.kpd = array[index];
                         guidectrlparam.kid = Single.Parse(array[++index]);
                         Properties.Settings.Default.kid = array[index];
                         guidectrlparam.kdd = Single.Parse(array[++index]);
                         Properties.Settings.Default.kdd = array[index];

                         Properties.Settings.Default.Save();


                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }
                         //将制导参数内容发送到飞控
                         bool result = port.setupGuideCtrl(guidectrlparam);
                         //判断执行结果
                         if (result)
                         {
                             guideCtrllabel.ForeColor = System.Drawing.Color.Black;
                             guideCtrllabel.Text = "设置成功";
                         }
                         else
                         {
                             guideCtrllabel.ForeColor = System.Drawing.Color.Red;
                             guideCtrllabel.Text = "设置失败";
                         }

                     }
                     else if (array[index].Equals("TakeOffView"))
                     {
                         JYLink.jylink_takeoff_param_setup takeoffparam = new JYLink.jylink_takeoff_param_setup();
                         takeoffparam.takeoff_offset = Single.Parse(array[++index]);
                         Properties.Settings.Default.takeoff_offset = array[index];
                         takeoffparam.lift_pull = Single.Parse(array[++index]);
                         Properties.Settings.Default.lift_pull = array[index];
                         takeoffparam.pull_time = Single.Parse(array[++index]);
                         Properties.Settings.Default.pull_time = array[index];
                         takeoffparam.pull_alt = Single.Parse(array[++index]);
                         Properties.Settings.Default.pull_alt = array[index];
                         takeoffparam.vspeed = Single.Parse(array[++index]);
                         Properties.Settings.Default.vspeed = array[index];
                         takeoffparam.takeoff_type = Byte.Parse(array[++index]);//起飞类型
                         Properties.Settings.Default.takeoff_type = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }
                         //将起飞参数内容发送到飞控
                         bool result = port.setupTakeOff(takeoffparam);
                         //判断执行结果
                         if (result)
                         {
                             takeofflabel.ForeColor = System.Drawing.Color.Black;
                             takeofflabel.Text = "设置成功";
                         }
                         else
                         {
                             takeofflabel.ForeColor = System.Drawing.Color.Red;
                             takeofflabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("GuideView"))
                     {
                         JYLink.jylink_guide_param_setup guideparam = new JYLink.jylink_guide_param_setup();
                         guideparam.alt = Single.Parse(array[++index]);
                         Properties.Settings.Default.alt = array[index];
                         guideparam.speed = Single.Parse(array[++index]);
                         Properties.Settings.Default.speed = array[index];
                         guideparam.heading = Single.Parse(array[++index]);
                         Properties.Settings.Default.heading = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }
                         //将引导参数内容发送到飞控
                         bool result = port.setupGuide(guideparam);
                         //判断执行结果
                         if (result)
                         {
                             guidelabel.ForeColor = System.Drawing.Color.Black;
                             guidelabel.Text = "设置成功";
                         }
                         else
                         {
                             guidelabel.ForeColor = System.Drawing.Color.Red;
                             guidelabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("LoiterView"))
                     {
                         JYLink.jylink_loiter_param_setup loiterparam = new JYLink.jylink_loiter_param_setup();
                         loiterparam.loiter_radius = Single.Parse(array[++index]);
                         Properties.Settings.Default.loiter_radius = array[index];
                         loiterparam.op_lng = Double.Parse(array[++index]);
                         Properties.Settings.Default.op_lng = array[index];
                         loiterparam.op_lat = Double.Parse(array[++index]);
                         Properties.Settings.Default.op_lat = array[index];
                         loiterparam.loiter_dir = Byte.Parse(array[++index]);
                         Properties.Settings.Default.loiter_dir = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                             throw new Exception("请先连接!");
                         }
                         //将盘旋参数内容发送到飞控
                         bool result = port.setupLoiter(loiterparam);
                         //判断执行结果
                         if (result)
                         {
                             loiterlabel.ForeColor = System.Drawing.Color.Black;
                             loiterlabel.Text = "设置成功";
                         }
                         else
                         {
                             loiterlabel.ForeColor = System.Drawing.Color.Red;
                             loiterlabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("LimitView"))
                     {
                         JYLink.jylink_limit_param_setup limitparam = new JYLink.jylink_limit_param_setup();
                         limitparam.aileron = Single.Parse(array[++index]);
                         Properties.Settings.Default.aileron = array[index];
                         limitparam.elevator = Single.Parse(array[++index]);
                         Properties.Settings.Default.elevator = array[index];
                         limitparam.rudder = Single.Parse(array[++index]);
                         Properties.Settings.Default.rudder = array[index];
                         limitparam.frontwheel = Single.Parse(array[++index]);
                         Properties.Settings.Default.frontwheel = array[index];
                         limitparam.max_throttle = Single.Parse(array[++index]);
                         Properties.Settings.Default.max_throttle = array[index];
                         limitparam.min_throttle = Single.Parse(array[++index]);
                         Properties.Settings.Default.min_throttle = array[index];
                         limitparam.max_pitch_angle = Single.Parse(array[++index]);
                         Properties.Settings.Default.max_pitch_angle = array[index];
                         limitparam.min_pitch_angle = Single.Parse(array[++index]);
                         Properties.Settings.Default.min_pitch_angle = array[index];
                         limitparam.roll_angle = Single.Parse(array[++index]);
                         Properties.Settings.Default.roll_angle = array[index];
                         limitparam.stall_speed = Single.Parse(array[++index]);
                         Properties.Settings.Default.stall_speed = array[index];
                         limitparam.max_airspeed = Single.Parse(array[++index]);
                         Properties.Settings.Default.max_airspeed = array[index];
                         limitparam.max_lateral_overload = Single.Parse(array[++index]);
                         Properties.Settings.Default.max_lateral_overload = array[index];
                         limitparam.reserve = Single.Parse(array[++index]);
                         Properties.Settings.Default.reserve = array[index];

                         Properties.Settings.Default.Save();

                         JYLinkInterface port = MainForm.comPort;

                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                             throw new Exception("请先连接!");
                         }
                         bool result = port.setupLimit(limitparam);
                         if (result)
                         {
                             limitlabel.ForeColor = System.Drawing.Color.Black;
                             limitlabel.Text = "设置成功";
                         }
                         else
                         {
                             limitlabel.ForeColor = System.Drawing.Color.Red;
                             limitlabel.Text = "设置失败";
                         }
                     }
                     else if (array[index].Equals("SteerTrimView"))
                     {
                         JYLink.jylink_steertrim_param_setup steertrimparam = new JYLink.jylink_steertrim_param_setup();
                         steertrimparam.LeftAileron = Int16.Parse(array[++index]);
                         Properties.Settings.Default.LeftAileron = array[index];
                         steertrimparam.LeftAileronRatio = Single.Parse(array[++index]);
                         Properties.Settings.Default.LeftAileronRatio = array[index];
                         steertrimparam.RightAileron = Int16.Parse(array[++index]);
                         Properties.Settings.Default.RightAileron = array[index];
                         steertrimparam.RightAileronRatio = Single.Parse(array[++index]);
                         Properties.Settings.Default.RightAileronRatio = array[index];
                         steertrimparam.LeftTail = Int16.Parse(array[++index]);
                         Properties.Settings.Default.LeftTail = array[index];
                         steertrimparam.LeftTailRatio = Single.Parse(array[++index]);
                         Properties.Settings.Default.LeftTailRatio = array[index];
                         steertrimparam.RightTail = Int16.Parse(array[++index]);
                         Properties.Settings.Default.RightTail = array[index];
                         steertrimparam.RightTailRatio = Single.Parse(array[++index]);
                         Properties.Settings.Default.RightTailRatio = array[index];
                         Properties.Settings.Default.Save();
                         JYLinkInterface port = MainForm.comPort;
                         //判断是否连接
                         if (!port.BaseStream.IsOpen)
                         {
                             MessageBox.Show("请先连接!");
                             return;
                         }

                         bool result = port.setupSteerTrim(steertrimparam);

                         //bool result = true;
                         if (result)
                         {
                             steertrimlabel.ForeColor = System.Drawing.Color.Black;
                             steertrimlabel.Text = "设置成功";
                         }
                         else
                         {
                             steertrimlabel.ForeColor = System.Drawing.Color.Red;
                             steertrimlabel.Text = "设置失败";
                         }

                     }


                 }


             }
         } */

        private void button4_Click(object sender, EventArgs e)
        {
            JYLinkInterface port = MainForm.comPort;
            //判断是否连接
            if (!port.BaseStream.IsOpen)
            {

                MessageBox.Show("请先连接!");
                return;
            }

            JYLink.jylink_attitudeloop_param_down attitudeloopParam = new JYLink.jylink_attitudeloop_param_down();
            attitudeloopParam = port.searchAttitudeLoop();

            if ((Properties.Settings.Default.roll_kp.Equals(attitudeloopParam.roll_kp.ToString())) && (Properties.Settings.Default.roll_ki.Equals(attitudeloopParam.roll_ki.ToString())) &&
                (Properties.Settings.Default.roll_kd.Equals(attitudeloopParam.roll_kd.ToString())) && (Properties.Settings.Default.attitudeloop_remaind1.Equals(attitudeloopParam.attitudeloop_remaind1.ToString())) &&
                (Properties.Settings.Default.pitch_kp.Equals(attitudeloopParam.pitch_kp.ToString())) && (Properties.Settings.Default.pitch_ki.Equals(attitudeloopParam.pitch_ki.ToString())) &&
                (Properties.Settings.Default.pitch_kd.Equals(attitudeloopParam.pitch_kd.ToString())) && (Properties.Settings.Default.attitudeloop_remaind2.Equals(attitudeloopParam.attitudeloop_remaind2.ToString())) &&
                (Properties.Settings.Default.heading_offset_kp.Equals(attitudeloopParam.heading_offset_kp.ToString())) && (Properties.Settings.Default.heading_offset_ki.Equals(attitudeloopParam.heading_offset_ki.ToString())) &&
                (Properties.Settings.Default.heading_offset_kd.Equals(attitudeloopParam.heading_offset_kd.ToString())) && (Properties.Settings.Default.attitudeloop_remaind3.Equals(attitudeloopParam.attitudeloop_remaind3.ToString())))
            {
                attitudelabel.ForeColor = System.Drawing.Color.Black;
                attitudelabel.Text = "参数相同";
            }
            else
            {
                attitudelabel.ForeColor = System.Drawing.Color.Red;
                attitudelabel.Text = "参数不同";
            }

            //JYLink.jylink_overloadloop_param_down overloadloopParam = new JYLink.jylink_overloadloop_param_down();
            //overloadloopParam = port.searchOverLoadLoop();
            //if((Properties.Settings.Default.head_kp.Equals(overloadloopParam.head_kp.ToString()))&&(Properties.Settings.Default.head_ki.Equals(overloadloopParam.head_ki.ToString()))&&
            //    (Properties.Settings.Default.head_kd.Equals(overloadloopParam.head_kd.ToString()))&&(Properties.Settings.Default.overloadloop_remaind1.Equals(overloadloopParam.remaind1.ToString()))&&
            //    (Properties.Settings.Default.side_kp.Equals(overloadloopParam.side_kp.ToString()))&&(Properties.Settings.Default.side_ki.Equals(overloadloopParam.side_ki.ToString()))&&
            //    (Properties.Settings.Default.side_kd.Equals(overloadloopParam.side_kd.ToString()))&&(Properties.Settings.Default.overloadloop_remaind2.Equals(overloadloopParam.remaind2.ToString()))&&
            //    (Properties.Settings.Default.up_kp.Equals(overloadloopParam.up_kp.ToString()))&&(Properties.Settings.Default.up_kp.Equals(overloadloopParam.up_kp.ToString()))&&
            //    (Properties.Settings.Default.up_kd.Equals(overloadloopParam.up_kd.ToString()))&&(Properties.Settings.Default.overloadloop_remaind3.Equals(overloadloopParam.remaind3.ToString())))
            //{
            //    overloadlabel.ForeColor = System.Drawing.Color.Black;
            //    overloadlabel.Text = "参数相同";
            //}
            //else
            //{
            //    overloadlabel.ForeColor = System.Drawing.Color.Red;
            //    overloadlabel.Text = "参数不同";
            //}


            JYLink.jylink_guidectrl_param_down guidectrlParam = new JYLink.jylink_guidectrl_param_down();
            guidectrlParam = port.searchGuideCtrl();
            if ((Properties.Settings.Default.khead.Equals(guidectrlParam.khead.ToString())) && (Properties.Settings.Default.kxt.Equals(guidectrlParam.kxt.ToString())) &&
                (Properties.Settings.Default.kc.Equals(guidectrlParam.kc.ToString())) && (Properties.Settings.Default.kr.Equals(guidectrlParam.kr.ToString())) &&
                (Properties.Settings.Default.l1guide_dr.Equals(guidectrlParam.l1guide_dr.ToString())) && (Properties.Settings.Default.l1guide_p.Equals(guidectrlParam.l1guide_p.ToString())) &&
                (Properties.Settings.Default.l1guide_kig.Equals(guidectrlParam.l1guide_kig.ToString())) && (Properties.Settings.Default.throttle_t.Equals(guidectrlParam.throttle_t.ToString())) &&
                (Properties.Settings.Default.throttle_d.Equals(guidectrlParam.throttle_d.ToString())) && (Properties.Settings.Default.throttle_i.Equals(guidectrlParam.throttle_i.ToString())) &&
                (Properties.Settings.Default.throttle_turn.Equals(guidectrlParam.throttle_turn.ToString())) && (Properties.Settings.Default.pitch_kw.Equals(guidectrlParam.pitch_kw.ToString())) &&
                (Properties.Settings.Default.pitch_d.Equals(guidectrlParam.pitch_d.ToString())) && (Properties.Settings.Default.kspd.Equals(guidectrlParam.kspd.ToString())) &&
                (Properties.Settings.Default.kspdi.Equals(guidectrlParam.kspdi.ToString())) && (Properties.Settings.Default.kspdd.Equals(guidectrlParam.kspdd.ToString())) &&
                (Properties.Settings.Default.kh.Equals(guidectrlParam.kh.ToString())) && (Properties.Settings.Default.khi.Equals(guidectrlParam.khi.ToString())) &&
                (Properties.Settings.Default.khd.Equals(guidectrlParam.khd.ToString())) && (Properties.Settings.Default.kpd.Equals(guidectrlParam.kpd.ToString())) &&
                (Properties.Settings.Default.kid.Equals(guidectrlParam.kid.ToString())) && (Properties.Settings.Default.kdd.Equals(guidectrlParam.kdd.ToString())))
            {
                guideCtrllabel.ForeColor = System.Drawing.Color.Black;
                guideCtrllabel.Text = "参数相同";
            }
            else
            {
                guideCtrllabel.ForeColor = System.Drawing.Color.Red;
                guideCtrllabel.Text = "参数不同";
            }

            //JYLink.jylink_takeoff_param_down takeoffParam = new JYLink.jylink_takeoff_param_down();
            //takeoffParam = port.searchTakeOff();
            //if ((Properties.Settings.Default.takeoff_offset.Equals(takeoffParam.takeoff_offset.ToString())) && (Properties.Settings.Default.lift_pull.Equals(takeoffParam.lift_pull.ToString()))&&
            //    (Properties.Settings.Default.pull_time.Equals(takeoffParam.pull_time.ToString())) && (Properties.Settings.Default.pull_alt.Equals(takeoffParam.pull_alt.ToString()))&&
            //    (Properties.Settings.Default.vspeed.Equals(takeoffParam.vspeed.ToString())) && (Properties.Settings.Default.takeoff_type.Equals(takeoffParam.takeoff_type.ToString())))
            //{
            //    takeofflabel.ForeColor = System.Drawing.Color.Black;
            //    takeofflabel.Text = "参数相同";
            //}
            //else
            //{
            //    takeofflabel.ForeColor = System.Drawing.Color.Red;
            //    takeofflabel.Text = "参数不同";
            //}

            //JYLink.jylink_guide_param_down guideParam = new JYLink.jylink_guide_param_down();
            //guideParam = port.searchGuide();
            //if ((Properties.Settings.Default.alt.Equals(guideParam.alt.ToString())) && (Properties.Settings.Default.speed.Equals(guideParam.speed.ToString()))&&
            //    (Properties.Settings.Default.heading.Equals(guideParam.heading.ToString())))
            //{
            //    guidelabel.ForeColor = System.Drawing.Color.Black;
            //    guidelabel.Text = "参数相同";
            //}
            //else
            //{
            //    guidelabel.ForeColor = System.Drawing.Color.Red;
            //    guidelabel.Text = "参数不同";
            //}

            //JYLink.jylink_loiter_param_down loiterParam = new JYLink.jylink_loiter_param_down();
            //loiterParam = port.searchLoiter();
            //if ((Properties.Settings.Default.loiter_radius.Equals(loiterParam.loiter_radius.ToString())) && (Properties.Settings.Default.op_lng.Equals(loiterParam.op_lng.ToString()))&&
            //    (Properties.Settings.Default.op_lat.Equals(loiterParam.op_lat.ToString())) && (Properties.Settings.Default.loiter_dir.Equals(loiterParam.loiter_dir.ToString())))
            //{
            //    loiterlabel.ForeColor = System.Drawing.Color.Black;
            //    loiterlabel.Text = "参数相同";
            //}
            //else
            //{
            //    loiterlabel.ForeColor = System.Drawing.Color.Red;
            //    loiterlabel.Text = "参数不同";
            //}

            JYLink.jylink_limit_param_down limitParam = new JYLink.jylink_limit_param_down();
            limitParam = port.searchLimit();
            if ((Properties.Settings.Default.aileron.Equals(limitParam.aileron.ToString())) && (Properties.Settings.Default.elevator.Equals(limitParam.elevator.ToString())) &&
                (Properties.Settings.Default.rudder.Equals(limitParam.rudder.ToString())) && (Properties.Settings.Default.frontwheel.Equals(limitParam.frontwheel.ToString())) &&
                (Properties.Settings.Default.max_throttle.Equals(limitParam.max_throttle.ToString())) && (Properties.Settings.Default.min_throttle.Equals(limitParam.min_throttle.ToString())) &&
                (Properties.Settings.Default.max_pitch_angle.Equals(limitParam.max_pitch_angle.ToString())) && (Properties.Settings.Default.min_pitch_angle.Equals(limitParam.min_pitch_angle.ToString())) &&
                (Properties.Settings.Default.roll_angle.Equals(limitParam.roll_angle.ToString())) && (Properties.Settings.Default.stall_speed.Equals(limitParam.stall_speed.ToString())) &&
                (Properties.Settings.Default.max_airspeed.Equals(limitParam.max_airspeed.ToString())) && (Properties.Settings.Default.max_lateral_overload.Equals(limitParam.max_lateral_overload.ToString())) &&
                (Properties.Settings.Default.reserve.Equals(limitParam.reserve.ToString())))
            {
                limitlabel.ForeColor = System.Drawing.Color.Black;
                limitlabel.Text = "参数相同";
            }
            else
            {
                limitlabel.ForeColor = System.Drawing.Color.Red;  
                limitlabel.Text = "参数不同";
            }

            //JYLink.jylink_steertrim_param_down steertrimParam = new JYLink.jylink_steertrim_param_down();
            //steertrimParam = port.searchSteerTrim();
            //if ((Properties.Settings.Default.LeftAileron.Equals(steertrimParam.LeftAileron.ToString())) && (Properties.Settings.Default.LeftAileronRatio.Equals(steertrimParam.LeftAileronRatio.ToString()))&&
            //    (Properties.Settings.Default.RightAileron.Equals(steertrimParam.RightAileron.ToString())) && (Properties.Settings.Default.RightAileronRatio.Equals(steertrimParam.RightAileronRatio.ToString()))&&
            //    (Properties.Settings.Default.LeftTail.Equals(steertrimParam.LeftTail.ToString())) && (Properties.Settings.Default.LeftTailRatio.Equals(steertrimParam.LeftTailRatio.ToString()))&&
            //    (Properties.Settings.Default.RightTail.Equals(steertrimParam.RightTail.ToString())) && (Properties.Settings.Default.RightTailRatio.Equals(steertrimParam.RightTailRatio.ToString())))
            //{
            //    steertrimlabel.ForeColor = System.Drawing.Color.Black;
            //    steertrimlabel.Text = "参数相同";
            //}
            //else
            //{
            //    steertrimlabel.ForeColor = System.Drawing.Color.Red;
            //    steertrimlabel.Text = "参数不同";
            //}





        }

        private void DataManageFrm_Load(object sender, EventArgs e)
        {

        }



    }
}