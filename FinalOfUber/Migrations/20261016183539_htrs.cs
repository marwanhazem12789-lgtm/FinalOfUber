using Microsoft.EntityFrameworkCore.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalOfUber.Migrations
{
    /// <inheritdoc />
    public partial class htrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupLocatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffLocatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rides_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rides_users_RiderId",
                        column: x => x.RiderId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalteNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicles_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ratings_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "Moo@gmail.com", "Mohamed Ashraf", "123456", "01096857067", " Admin" },
                    { 2, "Maro@gmail.com", "Maro Ashraf", "123456", "01096857067", " Driver" }
                });

            migrationBuilder.InsertData(
                table: "rides",
                columns: new[] { "Id", "DriverId", "DropOffLocatin", "Fare", "PickupLocatin", "RiderId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Imbaba", 80, "October", 1, "Availble" },
                    { 2, 2, "Fasel", 100, "Zayed", 2, "Busy" }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "Id", "Color", "DriverId", "Model", "PalteNumber" },
                values: new object[,]
                {
                    { 1, " Red", 1, "BMW-7", "125487" },
                    { 2, " Black", 2, "BMW-9", "12548" }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RideId", "Status" },
                values: new object[,]
                {
                    { 1, 250.0, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 1, "Complete" },
                    { 2, 350.0, new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "مش معايا فلوس", 2, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "Id", "Comments", "RideId", "Score" },
                values: new object[,]
                {
                    { 1, "Good", 1, 2 },
                    { 2, "Very Good", 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_RideId",
                table: "payments",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_RideId",
                table: "ratings",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rides_DriverId",
                table: "rides",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_rides_RiderId",
                table: "rides",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_DriverId",
                table: "vehicles",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "rides");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
