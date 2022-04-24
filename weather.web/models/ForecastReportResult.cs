using Web.Models;

namespace Weather.Web.Models
{
    public class ForecastReportResult : ForecastBaseResult
    {
        public IEnumerable<FeelLikeForecastByDay> ForecastByDay { get; set; } = Enumerable.Empty<FeelLikeForecastByDay>();
    }
}
