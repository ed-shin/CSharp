using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility.UI
{
    /// <summary>
    /// Custom List View Example
    /// </summary>
    public class CustomDetailsListView : ListView
    {
        private ListViewItem beforeFocusedItem = null;
        
        public CustomDetailsListView()
        {
            this.Columns.Add("");

            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
            this.View = View.Details;
            this.Scrollable = false;
            this.HeaderStyle = ColumnHeaderStyle.None;
            this.BackColor = System.Drawing.Color.White;
            this.FullRowSelect = true;
            this.DoubleBuffered = true;

            this.SizeChanged += CustomDetailsListView_SizeChanged;
            this.MouseMove += CustomDetailsListView_MouseMove;
        }

        /// <summary>
        /// Change item's color on mouse hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDetailsListView_MouseMove(object sender, MouseEventArgs e)
        {
            //var p = this.PointToClient(MousePosition);
            ListViewItem item = this.GetItemAt(e.Location.X, e.Location.Y);
            if(item != null)
            {
                if (beforeFocusedItem == item)
                    return;

                item.ForeColor = System.Drawing.Color.Blue;
                item.BackColor = System.Drawing.Color.WhiteSmoke;

                if (beforeFocusedItem != null)
                {
                    beforeFocusedItem.ForeColor = System.Drawing.Color.Black;
                    beforeFocusedItem.BackColor = System.Drawing.Color.Transparent;
                }

                beforeFocusedItem = item;
            }
        }

        private void CustomDetailsListView_SizeChanged(object sender, EventArgs e)
        {
            if (this.Columns.Count > 0)
            {
                this.Columns[0].Width = this.Width;
            }
        }
    }
}
