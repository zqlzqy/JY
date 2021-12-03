using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

public partial class JYLink
{
    public const byte JYLINK_STX_1 = 0xEB;
    public const byte JYLINK_STX_2 = 0x90;
    public const byte JYLINK_STX_3 = 0xDD;
    public const byte JYLINK_STX_4 = 0x77;
    public const byte JYLINK_HEADER_LEN = 5;
    public const byte JYLINK_NUM_HEADER_BYTES = (JYLINK_HEADER_LEN + 2);///< Length of all header bytes, including core and stx
    public static readonly jy_message_info[] JYLINK_MESSAGE_INFOS = new jy_message_info[] {
        new jy_message_info(0x00, "UNKNOW_MESSAGE_DOWN", 0, 8 , 8, typeof( jylink_unknow_messsage )),
        new jy_message_info(0xA0, "STATUS_PARAM_DOWN", 50, 66,66, typeof( jylink_status_param_down )),
        new jy_message_info(0xA1,"ATTITUDELOOP_PARAM_DOWN",60,48,48, typeof(jylink_attitudeloop_param_down)),
        new jy_message_info(0x01,"ATTITUDELOOP_PARAM_SETUP",60,48,48, typeof(jylink_attitudeloop_param_setup)),
        new jy_message_info(0x51,"ATTITUDELOOP_PARAM_SEARCH",60,8,8, typeof(jylink_attitudeloop_param_search)),
        new jy_message_info(0xA2,"OVERLOADLOOP_PARAM_DOWN",60,48,48, typeof(jylink_overloadloop_param_down)),
        new jy_message_info(0x02,"OVERLOADLOOP_PARAM_SETUP",60,48,48, typeof(jylink_overloadloop_param_setup)),
        new jy_message_info(0x52,"OVERLOADLOOP_PARAM_SEARCH",60,8,8, typeof(jylink_overloadloop_param_search)),
        new jy_message_info(0xA3,"GUIDECTRL_PARAM_DOWN",60,100,100, typeof(jylink_guidectrl_param_down)),
        new jy_message_info(0x03,"GUIDECTRL_PARAM_SETUP",60,100,100, typeof(jylink_guidectrl_param_setup)),
        new jy_message_info(0x53,"GUIDECTRL_PARAM_SEARCH",60,8,8, typeof(jylink_guidectrl_param_search)),
        new jy_message_info(0xA4,"TAKEOFF_PARAM_DOWN",60,21,21, typeof(jylink_takeoff_param_down)),
        new jy_message_info(0x04,"TAKEOFF_PARAM_SETUP",60,21,21, typeof(jylink_takeoff_param_setup)),
        new jy_message_info(0x54,"TAKEOFF_PARAM_SEARCH",60,8,8, typeof(jylink_takeoff_param_search)),
        new jy_message_info(0xA5,"GUIDE_PARAM_DOWN",60,12,12, typeof(jylink_guide_param_down)),
        new jy_message_info(0x05,"GUIDE_PARAM_SETUP",60,12,12, typeof(jylink_guide_param_setup)),
        new jy_message_info(0x55,"GUIDE_PARAM_SEARCH",60,8,8, typeof(jylink_guide_param_search)),
        new jy_message_info(0xA6,"LOITER_PARAM_DOWN",60,21,21, typeof(jylink_loiter_param_down)),
        new jy_message_info(0x06,"LOITER_PARAM_SETUP",60,21,21, typeof(jylink_loiter_param_setup)),
        new jy_message_info(0x56,"LOITER_PARAM_SEARCH",60,8,8, typeof(jylink_loiter_param_search)),
        new jy_message_info(0xA7,"LIMIT_PARAM_DOWN",60,52,52, typeof(jylink_limit_param_down)),
        new jy_message_info(0x07,"LIMIT_PARAM_SETUP",60,52,52, typeof(jylink_limit_param_setup)),
        new jy_message_info(0x57,"LIMIT_PARAM_SEARCH",60,8,8, typeof(jylink_limit_param_search)),
        new jy_message_info(0xA8,"STEERTRIM_PARAM_DOWN",60,24,24, typeof(jylink_steertrim_param_down)),
        new jy_message_info(0x08,"STEERTRIM_PARAM_SETUP",60,24,24, typeof(jylink_steertrim_param_setup)),
        new jy_message_info(0x58,"STEERTRIM_PARAM_SEARCH",60,8,8, typeof(jylink_steertrim_param_search)),
        new jy_message_info(0x65,"HOME_LOCATION_SEARCH",60,8,8, typeof(jylink_home_location_down_search)),
        new jy_message_info(0xB5,"HOME_LOCATION_DOWN",60,20,20, typeof(jylink_home_location_down)),

        new jy_message_info(0x22,"MAINCTRL_CMD_SETUP",60,8,8, typeof(jylink_mainctrl_command_setup)),
        new jy_message_info(0x0F,"MISSION_WAYPOINT_UP",60,50,50, typeof(jylink_mission_item)),
        new jy_message_info(0xaC,"MISSION_WAYPOINT_DOWN",60,50,50, typeof(jylink_mission_item)),

        new jy_message_info(0x59,"MISSION_SEARCH",60,2,2, typeof(jylink_mission_search)),
        new jy_message_info(0x09,"FLIGHT_MODE_SETUP",60,2,2, typeof(jylink_flightmode_setup)),
        new jy_message_info(0xB6,"SATLATE_STATUS",60,82,82, typeof(Satlate_status)),
        new jy_message_info(0x66,"SATELLITE_STATUS",60,1,1, typeof(jylink_satellite_search)),
        new jy_message_info(0x20,"MISSION_UPLOAD",60,37,37, typeof(jylink_mission_upload)),

        new jy_message_info(0x0A,"AIRSPEED_BALT_CAL",60,8,8, typeof(jylink_airspeed_balt_cal)),
        new jy_message_info(0x0B,"SYSTEM_SELF_CHECK",60,8,8, typeof(jylink_system_self_check)),
        new jy_message_info(0x21,"LINK_TEST",60,11,11, typeof(jylink_link_test)), 

        new jy_message_info(0x17,"HIGHT_SETUP",60,8,8, typeof(jylink_hight_setup)), 
        new jy_message_info(0x62,"HIGHT_SEARCH",60,8,8, typeof(jylink_hight_search)), 

        new jy_message_info(0x00,"STEER_TEST",60,8,8, typeof(jylink_steer_test)), 
        new jy_message_info(0x00,"ECU_SETUP",60,11,11, typeof(jylink_ecu_setup)), 
        new jy_message_info(0x00,"CTRLPOLARITY_TEST",60,9,9, typeof(jylink_ctrlpolarity_test)),
        new jy_message_info(0x00,"STEER_CAC_SETUP",60,25,25, typeof(jylink_steer_cac_setup)),
        new jy_message_info(0x00,"STEER_SET_SEARCH",60,8,8, typeof(jylink_steer_cac_param_search)),
        new jy_message_info(0x00,"STEER_SET_DOWN",60,25,25, typeof(jylink_steer_cac_param_down)),
        new jy_message_info(0xB7, "STATUS_DOWN", 60,58,58, typeof( jylink_status_down )),

        new jy_message_info(0xB8,"IMU_PARAM_DOWN",60,128,128, typeof(jylink_imu_param_down)),
        new jy_message_info(0x23,"IMU_PARAM_SETUP",60,128,128, typeof(jylink_imu_param_setup)),
        new jy_message_info(0x67,"IMU_PARAM_SEARCH",60,8,8, typeof(jylink_imu_param_search)),
        
        new jy_message_info(0x24,"Warship_Change",60,13,13, typeof(Warship_change)),
        new jy_message_info(0x25,"Warship_Home_Up",60,28,28, typeof(Warship_home_location_up)),
              
        new jy_message_info(0x39,"Duoji_PARAM_SETUP",60,9,9, typeof(jylink_duoji_param_setup)), 
 
        new jy_message_info(0x3A,"PLANEID_PARAM_SETUP",60,12,12, typeof(jylink_planeID_param_set)), 
        new jy_message_info(0x3B,"BD_PLANEID_PARAM_SETUP",60,14,14, typeof(jylink_bd_planeID_param_set)), 
        new jy_message_info(0x3C,"BD_CONTROL_PARAM_SETUP",60,14,14, typeof(jylink_bd_control_param_set)), 
        new jy_message_info(0xCC,"PLANEID_PARAM_DOWN",60,4,4, typeof(jylink_planeID_param_down)), 
        new jy_message_info(0xCD,"BD_PLANEID_PARAM_DOWN",60,14,14, typeof(jylink_bd_planeID_param_down)), 
        new jy_message_info(0xCE,"BD_CONTROL_PARAM_DOWN",60,48,48, typeof(jylink_bd_control_param_down)), 

        new jy_message_info(0x7C,"PLANEID_PARAM_SEARCH",60,8,8, typeof(jylink_planeID_param_search)), 
        new jy_message_info(0x7D,"BD_PLANEID_PARAM_SEARCH",60,8,8, typeof(jylink_bd_planeID_param_search)), 
        new jy_message_info(0x7E,"BD_CONTROL_PARAM_SEARCH",60,8,8, typeof(jylink_bd_control_param_search)), 
        new jy_message_info(0x16,"FANGZHEN_SET",60,17,17, typeof(jylink_fangzhe_set)), 
      
        new jy_message_info(0xAA,"ENGINE_PARAM_DOWN",60,9,9, typeof(jylink_engine_param_down)),  
        new jy_message_info(0x0D,"ENGINE_PARAM_SETUP",60,9,9, typeof(jylink_engine_param_setup)),  
        new jy_message_info(0x5A,"ENGINE_PARAM_SEARCH",60,8,8, typeof(jylink_engine_param_search)),
        new jy_message_info(0x40,"FLYTONEXTPOINT_SET",60,9,9, typeof(jylink_to_nextpoint_set)), 

        new jy_message_info(0xB1,"BANDWIDTH_PARAM_DOWN",60,11,11, typeof(jylink_bandwidth_param_down)),  
        new jy_message_info(0x14,"BANDWIDTH_PARAM_SETUP",60,11,11, typeof(jylink_bandwidth_param_setup)),  
        new jy_message_info(0x61,"BANDWIDTH_PARAM_SEARCH",60,8,8, typeof(jylink_bandwidth_param_search)),

        new jy_message_info(0xB2,"GMODE_PARAM_DOWN",60,11,11, typeof(jylink_gmode_param_down)),  
        new jy_message_info(0x15,"GMODE_PARAM_SETUP",60,11,11, typeof(jylink_gmode_param_setup)),  
        new jy_message_info(0x62,"GMODE_PARAM_SEARCH",60,8,8, typeof(jylink_gmode_param_search)),

        new jy_message_info(0xAB,"TUOLUO_PARAM_DOWN",60,26,26, typeof(jylink_tuoluo_param_down)),  
        new jy_message_info(0x0E,"TUOLUO_PARAM_SETUP",60,8,8, typeof(jylink_tuoluo_param_setup)),  
        //new jy_message_info(0x62,"TUOLUO_PARAM_SEARCH",60,8,8, typeof(jylink_tuoluo_param_search)),
        new jy_message_info(0xC7,"Micro_STATUS_PARAM_DOWN",60,24,24, typeof(jylink_Micro_status_down)),
        new jy_message_info(0xC8,"Micro_PARAM_DOWN",60,42,42, typeof(jylink_Micro_param_down)),
        new jy_message_info(0x34,"Micro_PARAM_SETUP",60,42,42, typeof(jylink_Micro_param_setup)),
        new jy_message_info(0x76,"Micro_PARAM_SEARCH",60,8,8, typeof(jylink_Micro_param_search)),  

        new jy_message_info(0x35,"Kdj_PARAM_SETUP",60,9,9, typeof(jylink_Micro_position_setup)),
        new jy_message_info(0x77,"Micro_STATUS_PARAM_SEARCH",60,8,8, typeof(jylink_status_Micro_param_search)),
        new jy_message_info(0x50,"Micro_XB_STATUS",60,19,19, typeof(jylink_xb_status_down)),

        new jy_message_info(0x44,"Grj_PARAM_SETUP",60,10,10, typeof(jylink_Grj_setup)),
        new jy_message_info(0xD4,"Grj_PARAM_DOWN",60,35,35, typeof(jylink_Grj_down)),
        new jy_message_info(0xBB,"KONGYU_PARAM_DOWN",60,77,77, typeof(jylink_kongyu_param)),  
        new jy_message_info(0x28,"KONGYU_PARAM_SETUP",60,77,77, typeof(jylink_kongyu_param)),  
        new jy_message_info(0x6A,"KONGYU_PARAM_SEARCH",60,8,8, typeof(jylink_kongyu_param_search)),
        new jy_message_info(0x3D,"BIANDUI_MODE_SET",60,1,1, typeof(jylink_biandui_mode_setup)),
        new jy_message_info(0xBC,"ZHENGHE_PARAM_DOWN",60,12,12, typeof(jylink_zhenghe_param)),  
        new jy_message_info(0x29,"ZHENGHE_PARAM_SETUP",60,12,12, typeof(jylink_zhenghe_param)),  
        new jy_message_info(0x6B,"ZHENGHE_PARAM_SEARCH",60,8,8, typeof(jylink_zhenghe_param_search)),

        new jy_message_info(0x1A,"YOUMEN_MODE_SET",60,1,1, typeof(jylink_youmen_mode_setup)),
        new jy_message_info(0x36,"BIANHAO_SET",60,1,1, typeof(jylink_bianhao_setup)),
        new jy_message_info(0x79,"BIANHAO_Ser",60,8,8, typeof(jylink_bianhao_ser)),
        new jy_message_info(0xC9,"BIANHAO_Down",60,1,1, typeof(jylink_bianhao_setup)),
    };

