using DemoWASM.Services;
using LibreriaComponenti.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using LibreriaComponenti;
using LibreriaComponenti.Models;
using Polly;

namespace DemoWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient("ReqRes", client =>
            {
                client.BaseAddress = new Uri("https://reqres.in/api/");
            })
            .AddTransientHttpErrorPolicy( policy => 
                policy.WaitAndRetryAsync(new[] { 
                   TimeSpan.FromSeconds(1),
                   TimeSpan.FromSeconds(10),
                   TimeSpan.FromSeconds(20)
                })
            );


            builder.Services.AddSingleton<ILogData, LogDataService>();
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddSingleton(provider =>
            {
                var configurazione = provider.GetService<IConfiguration>();
                var sezioneSetting = configurazione.GetSection(nameof(MySettings));
                var oggettoSetting = sezioneSetting.Get<MySettings>();
                return oggettoSetting;
            });
            builder.Services.AddScoped<IReqResService, ReqResDataService>();


            await builder.Build().RunAsync();
        }
    }
}
