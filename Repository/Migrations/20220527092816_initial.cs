using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "addressid",
                table: "UserOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_addressid",
                table: "UserOrders",
                column: "addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Address_addressid",
                table: "UserOrders",
                column: "addressid",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Address_addressid",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "IX_UserOrders_addressid",
                table: "UserOrders");

            migrationBuilder.DropColumn(
                name: "addressid",
                table: "UserOrders");
        }
    }
}
