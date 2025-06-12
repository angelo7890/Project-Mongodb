using lanchonete.configuration;
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
    
    public Task<List<OrderModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderModel?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(OrderModel order)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, OrderModel order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}