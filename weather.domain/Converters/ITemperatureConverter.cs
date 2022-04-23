using Domain.Models;

namespace Domain.Converters
{
    public interface ITemperatureConverter
    {
        float ToCelsius(float value, TemperatureUnit unit);
    }
}