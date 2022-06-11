using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class AnimalService : IService<>
    {
        private readonly IMongoCollection<Animal> _animalCollection;

        public AnimalService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _animalCollection = mongoDatabase.GetCollection<Animal>(dbSettings.Value.Collection);
        }
    }
}
