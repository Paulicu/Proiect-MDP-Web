using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MDP_Web.Migrations
{
    public partial class ServiciiModificat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipServiciu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    RachetaID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_Racheta_RachetaID",
                        column: x => x.RachetaID,
                        principalTable: "Racheta",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_ClientID",
                table: "Serviciu",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_RachetaID",
                table: "Serviciu",
                column: "RachetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
