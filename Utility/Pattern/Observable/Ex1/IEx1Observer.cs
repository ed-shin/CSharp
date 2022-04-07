using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Observable;

namespace Utility.Pattern.Observable.Ex1
{
    internal interface IEx1Observer : IListenerObserver<Ex1Subject>
    {
        void Listen(object sender, int n);
    }
}
