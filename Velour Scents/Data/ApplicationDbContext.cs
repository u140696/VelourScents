using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Velour_Scents.Models;

namespace Velour_Scents.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Perfume> Perfumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfume>().HasData(
                new Perfume { Id = 1, Name = "Ocean Breeze", Brand = "LuxuryScents", FragranceNotes = "Citrus, Musk", Price = 99.99, ImageUrl = "/images/oceanbreeze.jpg" },
                new Perfume { Id = 2, Name = "Midnight Rose", Brand = "Velour", FragranceNotes = "Rose, Amber, Vanilla", Price = 79.99, ImageUrl = "/images/midnightrose.jpg" },
                new Perfume { Id = 3, Name = "Fresh Blossom", Brand = "NatureEssence", FragranceNotes = "Jasmine, Green Tea", Price = 59.99, ImageUrl = "/images/freshblossom.jpg" },
                new Perfume { Id = 4, Name = "Royal Oud", Brand = "Prestige", FragranceNotes = "Oud, Sandalwood, Bergamot", Price = 129.99, ImageUrl = "/images/royaloud.jpg" },
                new Perfume { Id = 5, Name = "Sweet Vanilla", Brand = "Vanille Co.", FragranceNotes = "Vanilla, Caramel, Tonka Bean", Price = 49.99, ImageUrl = "/images/sweetvanilla.jpg" }
            );
        }
    }
}
