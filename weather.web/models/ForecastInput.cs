﻿using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace weather.web.models
{
    public class ForecastInput
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float Temperature { get; set; }

        public TemperatureUnit unit { get; set; }
    }
}