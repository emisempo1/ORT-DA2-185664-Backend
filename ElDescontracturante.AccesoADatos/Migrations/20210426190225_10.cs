using Microsoft.EntityFrameworkCore.Migrations;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problematica_Psicologo",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreProblematica = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problematica_Psicologo", x => new { x.Email, x.NombreProblematica });
                });

            migrationBuilder.CreateTable(
                name: "Psicologo",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeConsulta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psicologo", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problematica_Psicologo");

            migrationBuilder.DropTable(
                name: "Psicologo");
        }
    }
}
