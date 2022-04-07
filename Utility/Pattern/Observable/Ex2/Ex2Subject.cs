using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Observable.Ex2
{
    class Ex2Subject : ListenerSubject
    {
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
    }
}
