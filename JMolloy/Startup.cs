using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JMolloy.Models;
using Microsoft.EntityFrameworkCore;
using JMolloy.Services;
using System;
using System.IO;
using System.Reflection;

namespace JMolloy
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment _env;
        string AppBasepath = string.Empty;
        string AppRootpath = string.Empty;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            AppBasepath = _env.WebRootPath;
            AppRootpath = _env.ContentRootPath;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddControllersWithViews();
            services.AddDbContext<BookDbContext>(options =>
            options.UseSqlite(                      //Directory/
                Configuration.GetConnectionString("DefaultConnection")));
            
            // options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddScoped<IBookRepository, DbBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           //Configure for production! (avoid chaning startup settings from prod to env) if (env.IsProduction)
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
