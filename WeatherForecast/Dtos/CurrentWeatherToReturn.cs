using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Dtos
{
    public class CurrentWeatherToReturn
    {

        public string Name { get; set; }
        public string Temp { get; set; }
        public string Feels_Like { get; set; }
        public int Humidity { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Visibility { get; set; }
        public string Wind_Speed { get; set; }
    }
}
