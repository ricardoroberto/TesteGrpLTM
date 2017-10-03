using Commom.Contracts;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Commom.Infra.MongoDB.Maps
{
    public class MapEntity
    {
        public static void SetId<TPrimaryKeyType, TEntity>() where TEntity : IEntityBase<TPrimaryKeyType>
        {
            BsonClassMap.RegisterClassMap<TEntity>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
