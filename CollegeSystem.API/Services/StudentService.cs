using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CollegeSystem.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly UserManager<Student> _studentManager;
        private readonly SignInManager<User> _studentSignInManager;
        private readonly ILogger<StudentService> _logger;
        private readonly IEmailService _emailService;


        public StudentService(UserManager<Student> userMangaer,
                            SignInManager<User> userSignInManager,
                            ILogger<StudentService> logger,
                            IEmailService emailService)
        {
            _studentManager = userMangaer;
            _studentSignInManager = userSignInManager;
            _logger = logger;
            _emailService = emailService;
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
            var student = new Student { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await _studentManager.CreateAsync(student, model.Password);


            if (!result.Succeeded)
            {
                _logger.LogError($"{logSignature} Faild to signup student {result}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }


            await _studentManager.AddClaimAsync(student, new Claim("IsStudent", "true"));
            var token = await _studentManager.GenerateEmailConfirmationTokenAsync(student);
            await _emailService.SendVerificationTokenAsync(student.Email, token, student.Id);
            return new ServiceResult<UserResponse> { StatusCode = 201 };
        }
    }
}
