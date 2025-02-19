using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Velour_Scents.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPerfumes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Perfumes",
                columns: new[] { "Id", "Brand", "FragranceNotes", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "LuxuryScents", "Citrus, Musk", "/images/oceanbreeze.jpg", "Ocean Breeze", 99.989999999999995 },
                    { 2, "Velour", "Rose, Amber, Vanilla", "/images/midnightrose.jpg", "Midnight Rose", 79.989999999999995 },
                    { 3, "NatureEssence", "Jasmine, Green Tea", "/images/freshblossom.jpg", "Fresh Blossom", 59.990000000000002 },
                    { 4, "Prestige", "Oud, Sandalwood, Bergamot", "/images/royaloud.jpg", "Royal Oud", 129.99000000000001 },
                    { 5, "Vanille Co.", "Vanilla, Caramel, Tonka Bean", "/images/sweetvanilla.jpg", "Sweet Vanilla", 49.990000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfumes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perfumes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perfumes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Perfumes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Perfumes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
