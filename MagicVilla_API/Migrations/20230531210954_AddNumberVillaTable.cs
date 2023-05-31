using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberVilla",
                columns: table => new
                {
                    VillaNumber = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberVilla", x => x.VillaNumber);
                    table.ForeignKey(
                        name: "FK_NumberVilla_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6196), new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6209), new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "CreationTime" },
                values: new object[] { new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6211), new DateTime(2023, 5, 31, 16, 9, 54, 784, DateTimeKind.Local).AddTicks(6212) });

            migrationBuilder.CreateIndex(
                name: "IX_NumberVilla_VillaId",
                table: "NumberVilla",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberVilla");

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
    }
}
