﻿using CollegeSystem.Core;
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
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _adminManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminService> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;


        public AdminService(UserManager<User> adminMangaer,
                            IUnitOfWork unitOfWork,
                            ILogger<AdminService> logger,
                            IEmailService emailService,
                            IUserService userService)
        {
            _adminManager = adminMangaer;
            _unitOfWork = unitOfWork;
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
            try
            {
                var admin = new Admin { };
                var user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber, Admin = admin };
                _logger.LogInformation($"{logSignature} started to signup teacher");
                var result = await _adminManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError($"{logSignature} Faild to signup Admin {result}");
                    return new ServiceResult<UserResponse> { StatusCode = 500 };
                }

                await _adminManager.AddClaimAsync(user, new Claim(Claims.IsAdminClaim, "true"));
                var token = await _userService.GenerateEmailVerifivationTokenAsync(user.Id);
                await _emailService.SendEmailVerificationTokenAsync(user.Email, token, user.Id);
                _logger.LogInformation($"{logSignature} finished signup teacher");
                return new ServiceResult<UserResponse> { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} sonthing went wrong while signing up admin : {ex.Message}");
                return new ServiceResult<UserResponse> { StatusCode = 500 };
            }

        }

    }
}
