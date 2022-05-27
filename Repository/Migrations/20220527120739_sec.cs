using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBrand_Specification_Specificationid",
                table: "ProductBrand");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Specification_Specificationid",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Specification_Specificationid",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Specification_Specificationid",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRam_Specification_Specificationid",
                table: "ProductRam");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSim_Specification_Specificationid",
                table: "ProductSim");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorage_Specification_Specificationid",
                table: "ProductStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Products_Productsid",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Specification_Productsid",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_ProductStorage_Specificationid",
                table: "ProductStorage");

            migrationBuilder.DropIndex(
                name: "IX_ProductSim_Specificationid",
                table: "ProductSim");

            migrationBuilder.DropIndex(
                name: "IX_ProductRam_Specificationid",
                table: "ProductRam");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_Specificationid",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductImage_Specificationid",
                table: "ProductImage");

            migrationBuilder.DropIndex(
                name: "IX_ProductColor_Specificationid",
                table: "ProductColor");

            migrationBuilder.DropIndex(
                name: "IX_ProductBrand_Specificationid",
                table: "ProductBrand");

            migrationBuilder.DropColumn(
                name: "Productsid",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductStorage");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductSim");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductRam");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "Specificationid",
                table: "ProductBrand");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pincode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "district",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "additionalInfo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userCheckOut_productId",
                table: "userCheckOut",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_specificationId",
                table: "Products",
                column: "specificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Specification_specificationId",
                table: "Products",
                column: "specificationId",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCheckOut_Products_productId",
                table: "userCheckOut",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Specification_specificationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_userCheckOut_Products_productId",
                table: "userCheckOut");

            migrationBuilder.DropIndex(
                name: "IX_userCheckOut_productId",
                table: "userCheckOut");

            migrationBuilder.DropIndex(
                name: "IX_Products_specificationId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Productsid",
                table: "Specification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductStorage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductSim",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductRam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductColor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specificationid",
                table: "ProductBrand",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "pincode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "district",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "additionalInfo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_Productsid",
                table: "Specification",
                column: "Productsid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_Specificationid",
                table: "ProductStorage",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSim_Specificationid",
                table: "ProductSim",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRam_Specificationid",
                table: "ProductRam",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_Specificationid",
                table: "ProductModel",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_Specificationid",
                table: "ProductImage",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_Specificationid",
                table: "ProductColor",
                column: "Specificationid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrand_Specificationid",
                table: "ProductBrand",
                column: "Specificationid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBrand_Specification_Specificationid",
                table: "ProductBrand",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Specification_Specificationid",
                table: "ProductColor",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Specification_Specificationid",
                table: "ProductImage",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Specification_Specificationid",
                table: "ProductModel",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRam_Specification_Specificationid",
                table: "ProductRam",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSim_Specification_Specificationid",
                table: "ProductSim",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorage_Specification_Specificationid",
                table: "ProductStorage",
                column: "Specificationid",
                principalTable: "Specification",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Products_Productsid",
                table: "Specification",
                column: "Productsid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
