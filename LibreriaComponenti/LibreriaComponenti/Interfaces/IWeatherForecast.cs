using LibreriaComponenti.Models;
using System;
using System.Threading.Tasks;

namespace LibreriaComponenti.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
