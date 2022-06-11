using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class CountryService : IService<>
    {
        private readonly IMongoCollection<Country> _countryCollection;

        public CountryService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _countryCollection = mongoDatabase.GetCollection<Country>(dbSettings.Value.Collection);
        }
    }
}
