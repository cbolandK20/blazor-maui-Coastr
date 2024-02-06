using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Integrity_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTERS_VENUES_VenueId",
                table: "COASTERS");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTERS_VENUES_VenueId",
                table: "COASTERS",
                column: "VenueId",
                principalTable: "VENUES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASTERS_VENUES_VenueId",
                table: "COASTERS");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VENUES",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_COASTERS_VENUES_VenueId",
                table: "COASTERS",
                column: "VenueId",
                principalTable: "VENUES",
                principalColumn: "Id");
        }
    }
}
