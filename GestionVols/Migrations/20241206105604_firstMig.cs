using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class firstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroports",
                columns: table => new
                {
                    IdAeroport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomAeroport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VilleAeroport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysAeroport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroports", x => x.IdAeroport);
                });

            migrationBuilder.CreateTable(
                name: "Avions",
                columns: table => new
                {
                    IdAvion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAvion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapaciteAvion = table.Column<int>(type: "int", nullable: false),
                    FabriquantAvion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avions", x => x.IdAvion);
                });

            migrationBuilder.CreateTable(
                name: "Passagers",
                columns: table => new
                {
                    IdPassager = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPassager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomPassager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPassager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelephonePassager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPasseport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagers", x => x.IdPassager);
                });

            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    IdVol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AeroportDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AeroportArrivee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeureDepart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureArrivee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAvion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.IdVol);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeroports");

            migrationBuilder.DropTable(
                name: "Avions");

            migrationBuilder.DropTable(
                name: "Passagers");

            migrationBuilder.DropTable(
                name: "Vols");
        }
    }
}
