using Domain.Models;
using weather.domain.Exceptions;
using weather.repository.Repository;
using weather.services.Validators;

namespace weather.services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastService(ITemperatureValidator temperatureChecker, IWeatherForecastRepository weatherForecastRepository)
        {
            _temperatureChecker = temperatureChecker;
            _weatherForecastRepository = weatherForecastRepository;
        }

        private ITemperatureValidator _temperatureChecker;
        private IWeatherForecastRepository _weatherForecastRepository;

        public void AddForecastByDay(WeatherForecastCelcius dayForecast)
        {

            if (!_temperatureChecker.IsTemperatureInRange(dayForecast))
            {
                throw new ForecastInputException(message: $"Temperature not in range ({dayForecast.Temperature}).");
            }

            if (dayForecast.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0) {
                throw new ForecastInputException(message: $"cannot set forecast in the past! Forecast date ({dayForecast.Date}).");
            };

            _weatherForecastRepository.AddForecastByDay(dayForecast);

        }

        public IEnumerable<WeatherForecastCelcius> GetWeekForecast()
        {

            // TODO: Call Repository

            return _weatherForecastRepository.GetWeekForecast();
        }
    }
}