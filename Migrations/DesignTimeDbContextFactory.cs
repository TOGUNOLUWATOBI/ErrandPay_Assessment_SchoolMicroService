using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Migrations
{
    public class DesignTimeDbContextFactory
    {
        public AppDbContext1 CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../EWallet/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext1>();
            string connectionString = configuration.GetConnectionString("DbConnectionString");
            builder.UseSqlServer(connectionString);
            return new AppDbContext1(builder.Options);
        }
    }
}
