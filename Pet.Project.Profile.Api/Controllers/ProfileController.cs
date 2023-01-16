using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pet.Project.Profile.Domain.Database;
using Pet.Project.Profile.Domain.Database.Models;
using Pet.Project.Profile.Infrastructure.Database.Services;

namespace Pet.Project.Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _database;

        public ProfileController(IDatabaseService dataService)
        {
            _database = dataService.Profiles;
        }

        [HttpDelete("{email}")]
        public async Task DeleteByIdAsync(string email)
        {
            await _database.DeleteAsync(x => x.Email!.EmailAddress == email);
        }

        [HttpGet("{email}")]
        public Task<UserProfile> GetSingleAsync(string email)
        {
            return _database.GetSingleAsync(x => x.Email!.EmailAddress == email);
        }

        [HttpGet]
        public IEnumerable<UserProfile> Get()
        {
            return _database.GetAll();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] UserProfile model)
        {
            await _database.AddAsync(model);
        }

        [HttpPut("{email}")]
        public async Task PutAsync([FromBody] UserProfile model)
        {
            await _database.UpdateAsync(model);
        }
    }
}