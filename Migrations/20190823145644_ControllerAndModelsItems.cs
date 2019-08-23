using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudEscuela.Migrations
{
    public partial class ControllerAndModelsItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "Materias",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Alumnos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Alumnos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Alumnos");
        }
    }
}
