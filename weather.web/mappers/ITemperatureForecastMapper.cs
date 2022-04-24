namespace Weather.Web.Mappers
{
    public interface ITemperatureForecastMapper
    {
        string MapCelsiusToFeelFormat(float temperatureValue);
    }
}