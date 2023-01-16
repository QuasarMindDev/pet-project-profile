using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface ILikeService
{
    public Task AddLikeAsync(string email, string postId);
    public Task RemoveLikeAsync(string email, string postId);
    public Task ModifyLikeStatusAsync(string email, string postId);
    public Task<List<Like>> GetLikesAsync(string email);
    public Task<Like> GetLikeAsync(string email, string postId);
}
