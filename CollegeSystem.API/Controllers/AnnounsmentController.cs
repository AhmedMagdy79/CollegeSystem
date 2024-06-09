using CollegeSystem.Core.Constants;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounsmentController : ControllerBase
    {
        private IAnnounsmentService _announsmentService;

        public AnnounsmentController(IAnnounsmentService announsmentService)
        {
            _announsmentService = announsmentService;
        }


        [HttpPost]
        [Authorize(Policy = Policy.AdminPolicy)]
        public async Task<IActionResult> AddAnnounsment(AnnounsmentRequest announsment ) 
        {
            var result = await _announsmentService.AddAnnounsmentAsync(announsment);

            if(result == null)
            {
                return BadRequest("failed to add new announsment");
            }

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _announsmentService.GetAllAnnounsmentAsync();

            if (result.Count == 0)
            {
                return BadRequest("failed to get announsments");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _announsmentService.GetAnnounsmentByIdAsync(id);
            
            if (result == null)
            {
                return BadRequest("failed to get announsment");
            }

            return Ok(result);
        }


    }
}
