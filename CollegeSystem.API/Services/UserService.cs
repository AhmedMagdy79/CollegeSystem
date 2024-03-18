using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<IdentityUser> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> CheckVerificationTokenAsync(string token, string userId)
        {
            string logSignature = "<< UserService --- CheckVerificationTokenAsync  >>";

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"{logSignature} Faild to find user");
                return false;
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                _logger.LogError($"{logSignature} Faild to verify user {result}");
                return false;
            }

            return true;
        }
    }
}
