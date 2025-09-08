using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        [BsonId] // Marks this property as the MongoDB _id
        [BsonRepresentation(BsonType.ObjectId)] // Converts ObjectId <-> string
        public string Id { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
