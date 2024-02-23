using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class trips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "Higer");

            migrationBuilder.InsertData(
                table: "Bus",
                columns: new[] { "Id", "Category", "Model", "Seats" },
                values: new object[,]
                {
                    { 3, 1, "BYD", 52 },
                    { 4, 0, "MCV", 14 },
                    { 5, 2, "Solaris", 32 },
                    { 6, 1, "MCV", 52 },
                    { 7, 0, "Toyota", 14 },
                    { 8, 2, "MCV", 32 },
                    { 9, 1, "Scania", 52 },
                    { 10, 0, "Volvo", 14 },
                    { 11, 2, "MCV", 32 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "Id", "AvailableDays", "BusId", "DropOffID", "Duration", "Name", "PickUpID", "Price", "Time" },
                values: new object[] { 1, "[0,1]", 1, 2, 0, "A", 1, 200m, new TimeOnly(2, 14, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Bus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "MCV");
        }
    }
}
