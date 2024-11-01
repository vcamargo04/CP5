using MongoDB.Bson;
using MongoDB.Driver;
using SorveteriaDatabase;

namespace SorvetesRepository
{
    public class MongoDbRepository<T> : IRepository<T> where T : class
    {
        private readonly FIAPMongoDBContext _context;
        private readonly IMongoCollection<T> _collection;

        public MongoDbRepository(FIAPMongoDBContext context)
        {
            _context = context;
            _collection = _context.Sorvetes as IMongoCollection<T>; // Cast para IMongoCollection<T>
        }

        public async Task Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(ObjectId id)
        {
            var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
            if (result.DeletedCount == 0)
            {
                throw new Exception("Entity not found");
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(ObjectId? id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task Update(ObjectId? id, T entity)
        {
            var result = await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
            if (result.MatchedCount == 0)
            {
                throw new Exception("Entity not found");
            }
        }
    }
}
