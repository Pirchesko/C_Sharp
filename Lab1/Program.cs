using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FastidiousPrincess
{   
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Princess>();
                services.AddScoped<IContenderGenerator, ContenderGenerator>();
                services.AddScoped<Hall>();
                services.AddScoped<IHall>(sp => sp.GetRequiredService<Hall>());
                services.AddScoped<IHallForPrincess>(sp => sp.GetRequiredService<Hall>());
                services.AddScoped<Friend>();
            });
        }
    }
}