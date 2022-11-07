using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RestApi_MongoDB.Models;

namespace RestApi_MongoDB.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _entity;

        public BaseService(string databaseName, string collectionName, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _entity = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync()
        {
            List<T> result = new();
            var entities = _entity.AsQueryable().Where(x => x.IsDeleted == false);
            for (int i = 0; true; i++)
            {
                var retrievedData = await entities.Skip(i * 100).Take(100).ToListAsync();
                if (!retrievedData.Any())
                {
                    break;
                }
                result.AddRange(retrievedData);
            }
            return result;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entity.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> InsertAsync(T value)
        {
            await _entity.InsertOneAsync(value);
            return value;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await _entity.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null)
            {
                entity.IsDeleted = true;
                await _entity.ReplaceOneAsync(x => x.Id == id, entity);
            }
        }

        public async Task<T> UpdateAsync(Guid id, T value)
        {
            await _entity.ReplaceOneAsync(x => x.Id == id, value);
            return value;
        }
    }
}