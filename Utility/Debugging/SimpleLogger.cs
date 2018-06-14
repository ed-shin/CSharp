using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Utility.Debugging
{
    public class SimpleLogger
    {
        private static StringBuilder sb = new StringBuilder();
        private static StringBuilder subSb = new StringBuilder();

        private static readonly string _appLocalDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string _appName = Application.ProductName;
        private static string _logDir = Path.Combine(_appLocalDirectory, _appName);
        private static string _logName
        {
            get { return string.Format("{0}_log.txt", DateTime.Now.ToString("yyyy-MM-dd")); }
        }
        
        public static string LogDirectory
        {
            get { return _logDir; }
            set { _logDir = value; }
        }

        public static int StackDepth = 2;
        public static bool bNeedFileInfo = false;

        
        /// <summary>
        /// when writing, append sub text
        /// </summary>
        public static void AppenText(string text)
        {
            subSb.AppendFormat("{0}\t{1}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), text);
        }

        /// <summary>
        /// single call stack, write log
        /// </summary>
        public static void SimpleWrite(string text)
        {
            StackTrace st = new StackTrace(bNeedFileInfo);
            if (st.FrameCount > 1)
            {
                StackFrame sf = st.GetFrame(1);
                sb.AppendFormat("{0}\t[{1}.{2}]\t{3}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), getClassName(sf), getMethodName(sf), text);
            }

            write();
        }
        public static void Write(string text, bool isError = false)
        {
            //StackFrame 0: current
            StackTrace st = new StackTrace(bNeedFileInfo);

            if (isError)
                sb.Append("[Error]\n");

            StackFrame[] frames = st.GetFrames();
            int depth = frames.Length - 1 < StackDepth ? frames.Length - 1 : StackDepth;    //length to index
            for (int i = 2; i <= depth; i++)
            {
                StackFrame frame = frames[i];
                sb.AppendFormat("{0}\t[{1}.{2}]\n", getNormalDateText(), getClassName(frame), getMethodName(frame));
            }

            if (frames.Length > 1)
            {
                StackFrame sf = frames[1];
                sb.AppendFormat("{0}\t[{1}.{2}]\t{3}\n", getNormalDateText(), getClassName(sf), getMethodName(sf), text);
            }

            write();
        }

        private static void write()
        {
            string logFile = Path.Combine(_logDir, _logName);
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.Write(sb.ToString());

                if (subSb.Length > 0)
                    sw.Write(subSb.ToString());
            }

            sb.Clear();
            subSb.Clear();
        }

        private static string getNormalDateText()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static string getClassName(StackFrame sf)
        {
            return sf.GetMethod().DeclaringType.ToString();
        }

        private static string getMethodName(StackFrame sf)
        {
            return sf.GetMethod().Name;
        }
    }
}
