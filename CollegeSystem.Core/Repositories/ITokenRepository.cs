using CollegeSystem.Core.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Repositories
{
    public interface ITokenRepository : IBaseRepository<UserToken>
    {
        UserToken GetToken(string userId, string token);
    }
}
