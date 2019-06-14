using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;

namespace EDEN.Utility.Data.DataModel
{
    /// <summary>
    /// Context를 관리하고 호출할 수 있도록 지원하는 사용자 전용 객체
    /// </summary>
    public partial class DataModelContextHandler
    {
        private static DataModelContextHandler _localHandler = null;
        public static DataModelContextHandler GetContext(string path)
        {
            if (_localHandler == null)
                _localHandler = new DataModelContextHandler(path);

            return _localHandler;
        }

        public static void Release()
        {
            if(_localHandler != null)
            {
                _localHandler.Dispose();
                _localHandler = null;
            }
        }
    }

    public partial class DataModelContextHandler : IDisposable
    {
        private Dictionary<Type, IDataModelContext> _modelContext = null;
        private string _dbPath = null;
        public string DbPath
        {
            get { return _dbPath; }
        }
        private DataModelContextHandler(string dbPath)
        {
            _dbPath = dbPath;

            _modelContext = new Dictionary<Type, IDataModelContext>();
            _modelContext.Add(typeof(SampleModel), new SampleDataModelContext<SampleModel>(this));
        }

        public SampleDataModelContext<SampleModel> GetSampleDataModelContext()
        {
            return _modelContext[typeof(SampleModel)] as SampleDataModelContext<SampleModel>;
        }

        public void Flush()
        {
            using (var controller = EntityConnectionHandler.GetController())
            {
                foreach (var context in _modelContext)
                {
                    context.Value.Flush(controller);
                }
            }
        }

        public void Dispose()
        {
            foreach (var contextItem in _modelContext)
            {
                contextItem.Value.Close();
            }
        }
    }
}
