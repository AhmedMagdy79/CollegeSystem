using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [Authorize(Policy = Policy.AdminPolicy)]
        [HttpPost("auth/signup")]
        public async Task<IActionResult> Signup(TeacherRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isExist = await _teacherService.IsExist(model);

            if (isExist)
            {
                return BadRequest("This Mail Is Already Exist");
            }

            var result = await _teacherService.Signup(model);

            if (result.StatusCode == 500)
            {
                return BadRequest("Something Went Wrong");
            }

            return StatusCode(201, "Teacher Created Succesfully");

        }
    }
}
