using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class EmailService : IEmailService
{
    private readonly IUserProfileRepository _database;

    public EmailService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task ConfirmEmailAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Email.Confirmed = true;
        await _database.UpdateAsync(profile);
    }

    public Task<Email> GetEmailInfoAsync(string email)
    {
        return _database.GetSingleAsync(x => x.Email!.EmailAddress == email).ContinueWith(x => x.Result.Email);
    }

    public async Task ModifyEmailAddressAsync(string email, string newEmail)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);

        if(await _database.GetSingleAsync(x => x.Email!.EmailAddress == newEmail) == null){
            throw new SystemException("Email already exists");
        }

        await _database.UpdateAsync(profile);
    }

    //TODO: Add Email Senders
}
