using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.Protocol
{
    public static class Utility
    {
        public static string ToServerString(this Guid guid)
        {
            byte[] ba = guid.ToByteArray();
            Guid temp = new Guid(new byte[16] { ba[3], ba[2], ba[1], ba[0], ba[5], ba[4], ba[7], ba[6], ba[8], ba[9], ba[10], ba[11], ba[12], ba[13], ba[14], ba[15] });
            string str = temp.ToString();

            return str.Replace("-", "").ToUpper();
        }

        public static string ToServerString(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        public static Guid ToServerGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Guid();

            Guid guid = new Guid(str);
            byte[] ba = guid.ToByteArray();
            Guid temp = new Guid(new byte[16] { ba[3], ba[2], ba[1], ba[0], ba[5], ba[4], ba[7], ba[6], ba[8], ba[9], ba[10], ba[11], ba[12], ba[13], ba[14], ba[15] });

            return temp;
        }
    }
}
