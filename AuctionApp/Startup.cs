using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.ContextFactory;
using AuctionApp.Core.DatabaseInitial;
using AuctionApp.Dependencies;
using AuctionApp.Domain.Identity;
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
            services.AddDbContext<AppIdentityDbContext>(o => 
                o.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AspCore_Identity;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddDbContext<AuctionDbContext>(o =>
                o.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AspCore_Auction;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            UserManager<AppUser> userManager, AppIdentityDbContext appIdentityDbContext, AuctionDbContext auctionDbContext)
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

            IdentityInitializer identityInitializer = new IdentityInitializer(userManager);
            identityInitializer.Initialize(appIdentityDbContext);
            AuctionInitializer auctionInitializer = new AuctionInitializer(userManager);
            auctionInitializer.Initialize(auctionDbContext);
        }
    }
}
