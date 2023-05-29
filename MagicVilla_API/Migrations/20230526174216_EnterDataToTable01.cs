using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class EnterDataToTable01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1967), new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1981) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1983), new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1984) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1986), new DateTime(2023, 5, 26, 12, 42, 16, 489, DateTimeKind.Local).AddTicks(1987) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8613), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8631) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8636), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 5, 26, 12, 10, 4, 231, DateTimeKind.Local).AddTicks(8640) });
        }
    }
}
