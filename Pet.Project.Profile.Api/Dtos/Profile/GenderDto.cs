using Pet.Project.Profile.Domain.Database.Enums;

namespace Pet.Project.Profile.Api.Dtos.Profile;

public class GenderDto
{
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}