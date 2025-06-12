using lanchonete.model;

namespace lanchonete.interfaces;

public interface IOrderRepository
{
    Task<List<OrderModel>> GetAllAsync(int pageNumber, int pageSize);
    Task<OrderModel?> GetByIdAsync(string id);
    Task CreateAsync(OrderModel order);
    Task UpdateAsync(string id, OrderModel order);
    Task DeleteAsync(string id);
}