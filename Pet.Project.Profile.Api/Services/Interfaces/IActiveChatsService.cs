namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IActiveChatsService
{
    public Task AddActiveChatAsync(string email, string chatId);
    public Task RemoveActiveChatAsync(string email, string chatId);
    public Task<List<string>?> GetActiveChatsAsync(string email);
}
