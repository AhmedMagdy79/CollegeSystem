namespace CollegeSystem.Core.Models.Shared
{
    public class EmailSettings
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string SmtpClient { get; set; }

        public int SmtpPortNumber { get; set; }

        public string ConfirmMailUrl { get; set; }
    }
}
