using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Like
    {
        public DateTime Created { get; set; } = DateTime.Now;

        [BsonId]
        public string PostId { get; set; } = Guid.NewGuid().ToString();

        public bool Status { get; set; }
    }
}