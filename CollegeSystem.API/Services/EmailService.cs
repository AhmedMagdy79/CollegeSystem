using CollegeSystem.Core.Services;
using System.Net.Mail;
using System.Net;
using System;
using CollegeSystem.Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using CollegeSystem.Core.Models.DB;
using Microsoft.Extensions.Options;

namespace CollegeSystem.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings) 
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailVerificationTokenAsync(string email, string token, string userId)
        {
            var client = new SmtpClient(_emailSettings.SmtpClient, _emailSettings.SmtpPortNumber)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)
            };
            
            var message = string.Format(_emailSettings.ConfirmMailUrl, userId, token);
            var subject = "College Verification";
            await client.SendMailAsync(
                new MailMessage(from: _emailSettings.Email,
                                to: email,
                                subject,
                                message
                                ));
            return;
        }
    }
}
