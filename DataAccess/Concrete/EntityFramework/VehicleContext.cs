using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class VehicleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=C:\USERS\MBA\DOCUMENTS\VEHICLEDB.MDF;Trusted_Connection=true;");
        }

        public DbSet<Color> Color { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Car> Car { get; set; }
    }
}
