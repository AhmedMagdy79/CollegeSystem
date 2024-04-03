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
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserToken GetToken(string userId, string token)
        {
            var token = _context.UserTokens.FindAsync(t => t.UserId );
        }
    }
}
