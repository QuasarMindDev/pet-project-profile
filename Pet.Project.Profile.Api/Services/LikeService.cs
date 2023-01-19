using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class LikeService : ILikeService
{
    private readonly IUserProfileRepository _database;

    public LikeService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddLikeAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var like = new Like() { PostId = postId, Status = false };
        if (profile.Like is null)
        {
            profile.Like = new List<Like> { like };
        }
        else
        {
            profile.Like.Add(like);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task<Like> GetLikeAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Like!.Find(x => x.PostId == postId)!;
    }

    public async Task<List<Like>> GetLikesAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Like!;
    }

    public async Task ModifyLikeStatusAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var likeIndex = profile.Like!.FindIndex(x => x.PostId == postId);
        profile.Like[likeIndex].Status = !profile.Like[likeIndex].Status;
        await _database.UpdateAsync(profile);
    }

    public async Task RemoveLikeAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Like!.RemoveAll(x => x.PostId == postId);
        await _database.UpdateAsync(profile);
    }
}