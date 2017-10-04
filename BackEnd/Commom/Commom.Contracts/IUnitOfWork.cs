namespace Commom.Contracts
{
    public interface IUnitOfWork
    {
        TEntity GetSession<TEntity>() where TEntity : class;
    }
}
