using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class prixVolReservationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrixReservation",
                table: "Reservations",
                newName: "PrixReservationTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "PrixVol",
                table: "Vols",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NbrePassagers",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeClasse",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixVol",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "NbrePassagers",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TypeClasse",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PrixReservationTotal",
                table: "Reservations",
                newName: "PrixReservation");
        }
    }
}
