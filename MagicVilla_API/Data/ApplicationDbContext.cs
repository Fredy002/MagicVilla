using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Db Set Entity

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<NumberVilla> NumberVilla { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Villa Fredy",
                    Description = "Villa Fredy is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                    Rate = 10,
                    Occupants = 6,
                    SquareMeters = 200,
                    ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAFskFyZTRMZ9ATpIAD9hYIsOl53hb4joVYv5T5YMcdL0gPsF0NGDsmI8opsHGoGb71Kw",
                    Amenity = "Pool",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Villa Maria",
                    Description = "Villa Maria is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                    Rate = 10,
                    Occupants = 6,
                    SquareMeters = 200,
                    ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQR-VVajuXehgQBdHgR3_J4rk_PuiLJVrmJdGnjAsE8I5Kw3dhbsTxxbWnJHhzxaaT11mk",
                    Amenity = "Pool",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Villa Jack",
                    Description = "Villa Jack is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                    Rate = 10,
                    Occupants = 6,
                    SquareMeters = 200,
                    ImageURL = "https://www.engelvoelkers.com/images/ba6a064e-2c80-4df7-9e75-586392b76a3c/exclusiva-villa-rodeada-de-naturaleza",
                    Amenity = "Pool",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                }
            );
        }
    }
}
