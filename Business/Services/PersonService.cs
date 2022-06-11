using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class PersonService : IService<>
    {
        private readonly IMongoCollection<Person> _personCollection;

        public PersonService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _personCollection = mongoDatabase.GetCollection<Person>(dbSettings.Value.Collection);
        }
    }
}
