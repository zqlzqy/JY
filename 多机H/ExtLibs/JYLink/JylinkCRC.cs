using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class JYLink
{
    public class JylinkCRC
    {
        public static byte crc_calculate(byte[] pBuffer, int length)
        {
           
                if (length < 1)
                {
                    return 0xff;
                }
                byte CRC = pBuffer[2];
                for (int i = 3; i < pBuffer.Length - 1; i++)
                {
                    CRC ^= pBuffer[i];
                }
                return CRC;
            
        }
        public static byte crc_calculate2(byte[] pBuffer)
        {
            byte CRC = pBuffer[0];
            for (int i = 1; i < pBuffer.Length - 1; i++)
            {
                CRC ^= pBuffer[i];
            }
            return CRC;
        }
    }
}