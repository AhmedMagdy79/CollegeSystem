using CollegeSystem.Core.Models.DB;

namespace CollegeSystem.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailVerificationTokenAsync(string email, string token, string userId);

        Task PodcastAnnounsmentAsync(Announsment announsment);
    }
}
