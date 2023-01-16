using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Domain.Models;
using System.Linq.Expressions;

namespace Pet.Project.Profile.Infrastructure.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IMongoCollection<UserProfile> _profiles;

        public UserProfileRepository(IMongoDatabase database, IOptions<DatabaseSettings> dbOptions)
        {
            _profiles = database.GetCollection<UserProfile>(dbOptions.Value.CollectionName);
        }

        public async Task AddAsync(UserProfile profile)
        {
            await _profiles.InsertOneAsync(profile);
        }

        public async Task DeleteAsync(Expression<Func<UserProfile, bool>> predicate)
        {
           await _profiles.DeleteOneAsync(predicate);
        }

        public IQueryable<UserProfile> GetAll()
        {
            return _profiles.AsQueryable();
        }

        public async Task<UserProfile> GetSingleAsync(Expression<Func<UserProfile, bool>> predicate)
        {
            var filter = Builders<UserProfile>.Filter.Where(predicate);
            return (await _profiles.FindAsync(filter)).FirstOrDefault();
        }

        public Task<UserProfile> UpdateAsync(UserProfile profile)
        {
            return  _profiles.FindOneAndReplaceAsync(x => x.Email!.EmailAddress == profile.Email!.EmailAddress, profile);
        }
    }
}