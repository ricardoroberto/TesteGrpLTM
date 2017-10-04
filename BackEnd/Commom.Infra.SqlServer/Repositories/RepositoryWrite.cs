using Commom.Contracts;
using System.Data.Entity;
using System.Linq;

namespace Commom.Infra.SqlServer.Repositories
{
    public class RepositoryWrite<TPrimaryKeyType, TEntity> where TEntity : class, IEntityBase<TPrimaryKeyType>
    {
        protected DbContext _db = null;
        public RepositoryWrite(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork.GetSession<DbContext>();
        }

        private TEntity GetById(TPrimaryKeyType id)
        {
            var entity = _db.Set<TEntity>().SingleOrDefault(u => u.Id.Equals(id));
            return entity;
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
            if (exist != null)
            {
                var entry = _db.Set<TEntity>();
                entry.Remove(exist);
            }
        }
    }
}
