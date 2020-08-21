using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Dtos
{
    public class DayToReturn
    {
        public int Humidity { get; set; }
        public string Temp_Min { get; set; }
        public string Temp_Max { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
