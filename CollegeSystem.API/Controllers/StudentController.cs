﻿using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Policy = Policy.AdminPolicy)]
        [HttpPost("auth/signup")]
        public async Task<IActionResult> Signup(UserRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isExist = await _studentService.IsExist(model);

            if (isExist)
            {
                return BadRequest("This Mail Is Already Exist");
            }

            var result = await _studentService.Signup(model);

            if (result.StatusCode == 400)
            {
                return BadRequest("Something Went Wrong");
            }

            return StatusCode(201, "Student Created Succesfully");

        }
    }
}
