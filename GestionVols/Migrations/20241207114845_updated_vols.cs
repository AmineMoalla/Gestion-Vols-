using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class updated_vols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AeroportArrivee",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "AeroportDepart",
                table: "Vols");

            migrationBuilder.AddColumn<int>(
                name: "IdAeroportArrivee",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAeroportDepart",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAeroportArrivee",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "IdAeroportDepart",
                table: "Vols");

            migrationBuilder.AddColumn<string>(
                name: "AeroportArrivee",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AeroportDepart",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
