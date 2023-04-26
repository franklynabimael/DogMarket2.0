using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class final3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "DogMarketDB",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74fc47a5-c34c-459e-8f0b-a8112e6252a0", "AQAAAAIAAYagAAAAECGz5xP9VR+rKHa+O7ZDb756M1VArV7s3xRynbY3X2N79TtMl5z/8W7rvJFfKNW7SQ==", "0552019d-84d2-4f2e-9f3d-e6c2f272ecfc" });

            migrationBuilder.InsertData(
                schema: "DogMarketDB",
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"), "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "DogMarketDB",
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"));

            migrationBuilder.UpdateData(
                schema: "DogMarketDB",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91c76056-969c-4276-9716-fd9394eb7b5b", "AQAAAAIAAYagAAAAEIjRhHa/ai/UWAfg2C2ywFtc8MCcJqhVWeouWW/rpFUikIHBF5XWt/hH1sVytNz+kA==", "68d3cad2-be04-4590-af16-4ecc48ed5c7c" });
        }
    }
}
