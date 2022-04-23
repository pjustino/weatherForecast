using Domain.Models;

namespace weather.web.models
{
    public class ForecastReportResult : ForecastBaseResult
    {
        public IEnumerable<FeelLikeForecastByDay> ForecastByDay { get; set; } = Enumerable.Empty<FeelLikeForecastByDay>();
    }
}
