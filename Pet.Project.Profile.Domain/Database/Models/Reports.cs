using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Reports
    {
        public List<string>? Category { get; set; }

        [BsonId]
        public string? ReportId { get; set; }

        public string? Summary { get; set; }
    }
}