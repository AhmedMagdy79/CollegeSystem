using CollegeSystem.Core;
using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<User> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTService _jwtService;

        public UserService(ILogger<User> logger,
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<bool> CheckEmailVerificationTokenAsync(string userId, string token)
        {
            string logSignature = "<< UserService --- CheckVerificationTokenAsync  >>";

            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"{logSignature} Faild to find user");
                    return false;
                }

                var userToken = await _unitOfWork.Tokens.GetToken(userId, token);

                if (userToken == null || userToken.EndDate < DateTime.UtcNow || userToken.TokenType != TokenTypes.Confirm_Email)
                {
                    _logger.LogError($"{logSignature} Faild to verify user");
                    return false;
                }

                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while verifing user account : {ex.Message}");
                return false;
            }
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

        public async Task<LogInResponse> LogInAsync(LogInRequest request)
        {
            var logSignature = "<< UserService --- LogInAsync >>";
            try
            {
                var user = await _userManager.FindByNameAsync(request.Email);

                if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    return null;
                }

                var token = await _jwtService.CreateToken(user.Id);

                return new LogInResponse { Email = user.Email , AccessToken = token };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while loging in to user account : {ex.Message}");
                return null;
            }
        }
    }
}
