using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBGroundControl.Forms.utils
{
    class DictionaryTools
    {
        //遥测数据中英文映射字典
        public static Dictionary<string, string>  getTelemDic()
        {
            Dictionary<string, string> telem = new Dictionary<string, string>();
            telem.Add("satcount", "卫星数");
            telem.Add("lat", "纬度");
            telem.Add("lng", "经度");
            telem.Add("alt", "高度");
            telem.Add("roll", "滚转");
            telem.Add("pitch", "俯仰");
            telem.Add("yaw", "偏航");
            telem.Add("airspeed", "空速");
            telem.Add("battery_voltage", "飞控电压");
            telem.Add("current", "飞控电流");
            telem.Add("accel_cal_x", "加速度X");
            telem.Add("accel_cal_y", "加速度Y");
            telem.Add("accel_cal_z", "加速度Z");
            telem.Add("wpno", "航点序号");
            telem.Add("wp_dist", "距下一航点距离");
            telem.Add("second_count", "秒计数");
            telem.Add("barome_altitude", "气压高度");
            telem.Add("rpm", "左RPM");
            telem.Add("rpm1", "右RPM");
            telem.Add("east_speed", "东速");
            telem.Add("north_speed", "北速");
            telem.Add("air_speed", "天速");
            telem.Add("waypoint_cmd", "航点指令");
            telem.Add("next_waypoint_cmd", "下一航点指令");
            telem.Add("distance_to_home", "距家距离");
            telem.Add("utc_hour", "UTC时");
            telem.Add("utc_minute", "UTC分");
            telem.Add("utc_second", "UTC秒");
            telem.Add("change_flag", "切换标志");
            telem.Add("position_state", "定位状态");
            telem.Add("setcontrol_mode", "预设飞控模式");
            telem.Add("flightcontrol_mode", "飞控模式");
            telem.Add("servo_voltage", "舵机电压");
            telem.Add("servo_current", "舵机电流");
            telem.Add("load1_voltage", "负载1电压");
            telem.Add("load1_current", "负载1电流");
            telem.Add("land_stage", "降落阶段");
            telem.Add("load2_current", "负载2电流");
            telem.Add("load3_voltage", "负载3电压");
            telem.Add("load3_current", "负载3电流");
            telem.Add("load4_voltage", "负载4电压");
            telem.Add("load4_current", "负载4电流");
            telem.Add("load5_voltage", "负载5电压");
            telem.Add("load5_current", "负载5电流");
            telem.Add("ecu_head_tempreture", "ECU钢头温度");
            telem.Add("ecu_voltage1", "左动力电压");
            telem.Add("ecu_voltage2", "右动力电压");
            telem.Add("ecu_voltage", "ECU电压");
            telem.Add("ignition_pump_choke", "点火、油泵、吸油");
            telem.Add("auto_step", "飞行阶段");
            telem.Add("ecu_duty_cycle", "ECU占空比");
            telem.Add("angle_x", "角速度X");
            telem.Add("angle_y", "角速度Y");
            telem.Add("angle_z", "角速度Z");
            return telem;
        }
        //飞行模式映射字典
        public static Dictionary<byte, string> getFlightMode()
        {
        //     Manual = 0x01, //手动控制飞机
        //Stabilize = 0x00, //自稳模式
        //Alt_Hold = 0x02, //定高飞行模式  手动控制油门，飞控进行高度和航向保持
        //Loiter = 0x04, //定点盘旋  定点绕圆圈飞行，半径根据盘旋半径参数
        //Longitudinal = 0x08, //定高定速模式  飞控自动控制高度、速度(空速)、方向，永远朝向远处1Km的目标 (机头锁定)
        //Guided = 0x10, //航迹飞行  根据地面站的航迹文件，进行导引飞行，到达位置后定点绕圆
        //RTL = 0x20, //自动返航模式  自动返航模式
        //Mot_ContinueRoll = 0x42, //机动模式  连续横滚
        //Mot_AnglePitch = 0x44, //机动模式  大角度俯冲
        //Mot_LevelTurn = 0x48, //机动模式  水平转弯
        //Mot_YMM_Motorized = 0x50, //机动模式  英麦曼机动
        //Mot_Loop = 0x60, //机动模式  筋斗
        //Auto = 0x80 //自动模式  完成自动起飞、爬升、导引飞行、机动飞行和自动降落
            Dictionary<byte, string> telem = new Dictionary<byte, string>();
            telem.Add(0x01, "手动模式"); //Manual
            telem.Add(0x00, "自稳模式");//Stabilize
            telem.Add(0x02, "定高模式");//Alt_Hold
            telem.Add(0x04, "定点盘旋");//Loiter
            telem.Add(0x08, "定高定速模式");//Longitudinal
            telem.Add(0x10, "航迹模式");//Guided
            telem.Add(0x20, "自动返航模式");//RTL
            telem.Add(0x42, "机动横滚");//Mot_ContinueRoll
            telem.Add(0x44, "机动俯冲");//Mot_AnglePitch
            telem.Add(0x48, "机动转弯");//Mot_LevelTurn
            telem.Add(0x50, "英麦曼机动");//Mot_YMM_Motorized
            telem.Add(0x60, "机动筋斗");//Mot_Loop
            telem.Add(0x80, "自动模式");//Auto
            
            return telem;
        }

        public static Dictionary<byte, string> getCmdName()
        {

            Dictionary<byte, string> telem = new Dictionary<byte, string>();
            telem.Add(0x2D, "姿态环参数设置");
            telem.Add(0xE1, "姿态环参数查询");
            telem.Add(0xA5, "航线上传");
            telem.Add(0xD2, "航线查询");
            telem.Add(0x0F, "飞行模式设置");
            telem.Add(0x1E, "初始舵面配平");
            telem.Add(0x3C, "过载环参数设置");
            telem.Add(0x3A, "制导环参数设置");
            telem.Add(0x39, "起飞参数设置");
            telem.Add(0x35, "引导参数设置");
            telem.Add(0x33, "盘旋飞行参数设置");
            telem.Add(0x30, "极限参数设置");
            telem.Add(0x4B, "极空速和气压高度校准");
            telem.Add(0x87, "系统自检");
            telem.Add(0x96, "舵机测试");
            telem.Add(0xB4, "ECU");
            telem.Add(0xE2, "过载环参数查询");
            telem.Add(0xE4, "制导参数查询");
            telem.Add(0xE8, "起飞参数查询");
            telem.Add(0xE7, "引导参数查询");
            telem.Add(0xF3, "盘旋飞行参数查询");
            telem.Add(0xED, "极限参数查询");
            telem.Add(0xEE, "舵面配平查询");
            telem.Add(0xD8, "星况测试");
            telem.Add(0xD4, "控制极性测试");
            telem.Add(0xD1, "链路测试");
            telem.Add(0xEA, "Home点查询");
            telem.Add(0xF0, "任务上传");

            return telem;
        }

        public static Dictionary<byte, string> getOffCondition()
        {
            Dictionary<byte, string> telem = new Dictionary<byte, string>();
            telem.Add(0, "正常运行");
            telem.Add(1, "RC关闭");
            telem.Add(2, "超温");
            telem.Add(3, "点火超时");
            telem.Add(4, "加速超时");
            telem.Add(5, "加速慢");
            telem.Add(6, "超转");
            telem.Add(7, "低转");
            telem.Add(8, "低电压");
            telem.Add(9, "自动停");
            telem.Add(10, "低温");
            telem.Add(11, "高温");
            telem.Add(12, "点火器故障");
            telem.Add(13, "看门口计时器");
            telem.Add(14, "失控保护关闭");
            telem.Add(15, "手动关闭");
            telem.Add(16, "供电故障");
            telem.Add(17, "温感故障");
            telem.Add(18, "燃油故障");
            telem.Add(19, "输出轴故障");
            telem.Add(20, "2级引擎故障");
            telem.Add(21, "2级引擎故障");
            telem.Add(22, "2级引擎故障");
            telem.Add(23, "无润滑油");
            telem.Add(24, "电流过大");
            telem.Add(25, "油泵故障");
            telem.Add(26, "油泵故障");
            telem.Add(27, "油泵故障");
            telem.Add(28, "燃油不足");
            telem.Add(29, "低转关闭");
            telem.Add(30, "低转关闭");
            telem.Add(31, "离合器故障");
            telem.Add(32, "ECU重启");
            telem.Add(33, "CAN通讯故障");
            telem.Add(34, "无RC脉宽");
            telem.Add(35, "转子堵转");
            telem.Add(36, "地线断开");
            telem.Add(37, "重启终止");
 
            return telem;
        }

        public static Dictionary<string,string>getCommand()
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command.Add("Manual", "手动");
            command.Add("Stabilize", "自稳");
            command.Add("Alt_Hold", "定高");
            command.Add("Loiter", "定点盘旋");
            command.Add("Longitudinal", "定高定速");
            command.Add("Guided", "航迹");
            command.Add("RTL", "自动返航");
            command.Add("Mot_ContinueRoll", "机动横滚");
            command.Add("Mot_AnglePitch", "机动俯冲");
            command.Add("Mot_LevelTurn", "机动转弯");
            command.Add("Mot_YMM_Motorized", "英麦曼机动");
            command.Add("Mot_Loop", "机动筋斗");
            command.Add("Auto", "自动模式");

            return command;
        }

        public static Dictionary<byte, string> getControlMode()
        {
            Dictionary<byte, string> telem = new Dictionary<byte, string>();
            telem.Add(0x00, "GNC");               //飞控模式
            telem.Add(0x01, "Futaba");            //遥控模式
            telem.Add(0x02, "Stabilize");      //断开连接
            telem.Add(0x03, "Loss_Connect");      //断开连接
            return telem;
        }
    }
}
