using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly UserManager<Student> _studentManager;
        private readonly SignInManager<User> _studentSignInManager;


        public StudentService(UserManager<Student> userMangaer, SignInManager<User> userSignInManager)
        {
            _studentManager = userMangaer;
            _studentSignInManager = userSignInManager;
        }

        public async Task<bool> IsExist(UserRequest model)
        {
            var res = await _studentManager.FindByEmailAsync(model.Email);

            if (res == null) { return false; }

            return true;
        }

        public Task<ServiceResult<UserResponse>> Login(string eamil, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserResponse>> Signup(UserRequest model)
        {
            var student = new Student { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _studentManager.CreateAsync(student, model.Password);

            if (result.Succeeded)
            {
                return new ServiceResult<UserResponse> { StatusCode = 201 };
            }

            return new ServiceResult<UserResponse> { StatusCode = 400 };
        }
    }
}
