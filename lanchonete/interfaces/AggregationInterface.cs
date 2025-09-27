using lanchonete.enums;
using MongoDB.Bson;

namespace lanchonete.interfaces;

public interface IAggregationInterface
{
    Task<List<BsonDocument>> GetUsersWhoSpentMostAsync();
    Task<List<BsonDocument>> GetOrdersByStatusAsync(StatusEnum status);
    Task<List<BsonDocument>> GetBestSellingCategoryAsync();
    Task<List<BsonDocument>> GetBestSellingItemsAsync();
}