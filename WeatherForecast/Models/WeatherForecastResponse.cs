using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherForecastResponse
    {
        public IEnumerable<Day> Daily { get; set; }
    }
}
