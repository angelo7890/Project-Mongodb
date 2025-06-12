using lanchonete.configuration;
using lanchonete.enums;
using lanchonete.interfaces;
using lanchonete.model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lanchonete.repository;

public class OrderRepository:IOrderRepository
{
    private readonly IMongoCollection<OrderModel> _orders;
    
    public OrderRepository(IOptions<MongodbSettings> mongoSettings)
    {
        var client = new MongoClient(mongoSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
        _orders = database.GetCollection<OrderModel>("orders");
    }
    
    public async Task<List<OrderModel>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _orders
            .Find(_ => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<OrderModel?> GetByIdAsync(string id)
    {
        return await _orders.Find(x => x.id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(OrderModel order)
    {
        await _orders.InsertOneAsync(order);
    }

    public async Task UpdateAsync(string id, StatusEnum status)
    {
        var update = Builders<OrderModel>.Update.Set(o => o.status, status);
        await _orders.UpdateOneAsync(o => o.id == id, update);
    }

    public async Task DeleteAsync(string id)
    {
        await _orders.DeleteOneAsync(x => x.id == id);
    }
}