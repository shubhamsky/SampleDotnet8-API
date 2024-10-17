using Microsoft.AspNetCore.Mvc;
using VehicleStoreAPI.Service.WeatherAppServices;

namespace VehicleStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherAppService<WeatherForecast> _weatherAppService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherAppService<WeatherForecast> weatherAppService)
        {
            _logger = logger;
            _weatherAppService = weatherAppService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherAppService.GetData();
        }
    }
}
