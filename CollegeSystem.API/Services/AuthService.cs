using CollegeSystem.Core;
using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Models.Response;
using CollegeSystem.Core.Services;

namespace CollegeSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Task Login(string eamil, string password)
        {
            throw new NotImplementedException();
        }

        public Task SignupStudent()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceReturn<UserResponse>> SignupTeacher(UserRequest model)
        {
            var user = new Admin { Email = model.Email, UserName = model.UserName,  PhoneNumber = model.PhoneNumber  };
            var result =  await _unitOfWork.AdminManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return new ServiceReturn<UserResponse> { StatusCode = 201};
            }

            return null;
        }

       
    }
}
