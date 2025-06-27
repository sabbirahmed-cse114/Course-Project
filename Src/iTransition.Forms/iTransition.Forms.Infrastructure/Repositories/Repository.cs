using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iTransition.Forms.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TKey>
         : IRepository<TEntity, TKey> where TKey : IComparable
         where TEntity : class, IEntity<TKey>
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        protected ISqlUtility SqlUtility { get; private set; }

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
            SqlUtility = new SqlUtility(_dbContext.Database.GetDbConnection());
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            int count;

            if (filter != null)
                count = query.Count(filter);
            else
                count = query.Count();

            return count;
        }
    }
}