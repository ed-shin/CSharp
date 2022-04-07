using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Observable.Ex2
{
    class Ex2Listener : IListenerObserver<Ex2Subject>, IDisposable
    {
        Ex2Listener()
        {
            // Subject를 등록합니다.
            ListenerContext.AddSubject(new Ex2Subject());

            // Listener를 등록합니다.
            ListenerContext.BindListener<Ex2Subject>(this);
        }

        public void Listen(object value)
        {
            // TODO: 외부에서 변경된 값을 받을 수 있는 로직 구현
            Console.WriteLine($"Listen: {value}");
        }

        public void Dispose()
        {
            // 등록된 Listener 해제 합니다.
            ListenerContext.UnbindListener<Ex2Subject>(this);

            // 등록된 Subject를 제거합니다.
            ListenerContext.RemoveSubject<Ex2Subject>();
        }
    }
}
