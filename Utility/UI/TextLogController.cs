﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Utiltiy.UI
{
    /// <summary>
    /// Rich Text Box Logging Controller
    /// </summary>
    public class TextLogController
    {
        private RichTextBox _control;
        private int _limit;

        public RichTextBox Control { get { return _control; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="limite">limit show log lines</param>
        public TextLogController(RichTextBox control, int limite = 500)
        {
            _control = control;
            _limit = limite;
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
                if (_control.Lines.Length > _limit)
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
