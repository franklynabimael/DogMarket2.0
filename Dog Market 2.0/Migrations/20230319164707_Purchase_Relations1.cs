using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Purchase_Relations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Produts_ProductId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Purchases_PurchaseId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details",
                column: "CartId",
                principalSchema: "DogMarketDB",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Produts_ProductId",
                schema: "DogMarketDB",
                table: "Details",
                column: "ProductId",
                principalSchema: "DogMarketDB",
                principalTable: "Produts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Purchases_PurchaseId",
                schema: "DogMarketDB",
                table: "Details",
                column: "PurchaseId",
                principalSchema: "DogMarketDB",
                principalTable: "Purchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Produts_ProductId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Purchases_PurchaseId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details",
                column: "CartId",
                principalSchema: "DogMarketDB",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Produts_ProductId",
                schema: "DogMarketDB",
                table: "Details",
                column: "ProductId",
                principalSchema: "DogMarketDB",
                principalTable: "Produts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Purchases_PurchaseId",
                schema: "DogMarketDB",
                table: "Details",
                column: "PurchaseId",
                principalSchema: "DogMarketDB",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
