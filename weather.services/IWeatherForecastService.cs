using Domain.Models;

namespace weather.services
{
    public interface IWeatherForecastService
    {
        void AddForecastByDay(WeatherForecastCelcius dayForecast);
        IEnumerable<WeatherForecastCelcius> GetWeekForecast();
    }
}