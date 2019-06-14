using EDEN.Utility.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.DataModel
{
    /// <summary>
    /// Data Model을 핸들링하기 위한 객체
    /// </summary>
    public abstract partial class DataModelContext<T> : IDataModelContext where T : IDataModel
    {
        protected Dictionary<Guid, T> models = new Dictionary<Guid, T>();
        protected Dictionary<Guid, T> insertModels = new Dictionary<Guid, T>();
        protected Dictionary<Guid, T> updateModels = new Dictionary<Guid, T>();
        protected Dictionary<Guid, T> deleteModels = new Dictionary<Guid, T>();

        protected bool IsLoaded
        {
            get { return models.Count > 0; }
        }

        protected T find(Guid id)
        {
            if (models.ContainsKey(id))
                return models[id];

            return default(T);
        }

        /// <summary>
        /// 서버로 부터 전달받은 데이터를 합친다.
        /// </summary>
        public virtual void Merge(T model)
        {
            this.update(model);
        }

        /// <summary>
        /// 서버로 부터 전달받은 데이터를 합친다.
        /// </summary>
        public virtual void MergeRange(IEnumerable<T> models)
        {
            foreach (T model in models)
            {
                Merge(model);
            }
        }

        /// <summary>
        /// 프로그램에서 신규로 생성된 데이터를 추가한다.
        /// </summary>
        public virtual void Insert(T model)
        {
            if (model.Id != Guid.Empty)
                throw new AccessViolationException();

            model.Id = Guid.NewGuid();

            this.insert(model);
        }

        public virtual void InsertRange(IEnumerable<T> models)
        {
            foreach (T model in models)
            {
                Insert(model);
            }
        }

        /// <summary>
        /// 프로그램에서 변경된 데이터를 추가한다.
        /// </summary>
        public virtual void Update(T model)
        {
            if (models.ContainsKey(model.Id))
                throw new AccessViolationException();
            
            this.update(model);
        }

        public virtual void UpdateRange(IEnumerable<T> models)
        {
            foreach (T model in models)
            {
                Update(model);
            }
        }

        /// <summary>
        /// 프로그램에서 삭제된 데이터를 추가한다.
        /// </summary>
        public virtual void Delete(T model)
        {
            this.delete(model);
        }

        public virtual void DeletetRange(IEnumerable<T> models)
        {
            foreach (T model in models)
            {
                Delete(model);
            }
        }

        public T Apply(T model)
        {
            if (model == null)
                return default(T);

            if (models.ContainsKey(model.Id))
                model = models[model.Id];

            return model;
        }

        public T[] Apply(T[] models)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < models.Length; i++)
            {
                T model = this.Apply(models[i]);
                if (model != null)
                    result.Add(model);
            }
            
            return result.ToArray();
        }

        public void Clear()
        {
            insertModels.Clear();
            updateModels.Clear();
            deleteModels.Clear();

            models.Clear();
        }

        public void Flush(ITransactionController controller)
        {
            if (insertModels.Count > 0)
            {
                var insert = insertModels.Values.Select(x => x.ToEntityModel()).ToArray();
                controller.Insert(insert);
            }
            if (updateModels.Count > 0)
            {
                var update = updateModels.Values.Select(x => x.ToEntityModel()).ToArray();
                controller.Update(update);
            }
            if (deleteModels.Count > 0)
            {
                var delete = deleteModels.Values.Select(x => x.ToEntityModel()).ToArray();
                controller.Delete(delete);
            }

            this.Clear();
        }

        public abstract void Close();
    }

    public abstract partial class DataModelContext<T>
    {
        private void insert(T model)
        {
            if (!insertModels.ContainsKey(model.Id))
                insertModels.Add(model.Id, model);

            if (!models.ContainsKey(model.Id))
                models.Add(model.Id, model);
        }

        private void update(T model)
        {
            if (insertModels.ContainsKey(model.Id))
                insertModels[model.Id] = model;

            if (updateModels.ContainsKey(model.Id))
                updateModels[model.Id] = model;
            else
                updateModels.Add(model.Id, model);

            models[model.Id] = model;
        }

        private void delete(T model)
        {
            if (insertModels.ContainsKey(model.Id))
                insertModels.Remove(model.Id);

            if (updateModels.ContainsKey(model.Id))
                updateModels.Remove(model.Id);

            if (models.ContainsKey(model.Id))
            {
                models.Remove(model.Id);

                deleteModels.Add(model.Id, model);
            }
        }
    }
}
