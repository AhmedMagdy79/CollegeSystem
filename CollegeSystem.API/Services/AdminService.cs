using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CollegeSystem.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<Admin> _adminManager;
        private readonly SignInManager<User> _adminSignInManager;
        private readonly ILogger<AdminService> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;


        public AdminService(UserManager<Admin> adminMangaer,
                            SignInManager<User> adminSignInManager,
                            ILogger<AdminService> logger,
                            IEmailService emailService,
                            IUserService userService)
        {
            _adminManager = adminMangaer;
            _adminSignInManager = adminSignInManager;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
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
            string logSignature = "<< AdminService --- Signup>>";
            var admin = new Admin { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _adminManager.CreateAsync(admin, model.Password);

            
            if (!result.Succeeded)
            {
                _logger.LogError($"{logSignature} Faild to signup Admin {result}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }


            await _adminManager.AddClaimAsync(admin, new Claim("IsAdmin", "true"));
            var token = await _userService.GenerateVerificationTokenAsync(admin);
            await _emailService.SendVerificationTokenAsync(admin.Email, token, admin.Id);
            return new ServiceResult<UserResponse> { StatusCode = 201 };
        }

    }
}
