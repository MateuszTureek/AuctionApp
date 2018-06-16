using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AuctionApp.Core.BLL.Mapper;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Service.Implement;
using AuctionApp.Core.DAL.Data;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.IdentityContext;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Repository.Implement;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionApp
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
            services.AddSingleton(_ => Configuration);

            services.AddDbContext<AppIdentityDbContext>(o =>
                 o.UseSqlServer(ConfigurationBuilderManager.GetConfiguration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<AuctionDbContext>(o =>
                  o.UseSqlServer(ConfigurationBuilderManager.GetConfiguration.GetConnectionString("AuctionConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();
            // init db
            services.AddScoped<IdentityInitializer>();
            services.AddScoped<AuctionInitializer>();
            // repo
            services.AddTransient<IAuctionRepo, AuctionRepo>();
            services.AddTransient<ICategoryRepo, CategoryRepo>();
            //services
            services.AddTransient<IAuctionService, AuctionService>();
            services.AddTransient<ICategoryService, CategoryService>();
            // mvc
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IdentityInitializer identityInitializer, AuctionInitializer auctionInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            identityInitializer.Initialize();
            auctionInitializer.Initialize();
        }
    }
}
