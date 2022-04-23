using Domain.Converters;
using Domain.Models;

namespace weather.services.Validators
{
    public class TemperatureValidator : ITemperatureValidator
    {
        private readonly ITemperatureConverter _temperatureConverter1;
        public TemperatureValidator(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter1 = temperatureConverter;
        }
        public bool IsTemperatureInRange(ForecastByDay dayForecast)
        {
            var temperature = _temperatureConverter1.ToCelsius(dayForecast.Temperature, dayForecast.Unit);

            return temperature >= ((float)TemperatureRangeCelsius.MIN)
                && temperature <= ((float)TemperatureRangeCelsius.MAX);
        }
    }
}
