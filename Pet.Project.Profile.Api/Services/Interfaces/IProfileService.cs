using Pet.Project.Profile.Api.Dtos.Profile;

namespace Pet.Project.Profile.Api.Services.Interfaces;

public interface IProfileService
{
    public Task<Domain.Database.Models.Profile> GetProfileAsync(string email);

    public Task ModifyBirthDateAsync(BirthDateDto birthDateDto);

    public Task ModifyGenderAsync(GenderDto genderDto);

    public Task ModifyImagePathAsync(ImagePathDto imagePathDto);

    public Task ModifySummaryAsync(SummaryDto summaryDto);
}