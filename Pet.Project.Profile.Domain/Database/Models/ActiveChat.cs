using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class ActiveChat
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}