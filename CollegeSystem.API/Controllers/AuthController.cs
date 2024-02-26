using CollegeSystem.Core.Models;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> signup(UserRequest model)
        {
            var res = await _authService.SignupTeacher(model);

            if(res == null)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new JsonResult(new { IsSuccess = false, Message= "Somthing Went Wrong" });
            }

            return Ok();
        }
    }
}
