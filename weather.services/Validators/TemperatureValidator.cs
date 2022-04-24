using Domain.Converters;
using Domain.Models;

namespace Weather.Services.Validators
{
    public class TemperatureValidator : ITemperatureValidator
    {
        private readonly ITemperatureConverter _temperatureConverter1;
        public TemperatureValidator(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter1 = temperatureConverter;
        }
        public bool IsTemperatureInRange(WeatherForecastCelcius dayForecast)
        {

            return dayForecast.Temperature >= ((float)TemperatureRangeCelsius.MIN)
                && dayForecast.Temperature <= ((float)TemperatureRangeCelsius.MAX);
        }
    }
}
