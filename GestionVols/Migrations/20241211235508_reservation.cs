using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Avions_IdAvion",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_IdAvion",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "IdAvion",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "NbreReservée",
                table: "Vols");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAvion",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbreReservée",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vols_IdAvion",
                table: "Vols",
                column: "IdAvion");

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Avions_IdAvion",
                table: "Vols",
                column: "IdAvion",
                principalTable: "Avions",
                principalColumn: "IdAvion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
