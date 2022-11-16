using ArchiLibrary.Data;
using Archilogtest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archilogtest.Data
{
    public class DbContextTest : BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Connection Azure
            // optionsBuilder.UseSqlServer(@"Server=tcp:archiloghaig.database.windows.net,1433;Initial Catalog=archi_log;Persist Security Info=False;User ID=hp;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

            // Connection Local (SSMS)
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=archilogtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<BrandModelTest>()
                   .HasData(
                   new BrandModelTest { ID = 1, CreatedAt = new DateTime(1896, 01, 01, 12, 00, 00, DateTimeKind.Utc), Name = "Peugeot", Slogan = "Lions de notre temps", Active = true },
                   new BrandModelTest { ID = 2, CreatedAt = new DateTime(1919, 06, 04, 12, 00, 00, DateTimeKind.Utc), Name = "Citroën", Slogan = "Inspiré par vous", Active = true },
                   new BrandModelTest { ID = 3, CreatedAt = new DateTime(1898, 12, 24, 12, 00, 00, DateTimeKind.Utc), Name = "Renault", Slogan = "Renault, des voitures à vivre", Active = true }
                   );

            modelBuilder.Entity<CarsModelTest>()
                .HasData(
                    new CarsModelTest { ID = 1, CreatedAt = new DateTime(2019, 10, 01, 12, 00, 00, DateTimeKind.Utc), Name = "208 Electrique", BrandID = 1, Active = true, Price = 25000 },
                    new CarsModelTest { ID = 2, CreatedAt = new DateTime(2013, 09, 12, 12, 00, 00, DateTimeKind.Utc), Name = "308 Hybride", BrandID = 1, Active = true, Price = 15000 },
                    new CarsModelTest { ID = 3, CreatedAt = new DateTime(2020, 02, 01, 12, 00, 00, DateTimeKind.Utc), Name = "508 PSE", BrandID = 1, Active = true, Price = 30000 },
                    new CarsModelTest { ID = 4, CreatedAt = new DateTime(2022, 10, 13, 12, 00, 00, DateTimeKind.Utc), Name = "C4 Electrique", BrandID = 3, Active = true, Price = 35000 },
                    new CarsModelTest { ID = 5, CreatedAt = new DateTime(2019, 04, 02, 12, 00, 00, DateTimeKind.Utc), Name = "Clio 5", BrandID = 3, Active = true, Price = 45000 },
                    new CarsModelTest { ID = 6, CreatedAt = new DateTime(2020, 12, 01, 12, 00, 00, DateTimeKind.Utc), Name = "C4", BrandID = 2, Active = true, Price = 40000 },
                    new CarsModelTest { ID = 7, CreatedAt = new DateTime(2021, 02, 01, 12, 00, 00, DateTimeKind.Utc), Name = "SpaceTourer XS", BrandID = 2, Active = true, Price = 25000 },
                    new CarsModelTest { ID = 8, CreatedAt = new DateTime(2019, 10, 14, 12, 00, 00, DateTimeKind.Utc), Name = "3008", BrandID = 1, Active = true, Price = 10000 },
                    new CarsModelTest { ID = 9, CreatedAt = new DateTime(2020, 11, 01, 12, 00, 00, DateTimeKind.Utc), Name = "GS", BrandID = 2, Active = true, Price = 25000 },
                    new CarsModelTest { ID = 10, CreatedAt = new DateTime(2021, 05, 01, 12, 00, 00, DateTimeKind.Utc), Name = "DS 9", BrandID = 1, Active = true, Price = 50000 }
                );
        }

        public DbSet<BrandModelTest> Brands { get; set; }

        public DbSet<CarsModelTest> Cars { get; set; }
    }
}

