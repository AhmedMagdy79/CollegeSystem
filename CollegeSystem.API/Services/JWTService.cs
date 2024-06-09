using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Shared;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollegeSystem.API.Services
{
    public class JWTService : IJWTService
    {
        private readonly ILogger<JWTService> _logger;
        private readonly Jwt _settings;
        private readonly UserManager<User> _userManager;

        public JWTService(UserManager<User> userManager, ILogger<JWTService> logger, IOptions<Jwt> setting)
        {
            _userManager = userManager;
            _logger = logger;
            _settings = setting.Value;

        }

        public async Task<string> CreateToken(string userId)
        {
            string logSignature = "<< JWTService --- CreateToken >>";
            try
            {
                var user = await GetUserById(userId);

                _logger.LogInformation($"{logSignature} Start Generting Jwt Token");

                if (user == null)
                {
                    _logger.LogError($"{logSignature} user not found for user Id = {userId}");
                    return null;
                }

                var userClaims = await GetUserClaimsById(user);

                if (userClaims == null)
                {
                    _logger.LogError($"{logSignature} user claims not found for user Id = {userId}");
                    return null;
                }

                var jwtClaims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("uid", user.Id)
                }
                .Union(userClaims);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _settings.Issuer,
                    audience: _settings.Audience,
                    claims: jwtClaims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signingCredentials);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                _logger.LogInformation($"{logSignature} finished generating jwt");

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} sonthing went wrong while generating jwt : {ex.Message}");
                return null;
            }
        }

        private async Task<User> GetUserById(string id)
        {
           return await _userManager.FindByIdAsync(id);
        }

        private async Task<IList<Claim>> GetUserClaimsById(User user)
        {
            return await _userManager.GetClaimsAsync(user);
        }
    }
}
