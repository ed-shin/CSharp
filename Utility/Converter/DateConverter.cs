using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Converter
{
    public static class DateConverter
    {
        public static string ToOracleFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH24:MI:SS");
        }
    }
}
