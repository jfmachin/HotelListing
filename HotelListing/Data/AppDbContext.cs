using System.Diagnostics.CodeAnalysis;
using HotelListing.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data {
    public class AppDbContext : DbContext {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Country>().HasData(
                new Country {id = 1, name = "Jamaica", shortName = "JM" },
                new Country {id = 2, name = "Bahamas", shortName = "BS" },
                new Country {id = 3, name = "Cayman Islan", shortName = "CI" });

            builder.Entity<Hotel>().HasData(
                new Hotel { id = 1, name = "Sandals Resort and Spa", address = "Negril", countryId = 1, rating = 4.5 },
                new Hotel { id = 2, name = "Comfort Suites", address = "George Town", countryId = 3, rating = 4.3 },
                new Hotel { id = 3, name = "Grand Palldium", address = "Nassua", countryId = 2, rating = 4 });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Contries { get; set; }
    }
}
