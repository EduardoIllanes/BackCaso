using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApiCaso.Models
{
        public class Iniciative
        {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }

            [BsonElement("Title")]
            public string Title { get; set; }

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
