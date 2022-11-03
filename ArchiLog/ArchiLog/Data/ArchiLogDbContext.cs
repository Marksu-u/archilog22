using ArchiLibrary.Data;
using ArchiLibrary.Models;
using ArchiLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchiLog.Data
{
    public class ArchiLogDbContext : BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Connection Azure
            //optionsBuilder.UseSqlServer(@"Server=tcp:archiloghaig.database.windows.net,1433;Initial Catalog=archi_log;Persist Security Info=False;User ID=hp;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            
            // Connection Local (SSMS)
             optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=archilog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<Brand>()
                   .HasData(
                   new Brand { ID = 1, CreatedAt = DateTime.UtcNow, Name = "Peugeot", Slogan = "Nos voitures pas chères", Active = true },
                   new Brand { ID = 2, CreatedAt = DateTime.UtcNow, Name = "Citroën", Slogan = "Nos voitures très chères", Active = true }
                   );

            modelBuilder.Entity<Car>()
                .HasData(
                    new Car { ID = 1, CreatedAt = DateTime.UtcNow, Name = "Pas cher V1", BrandID = 1, Active = true },
                    new Car { ID = 2, CreatedAt = DateTime.UtcNow, Name = "Pas cher V2", BrandID = 1, Active = true }
                );
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
