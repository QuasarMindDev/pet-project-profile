using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IPhoneService
{
    public Task ModifyPhoneAsync(string email, Phone phone);
    public Task ConfirmPhoneAsync(string email);
    public Task<Phone> GetPhoneInfoAsync(string email);
}
