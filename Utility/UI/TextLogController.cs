using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Utiltiy.UI
{
    public class TextLogController
    {
        private RichTextBox _control;

        public RichTextBox Control { get { return _control; } }

        public TextLogController(RichTextBox control)
        {
            _control = control;
        }

        public void SetTextWithSystem(string title, string content)
        {
            string text = string.Format("{0}   {1}\t{2}", DateTime.Now.ToString("HH:mm:ss"), title, content);
            this.SetText(text);
        }

        public void SetTextWithError(string title, string content)
        {
            string text = string.Format("{0}   {1}\tError: {2}", DateTime.Now.ToString("HH:mm:ss"), title, content);
            this.SetText(text);
        }

        public void SetText(string text)
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(new MethodInvoker(delegate
                {
                    SetText(text);
                }));
            }
            else
            {
                if (_control.Lines.Length > 500)
                {
                    List<string> content = _control.Lines.ToList();
                    content.RemoveAt(0);

                    _control.Lines = content.ToArray();
                }

                _control.AppendText(text + "\n");
                _control.ScrollToCaret();
                _control.Update();
            }
        }

        public void Clear()
        {
            _control.Clear();
        }
    }
}
