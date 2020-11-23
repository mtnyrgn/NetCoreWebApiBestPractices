using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface IRepository <TEntity> where TEntity:class //T entity must be class
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable> GetAllAsync();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
