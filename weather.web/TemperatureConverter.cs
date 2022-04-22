using Domain.Models;

namespace WeatherForecast
{
    public class TemperatureConverter
    {

        public float ToCelsius(float value,  TemperatureUnit unit) {

            switch(unit)
            {
                case TemperatureUnit.FAHRENHEIT:
                    return (value - 32) * 5 / 9;
                
                default:
                    return value;
            }
        }
    }
}