using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BillItem_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "BILL_ITEMS",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "BILL_ITEMS");
        }
    }
}
