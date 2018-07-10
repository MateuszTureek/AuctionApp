using System;
using System.Collections.Generic;
using System.Linq;
using AuctionApp.Core.BLL.Dependencies;
using AuctionApp.Core.DAL.Data;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.IdentityContext;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            services.AddScoped<IdentityInitializer>();
            services.AddScoped<AuctionInitializer>();
            // register my service
            DependencyProvider.SetupAuctionDependency(services);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(3);
            });

            services.AddMvc(opt => opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
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

            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            identityInitializer.Initialize();
            auctionInitializer.Initialize();
        }
    }
}
