using Commom.Contracts;
using System.Data.Entity;

namespace Commom.Infra.SqlServer.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext = null;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity GetSession<TEntity>() where TEntity : class
        {
            return _dbContext as TEntity;
        }
    }
}
