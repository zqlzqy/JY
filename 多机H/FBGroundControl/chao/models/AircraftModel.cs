using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBGroundControl.chao.models
{
    /// <summary>
    /// 定义无人机模型,lichao
    /// </summary>
    public class AircraftModel
    {
        //飞控系统编号
        public string system_id { get; set; }

        //飞控当前自定义编号
        public string current_id { get; set; }

        //地面站准备修改飞控的自定义编号
        public string modify_id { get; set; }

        //飞机颜色编号
        public int colorID { get; set; }

        //飞机是否显示航向
        public bool isShowHeading { get; set; }
        //飞机是否显示轨迹
        public bool isShowTrack { get; set; }
        //飞机是否显示航线
        public bool isShowWayPointLine { get; set; }
        //飞机是否显示编号
        public bool isShowPlaneID { get; set; }
        public AircraftModel(string system_id, string current_id) {
            this.system_id = system_id;
            this.current_id = current_id;
            this.colorID = 0;
            this.isShowHeading = false;
            this.isShowTrack = true;
            this.isShowWayPointLine = true;
            this.isShowPlaneID = true;
        }
    }
}
