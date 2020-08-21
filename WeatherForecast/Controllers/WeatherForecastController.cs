using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherForecast.Data;
using WeatherForecast.Dtos;
using WeatherForecast.Helpers;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet("{latitude}/{longitud}")]
        public async Task<IActionResult> GetWeatherByCity(double latitude, double longitud)
        {
            try
            {
                var currentWeather = await _weatherRepository.GetCurrentWeather(latitude, longitud);

                var forecast = await _weatherRepository.GetForecast(latitude, longitud);

                var mapper = new CustomMappers();

                var currentWeatherToReturn = mapper.MapCurrentWeather(currentWeather);

                var currentForecastToReturn = mapper.MapForecast(forecast);

                return Ok(new WeatherForecastToReturn
                {
                    CurrentWeather = currentWeatherToReturn,
                    Days = currentForecastToReturn
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
