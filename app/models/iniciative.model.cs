using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Iniciatives.Model{
    public class Iniciative{
        
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Description")]
    public string Description{ get; set; }

    [BsonElement("Likes")]
    public List<int> Likes { get; set; }

    [BsonElement("UserCreatorId")]
    public string UserCreatorId { get; set; }
    }
}