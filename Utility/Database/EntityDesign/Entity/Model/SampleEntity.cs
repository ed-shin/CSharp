using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    internal partial class SampleEntity : IEntityModel
    {
        public string TableName
        {
            get { return EntityInfo.TableName.SAMPLE; }
        }

        public string PrivateKey
        {
            get { return EntityInfo.PrimaryKey.SAMPLE; }
        }

        public string[] Columns
        {
            get { return EntityInfo.Columns.SAMPLE; }
        }

        // id를 제외한 추가적인 테이블 key 속성 (쿼리 작성을 위해)
        public string NameColumn
        {
            get { return "SAMPLE_NAME"; }
        }

        public void SetRow(object[] row)
        {
            int offset = 0;

            Id = row[offset++].ToGuid();
            Name = row[offset++].ToString();
            Data = row[offset++].ToByteArray();
            Deleted = row[offset++].ToInt();
            Time = row[offset++].ToDateTime();
        }

        public object[] GetRow()
        {
            int offset = 0;
            
            object[] values = new object[this.Columns.Length];
            values[offset++] = Id.ToByteArray();
            values[offset++] = Name;
            values[offset++] = Data;
            values[offset++] = Deleted;
            values[offset++] = Time;
            return values;
        }
    }
    internal partial class SampleEntity
    {
        private Guid _id;
        private string _name;
        private byte[] _data;
        private int _deleted;
        private DateTime _time;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public byte[] Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public int Deleted
        {
            get
            {
                return _deleted;
            }

            set
            {
                _deleted = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }
    }
}
