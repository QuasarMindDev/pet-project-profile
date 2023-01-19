using Microsoft.AspNetCore.Mvc;
using Pet.Project.Profile.Api.Services.Interfaces;
using Pet.Project.Profile.Domain.Database.Models;

namespace Pet.Project.Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ILogger<IUserProfileService> _logger;
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(ILogger<IUserProfileService> logger, IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfileAsync(UserProfile userProfile)
        {
            try
            {
                await _userProfileService.CreateUserProfileAsync(userProfile);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return NotFound();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return BadRequest();
                throw;
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserProfileAsync(string email)
        {
            try
            {
                return Ok(await _userProfileService.GetUserProfileAsync(email));
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return NotFound();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return BadRequest();
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetUsersProfile()
        {
            try
            {
                return Ok(_userProfileService.GetUsersProfile());
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return NotFound();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return BadRequest();
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyUserProfileAsync(UserProfile userProfile)
        {
            try
            {
                await _userProfileService.ModifyUserProfileAsync(userProfile);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return NotFound();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("{errorMessage}", ex.Message);
                return BadRequest();
                throw;
            }
        }
    }
}