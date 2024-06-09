using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;

namespace CollegeSystem.Core.Services
{
    public interface IUserService
    {
        Task<bool> CheckEmailVerificationTokenAsync(string userId, string token);

        Task<string> GenerateEmailVerifivationTokenAsync(string userId);

        Task<LogInResponse> LogInAsync(LogInRequest request);
    }
}
