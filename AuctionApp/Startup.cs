using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.Auction;
using AuctionApp.Core.DatabaseInitial;
using AuctionApp.Domain.Identity;
using AuctionApp.Repository.IRepo;
using AuctionApp.Repository.Repo;
using AuctionApp.Web.AppDbContext;
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

            services.AddTransient<IGenericRepo<int, Item>, GenericRepo<int, Item>>();

            services.AddDbContext<AppIdentityDbContext>(o =>
                 o.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<AuctionDbContext>(o =>
                 o.UseSqlServer(Configuration.GetConnectionString("AuctionConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IdentityInitializer>();
            services.AddScoped<AuctionInitializer>();

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
