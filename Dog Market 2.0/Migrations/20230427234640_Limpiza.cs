using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Limpiza : Migration
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
                values: new object[] { "dc0e7b01-b4f6-4f8b-8fd3-9e93379be683", "AQAAAAIAAYagAAAAEO/zscbu5+jwtW/Jj8jj8q7sG7x0015OdGsTyKo2bqyiarQvFfCxdUJjpOZ4CLpFMg==", "14312a89-ecd9-4971-86aa-2f27d82eefe6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "DogMarketDB",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb67a0fa-82c6-46db-852e-071cf09f12b6", "AQAAAAIAAYagAAAAELpvNo/8HgKyFO7fp5ihKugdSAUB/W7mvxpqsOhPEXyKLU/G6ACobVUQ7/3kCwjM0A==", "fd819abe-2d3a-47e1-a92a-14d224158062" });
        }
    }
}
