using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class mig_reservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPassager = table.Column<int>(type: "int", nullable: false),
                    IdVol = table.Column<int>(type: "int", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatutReservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixReservation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Passagers_IdPassager",
                        column: x => x.IdPassager,
                        principalTable: "Passagers",
                        principalColumn: "IdPassager",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Vols_IdVol",
                        column: x => x.IdVol,
                        principalTable: "Vols",
                        principalColumn: "IdVol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdPassager",
                table: "Reservations",
                column: "IdPassager");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdVol",
                table: "Reservations",
                column: "IdVol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
