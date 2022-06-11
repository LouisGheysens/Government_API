using Business.Interfaces;
using Data.Models;
using Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Business.Services
{
    public class CompanyService : IService<Company, string>
    {
        private readonly IMongoCollection<Company> _companyCollection;

        public CompanyService(IOptions<DbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _companyCollection = mongoDatabase.GetCollection<Company>(dbSettings.Value.Collection);
        }

        public async Task AddAsync(Company item)
        {
            await _companyCollection.InsertOneAsync(item);
        }

        public async Task DeleteAsync(string id)
        {
            await _companyCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _companyCollection.Find(_ => true).ToListAsync();
            return companies;
        }

        public async Task<Company> GetAsync(string id)
        {
            var company = await _companyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return company;
        }

        public async Task UpdateAsync(string id, Company data)
        {
            await _companyCollection.ReplaceOneAsync(x => x.Id == id, data);
        }
    }
}
