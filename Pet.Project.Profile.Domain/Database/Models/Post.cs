using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Post
    {
        [BsonId]
        public string PostId { get; set; } = Guid.NewGuid().ToString();
    }
}