using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public partial class JYLink
{
    public class JylinkParse
    {
        public int packetcount = 0;

        public int badCRC = 0;
        public int badLength = 0;

        public static void ReadWithTimeout(Stream BaseStream, byte[] buffer, int offset, int count)
        {
            int timeout = BaseStream.ReadTimeout;

            if (timeout == -1)
                timeout = 60000;

            DateTime to = DateTime.Now.AddMilliseconds(timeout);

            int toread = count;
            int pos = offset;

            while (true)
            {
                // read from stream
                int read = BaseStream.Read(buffer, pos, toread);

                // update counter
                toread -= read;
                pos += read;

                // reset timeout if we get data
                if (read > 0)
                    to = DateTime.Now.AddMilliseconds(timeout);

                if (toread == 0)
                    break;

                if (DateTime.Now > to)
                {
                    throw new TimeoutException("Timeout waiting for data");
                }
                System.Threading.Thread.Sleep(1);
            }
        }

        public JYLinkMessage ReadPacket(Stream BaseStream)
        {
            byte[] buffer = new byte[270];

            int readcount = 0;

            while (readcount < 200)
            {
                // read STX1 byte
                
                ReadWithTimeout(BaseStream, buffer, 0, 1);

                if (buffer[0] == JYLink.JYLINK_STX_1)
                    break;
                readcount +=1 ;
            }
          
            var headerlength = 0;
            if (buffer[0] == JYLINK_STX_1)
                headerlength = JYLINK_HEADER_LEN;
            
            var headerlengthstx = headerlength + 2;

            // read header
            ReadWithTimeout(BaseStream, buffer, 1, headerlength+1);

            // packet length
            int lengthtoread = 0;
            if (buffer[0] == JYLINK_STX_1)
            {
                lengthtoread = buffer[6] + headerlengthstx + 1; // data + header + checksum - magic - length
                
            }
            //read rest of packet
            ReadWithTimeout(BaseStream, buffer, 7, lengthtoread - (headerlengthstx));

            // resize the packet to the correct length
            Array.Resize<byte>(ref buffer, lengthtoread);

            JYLinkMessage message = new JYLinkMessage(buffer);

            
            byte crc = JylinkCRC.crc_calculate(buffer, buffer.Length - 1);

            if (crc != buffer[buffer.Length - 1])
            {
                return null;
            }
            else
            {
                return message;
            }
           
        }
        //生成尖翼飞控指令
        public byte[] GenerateJYLinkPacket(JYLINK_MSG_ID messageType, object indata)
        {
            byte[] data;

            data = JylinkUtil.StructureToByteArray(1,indata);

            byte[] packet = new byte[data.Length + 7 + 1];

            packet[0] = JYLINK_STX_1;
            packet[1] = JYLINK_STX_2;
            packet[2] = (byte)messageType;
            packet[3] = (byte)JY_COMPONENT.JY_MISSION_PLANNER;
            packet[5] = (byte)packetcount;
            packetcount++;
            packet[6] = (byte)data.Length;


            int i = 7;
            foreach (byte b in data)
            {
                packet[i] = b;
                i++;
            }

            byte checksum = JylinkCRC.crc_calculate(packet, packet[6] + 8);

            packet[i] = checksum;
            i += 1;

            return packet;
        }


        public byte sendlinkid { get; set; }

        public ulong lasttimestamp { get; set; }

        public byte[] signingKey { get; set; }
    }
}
