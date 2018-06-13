using AuctionApp.Web.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.ContextFactory
{
    public class AuctionDbContextFactory : IDesignTimeDbContextFactory<AuctionDbContext>
    {
        public AuctionDbContextFactory() { }

        public AuctionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AuctionDbContext>();
            builder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AspCore_Auction;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AuctionDbContext(builder.Options);
        }
    }
}
