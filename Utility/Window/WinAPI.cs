using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Window
{
    /// <summary>
    /// Window Animation API
    /// </summary>
    public partial class WinAPI
    {
        public const int Horizontal_Positive = 0x1;
        public const int Horizontal_Negative = 0x2;
        public const int Vertical_Positive = 0x4;
        public const int Vertical_Negative = 0x8;
        public const int Center = 0x10;
        public const int Blent = 0x80000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int AnimateWindow(IntPtr hwnd, int drawTime, int drawFlag);
    }
}
