using GlobalExceptionHandling.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Controllers
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
        private readonly ICustomException _customException;

        public WeatherForecastController(ICustomException customException,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _customException = customException;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            await _customException.GetData();
            
            return Ok(new { Message = "successs" });
        }
    }
}
