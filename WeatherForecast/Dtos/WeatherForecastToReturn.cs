using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Dtos
{
    public class WeatherForecastToReturn
    {
        public CurrentWeatherToReturn CurrentWeather { get; set; }

        public IEnumerable<DayToReturn> Days { get; set; }
    }
}
