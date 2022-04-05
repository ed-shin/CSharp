using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Pattern;

namespace Utility.Listener
{
    /// <summary>
    /// 특정 Subject와 Listener간 이벤트 연결을 지원하는 객체
    /// </summary>
    public static class ListenerContext
    {
        private static readonly List<ListenerSubject> _subjects = new List<ListenerSubject>();

        /// <summary>
        /// Subject를 추가합니다.
        /// </summary>
        public static void AddSubject(ListenerSubject subject)
        {
            var oldSubject = _subjects.FirstOrDefault(sub => sub.GetType() == subject.GetType());
            if (oldSubject != null)
                _subjects.Remove(oldSubject);

            _subjects.Add(subject);
        }

        /// <summary>
        /// Subject를 제거합니다.
        /// </summary>
        public static void RemoveSubject<T>() where T : ListenerSubject
        {
            var subject = _subjects.FirstOrDefault(sub => sub.GetType() == typeof(T));
            if (subject != null)
                _subjects.Remove(subject);
        }

        /// <summary>
        /// Context에 추가된 Subject를 가져옵니다.
        /// </summary>
        public static T Get<T>() where T : ListenerSubject
        {
            return (T)_subjects.First(sub => sub.GetType() == typeof(T));
        }

        /// <summary>
        /// Subject에 Listener를 바인딩합니다
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static void BindListener<T>(IListenerContextDelegate<T> listener) where T : ListenerSubject
        {
            var subject = _subjects.First(sub => sub.GetType() == typeof(T));
            if (subject != null)
                subject.Add(listener);
            else
                throw new ArgumentException("Couldn't bind listener, because subject is not added");
        }

        /// <summary>
        /// Subject에 바인딩된 Listener를 해제합니다
        /// </summary>
        public static void UnbindListener<T>(IListenerContextDelegate<T> listener) where T : ListenerSubject
        {
            var subject = _subjects.First(sub => sub.GetType() == typeof(T));
            if (subject != null)
                subject.Remove(listener);
        }

        public static void Clear()
        {
            _subjects.Clear();
        }
    }
}
