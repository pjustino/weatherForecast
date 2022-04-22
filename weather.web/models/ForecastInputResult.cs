namespace weather.web.models
{
    public class ForecastInputResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
