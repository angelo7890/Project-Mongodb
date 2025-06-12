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

    public async  Task<List<AdditionalModel>> GetAllAsync()
    {
        return await _additional.Find(_=>true).ToListAsync();
    }

    public async Task<AdditionalModel?> GetByIdAsync(string id)
    {
        return await _additional.Find(x => x.id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(AdditionalModel additional)
    {
        await _additional.InsertOneAsync(additional);
    }

    public async Task UpdateAsync(string id, AdditionalModel additional)
    {
        additional.id = id;
        await _additional.ReplaceOneAsync(x => x.id == id, additional);
    }

    public async Task DeleteAsync(string id)
    {
        await _additional.DeleteOneAsync(x => x.id == id);
    }
}