using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class startPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "price", "title" },
                values: new object[] { 1, 115m, "Hacivat ve Karagöz" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "price", "title" },
                values: new object[] { 2, 150m, "Mesneviler" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "price", "title" },
                values: new object[] { 3, 501m, "Devlet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
