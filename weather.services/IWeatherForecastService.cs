using Domain.Models;

namespace weather.services
{
    public interface IWeatherForecastService
    {
        void AddForecastByDay(ForecastByDay dayForecast);
        IEnumerable<ForecastByDay> GetWeekForecast();
    }
}