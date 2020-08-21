using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Dtos;
using WeatherForecast.Models;

namespace WeatherForecast.Data
{
    public class WeatherRepository : IWeatherRepository
    {
        public async Task<CurrentWeatherResponse> GetCurrentWeather(double latitude, double longitud)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var appId = ' ';  // Removed for public repository.
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitud}&units=metric&APPID={appId}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = response.Content.ReadAsStringAsync().Result;
                    var rawWeather = JsonConvert.DeserializeObject<CurrentWeatherResponse>(stringResult);

                    return rawWeather;

                }
                catch (HttpRequestException ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<WeatherForecastResponse> GetForecast(double latitude, double longitud)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var appId = ' '; // Removed for public repository.
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitud}&exclude=hourly,minutely&units=metric&APPID={appId}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = response.Content.ReadAsStringAsync().Result;

                    var rawForecast = JsonConvert.DeserializeObject<WeatherForecastResponse>(stringResult);

                    return rawForecast;
                }
                catch (HttpRequestException ex)
                {

                    throw ex;
                }
            }
        }
    }
}
