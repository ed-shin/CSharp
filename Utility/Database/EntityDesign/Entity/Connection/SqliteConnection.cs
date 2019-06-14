using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    internal class SqliteConnection : IConnection, IDisposable
    {
        private SQLiteConnection _conn = null;
        private SQLiteCommand _cmd = null;
        private SQLiteTransaction _tran = null;

        public bool IsConnected
        {
            get
            {
                if (_conn == null)
                    return false;

                return _conn.State == ConnectionState.Open;
            }
        }

        public bool IsTransactioning
        {
            get
            {
                return _tran != null;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return _cmd;
            }
        }

        public SqliteConnection()
        {

        }

        public IDbTransaction BeginTrans()
        {
            _tran = _conn.BeginTransaction();
            _cmd.Transaction = _tran;
            return _tran;
        }

        public void Commit()
        {
            _tran.Commit();
            _tran = null;

            _cmd.Transaction = null;
        }

        public void Rollback()
        {
            _tran.Rollback();
            _tran = null;

            _cmd.Transaction = null;
        }

        public bool Connect(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    SQLiteConnection.CreateFile(path);
                }

                if (!IsConnected)
                {
                    string connectionString = string.Format("Data Source={0};", path);
                    connectionString += " Pooling=true;";
                    connectionString += " Max Pool Size=20;";
                    connectionString += " PRAGMA synchronous=OFF;";
                    connectionString += " PRAGMA count_changes=OFF;";
                    connectionString += " PRAGMA journal_mode=MEMORY;";
                    connectionString += " PRAGMA temp_store=MEMORY";
                    connectionString = connectionString.Trim();

                    _conn = new SQLiteConnection();
                    _conn.ConnectionString = connectionString;
                    _conn.Open();

                    _cmd = new SQLiteCommand();
                    _cmd.Connection = _conn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public void Dispose()
        {
            if (_tran != null)
            {
                _tran.Rollback();
                _tran = null;
            }

            if (_cmd != null)
            {
                _cmd.Dispose();
                _cmd = null;
            }

            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }

            SQLiteConnection.ClearAllPools();
            GC.Collect();
        }

        public IDataReader ExecuteReader(string sql)
        {
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = sql;

            IDataReader reader = _cmd.ExecuteReader();

            return reader;
        }

        public int ExecuteScalar(string sql)
        {
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = sql;

            return (int)_cmd.ExecuteScalar();
        }

        public int Execute(string sql)
        {
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = sql;

            return _cmd.ExecuteNonQuery();
        }
    }
}
