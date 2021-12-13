using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EF
{
    public class CarParkDbContext : DbContext 
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingOfficeConfig());
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ParkinglotConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new TripConfig());


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = CarParkDB;");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<BookingOffice> BookingOffices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parkinglot> Parkinglots { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
