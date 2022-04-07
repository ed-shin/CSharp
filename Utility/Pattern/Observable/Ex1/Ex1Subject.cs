using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Observable;
using Utility.Pattern.Observable.Ex1;

namespace Utility.Pattern.Observable.Ex1
{
    class Ex1Subject : ListenerSubject
    {
        private HashSet<IEx1Observer> _listeners = new HashSet<IEx1Observer> ();

        private int _value = 0;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;

                // 변경된 내용을 등록된 Listener에게 sync로 알리는 경우
                Notify(value);

                // 변경된 내용을 등록된 Listener에게 async로 알리는 경우
                Task.Run(() => Notify(value));
            }
        }

        public void Notify(object sender, int n)
        {
            foreach (var listener in _listeners)
            {
                listener.Listen(sender, n);
            }
        }
    }
}
