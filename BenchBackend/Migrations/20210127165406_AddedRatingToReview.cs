using Microsoft.EntityFrameworkCore.Migrations;

namespace BenchBackend.Migrations
{
    public partial class AddedRatingToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PriceCharged",
                table: "ProductOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PriceCharged",
                table: "ProductOrders");
        }
    }
}
