using lanchonete.enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lanchonete.model;

public class OrderModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string id { get; set; }
    public string user_id { get; set; }
    public List<ItemOrdered> items { get; set; }
    public decimal total { get; set; }
    
    public StatusEnum  status { get; set; }

    public OrderModel(string userId, List<ItemOrdered> items, decimal total,  StatusEnum status)
    {
        user_id = userId;
        this.items = items;
        this.total = total;
        this.status = status;
    }
}