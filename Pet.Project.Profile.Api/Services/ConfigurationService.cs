using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IUserProfileRepository _database;

    public ConfigurationService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task<Configuration> GetConfigurationAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Configuration;
    }

    public async Task UpdateDarkThemeAsync(string email, bool darkTheme)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Configuration.DarkTheme = darkTheme;
        await _database.UpdateAsync(profile);
    }

    public async Task UpdateFontAsync(string email, string font)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Configuration.Font = font;
        await _database.UpdateAsync(profile);
    }

    public async Task UpdateFontSizeAsync(string email, int fontSize)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Configuration.FontSize = fontSize;
        await _database.UpdateAsync(profile);
    }

    public async Task UpdateNotificationsSettingsAsync(string email, NotificationsSettings settings)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Configuration.Settings = settings;
        await _database.UpdateAsync(profile);
    }
}