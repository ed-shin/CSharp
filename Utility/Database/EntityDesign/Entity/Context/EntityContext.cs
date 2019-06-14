using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// Entity 영역의 데이터를 핸들링하는 객체
    /// </summary>
    internal abstract partial class EntityContext<T> : IDisposable
    {
        protected string path = null;
        protected IEntityModel entity = null;

        protected EntityContext(string path)
        {
            this.path = path;
            this.entity = new T();
        }

        protected EntityController GetEntityController()
        {
            return EntityConnectionHandler.GetController();
        }

        public void Dispose()
        {
            this.path = null;
            this.entity = null;
        }
    }

    internal abstract partial class EntityContext<T> where T : IEntityModel, new()
    {
        internal T[] SelectAll()
        {
            List<T> models = new List<T>();

            string sql = string.Format("SELECT * FROM {0}", entity.TableName);

            using (var controller = GetEntityController())
            {
                var values = controller.Connection.Select(sql, entity.Columns.Length);
                foreach (var value in values)
                {
                    T model = new T();
                    model.SetRow(value);
                    models.Add(model);
                }
            }

            return models.ToArray();
        }

        internal T SelectByKey(Guid id)
        {
            T model = new T();

            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", entity.TableName, entity.PrivateKey, id.ToDbString());

            using (var controller = GetEntityController())
            {
                var values = controller.Connection.Select(sql, entity.Columns.Length);
                foreach (var value in values)
                {
                    model.SetRow(value);
                }
            }

            return model;
        }
    }
}
