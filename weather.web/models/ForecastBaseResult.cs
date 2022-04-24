namespace Weather.Web.Models
{
    public class ForecastBaseResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
