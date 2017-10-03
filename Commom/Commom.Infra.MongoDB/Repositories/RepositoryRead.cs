using Commom.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Commom.Infra.MongoDB.Repositories
{
    public class RepositoryRead<TPrimaryKeyType, TEntity> where TEntity : IEntityBase<TPrimaryKeyType>
    {
        MongoDatabase _db = null;
        public RepositoryRead(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork.GetSession<MongoDatabase>();
        }

        public TEntity GetById(string id)
        {
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
            var entity = col.FindAllAs<TEntity>().SingleOrDefault(u => u.Id.Equals(id));
            return entity;
        }

        public List<TEntity> GetAll()
        {
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
            var entity = col.FindAllAs<TEntity>();
            return entity.ToList();
        }

        public List<TEntity> GetAll(System.Func<TEntity, bool> query)
        {
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
            var entity = col.FindAllAs<TEntity>().Where(query);
            return entity.ToList();
        }

        public TEntity First(System.Func<TEntity, bool> query)
        {
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
            return col.FindAllAs<TEntity>().FirstOrDefault(query);
        }
    }
}
