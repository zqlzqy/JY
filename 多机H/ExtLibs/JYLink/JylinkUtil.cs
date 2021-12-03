using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Static methods and helpers for creation and manipulation of Mavlink packets
/// </summary>
public static class JylinkUtil
{

    public static void ByteArrayToStructure(byte[] bytearray, ref object obj, int startoffset, int payloadlength = 0)
    {
        int len = Marshal.SizeOf(obj);

        IntPtr iptr = Marshal.AllocHGlobal(len);

        //clear memory
        for (int i = 0; i < len; i += 8)
        {
            Marshal.WriteInt64(iptr, i, 0x00);
        }

        for (int i = len - (len % 8); i < len; i++)
        {
            Marshal.WriteByte(iptr, i, 0x00);
        }

        // copy byte array to ptr
        Marshal.Copy(bytearray, startoffset, iptr, payloadlength);

        obj = Marshal.PtrToStructure(iptr, obj.GetType());

        Marshal.FreeHGlobal(iptr);

    }

    /// <summary>
    /// Convert a struct to an array of bytes, struct fields being reperesented in 
    /// little endian (LSB first)
    /// </summary>
    /// <remarks>Note - assumes little endian host order</remarks>
    public static byte[] StructureToByteArray(int messageType, object obj)
    {
        int len = Marshal.SizeOf(obj) ;

        int messg_len = 0;

        byte[] arr = new byte[len];
        ////////////////////////////////
        int size = 0;
        try
        {
            size = Marshal.SizeOf(obj);
        }
        catch (Exception ex)
        {
            string rr = ex.Message;
        }
        IntPtr buffer = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.StructureToPtr(obj, buffer, true);
            byte[] bytes = new byte[size];
            Marshal.Copy(buffer, bytes, 0, size);
            return bytes;
        }
        catch (Exception ex)
        {
            string rr = ex.Message;
            return null;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }

        ////////////////////////////////////
    }


    //从数组中获取对应消息实体

    public static JYLink.jy_message_info GetMessageInfo(this JYLink.jy_message_info[] source, uint msgid)
    {
        foreach (var item in source)
        {
            //if (cmd != null && cmd != 0)
            //{

            //    if ((item.msgid == (uint)JYLink.JY_CHANGEDSIZE_MSG_ID.JY_WP_DOWN || item.msgid == (uint)JYLink.JY_CHANGEDSIZE_MSG_ID.JY_WP_UP) && item.cmd == cmd)
            //        return item;
            //}
            //else
            //{
            if (item.msgid == msgid)
                return item;
            //}
        }

        return source[0];
    }
}