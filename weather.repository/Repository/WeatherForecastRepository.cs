using Domain.Models;

namespace Weather.Repository.Data
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
                  where forecast.Date >= startDate.Date && forecast.Date <= endDate.Date
                  orderby forecast.Date
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
