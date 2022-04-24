using Domain.Models;

namespace Weather.Services
{
    public interface IWeatherForecastService
    {
        Task AddForecastByDay(WeatherForecastCelsius dayForecast);
        Task<IEnumerable<WeatherForecastCelsius>> GetWeekForecast();
    }
}