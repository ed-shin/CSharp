using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Converter
{
    public static class StringConverter
    {
        public static Int32 ToInt32(this string str)
        {
            return Convert.ToInt32(str);
        }

        public static Int32 ToInt32(this string str, Int32 defaultValue)
        {
            int result = -1;
            if (!Int32.TryParse(str, out result))
                return defaultValue;

            return result;
        }

        public static Int64 ToInt64(this string str)
        {
            return Convert.ToInt64(str);
        }

        public static Int64 ToInt64(this string str, Int64 defaultValue)
        {
            long result = -1;
            if (!Int64.TryParse(str, out result))
                return defaultValue;

            return result;
        }

        public static float ToFloat(this string str)
        {
            return Convert.ToSingle(str);
        }

        public static float ToFloat(this string str, float defaultValue)
        {
            float result = -1f;
            if (!float.TryParse(str, out result))
                return defaultValue;

            return result;
        }

        public static double ToDouble(this string str)
        {
            return Convert.ToDouble(str);
        }

        public static double ToDouble(this string str, double defaultValue)
        {
            double result = -1f;
            if (!double.TryParse(str, out result))
                return defaultValue;

            return result;
        }

        public static DateTime ToDate(this string str)
        {
            DateTime date = DateTime.MinValue;
            if (DateTime.TryParse(str, out date))
                ;
            return date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">Format="yyyyMMddHHmmssfff</param>
        /// <returns></returns>
        public static DateTime ToDateFromLinearString(this string str)
        {
            int offset = 0, year = 0, month = 0, day = 0, hour = 0, min = 0, sec = 0, millisec = 0;

            str = str.Trim();

            offset += 4;
            if(str.Length > offset)
                year = Convert.ToInt32(str.Substring(0, 4));

            offset += 2;
            if (str.Length > offset)
                month = Convert.ToInt32(str.Substring(4, 2));

            offset += 2;
            if (str.Length > offset)
                day = Convert.ToInt32(str.Substring(6, 2));
            
            offset += 2;
            if (str.Length > offset)
                hour = Convert.ToInt32(str.Substring(8, 2));

            offset += 2;
            if (str.Length > offset)
                min = Convert.ToInt32(str.Substring(10, 2));

            offset += 2;
            if (str.Length > offset)
                sec = Convert.ToInt32(str.Substring(12, 2));

            offset += 3;
            if (str.Length > offset)
                millisec = Convert.ToInt32(str.Substring(14, 3));

            return new DateTime(year, month, day, hour, min, sec, millisec);
        }
    }
}
