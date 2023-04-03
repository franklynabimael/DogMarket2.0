using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                schema: "DogMarketDB",
                table: "Details",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details",
                column: "CartId",
                principalSchema: "DogMarketDB",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                schema: "DogMarketDB",
                table: "Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Carts_CartId",
                schema: "DogMarketDB",
                table: "Details",
                column: "CartId",
                principalSchema: "DogMarketDB",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
