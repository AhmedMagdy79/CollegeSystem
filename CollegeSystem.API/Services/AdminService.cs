using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<Admin> _adminManager;
        private readonly SignInManager<User> _adminSignInManager;


        public AdminService(UserManager<Admin> adminMangaer ,SignInManager<User> adminSignInManager)
        {
            _adminManager = adminMangaer;
            _adminSignInManager = adminSignInManager;
        }

        public async Task<bool> IsExist(UserRequest model)
        {
            var res = await _adminManager.FindByEmailAsync(model.Email);

            if (res == null) { return false; }

            return true;
        }

        public Task<ServiceResult<UserResponse>> Login(string eamil, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserResponse>> Signup(UserRequest model)
        {
            var admin = new Admin { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _adminManager.CreateAsync(admin, model.Password);

            if (result.Succeeded)
            {
                return new ServiceResult<UserResponse> { StatusCode = 201 };
            }

            return new ServiceResult<UserResponse> { StatusCode = 400 };
        }

    }
}
