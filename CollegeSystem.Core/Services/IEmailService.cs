namespace CollegeSystem.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailVerificationTokenAsync(string email, string token, string userId);
    }
}
