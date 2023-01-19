using Pet.Project.Profile.Api.Dtos.Profile;
using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class ProfileService : IProfileService
{
    private readonly IUserProfileRepository _database;

    public ProfileService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task<Domain.Database.Models.Profile> GetProfileAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Profile;
    }

    public async Task ModifyBirthDateAsync(BirthDateDto birthDateDto)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == birthDateDto.Email);
        profile.Profile.BirthDate = birthDateDto.BirthDate;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyGenderAsync(GenderDto genderDto)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == genderDto.Email);
        profile.Profile.Gender = genderDto.Gender;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyImagePathAsync(ImagePathDto imagePathDto)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == imagePathDto.Email);
        profile.Profile.ImagePath = imagePathDto.ImagePath;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifySummaryAsync(SummaryDto summaryDto)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == summaryDto.Email);
        profile.Profile.Summary = summaryDto.Summary;
        await _database.UpdateAsync(profile);
    }
}