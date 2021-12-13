using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    EmployeeAddress = table.Column<string>(nullable: true),
                    EmployeeBirthdate = table.Column<DateTime>(nullable: false),
                    EmployeeEmail = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeePhone = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Parkinglots",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkArea = table.Column<int>(nullable: false),
                    ParkName = table.Column<string>(nullable: true),
                    ParkPlace = table.Column<string>(nullable: true),
                    ParkPrice = table.Column<int>(nullable: false),
                    ParkStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkinglots", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookerTicketNumber = table.Column<int>(nullable: false),
                    CarType = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Driver = table.Column<string>(nullable: true),
                    MaximumOnlineTickerNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(nullable: false),
                    CarColor = table.Column<string>(nullable: true),
                    CarType = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    ParkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_Cars_Parkinglots_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parkinglots",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndContractDeadline = table.Column<DateTime>(nullable: false),
                    StartContractDeadline = table.Column<DateTime>(nullable: false),
                    OfficeName = table.Column<string>(nullable: true),
                    OfficePhone = table.Column<string>(nullable: true),
                    OfficePlace = table.Column<string>(nullable: true),
                    OfficePrice = table.Column<int>(nullable: false),
                    ParkId = table.Column<int>(nullable: false),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Offices_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTime = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    LicensePlate = table.Column<string>(nullable: true),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Cars_LicensePlate",
                        column: x => x.LicensePlate,
                        principalTable: "Cars",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ParkId",
                table: "Cars",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_TripId",
                table: "Offices",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LicensePlate",
                table: "Tickets",
                column: "LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Parkinglots");
        }
    }
}
