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
    
    public async Task<List<ItemModel>> GetAllAsync()
    {
        return await _items.Find(_ => true).ToListAsync();
    }

    public async Task<ItemModel?> GetByIdAsync(string id)
    {
        return await _items.Find(x => x.id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ItemModel item)
    {
        await _items.InsertOneAsync(item);
    }

    public async Task UpdateAsync(string id, ItemModel item)
    {
       item.id = id;
       await _items.ReplaceOneAsync(x => x.id == id, item);
       
    }

    public async Task DeleteAsync(string id)
    {
        await _items.DeleteOneAsync(x => x.id == id);
    }
}