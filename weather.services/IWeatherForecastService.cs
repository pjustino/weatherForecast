using Domain.Models;

namespace Weather.Services
{
    public interface IWeatherForecastService
    {
        Task AddForecastByDay(WeatherForecastCelcius dayForecast);
        Task<IEnumerable<WeatherForecastCelcius>> GetWeekForecast();
    }
}