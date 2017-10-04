namespace Commom.Contracts
{
    public interface IRepositoryWrite<TEntity> where TEntity : class
    {
        void Create(TEntity emp);
        void Update(TEntity emp);
        void Save(TEntity emp);
        void Delete(string id);
    }
}
