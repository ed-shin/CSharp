using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Utility.Database.Access
{
    /*
        using library
        - SQLite.Interop.dll
        - System.Data.SQLite.dll (refrence)
    */

    public class SQLiteAccess : IDataAccess
    {
        private SQLiteConnection _conn = null;
        private SQLiteCommand _cmd = null;
        private SQLiteTransaction _tran = null;

        public IPropertySet PropertySet { get; set; }
        public bool Connected
        {
            get
            {
                if (_conn == null)
                    return false;

                return _conn.State == ConnectionState.Open;
            }
        }

        public SQLiteAccess()
        {
            _conn = new SQLiteConnection();

            _cmd = new SQLiteCommand();
            _cmd.Connection = _conn;
        }

        public bool Connect()
        {
            try
            {
                if (!File.Exists(PropertySet.Database))
                {
                    SQLiteConnection.CreateFile(PropertySet.Database);
                }

                if (!Connected)
                {
                    _conn.ConnectionString = PropertySet.ConnectionString;
                    _conn.Open();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool HasTable(string tableName)
        {
            string query = string.Format(@"select count(*) from sqlite_master Where Name = '{0}'", tableName);

            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = query;

            bool rc = Convert.ToInt32(_cmd.ExecuteScalar()) > 0;

            return rc;
        }

        public bool ExecuteNonQuery(string query)
        {
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = query;

            bool error = _cmd.ExecuteNonQuery() < 0;

            return !error;
        }

        public IDataReader ExecuteReader(string query)
        {
            try
            {
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = query;

                IDataReader reader = _cmd.ExecuteReader();

                return reader;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void BeginTransaction()
        {
            _tran = _conn.BeginTransaction();
            _cmd.Transaction = _tran;
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

        public void Dispose()
        {
            if (_tran != null)
            {
                _tran.Rollback();
                _tran = null;
            }
            
            _cmd.Dispose();
            _cmd = null;

            _conn.Close();
            _conn.Dispose();
            _conn = null;
        }
    }
}
