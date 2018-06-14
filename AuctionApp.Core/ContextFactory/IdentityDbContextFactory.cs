using AuctionApp.Web.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.ContextFactory
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        IConfigurationRoot _configuration;

        public IdentityDbContextFactory(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            builder.UseSqlServer(_configuration.GetConnectionString("IdentityConnection"));

            return new AppIdentityDbContext(builder.Options);
        }
    }
}
