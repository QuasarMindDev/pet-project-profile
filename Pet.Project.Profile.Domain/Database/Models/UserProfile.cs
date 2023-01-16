using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class UserProfile
    {
        [BsonId]
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        public Access Access { get; set; } = new Access();
        public bool Active { get; set; }
        public List<ActiveChat>? ActiveChats { get; set; }
        public Configuration Configuration { get; set; } = new Configuration();
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public Email Email { get; set; } = new Email();
        public DateTime LastAccess { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public List<Like>? Like { get; set; }
        public Location Location { get; set; } = new Location();
        public List<Match>? Match { get; set; }
        public Phone Phone { get; set; } = new Phone();
        public List<Post>? Post { get; set; }
        public Preferences Preferences { get; set; } = new Preferences();
        public Profile Profile { get; set; } = new Profile();
        public List<Reports>? Reports { get; set; }
    }
}