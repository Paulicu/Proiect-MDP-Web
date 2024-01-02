using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MDP_Web.Migrations
{
    public partial class CreateMagazin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagazinID",
                table: "Racheta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Magazin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireMagazin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazin", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racheta_MagazinID",
                table: "Racheta",
                column: "MagazinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racheta_Magazin_MagazinID",
                table: "Racheta",
                column: "MagazinID",
                principalTable: "Magazin",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racheta_Magazin_MagazinID",
                table: "Racheta");

            migrationBuilder.DropTable(
                name: "Magazin");

            migrationBuilder.DropIndex(
                name: "IX_Racheta_MagazinID",
                table: "Racheta");

            migrationBuilder.DropColumn(
                name: "MagazinID",
                table: "Racheta");
        }
    }
}
