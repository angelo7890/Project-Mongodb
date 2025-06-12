using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lanchonete.model;

public class AdditionalModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string id { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }

    public AdditionalModel(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }
}