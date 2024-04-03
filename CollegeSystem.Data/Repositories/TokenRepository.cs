using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Data.Repositories
{
    internal class TokenRepository : BaseRepository<UserToken>, ITokenRepository
    {

        public TokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<UserToken> GetToken(string userId, string token)
        {
            var usertoken = await _context.UserTokens.FindAsync(userId, token);
            if (usertoken == null)
            {
                return null;
            }
            return usertoken;
        }
    }
}
