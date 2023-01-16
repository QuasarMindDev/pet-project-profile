using Pet.Project.Profile.Domain.Database.Enums;
using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IPreferencesService
{
    public Task ModifyDistanceAsync(string email, double distance);
    public Task AddCategoryAsync(string email, Category category);
    public Task AddGenderAsync(string email, Gender gender);
    public Task RemoveCategoryAsync(string email, Category category);
    public Task RemoveGenderAsync(string email, Gender gender);
    public Task<Preferences> GetPreferencesAsync(string email);
}
