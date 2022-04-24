using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class WeatherForecastCelsius
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
    }
}