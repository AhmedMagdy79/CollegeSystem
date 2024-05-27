using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.Core.Models.DB
{
    public class User : IdentityUser
    {
        public Admin Admin { get; set; }

        public Teacher Teacher { get; set; }

        public Student Student { get; set; }
        public ICollection<UserToken> UserToken { get; set; }
    }
}
