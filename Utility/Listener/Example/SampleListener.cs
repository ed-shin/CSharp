using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Listener.Example
{
    class SampleListener : IListenerContextDelegate<SampleSubject>, IDisposable
    {
        SampleListener()
        {
            // Subject를 등록합니다.
            ListenerContext.AddSubject(new SampleSubject());

            // Listener를 등록합니다.
            ListenerContext.BindListener<SampleSubject>(this);
        }

        public void Listen(object value)
        {
            // TODO: 외부에서 변경된 값을 받을 수 있는 로직 구현
        }

        public void Dispose()
        {
            // 등록된 Listener 해제 합니다.
            ListenerContext.UnbindListener<SampleSubject>(this);

            // 등록된 Subject를 제거합니다.
            ListenerContext.RemoveSubject<SampleSubject>();
        }
    }
}
