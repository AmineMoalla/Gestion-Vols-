using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vols_IdAeroportArrivee",
                table: "Vols",
                column: "IdAeroportArrivee");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_IdAeroportDepart",
                table: "Vols",
                column: "IdAeroportDepart");

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Aeroports_IdAeroportArrivee",
                table: "Vols",
                column: "IdAeroportArrivee",
                principalTable: "Aeroports",
                principalColumn: "IdAeroport",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Aeroports_IdAeroportDepart",
                table: "Vols",
                column: "IdAeroportDepart",
                principalTable: "Aeroports",
                principalColumn: "IdAeroport",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Aeroports_IdAeroportArrivee",
                table: "Vols");

            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Aeroports_IdAeroportDepart",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_IdAeroportArrivee",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_IdAeroportDepart",
                table: "Vols");
        }
    }
}
