using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    public class VehicleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=C:\USERS\MBA\DOCUMENTS\VEHICLEDB.MDF;Trusted_Connection=true;");
        }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
