using NetCoreBestPractices.Core.BaseDocument;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Service.Services
{
    public class MongoService<TDocument> : IMongoService<TDocument> where TDocument : MongoBaseDocument
    {
        private readonly IMongoRepository<TDocument> _mongoRepository;

        public MongoService(IMongoRepository<TDocument> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<TDocument> AddAsync(TDocument document)
        {
            await _mongoRepository.AddAsync(document);

            return document;
        }

        public async Task<IEnumerable<TDocument>> AddRangeAsync(IEnumerable<TDocument> documents)
        {
            await _mongoRepository.AddRangeAsync(documents);

            return documents;
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return await _mongoRepository.GetAllAsync();
        }

        public async Task<TDocument> GetByIdAsync(string id)
        {
            return await _mongoRepository.GetByIdAsync(id);
        }

        public void Remove(string id)
        {
            _mongoRepository.Remove(id);
        }

        public TDocument Update(TDocument document)
        {
            _mongoRepository.Update(document);

            return document;
        }
    }
}
