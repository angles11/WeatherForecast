using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Day
    {
        public Temp Temp { get; set; }
        public int Humidity { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }
    }
}
