using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Listener
{
    /// <summary>
    /// 특정 주제의 값을 모니터링 할 수 있도록 지원하는 객체
    /// </summary>
    public class ListenerSubject : IDisposable
    {
        private HashSet<IListenerContextDelegate<ListenerSubject>> _listeners = new HashSet<IListenerContextDelegate<ListenerSubject>>();

        /// <summary>
        /// Listener를 추가합니다.
        /// </summary>
        public void Add(IListenerContextDelegate<ListenerSubject> sender)
        {
            _listeners.Add(sender);
        }

        /// <summary>
        /// Listener를 제거합니다.
        /// </summary>
        public void Remove(IListenerContextDelegate<ListenerSubject> sender)
        {
            _listeners.Remove(sender);
        }

        /// <summary>
        /// 등록된 모든 Listener에 값을 반환합니다.
        /// </summary>
        /// <param name="value">외부에서 호출된 값</param>
        protected void Call(object value)
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
