using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Utility.Database.Access
{
    public interface IDataAccess : IDisposable
    {
        IPropertySet PropertySet { get; set; }
        bool Connected { get; }
        bool Connect();
        bool HasTable(string tableName);
        bool ExecuteNonQuery(string query);
        IDataReader ExecuteReader(string query);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
