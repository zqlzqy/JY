using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MissionPlanner.Utilities
{
    /// <summary>
    /// Struct as used in Ardupilot
    /// </summary>
    public struct Locationwp
    {
        public Locationwp Set(double lat, double lng, double alt, byte id, byte num)
        {
            this.lat = lat;
            this.lng = lng;
            this.alt = (float)alt;
            this.id = id;
            this.num = num;
            return this;
        }

        public static implicit operator JYLink.jylink_mission_item(Locationwp input)
        {
            return (JYLink.jylink_mission_item)Convert(input, false);
        }

        public static implicit operator MAVLink.mavlink_mission_item_int_t(Locationwp input)
        {
            return (MAVLink.mavlink_mission_item_int_t)Convert(input, true);
        }

        public static implicit operator Locationwp(JYLink.jylink_mission_item input)
        {
            Locationwp temp = new Locationwp()
            {
                num = input.num,
                id = input.cmd,
                p1 = input.param1,
                p2 = input.param2,
                p3 = input.param3,
                p4 = input.param4,
                lat = input.latitude,
                lng = input.longitude,
                alt = input.altitude,
                _seq = input.seq,
                //_frame = input.frame
            };

            return temp;
        }

        //public static implicit operator Locationwp(JYLink.jylink_mission_item input)
        //{
        //    Locationwp temp = new Locationwp()
        //    {
        //        id = input.cmd,
        //        p1 = input.param1,
        //        p2 = input.param2,
        //        p3 = input.param3,
        //        p4 = input.param4,
        //        lat = input.latitude / 1.0e7,
        //        lng = input.longitude / 1.0e7,
        //        alt = input.altitude,
        //        _seq = input.seq,
        //        //_frame = input.frame
        //    };

        //    return temp;
        //}

        public static implicit operator Locationwp(MissionFile.MissionItem input)
        {
            Locationwp temp = new Locationwp()
            {
                num = input.num,
                id = input.command,
                p1 = input.param1,
                p2 = input.param2,
                p3 = input.param3,
                p4 = input.param4,
                lat = input.coordinate[0],
                lng = input.coordinate[1],
                alt = (float)input.coordinate[2],
                _seq = input.id,
                _frame = input.frame
            };

            return temp;
        }

        public static implicit operator MissionFile.MissionItem(Locationwp input)
        {
            MissionFile.MissionItem temp = new MissionFile.MissionItem()
            {
                num = input.num,
                command = input.id,
                param1 = input.p1,
                param2 = input.p2,
                param3 = input.p3,
                param4 = input.p4,
                coordinate = new double[] { input.lat, input.lng, input.alt },
                id = input._seq,
                frame = input._frame
            };

            return temp;
        }

        static object Convert(Locationwp cmd, bool isint = false)
        {
            if (isint)
            {
                var temp = new JYLink.jylink_mission_item()
                {
                    num = cmd.num,
                    cmd = cmd.id,
                    param1 = cmd.p1,
                    param2 = cmd.p2,
                    param3 = cmd.p3,
                    param4 = cmd.p4,
                    latitude = (int)(cmd.lat * 1.0e7),
                    longitude = (int)(cmd.lng * 1.0e7),
                    altitude = (float)cmd.alt,
                    seq = cmd._seq,
                    //frame = cmd._frame
                };

                return temp;
            }
            else
            {
                var temp = new MAVLink.mavlink_mission_item_t()
                {

                    command = cmd.id,

                    param1 = cmd.p1,
                    param2 = cmd.p2,
                    param3 = cmd.p3,
                    param4 = cmd.p4,
                    x = (float)cmd.lat,
                    y = (float)cmd.lng,
                    z = (float)cmd.alt,
                    seq = cmd._seq,
                    frame = cmd._frame
                };

                return temp;
            }
        }

        private byte _seq;
        private byte _frame;
        public object Tag;
        public byte num;
        public byte id;				// command id
        public byte options;
        public UInt16 p1;				// param 1
        public UInt16 p2;				// param 2
        public UInt16 p3;				// param 3
        public UInt16 p4;				// param 4
        public double lat;				// Lattitude * 10**7
        public double lng;				// Longitude * 10**7
        public float alt;				// Altitude in centimeters (meters * 100)
    };
}
