using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Dtos;
using WeatherForecast.Models;

namespace WeatherForecast.Helpers
{
    public class CustomMappers
    {
        public CurrentWeatherToReturn MapCurrentWeather(CurrentWeatherResponse current)
        {
            var currentWeatherToReturn = new CurrentWeatherToReturn
            {
                Name = current.Name,
                Temp = Math.Round(current.Main.Temp, 1).ToString("0.0"),
                Feels_Like = Math.Round(current.Main.Feels_Like, 1).ToString("0.0"),
                Humidity = current.Main.Humidity,
                Id = current.Weather.First().Id,
                Description = current.Weather.First().Description,
                Visibility = Math.Round(current.Visibility/(double)1000, 1).ToString("0.0"),
                Wind_Speed = current.Wind.Speed
            };

            return currentWeatherToReturn;
        }

        public IEnumerable<DayToReturn> MapForecast(WeatherForecastResponse forecast)
        {
            var daysToReturn = new List<DayToReturn>();
            foreach(var day in forecast.Daily)
            {
                var mappedDay = new DayToReturn
                {
                    Humidity = day.Humidity,
                    Temp_Min = Math.Round(day.Temp.Min, 1).ToString("0.0"),
                    Temp_Max = Math.Round(day.Temp.Max, 1).ToString("0.0"),
                    Id = day.Weather.First().Id,
                    Description = day.Weather.First().Description
                };

                daysToReturn.Add(mappedDay);
            }

            return daysToReturn;
        } 
    }
}
