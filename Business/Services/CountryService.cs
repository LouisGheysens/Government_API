using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class CountryService : IService<Country, string>
    {
        private readonly IMongoCollection<Country> _countryCollection;

        public CountryService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _countryCollection = mongoDatabase.GetCollection<Country>(dbSettings.Value.Collection);
        }

        public async Task AddAsync(Country item)
        {
            await _countryCollection.InsertOneAsync(item);
        }

        public async Task DeleteAsync(string id)
        {
            await _countryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var countries = await _countryCollection.Find(_ => true).ToListAsync();
            return countries;
        }

        public  async Task<Country> GetAsync(string id)
        {
            var country = await _countryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return country;
        }

        public async Task UpdateAsync(string id, Country data)
        {
            await _countryCollection.ReplaceOneAsync(x => x.Id == id, data);
        }
    }
}
