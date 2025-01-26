using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MDP_Web.Migrations
{
    public partial class CategorieRacheta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieRacheta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RachetaID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieRacheta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieRacheta_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieRacheta_Racheta_RachetaID",
                        column: x => x.RachetaID,
                        principalTable: "Racheta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieRacheta_CategorieID",
                table: "CategorieRacheta",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieRacheta_RachetaID",
                table: "CategorieRacheta",
                column: "RachetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieRacheta");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
