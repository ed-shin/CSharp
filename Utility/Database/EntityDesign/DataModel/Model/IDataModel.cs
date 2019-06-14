using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.DataModel
{
    /// <summary>
    /// 모든 영역의 레이어에서 데이터 전달을 위해 사용하는 데이터 모델 객체
    /// </summary>
    public interface IDataModel
    {
        /// <summary>
        /// 데이터의 ID (Entity의 ID)
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// 데이터 모델로부터 Entity Model을 가져옵니다.
        /// </summary>
        IEntityModel ToEntityModel();
    }
}
