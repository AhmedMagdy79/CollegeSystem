using CollegeSystem.Core;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace CollegeSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ILogger<UserService> logger,
            UserManager<User> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckEmailVerificationTokenAsync( string userId, string token)
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

        public async Task<string> GenerateEmailVerifivationTokenAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            /*await Task.Delay(new TimeSpan(0, 0, 30)).ContinueWith(async o => 
             { var result = await _userManager.ConfirmEmailAsync(user, token); Console.WriteLine("ana hena y jou"); });*/
            return token;
        }

        private string GenerateEmailConfirmationTokenAsync(string userId)
        {

        }
    }
}
