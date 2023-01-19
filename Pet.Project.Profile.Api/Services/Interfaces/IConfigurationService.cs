using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IConfigurationService
{
    public Task<Configuration> GetConfigurationAsync(string email);

    public Task UpdateDarkThemeAsync(string email, bool darkTheme);

    public Task UpdateFontAsync(string email, string font);

    public Task UpdateFontSizeAsync(string email, int fontSize);

    public Task UpdateNotificationsSettingsAsync(string email, NotificationsSettings settings);
}