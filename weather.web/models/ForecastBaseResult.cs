namespace weather.web.models
{
    public class ForecastBaseResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
