
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public partial class JYLink
{
    public class JYLinkMCMessage
    {
        

        public static readonly JYLinkMCMessage Invalid = new JYLinkMCMessage();
        object _locker = new object();

        public byte[] buffer { get; internal set; }

        public byte header { get; internal set; }
        public byte payloadlength { get; internal set; }

        public byte incompat_flags { get; internal set; }
        public byte compat_flags { get; internal set; }

        public byte seq { get; internal set; }
        //消息源Id
        public byte sysid { get; internal set; }
        //消息目标Id
        public byte targetid { get; internal set; }

        public uint msgid { get; internal set; }
        public uint cmd { get; internal set; }

        object _data;
        public object data
        {
            get
            {
                // lock the entire creation of the packet. to prevent returning a incomplete packet.
                lock (_locker)
                {
                    if (_data != null)
                        return _data;

                    _data = Activator.CreateInstance(JYLINK_MESSAGE_INFOS.GetMessageInfo(msgid).type);

                    try
                    {
                        // fill in the data of the object
                        if (buffer[0] == JYLINK_STX_1)
                        {
                            JylinkUtil.ByteArrayToStructure(buffer, ref _data, JYLINK_NUM_HEADER_BYTES, payloadlength);
                        }
                        else
                        {
                            JylinkUtil.ByteArrayToStructure(buffer, ref _data, 8, payloadlength);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
              }

                return _data;
            }
        }

        public T ToStructure<T>()
        {
            return (T)data;
        }

        public ushort crc16 { get; internal set; }

        public byte[] sig { get; internal set; }

        public byte sigLinkid
        {
            get
            {
                if (sig != null)
                {
                    return sig[0];
                }

                return 0;
            }
        }

        public ulong sigTimestamp 
        {
            get
            {
                if (sig != null)
                {
                    byte[] temp = new byte[8];
                    Array.Copy(sig, 1, temp, 0, 6);
                    return BitConverter.ToUInt64(temp, 0);
                }

                return 0;
            }
        }

        public int Length
        {
            get
            {
                if (buffer == null) return 0;
                return buffer.Length;
            }
        }

        public JYLinkMCMessage()
        {

        }

        public JYLinkMCMessage(byte[] buffer)
        {
            this.buffer = buffer;

            if (buffer[0] == 0xEB)
            {
                header = buffer[0];
                payloadlength = 24;
                incompat_flags = 0;
                compat_flags = 0;
                seq = 0;
                sysid = 1;
                targetid = 0;
                msgid = buffer[2];

            }
            else
            {
                header = 0;
                payloadlength = 0;
                incompat_flags = 0;
                compat_flags = 0;
                seq = 0;
                sysid = 0;
                targetid = 0;
                msgid = 0;

            }
        }
    }
}
