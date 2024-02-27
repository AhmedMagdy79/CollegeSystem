using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<Teacher> _teacherManager;
        private readonly SignInManager<User> _teacherSignInManager;


        public TeacherService(UserManager<Teacher> teacherMangaer, SignInManager<User> teacherSignInManager)
        {
            _teacherManager = teacherMangaer;
            _teacherSignInManager = teacherSignInManager;
        }

        public async Task<bool> IsExist(TeacherRequest model)
        {
           var res = await _teacherManager.FindByEmailAsync(model.Email);

            if (res == null) { return false; }

            return true;
        }

        public Task<ServiceResult<UserResponse>> Login(string eamil, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserResponse>> Signup(TeacherRequest model)
        {
            var teacher = new Teacher { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Salary = model.Salary };
            var result = await _teacherManager.CreateAsync(teacher, model.Password);

            if (result.Succeeded)
            {
                return new ServiceResult<UserResponse> { StatusCode = 201};
            }

            return new ServiceResult<UserResponse> { StatusCode = 500 };
        }
    }
}
