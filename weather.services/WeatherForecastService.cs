using Domain.Models;
using weather.domain.Exceptions;
using weather.services.Validators;

namespace weather.services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastService(ITemperatureValidator temperatureChecker)
        {
            _temperatureChecker = temperatureChecker;
        }

        private ITemperatureValidator _temperatureChecker;

        public void AddForecastByDay(ForecastByDay dayForecast)
        {

            if (!_temperatureChecker.IsTemperatureInRange(dayForecast))
            {
                throw new ForecastInputException(message: $"Temperature not in range ({dayForecast.Temperature} {dayForecast.Unit}).");
            }

            if (dayForecast.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0) {
                throw new ForecastInputException(message: $"cannot set forecast in the past! Forecast date: {dayForecast.Date} .");
            };

            // TODO: Add call to repository

        }

        public IEnumerable<ForecastByDay> GetWeekForecast()
        {

            // TODO: Call Repository

            return new List<ForecastByDay> { 
                new ForecastByDay
                {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Temperature = -2.5f
                },
                new ForecastByDay
                {
                    Date = DateOnly.FromDateTime(DateTime.Now).AddDays(1),
                    Temperature = 40
                }

            };
        }
    }
}