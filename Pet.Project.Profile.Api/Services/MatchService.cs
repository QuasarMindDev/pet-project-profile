using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class MatchService : IMatchService
{
    private readonly IUserProfileRepository _database;

    public MatchService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddMatchAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email.EmailAddress == email);
        var match = new Match(){PostId = postId};
        if (profile.Match is null)
        {
            profile.Match = new List<Match>{match};
        }
        else
        {
            profile.Match.Add(match);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task<Match> GetMatchAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Match!.Find(x => x.PostId == postId)!;
    }

    public async Task<List<Match>> GetMatchesAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Match!;
    }

    public async Task RemoveMatchAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Match!.RemoveAll(x => x.PostId == postId);
        await _database.UpdateAsync(profile);
    }
}
