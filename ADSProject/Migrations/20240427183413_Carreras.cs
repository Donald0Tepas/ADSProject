using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSProject.Migrations
{
    /// <inheritdoc />
    public partial class Carreras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    IdCarrera = table.Column<int>(type: "int", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    Ciclo = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    NombreMateria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMateria = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.NombreMateria);
                });

            migrationBuilder.CreateTable(
                name: "profesores",
                columns: table => new
                {
                    NombresProfesor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApellidosProfesor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdProfesor = table.Column<int>(type: "int", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.NombresProfesor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "profesores");
        }
    }
}
