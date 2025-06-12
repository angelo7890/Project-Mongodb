using lanchonete.enums;
using lanchonete.model;

namespace lanchonete.interfaces;

public interface IOrderRepository
{
    Task<List<OrderModel>> GetAllAsync(int pageNumber, int pageSize);
    Task<OrderModel?> GetByIdAsync(string id);
    Task CreateAsync(OrderModel order);
    Task UpdateAsync(string id, StatusEnum status);
    Task DeleteAsync(string id);
}