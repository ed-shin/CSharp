using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Utility.UI
{
    public partial class CustomProgressbar : UserControl
    {
        // draw attribute
        private bool useGradation = false;
        private Color color = Color.Black;

        private float maxValue = 10;
        private float value = 10;


        public bool UseGradation
        {
            get { return useGradation; }
            set
            {
                this.useGradation = value;
                this.Invalidate();
            }
        }

        public Color DrawColor
        {
            get { return color; }
            set
            {
                this.color = value;
                this.Invalidate();
            }
        }

        public float Value
        {
            get { return value; }
            set
            {
                if (value < 0)
                    this.value = 0;

                if (this.maxValue < value)
                    throw new InvalidExpressionException();

                this.value = value;

                this.Invalidate();
            }
        }

        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value < 0 || this.value > value)
                    throw new InvalidExpressionException();

                this.maxValue = value;

                this.Invalidate();
            }
        }

        public CustomProgressbar()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            draw(g);
        }
        

        private void draw(Graphics g)
        {
            int width = (int)((this.value / this.maxValue) * this.Width);
            
            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), color, color, LinearGradientMode.Horizontal);
            if (useGradation)
            {
                Color sColor = Color.FromArgb(128, color);
                Color eColor = color;

                ColorBlend cb = new ColorBlend();
                cb.Colors = new Color[] { sColor, eColor };
                cb.Positions = new float[] { 0.0F, 1.0F };
                lgb.InterpolationColors = cb;
            }
            g.FillRectangle(lgb, new Rectangle(0, 0, width, this.Height));
            lgb.Dispose();
        }
    }
}
