using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class stations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Giza", "Example 1" },
                    { 2, "Cairo", "Example 2" },
                    { 3, "Alexandria", "Example 2" },
                    { 4, "Menofia", "Example 2" },
                    { 5, "Mansoura", "Example 2" },
                    { 6, "Fayoum", "Example 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
