using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lanchonete.model;

public class ItemModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public decimal price { get; set; }

    public ItemModel()
    {
    }

    public ItemModel(string name, string description, string category, decimal price)
    {
        this.name = name;
        this.description = description;
        this.category = category;
        this.price = price;
    }
}