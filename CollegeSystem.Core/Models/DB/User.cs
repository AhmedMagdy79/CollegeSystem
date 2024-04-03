using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
