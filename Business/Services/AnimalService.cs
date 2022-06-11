using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class AnimalService : IService<Animal, string>
    {
        private readonly IMongoCollection<Animal> _animalCollection;

        public AnimalService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _animalCollection = mongoDatabase.GetCollection<Animal>(dbSettings.Value.Collection);
        }

        public async Task AddAsync(Animal item)
        {
            await _animalCollection.InsertOneAsync(item);
        }

        public async Task DeleteAsync(string id)
        {
            await _animalCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
           var animals = await _animalCollection.Find(_ => true).ToListAsync();
           return animals;
        }

        public async Task<Animal> GetAsync(string id)
        {
            var animal = await _animalCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return animal;
        }

        public async Task UpdateAsync(string id, Animal data)
        {
            await _animalCollection.ReplaceOneAsync(x => x.Id == id, data);
        }
    }
}
