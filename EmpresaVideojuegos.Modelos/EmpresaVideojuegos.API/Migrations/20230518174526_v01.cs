using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaVideojuegos.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desarrolladora",
                columns: table => new
                {
                    Id_desarrolladora = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Pais = table.Column<string>(type: "TEXT", nullable: true),
                    Año = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladora", x => x.Id_desarrolladora);
                });

            migrationBuilder.CreateTable(
                name: "Videojuego",
                columns: table => new
                {
                    Id_videojuego = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Año = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneroPrincipal = table.Column<string>(type: "TEXT", nullable: true),
                    DesarrolladoraId_desarrolladora = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuego", x => x.Id_videojuego);
                    table.ForeignKey(
                        name: "FK_Videojuego_Desarrolladora_DesarrolladoraId_desarrolladora",
                        column: x => x.DesarrolladoraId_desarrolladora,
                        principalTable: "Desarrolladora",
                        principalColumn: "Id_desarrolladora");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videojuego_DesarrolladoraId_desarrolladora",
                table: "Videojuego",
                column: "DesarrolladoraId_desarrolladora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videojuego");

            migrationBuilder.DropTable(
                name: "Desarrolladora");
        }
    }
}
