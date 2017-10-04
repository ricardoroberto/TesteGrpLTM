using Commom.Contracts;
using MongoDB.Driver;

namespace Commom.Infra.MongoDB.Repositories
{
    public class RepositoryWrite<TEntity> where TEntity : class
    {
        MongoDatabase _db = null;
        public RepositoryWrite(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork.GetSession<MongoDatabase>();
        }

        public void Create(TEntity emp)
        {
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
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
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
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
            MongoCollection col = _db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
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

        public void Delete(string id)
        {
            MongoCollection col = _db.GetCollection(typeof(TEntity).Name.ToLower() + "s");
            //var result = col.Remove(Query.EQ("_id", ObjectId.Parse(id)));
            //var result = col.Remove(Query.EQ("_id", "ObjectId('" + id + "')"));
            var query = new QueryDocument("_id", id);
            //var doc = col.FindAs<TEntity>(query);
            var result = col.Remove(query);


            if (result.LastErrorMessage != null)
            {
                //// Something went wrong
            }
        }
    }
}
