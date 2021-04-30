using Microsoft.EntityFrameworkCore.Migrations;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailPaciente",
                table: "Cita",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailPaciente",
                table: "Cita");
        }
    }
}
