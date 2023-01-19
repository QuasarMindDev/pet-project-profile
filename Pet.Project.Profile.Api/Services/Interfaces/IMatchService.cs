using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IMatchService
{
    public Task AddMatchAsync(string email, string postId);

    public Task<Match> GetMatchAsync(string email, string postId);

    public Task<List<Match>> GetMatchesAsync(string email);

    public Task RemoveMatchAsync(string email, string postId);
}