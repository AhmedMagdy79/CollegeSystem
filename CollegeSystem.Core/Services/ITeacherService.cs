using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;

namespace CollegeSystem.Core.Services
{
    public interface ITeacherService
    {
        Task<ServiceResult<UserResponse>> Login(string eamil, string password);

        Task<ServiceResult<UserResponse>> Signup(TeacherRequest model);

        Task<bool> IsExist(TeacherRequest model);
    }
}
