using lanchonete.model;

namespace lanchonete.interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllAsync();
    Task<UserModel?> GetByIdAsync(string id);
    Task CreateAsync(UserModel user);
    Task UpdateAsync(string id, UserModel user);
    Task DeleteAsync(string id);
}