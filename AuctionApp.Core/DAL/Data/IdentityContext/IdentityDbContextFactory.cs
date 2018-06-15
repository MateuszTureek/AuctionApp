using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AuctionApp.Core.DAL.Data.IdentityContext
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var builder = ConfigurationBuilderManager.CreateBuiilder<AppIdentityDbContext>();

            var connectionString = ConfigurationBuilderManager.GetConfiguration.GetConnectionString("IdentityConnection");

            builder.UseSqlServer(connectionString);

            return new AppIdentityDbContext(builder.Options);
        }
    }
}
