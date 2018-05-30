using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Utility.Debugging
{
    public static class ConsoleDebuger
    {
        public static bool IsDebug = true;
        public static void Write(string text, params object[] objs)
        {
            if (IsDebug)
                Console.WriteLine(text, objs);
        }

        public static void Write(string text)
        {
            if (IsDebug)
                Console.WriteLine(text);
        }
    }
}
