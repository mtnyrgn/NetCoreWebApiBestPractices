using MongoDB.Bson;
using MongoDB.Driver;
using NetCoreBestPractices.Core.BaseDocument;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBestPractices.Data.Repositories
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : MongoBaseDocument
    {
        private readonly IMongoCollection<TDocument> _collection;
        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName; // databasede iş yapmak için gönderilen objenin collection name'ini aldık.
        }

        public async Task AddAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task AddRangeAsync(IEnumerable<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public async Task<IQueryable<TDocument>> GetAllAsync()
        {
            return await Task.Run(() => _collection.AsQueryable());
        }

        public async Task<TDocument> GetByIdAsync(string id)
        {
            return await Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.FindAsync(filter).Result.SingleOrDefaultAsync();
            });
        }

        public void Remove(TDocument document)
        {
            _collection.DeleteOne(d => d.Id == document.Id);
        }
        public void Remove(string id)
        {
            var objectId = new ObjectId(id);
            _collection.DeleteOne(d => d.Id == objectId);
        }
        public void RemoveRange(Expression<Func<TDocument,bool>> expression)
        {
            _collection.DeleteMany(expression);
        }

        public TDocument Update(TDocument document)
        {
            _collection.ReplaceOne(r => r.Id == document.Id, document);
            return document;
        }
    }
}
