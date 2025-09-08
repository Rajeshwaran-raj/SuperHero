using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        [BsonId] // MongoDB requires an Id
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
