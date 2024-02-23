using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class longlat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Station",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Station",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.0444, 31.235700000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.042456999999999, 30.472750000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 29.066127000000002, 31.099385000000002 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.244399999999999, 30.035699999999999 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.814443000000001, 31.417539000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.842849999999999, 29.308402000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.013055999999999, 31.208853000000001 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.465928000000002, 30.930579999999999 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 31.265288999999999, 32.301865999999997 });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 30.777818, 30.991126000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Station");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Station");
        }
    }
}
