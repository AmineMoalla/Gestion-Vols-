using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Avions_IdAvion",
                table: "Vols");

            migrationBuilder.RenameColumn(
                name: "PrixReservation",
                table: "Reservations",
                newName: "PrixReservationTotal");

            migrationBuilder.AlterColumn<int>(
                name: "IdAvion",
                table: "Vols",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Avions_IdAvion",
                table: "Vols",
                column: "IdAvion",
                principalTable: "Avions",
                principalColumn: "IdAvion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Avions_IdAvion",
                table: "Vols");

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

            migrationBuilder.AlterColumn<int>(
                name: "IdAvion",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
