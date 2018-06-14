using AuctionApp.Web.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.ContextFactory
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public IdentityDbContextFactory() { }

        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            builder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AspCore_Identity;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AppIdentityDbContext(builder.Options);
        }
    }
}
