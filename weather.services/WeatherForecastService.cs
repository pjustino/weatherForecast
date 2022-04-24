using Domain.Models;
using Weather.Domain.Exceptions;
using Weather.Repository.Data;
using Weather.Services.Validators;

namespace Weather.Services
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

            if (dayForecast.Date.CompareTo(DateTime.Now.Date) < 0) {
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