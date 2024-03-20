using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApiCaso.Models
{
        public class Iniciative
        {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }

            [BsonElement("Description")]
            public string Description { get; set; }

            [BsonElement("Likes")]
            public int Likes { get; set; }

            [BsonElement("LikesList")]
            public List<ObjectId> LikesList { get; set; }

        [BsonElement("UserCreatorId")]
            public ObjectId UserCreatorId { get; set; }
        }
}
