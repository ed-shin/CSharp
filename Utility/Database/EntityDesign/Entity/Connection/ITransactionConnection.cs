using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// Transaction 상태의 Connection을 담은 객체
    /// </summary>
    public interface ITransactionController : IDisposable
    {
        IDbTransaction Begin();
        void Commit();
        void Rollback();

        int Insert(IEntityModel entity);
        int Update(IEntityModel entity);
        int Delete(IEntityModel entity);

        int Insert(IEntityModel[] entity);
        int Update(IEntityModel[] entity);
        int Delete(IEntityModel[] entity);
    }
}
