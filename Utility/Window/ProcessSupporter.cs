using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Utility.Window
{
    public class ProcessSupporter
    {
        public delegate void EndProcEventDelegate(object sender, Process proc);
        public event EndProcEventDelegate EndProcEvent;

        //private List<Process> _procList = new List<Process>();
        private Dictionary<int, Process> _procPool = new Dictionary<int, Process>();

        public string Add(string path, string arg = null)
        {
            string procID = Guid.NewGuid().ToString();

            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = path;

            if (arg != null)
                pInfo.Arguments = arg;

            Process p = new Process();
            p.EnableRaisingEvents = true;
            p.StartInfo = pInfo;
            p.Exited += p_Exited;

            _procPool.Add(p.Id, p);

            return procID;
        }

        public List<KeyValuePair<int, Process>> Find(string path)
        {
            return _procPool.Where(x => x.Value.StartInfo.FileName == path).ToList();
        }

        public int Find(Process p)
        {
            var result = _procPool.Where(x => x.Value == p).ToList();
            if(result.Count > 0)
            {
                return result[0].Key;
            }

            return -1;
        }
        
        public void Remove(int procID)
        {
            if (_procPool.ContainsKey(procID))
                _procPool.Remove(procID);
        }

        public void Start(int procID)
        {
            if (_procPool.ContainsKey(procID))
                _procPool[procID].Start();
        }

        public void Close(int procID)
        {
            if (_procPool.ContainsKey(procID))
                _procPool[procID].Close();
        }

        void p_Exited(object sender, EventArgs e)
        {
            Process p = sender as Process;
            
            if (EndProcEvent != null)
                EndProcEvent(sender, p);
        }
    }
}
