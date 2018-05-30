using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Utility.Drawing
{
    public class HeatmapUtil
    {
        public static Color RedHeatmapColor(int value, int min, int max)
        {
            if (max == min)
                return Color.Black;

            double val = (double)(value - min) / (double)(max - min);
            
            int r = Convert.ToByte(255);
            int g = Convert.ToByte(255 * (1 - val));
            int b = Convert.ToByte(255 * (1 - val));

            return Color.FromArgb(r, g, b);
        }

        public static Color ReverseRedHeatmapColor(int value, int min, int max)
        {
            if (max == min)
                return Color.Black;

            double val = (double)(value - min) / (double)(max - min);

            int r = Convert.ToByte(255);
            int g = Convert.ToByte(255 - (255 * (1 - val)));
            int b = Convert.ToByte(255 - (255 * (1 - val)));

            return Color.FromArgb(r, g, b);
        }

        public static Color GreenHeatmapColor(int value, int min, int max)
        {
            if (max == min)
                return Color.Black;

            double val = (double)(value - min) / (double)(max - min);

            int r = Convert.ToByte(255 * (1 - val));
            int g = Convert.ToByte(255);
            int b = Convert.ToByte(255 * (1 - val));

            return Color.FromArgb(r, g, b);
        }

        public static Color BlueHeatmapColor(int value, int min, int max)
        {
            if (max == min)
                return Color.Black;

            double val = (double)(value - min) / (double)(max - min);

            int r = Convert.ToByte(255 * (1 - val));
            int g = Convert.ToByte(255 * (1 - val));
            int b = Convert.ToByte(255);

            return Color.FromArgb(r, g, b);
        }

        public static Color BlueToRedHeatmapColor(int value, int min, int max, int opacity = 255)
        {
            if (max == min)
                return Color.Black;

            double val = (double)(value - min) / (double)(max - min);

            if (val > 1)
                val = 1;

            int r = Convert.ToByte(255 * val);
            int g = 0;
            int b = Convert.ToByte(255 * (1 - val));
            int a = opacity;
            if (opacity == 255)
                a = b > 128 ? 128 : 255;

            return Color.FromArgb(a, r, g, b);
        }
    }
}
