using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class PersonService : IService<Person, string>
    {
        private readonly IMongoCollection<Person> _personCollection;

        public PersonService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _personCollection = mongoDatabase.GetCollection<Person>(dbSettings.Value.Collection);
        }

        public async Task AddAsync(Person item)
        {
            await _personCollection.InsertOneAsync(item);
        }

        public async Task DeleteAsync(string id)
        {
            await _personCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _personCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Person> GetAsync(string id)
        {
            return await _personCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Person data)
        {
            await _personCollection.ReplaceOneAsync(x => x.Id == id, data);
        }
    }
}
