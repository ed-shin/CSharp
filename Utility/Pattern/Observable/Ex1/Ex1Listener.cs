using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Observable;

namespace Utility.Pattern.Observable.Ex1
{
    class Ex1Listener : IEx1Observer, IDisposable
    {
        Ex1Listener()
        {
            // Subject를 등록합니다.
            ListenerContext.AddSubject(new Ex1Subject());

            // Listener를 등록합니다.
            ListenerContext.BindListener(this);
        }

        public void Dispose()
        {
            // 등록된 Listener 해제 합니다.
            ListenerContext.UnbindListener(this);

            // 등록된 Subject를 제거합니다.
            ListenerContext.RemoveSubject<Ex1Subject>();
        }

        public void Listen(object sender, int n)
        {
            // TODO: 외부에서 변경된 값을 받을 수 있는 로직 구현
            Console.WriteLine($"Listen: {n}");
        }

        public void Listen(object value)
        {
            throw new NotImplementedException();
        }
    }
}
