using lanchonete.model;

namespace lanchonete.interfaces;

public interface IItemRepository
{
    Task<List<ItemModel>> GetAllAsync(int pageNumber, int pageSize);
    Task<ItemModel?> GetByIdAsync(string id);
    Task CreateAsync(ItemModel item);
    Task UpdateAsync(string id, ItemModel item);
    Task DeleteAsync(string id);
}