using NetCoreBestPractices.Core.BaseDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface IMongoRepository<TDocument> where TDocument : MongoBaseDocument
    {
        Task<TDocument> GetByIdAsync(string id);
        Task<IQueryable<TDocument>> GetAllAsync();
        Task AddAsync(TDocument document);
        Task AddRangeAsync(IEnumerable<TDocument> documents);
        void Remove(TDocument document);
        void Remove(string id);
        void RemoveRange(Expression<Func<TDocument, bool>> expression);
        TDocument Update(TDocument document);

    }
}
