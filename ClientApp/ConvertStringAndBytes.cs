using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApp
{
    /// <summary>
    /// 添加新类执行字符串和二进制数组转换功能的静态方法类
    /// </summary>
    class ConvertStringAndBytes
    {
        //将字节数组转换为16进制字符串
        public static string ConvertBytesToString(byte[] bs)
        {
            string str = string.Empty;
            if (bs != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bs.Length; i++)
                {
                    sb.Append(bs[i].ToString("X2"));
                }
                str = sb.ToString();
            }
            return str;
        }
        //将16进制符号转换为为字节数组
        public static byte[] ConvertStringToBytes(string str)
        { 
            byte[] bs=new byte[str.Length/2];

            for (int i = 0; i < bs.Length; i++)
            {
                bs[i] = Convert.ToByte(str.Substring(i*2,2),16);
            }
            return bs;        
        }
    }
}
