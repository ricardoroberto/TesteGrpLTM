using Commom.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Commom.Infra.SqlServer.Repositories
{
    public class RepositoryRead<TPrimaryKeyType, TEntity> where TEntity : class,IEntityBase<TPrimaryKeyType>
    {
        protected DbContext _db = null;

        public RepositoryRead(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork.GetSession<DbContext>();
        }

        public TEntity GetById(TPrimaryKeyType id)
        {
            var entity = _db.Set<TEntity>().SingleOrDefault(u => u.Id.Equals(id));
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
    }
}
