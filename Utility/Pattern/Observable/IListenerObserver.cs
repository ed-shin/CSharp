using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Observable
{
    /// <summary>
    /// 외부 이벤트로 인해 변경된 Subject 값을 참조하기 위한 Obserser 
    /// </summary>
    public interface IListenerObserver<out T> where T : ListenerSubject
    {
        void Listen(object value);
    }
}
