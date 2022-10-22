using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audi.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audi", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Audi",
                columns: new[] { "Id", "Brand", "Description", "Model", "Price" },
                values: new object[] { 1, "Audi", "The most luxary model", "A8l", 1090321 });

            migrationBuilder.InsertData(
                table: "Audi",
                columns: new[] { "Id", "Brand", "Description", "Model", "Price" },
                values: new object[] { 2, "Audi", " The most faster jeep", "RS Q8", 1090321 });

            migrationBuilder.InsertData(
                table: "Audi",
                columns: new[] { "Id", "Brand", "Description", "Model", "Price" },
                values: new object[] { 3, "Audi", "Sooo beautiful))", "RS7", 1090321 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audi");
        }
    }
}
