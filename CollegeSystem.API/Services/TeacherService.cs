using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CollegeSystem.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<User> _teacherManager;
        private readonly ILogger<TeacherService> _logger;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;


        public TeacherService(UserManager<User> teacherMangaer,
                            ILogger<TeacherService> Logger,
                            IEmailService emailService,
                            IUserService userService)
        {
            _teacherManager = teacherMangaer;
            _logger = Logger;
            _emailService = emailService;
            _userService = userService;
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
            try
            {
                var teacher = new Teacher { Salary = model.Salary };
                var user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Teacher = teacher };

                _logger.LogInformation($"{logSignature} Started Signup Teacher");
                var result = await _teacherManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError($"{logSignature} Faild to signup teacher {result}");
                    return new ServiceResult<UserResponse> { StatusCode = 500 };
                }

                await _teacherManager.AddClaimAsync(user, new Claim(Claims.IsTeacherClaim, "true"));
                var token = await _userService.GenerateEmailVerifivationTokenAsync(user.Id);
                await _emailService.SendEmailVerificationTokenAsync(user.Email, token, user.Id);
                _logger.LogInformation($"{logSignature} Finished Signup Teacher");
                return new ServiceResult<UserResponse> { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} sonthing went wrong while signing up teacher : {ex.Message}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }
        }
    }
}
