using System.Collections.Generic;

namespace Commom.Contracts
{
    public interface IRepositoryRead<TPrimaryKeyType, TEntity> where TEntity : IEntityBase<TPrimaryKeyType>
    {
        TEntity GetById(string id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(System.Func<TEntity, bool> query);
        TEntity First(System.Func<TEntity, bool> query);
    }
}
