using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ForecastByDay
    {
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public float Temperature { get; set; }

        [Required]
        public TemperatureUnit Unit;
    }
}