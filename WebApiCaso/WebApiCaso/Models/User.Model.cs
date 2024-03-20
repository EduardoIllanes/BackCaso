using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApiCaso.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
