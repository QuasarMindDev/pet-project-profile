using Microsoft.Extensions.Options;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Models;
using Pet.Project.Profile.Infrastructure.Database.Repositories;

namespace Pet.Project.Profile.Infrastructure.Database.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly MongoContext _dbContext;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public DatabaseService(MongoContext dbContext, IOptions<DatabaseSettings> dbSettings)
        {
            _dbContext = dbContext;
            _dbSettings = dbSettings;
        }

        public IUserProfileRepository Profiles => new UserProfileRepository(_dbContext.Database, _dbSettings);
    }
}