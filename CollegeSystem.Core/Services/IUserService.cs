using CollegeSystem.Core.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IUserService
    {
        Task<bool> CheckEmailVerificationTokenAsync( string userId, string token);

        Task<string> GenerateEmailVerifivationTokenAsync(string userId);
    }
}
