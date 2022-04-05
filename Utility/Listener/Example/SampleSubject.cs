using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Listener.Example
{
    class SampleSubject : ListenerSubject
    {
        private int curValue = 0;

        public void SetArg(int newValue)
        {
            curValue = newValue;

            // 변경된 내용을 등록된 Listener에게 sync로 알리는 경우
            Call(newValue);

            // 변경된 내용을 등록된 Listener에게 async로 알리는 경우
            Task.Run(() => Call(newValue));

            // Rx 라이브러리를 이용하는 경우
            //public IReactiveProperty<T> prop { get; set; }
            //public SampleSubject()
            //{
            //    this.prop.Subscribe(newProp => Call(newProp));
            //}
        }
    }
}
