using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace CollegeSystem.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<Teacher> _teacherManager;
        private readonly SignInManager<User> _teacherSignInManager;
        private readonly ILogger<TeacherService> _logger;


        public TeacherService(UserManager<Teacher> teacherMangaer, SignInManager<User> teacherSignInManager, ILogger<TeacherService> Logger)
        {
            _teacherManager = teacherMangaer;
            _teacherSignInManager = teacherSignInManager;
            _logger = Logger;
        }

        public async Task<bool> IsExist(TeacherRequest model)
        {
           var res = await _teacherManager.FindByEmailAsync(model.Email);

            if (res == null) { return false; }

            return false;
        }

        public Task<ServiceResult<UserResponse>> Login(string eamil, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserResponse>> Signup(TeacherRequest model)
        {
            string logSignature = "<< TeacherService --- Signup  >>";
            var teacher = new Teacher { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Salary = model.Salary };

            var result = await _teacherManager.CreateAsync(teacher, model.Password);

            if (!result.Succeeded)
            {
                _logger.LogError( $"{logSignature} Faild to signup teacher {result}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }

            await _teacherManager.AddClaimAsync(teacher, new Claim("IsTeacher", "true"));

            return new ServiceResult<UserResponse> { StatusCode = 201};
        }
    }
}
