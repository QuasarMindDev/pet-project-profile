using Pet.Project.Profile.Domain.Database.Enums;

namespace Pet.Project.Profile.Domain.Database.Models;

public class Profile
{
    public Gender Gender { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; } = DateTime.MinValue;

    public string Summary { get; set; } = string.Empty;
}
