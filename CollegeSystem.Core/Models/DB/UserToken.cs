namespace CollegeSystem.Core.Models.DB
{
    public class UserToken
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string Token { get; set; }

        public string TokenType { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMinutes(15);
    }
}
