using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class CustomTitleBar : UserControl
    {
        private bool onDrag = false;
        private Point prevPt = Point.Empty;

        public String Title
        {
            get { return this.lbTitle.Text; }
            set
            {
                this.lbTitle.Text = value;
                this.lbTitle.Invalidate();
            }
        }

        public CustomTitleBar()
        {
            InitializeComponent();

            this.lbTitle.Paint += LbTitle_Paint;
        }

        private void LbTitle_Paint(object sender, PaintEventArgs e)
        {
            SizeF strSize = e.Graphics.MeasureString(this.lbTitle.Text, this.lbTitle.Font);
            this.lbTitle.Size = new Size((int)strSize.Width + 10, this.lbTitle.Size.Height);
        }

        private void CustomTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.onDrag = true;
                this.prevPt = e.Location;
            }
        }

        private void CustomTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.onDrag = false;
        }
        
        private void CustomTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.onDrag)
            {
                Point dPt = e.Location - new Size(prevPt.X, prevPt.Y);
                this.ParentForm.Location += new Size(dPt.X, dPt.Y);
            }
        }

        private void CustomTitleBar_MouseHover(object sender, EventArgs e)
        {
            this.lbTitle.ForeColor = Color.FromArgb(0, 64, 64);
        }

        private void CustomTitleBar_MouseLeave(object sender, EventArgs e)
        {
            this.lbTitle.ForeColor = Color.FromArgb(114, 114, 114);
        }

        private void picBtnMinimize_MouseHover(object sender, EventArgs e)
        {
            picBtnMinimize.Image = Properties.Resources.minimize_green;
        }

        private void picBtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            picBtnMinimize.Image = Properties.Resources.minimize_gray;
        }

        private void picBtnClose_MouseHover(object sender, EventArgs e)
        {
            picBtnClose.Image = Properties.Resources.close_green;
        }

        private void picBtnClose_MouseLeave(object sender, EventArgs e)
        {
            picBtnClose.Image = Properties.Resources.close_gray;
        }

        private void picBtnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void picBtnMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}
