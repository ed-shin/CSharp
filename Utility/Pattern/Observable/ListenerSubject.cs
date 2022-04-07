using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Observable
{
    /// <summary>
    /// 특정 주제의 값을 모니터링 할 수 있도록 지원하는 객체
    /// </summary>
    public class ListenerSubject : IDisposable
    {
        private HashSet<IListenerObserver<ListenerSubject>> _listeners = new HashSet<IListenerObserver<ListenerSubject>>();

        /// <summary>
        /// Listener를 추가합니다.
        /// </summary>
        public virtual void Add(IListenerObserver<ListenerSubject> sender)
        {
            _listeners.Add(sender);
        }

        /// <summary>
        /// Listener를 제거합니다.
        /// </summary>
        public virtual void Remove(IListenerObserver<ListenerSubject> sender)
        {
            _listeners.Remove(sender);
        }

        /// <summary>
        /// 등록된 모든 Listener에 값을 알립니다.
        /// </summary>
        /// <param name="value">외부에서 호출된 값</param>
        public void Notify(object value)
        {
            foreach (var listener in _listeners)
            {
                listener.Listen(value);
            }
        }

        public void Dispose()
        {
            _listeners.Clear();
            _listeners = null;
        }
    }
}
