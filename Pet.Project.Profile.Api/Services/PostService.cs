using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class PostService : IPostService
{
    private readonly IUserProfileRepository _database;

    public PostService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddPostAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var post = new Post() { PostId = postId };
        if (profile.Post is null)
        {
            profile.Post = new List<Post> { post };
        }
        else
        {
            profile.Post.Add(post);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task<Post> GetPostAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Post!.Find(x => x.PostId == postId)!;
    }

    public async Task<List<Post>> GetPostsAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Post!;
    }

    public async Task RemovePostAsync(string email, string postId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Post!.RemoveAll(x => x.PostId == postId);
        await _database.UpdateAsync(profile);
    }
}