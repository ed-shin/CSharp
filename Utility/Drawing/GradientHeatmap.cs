using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EDEN.Utility
{
    public class GradientHeatmap
    {
        private static double _min;
        private static double _max;
        private static int _level = 10;
        
        private static Dictionary<int, ColorBlend> _gradients = new Dictionary<int, ColorBlend>();
        

        public static void Init(int min, int max, Color color)
        {
            _min = min;
            _max = max;
            _gradients.Clear();
            for (int i = 1; i <= _level; i++)
            {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = getRelativePosition(i);
                colorBlend.Colors = getColors(color, i);

                _gradients.Add(i, colorBlend);
            }
        }

        public static void Clear()
        {
            _gradients.Clear();
        }

        private static float[] getRelativePosition(int level)
        {
            List<float> positions = new List<float>();
            positions.Add(0);
            for (int i = 1; i <= level; i++)
            {
                positions.Add((float)i / level);
            }

            return positions.ToArray();
        }

        private static Color[] getColors(Color color, int level)
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(0, color));
            for (int i = 1; i <= level; i++)
            {
                float scale = (float)i / (float)(level);
                int a = (int)(255f * scale);

                colors.Add(Color.FromArgb(a, color));
            }

            return colors.ToArray();
        }

        private static int parseLevel(double value)
        {
            double scale = (value - _min) / (_max - _min);
            int l = (int)Math.Floor(_level * scale);
            if (l > _level)
                l = _level;

            if (l <= 0)
                l = 1;

            return l;
        }

        public static void Draw(float x, float y, float radius, int value, Graphics g)
        {
            if (radius == 0)
                return;

            int level = parseLevel(value);

            using (GraphicsPath gPath = new GraphicsPath())
            {
                float length = radius * 2;
                gPath.AddEllipse(x - radius, y - radius, length, length);

                using (PathGradientBrush brush = new PathGradientBrush(gPath))
                {
                    brush.InterpolationColors = _gradients[level];

                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.Half;
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;

                    g.FillEllipse(brush, x - radius, y - radius, length, length);
                }
            }
        }

        public static void DrawEllipese(int x, int y, Graphics g)
        {
            Point p1 = new Point(x - 50, y - 50);
            Point p2 = new Point(x + 50, y + 50);
            using (LinearGradientBrush brush = new LinearGradientBrush(p1, p2, Color.Red, Color.Violet))
            {
                g.FillEllipse(brush, x, y, 50, 50);
            }
        }
    }
}
