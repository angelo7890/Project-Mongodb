using lanchonete.configuration;
using lanchonete.interfaces;
using lanchonete.model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lanchonete.repository;

public class AdditionalRepository: IAdditionalRepository
{
    private readonly IMongoCollection<AdditionalModel> _additional;
    
    public AdditionalRepository(IOptions<MongodbSettings> mongoSettings)
    {
        var client = new MongoClient(mongoSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
        _additional = database.GetCollection<AdditionalModel>("additional");
    }

    public Task<List<AdditionalModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AdditionalModel?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AdditionalModel additional)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, AdditionalModel additional)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}