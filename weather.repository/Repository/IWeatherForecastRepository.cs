using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.repository.Repository
{
    public interface IWeatherForecastRepository
    {
        void AddForecastByDay(WeatherForecastCelcius dayForecast);
        IEnumerable<WeatherForecastCelcius> GetWeekForecast();
    }
}
