using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rework_Billing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BILLS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sum = table.Column<decimal>(type: "TEXT", nullable: false),
                    VenueName = table.Column<string>(type: "TEXT", nullable: false),
                    VenueLocation_Altitude = table.Column<double>(type: "REAL", nullable: true),
                    VenueLocation_Longitude = table.Column<double>(type: "REAL", nullable: true),
                    VenueLocation_Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BILL_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BILL_ITEMS_BILLS_BillId",
                        column: x => x.BillId,
                        principalTable: "BILLS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BILL_ITEMS_BillId",
                table: "BILL_ITEMS",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BILL_ITEMS");

            migrationBuilder.DropTable(
                name: "BILLS");
        }
    }
}
