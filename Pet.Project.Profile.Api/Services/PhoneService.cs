using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class PhoneService : IPhoneService
{
    private readonly IUserProfileRepository _database;

    public PhoneService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task ConfirmPhoneAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Phone.Confirmed = true;
        await _database.UpdateAsync(profile);
    }

    public async Task<Phone> GetPhoneInfoAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Phone!;
    }

    public async Task ModifyPhoneAsync(string email, Phone phone)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Phone = phone;
        await _database.UpdateAsync(profile);
    }
}