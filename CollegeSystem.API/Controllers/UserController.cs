﻿using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _userService;

        public UserController(IUserService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}/{token}")]
        public async Task<IActionResult> VerifyEmailToken(string userId, string token) 
        {
            if(userId == null || token == null) 
            {
                return BadRequest();
            }

            var isVerified = await _userService.CheckVerificationTokenAsync(userId, token);

            if(!isVerified)
            {
                return BadRequest("Unable to verify account");
            }
            return Ok("Account Verified");
        }
    }
}
