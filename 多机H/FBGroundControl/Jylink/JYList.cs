using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using MissionPlanner.Controls;
using FBGroundControl.chao.models;

namespace MissionPlanner.Mavlink
{
    public class JYList : IEnumerable<JYState>
    {
        private Dictionary<int, JYState> masterlist = new Dictionary<int, JYState>();

        private Dictionary<int, JYState> hiddenlist = new Dictionary<int, JYState>();


        public JYList()
        {
            // add blank item
            //masterlist.Add(0, new JYState());
        }

        public void AddHiddenList(byte sysid, byte compid)
        {
            int id = GetID((byte)sysid, (byte)compid);

            hiddenlist[id] = new JYState() { sysid = sysid, targetid = compid };
        }

        public JYState this[int sysid, int compid]
        {
            get
            {
                int id = GetID((byte)sysid, (byte)compid);

                // 3dr radio special case
                if (hiddenlist.ContainsKey(id))
                    return hiddenlist[id];

                if (!masterlist.ContainsKey(id))
                    return new JYState();

                return masterlist[id];
            }
            set
            {
                int id = GetID((byte)sysid, (byte)compid);
                if (id != 0)
                {
                    masterlist[id] = value;
                }

            }
        }

        public int Count
        {
            get { return masterlist.Count; }
        }

        public List<int> GetRawIDS()
        {
            return masterlist.Keys.ToList<int>();
        }

        public void Clear()
        {
            masterlist.Clear();
        }

        public bool Contains(byte sysid, byte compid, bool includehidden = true)
        {
            foreach (var item in masterlist)
            {
                if (item.Value.sysid == sysid && item.Value.targetid == compid)
                    return true;
            }

            if (includehidden)
            {
                foreach (var item in hiddenlist)
                {
                    if (item.Value.sysid == sysid && item.Value.targetid == compid)
                        return true;
                }
            }

            return false;
        }

        internal void Create(byte sysid, byte compid)
        {
            int id = GetID((byte)sysid, (byte)compid);

            // move from hidden to visible
            if (hiddenlist.ContainsKey(id))
            {
                masterlist[id] = hiddenlist[id];
                hiddenlist.Remove(id);
            }

            if (!masterlist.ContainsKey(id))
                masterlist[id] = new JYState();
        }

        public IEnumerator<JYState> GetEnumerator()
        {
            foreach (var key in masterlist.Values)
            {
                yield return key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static int GetID(byte sysid, byte compid)
        {
            return  compid;
        }

        public void remove(int id)
        {
            if (masterlist.ContainsKey(id))
            {
                masterlist.Remove(id);
            }
        }
    }
}