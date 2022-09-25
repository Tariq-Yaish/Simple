using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple.Migrations
{
    public partial class MgV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBCompanies",
                columns: table => new
                {
                    Company_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCompanies", x => x.Company_ID);
                });

            migrationBuilder.CreateTable(
                name: "DBEmployees",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Age = table.Column<int>(type: "int", nullable: false),
                    Comapny_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBEmployees", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_DBEmployees_DBCompanies_Comapny_Id",
                        column: x => x.Comapny_Id,
                        principalTable: "DBCompanies",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBEmployees_Comapny_Id",
                table: "DBEmployees",
                column: "Comapny_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBEmployees");

            migrationBuilder.DropTable(
                name: "DBCompanies");
        }
    }
}
