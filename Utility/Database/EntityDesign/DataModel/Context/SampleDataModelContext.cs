using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDEN.Utility.Data.DataModel
{
    public partial class SampleDataModelContext<T> : DataModelContext<T> where T : SampleModel
    {
        private SampleEntityContext<SampleEntity> _entityContext = null;
        private SampleEntityContext<SampleEntity> entityContext
        {
            get
            {
                if (_entityContext == null)
                    _entityContext = new SampleEntityContext<SampleEntity>(_owner.DbPath);
                return _entityContext;
            }
        }

        private DataModelContextHandler _owner = null;
        public SampleDataModelContext(DataModelContextHandler owner)
        {
            _owner = owner;
        }


        public SampleModel[] GetAll()
        {
            SampleEntity[] entities = entityContext.SelectAll();
            SampleModel[] models = entities.Select(x => new SampleModel(x)).ToArray();

            return base.Apply((T[])models);
        }

        public SampleModel GetByKey(Guid id)
        {
            SampleEntity entity = entityContext.SelectByKey(id);
            SampleModel model = new SampleModel(entity);

            return base.Apply((T)model);
        }
        
        public override void Close()
        {
            if (_entityContext != null)
                _entityContext.Dispose();
        }
    }

    public partial class SampleDataModelContext<T>
    {
        public SampleModel[] GetByName(string name)
        {
            SampleEntity[] entities = entityContext.SelectByName(name);
            SampleModel[] models = entities.Select(x => new SampleModel(x)).ToArray();

            return base.Apply((T[])models);
        }
    }
}
