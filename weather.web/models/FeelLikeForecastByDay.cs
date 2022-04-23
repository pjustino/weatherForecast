using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FeelLikeForecastByDay
    {
        public DateTime Date { get; set; }
        public string TemperatureFeel { get; set; } = String.Empty;
    }
}
