using Business29.Implemantion;
using Business29.Services;
using DAL29.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        private readonly IConfiguration _configuretion;

        public Startup(IConfiguration configuretion)
        {
            _configuretion = configuretion;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICardService, CardRepository>();
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(_configuretion.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("WebApplication1"));
              

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Admin",
                  pattern: "{controller=dashboard}/{action=index}/{id?}");

                endpoints.MapControllerRoute(name: "Default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
