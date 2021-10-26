using LibreriaComponenti.Interfaces;
using LibreriaComponenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DemoWASM.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _http;
        public WeatherForecastService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
