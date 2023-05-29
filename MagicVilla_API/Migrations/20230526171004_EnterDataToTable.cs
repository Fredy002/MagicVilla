using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class EnterDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreationDate", "CreationTime", "Description", "ImageURL", "Name", "Occupants", "Rate", "SquareMeters" },
                values: new object[,]
                {
                    { 1, "Pool", new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8613), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8631), "Villa Fredy is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAFskFyZTRMZ9ATpIAD9hYIsOl53hb4joVYv5T5YMcdL0gPsF0NGDsmI8opsHGoGb71Kw", "Villa Fredy", 6, 10.0, 200.0 },
                    { 2, "Pool", new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8636), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8637), "Villa Maria is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQR-VVajuXehgQBdHgR3_J4rk_PuiLJVrmJdGnjAsE8I5Kw3dhbsTxxbWnJHhzxaaT11mk", "Villa Maria", 6, 10.0, 200.0 },
                    { 3, "Pool", new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8640), "Villa Jack is a beautiful villa with a private pool, located in the heart of the Algarve, in the Vale de Parra area, just 5 minutes drive from the beach.", "https://www.engelvoelkers.com/images/ba6a064e-2c80-4df7-9e75-586392b76a3c/exclusiva-villa-rodeada-de-naturaleza", "Villa Jack", 6, 10.0, 200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
