using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;

namespace CollegeSystem.Core.Services
{
    public interface IAdminService
    {
        Task<ServiceResult<UserResponse>> Login(string eamil, string password);

        Task<ServiceResult<UserResponse>> Signup(UserRequest model);

        Task<bool> IsExist(UserRequest model);
    }
}