    public struct jy_message_info
    {
        public uint msgid { get; internal set; }
        public string name { get; internal set; }
        public byte crc { get; internal set; }
        public uint minlength { get; internal set; }
        public uint length { get; internal set; }
        public Type type { get; internal set; }


        public jy_message_info(uint msgid, string name, byte crc, uint minlength, uint length, Type type)
            : this()
        {
            this.msgid = msgid;
            this.name = name;
            this.crc = crc;
            this.minlength = minlength;
            this.length = length;
            this.type = type;


        }
        public override string ToString()
        {
            return String.Format("{0} - {1}", name, msgid);
        }
    }
    //����ö������
    public enum SERIAL_CONTROL_DEV
    {
        ///<summary> First telemetry port | </summary>
        TELEM1 = 0,
        ///<summary> Second telemetry port | </summary>
        TELEM2 = 1,
        ///<summary> First GPS port | </summary>
        GPS1 = 2,
        ///<summary> Second GPS port | </summary>
        GPS2 = 3,
        ///<summary> system shell | </summary>
        SHELL = 10,
        ///<summary>  | </summary>
        ENUM_END = 11,

    };
    public enum JY_POWER_STATUS
    {
        ///<summary> main brick power supply valid | </summary>
        BRICK_VALID = 1,
        ///<summary> main servo power supply valid for FMU | </summary>
        SERVO_VALID = 2,
        ///<summary> USB power is connected | </summary>
        USB_CONNECTED = 4,
        ///<summary> peripheral supply is in over-current state | </summary>
        PERIPH_OVERCURRENT = 8,
        ///<summary> hi-power peripheral supply is in over-current state | </summary>
        PERIPH_HIPOWER_OVERCURRENT = 16,
        ///<summary> Power status has changed since boot | </summary>
        CHANGED = 32,
        ///<summary>  | </summary>
        ENUM_END = 33,

    };
    //����ɿ���ϢID

    public enum JYLINK_MSG_ID
    {
        STATUS_PARAM_DOWN = 0xA0,
        STATUS_DOWN = 0xB7,
        Warship_Change = 0x24,
        Warship_Home_Up = 0x25,
        STEER_TEST = 0x00,
        ECU_SETUP = 0x00,
        CTRLPOLARITY_TEST = 0x00,
        STEER_CAC_SETUP = 0x00,
        STEER_SET_SEARCH = 0x00,
        STEER_SET_DOWN = 0x00,
        UNKNOW_MESSAGE_DOWN = 0x00,
        ATTITUDELOOP_PARAM_SETUP = 0x01,
        OVERLOADLOOP_PARAM_SETUP = 0x02,
        GUIDECTRL_PARAM_SETUP = 0x03,
        TAKEOFF_PARAM_SETUP = 0x04,
        GUIDE_PARAM_SETUP = 0x05,
        LOITER_PARAM_SETUP = 0x06,
        LIMIT_PARAM_SETUP = 0x07,
        STEERTRIM_PARAM_SETUP = 0x08,
        FLIGHT_MODE_SETUP = 0x09,
        AIRSPEED_BALT_CAL = 0x0A,
        SYSTEM_SELF_CHECK = 0x0B,
        MISSION_ITEM_UP = 0x0F,
        MISSION_UPLOAD = 0x20,
        LINK_TEST = 0x21,
        MAINCTRL_CMD_SETUP = 0x22,
        HIGHT_SETUP = 0x17,
        HIGHT_SEARCH = 0x62,
        ATTITUDELOOP_PARAM_SEARCH = 0x51,
        OVERLOADLOOP_PARAM_SEARCH = 0x52,
        GUIDECTRL_PARAM_SEARCH = 0x53,
        TAKEOFF_PARAM_SEARCH = 0x54,
        GUIDE_PARAM_SEARCH = 0x55,
        LOITER_PARAM_SEARCH = 0x56,
        LIMIT_PARAM_SEARCH = 0x57,
        STEERTRIM_PARAM_SEARCH = 0x58,
        MISSION_SEARCH = 0x5C,
        HOME_LOCATION_SEARCH = 0x65,
        SATELLITE_STATUS = 0x66,
        SATLATE_STATUS = 0xB6,
        ATTITUDELOOP_PARAM_DOWN = 0xA1,
        OVERLOADLOOP_PARAM_DOWN = 0xA2,
        GUIDECTRL_PARAM_DOWN = 0xA3,
        TAKEOFF_PARAM_DOWN = 0xA4,
        GUIDE_PARAM_DOWN = 0xA5,
        LOITER_PARAM_DOWN = 0xA6,
        LIMIT_PARAM_DOWN = 0xA7,
        STEERTRIM_PARAM_DOWN = 0xA8,
        MISSION_ITEM_DOWN = 0xAC,
        HOME_LOCATION_DOWN = 0xB5,
        IMU_PARAM_SETUP = 0x23,
        IMU_PARAM_SEARCH = 0x67,
        IMU_PARAM_DOWN = 0xB8,
        Duoji_PARAM_SETUP = 0x39,
        PLANEID_PARAM_SETUP = 0x3A,
        BD_PLANEID_PARAM_SETUP = 0x3B,
        BD_CONTROL_PARAM_SETUP = 0x3C,
        PLANEID_PARAM_DOWN = 0xCC,
        BD_PLANEID_PARAM_DOWN = 0xCD,
        BD_CONTROL_PARAM_DOWN = 0xCE,
        PLANEID_PARAM_SEARCH = 0x7C,
        BD_PLANEID_PARAM_SEARCH = 0x7D,
        BD_CONTROL_PARAM_SEARCH = 0x7E,
        FANGZHEN_SET = 0x16,
        ENGINE_PARAM_DOWN = 0xAA,
        ENGINE_PARAM_SETUP = 0x0D,
        ENGINE_PARAM_SEARCH = 0x5A,
        FLYTONEXTPOINT_SET = 0x40,

        BANDWIDTH_PARAM_DOWN = 0xB1,
        BANDWIDTH_PARAM_SETUP = 0x14,
        BANDWIDTH_PARAM_SEARCH = 0x61,
        GMODE_PARAM_DOWN = 0xB2,
        GMODE_PARAM_SETUP = 0x15,
        GMODE_PARAM_SEARCH = 0x62,

