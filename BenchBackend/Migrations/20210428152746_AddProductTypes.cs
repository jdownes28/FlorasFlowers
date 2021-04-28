using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenchBackend.Migrations
{
    public partial class AddProductTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Buy" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Subscription" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryAddress", "OrderFulfilled", "OrderPlaced", "TotalOrderPrice" },
                values: new object[] { 1, null, null, new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 });
        }
    }
}
