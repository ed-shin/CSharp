using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class FormMain : Form
    {
        private Timer timer = null;
        private Bitmap bmpCaptured = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
        private Bitmap bmpCapturedExapnd = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
        private Color colorPicked = Color.Empty;

        private bool blocked = false;

        public FormMain()
        {
            InitializeComponent();

            ColorOnMouse.UsageDPI();

            MouseHook.Start();
            MouseHook.MouseAction += MouseHook_MouseAction;

            KeyboardHook.Start();
            KeyboardHook.KeyboardAction += KeybordHook_KeyboardAction;

            this.picImage.Paint += picImage_Paint;
            this.picExpand.Paint += PicExpand_Paint;
            this.picColor.Paint += PicColor_Paint;

            this.tbR.TextChanged += Tb_TextChanged;
            this.tbG.TextChanged += Tb_TextChanged;
            this.tbB.TextChanged += Tb_TextChanged;
            this.tbHex.TextChanged += Tb_TextChanged;

            this.btnCopyRGB.MouseLeave += setMouseHook;
            this.btnCopyRGB.MouseHover += unMouseHook;
            this.btnCopyHEX.MouseLeave += setMouseHook;
            this.btnCopyHEX.MouseHover += unMouseHook;

            this.radioBackColor.MouseLeave += setMouseHook;
            this.radioBackColor.MouseHover += unMouseHook;
            this.radioForeColor.MouseLeave += setMouseHook;
            this.radioForeColor.MouseHover += unMouseHook;
        }

        private void KeybordHook_KeyboardAction(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.C)
            {
                this.printColor(colorPicked);
                this.addColorItem(colorPicked);
            }
        }

        private void MouseHook_MouseAction(object sender, MouseEventArgs e)
        {
            //printColor();
        }

        // Text Size Scaling
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0)
                return;
            
            float height = tb.Height * 0.99f;
            float width = tb.Width * 0.99f;

            tb.SuspendLayout();

            Font tryFont = tb.Font;
            Size tempSize = TextRenderer.MeasureText(tb.Text, tryFont);

            float heightRatio = height / tempSize.Height;
            float widthRatio = width / tempSize.Width;

            tryFont = new Font(tryFont.FontFamily, tryFont.Size * Math.Min(widthRatio, heightRatio), tryFont.Style);

            tb.Font = tryFont;
            tb.ResumeLayout();
        }

        private void printColor(Color color)
        {
            if (blocked)
                return;

            this.tbR.Text = color.R.ToString();
            this.tbG.Text = color.G.ToString();
            this.tbB.Text = color.B.ToString();
            this.tbHex.Text = string.Format("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);

            if (radioBackColor.Checked)
                this.pnlResult.BackColor = color;

            if (radioForeColor.Checked)
                this.lbForeColor.ForeColor = color;
        }

        private void addColorItem(Color color)
        {
            Label lb = new Label();
            lb.Dock = DockStyle.Top;
            lb.Text = string.Format("{0},{1},{2}", tbR.Text, tbG.Text, tbB.Text);
            lb.BackColor = color;
            lb.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            lb.MouseHover += Lb_MouseHover;
            lb.MouseLeave += Lb_MouseLeave;
            lb.MouseClick += Lb_MouseClick;
            lb.MouseDoubleClick += Lb_MouseDoubleClick;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Tag = color;

            this.pnlColorItems.Controls.Add(lb);
        }

        private void Lb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;

            this.pnlColorItems.Controls.Remove(lb);
        }

        private void Lb_MouseClick(object sender, EventArgs e)
        {
            Label lb = (Label)sender;

            this.colorPicked = (Color)lb.Tag;
            this.printColor(colorPicked);
        }

        private void Lb_MouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.BorderStyle = BorderStyle.None;
        }

        private void Lb_MouseHover(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.BorderStyle = BorderStyle.Fixed3D;
        }

        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            lock (bmpCaptured)
            {
                e.Graphics.DrawImage(bmpCaptured, 
                    e.ClipRectangle.Left + e.ClipRectangle.Width / 2 - bmpCaptured.Width / 2,
                    e.ClipRectangle.Top + e.ClipRectangle.Height / 2 - bmpCaptured.Height / 2,
                    bmpCaptured.Width, 
                    bmpCaptured.Height);
                
                e.Graphics.DrawLine(Pens.Red, new Point(0, 50), new Point(99, 50));
                e.Graphics.DrawLine(Pens.Red, new Point(50, 0), new Point(50, 99));
            }
        }

        private void PicExpand_Paint(object sender, PaintEventArgs e)
        {
            lock (bmpCapturedExapnd)
            {
                e.Graphics.DrawImage(bmpCapturedExapnd, 
                    e.ClipRectangle.Left + e.ClipRectangle.Width / 2 - bmpCapturedExapnd.Width / 2,
                    e.ClipRectangle.Top + e.ClipRectangle.Height / 2 - bmpCapturedExapnd.Height / 2,
                    bmpCapturedExapnd.Width, 
                    bmpCapturedExapnd.Height);

                e.Graphics.DrawLine(Pens.Red, new Point(0, 50), new Point(99, 50));
                e.Graphics.DrawLine(Pens.Red, new Point(50, 0), new Point(50, 99));
            }
        }
        private void PicColor_Paint(object sender, PaintEventArgs e)
        {
            this.picColor.BackColor = colorPicked;
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            this.timer = new Timer();
            this.timer.Interval = 100;
            this.timer.Tick += Timer_Tick;
            this.timer.Start();

            this.lbForeColor.BackColor = Color.Transparent;
            this.lbForeColor.ForeColor = Color.White;
            this.lbForeColor.Parent = this.pnlResult;

            this.customTitleBar.Title = "Simple Color Picker";
            this.TopMost = true;
            this.TopLevel = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(bmpCaptured != null)
            {
                bmpCaptured.Dispose();
                bmpCaptured = null;
            }

            if(bmpCapturedExapnd != null)
            {
                bmpCapturedExapnd.Dispose();
                bmpCapturedExapnd = null;
            }

            bmpCaptured = ColorOnMouse.CaptureImage(MousePosition.X, MousePosition.Y);
            bmpCapturedExapnd = new Bitmap(bmpCaptured, new Size(bmpCaptured.Width * 8, bmpCaptured.Height * 8));
            colorPicked = ColorOnMouse.GetColor();

            picImage.Invalidate();
            picExpand.Invalidate();
            picColor.Invalidate();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer.Stop();
            this.timer.Dispose();
            this.timer = null;

            MouseHook.Stop();
            KeyboardHook.Stop();
        }

        private void btnCopyRGB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbR.Text) || string.IsNullOrEmpty(tbG.Text) || string.IsNullOrEmpty(tbB.Text))
                return;

            Clipboard.Clear();
            Clipboard.SetText(string.Format("{0},{1},{2}", tbR.Text, tbG.Text, tbB.Text));
        }

        private void btnCopyHEX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHex.Text))
                return;

            Clipboard.Clear();
            Clipboard.SetText(tbHex.Text);
        }
        
        private void unMouseHook(object sender, EventArgs e)
        {
            blocked = true;
        }

        private void setMouseHook(object sender, EventArgs e)
        {
            blocked = false;
        }
    }
}
