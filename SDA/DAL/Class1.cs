using System;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class VehicleContext : DbContext
    {

        public VehicleContext() : base("VehicleContext")
        {
        }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Locat> Locations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Returned> Returneds{ get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<TrackerType> Types { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}