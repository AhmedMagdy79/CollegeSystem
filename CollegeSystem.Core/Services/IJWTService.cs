namespace CollegeSystem.Core.Services
{
    public interface IJWTService
    {
        Task<string> CreateToken(string userId);
    }
}
