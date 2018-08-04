using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuctionApp.Core.DAL.Data {
    public static class ConfigurationBuilderManager {
        static IConfigurationRoot configurationRoot;

        static ConfigurationBuilderManager () {
            configurationRoot = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json")
                .Build ();
        }

        public static DbContextOptionsBuilder<TDbContext> CreateBuiilder<TDbContext> () where TDbContext : DbContext {
            var builder = new DbContextOptionsBuilder<TDbContext> ();
            return builder;
        }

        public static IConfiguration GetConfiguration {
            get {
                return configurationRoot;
            }
        }
    }
}