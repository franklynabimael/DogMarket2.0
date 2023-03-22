using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Market_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "DogMarketDB",
                table: "Produts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "DogMarketDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produts_CategoryId",
                schema: "DogMarketDB",
                table: "Produts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produts_Categories_CategoryId",
                schema: "DogMarketDB",
                table: "Produts",
                column: "CategoryId",
                principalSchema: "DogMarketDB",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produts_Categories_CategoryId",
                schema: "DogMarketDB",
                table: "Produts");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "DogMarketDB");

            migrationBuilder.DropIndex(
                name: "IX_Produts_CategoryId",
                schema: "DogMarketDB",
                table: "Produts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "DogMarketDB",
                table: "Produts");
        }
    }
}
