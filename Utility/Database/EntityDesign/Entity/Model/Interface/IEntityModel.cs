using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    public interface IEntityModel : IEntityTable
    {
        /// <summary>
        /// Table과 맵핑되는 Entity 객체의 ID 속성
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// DataReader로 부터 Enitty 객체를 생성시 해당 함수를 호출합니다.
        /// </summary>
        void SetRow(object[] row);
        /// <summary>
        /// Entity 객체로 부터 쿼리를 생성시 해당 함수를 호출합니다.
        /// </summary>
        object[] GetRow();
    }
}
