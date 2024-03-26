using CollegeSystem.API.Factory;
using CollegeSystem.Core.Factory;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManagerFactory _managerFactory;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, IUserManagerFactory managerFactory,
            UserManager<IdentityUser> userManager)
        {
            _managerFactory = managerFactory;
            this.userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> CheckVerificationTokenAsync(string token, string userId, string userType)
        {
            string logSignature = "<< UserService --- CheckVerificationTokenAsync  >>";
            
            var user = await userManager.FindByIdAsync(userId);
            
            if (user == null)
            {
                _logger.LogError($"{logSignature} Faild to find user");
                return false;
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                _logger.LogError($"{logSignature} Faild to verify user {result}");
                return false;
            }

            return true;
        }

        private Task<bool> VerifyEmailToken(string userId, string token, UserManager<Admin> userManager) { }
    }
}
