using Pet.Project.Profile.Domain.Database.Enums;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IProfileService
{
    public Task ModifyGenderAsync(string email, Gender gender);
    public Task ModifyImagePathAsync(string email, string imagePath);
    public Task ModifyBirthDateAsync(string email, DateTime birthDate);
    public Task ModifySummaryAsync(string email, string summary);
}
