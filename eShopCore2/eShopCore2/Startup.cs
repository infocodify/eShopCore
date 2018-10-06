using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eShopCore2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace eShopCore2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Default Configuration
        public IConfiguration Configuration { get; }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        // This method gets called by the runtime. 
        // Use this method to add services to the Dependency Injection container.
        public void ConfigureServices(IServiceCollection services)
        {
            //in memory db, data vailable until app is running
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("eShopCore"));

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Dependency Injection
            //Classes can ask Startup.cs for the repository and obtain instance of it using Dependecy Injection
            services.AddTransient<IProductRepository, ProductRepository>();
            
            //When you use MockPieRepository
            //services.AddTransient<IProductRepository, MockProductRepository>();
            
            //the app know about MVC service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //In and Out images in wwwroot/images
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "Images")),
                RequestPath = new PathString("/Images")
            });
            //add components/ Middleware
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=App}/{action=Index}/{id?}");
            });
        }
    }
}
