using iTransition.Forms.Domain.Entities;
using System.Linq.Expressions;

namespace iTransition.Forms.Domain.RepositoryContracts
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        Task AddAsync(TEntity entity);
    }
}