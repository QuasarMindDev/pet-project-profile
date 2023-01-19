using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IReportsService
{
    public Task AddReportAsync(string email, Reports report);

    public Task<Reports> GetReportAsync(string email, string reportId);

    public Task<List<Reports>> GetReportsAsync(string email);

    public Task ModifyCategoryAsync(string email, string reportId, List<string> category);

    public Task ModifySummaryAsync(string email, string reportId, string summary);

    public Task RemoveReportAsync(string email, string reportId);
}