using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Converter
{
    public static class ObjectConverter
    {
        public static Int32 ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static Int32 ToInt32(this object obj, Int32 defaultValue)
        {
            if (obj is Int32)
                return obj.ToInt32();

            return defaultValue;
        }

        public static Int64 ToInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }

        public static Int64 ToInt64(this object obj, Int64 defaultValue)
        {
            if (obj is Int64)
                return obj.ToInt64();

            return defaultValue;
        }

        public static float ToFloat(this object obj)
        {
            return Convert.ToSingle(obj);
        }

        public static float ToFloat(this object obj, float defaultValue)
        {
            if (obj is Single)
                return obj.ToFloat();

            return defaultValue;
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static double ToDouble(this object obj, double defaultValue)
        {
            if (obj is Double)
                return obj.ToDouble();

            return defaultValue;
        }
        
        public static DateTime ToDate(this object obj)
        {
            return Convert.ToDateTime(obj);
        }

        public static DateTime ToDate(this object obj, DateTime defaultValue)
        {
            if (obj is DateTime)
                return obj.ToDate();

            return defaultValue;
        }
    }
}
