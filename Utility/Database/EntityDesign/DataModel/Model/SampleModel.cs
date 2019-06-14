using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDEN.Utility.Data.DataModel
{
    public partial class SampleModel : IDataModel
    {
        private SampleEntity _entity = null;

        /// <summary>
        /// 새로운 객체를 생성합니다.
        /// </summary>
        public SampleModel()
        {
            _entity = new SampleEntity();
        }

        /// <summary>
        /// 기존 DB에 생성된 객체를 가져옵니다.
        /// </summary>
        /// <param name="entity"></param>
        public SampleModel(IEntityModel entity)
        {
            _entity = (SampleEntity)entity;
        }

        public IEntityModel ToEntityModel()
        {
            return _entity;
        }
    }

    public partial class SampleModel
    {
        public Guid Id
        {
            get { return _entity.Id; }
            set { _entity.Id = value; }
        }

        public String Name
        {
            get { return _entity.Name; }
            set { _entity.Name = value; }
        }

        public bool Deleted
        {
            get { return _entity.Deleted > 0 ? true : false; }
            set { _entity.Deleted = value.ToInt(); }
        }

        public DateTime Time
        {
            get { return _entity.Time; }
            set { _entity.Time = value; }
        }
    }
}
