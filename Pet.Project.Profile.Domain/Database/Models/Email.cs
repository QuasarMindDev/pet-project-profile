using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Email
    {
        public bool Confirmed { get; set; }

        [BsonId]
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}