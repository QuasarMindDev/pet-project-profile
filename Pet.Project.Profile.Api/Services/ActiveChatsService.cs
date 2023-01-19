using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class ActiveChatsService : IActiveChatsService
{
    private readonly IUserProfileRepository _database;

    public ActiveChatsService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddActiveChatAsync(string email, string chatId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var activeChat = new ActiveChat() { Id = chatId };

        if (profile.ActiveChats is null)
        {
            profile.ActiveChats = new List<ActiveChat> { activeChat };
        }
        else
        {
            profile.ActiveChats.Add(activeChat);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task<List<string>?> GetActiveChatsAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.ActiveChats?.Select(x => x.Id).ToList();
    }

    public async Task RemoveActiveChatAsync(string email, string chatId)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.ActiveChats?.RemoveAll(x => x.Id == chatId);
        await _database.UpdateAsync(profile);
    }
}