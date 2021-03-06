using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var Logger =  services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StorecontextSeed.SeedAsync(context, Logger);
                }
                catch (Exception ex)
                {
                  var errorLogger = Logger.CreateLogger<Program>();
                  errorLogger.LogError(ex.Message);
                }
            }

            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
