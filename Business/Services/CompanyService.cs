using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class CompanyService : IService<>
    {
        private readonly IMongoCollection<Company> _companyCollection;

        public CompanyService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _companyCollection = mongoDatabase.GetCollection<Company>(dbSettings.Value.Collection);
        }
    }
}
