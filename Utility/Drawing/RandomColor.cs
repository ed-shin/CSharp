using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiltiy.Drawing
{
    public class RandomColor
    {
        private static Random rand = new Random();

        public static Color GetColor(int max = 255)
        {
            int r = rand.Next(max);
            int g = rand.Next(max);
            int b = rand.Next(max);

            return Color.FromArgb(r, g, b);
        }
    }
}
