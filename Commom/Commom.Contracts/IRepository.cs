using System.Collections.Generic;

namespace Commom.Contracts
{
    public interface IRepository<TPrimaryKeyType, TEntity> where TEntity : class,IEntityBase<TPrimaryKeyType>
    {
        TEntity GetById(TPrimaryKeyType id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(System.Func<TEntity, bool> query);
        TEntity First(System.Func<TEntity, bool> query);
        bool Any(System.Func<TEntity, bool> query);
        void Create(TEntity emp);
        void Update(TEntity emp);
        void Save(TEntity emp);
        void Delete(TPrimaryKeyType id);
    }
}
