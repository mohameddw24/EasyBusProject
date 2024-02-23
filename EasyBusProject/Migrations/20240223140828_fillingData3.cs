using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class fillingData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 0);
        }
    }
}
