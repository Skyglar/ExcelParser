using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelParser.Domain.Migrations
{
    public partial class intialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spreadsheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDX = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Node = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contains_Att = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contains_Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Between_Att = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Between_Lo = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    Between_Hi = table.Column<decimal>(type: "decimal(10,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spreadsheet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spreadsheet");
        }
    }
}
