using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVols.Migrations
{
    /// <inheritdoc />
    public partial class offre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offres",
                columns: table => new
                {
                    IdOffre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomOffre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PourcentageReduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdVol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offres", x => x.IdOffre);
                    table.ForeignKey(
                        name: "FK_Offres_Vols_IdVol",
                        column: x => x.IdVol,
                        principalTable: "Vols",
                        principalColumn: "IdVol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offres_IdVol",
                table: "Offres",
                column: "IdVol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offres");
        }
    }
}
