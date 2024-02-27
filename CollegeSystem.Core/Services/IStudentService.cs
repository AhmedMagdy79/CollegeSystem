using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IStudentService
    {
        Task<ServiceResult<UserResponse>> Login(string eamil, string password);

        Task<ServiceResult<UserResponse>> Signup(UserRequest model);

        Task<bool> IsExist(UserRequest model);
    }
}
