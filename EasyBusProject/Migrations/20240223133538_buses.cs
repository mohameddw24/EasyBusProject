using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class buses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bus",
                columns: new[] { "Id", "Category", "Model", "Seats" },
                values: new object[,]
                {
                    { 1, 0, "Mercedes", 14 },
                    { 2, 2, "MCV", 32 }
                });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name" },
                values: new object[] { "Alexandria", "Alexandria" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name" },
                values: new object[] { "Beheira", "Beheira" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name" },
                values: new object[] { "Bani Suef", "Bani Suef" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "Name" },
                values: new object[] { "Cairo", "Cairo" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "Name" },
                values: new object[] { "Damietta", "Damietta" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Fayoum");

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 7, "Giza", "Giza" },
                    { 8, "Monofiya", "Monofiya" },
                    { 9, "Port Said", "Port Said" },
                    { 10, "Tanta", "Tanta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name" },
                values: new object[] { "Giza", "Example 1" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name" },
                values: new object[] { "Cairo", "Example 2" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name" },
                values: new object[] { "Alexandria", "Example 2" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "Name" },
                values: new object[] { "Menofia", "Example 2" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "Name" },
                values: new object[] { "Mansoura", "Example 2" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Example 2");
        }
    }
}
