using Domain.Models;

namespace Domain.Converters
{
    public class TemperatureConverter : ITemperatureConverter
    {

        public float ToCelsius(float value, TemperatureUnit unit)
        {

            switch (unit)
            {
                case TemperatureUnit.FAHRENHEIT:
                    return (value - 32) * 5 / 9;

                default:
                    return value;
            }
        }
    }
}