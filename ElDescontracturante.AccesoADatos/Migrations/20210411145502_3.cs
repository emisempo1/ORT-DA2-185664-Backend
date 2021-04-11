using Microsoft.EntityFrameworkCore.Migrations;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlist_Audio",
                columns: table => new
                {
                    NombrePlaylist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreAudio = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist_Audio", x => new { x.NombrePlaylist, x.NombreAudio });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Playlist_Audio");
        }
    }
}
