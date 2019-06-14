using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data
{
    internal static partial class Uitlity
    {
        internal static Guid ToGuid(this object obj)
        {
            return new Guid((byte[])obj);
        }

        internal static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        internal static byte[] ToByteArray(this object obj)
        {
            return (byte[])obj;
        }

        internal static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        internal static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        internal static DateTime ToDateTime(this object obj)
        {
            return Convert.ToDateTime(obj);
        }
    }

    internal static partial class Uitlity
    {
        public static string ToDbString(this Guid guid)
        {
            byte[] ba = guid.ToByteArray();
            Guid temp = new Guid(new byte[16] { ba[3], ba[2], ba[1], ba[0], ba[5], ba[4], ba[7], ba[6], ba[8], ba[9], ba[10], ba[11], ba[12], ba[13], ba[14], ba[15] });
            return "X'" + temp.ToString().Replace("-", "") + "'";
        }
    }
}
