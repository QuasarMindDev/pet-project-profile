using Pet.Project.Profile.Domain.Database.Enums;

namespace Pet.Project.Profile.Domain.Database.Models;

public class Profile
{
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public Gender Gender { get; set; }

    public string ImagePath { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}