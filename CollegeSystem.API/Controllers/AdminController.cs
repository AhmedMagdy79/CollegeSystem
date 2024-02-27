using CollegeSystem.API.Services;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController (IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("auth/signup")]
        public async Task<IActionResult> Signup(UserRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isExist = await _adminService.IsExist(model);

            if (isExist)
            {
                return BadRequest("This Mail Is Already Exist");
            }

            var result = await _adminService.Signup(model);

            if(result.StatusCode == 400)
            {
                return BadRequest("Something Went Wrong");
            }

            return StatusCode(201, "Admin Created Succesfully");

        }
    }
}
