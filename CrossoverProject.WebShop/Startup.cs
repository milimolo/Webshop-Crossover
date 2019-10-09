using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Webshop.Infrastructure.Data;
using Webshop.Infrastructure.Data.Repositories;
using WebShop.Core.ApplicationService;
using WebShop.Core.ApplicationService.Impl;
using WebShop.Core.DomainService;

namespace CrossoverProject.WebShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                //Laver en database ved navn ShoeApp.db, når den ikke er i development
                services.AddDbContext<WebshopAppContext>(
                    opt => opt.UseSqlite("Data Source=ShoeApp.db"));
            }
            else
            {
                //Azure SQL database:
                services.AddDbContext<WebshopAppContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
            

            services.AddScoped<IShoeRepository, ShoeRepository>();
            services.AddScoped<IShoeService, ShoeService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.MaxDepth = 2;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        //.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                        .WithOrigins("http://localhost:8082").AllowAnyHeader().AllowAnyMethod()
                        .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
                    );
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");

            using (var scope = app.ApplicationServices.CreateScope())
            {
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var context = scope.ServiceProvider.GetRequiredService<WebshopAppContext>();
                context.Database.EnsureCreated();
                DBInitializer.Seed(context);
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
