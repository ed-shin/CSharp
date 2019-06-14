using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.DataModel
{
    // decorate DataModelContext
    public interface IDataModelContext
    {
        /// <summary>
        /// 변경된 내용을 초기화합니다.
        /// </summary>
        void Clear();
        /// <summary>
        /// 사용된 리소스를 해제합니다.
        /// </summary>
        void Close();
        /// <summary>
        /// 변경된 데이터를 일괄적으로 테이블에 적용합니다.
        /// </summary>
        void Flush(ITransactionController controller);
    }
}
