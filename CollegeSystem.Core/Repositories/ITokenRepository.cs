using CollegeSystem.Core.Models.DB;

namespace CollegeSystem.Core.Repositories
{
    public interface ITokenRepository : IBaseRepository<UserToken>
    {
        Task<UserToken> GetToken(string userId, string token);
    }
}
