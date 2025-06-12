using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lanchonete.model;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string id { get; set; }
    public string name { get; set; }
    public Address address { get; set; }

    public UserModel()
    {
    }

    public UserModel(string name , Address address)
    {
        this.name = name;
        this.address = address;
    }
}