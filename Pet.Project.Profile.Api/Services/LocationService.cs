using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class LocationService: ILocationService
{
    private readonly IUserProfileRepository _database;

    public LocationService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task<Location> GetLocationAsync(string email)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        return profile.Location;
    }

    public async Task ModifyAddressAsync(string email, string address)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Location.Address = address;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyCityAsync(string email, string city)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Location.City = city;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifyCountryAsync(string email, string country)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        profile.Location.Country = country;
        await _database.UpdateAsync(profile);
    }
}
