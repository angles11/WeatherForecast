using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Data
{
    public interface IWeatherRepository
    {
        public Task<CurrentWeatherResponse> GetCurrentWeather(double latitude, double longitud);

        public Task<WeatherForecastResponse> GetForecast(double latitude, double longitud);
    }
}
