using Domain.Models;

namespace weather.web.models
{
    public class ForecastReportResult : ForecastInputResult
    {
        public IEnumerable<ForecastByDay> ForecastByDay { get; set; } = Enumerable.Empty<ForecastByDay>();
    }
}