        TUOLUO_PARAM_DOWN = 0xAB,
        TUOLUO_PARAM_SETUP = 0x0E,
        Micro_PARAM_SETUP = 0x34,
        Kdj_PARAM_SETUP = 0x35,
        Micro_PARAM_SEARCH = 0x76,
        Micro_PARAM_DOWN = 0xC8,
        Micro_STATUS_PARAM_DOWN = 0xC7,
        Micro_STATUS_PARAM_SEARCH = 0x77,
        Micro_XB_STATUS = 0x50,
        Grj_PARAM_SETUP=0x44,
        Grj_PARAM_DOWN=0xD4,
        KONGYU_PARAM_DOWN = 0xBB,
        KONGYU_PARAM_SETUP = 0x28,
        KONGYU_PARAM_SEARCH = 0x6A,
        BIANDUI_MODE_SET = 0x3D,
        ZHENGHE_PARAM_DOWN = 0xBC,
        ZHENGHE_PARAM_SETUP = 0x29,
        ZHENGHE_PARAM_SEARCH = 0x6B,
        YOUMEN_MODE_SET = 0x1A,
        BIANHAO_SET = 0x36,
        BIANHAO_Ser = 0x79,
        BIANHAO_Down = 0xC9,
    }
    //������ID
    public enum JY_COMPONENT
    {
        JY_MISSION_PLANNER = 1,
    }
    //����ɱ������Ϣ
    public enum JY_CHANGEDSIZE_MSG_ID
    {
        JY_WP_UP = 0xBD,
        JY_WP_DOWN = 0xA5
    }


    //����ָ��
    public enum JY_TASK_ID
    {
        Mode = 0x01, //�л�ģʽ
        Target = 0x02, //��Ŀ������
        Umbrella = 0x03, //��ɡ
        TakeOff = 0x04, //���
        Return_To_Launch = 0x05, //һ������
        Land = 0x06, //һ������

    }

    public enum JY_STEERING_ID
    {
        ���� = 0x01,
        �Ҹ��� = 0x02,
        ������ = 0x03,
        ������ = 0x04,
        ����� = 0x05,
        �ҽ��� = 0x06,
        ���� = 0x07,
        ���� = 0x08,

    }
    public enum JY_PWM_ID
    {
        PWM1 = 0x01,
        PWM2 = 0x02,
        PWM3 = 0x03,
        PWM4 = 0x04,
        PWM5 = 0x05,
        PWM6 = 0x06,
        PWM7 = 0x07,
        PWM8 = 0x08,

    }
    //��������
    public enum JY_LOITERDIR_ID
    {
        //˳ʱ��01H
        //��ʱ��02H
        Clockwise = 0x01,
        AntiClockwise = 0x02

    }
    public enum JY_EcuDir_ID
    {
        /*�� (01H)
            ��� (02H)
            ����CHOKE (03H)
            ת�� (04H)
            Ϩ�� (05H)
        */


        Pump = 0x01,
        Ignition = 0x02,
        OilAbsorption = 0x03,
        Speed = 0x04,
        Flameout = 0x05


    }
    public enum JY_TakeOffDIR_ID
    {
        //�������00H
        //�������01H
        //�������02H
        PlanningRun = 0x00,
        Ejection = 0x01,
        RocketAssisted = 0x02
    }
    //����ģʽ

    public enum JY_SteerAction_ID
    {
        //�ɻ�̧ͷ 0x00
        //�ɻ���ͷ 0x01
        //�ɻ����� 0x02
        //�ɻ��Һ�� 0x03
        Rise = 0x00,
        Bow = 0x01,
        LeftRoll = 0x02,
        RightRoll = 0x03

    }
    public enum JY_FLIGHTMODE_ID
    {
        Manual = 0x01, //�ֶ����Ʒɻ�
        Stabilize = 0x00, //����ģʽ
        Alt_Hold = 0x02, //���߷���ģʽ  �ֶ��������ţ��ɿؽ��и߶Ⱥͺ��򱣳�
        Loiter = 0x04, //��������  ������ԲȦ���У��뾶���������뾶����
        Longitudinal = 0x08, //���߶���ģʽ  �ɿ��Զ����Ƹ߶ȡ��ٶ�(����)��������Զ����Զ��1Km��Ŀ�� (��ͷ����)
        Guided = 0x10, //��������  ���ݵ���վ�ĺ����ļ������е������У�����λ�ú󶨵���Բ
        RTL = 0x20, //�Զ�����ģʽ  �Զ�����ģʽ
        Mot_ContinueRoll = 0x42, //����ģʽ  �������
        Mot_AnglePitch = 0x44, //����ģʽ  ��Ƕȸ���
        Mot_LevelTurn = 0x48, //����ģʽ  ˮƽת��
        Mot_YMM_Motorized = 0x50, //����ģʽ  Ӣ��������
        Mot_Loop = 0x60, //����ģʽ  �
        Auto = 0x80 //�Զ�ģʽ  ����Զ���ɡ��������������С��������к��Զ�����
    }
    //��������
    public enum JY_PARAM_TYPE
    {
        ///<summary> 8-bit unsigned integer | </summary>
        UINT8 = 1,
        ///<summary> 8-bit signed integer | </summary>
        INT8 = 2,
        ///<summary> 16-bit unsigned integer | </summary>
        UINT16 = 3,
        ///<summary> 16-bit signed integer | </summary>
        INT16 = 4,
        ///<summary> 32-bit unsigned integer | </summary>
        UINT32 = 5,
        ///<summary> 32-bit signed integer | </summary>
        INT32 = 6,
        ///<summary> 64-bit unsigned integer | </summary>
        UINT64 = 7,
        ///<summary> 64-bit signed integer | </summary>
        INT64 = 8,
        ///<summary> 32-bit floating-point | </summary>
        REAL32 = 9,
        ///<summary> 64-bit floating-point | </summary>
        REAL64 = 10,
        ///<summary>  | </summary>
        ENUM_END = 11,

    };
    public enum JY_FRAME
    {
        ///<summary> Global coordinate frame, WGS84 coordinate system. First value / x: latitude, second value / y: longitude, third value / z: positive altitude over mean sea level (MSL) | </summary>
        GLOBAL = 0,
        ///<summary> Local coordinate frame, Z-up (x: north, y: east, z: down). | </summary>
        LOCAL_NED = 1,
        ///<summary> NOT a coordinate frame, indicates a mission command. | </summary>
        MISSION = 2,
        ///<summary> Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. First value / x: latitude, second value / y: longitude, third value / z: positive altitude with 0 being at the altitude of the home location. | </summary>
        GLOBAL_RELATIVE_ALT = 3,
        ///<summary> Local coordinate frame, Z-down (x: east, y: north, z: up) | </summary>
        LOCAL_ENU = 4,
        ///<summary> Global coordinate frame, WGS84 coordinate system. First value / x: latitude in degrees*1.0e-7, second value / y: longitude in degrees*1.0e-7, third value / z: positive altitude over mean sea level (MSL) | </summary>
        GLOBAL_INT = 5,
        ///<summary> Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude with 0 being at the altitude of the home location. | </summary>
        GLOBAL_RELATIVE_ALT_INT = 6,
        ///<summary> Offset to the current local frame. Anything expressed in this frame should be added to the current local frame position. | </summary>
        LOCAL_OFFSET_NED = 7,
        ///<summary> Setpoint in body NED frame. This makes sense if all position control is externalized - e.g. useful to command 2 m/s^2 acceleration to the right. | </summary>
        BODY_NED = 8,
        ///<summary> Offset in body NED frame. This makes sense if adding setpoints to the current flight path, to avoid an obstacle - e.g. useful to command 2 m/s^2 acceleration to the east. | </summary>
        BODY_OFFSET_NED = 9,
        ///<summary> Global coordinate frame with above terrain level altitude. WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. First value / x: latitude in degrees, second value / y: longitude in degrees, third value / z: positive altitude in meters with 0 being at ground level in terrain model. | </summary>
        GLOBAL_TERRAIN_ALT = 10,
        ///<summary> Global coordinate frame with above terrain level altitude. WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude in meters with 0 being at ground level in terrain model. | </summary>
        GLOBAL_TERRAIN_ALT_INT = 11,
        ///<summary>  | </summary>
        ENUM_END = 12,

    };
    public enum JY_CMD
    {
        WAYPOINT = 1,
        TAKEOFF = 2,
        LAND = 3,
        JUMP = 4,
        LAST = 5
    };
    public enum JY_TYPE
    {
        ///<summary> Generic micro air vehicle. | </summary>
        GENERIC = 0,
        ///<summary> Fixed wing aircraft. | </summary>
        FIXED_WING = 1,
        ///<summary> Quadrotor | </summary>
        QUADROTOR = 2,
        ///<summary> Coaxial helicopter | </summary>
        COAXIAL = 3,
        ///<summary> Normal helicopter with tail rotor. | </summary>
        HELICOPTER = 4,
        ///<summary> Ground installation | </summary>
        ANTENNA_TRACKER = 5,
        ///<summary> Operator control unit / ground control station | </summary>
        GCS = 6,
        ///<summary> Airship, controlled | </summary>
        AIRSHIP = 7,
        ///<summary> Free balloon, uncontrolled | </summary>
        FREE_BALLOON = 8,
        ///<summary> Rocket | </summary>
        ROCKET = 9,
        ///<summary> Ground rover | </summary>
        GROUND_ROVER = 10,
        ///<summary> Surface vessel, boat, ship | </summary>
        SURFACE_BOAT = 11,
        ///<summary> Submarine | </summary>
        SUBMARINE = 12,
        ///<summary> Hexarotor | </summary>
        HEXAROTOR = 13,
        ///<summary> Octorotor | </summary>
        OCTOROTOR = 14,
        ///<summary> Octorotor | </summary>
        TRICOPTER = 15,
        ///<summary> Flapping wing | </summary>
        FLAPPING_WING = 16,
        ///<summary> Flapping wing | </summary>
        KITE = 17,
        ///<summary> Onboard companion controller | </summary>
        ONBOARD_CONTROLLER = 18,
        ///<summary> Two-rotor VTOL using control surfaces in vertical operation in addition. Tailsitter. | </summary>
        VTOL_DUOROTOR = 19,
        ///<summary> Quad-rotor VTOL using a V-shaped quad config in vertical operation. Tailsitter. | </summary>
        VTOL_QUADROTOR = 20,
        ///<summary> Tiltrotor VTOL | </summary>
        VTOL_TILTROTOR = 21,
        ///<summary> VTOL reserved 2 | </summary>
        VTOL_RESERVED2 = 22,
        ///<summary> VTOL reserved 3 | </summary>
        VTOL_RESERVED3 = 23,
        ///<summary> VTOL reserved 4 | </summary>
        VTOL_RESERVED4 = 24,
        ///<summary> VTOL reserved 5 | </summary>
        VTOL_RESERVED5 = 25,
        ///<summary> Onboard gimbal | </summary>
        GIMBAL = 26,
        ///<summary> Onboard ADSB peripheral | </summary>
        ADSB = 27,
        ///<summary>  | </summary>
        ENUM_END = 28,

    };
    ///<summary> result in a mavlink mission ack </summary>
    public enum JY_MISSION_RESULT
    {
        ///<summary> mission accepted OK | </summary>
        JY_MISSION_ACCEPTED = 0,
        ///<summary> generic error / not accepting mission commands at all right now | </summary>
        JY_MISSION_ERROR = 1,
        ///<summary> one of the parameters has an invalid value | </summary>
        JY_MISSION_INVALID = 5,
        ///<summary>  | </summary>
        ENUM_END = 15,

    };
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_unknow_messsage
    {

    }
    //״̬�����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 62)]
    public struct jylink_status_param_down
    {
        /// <summary> �����</summary>
        public UInt32 second_count;
        /// <summary> ����ģʽ</summary>
        public byte youmen_mode;
        /// <summary> �����ѹ</summary>
        public byte duoji_v;
        /// <summary> ����</summary>
        public UInt16 beiyong; 
        /// <summary> ��ϸ߶�</summary>
        public Single zuhe_altitude;
        /// <summary> �߶�set</summary>
        public Int16 hight_set;
        /// <summary> ��ѹ�߶�</summary>
        public Int16 air_altitude;
        /// <summary> ���ߵ�߶ȱ�߶�</summary>
        public UInt16 altitude;
        /// <summary> RPM </summary>
        public UInt16 rpm;
        /// <summary> ECU��ѹ*10</summary>
        public UInt16 ecu_voltage1;
        /// <summary>����</summary>
        public UInt16 ecu_throttle;
        /// <summary>�¶�</summary>
        public Int16 ecu_pw;
        /// <summary>������</summary>
        public byte ecu_errorno;
        /// <summary>ʱ</summary>
        public byte time_h;
        /// <summary>��</summary>
        public byte time_m;
        /// <summary>��</summary>
        public byte time_s;
        /// <summary>����</summary>
        public byte sateliter;
        /// <summary> ��λ״̬</summary>
        public byte position_state;
        /// <summary> �ɿ�ģʽ</summary>
        public byte flightcontrol_mode;
        /// <summary> ���н׶�</summary>
        public byte flightcontrol_progrom;
        /// <summary> ��������</summary>       
        public byte control_youmen;
        /// <summary> ң��ָ��</summary>       
        public byte tele_command;
        /// <summary> ʧ��ģʽ</summar y>
        public byte loss_connect;
        /// <summary> �ɿص�ѹ*10</summary>
        public UInt16 flightcontrol_voltage;
        /// <summary> �������</summary>
        public byte waypoint_id;
        /// <summary> ����һ�������</summary>
        public UInt16 distance_to_nextwaypoint;
        /// <summary> ��Ҿ���</summary>
        public UInt16 distance_to_home;
        public float gnss_lng;
        public float gnss_lat;
        public float gnss_alt;
        public Int16 gnss_east;
        public Int16 gnss_north;
        public Int16 gnss_sky;

    };
    //��̬��������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_get_ack
    {

    }
    //��̬�������´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
    public struct jylink_attitudeloop_param_down
    {
        /// <summary> ��תKp</summary>
        public Single roll_kp;
        /// <summary> ��תKi</summary>
        public Single roll_ki;
        /// <summary> ��תKd</summary>
        public Single roll_kd;
        /// <summary> Ԥ��1</summary>
        public Single attitudeloop_remaind1;
        /// <summary> ����Kp</summary>
        public Single pitch_kp;
        /// <summary> ����Ki</summary>
        public Single pitch_ki;
        /// <summary> ����Kd</summary>
        public Single pitch_kd;
        /// <summary> Ԥ��2</summary>
        public Single attitudeloop_remaind2;
        /// <summary> ƫ��Kp</summary>
        public Single heading_offset_kp;
        /// <summary> ƫ��Ki</summary>
        public Single heading_offset_ki;
        /// <summary> ƫ��Kd</summary>
        public Single heading_offset_kd;

