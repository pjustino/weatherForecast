using Domain.Converters;
using Domain.Models;

namespace weather.services.Checkers
{
    public class TemperatureChecker : ITemperatureChecker
    {
        private double ConvertCelsiusToFahrenheit( int celsiusTemp)
        {
            return 1.8 * celsiusTemp + 32;
        }

        public bool IsTemperatureInRange(ForecastByDay dayForecast)
        {
            var temperatureConverter = new TemperatureConverter();
            var temperature = temperatureConverter.ToCelsius(dayForecast.Temperature, dayForecast.Unit);

            return temperature >= ((float)TemperatureRangeCelsius.MIN)
                && temperature <= ((float)TemperatureRangeCelsius.MAX);
        }
    }
}
