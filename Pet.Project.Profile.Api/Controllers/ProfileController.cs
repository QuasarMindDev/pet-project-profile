using Microsoft.AspNetCore.Mvc;
using Pet.Project.Profile.Api.Dtos.Profile;
using Pet.Project.Profile.Api.Services.Interfaces;

namespace Pet.Project.Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<IProfileService> _logger;
        private readonly IProfileService _profileService;

        public ProfileController(ILogger<IProfileService> logger, IProfileService profileService)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileAsync(string email)
        {
            try
            {
                return Ok(await _profileService.GetProfileAsync(email));
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

        [HttpPut("birthDate")]
        public async Task<IActionResult> ModifyBirthDateAsync(BirthDateDto birthDateDto)
        {
            try
            {
                await _profileService.ModifyBirthDateAsync(birthDateDto);
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

        [HttpPut("gender")]
        public async Task<IActionResult> ModifyGenderAsync(GenderDto genderDto)
        {
            try
            {
                await _profileService.ModifyGenderAsync(genderDto);
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

        [HttpPut("imagePath")]
        public async Task<IActionResult> ModifyImagePathAsync(ImagePathDto imagePathDto)
        {
            try
            {
                await _profileService.ModifyImagePathAsync(imagePathDto);
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

        [HttpPut("summary")]
        public async Task<IActionResult> ModifySummaryAsync(SummaryDto summaryDto)
        {
            try
            {
                await _profileService.ModifySummaryAsync(summaryDto);
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