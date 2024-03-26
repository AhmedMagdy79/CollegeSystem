using CollegeSystem.API.Services;
using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Factory;
using CollegeSystem.Core.Models.DB;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.API.Factory
{
    public class UserManagerFactory : IUserManagerFactory
    {
        private readonly UserManager<Student> _studentManager;
        private readonly UserManager<Teacher> _teacherManager;
        private readonly UserManager<Admin> _adminManager;
        private readonly ILogger<UserManagerFactory> _logger;

        public UserManagerFactory(ILogger<UserManagerFactory> logger,
                           UserManager<Student> studentManager,
                           UserManager<Teacher> teacherManager,
                           UserManager<Admin> adminManager)
        {
            _studentManager = studentManager;
            _teacherManager = teacherManager;
            _adminManager = adminManager;
            _logger = logger;
        }


        public async UserManager<User> GetUserManager(string userType)
        {
            var student = await _studentManager.FindByIdAsync(userType);

            string logSignature = "<< UserManagerFactory --- GetUserManager  >>";
            switch (userType)
            {
                case UserTypes.Admin:
                    return _adminManager as UserManager<Admin>;
                case UserTypes.Student:
                    return _studentManager as UserManager<Student>;
                case UserTypes.Teacher:
                    return _teacherManager as UserManager<Teacher>;
                default:
                    _logger.LogError($"{logSignature} this user type : {userType} is not supported.");
                    return null;
            }
        }
    }

    public interface IUserManger
    {

    }
}
