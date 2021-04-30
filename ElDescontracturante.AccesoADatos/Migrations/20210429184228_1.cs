using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    UnidadDeTiempo = table.Column<int>(type: "int", nullable: false),
                    NombreCreador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlMp3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Nombre);
                });

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

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    NombreCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.NombreCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailPsicologo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePsicologo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDeConsulta = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Playlists_Audio",
                columns: table => new
                {
                    NombrePlaylist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreAudio = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists_Audio", x => new { x.NombrePlaylist, x.NombreAudio });
                });

            migrationBuilder.CreateTable(
                name: "Problematica_Psicologo",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreProblematica = table.Column<int>(type: "int", nullable: false)
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
                    TipoDeConsulta = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DireccionFisica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psicologo", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Categoria_Playlist");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Playlists_Audio");

            migrationBuilder.DropTable(
                name: "Problematica_Psicologo");

            migrationBuilder.DropTable(
                name: "Psicologo");

            migrationBuilder.DropTable(
                name: "Tokens");
        }
    }
}
