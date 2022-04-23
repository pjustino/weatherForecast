using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.services.Validators
{
    public interface ITemperatureValidator
    {
        bool IsTemperatureInRange(ForecastByDay dayForecast);
    }
}
