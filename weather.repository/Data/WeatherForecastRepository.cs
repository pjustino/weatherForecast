using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Weather.Repository.Data
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly DataContext _db;

        public WeatherForecastRepository(DataContext db)
        {
            _db = db;
        }
        public async Task AddForecastByDay(WeatherForecastCelsius dayForecast)
        {
            using (var dbContextTransaction = _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Check for duplicates, update if already in DB or else add a new forecast.
                    var dbDatForecast = await _db.WeatherForecasts.FirstOrDefaultAsync( q => q.Date.Date == dayForecast.Date.Date );

                    if (dbDatForecast != null )
                    {
                        dbDatForecast.Temperature = dayForecast.Temperature;
                    }
                    else
                    {
                        await _db.WeatherForecasts.AddAsync(dayForecast);
                    }

                    await _db.SaveChangesAsync();

                    var transaction = await dbContextTransaction;
                    transaction.Commit();

                }
                catch (Exception)
                {
                    var transaction = await dbContextTransaction;
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<WeatherForecastCelsius>> GetWeekForecast()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(7);

             var result = await _db.WeatherForecasts.Where(forecast => forecast.Date.Date > startDate.Date.Date && forecast.Date.Date <= endDate.Date.Date)
                .OrderBy( f => f.Date)
                .Select(forecast => new WeatherForecastCelsius
                {
                    Id = forecast.Id,
                    Date = forecast.Date,
                    Temperature = forecast.Temperature
                }).ToListAsync();

            return result;
        }

    }
}
