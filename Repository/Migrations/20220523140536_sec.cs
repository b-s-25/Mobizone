using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "specificationId",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "productModel",
                table: "Products",
                newName: "Model");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "specificationId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "productModel");

            migrationBuilder.AddColumn<int>(
                name: "productPrice",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
