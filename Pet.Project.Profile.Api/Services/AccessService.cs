using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class AccessService : IAccessService
{
    private readonly IUserProfileRepository _database;

    public AccessService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task<Access> GetAccessAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Access;
    }

    public async Task ModifyFailedCountAsync(string email, bool reset)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Access.FailedCount =  reset ? 0 : profile.Access.FailedCount + 1;
        await _database.UpdateAsync(profile);
    }

    public void UpdateAuth0Id(string email)
    {
        throw new NotImplementedException(); //TODO: Implement Auth0
    }
}
