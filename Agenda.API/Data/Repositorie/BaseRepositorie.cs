
using Agenda.API.Configuration.Model;
using Agenda.API.Domain.Interface;
using Agenda.API.Domain.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Agenda.API.Data.Repositorie
{
    public class BaseRepositorie<T> : IBaseRepositorie<T> where T : BaseModel
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepositorie(
            IOptions<DatabaseSettings> databaseSettings,
            string collectionName)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(Guid id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T novo)
        {
            novo.DataCriacao = DateTime.Now;
            novo.DataAtualizacao = DateTime.Now;
            novo.Id = Guid.NewGuid();
            await _collection.InsertOneAsync(novo);
        }

        public async Task UpdateAsync(Guid id, T atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }

        

        public async Task RemoveAsync(Guid id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}