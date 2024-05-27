using CollegeSystem.Core;
using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

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

        public async Task<bool> CheckEmailVerificationTokenAsync(string userId, string token)
        {
            string logSignature = "<< UserService --- CheckVerificationTokenAsync  >>";

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"{logSignature} Faild to find user");
                return false;
            }

            var userToken = await _unitOfWork.Tokens.GetToken(userId, token);

            if (userToken == null && userToken.EndDate > DateTime.UtcNow && userToken.TokenType == TokenTypes.Confirm_Email)
            {
                _logger.LogError($"{logSignature} Faild to verify user");
                return false;
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<string> GenerateEmailVerifivationTokenAsync(string userId)
        {
            var token = GenerateEmailConfirmationToken(userId);
            var userToken = new UserToken { Token = token, UserId = userId, TokenType = TokenTypes.Confirm_Email };
            await _unitOfWork.Tokens.AddAsync(userToken);
            await _unitOfWork.SaveAsync();
            return token;
        }

        private string GenerateEmailConfirmationToken(string userId)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(100000, 999999);
            return randomNumber + "";
        }
    }
}
