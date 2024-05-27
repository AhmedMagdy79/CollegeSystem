namespace CollegeSystem.Core.Services
{
    public interface IUserService
    {
        Task<bool> CheckEmailVerificationTokenAsync(string userId, string token);

        Task<string> GenerateEmailVerifivationTokenAsync(string userId);
    }
}
