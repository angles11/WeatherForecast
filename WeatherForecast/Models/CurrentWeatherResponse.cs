using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public partial class CurrentWeatherResponse
    {
        public string Name { get; set; }
        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }

        public int Visibility { get; set; }

       
    }
}
