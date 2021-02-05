using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNetCoreWithReact.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daprt",
                columns: table => new
                {
                    DepartNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Locations = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daprt", x => x.DepartNumber);
                });

            migrationBuilder.InsertData(
                table: "Daprt",
                columns: new[] { "DepartNumber", "Departname", "Locations" },
                values: new object[,]
                {
                    { 1, "Sofia", "Airport Terminal 1" },
                    { 2, "Sofia", "Airport Terminal 2" },
                    { 3, "Plovdiv", "Novotel" },
                    { 4, "Stara Zagora", "Stadium Beroe" },
                    { 5, "Shumen", "Post Office" },
                    { 6, "Burgas", "Post Office" },
                    { 7, "Varna", "Dolphinarium" },
                    { 8, "Pleven", "Hotel Bulgaria" },
                    { 9, "Sozopol", "Old City Post Office" },
                    { 10, "Lovech", "Varosha Gallery" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daprt");
        }
    }
}
