using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Weather.Services;
using Weather.Web.Models;
using Weather.Domain.Exceptions;
using Domain.Converters;
using Weather.Web.Mappers;
using Web.Models;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ITemperatureForecastMapper _temperatureForecastMapper;
        private readonly ITemperatureConverter _temperatureConverter1;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService,
            ITemperatureForecastMapper temperatureForecastMapper,
            ITemperatureConverter temperatureConverter
            )
        {
            _logger = logger;
            _temperatureForecastMapper = temperatureForecastMapper;
            _temperatureConverter1 = temperatureConverter;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var weeklyForecast = await _weatherForecastService.GetWeekForecast();

            var feelLikeReport = weeklyForecast.Select(wf =>
            {
                return new FeelLikeForecastByDay
                {
                    TemperatureFeel = _temperatureForecastMapper.MapCelsiusToFeelFormat(wf.Temperature),
                    Date = wf.Date.ToShortDateString()
                };
            });

            return Ok(new ForecastReportResult {
                ForecastByDay = feelLikeReport.ToList(),
                Success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ForecastInput forecastInput)
        {
            var temperatureConverter = new TemperatureConverter();

            var newForecast = new WeatherForecastCelcius
            {
                Date = forecastInput.Date.GetValueOrDefault(),
                Temperature = temperatureConverter.ToCelsius(forecastInput.Temperature.GetValueOrDefault(), forecastInput.unit),
            };

            try
            {
               await _weatherForecastService.AddForecastByDay(newForecast);
            }
            catch (ForecastInputException ex)
            {
                _logger.LogError("Invalid input forecast data.", ex);

                return BadRequest( new ForecastBaseResult
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }

            return Ok(new ForecastBaseResult
            {
                Success = true
            });
        }
    }
}