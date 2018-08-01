using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Utility.Threading
{
    /// <summary>
    /// Thread Example
    /// </summary>
    public class AsyncThread
    {
        public delegate void AsyncThreadDelegate(Queue<object> objs);
        public AsyncCallback CallBackDelegate = null;

        private AsyncThreadDelegate _dlgt = null;
        private Thread _thread = null;
        private bool _running = false;
        private int _duration = 1;

        private Queue<object> _queue = null;
        public Queue<object> AsyncQueue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        public bool Running
        {
            get { return _running; }
        }

        public int ThreadId
        {
            get
            {
                if (_thread == null)
                    return -1;
                else
                    return _thread.ManagedThreadId;
            }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public AsyncThread(AsyncThreadDelegate dlgt)
        {
            _queue = new Queue<object>();
        }

        public void SetMethod(AsyncThreadDelegate dlgt)
        {
            _dlgt = dlgt;
        }

        void run()
        {
            try
            {
                while (_running)
                {
                    if (_queue.Count > 0)
                    {
                        IAsyncResult result = _dlgt.BeginInvoke(_queue, CallBackDelegate, null);
                        _dlgt.EndInvoke(result);
                    }

                    Thread.Sleep(_duration);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Start()
        {
            if (_thread == null)
            {
                _running = true;

                _thread = new Thread(new ThreadStart(run));
                _thread.Start();
            }
        }

        public void Stop()
        {
            _running = false;

            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }
        }
    }
}
