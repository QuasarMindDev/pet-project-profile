using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Enums;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class ProfileService : IProfileService
{
    private readonly IUserProfileRepository _database;

    public ProfileService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task ModifyGenderAsync(string email, Gender gender)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Profile.Gender = gender;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyImagePathAsync(string email, string imagePath)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Profile.ImagePath = imagePath;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyBirthDateAsync(string email, DateTime birthDate)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Profile.BirthDate = birthDate;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifySummaryAsync(string email, string summary)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Profile.Summary = summary;
        await _database.UpdateAsync(profile);
    }
}
