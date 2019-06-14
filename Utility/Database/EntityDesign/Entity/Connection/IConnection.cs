using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// 가장 하단 레이어 영역의 Connection 객체
    /// </summary>
    internal interface IConnection : IDisposable
    {
        bool IsConnected { get; }
        bool Connect(string path);
        IDbCommand Command { get; }

        // Transaction
        bool IsTransactioning { get; }
        IDbTransaction BeginTrans();
        void Commit();
        void Rollback();

        // Query
        int Execute(string sql);
        int ExecuteScalar(string sql);
        IDataReader ExecuteReader(string sql);
    }
}
