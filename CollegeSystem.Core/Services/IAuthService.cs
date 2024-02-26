using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IAuthService
    {
        Task Login(string eamil, string password);

        Task<ServiceReturn<UserResponse>> SignupTeacher(UserRequest model);

        Task SignupStudent();
    }
}
