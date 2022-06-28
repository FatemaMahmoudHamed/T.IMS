using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IMS.Infrastructure;
using IMS.Infrastructure.DbContexts;
using Serilog;
using System;

namespace IMS.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("serilog.config.json")
            //    .Build();


            try
            {
                // Initialize the database.
                var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

                using (var scope = scopeFactory.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<CommandDbContext>();

                    if (db.Database.EnsureCreated())
                    {
                        Log.Information("Initializing Database.");
                        SeedData.Initialize(db, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development);
                        Log.Information("Database initialized successfully.");
                    }
                }

                Log.Information("IMS Legal Affairs Web API is Starting Up.");

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "IMS Legal Affairs Web API failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
