using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models.EF
{
    //public class CarParkDbContextFactory : IDesignTimeDbContextFactory<CarParkDbContext>
    //{
    //    public CarParkDbContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        var connectionString = configuration.GetConnectionString("CarParkDb");

    //        var optionsBuilder = new DbContextOptionsBuilder<CarParkDbContext>();
    //        optionsBuilder.UseSqlServer(connectionString);

    //        return new CarParkDbContext(optionsBuilder.Options);
    //    }
    //}
}
