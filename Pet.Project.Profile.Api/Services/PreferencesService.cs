using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Enums;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class PreferencesService : IPreferencesService
{
    private readonly IUserProfileRepository _database;

    public PreferencesService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddCategoryAsync(string email, Category category)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        if (profile.Preferences.Category is null)
        {
            profile.Preferences.Category = new List<Category> { category };
        }
        else
        {
            profile.Preferences.Category.Add(category);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task AddGenderAsync(string email, Gender gender)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        if (profile.Preferences.Gender is null)
        {
            profile.Preferences.Gender = new List<Gender> { gender };
        }
        else
        {
            profile.Preferences.Gender.Add(gender);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task<Preferences> GetPreferencesAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Preferences!;
    }

    public async Task ModifyDistanceAsync(string email, double distance)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Preferences.Distance = distance;
        await _database.UpdateAsync(profile);
    }

    public async Task RemoveCategoryAsync(string email, Category category)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Preferences.Category!.RemoveAll(x => x == category);
        await _database.UpdateAsync(profile);
    }

    public async Task RemoveGenderAsync(string email, Gender gender)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Preferences.Gender!.RemoveAll(x => x == gender);
        await _database.UpdateAsync(profile);
    }
}