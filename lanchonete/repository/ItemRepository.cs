using lanchonete.configuration;
using lanchonete.interfaces;
using lanchonete.model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lanchonete.repository;

public class ItemRepository: IItemRepository
{
    private readonly IMongoCollection<ItemModel> _items;
    
    public ItemRepository(IOptions<MongodbSettings> mongoSettings)
    {
        var client = new MongoClient(mongoSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
        _items = database.GetCollection<ItemModel>("items");
    }
    
    public Task<List<ItemModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(ItemModel item)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, ItemModel item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}