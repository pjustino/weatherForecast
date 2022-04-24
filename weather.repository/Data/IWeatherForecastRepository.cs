using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Repository.Data
{
    public interface IWeatherForecastRepository
    {
        Task AddForecastByDay(WeatherForecastCelsius dayForecast);
        Task<IEnumerable<WeatherForecastCelsius>> GetWeekForecast();
    }
}
