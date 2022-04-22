using Domain.Models;
using weather.domain.Exceptions;
using weather.services.Checkers;

namespace weather.services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastService(ITemperatureChecker temperatureChecker)
        {
            _temperatureChecker = temperatureChecker;
        }

        private ITemperatureChecker _temperatureChecker;

        public void AddForecast(ForecastByDay dayForecast)
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

        public FeelLikeDayForecast GetWeeklyForecast(int startDayInput)
        {
            var startDay = DateOnly.FromDayNumber(startDayInput);

            // TODO: Call Repository

            return new FeelLikeDayForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureFeel = "warm"
            };
        }
    }
}