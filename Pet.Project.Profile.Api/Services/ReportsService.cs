using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Services;

public class ReportsService : IReportsService
{
    private readonly IUserProfileRepository _database;

    public ReportsService(IDatabaseService dataService)
    {
        _database = dataService.Profiles;
    }

    public async Task AddReportAsync(string email, Reports report)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        if (profile.Reports is null)
        {
            profile.Reports = new List<Reports>{report};
        }
        else
        {
            profile.Reports.Add(report);
        }

        await _database.UpdateAsync(profile);
    }

    public async Task ModifyCategoryAsync(string email, string reportId, List<string> category)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var reportIndex = profile.Reports!.FindIndex(x => x.ReportId == reportId);
        profile.Reports[reportIndex].Category = category;
        await _database.UpdateAsync(profile);
    }

    public async Task ModifySummaryAsync(string email, string reportId, string summary)
    {
        var profile = await _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        var reportIndex = profile.Reports!.FindIndex(x => x.ReportId == reportId);
        profile.Reports[reportIndex].Summary = summary;
        await _database.UpdateAsync(profile);
    }
}
