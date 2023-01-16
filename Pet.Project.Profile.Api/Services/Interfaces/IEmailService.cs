using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IEmailService
{
    public Task ConfirmEmailAsync(string email);

    public Task ModifyEmailAddressAsync(string email, string newEmail);

    public Task<Email> GetEmailInfoAsync(string email);
}
