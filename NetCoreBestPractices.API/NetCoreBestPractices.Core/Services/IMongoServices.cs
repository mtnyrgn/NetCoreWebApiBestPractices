using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Core.Services
{
    public interface IMongoServices<TDocument> where TDocument : class
    {
        Task<TDocument> GetByIdAsync(long id);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<IEnumerable<TDocument>> Where(Expression<Func<TDocument, bool>> predicate);
        Task<TDocument> SingleOrDefaultAsync(Expression<Func<TDocument, bool>> predicate);
        Task<TDocument> AddAsync(TDocument entity);
        Task<IEnumerable<TDocument>> AddRangeAsync(IEnumerable<TDocument> entities);
        void Remove(TDocument entity);
        void RemoveRange(IEnumerable<TDocument> entities);
        TDocument Update(TDocument entity);
    }
}
