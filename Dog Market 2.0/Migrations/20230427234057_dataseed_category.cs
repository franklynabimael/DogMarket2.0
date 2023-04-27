using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class dataseed_category : Migration
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
                values: new object[] { "fb67a0fa-82c6-46db-852e-071cf09f12b6", "AQAAAAIAAYagAAAAELpvNo/8HgKyFO7fp5ihKugdSAUB/W7mvxpqsOhPEXyKLU/G6ACobVUQ7/3kCwjM0A==", "fd819abe-2d3a-47e1-a92a-14d224158062" });

            migrationBuilder.InsertData(
                schema: "DogMarketDB",
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Son Juguetes", "Juguetes" },
                    { 2, "Lo que comen los perros", "Comida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "DogMarketDB",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "DogMarketDB",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                schema: "DogMarketDB",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74fc47a5-c34c-459e-8f0b-a8112e6252a0", "AQAAAAIAAYagAAAAECGz5xP9VR+rKHa+O7ZDb756M1VArV7s3xRynbY3X2N79TtMl5z/8W7rvJFfKNW7SQ==", "0552019d-84d2-4f2e-9f3d-e6c2f272ecfc" });
        }
    }
}
