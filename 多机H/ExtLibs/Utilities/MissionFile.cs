﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace MissionPlanner.Utilities
{
    public class MissionFile
    {
        public static void test()
        {
            var file = File.ReadAllText(@"C:\Users\michael\Desktop\logs\FileFormat.mission");

            var output = JsonConvert.DeserializeObject<Format>(file);

            var fileout = JsonConvert.SerializeObject(output);
        }

        public static Format ReadFile(string filename)
        {
            var file = File.ReadAllText(filename);

            var output = JsonConvert.DeserializeObject<Format>(file);

            return output;
        }

        public static void WriteFile(string filename, Format format)
        {
            var fileout = JsonConvert.SerializeObject(format, Formatting.Indented);

            File.WriteAllText(filename, fileout);
        }

        public static List<Locationwp> ConvertToLocationwps(Format format)
        {
            List<Locationwp> cmds = new List<Locationwp>();

            cmds.Add(ConvertFromMissionItem(format.plannedHomePosition));

            foreach (var missionItem in format.items)
            {
                cmds.Add(ConvertFromMissionItem(missionItem));
            }

            return cmds;
        }

        public static Locationwp ConvertFromMissionItem(MissionItem missionItem)
        {
            return missionItem;
        }

        public static MissionItem ConvertFromLocationwp(Locationwp locationwp)
        {
            return locationwp;
        }

        public class Format
        {
            public int MAV_AUTOPILOT;
            public List<object> complexItems = new List<object>();
            public string groundStation;
            public List<MissionItem> items = new List<MissionItem>();
            public MissionItem plannedHomePosition;
            public string version = "1.0";
        }

        public class MissionItem
        {
            public bool autoContinue = true;
            public byte command;
            public double[] coordinate = new double[3];
            public byte frame;
            public byte num;
            public byte id;
            public UInt16 param1;
            public UInt16 param2;
            public UInt16 param3;
            public UInt16 param4;
        }

        public static Format ConvertFromLocationwps(List<Locationwp> list, byte frame = (byte)MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT)
        {
            Format temp = new Format()
            {
                MAV_AUTOPILOT = (int)MAVLink.MAV_AUTOPILOT.ARDUPILOTMEGA,
                groundStation = "MissionPlanner",
                version = "1.0"
            };

            if (list.Count > 0)
                temp.plannedHomePosition = ConvertFromLocationwp(list[0]);

            if (list.Count > 1)
            {
                int a = -1;
                foreach (var item in list)
                {
                    // skip home
                    if (a == -1)
                    {
                        a++;
                        continue;
                    }

                    var temploc = ConvertFromLocationwp(item);

                    // set id count
                    temploc.id = (byte)a;
                    // set frame type
                    temploc.frame = frame;

                    temp.items.Add(temploc);

                    if (item.Tag != null)
                    {
                        if (!temp.complexItems.Contains(item.Tag))
                            temp.complexItems.Add(item.Tag);
                    }

                    a++;
                }
            }

            return temp;
        }
    }
}