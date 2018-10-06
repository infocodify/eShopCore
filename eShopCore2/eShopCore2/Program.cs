using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eShopCore2.Models;

namespace eShopCore2
{
    public class Program
    {
            public static void Main(string[] args)
            {
                var host = BuildWebHost(args);

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<AppDbContext>();
                        DbInitializer.Seed(context);
                    }
                    catch (Exception)
                    {
                        //we could log this in a real-world situation
                    }
                }

                host.Run();

                //BuildWebHost(args).Run();
            }

            public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
