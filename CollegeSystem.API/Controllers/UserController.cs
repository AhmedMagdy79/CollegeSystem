using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}/{token}")]
        public async Task<IActionResult> VerifyEmailToken(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest();
            }

            var isVerified = await _userService.CheckEmailVerificationTokenAsync(userId, token);

            if (!isVerified)
            {
                return BadRequest("Unable to verify account");
            }
            return Ok("Account Verified");
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.LogInAsync(request);

            if (result == null)
            {
                return BadRequest("Wrong email or password");
            }

            return Ok(result);
        }
    }
}
