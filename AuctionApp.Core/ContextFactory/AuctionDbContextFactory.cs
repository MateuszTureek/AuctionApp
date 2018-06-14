using AuctionApp.Web.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.ContextFactory
{
    public class AuctionDbContextFactory : IDesignTimeDbContextFactory<AuctionDbContext>
    {
        IConfigurationRoot _configuration;

        public AuctionDbContextFactory(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public AuctionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AuctionDbContext>();
            builder.UseSqlServer(_configuration.GetConnectionString("AuctionConnection"));

            return new AuctionDbContext(builder.Options);
        }
    }
}
