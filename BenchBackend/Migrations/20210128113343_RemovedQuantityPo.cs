using Microsoft.EntityFrameworkCore.Migrations;

namespace BenchBackend.Migrations
{
    public partial class RemovedQuantityPo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
