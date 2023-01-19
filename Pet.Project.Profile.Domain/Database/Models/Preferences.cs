using Pet.Project.Profile.Domain.Database.Enums;

namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Preferences
    {
        public List<Category>? Category { get; set; }
        public double Distance { get; set; }
        public List<Gender>? Gender { get; set; }
    }
}