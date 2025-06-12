using lanchonete.configuration;
using lanchonete.interfaces;
using lanchonete.model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lanchonete.repository;

public class UserRepository:  IUserRepository
{
    private readonly IMongoCollection<UserModel> _users;
    
    public UserRepository(IOptions<MongodbSettings> mongoSettings)
    {
        var client = new MongoClient(mongoSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
        _users = database.GetCollection<UserModel>("users");
    }
    
    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _users.Find(user => true).ToListAsync();
    }

    public async Task<UserModel?> GetByIdAsync(string id)
    {
        return await _users.Find(user => user.id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(UserModel user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task UpdateAsync(string id, UserModel user)
    {
        user.id = id;
        await _users.ReplaceOneAsync(u => u.id == id, user);
    }
    
    public async Task DeleteAsync(string id)
    {
        await _users.DeleteOneAsync(user => user.id == id);
    }
}