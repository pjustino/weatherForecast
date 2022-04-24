using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Weather.Web.Models
{
    public class ForecastInput
    {
        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public float? Temperature { get; set; }

        [Required]
        public TemperatureUnit unit { get; set; }
    }
}
