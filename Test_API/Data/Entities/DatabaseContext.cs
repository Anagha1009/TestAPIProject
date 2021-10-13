using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                                                    new Country { Id = 1, Name = "India", ShortName = "Ind" },
                                                    new Country { Id = 2, Name = "Germany", ShortName = "Ger" },
                                                    new Country { Id = 3, Name = "France", ShortName = "Fra" }
                                                   );

            modelBuilder.Entity<Hotel>().HasData(
                                                   new Hotel { Id = 1, Name = "OperaHouse", Address = "Delhi", Rating=4, CountryId=1 },
                                                   new Hotel { Id = 2, Name = "HotelTaj", Address = "Delhi", Rating = 5, CountryId = 1 },
                                                   new Hotel { Id = 3, Name = "GardenMini", Address = "Mumbai", Rating = 3.5, CountryId = 1 }
                                                  );

        }

        public DbSet<Country> countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }
    }
}
