using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Purchase_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseId",
                schema: "DogMarketDB",
                table: "Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Purchases",
                schema: "DogMarketDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    NumVoucher = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DogMarketDB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_PurchaseId",
                schema: "DogMarketDB",
                table: "Details",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                schema: "DogMarketDB",
                table: "Purchases",
                column: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Purchases_PurchaseId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropTable(
                name: "Purchases",
                schema: "DogMarketDB");

            migrationBuilder.DropIndex(
                name: "IX_Details_PurchaseId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                schema: "DogMarketDB",
                table: "Details");
        }
    }
}
