﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext
{
    public class AuctionDbContextFactory : IDesignTimeDbContextFactory<AuctionDbContext>
    {
        public AuctionDbContext CreateDbContext(string[] args)
        {
            var builder = ConfigurationBuilderManager.CreateBuiilder<AuctionDbContext>();

            var connectionString = ConfigurationBuilderManager.GetConfiguration.GetConnectionString("AuctionConnection");

            builder.UseSqlServer(connectionString);

            return new AuctionDbContext(builder.Options);
        }
    }
}