using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_userCheckOut_Address_addressId",
                table: "userCheckOut");

            migrationBuilder.DropForeignKey(
                name: "FK_userCheckOut_Products_productId",
                table: "userCheckOut");

            migrationBuilder.DropForeignKey(
                name: "FK_userCheckOut_Register_userId",
                table: "userCheckOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCheckOut",
                table: "userCheckOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterDatas",
                table: "masterDatas");

            migrationBuilder.RenameTable(
                name: "userCheckOut",
                newName: "UserCheckOut");

            migrationBuilder.RenameTable(
                name: "masterDatas",
                newName: "MasterDatas");

            migrationBuilder.RenameIndex(
                name: "IX_userCheckOut_userId",
                table: "UserCheckOut",
                newName: "IX_UserCheckOut_userId");

            migrationBuilder.RenameIndex(
                name: "IX_userCheckOut_productId",
                table: "UserCheckOut",
                newName: "IX_UserCheckOut_productId");

            migrationBuilder.RenameIndex(
                name: "IX_userCheckOut_addressId",
                table: "UserCheckOut",
                newName: "IX_UserCheckOut_addressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCheckOut",
                table: "UserCheckOut",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterDatas",
                table: "MasterDatas",
                column: "id");*/

            migrationBuilder.CreateTable(
                name: "ProductsModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specificationId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productPrice = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productStatus = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductsModel_Specification_specificationId",
                        column: x => x.specificationId,
                        principalTable: "Specification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsModel_specificationId",
                table: "ProductsModel",
                column: "specificationId");

            /*migrationBuilder.AddForeignKey(
                name: "FK_UserCheckOut_Address_addressId",
                table: "UserCheckOut",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCheckOut_Products_productId",
                table: "UserCheckOut",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCheckOut_Register_userId",
                table: "UserCheckOut",
                column: "userId",
                principalTable: "Register",
                principalColumn: "registrationId",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckOut_Address_addressId",
                table: "UserCheckOut");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckOut_Products_productId",
                table: "UserCheckOut");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckOut_Register_userId",
                table: "UserCheckOut");

            migrationBuilder.DropTable(
                name: "ProductsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCheckOut",
                table: "UserCheckOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterDatas",
                table: "MasterDatas");

            migrationBuilder.RenameTable(
                name: "UserCheckOut",
                newName: "userCheckOut");

            migrationBuilder.RenameTable(
                name: "MasterDatas",
                newName: "masterDatas");

            migrationBuilder.RenameIndex(
                name: "IX_UserCheckOut_userId",
                table: "userCheckOut",
                newName: "IX_userCheckOut_userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCheckOut_productId",
                table: "userCheckOut",
                newName: "IX_userCheckOut_productId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCheckOut_addressId",
                table: "userCheckOut",
                newName: "IX_userCheckOut_addressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCheckOut",
                table: "userCheckOut",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterDatas",
                table: "masterDatas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCheckOut_Address_addressId",
                table: "userCheckOut",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCheckOut_Products_productId",
                table: "userCheckOut",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCheckOut_Register_userId",
                table: "userCheckOut",
                column: "userId",
                principalTable: "Register",
                principalColumn: "registrationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
