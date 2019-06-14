using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.VO
{
    public partial class ResponseVO<T> where T : IResponseVO
    {
        public int code { get; set; }
        public string message { get; set; }
        public T result { get; set; }
    }

    public interface IResponseVO
    {
    }
}
