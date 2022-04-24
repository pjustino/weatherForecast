namespace Weather.Web.Mappers
{
    public class TemperatureForecastMapper : ITemperatureForecastMapper
    {
        public string MapCelsiusToFeelFormat(float temperatureValue)
        {
            switch (temperatureValue)
            {
                case <= 0:
                    return "Freezing";

                case float t when (t <= 5 && t > 0):
                    return "Bracing";

                case float t when (t <= 10 && t > 5):
                    return "Chilly";

                case float t when (t <= 15 && t > 10):
                    return "Cool";

                case float t when (t <= 20 && t > 15):
                    return "Mild";

                case float t when (t <= 25 && t > 20):
                    return "Warm";

                case float t when (t <= 30 && t > 25):
                    return "Balmy";

                case float t when (t <= 35 && t > 30):
                    return "Hot";

                case float t when (t <= 40 && t > 35):
                    return "Sweltering";

                case > 40:
                    return "Scorching";

                default:
                    return string.Empty;
            }
        }
    }
}
