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
    public class StudentService : IStudentService
    {
        private readonly UserManager<User> _studentManager;
        private readonly ILogger<StudentService> _logger;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;



        public StudentService(UserManager<User> userMangaer,
                            ILogger<StudentService> logger,
                            IEmailService emailService,
                            IUserService userService)
        {
            _studentManager = userMangaer;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
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
            string logSignature = "<< StudentService --- Signup>>";
            try
            {
                var student = new Student { };
                var user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Student = student };
                _logger.LogInformation($"{logSignature} started signup student");
                var result = await _studentManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError($"{logSignature} Faild to signup student {result}");
                    return new ServiceResult<UserResponse> { StatusCode = 500 };
                }


                await _studentManager.AddClaimAsync(user, new Claim(Claims.IsStudentClaim, "true"));
                var token = await _userService.GenerateEmailVerifivationTokenAsync(user.Id);
                await _emailService.SendEmailVerificationTokenAsync(user.Email, token, user.Id);
                _logger.LogInformation($"{logSignature} finished signup student");
                return new ServiceResult<UserResponse> { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} sonthing went wrong while signing up student : {ex.Message}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }
        }
    }
}
