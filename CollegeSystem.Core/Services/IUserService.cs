using CollegeSystem.Core.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IUserService<TUser>
    {
        Task<bool> CheckVerificationTokenAsync(string token, string userId);

        Task<string> GenerateVerificationTokenAsync(TUser user);
    }
}
