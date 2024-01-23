using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Viewmodels_Rework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTER_ITEMS_MENU_ITEMS_itemId",
                table: "COASTER_ITEMS");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "COASTER_ITEMS",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_COASTER_ITEMS_itemId",
                table: "COASTER_ITEMS",
                newName: "IX_COASTER_ITEMS_MenuItemId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "COASTER_ITEMS",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTER_ITEMS_MENU_ITEMS_MenuItemId",
                table: "COASTER_ITEMS",
                column: "MenuItemId",
                principalTable: "MENU_ITEMS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTER_ITEMS_MENU_ITEMS_MenuItemId",
                table: "COASTER_ITEMS");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "COASTER_ITEMS");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "COASTER_ITEMS",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_COASTER_ITEMS_MenuItemId",
                table: "COASTER_ITEMS",
                newName: "IX_COASTER_ITEMS_itemId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTER_ITEMS_MENU_ITEMS_itemId",
                table: "COASTER_ITEMS",
                column: "itemId",
                principalTable: "MENU_ITEMS",
                principalColumn: "Id");
        }
    }
}
