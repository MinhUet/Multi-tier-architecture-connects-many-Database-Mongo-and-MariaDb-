using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVMinh.DemoArchitecture.DL.DatabaseContexts;
using BVMinh.DemoArchitecture.DL.EntityMongoRepositories;
using BVMinh.DemoArchitecture.DL.Repositories;
using BVMinh.DemoArchitecture.Entity.DatabaseSetting;
using BVMinh.DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BVMinh.DemoArchitecture.UI
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

            services.Configure<DatabaseSetting>(Configuration.GetSection("MongoDB"));

            services.AddSingleton<IDatabaseSetting>(sp => sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);
            
            services.AddTransient<IDatabaseContext, MongoDatabaseContext>();


            services.AddScoped<IRepository<Student>, StudentMongoRepository>();

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
