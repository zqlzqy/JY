using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class JYLink
{
    public class JYLinkParamList: List<JYLinkParam>
    {
        object locker = new object();

        public int TotalReported { get; set; }

        public int TotalReceived
        {
            get { return this.Count; }
        }

        public JYLinkParam this[string name]
        { 
            get
            {
                lock (locker)
                {
                    foreach (var item in this)
                    {
                        if (item.Name == name)
                            return item;
                    }
                }

                return null;
            }

            set
            {
                int index = 0;
                lock (locker)
                {
                    foreach (var item in this)
                    {
                        if (item.Name == name)
                        {
                            this[index] = value;
                            return;
                        }

                        index++;
                    }

                    this.Add(value);
                }
            }
        }

        public IEnumerable<string> Keys
        {
            get
            {
                foreach (JYLinkParam item in this.ToArray())
                {
                    yield return item.Name;
                }
            }
        }

        public bool ContainsKey(string v)
        {
            lock (locker)
            {
                foreach (JYLinkParam item in this)
                {
                    if (item.Name == v)
                        return true;
                }
            }

            return false;
        }

        public new void Clear()
        {
            lock (locker)
            {
                TotalReported = 0;
                base.Clear();
            }
        }

        public new void Add(JYLinkParam item)
        {
            lock (locker)
            {
                base.Add(item);
            }
        }

        public new void AddRange(IEnumerable<JYLinkParam> collection)
        {
            lock (locker)
            {
                base.AddRange(collection);
            }
        }

        public static implicit operator Hashtable(JYLinkParamList list)
        {
            Hashtable copy = new Hashtable();
            foreach (JYLinkParam item in list.ToArray())
            {
                copy[item.Name] = item.Value;
            }

            return copy;
        }
    }
}
