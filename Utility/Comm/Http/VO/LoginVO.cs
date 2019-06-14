using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.VO
{
    public partial class RequestVO
    {
        public class Login
        {
            public string loginId { get; set; }
            public string loginPw { get; set; }
        }
    }

    public partial class ResponseVO
    {
        public class Login : IResponseVO
        {
            public string userId { get; set; }
            public string loginId { get; set; }
            public string name { get; set; }
        }
    }
}
