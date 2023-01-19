using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface ILocationService
{
    public Task<Location> GetLocationAsync(string email);

    public Task ModifyAddressAsync(string email, string address);

    public Task ModifyCityAsync(string email, string city);

    public Task ModifyCountryAsync(string email, string country);
}