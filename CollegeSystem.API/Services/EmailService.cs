using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Shared;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CollegeSystem.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, UserManager<User> userManager, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task PodcastAnnounsmentAsync(Announsment announsment)
        {
            var logSignature = "<< EmailService --- PodcastAnnounsmentAsync>>";

            try
            {
                var client = GetSmtpClient();
                var body = GenerateAnnounsmentMessage(announsment);

                var users = await _userManager.Users.ToListAsync();

                _logger.LogInformation($"{logSignature} starting sending announsment emails users");

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.Email),
                    Subject = "New Announsment",
                    Body = body,
                };

                foreach (var user in users)
                {
                    mailMessage.To.Add(user.Email);
                }

                await client.SendMailAsync(mailMessage);

                _logger.LogInformation($"{logSignature} starting sending announsment emails users");

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while sending announsment mails : {ex.Message}");
                return;
            }
        }

        public async Task SendEmailVerificationTokenAsync(string email, string token, string userId)
        {
            var logSignature = "<< EmailService --- SendEmailVerificationTokenAsync>>";
            try
            {
                var client = GetSmtpClient();
                _logger.LogInformation($"{logSignature} starting sending Verification Token for userid : {userId}");
                var message = string.Format(_emailSettings.ConfirmMailUrl, userId, token);
                var subject = "College Verification";
                await client.SendMailAsync(
                    new MailMessage(from: _emailSettings.Email,
                                    to: email,
                                    subject,
                                    message
                                    ));
                _logger.LogInformation($"{logSignature} finished sending Verification Token for userid : {userId}");

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while sending verification mail : {ex.Message}");
                return;
            }
            
        }

        private SmtpClient GetSmtpClient()
        {
            return new SmtpClient(_emailSettings.SmtpClient, _emailSettings.SmtpPortNumber)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)
            };
        }

        private string GenerateAnnounsmentMessage(Announsment announsment)
        {
            return $"Title : {announsment.Title}\nDiscription : {announsment.Description}\n Time : {announsment.Date}";
        }
    }
}
