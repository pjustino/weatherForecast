namespace weather.services.mappers
{
    public interface ITemperatureForecastMapper
    {
        string MapCelsiusToFeelFormat(float temperatureValue);
    }
}