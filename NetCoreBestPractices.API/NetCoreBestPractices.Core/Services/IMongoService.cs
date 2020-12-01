using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Core.Services
{
    public interface IMongoService<TDocument> where TDocument : class
    {
        Task<TDocument> GetByIdAsync(string id);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> AddAsync(TDocument entity);
        Task<IEnumerable<TDocument>> AddRangeAsync(IEnumerable<TDocument> entities);
        void Remove(string id);
        TDocument Update(TDocument entity);
    }
}
