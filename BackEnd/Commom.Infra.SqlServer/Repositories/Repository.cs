using Commom.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Commom.Infra.SqlServer.Repositories
{
    public class Repository<TPrimaryKeyType, TEntity> where TEntity : class, IEntityBase<TPrimaryKeyType>
    {
        protected DbContext _db = null;
        public Repository(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork.GetSession<DbContext>();
        }

        public TEntity GetById(TPrimaryKeyType id)
        {
            var list = _db.Set<TEntity>().Where(u => u.Id.ToString() == id.ToString());
            var entity = list.Count() > 0 ? list.First() : null;
            return entity;
        }

        public List<TEntity> GetAll()
        {
            var entity = _db.Set<TEntity>();
            return entity.ToList();
        }

        public List<TEntity> GetAll(System.Func<TEntity, bool> query)
        {
            var entity = _db.Set<TEntity>().Where(query);
            return entity.ToList();
        }

        public TEntity First(System.Func<TEntity, bool> query)
        {
            return _db.Set<TEntity>().FirstOrDefault(query);
        }

        public bool Any(System.Func<TEntity, bool> query)
        {
            return _db.Set<TEntity>().Any(query);
        }

        public void Create(TEntity emp)
        {
            var entry = _db.Set<TEntity>();
            entry.Add(emp);
        }

        public void Update(TEntity emp)
        {
            var entry = _db.Set<TEntity>();
            entry.Attach(emp);
        }

        public void Save(TEntity emp)
        {
            var exist = this.GetById(emp.Id);
            if (exist != null)
                this.Update(emp);
            else
                this.Create(emp);
        }

        public void Delete(TPrimaryKeyType id)
        {
            var exist = this.GetById(id);
            if (exist!=null)
            {
                var entry = _db.Set<TEntity>();
                entry.Remove(exist);
            }
        }
    }
}
