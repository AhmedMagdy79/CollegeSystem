using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<User> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> CheckVerificationTokenAsync(string userId, string token)
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


        public async Task<string> GenerateVerificationTokenAsync(string userId)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return token;
        }

        private string GenerateEmailConfirmationTokenAsync(string userId)
        {

        }
    }
}
