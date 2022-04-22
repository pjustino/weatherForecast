using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using weather.services;
using weather.web.models;
using weather.domain.Exceptions;

namespace WeatherForecast.Controllers
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
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5).ToArray();
        }

        [HttpPost]
        public IActionResult Post(ForecastInput forecastInput)
        {
            var temperatureConverter = new TemperatureConverter();

            var newForecast = new ForecastByDay
            {
                Date = DateOnly.FromDateTime(forecastInput.Date),
                Temperature = temperatureConverter.ToCelsius(forecastInput.Temperature, forecastInput.unit),
                Unit = TemperatureUnit.CELSIUS
            };

                _weatherForecastService.AddForecast(newForecast);

            return Ok(new ForecastInputResult
            {
                Success = true
            });
        }
    }
}