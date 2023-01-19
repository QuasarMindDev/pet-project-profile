using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IPostService
{
    public Task AddPostAsync(string email, string postId);

    public Task<Post> GetPostAsync(string email, string postId);

    public Task<List<Post>> GetPostsAsync(string email);

    public Task RemovePostAsync(string email, string postId);
}