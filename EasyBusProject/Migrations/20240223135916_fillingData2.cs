using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class fillingData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableDays", "Time" },
                values: new object[] { "[0,1,2,3,4,5,6]", new TimeOnly(2, 0, 0) });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "Id", "AvailableDays", "BusId", "DropOffID", "Duration", "Name", "PickUpID", "Price", "Time" },
                values: new object[,]
                {
                    { 2, "[0,1]", 1, 3, 0, "B", 2, 300m, new TimeOnly(2, 0, 0) },
                    { 3, "[0,1]", 1, 4, 0, "C", 3, 400m, new TimeOnly(2, 0, 0) },
                    { 4, "[0,1]", 1, 5, 0, "D", 4, 500m, new TimeOnly(2, 0, 0) },
                    { 5, "[0,1]", 1, 6, 0, "E", 5, 100m, new TimeOnly(2, 0, 0) },
                    { 6, "[0,1]", 1, 7, 0, "F", 6, 200m, new TimeOnly(2, 0, 0) },
                    { 7, "[0,1]", 1, 8, 0, "G", 7, 300m, new TimeOnly(2, 0, 0) },
                    { 8, "[0,1]", 1, 9, 0, "H", 8, 400m, new TimeOnly(2, 0, 0) },
                    { 9, "[0,1]", 1, 10, 0, "I", 9, 500m, new TimeOnly(2, 0, 0) },
                    { 10, "[0,1]", 1, 9, 0, "J", 10, 600m, new TimeOnly(2, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableDays", "Time" },
                values: new object[] { "[0,1]", new TimeOnly(2, 14, 0) });
        }
    }
}
