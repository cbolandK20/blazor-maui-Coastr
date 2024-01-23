using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Menu_rework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENUES_MENUES_MenuId",
                table: "VENUES");

            migrationBuilder.DropIndex(
                name: "IX_VENUES_MenuId",
                table: "VENUES");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "VENUES");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_MENUES_VENUES_Id",
                table: "MENUES",
                column: "Id",
                principalTable: "VENUES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MENUES_VENUES_Id",
                table: "MENUES");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_VENUES_MenuId",
                table: "VENUES",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_VENUES_MENUES_MenuId",
                table: "VENUES",
                column: "MenuId",
                principalTable: "MENUES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
