using System.Security.Claims;
using HMS.Application.Dtos.Profile;
using HMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // Get Logged-in User Profile
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var profile = await _profileService.GetProfileAsync(userId);

            if (profile == null)
                return NotFound("Profile not found.");

            return Ok(profile);
        }

        // Update Logged-in User Profile
        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            await _profileService.UpdateProfileAsync(userId, dto);

            return Ok(new
            {
                Message = "Profile updated successfully."
            });
        }
    }
}