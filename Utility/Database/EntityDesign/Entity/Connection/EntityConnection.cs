using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// IConnection을 감싸서 IEntityModel에 적합하게 구현된 Connection 객체
    /// </summary>
    internal class EntityConnection : IEntityConnection, IDisposable
    {
        private IConnection _conn = null;

        internal bool IsConnected
        {
            get
            {
                if (_conn == null)
                    return false;

                return _conn.IsConnected;
            }
        }

        internal EntityConnection(string path)
        {
            _conn = new SqliteConnection();
            if (_conn.Connect(path) == false)
                throw new EntityException(EntityException.Code.ConnectionFail);
        }

        internal bool IsTransactioning
        {
            get { return _conn.IsTransactioning; }
        }
        internal IDbTransaction BeginTrans()
        {
            return _conn.BeginTrans();
        }
        public void Commit()
        {
            _conn.Commit();
        }
        public void Rollback()
        {
            _conn.Rollback();
        }

        // Query
        internal int Execute(string sql)
        {
            return _conn.Execute(sql);
        }
        internal int ExecuteScalar(string sql)
        {
            return _conn.ExecuteScalar(sql);
        }
        internal IDataReader ExecuteReader(string sql)
        {
            return _conn.ExecuteReader(sql);
        }

        internal List<object[]> Select(string sql, int columnCount)
        {
            List<object[]> values = new List<object[]>();

            using (var reader = _conn.ExecuteReader(sql))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        object[] value = new object[columnCount];
                        if (reader.GetValues(value) > 0)
                        {
                            values.Add(value);
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

            return values;
        }

        public int Insert(IEntityModel entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("INSERT INTO {0}", entity.TableName);
            sql.AppendFormat(" VALUES ( {0} )", string.Join(" , ", entity.Columns.Select(x => "?")));

            SQLiteCommand cmd = _conn.Command as SQLiteCommand;
            cmd.CommandText = sql.ToString();
            cmd.Parameters.Clear();

            object[] values = entity.GetRow();
            for (int i = 0; i < values.Length; i++)
            {
                var param = cmd.CreateParameter();
                param.Value = values[i];

                cmd.Parameters.Add(param);
            }

            return cmd.ExecuteNonQuery();
        }

        public int Insert(IEntityModel[] entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("INSERT INTO {0}", entity[0].TableName);
            sql.AppendFormat(" VALUES ( {0} )", string.Join(" , ", entity[0].Columns.Select(x => "?")));

            SQLiteCommand cmd = _conn.Command as SQLiteCommand;
            cmd.CommandText = sql.ToString();
            cmd.Parameters.Clear();

            int n = 0;
            for (int i = 0; i < entity[0].Columns.Length; i++)
            {
                var param = cmd.CreateParameter();
                cmd.Parameters.Add(param);
            }

            for (int i = 0; i < entity.Length; i++)
            {
                object[] row = entity[i].GetRow();
                for (int j = 0; j < row.Length; j++)
                {
                    cmd.Parameters[j].Value = row[j];
                }

                n += cmd.ExecuteNonQuery();
            }

            return n;
        }

        public int Update(IEntityModel entity)
        {
            var columns = entity.Columns.Where(x => x != entity.PrivateKey);

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE {0}", entity.TableName);
            sql.AppendFormat(" SET {0}", string.Join(" , ", columns.Select(x => x + " = ?")));
            sql.AppendFormat(" WHERE {0} = ?", entity.PrivateKey);

            SQLiteCommand cmd = _conn.Command as SQLiteCommand;
            cmd.CommandText = sql.ToString();
            cmd.Parameters.Clear();

            object[] values = entity.GetRow();
            for (int i = 0; i < values.Length; i++)
            {
                var param = cmd.CreateParameter();
                param.Value = values[i];

                cmd.Parameters.Add(param);
            }

            var keyparam = cmd.Parameters[0];
            cmd.Parameters.Add(keyparam);
            cmd.Parameters.RemoveAt(0);

            return cmd.ExecuteNonQuery();
        }

        public int Update(IEntityModel[] entity)
        {
            int d, i;
            d = Delete(entity);
            i = Insert(entity);
            return i;
        }

        public int Delete(IEntityModel entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM {0}", entity.TableName);
            sql.AppendFormat(" WHERE {0} = ?", entity.PrivateKey);

            SQLiteCommand cmd = _conn.Command as SQLiteCommand;
            cmd.CommandText = sql.ToString();
            cmd.Parameters.Clear();

            var param = cmd.CreateParameter();
            param.Value = entity.Id.ToByteArray();

            cmd.Parameters.Add(param);

            return cmd.ExecuteNonQuery();
        }

        public int Delete(IEntityModel[] entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM {0}", entity[0].TableName);
            sql.AppendFormat(" WHERE {0}", entity[0].PrivateKey);
            sql.AppendFormat(" IN ( {0} )", string.Join(" , ", entity.Select(x => x.Id.ToDbString())));

            return Execute(sql.ToString());
        }

        internal DataTable GetScheme(string tableName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM {0}", tableName);

            List<DataColumn> pk = new List<DataColumn>();
            DataTable result = new DataTable(tableName);
            using (var reader = _conn.ExecuteReader(sql.ToString()))
            {
                DataTable scheme = reader.GetSchemaTable();

                foreach (DataRow row in scheme.Rows)
                {
                    string colName = row["ColumnName"].ToString();
                    Type colType = (Type)row["DataType"];

                    DataColumn col = new DataColumn(colName, colType);
                    col.Unique = (bool)row["IsUnique"];
                    col.AllowDBNull = (bool)row["AllowDBNull"];
                    col.AutoIncrement = (bool)row["IsAutoIncrement"];

                    if (row["IsKey"].GetType() != typeof(DBNull) && (bool)(row["IsKey"]) == true)
                        pk.Add(col);

                    result.Columns.Add(col);
                }

                if (pk.Count > 0)
                    result.PrimaryKey = pk.ToArray();
            }

            return result;
        }

        public void Dispose()
        {
            if(_conn != null)
            {
                _conn.Dispose();
                _conn = null;
            }
        }
    }
}