        /// <summary> Ԥ��3</summary>
        public Single attitudeloop_remaind3;
    }

    //��̬����������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
    public struct jylink_attitudeloop_param_setup
    {
        /// <summary> ��תKp</summary>
        public Single roll_kp;
        /// <summary> ��תKi</summary>
        public Single roll_ki;
        /// <summary> ��תKd</summary>
        public Single roll_kd;
        /// <summary> Ԥ��1</summary>
        public Single remaind1;
        /// <summary> ����Kp</summary>
        public Single pitch_kp;
        /// <summary> ����Ki</summary>
        public Single pitch_ki;
        /// <summary> ����Kd</summary>
        public Single pitch_kd;
        /// <summary> Ԥ��2</summary>
        public Single remaind2;
        /// <summary> ƫ��Kp</summary>
        public Single heading_offset_kp;
        /// <summary> ƫ��Ki</summary>
        public Single heading_offset_ki;
        /// <summary> ƫ��Kd</summary>
        public Single heading_offset_kd;
        /// <summary> Ԥ��3</summary>
        public Single remaind3;
    }
    //��̬��������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_attitudeloop_param_search
    {

    }
    //��ͨ����ָ���ϴ�
    //��ͨ����ָ���ϴ�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
    public struct jylink_mission_item
    {
        /// <summary> �������</summary>
        public byte num;
        /// <summary> �������</summary>
        public byte count;
        /// <summary> �������</summary> 
        public byte seq;
        /// <summary> ����ָ��</summary>
        public byte cmd;
        /// <summary> �߶�</summary>
        public Single altitude;
        /// <summary> ����</summary>
        public Int32 longitude;
        /// <summary> γ��</summary>
        public Int32 latitude;
        /// <summary> ����1</summary>    
        public UInt16 param1;
        /// <summary> ����2</summary>
        public UInt16 param2;
        /// <summary> ����3</summary>
        public UInt16 param3;
        /// <summary> ����4</summary>
        public UInt16 param4;
    }
    //���ػ�������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_overloadloop_param_search
    {

    }
    //���ػ������´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
    public struct jylink_overloadloop_param_down
    {
        /// <summary> ǰ��Kp</summary>
        public Single head_kp;
        /// <summary> ǰ��Ki</summary>
        public Single head_ki;
        /// <summary> ǰ��Kd</summary>
        public Single head_kd;
        /// <summary> Ԥ��1</summary>
        public Single remaind1;
        /// <summary> ����Kp</summary>
        public Single side_kp;
        /// <summary> ����Ki</summary>
        public Single side_ki;
        /// <summary> ����Kd</summary>
        public Single side_kd;
        /// <summary> Ԥ��2</summary>
        public Single remaind2;
        /// <summary> ����Kp</summary>
        public Single up_kp;
        /// <summary> ����Ki</summary>
        public Single up_ki;
        /// <summary> ����Kd</summary>
        public Single up_kd;
        /// <summary> Ԥ��3</summary>
        public Single remaind3;
    }
    //���ػ���������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
    public struct jylink_overloadloop_param_setup
    {
        /// <summary> ǰ��Kp</summary>
        public Single head_kp;
        /// <summary> ǰ��Ki</summary>
        public Single head_ki;
        /// <summary> ǰ��Kd</summary>
        public Single head_kd;
        /// <summary> Ԥ��1</summary>
        public Single remaind1;
        /// <summary> ����Kp</summary>
        public Single side_kp;
        /// <summary> ����Ki</summary>
        public Single side_ki;
        /// <summary> ����Kd</summary>
        public Single side_kd;
        /// <summary> Ԥ��2</summary>
        public Single remaind2;
        /// <summary> ����Kp</summary>
        public Single up_kp;
        /// <summary> ����Ki</summary>
        public Single up_ki;
        /// <summary> ����Kd</summary>
        public Single up_kd;
        /// <summary> Ԥ��3</summary>
        public Single remaind3;

    }
    //�Ƶ�������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_guidectrl_param_search
    {

    }
    //�Ƶ������´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 108)]
    public struct jylink_guidectrl_param_down
    {
        /// <summary> ����Khead</summary>
        public Single khead;
        /// <summary> ����Kxt</summary>
        public Single kxt;
        /// <summary> ����Kc</summary>
        public Single kc;
        /// <summary> ����KR</summary>
        public Single kr;
        /// <summary> L1����������</summary>
        public Single l1guide_dr;
        /// <summary> L1��������</summary>
        public Single l1guide_p;
        /// <summary> L1��������������</summary>
        public Single l1guide_kig;
        /// <summary> ����ʱ�䳣��</summary>
        public Single throttle_t;
        /// <summary> ��������</summary>
        public Single throttle_d;
        /// <summary> ���Ż���</summary>
        public Single throttle_i;
        /// <summary> ����ת�䲹��</summary>
        public Single throttle_turn;
        /// <summary> ��������Ȩ��</summary>
        public Single pitch_kw;
        /// <summary> ��������ϵ��</summary>
        public Single pitch_i;
        /// <summary> ����ʱ�䳣��</summary>
        public Single pitch_t;
        /// <summary> ��������</summary>
        public Single pitch_d;
        /// <summary> �ٶȱ���ϵ��KSPD</summary>
        public Single kspd;
        /// <summary> �ٶȻ���ϵ��KSPDI</summary>
        public Single kspdi;
        /// <summary> �ٶ�΢��ϵ��KSPDD</summary>
        public Single kspdd;
        /// <summary> �߶ȱ���ϵ��KH</summary>
        public Single kh;
        /// <summary> �߶Ȼ���ϵ��KHI</summary>
        public Single khi;
        /// <summary> �߶�΢��ϵ��KHD</summary>
        public Single khd;
        /// <summary> �߶�����jfmx</summary>
        public Single jfmx;
        /// <summary> ���ܱ���ϵ��KPD</summary>
        public Single kpd;
        /// <summary> ���ܻ���ϵ��KID</summary>
        public Single kid;
        /// <summary> ����΢��ϵ��KDD</summary>
        public Single kdd;
    }
    //���ػ���������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 108)]
    public struct jylink_guidectrl_param_setup
    {
        /// <summary> ����Khead</summary>
        public Single khead;
        /// <summary> ����Kxt</summary>
        public Single kxt;
        /// <summary> ����Kc</summary>
        public Single kc;
        /// <summary> ����KR</summary>
        public Single kr;
        /// <summary> L1����������</summary>
        public Single l1guide_dr;
        /// <summary> L1��������</summary>
        public Single l1guide_p;
        /// <summary> L1��������������</summary>
        public Single l1guide_kig;
        /// <summary> ����ʱ�䳣��</summary>
        public Single throttle_t;
        /// <summary> ��������</summary>
        public Single throttle_d;
        /// <summary> ���Ż���</summary>
        public Single throttle_i;
        /// <summary> ����ת�䲹��</summary>
        public Single throttle_turn;
        /// <summary> ��������Ȩ��</summary>
        public Single pitch_kw;
        /// <summary> ��������ϵ��</summary>
        public Single pitch_i;
        /// <summary> ����ʱ�䳣��</summary>
        public Single pitch_t;
        /// <summary> ��������</summary>
        public Single pitch_d;
        /// <summary> �ٶȱ���ϵ��KSPD</summary>
        public Single kspd;
        /// <summary> �ٶȻ���ϵ��KSPDI</summary>
        public Single kspdi;
        /// <summary> �ٶ�΢��ϵ��KSPDD</summary>
        public Single kspdd;
        /// <summary> �߶ȱ���ϵ��KH</summary>
        public Single kh;
        /// <summary> �߶Ȼ���ϵ��KHI</summary>
        public Single khi;
        /// <summary> �߶�΢��ϵ��KHD</summary>
        public Single khd;
        /// <summary> �߶�����jfmx</summary>
        public Single jfmx;
        /// <summary> ���ܱ���ϵ��KPD</summary>
        public Single kpd;
        /// <summary> ���ܻ���ϵ��KID</summary>
        public Single kid;
        /// <summary> ����΢��ϵ��KDD</summary>
        public Single kdd;
    }
    //��ɲ�����ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_takeoff_param_search
    {

    }
    //��ɲ����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
    public struct jylink_takeoff_param_down
    {
        /// <summary> �������</summary>
        public byte takeoff_type;
        /// <summary> ���ƫת��</summary>
        public Single takeoff_offset;
        /// <summary> �������</summary>
        public Single lift_pull;
        /// <summary> ���˹���ʱ��</summary>
        public Single pull_time;
        /// <summary> ����߶�</summary>
        public Single pull_alt;
        /// <summary> �����ٶ�</summary>
        public Single vspeed;

    }
    //��ɲ�������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
    public struct jylink_takeoff_param_setup
    {
        /// <summary> �������</summary>
        public byte takeoff_type;
        /// <summary> ���ƫת��</summary>
        public Single takeoff_offset;
        /// <summary> �������</summary>
        public Single lift_pull;
        /// <summary> ���˹���ʱ��</summary>
        public Single pull_time;
        /// <summary> ����߶�</summary>
        public Single pull_alt;
        /// <summary> �����ٶ�</summary>
        public Single vspeed;
    }
    //����������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_guide_param_search
    {

    }
    //���������´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 20)]
    public struct jylink_guide_param_down
    {
        /// <summary> ���и߶�</summary>
        public Single alt;
        /// <summary> �����ٶ�</summary>
        public Single speed;
        /// <summary> ���к���</summary>
        public Single heading;

    }
    //������������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 20)]
    public struct jylink_guide_param_setup
    {
        /// <summary> ���и߶�</summary>
        public Single alt;
        /// <summary> �����ٶ�</summary>
        public Single speed;
        /// <summary> ���к���</summary>
        public Single heading;
    }
    //����������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_loiter_param_search
    {

    }
    //���������´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
    public struct jylink_loiter_param_down
    {
        /// <summary> �����뾶</summary>
        public Single loiter_radius;
        /// <summary> ԭ�����꾭��</summary>
        public Double op_lng;
        /// <summary> ԭ������γ��</summary>
        public Double op_lat;
        /// <summary> ��������</summary>
        public byte loiter_dir;

    }
    //������������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
    public struct jylink_loiter_param_setup
    {
        /// <summary> �����뾶</summary>
        public Single loiter_radius;
        /// <summary> ԭ�����꾭��</summary>
        public Double op_lng;
        /// <summary> ԭ������γ��</summary>
        public Double op_lat;
        /// <summary> ��������</summary>
        public byte loiter_dir;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 25)]
    public struct jylink_steer_cac_setup
    {
        /// <summary> ͨ����</summary>
        public byte channel_num;
        /// <summary> ���1����</summary>
        public byte channel1_name;
        /// <summary> ���1��ַ</summary>
        public byte channel1_addr;
        /// <summary> ���2����</summary>
        public byte channel2_name;
        /// <summary> ���2��ַ</summary>
        public byte channel2_addr;
        /// <summary> ���3����</summary>
        public byte channel3_name;
        /// <summary> ���3��ַ</summary>
        public byte channel3_addr;
        /// <summary> ���4����</summary>
        public byte channel4_name;
        /// <summary> ���4��ַ</summary>
        public byte channel4_addr;
        /// <summary> ���5����</summary>
        public byte channel5_name;
        /// <summary> ���5��ַ</summary>
        public byte channel5_addr;
        /// <summary> ���6����</summary>
        public byte channel6_name;
        /// <summary> ���6��ַ</summary>
        public byte channel6_addr;
        /// <summary> ���7����</summary>
        public byte channel7_name;
        /// <summary> ���7��ַ</summary>
        public byte channel7_addr;
        /// <summary> ���8����</summary>
        public byte channel8_name;
        /// <summary> ���8��ַ</summary>
        public byte channel8_addr;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
    public struct jylink_steer_cac_param_down
    {
        /// <summary> ͨ����</summary>
        public byte channel_num;
        /// <summary> ���1����</summary>
        public byte channel1_name;
        /// <summary> ���1��ַ</summary>
        public byte channel1_addr;
        /// <summary> ���2����</summary>
        public byte channel2_name;
        /// <summary> ���2��ַ</summary>
        public byte channel2_addr;
        /// <summary> ���3����</summary>
        public byte channel3_name;
        /// <summary> ���3��ַ</summary>
        public byte channel3_addr;
        /// <summary> ���4����</summary>
        public byte channel4_name;
        /// <summary> ���4��ַ</summary>
        public byte channel4_addr;
        /// <summary> ���5����</summary>
        public byte channel5_name;
        /// <summary> ���5��ַ</summary>
        public byte channel5_addr;
        /// <summary> ���6����</summary>
        public byte channel6_name;
        /// <summary> ���6��ַ</summary>
        public byte channel6_addr;
        /// <summary> ���7����</summary>
        public byte channel7_name;
        /// <summary> ���7��ַ</summary>
        public byte channel7_addr;
        /// <summary> ���8����</summary>
        public byte channel8_name;
        /// <summary> ���8��ַ</summary>
        public byte channel8_addr;

    }

    //���������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_steer_cac_param_search
    {

    }
    //���޲�����ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_limit_param_search
    {

    }
    //���޲����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 60)]
    public struct jylink_limit_param_down
    {
        /// <summary> �����޷�</summary>
        public Single aileron;
        /// <summary> �������޷�</summary>
        public Single elevator;
        /// <summary> ������޷�</summary>
        public Single rudder;
        /// <summary> ǰ���޷�</summary>
        public Single frontwheel;
        /// <summary> �������</summary>
        public Single max_throttle;
        /// <summary> ��С����</summary>
        public Single min_throttle;
        /// <summary> �������</summary>
        public Single max_pitch_angle;
        /// <summary> ��С������</summary>
        public Single min_pitch_angle;
        /// <summary> ��ת���޷�</summary>
        public Single roll_angle;
        /// <summary> ʧ���ٶ�</summary>
        public Single stall_speed;
        /// <summary> ������</summary>
        public Single max_airspeed;
        /// <summary> ���������</summary>
        public Single max_lateral_overload;
        /// <summary> Ԥ��</summary>
        public Single reserve;

    }
    //���޲�������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 60)]
    public struct jylink_limit_param_setup
    {
        /// <summary> �����޷�</summary>
        public Single aileron;
        /// <summary> �������޷�</summary>
        public Single elevator;
        /// <summary> ������޷�</summary>
        public Single rudder;
        /// <summary> ǰ���޷�</summary>
        public Single frontwheel;
        /// <summary> �������</summary>
        public Single max_throttle;
        /// <summary> ��С����</summary>
        public Single min_throttle;
        /// <summary> �������</summary>
        public Single max_pitch_angle;
        /// <summary> ��С������</summary>
        public Single min_pitch_angle;
        /// <summary> ��ת���޷�</summary>
        public Single roll_angle;
        /// <summary> ʧ���ٶ�</summary>
        public Single stall_speed;
        /// <summary> ������</summary>
        public Single max_airspeed;
        /// <summary> ���������</summary>
        public Single max_lateral_overload;
        /// <summary> Ԥ��</summary>
        public Single reserve;
    }
    //������ƽ������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_steertrim_param_search
    {

    }
    //������ƽ�����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 32)]
    public struct jylink_steertrim_param_down
    {
        /// <summary> ����</summary>
        public Int16 LeftAileron;
        /// <summary> ����ϵ��</summary>
        public Single LeftAileronRatio;
        /// <summary> �Ҹ���</summary>
        public Int16 RightAileron;
        /// <summary> �Ҹ���ϵ��</summary>
        public Single RightAileronRatio;
        /// <summary> ��β��</summary>
        public Int16 LeftTail;
        /// <summary> ��β��ϵ��</summary>
        public Single LeftTailRatio;
        /// <summary> ��β��</summary>
        public Int16 RightTail;
        /// <summary> ��β��ϵ��</summary>
        public Single RightTailRatio;

    }
    //������ƽ��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 32)]
    public struct jylink_steertrim_param_setup
    {
        /// <summary> ����</summary>
        public Int16 LeftAileron;
        /// <summary> ����ϵ��</summary>
        public Single LeftAileronRatio;
        /// <summary> �Ҹ���</summary>
        public Int16 RightAileron;
        /// <summary> �Ҹ���ϵ��</summary>
        public Single RightAileronRatio;
        /// <summary> ��β��</summary>
        public Int16 LeftTail;
        /// <summary> ��β��ϵ��</summary>
        public Single LeftTailRatio;
        /// <summary> ��β��</summary>
        public Int16 RightTail;
        /// <summary> ��β��ϵ��</summary>
        public Single RightTailRatio;

    }
    //���ٺ���ѹ�߶�У׼
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_airspeed_balt_cal
    {

    }
    //ϵͳ�Լ�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_system_self_check
    {

    }
    //�������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_steer_test
    {

    }
    //ECU
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 11)]
    public struct jylink_ecu_setup
    {
        /// <summary> ECU����</summary>
        public byte command;
        /// <summary> ����</summary>
        public UInt16 param;
    }
    //���Ƽ��Բ���
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_ctrlpolarity_test
    {
        /// <summary> �������λ</summary>
        public byte steer_action;

    }
    //��·����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 19)]
    public struct jylink_link_test
    {
        /// <summary> ���ͱ�־</summary>
        public byte send_flag;
        /// <summary> �̶����ݰ�1</summary>
        public byte data1;
        /// <summary> �̶����ݰ�2</summary>
        public byte data2;
        /// <summary> �̶����ݰ�3</summary>
        public byte data3;
        /// <summary> �̶����ݰ�4</summary>
        public byte data4;
        /// <summary> �̶����ݰ�5</summary>
        public byte data5;
        /// <summary> �̶����ݰ�6</summary>
        public byte data6;
        /// <summary> �̶����ݰ�7</summary>
        public byte data7;
        /// <summary> �̶����ݰ�8</summary>
        public byte data8;
        /// <summary> �̶����ݰ�9</summary>
        public byte data9;
        /// <summary> �̶����ݰ�10</summary>
        public byte data10;
    }
    //�����ϴ�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 45)]
    public struct jylink_mission_upload
    {
        /// <summary> ����ָ��ID</summary>
        public byte mission_id;
        /// <summary> ����1</summary>
        public UInt32 param1;
        /// <summary> ����2</summary>
        public UInt32 param2;
        /// <summary> ����3</summary>
        public UInt32 param3;
        /// <summary> ����4</summary>
        public UInt32 param4;
        /// <summary> ����5</summary>
        public UInt32 param5;
        /// <summary> ����6</summary>
        public UInt64 param6;
        /// <summary> ����7</summary>
        public UInt64 param7;

    }

    //���߲�ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
    public struct jylink_mission_search
    {
        public byte num;
        public byte seq;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_home_location_down_search
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
    public struct jylink_home_location_down
    {
        /// <summary> ����</summary>
        public double h_lon;
        /// <summary> γ��</summary>
        public double h_lat;
        /// <summary> �߶�</summary>
        public float h_alt;

    }
    //����ģʽ����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_flightmode_setup
    {
        /// <summary> ����ģʽ</summary>
        public byte flight_mode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_mainctrl_command_setup
    {

        public byte command1;
        public byte command2;
        public byte command3;
        public byte command4;
        public byte command5;
        public byte command6;
        public byte command7;
        public byte command8;

    }

    //״̬�����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 77)]
    public struct jylink_status_down
    {
        /// <summary> �����</summary>
        public UInt32 second_count;
        /// <summary> ����ģʽ</summary>
        public byte youmen_mode;
        /// <summary> �����ѹ0.2</summary>
        public byte duoji_v;
        /// <summary> ��ϸ߶�</summary>
        public Int16 zuhe_altitude;
        /// <summary> �߶��趨</summary>
        public Int16 hight_set;
        /// <summary> ��ѹ�߶�</summary>
        public Int16 air_altitude;
        /// <summary> ���ߵ�߶ȱ�߶�</summary>
        public UInt16 altitude;
        /// <summary> RPM </summary>
        public UInt16 rpm;
        /// <summary> �õ�ѹ</summary>
        public byte ecub_v;
        /// <summary> ��������ѹ*5</summary>
        public byte ecu_voltage1;
        /// <summary>����</summary>
        public UInt16 ecu_throttle;
        /// <summary>�¶�</summary>
        public Int16 ecu_pw;
        /// <summary>������</summary>
        public byte ecu_errorno;
        /// <summary>ʱ</summary>
        public byte time_h;
        /// <summary>��</summary>
        public byte time_m;
        /// <summary>��</summary>
        public byte time_s;
        /// <summary>����</summary>
        public byte sateliter;
        /// <summary> ��λ״̬</summary>
        public byte position_state;
        /// <summary> �ɿ�ģʽ</summary>
        public byte flightcontrol_mode;
        /// <summary> ������Ʒ��н׶�</summary>
        // public byte flightcontrol_progrom;
        /// <summary> ָ����Ʒ��н׶�</summary>       
        public byte youmen;
        /// <summary> ң��ָ��</summary>       
        public byte tele_command;
        /// <summary> ʧ��ģʽ</summar y>
        public byte loss_connect;
        /// <summary> ����</summar y>
        public byte warming;
        /// <summary> �ɿص�ѹ*5</summary>
        public byte flightcontrol_voltage;
        /// <summary> �������</summary>
        public byte waypoint_id;
        /// <summary> ����һ�������</summary>
        public UInt16 distance_to_nextwaypoint;
        /// <summary> ��Ҿ���</summary>
        public UInt16 distance_to_home;
        /// <summary> �೤������</summary>
        public Int16 distance_to_zj;
        public Int16 roll;
        public Int16 pitch;
        public Int16 yaw;
        public Int16 accz;
        public float lng;
        public float lat;
        public Int16 east_speed;
        public Int16 north_speed;
        public Int16 sky_speed;
        /// <summary> ����speed</summary>
        public byte zj_speed;
        public sbyte cepian;
        public sbyte s1;
        public sbyte s2;
        public sbyte s3;
        public sbyte s4;
        public sbyte f1;
        public sbyte f2;
        public sbyte f3;
        public sbyte f4;
        public Int16 roll_set;
        public Int16 pitch_set;

    };
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 17)]
    public struct jylink_serial_control_t
    {
        /// <summary> Baudrate of transfer. Zero means no change. </summary>
        public UInt32 baudrate;
        /// <summary> Timeout for reply data in milliseconds </summary>
        public UInt16 timeout;
        /// <summary> See SERIAL_CONTROL_DEV enum </summary>
        public byte device;
        /// <summary> See SERIAL_CONTROL_FLAG enum </summary>
        public byte flags;
        /// <summary> how many bytes in this transfer </summary>
        public byte count;
        /// <summary> serial data </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
        public byte[] data;

    };
    //�ǿ�����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_satellite_search
    {
        /// <summary> ���������</summary>
        public byte seq;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 14)]
    public class jylink_satlate_status
    {
        /// <summary> ������</summary>
        public UInt16 stacounts;
        /// <summary> Ԥ�������20��������</summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public Satlate_status[] satlist;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 82)]
    public struct Satlate_status
    {

        public UInt32 time;//LSB = 0.01 s
        public Int16 roll;//-180��180��LSB=1/182
        public Int16 pitch;//-90��90��LSB=1/182
        public Int16 yaw;//-180��180��LSB=1/182
        public float accspeed_x;
        public float accspeed_y;
        public float accspeed_z;
        public float angelspeed_x;
        public float angelspeed_y;
        public float angelspeed_z;
        public float lng;
        public float lat;
        public Int16 east_speed;//LSB=1/100
        public Int16 north_speed;//LSB=1/100
        public Int16 sky_speed;//LSB=1/100
        public Int16 duo1_set;
        public Int16 duo2_set;
        public Int16 duo3_set;
        public Int16 duo4_set;
        public Int16 duo1_get;
        public Int16 duo2_get;
        public Int16 duo3_get;
        public Int16 duo4_get;
        public Int16 roll_set;
        public Int16 pitch_set;
        public Int16 roll_ref;//-180��180��LSB=1/182
        public Int16 pitch_ref;//-90��90��LSB=1/182
        public Int16 yaw_ref; //-180��180��LSB=1/182
    }
    //�߶�ģʽ�л�����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_hight_setup
    {
        /// <summary> �߶�ģʽ</summary>
        public byte hightmode;
    }
    //�߶�ģʽ�л���ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_hight_search
    {
        /// <summary> �߶�ģʽ</summary>
        public byte hightmode;
    }
    //IMu�����´�
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
    public struct jylink_imu_param_down
    {
        public Single AccX;
        public Single AccY;
        public Single AccZ;
        public Single GyroX;
        public Single GyroY;
        public Single GyroZ;
        public Single SAccX;
        public Single SAccY;
        public Single SAccZ;
        public Single SGyroX;
        public Single SGyroY;
        public Single SGyroZ;
        public Single AccX_0;
        public Single AccY_0;
        public Single AccZ_0;
        public Single AccX_1;
        public Single AccY_1;
        public Single AccZ_1;
        public Single AccX_2;
        public Single AccY_2;
        public Single AccZ_2;
        public Single GccX_0;
        public Single GccY_0;
        public Single GccZ_0;
        public Single GccX_1;
        public Single GccY_1;
        public Single GccZ_1;
        public Single GccX_2;
        public Single GccY_2;
        public Single GccZ_2;
    };
    //IMU��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
    public struct jylink_imu_param_setup
    {
        public Single AccX;
        public Single AccY;
        public Single AccZ;
        public Single GyroX;
        public Single GyroY;
        public Single GyroZ;
        public Single SAccX;
        public Single SAccY;
        public Single SAccZ;
        public Single SGyroX;
        public Single SGyroY;
        public Single SGyroZ;
        public Single AccX_0;
        public Single AccY_0;
        public Single AccZ_0;
        public Single AccX_1;
        public Single AccY_1;
        public Single AccZ_1;
        public Single AccX_2;
        public Single AccY_2;
        public Single AccZ_2;
        public Single GccX_0;
        public Single GccY_0;
        public Single GccZ_0;
        public Single GccX_1;
        public Single GccY_1;
        public Single GccZ_1;
        public Single GccX_2;
        public Single GccY_2;
        public Single GccZ_2;
    };
    //IMU������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_imu_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
    public struct Warship_change
    {
        /// <summary> qiehuan</summary>
        public byte Heading_status;
        /// <summary> hangxiang</summary>
        public float Heading;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 20)]
    public struct Warship_home_location_up
    {
        /// <summary> ����</summary>
        public double h_lon;
        /// <summary> γ��</summary>
        public double h_lat;
        /// <summary> �߶�</summary>
        public Int16 h_head;
        public Int16 h_speed;

    }

    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_kg0z_param_setup
    {
        public Double kg0z00;
        public Double kg0z01;
        public Double kg0z02;
        public Double kg0z10;
        public Double kg0z11;
        public Double kg0z12;
        public Double kg0z20;
        public Double kg0z21;
        public Double kg0z22;
        public Double kg0z30;
        public Double kg0z31;
        public Double kg0z32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_kg0z_param_down
    {
        public Double kg0z00;
        public Double kg0z01;
        public Double kg0z02;
        public Double kg0z10;
        public Double kg0z11;
        public Double kg0z12;
        public Double kg0z20;
        public Double kg0z21;
        public Double kg0z22;
        public Double kg0z30;
        public Double kg0z31;
        public Double kg0z32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_kg0z_param_search
    {

    }

    //NAV��������Kgsx
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsx_param_setup
    {
        public Double Kgsx00;
        public Double Kgsx01;
        public Double Kgsx02;
        public Double Kgsx03;
        public Double Kgsx10;
        public Double Kgsx11;
        public Double Kgsx12;
        public Double Kgsx13;
        public Double Kgsx20;
        public Double Kgsx21;
        public Double Kgsx22;
        public Double Kgsx23;
        public Double Kgsx30;
        public Double Kgsx31;
        public Double Kgsx32;
        public Double Kgsx33;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsx_param_down
    {
        public Double Kgsx00;
        public Double Kgsx01;
        public Double Kgsx02;
        public Double Kgsx03;
        public Double Kgsx10;
        public Double Kgsx11;
        public Double Kgsx12;
        public Double Kgsx13;
        public Double Kgsx20;
        public Double Kgsx21;
        public Double Kgsx22;
        public Double Kgsx23;
        public Double Kgsx30;
        public Double Kgsx31;
        public Double Kgsx32;
        public Double Kgsx33;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgsx_param_search
    {

    }

    //NAV��������Kgsy
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsy_param_setup
    {
        public Double Kgsy00;
        public Double Kgsy01;
        public Double Kgsy02;
        public Double Kgsy03;
        public Double Kgsy10;
        public Double Kgsy11;
        public Double Kgsy12;
        public Double Kgsy13;
        public Double Kgsy20;
        public Double Kgsy21;
        public Double Kgsy22;
        public Double Kgsy23;
        public Double Kgsy30;
        public Double Kgsy31;
        public Double Kgsy32;
        public Double Kgsy33;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsy_param_down
    {
        public Double Kgsy00;
        public Double Kgsy01;
        public Double Kgsy02;
        public Double Kgsy03;
        public Double Kgsy10;
        public Double Kgsy11;
        public Double Kgsy12;
        public Double Kgsy13;
        public Double Kgsy20;
        public Double Kgsy21;
        public Double Kgsy22;
        public Double Kgsy23;
        public Double Kgsy30;
        public Double Kgsy31;
        public Double Kgsy32;
        public Double Kgsy33;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgsy_param_search
    {

    }

    //NAV��������Kgsz
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsz_param_setup
    {
        public Double Kgsz00;
        public Double Kgsz01;
        public Double Kgsz02;
        public Double Kgsz03;
        public Double Kgsz10;
        public Double Kgsz11;
        public Double Kgsz12;
        public Double Kgsz13;
        public Double Kgsz20;
        public Double Kgsz21;
        public Double Kgsz22;
        public Double Kgsz23;
        public Double Kgsz30;
        public Double Kgsz31;
        public Double Kgsz32;
        public Double Kgsz33;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
    public struct jylink_nav_Kgsz_param_down
    {
        public Double Kgsz00;
        public Double Kgsz01;
        public Double Kgsz02;
        public Double Kgsz03;
        public Double Kgsz10;
        public Double Kgsz11;
        public Double Kgsz12;
        public Double Kgsz13;
        public Double Kgsz20;
        public Double Kgsz21;
        public Double Kgsz22;
        public Double Kgsz23;
        public Double Kgsz30;
        public Double Kgsz31;
        public Double Kgsz32;
        public Double Kgsz33;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgsz_param_search
    {

    }

    //NAV��������Kgax
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgax_param_setup
    {
        public Double Kgax00;
        public Double Kgax01;
        public Double Kgax02;
        public Double Kgax10;
        public Double Kgax11;
        public Double Kgax12;
        public Double Kgax20;
        public Double Kgax21;
        public Double Kgax22;
        public Double Kgax30;
        public Double Kgax31;
        public Double Kgax32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgax_param_down
    {
        public Double Kgax00;
        public Double Kgax01;
        public Double Kgax02;
        public Double Kgax10;
        public Double Kgax11;
        public Double Kgax12;
        public Double Kgax20;
        public Double Kgax21;
        public Double Kgax22;
        public Double Kgax30;
        public Double Kgax31;
        public Double Kgax32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgax_param_search
    {

    }

    //NAV��������Kgay
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgay_param_setup
    {
        public Double Kgay00;
        public Double Kgay01;
        public Double Kgay02;
        public Double Kgay10;
        public Double Kgay11;
        public Double Kgay12;
        public Double Kgay20;
        public Double Kgay21;
        public Double Kgay22;
        public Double Kgay30;
        public Double Kgay31;
        public Double Kgay32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgay_param_down
    {
        public Double Kgay00;
        public Double Kgay01;
        public Double Kgay02;
        public Double Kgay10;
        public Double Kgay11;
        public Double Kgay12;
        public Double Kgay20;
        public Double Kgay21;
        public Double Kgay22;
        public Double Kgay30;
        public Double Kgay31;
        public Double Kgay32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgay_param_search
    {

    }


    //NAV��������Kgaz
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgaz_param_setup
    {
        public Double Kgaz00;
        public Double Kgaz01;
        public Double Kgaz02;
        public Double Kgaz10;
        public Double Kgaz11;
        public Double Kgaz12;
        public Double Kgaz20;
        public Double Kgaz21;
        public Double Kgaz22;
        public Double Kgaz30;
        public Double Kgaz31;
        public Double Kgaz32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Kgaz_param_down
    {
        public Double Kgaz00;
        public Double Kgaz01;
        public Double Kgaz02;
        public Double Kgaz10;
        public Double Kgaz11;
        public Double Kgaz12;
        public Double Kgaz20;
        public Double Kgaz21;
        public Double Kgaz22;
        public Double Kgaz30;
        public Double Kgaz31;
        public Double Kgaz32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Kgaz_param_search
    {

    }

    //NAV��������Gyron
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 152)]
    public struct jylink_nav_Gyron_param_setup
    {
        public Double Gyron00;
        public Double Gyron01;
        public Double Gyron02;
        public Double Gyron03;
        public Double Gyron04;
        public Double Gyron05;
        public Double Gyron10;
        public Double Gyron11;
        public Double Gyron12;
        public Double Gyron13;
        public Double Gyron14;
        public Double Gyron15;
        public Double Gyron20;
        public Double Gyron21;
        public Double Gyron22;
        public Double Gyron23;
        public Double Gyron24;
        public Double Gyron25;
    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 152)]
    public struct jylink_nav_Gyron_param_down
    {
        public Double Gyron00;
        public Double Gyron01;
        public Double Gyron02;
        public Double Gyron03;
        public Double Gyron04;
        public Double Gyron05;
        public Double Gyron10;
        public Double Gyron11;
        public Double Gyron12;
        public Double Gyron13;
        public Double Gyron14;
        public Double Gyron15;
        public Double Gyron20;
        public Double Gyron21;
        public Double Gyron22;
        public Double Gyron23;
        public Double Gyron24;
        public Double Gyron25;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Gyron_param_search
    {

    }


    //NAV��������ka0z
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_ka0z_param_setup
    {
        public Double ka0z00;
        public Double ka0z01;
        public Double ka0z02;
        public Double ka0z10;
        public Double ka0z11;
        public Double ka0z12;
        public Double ka0z20;
        public Double ka0z21;
        public Double ka0z22;
        public Double ka0z30;
        public Double ka0z31;
        public Double ka0z32;

    };
    //NAV��������ka0z
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_ka0z_param_down
    {
        public Double ka0z00;
        public Double ka0z01;
        public Double ka0z02;
        public Double ka0z10;
        public Double ka0z11;
        public Double ka0z12;
        public Double ka0z20;
        public Double ka0z21;
        public Double ka0z22;
        public Double ka0z30;
        public Double ka0z31;
        public Double ka0z32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_ka0z_param_search
    {

    }

    //NAV��������Ka1s
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Ka1s_param_setup
    {
        public Double Ka1s00;
        public Double Ka1s01;
        public Double Ka1s02;
        public Double Ka1s10;
        public Double Ka1s11;
        public Double Ka1s12;
        public Double Ka1s20;
        public Double Ka1s21;
        public Double Ka1s22;
        public Double Ka1s30;
        public Double Ka1s31;
        public Double Ka1s32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Ka1s_param_down
    {
        public Double Ka1s00;
        public Double Ka1s01;
        public Double Ka1s02;
        public Double Ka1s10;
        public Double Ka1s11;
        public Double Ka1s12;
        public Double Ka1s20;
        public Double Ka1s21;
        public Double Ka1s22;
        public Double Ka1s30;
        public Double Ka1s31;
        public Double Ka1s32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Ka1s_param_search
    {

    }

    //NAV��������Ka2k
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Ka2k_param_setup
    {
        public Double Ka2k00;
        public Double Ka2k01;
        public Double Ka2k02;
        public Double Ka2k10;
        public Double Ka2k11;
        public Double Ka2k12;
        public Double Ka2k20;
        public Double Ka2k21;
        public Double Ka2k22;
        public Double Ka2k30;
        public Double Ka2k31;
        public Double Ka2k32;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 104)]
    public struct jylink_nav_Ka2k_param_down
    {
        public Double Ka2k00;
        public Double Ka2k01;
        public Double Ka2k02;
        public Double Ka2k10;
        public Double Ka2k11;
        public Double Ka2k12;
        public Double Ka2k20;
        public Double Ka2k21;
        public Double Ka2k22;
        public Double Ka2k30;
        public Double Ka2k31;
        public Double Ka2k32;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Ka2k_param_search
    {

    }

    //NAV��������Accinv
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 80)]
    public struct jylink_nav_Accinv_param_setup
    {
        public Double Accinv00;
        public Double Accinv01;
        public Double Accinv02;
        public Double Accinv10;
        public Double Accinv11;
        public Double Accinv12;
        public Double Accinv20;
        public Double Accinv21;
        public Double Accinv22;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 80)]
    public struct jylink_nav_Accinv_param_down
    {
        public Double Accinv00;
        public Double Accinv01;
        public Double Accinv02;
        public Double Accinv10;
        public Double Accinv11;
        public Double Accinv12;
        public Double Accinv20;
        public Double Accinv21;
        public Double Accinv22;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Accinv_param_search
    {

    }

    //NAV��������Gyrinv
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 80)]
    public struct jylink_nav_Gyrinv_param_setup
    {
        public Double Gyrinv00;
        public Double Gyrinv01;
        public Double Gyrinv02;
        public Double Gyrinv10;
        public Double Gyrinv11;
        public Double Gyrinv12;
        public Double Gyrinv20;
        public Double Gyrinv21;
        public Double Gyrinv22;

    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 80)]
    public struct jylink_nav_Gyrinv_param_down
    {
        public Double Gyrinv00;
        public Double Gyrinv01;
        public Double Gyrinv02;
        public Double Gyrinv10;
        public Double Gyrinv11;
        public Double Gyrinv12;
        public Double Gyrinv20;
        public Double Gyrinv21;
        public Double Gyrinv22;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Gyrinv_param_search
    {

    }

    //NAV��������Accn
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 152)]
    public struct jylink_nav_Accn_param_setup
    {
        public Double Accn00;
        public Double Accn01;
        public Double Accn02;
        public Double Accn03;
        public Double Accn04;
        public Double Accn05;
        public Double Accn10;
        public Double Accn11;
        public Double Accn12;
        public Double Accn13;
        public Double Accn14;
        public Double Accn15;
        public Double Accn20;
        public Double Accn21;
        public Double Accn22;
        public Double Accn23;
        public Double Accn24;
        public Double Accn25;
    };
    //NAV��������
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 152)]
    public struct jylink_nav_Accn_param_down
    {
        public Double Accn00;
        public Double Accn01;
        public Double Accn02;
        public Double Accn03;
        public Double Accn04;
        public Double Accn05;
        public Double Accn10;
        public Double Accn11;
        public Double Accn12;
        public Double Accn13;
        public Double Accn14;
        public Double Accn15;
        public Double Accn20;
        public Double Accn21;
        public Double Accn22;
        public Double Accn23;
        public Double Accn24;
        public Double Accn25;

    };
    //nav������ѯ
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_nav_Accn_param_search
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    public struct jylink_duoji_param_setup
    {
        public byte status;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
    public struct jylink_planeID_param_set
    {
        public UInt16 planeID;
        public byte planeType;
        public byte dmzID;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
    public struct jylink_planeID_param_down
    {
        public UInt16 planeID;
        public byte planeType;
        public byte dmzID;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_planeID_param_search
    {

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 13)]
    public struct jylink_bd_planeID_param_set
    {
        /// <summary> ������ɾ��� </summary>
        public float lng;
        /// <summary> �������γ�� </summary>
        public float lat;
        /// <summary> �����ٶ� </summary>
        public byte speed;
        /// <summary> �������� </summary>
        public byte status;
        /// <summary> �ӳ�����ʱ�� </summary>
        public byte h;
        public byte m;
        public byte s;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 13)]
    public struct jylink_bd_planeID_param_down
    {
        /// <summary> ������ɾ��� </summary>
        public float lng;
        /// <summary> �������γ�� </summary>
        public float lat;
        /// <summary> �����ٶ� </summary>
        public byte speed;
        /// <summary> �������� </summary>
        public byte status;
        /// <summary> �ӳ�����ʱ�� </summary>
        public byte h;
        public byte m;
        public byte s;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0)]
    public struct jylink_bd_planeID_param_search
    {
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 20)]
    public struct jylink_bd_control_param_set
    {
        /// <summary> �ٶ���Сֵ</summary>
        public float min;
        /// <summary> �ٶ����ֵ</summary>
        public float max;
        /// <summary> ������� </summary>
        public float crossDemand;
        /// <summary> ǰ����� </summary>
        public float formDemand;
        /// <summary> �߶Ȳ� </summary>
        public float hightdiff;  
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 20)]
    public struct jylink_bd_control_param_down
    {
        /// <summary> �ٶ���Сֵ</summary>
        public float min;
        /// <summary> �ٶ����ֵ</summary>
        public float max;
        /// <summary> ������� </summary>
        public float crossDemand;
        /// <summary> ǰ����� </summary>
        public float formDemand;
        /// <summary> �߶Ȳ� </summary>
        public float hightdiff;  
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_bd_control_param_search
    {
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 17)]
    public struct jylink_fangzhe_set
    {
        public byte mode;
        public float lng;
        public float lat;
        public float alt;
        public float heading;
        //public byte hg; 
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_engine_param_down
    {
        public byte type;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_engine_param_setup
    {
        public byte type;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_engine_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_to_nextpoint_set
    {
        public byte mode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct jylink_bandwidth_param_down
    {
        public byte fbl;
        public UInt16 zq;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct jylink_bandwidth_param_setup
    {
        public byte fbl;
        public UInt16 zq;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_bandwidth_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct jylink_gmode_param_down
    {
        public byte mode;
        public byte count;
        public byte lossmode;
        public byte paosan;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct jylink_gmode_param_setup
    {
        public byte mode;
        public byte count;
        public byte lossmode;
        public byte paosan;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_gmode_param_search
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 18)]
    public struct jylink_tuoluo_param_down
    {
        public byte status;
        public float Tuo_x;
        public float Tuo_y;
        public float Tuo_z;
        public byte acc_status;
        public float acc_value;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_tuoluo_param_setup
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_tuoluo_param_search
    {

    }
    //micro����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 42)]
    public struct jylink_Micro_param_setup
    {
        public byte search_vs;
        public byte search_fws;
        public byte get_modes;
        public byte search_times;
        public UInt16 zp_hzs;
        public UInt16 zp_fws;
        public UInt16 mc_hzs;
        public float mc_kds;
        public byte bm_modes;
        public UInt16 lmf_dks;
        public byte micro_ids;
        public byte kj_ls;
        public byte jq_ls;
        public byte gl_kz1s;
        public byte gl_kz2s;
        public byte zkdj_ids;
        public double zkdj_lngs;
        public double zkdj_lats;
        public byte pz_sj;
        public byte gf_sj;
        public byte jd_kg;
    }
    //micro����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 42)]
    public struct jylink_Micro_param_down
    {
        public byte search_vs;
        public byte search_fws;
        public byte get_modes;
        public byte search_times;
        public UInt16 zp_hzs;
        public UInt16 zp_fws;
        public UInt16 mc_hzs;
        public float mc_kds;
        public byte bm_modes;
        public UInt16 lmf_dks;
        public byte micro_ids;
        public byte kj_ls;
        public byte jq_ls;
        public byte gl_kz1s;
        public byte gl_kz2s;
        public byte zkdj_ids;
        public double zkdj_lngs;
        public double zkdj_lats;
        public byte pz_sj;
        public byte gf_sj;
        public byte jd_kg;
    }
    //micro����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_Micro_param_search
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 17)]
    public struct jylink_Micro_position_setup
    {
        public byte id;
        public float lat;
        public float lng;
    }
    //micro����
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_status_Micro_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
    public struct jylink_Micro_status_down
    {

        public UInt16 kj_time;
        public byte wby_status1;
        public byte wby_id;
        public byte kdj_id;
        public UInt16 bj_kdj_l;
        public Int16 bj_zxj;
        public Int16 bjsf_fkj;
        public UInt16 v_60;
        public UInt16 v1_28;
        public UInt16 v2_28;
        public UInt16 v_12;
        public UInt16 pz_cyz;
        public Int16 beiyong;//cehuajiao
        public byte wby_status2;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 19)]
    public struct jylink_xb_status_down
    {
        public byte id;
        public double lat;
        public double lng;
        public UInt16 by;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 36)]
    public struct jylink_bj_status_down
    {
        public byte bjid;
        public byte wbyid;
        public byte mode;
        public double lat;
        public double lng;
        public UInt16 alt;
        public float heading;
        public UInt16 UTC_year;
        public byte UTC_month;
        public byte UTC_day;
        public byte UTC_hour;
        public byte UTC_min;
        public byte UTC_sec;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
    public struct jylink_zhenghe_param
    {
        public float hight;
        public float guozai;
        public float time;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_zhenghe_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
    public struct jylink_Grj_setup
    {
        public byte status;
        public byte num;
        public byte id;
        public byte command;
        public byte retain1;
        public byte retain2;
        public byte retain3;
        public byte retain4;
        public byte retain5;
        public byte retain6;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 27)]
    public struct jylink_Grj_down
    {
        public UInt16 second;
        public byte leibie;
        public sbyte command;
        public sbyte grjid;
        public byte backup1;
        public UInt16 backup2;
        public UInt16 secCount;
        public sbyte temp;
        public byte status;
        public UInt16 zsldpl;
        public UInt16 cfzq;
        public UInt16 mk;
        public sbyte taskid;
        public UInt16 taskb;
        public UInt16 yzzsdk;
        //       public Int16 xczsdk;
        public sbyte count;
        public byte ld3pl;
        public byte ld4pl;
        public byte backup3;         
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 77)]
    public struct jylink_kongyu_param
    {
        public float lng1;
        public float lat1;
        public float lng2;
        public float lat2;
        public float lng3;
        public float lat3;
        public float lng4;
        public float lat4;
        public float lng5;
        public float lat5;
        public float lng6;
        public float lat6;
        public float lng7;
        public float lat7;
        public float lng8;
        public float lat8;
        public float yujing_l;
        public float guihang_l;
        public float kaisan_l;
        public byte isrun;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_kongyu_param_search
    {

    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_biandui_mode_setup
    {
        public byte status;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_youmen_mode_setup
    {
        public byte status;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct jylink_bianhao_setup
    {
        public byte status;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct jylink_bianhao_ser
    {

    }
}
