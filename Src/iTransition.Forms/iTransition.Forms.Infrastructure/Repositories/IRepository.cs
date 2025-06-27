using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {

    }
}
