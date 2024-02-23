using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class longlatedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.474399999999999, 31.035699999999999 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.144400000000001, 30.035699999999999 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 32.314442999999997, 31.217538999999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.042456999999999, 30.472750000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.013055999999999, 31.208853000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.265288999999999, 32.301865999999997 });
        }
    }
}
