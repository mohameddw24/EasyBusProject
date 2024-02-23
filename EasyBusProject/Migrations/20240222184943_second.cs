using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBusProject.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSeats",
                table: "Schedule",
                newName: "AvailableSeatsInTrip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSeatsInTrip",
                table: "Schedule",
                newName: "AvailableSeats");
        }
    }
}
