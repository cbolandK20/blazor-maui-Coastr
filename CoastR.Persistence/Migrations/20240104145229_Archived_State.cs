using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Archived_State : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTER_ITEMS_COASTERS_CoasterId",
                table: "COASTER_ITEMS");

            migrationBuilder.DropForeignKey(
                name: "FK_MENU_ITEMS_MENUES_MenuId",
                table: "MENU_ITEMS");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "MENUES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "MENU_ITEMS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "COASTER_ITEMS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTER_ITEMS_COASTERS_CoasterId",
                table: "COASTER_ITEMS",
                column: "CoasterId",
                principalTable: "COASTERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_ITEMS_MENUES_MenuId",
                table: "MENU_ITEMS",
                column: "MenuId",
                principalTable: "MENUES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTER_ITEMS_COASTERS_CoasterId",
                table: "COASTER_ITEMS");

            migrationBuilder.DropForeignKey(
                name: "FK_MENU_ITEMS_MENUES_MenuId",
                table: "MENU_ITEMS");

            migrationBuilder.DropColumn(
                name: "State",
                table: "VENUES");

            migrationBuilder.DropColumn(
                name: "State",
                table: "MENUES");

            migrationBuilder.DropColumn(
                name: "State",
                table: "MENU_ITEMS");

            migrationBuilder.DropColumn(
                name: "State",
                table: "COASTER_ITEMS");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTER_ITEMS_COASTERS_CoasterId",
                table: "COASTER_ITEMS",
                column: "CoasterId",
                principalTable: "COASTERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_ITEMS_MENUES_MenuId",
                table: "MENU_ITEMS",
                column: "MenuId",
                principalTable: "MENUES",
                principalColumn: "Id");
        }
    }
}
