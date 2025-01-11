using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Speedrun.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    CodTara = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.CodTara);
                });

            migrationBuilder.CreateTable(
                name: "Oras",
                columns: table => new
                {
                    CodOras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumarulLocuitori = table.Column<int>(type: "int", nullable: false),
                    CodTara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oras", x => x.CodOras);
                    table.ForeignKey(
                        name: "FK_Oras_Tara_CodTara",
                        column: x => x.CodTara,
                        principalTable: "Tara",
                        principalColumn: "CodTara",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oras_CodTara",
                table: "Oras",
                column: "CodTara");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oras");

            migrationBuilder.DropTable(
                name: "Tara");
        }
    }
}
