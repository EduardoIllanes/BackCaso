using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Users.Model{

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set;}
    }

}