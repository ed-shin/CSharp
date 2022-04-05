using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Pattern
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), true) as T);

        public static T Instance 
        { 
            get { return _instance.Value; } 
        }
    }
}
