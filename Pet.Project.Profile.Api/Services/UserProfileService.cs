using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Domain.Extensions;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _database;

    public UserProfileService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task CreateUserProfileAsync(UserProfile userProfile)
    {
        await _database.AddAsync(userProfile);
    }

    public Task<UserProfile> GetUserProfileAsync(string email)
    {
        return _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
    }

    public IQueryable<UserProfile> GetUsersProfile()
    {
        return _database.GetAll(new PagingExtension());
    }

    public Task ModifyUserProfileAsync(UserProfile userProfile)
    {
        return _database.UpdateAsync(userProfile);
    }
}