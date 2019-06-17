using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Read
{
    public class BaseReadModel
    {
       [BsonElement("_id")]
       public ObjectId Id { get; set; }
    }
}
