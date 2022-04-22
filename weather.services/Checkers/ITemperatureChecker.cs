using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.services.Checkers
{
    public interface ITemperatureChecker
    {
        bool IsTemperatureInRange(ForecastByDay dayForecast);
    }
}
