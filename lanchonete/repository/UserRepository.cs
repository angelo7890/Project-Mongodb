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
    
    public Task<List<UserModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}