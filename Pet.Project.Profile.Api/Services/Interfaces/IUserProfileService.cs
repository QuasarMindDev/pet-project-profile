using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IUserProfileService
{
    public Task CreateUserProfileAsync(UserProfile userProfile);

    public Task<UserProfile> GetUserProfileAsync(string email);

    public IQueryable<UserProfile> GetUsersProfile();

    public Task ModifyUserProfileAsync(UserProfile userProfile);
}