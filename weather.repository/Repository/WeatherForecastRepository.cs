using Domain.Models;

namespace weather.repository.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly DataContext _db;

        public WeatherForecastRepository(DataContext db)
        {
            _db = db;
        }
        public void AddForecastByDay(WeatherForecastCelcius dayForecast)
        {
            _db.WeatherForecasts.Add(dayForecast);
            _db.SaveChanges();
        }

        public IEnumerable<WeatherForecastCelcius> GetWeekForecast()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(7);

           var query =  from forecast in _db.WeatherForecasts
                  where forecast.Date >= startDate && forecast.Date <= endDate
                  select new WeatherForecastCelcius
                  {
                      Id = forecast.Id,
                      Date = forecast.Date,
                      Temperature = forecast.Temperature
                  };
            return query.ToList();
        }

    }
}
