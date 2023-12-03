using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yatra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Travellers",
                table: "Travellers");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Travellers",
                newName: "FlightID");

            migrationBuilder.AlterColumn<string>(
                name: "FlightID",
                table: "Travellers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TravellerID",
                table: "Travellers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travellers",
                table: "Travellers",
                column: "TravellerID");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stops = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Meals = table.Column<bool>(type: "bit", nullable: false),
                    Emmisions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travellers_FlightID",
                table: "Travellers",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Travellers_Flights_FlightID",
                table: "Travellers",
                column: "FlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travellers_Flights_FlightID",
                table: "Travellers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travellers",
                table: "Travellers");

            migrationBuilder.DropIndex(
                name: "IX_Travellers_FlightID",
                table: "Travellers");

            migrationBuilder.DropColumn(
                name: "TravellerID",
                table: "Travellers");

            migrationBuilder.RenameColumn(
                name: "FlightID",
                table: "Travellers",
                newName: "FlightId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlightId",
                table: "Travellers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travellers",
                table: "Travellers",
                column: "FlightId");
        }
    }
}
