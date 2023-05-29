﻿// <auto-generated />
using System;
using MagicVilla_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupants")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("SquareMeters")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Pool",
                            CreationDate = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1967),
                            CreationTime = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1981),
                            Description = "Villa Fredy is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAFskFyZTRMZ9ATpIAD9hYIsOl53hb4joVYv5T5YMcdL0gPsF0NGDsmI8opsHGoGb71Kw",
                            Name = "Villa Fredy",
                            Occupants = 6,
                            Rate = 10.0,
                            SquareMeters = 200.0
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Pool",
                            CreationDate = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1983),
                            CreationTime = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1984),
                            Description = "Villa Maria is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQR-VVajuXehgQBdHgR3_J4rk_PuiLJVrmJdGnjAsE8I5Kw3dhbsTxxbWnJHhzxaaT11mk",
                            Name = "Villa Maria",
                            Occupants = 6,
                            Rate = 10.0,
                            SquareMeters = 200.0
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Pool",
                            CreationDate = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1986),
                            CreationTime = new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1987),
                            Description = "Villa Jack is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.",
                            ImageURL = "https://www.engelvoelkers.com/images/ba6a064e-2c80-4df7-9e75-586392b76a3c/exclusiva-villa-rodeada-de-naturaleza",
                            Name = "Villa Jack",
                            Occupants = 6,
                            Rate = 10.0,
                            SquareMeters = 200.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
