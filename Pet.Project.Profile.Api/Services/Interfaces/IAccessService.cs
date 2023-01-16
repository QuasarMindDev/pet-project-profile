using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IAccessService
{
    public Task<Access> GetAccessAsync(string email);
    public void UpdateAuth0Id(string email);
    public Task ModifyFailedCountAsync(string email, bool reset);
}
