using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
    }
}