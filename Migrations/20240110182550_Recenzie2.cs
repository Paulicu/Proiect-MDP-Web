using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MDP_Web.Migrations
{
    public partial class Recenzie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recenzie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentariu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    RachetaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzie_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Recenzie_Racheta_RachetaID",
                        column: x => x.RachetaID,
                        principalTable: "Racheta",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_ClientID",
                table: "Recenzie",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_RachetaID",
                table: "Recenzie",
                column: "RachetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recenzie");
        }
    }
}
