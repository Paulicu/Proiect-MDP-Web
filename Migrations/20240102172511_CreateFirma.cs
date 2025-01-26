using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MDP_Web.Migrations
{
    public partial class CreateFirma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmaID",
                table: "Racheta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racheta_FirmaID",
                table: "Racheta",
                column: "FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racheta_Firma_FirmaID",
                table: "Racheta",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racheta_Firma_FirmaID",
                table: "Racheta");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_Racheta_FirmaID",
                table: "Racheta");

            migrationBuilder.DropColumn(
                name: "FirmaID",
                table: "Racheta");
        }
    }
}
