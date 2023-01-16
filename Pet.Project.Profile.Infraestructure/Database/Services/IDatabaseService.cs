using Pet.Project.Profile.Domain.Database;

namespace Pet.Project.Profile.Infrastructure.Database.Services
{
    public interface IDatabaseService
    {
        public IUserProfileRepository Profiles { get; }
    }
}