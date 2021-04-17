using Microsoft.EntityFrameworkCore.Migrations;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist_Audio",
                table: "Playlist_Audio");

            migrationBuilder.RenameTable(
                name: "Playlist_Audio",
                newName: "Playlists_Audio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists_Audio",
                table: "Playlists_Audio",
                columns: new[] { "NombrePlaylist", "NombreAudio" });

            migrationBuilder.CreateTable(
                name: "Categoria_Playlist",
                columns: table => new
                {
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    NombrePlaylist = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Playlist", x => new { x.Categoria, x.NombrePlaylist });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria_Playlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists_Audio",
                table: "Playlists_Audio");

            migrationBuilder.RenameTable(
                name: "Playlists_Audio",
                newName: "Playlist_Audio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist_Audio",
                table: "Playlist_Audio",
                columns: new[] { "NombrePlaylist", "NombreAudio" });
        }
    }
}
