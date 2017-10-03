using Commom.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Commom.Infra.MongoDB.Repositories
{
    public class Repository<TPrimaryKeyType, TEntity> where TEntity : IEntityBase<TPrimaryKeyType>
    {
        protected MongoDatabase _db = null;
        string _customCOllectionName = "";
        public Repository(IUnitOfWork unitOfWork, string customCollectionName = null)
        {
            _db = unitOfWork.GetSession<MongoDatabase>();
            _customCOllectionName = customCollectionName;
        }

        public TEntity GetById(TPrimaryKeyType id)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var entity = col.FindAllAs<TEntity>().SingleOrDefault(u => u.Id.Equals(id));
            return entity;
        }

        public List<TEntity> GetAll()
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var entity = col.FindAllAs<TEntity>();
            return entity.ToList();
        }

        public List<TEntity> GetAll(System.Func<TEntity, bool> query)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var entity = col.FindAllAs<TEntity>().Where(query);
            return entity.ToList();
        }

        public TEntity First(System.Func<TEntity, bool> query)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            return col.FindAllAs<TEntity>().FirstOrDefault(query);
        }

        public bool Any(System.Func<TEntity, bool> query)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            return col.FindAllAs<TEntity>().Any(query);
        }

        public void Create(TEntity emp)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var result = col.Save(emp,
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });

            if (result.LastErrorMessage != null)
            {
                //// Something went wrong
            }
        }

        public void Update(TEntity emp)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var result = col.Save(emp,
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });

            if (result.LastErrorMessage != null)
            {
                //// Something went wrong
            }
        }

        public void Save(TEntity emp)
        {
            MongoCollection col = _db.GetCollection<TEntity>(GetName());
            var result = col.Save(emp,
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });

            if (result.LastErrorMessage != null)
            {
                //// Something went wrong
            }
        }

        public void Delete(TPrimaryKeyType id)
        {
            MongoCollection col = _db.GetCollection(GetName());
            //var result = col.Remove(Query.EQ("_id", ObjectId.Parse(id)));
            //var result = col.Remove(Query.EQ("_id", "ObjectId('" + id + "')"));
            var query = new QueryDocument("_id", id.ToString());
            //var doc = col.FindAs<TEntity>(query);
            var result = col.Remove(query);


            if (result.LastErrorMessage != null)
            {
                //// Something went wrong
            }
        }

        protected string GetName()
        {
            return _customCOllectionName != null ? _customCOllectionName : typeof(TEntity).Name.ToLower() + "s";
        }
    }
}
