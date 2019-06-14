using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    internal partial class SampleEntityContext<T> : EntityContext<T> where T : SampleEntity, new()
    {
        internal SampleEntityContext(string path) : base(path) { }
    }

    // select
    internal partial class SampleEntityContext<T>
    {
        internal T[] SelectByName(string name)
        {
            List<T> models = new List<T>();

            T sample = (T)entity;
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", sample.TableName, sample.NameColumn, name);
            using (var controller = GetEntityController())
            {
                var values = controller.Connection.Select(sql, sample.Columns.Length);
                foreach (var value in values)
                {
                    T model = new T();
                    model.SetRow(value);
                    models.Add(model);
                }
            }

            return models.ToArray();
        }
    }

    // insert
    internal partial class SampleEntityContext<T>
    {

    }

    // update
    internal partial class SampleEntityContext<T>
    {

    }

    // delete
    internal partial class SampleEntityContext<T>
    {

    }
}
