using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    public class EntityConnectionHandler
    {
        private static EntityConnection _conn = null;
        private static int _using = 0;
        
        public static bool Using
        {
            get { return _using > 0; }
        }

        public static bool Connect(string path)
        {
            if (_conn == null)
            {
                _conn = new EntityConnection(path);

                if (_conn.IsConnected)
                    EntityInfo.Load(_conn);
                else
                    _conn = null;
            }

            return _conn != null;
        }

        public static void Disconnect()
        {
            if(_conn != null)
            {
                _conn.Dispose();
                _conn = null;
            }
        }

        public static EntityController GetController()
        {
            if (_conn != null)
                _using++;

            return new EntityController(_conn);
        }

        internal static void ReturnConnection()
        {
            _using--;
        }
    }

    /// <summary>
    /// Connection의 리소스를 사용 후 반환하기 위한 용도의 객체
    /// </summary>
    public class EntityController : ITransactionController
    {
        private EntityConnection _conn;

        internal EntityConnection Connection
        {
            get { return _conn; }
        }

        internal EntityController(EntityConnection conn)
        {
            _conn = conn;
        }

        public void Dispose()
        {
            _conn = null;

            EntityConnectionHandler.ReturnConnection();
        }

        public IDbTransaction Begin()
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

        public int Insert(IEntityModel entity)
        {
            return _conn.Insert(entity);
        }

        public int Update(IEntityModel entity)
        {
            return _conn.Update(entity);
        }

        public int Delete(IEntityModel entity)
        {
            return _conn.Delete(entity);
        }

        public int Insert(IEntityModel[] entity)
        {
            return _conn.Insert(entity);
        }

        public int Update(IEntityModel[] entity)
        {
            return _conn.Update(entity);
        }

        public int Delete(IEntityModel[] entity)
        {
            return _conn.Delete(entity);
        }
    }
}
