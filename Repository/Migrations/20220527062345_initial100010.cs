using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial100010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_productId",
                table: "UserOrders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Products_productId",
                table: "UserOrders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Products_productId",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "IX_UserOrders_productId",
                table: "UserOrders");
        }
    }
}
