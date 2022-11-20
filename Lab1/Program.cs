using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Labs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                Hall hall = new Hall();
                services.AddHostedService<Princess>();
                services.AddScoped<IHall>(sp => hall);
                services.AddScoped<IHallForPrincess>(sp => hall);
                services.AddScoped<Friend>();
            });
        }
    }
}