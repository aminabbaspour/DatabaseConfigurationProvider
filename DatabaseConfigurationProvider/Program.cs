using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DatabaseConfigurationProvider.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConfigurationProvider.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConfigurationProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostBuildContext, configurationBuilder) =>
            {
                var config = configurationBuilder.Build();
                var configSource = new DatabaseConfigurationSource(opts =>
                    opts.UseSqlServer(config.GetConnectionString("Default")));
                configurationBuilder.Add(configSource);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
