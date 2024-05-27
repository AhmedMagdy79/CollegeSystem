using CollegeSystem.Core.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            var test = typeof(Student);
            return new JsonResult(new { test1 = test.FullName });
        }
    }
}