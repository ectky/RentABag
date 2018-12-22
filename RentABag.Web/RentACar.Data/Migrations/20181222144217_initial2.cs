using Microsoft.EntityFrameworkCore.Migrations;

namespace RentABag.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bags_BagId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Shops_ShopId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses",
                column: "ShopId",
                unique: true,
                filter: "[ShopId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bags_BagId",
                table: "Reviews",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Shops_ShopId",
                table: "Reviews",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bags_BagId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Shops_ShopId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses",
                column: "ShopId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bags_BagId",
                table: "Reviews",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Shops_ShopId",
                table: "Reviews",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
