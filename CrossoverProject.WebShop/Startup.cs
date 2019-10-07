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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IShoeRepository, Webshop.Infrastructure.Data.Repositories.ShoeRepository>();
            //Laver en database ved navn ShoeApp.db
            services.AddDbContext<WebshopAppContext>(
                opt => opt.UseSqlite("Data Source=ShoeApp.db"));

            services.AddScoped<IShoeRepository, ShoeRepository>();
            services.AddScoped<IShoeService, ShoeService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.MaxDepth = 2;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<WebshopAppContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DBInitializer.Seed(context);
                }

                app.UseDeveloperExceptionPage();
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
