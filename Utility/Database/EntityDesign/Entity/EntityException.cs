using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// Entity 레이어 영역에서 발생한 예외
    /// </summary>
    public class EntityException : Exception
    {
        public enum Code : int
        {
            ConnectionFail = 101,
            
        }

        private Code code;
        private string message;
        private Exception innerException;

        public EntityException(Code code)
        {
            this.code = code;
        }

        public EntityException(Code code, string message)
        {
            this.code = code;
            this.message = message;
        }
        public EntityException(Code code, Exception innerException)
        {
            this.code = code;
            this.innerException = innerException;
        }
    }
}
