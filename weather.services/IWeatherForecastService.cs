using Domain.Models;

namespace weather.services
{
    public interface IWeatherForecastService
    {
        void AddForecast(ForecastByDay dayForecast);
        FeelLikeDayForecast GetWeeklyForecast(int startDayInput);
    }
}