using Domain.Models;

namespace Weather.Services
{
    public interface IWeatherForecastService
    {
        void AddForecastByDay(WeatherForecastCelcius dayForecast);
        IEnumerable<WeatherForecastCelcius> GetWeekForecast();
    }
}