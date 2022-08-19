using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6amCoreBatch_Ravi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();


            app.Use(async (context,next) =>//annoymonus method in run method to write some text
            {
                await context.Response.WriteAsync("My First Request UserDefine Middleware");
                await next();
                await context.Response.WriteAsync("My First Response UserDefine Middleware");

            });


            app.Use(async (context, next) =>//annoymonus method in run method to write some text
            {
                await context.Response.WriteAsync("My Second UserDefine Middleware");
                await next();
                await context.Response.WriteAsync("My Second Response UserDefine Middleware");
            });

            app.Use(async (context, next) =>//annoymonus method in run method to write some text
            {
                await context.Response.WriteAsync("My third UserDefine Middleware");
            });


            //Note: Terminal Middle ware 
            // Run method is there in RunExtensions class but call by using app variable as it Extentend with IapplicationBuilder inferface 
            //second object is Request Delegate which call HttpContext(handle request and response information )
            //app.Run(async (context) =>//annoymonus method in run method to write some text
            //{
            //    await context.Response.WriteAsync("My First UserDefine Middleware");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("My second UserDefine Middleware");
            //});

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
