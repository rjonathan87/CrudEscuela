using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudEscuela.Migrations
{
    public partial class ControladoresVistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreGenero",
                table: "Alumnos",
                newName: "Nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Alumnos",
                newName: "NombreGenero");
        }
    }
}
