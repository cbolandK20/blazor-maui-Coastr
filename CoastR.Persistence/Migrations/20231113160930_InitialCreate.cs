using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MENUES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENUES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MENU_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MENU_ITEMS_MENUES_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MENUES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VENUES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location_Altitude = table.Column<double>(type: "REAL", nullable: true),
                    Location_Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Location_Latitude = table.Column<double>(type: "REAL", nullable: true),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENUES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VENUES_MENUES_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MENUES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COASTERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VenueId = table.Column<int>(type: "INTEGER", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COASTERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COASTERS_VENUES_VenueId",
                        column: x => x.VenueId,
                        principalTable: "VENUES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "COASTER_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    itemId = table.Column<int>(type: "INTEGER", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    CoasterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COASTER_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COASTER_ITEMS_COASTERS_CoasterId",
                        column: x => x.CoasterId,
                        principalTable: "COASTERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COASTER_ITEMS_MENU_ITEMS_itemId",
                        column: x => x.itemId,
                        principalTable: "MENU_ITEMS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_COASTER_ITEMS_CoasterId",
                table: "COASTER_ITEMS",
                column: "CoasterId");

            migrationBuilder.CreateIndex(
                name: "IX_COASTER_ITEMS_itemId",
                table: "COASTER_ITEMS",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_COASTERS_VenueId",
                table: "COASTERS",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_ITEMS_MenuId",
                table: "MENU_ITEMS",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_VENUES_MenuId",
                table: "VENUES",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COASTER_ITEMS");

            migrationBuilder.DropTable(
                name: "COASTERS");

            migrationBuilder.DropTable(
                name: "MENU_ITEMS");

            migrationBuilder.DropTable(
                name: "VENUES");

            migrationBuilder.DropTable(
                name: "MENUES");
        }
    }
}
