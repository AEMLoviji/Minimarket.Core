using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Minimarket.API.Domain.Db.Contexts;

namespace Minimarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            return
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                     // Heroku specific - as heroku initiate application using the PORT defined in PORT environment variable.
                    .UseUrls("http://*:" + port)
                    .Build();
        }
    }
}
