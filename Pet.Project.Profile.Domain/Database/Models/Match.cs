using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Match
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [BsonId]
        public string PostId { get; set; } = Guid.NewGuid().ToString();
    }
}